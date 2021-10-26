Imports JHSoftware.SimpleDNS.Plugin

Public Class RedirectorPlugIn
  Implements ILookupHost
  Implements IOptionsUI

  Private Cfg As MyConfig
  Private MinSegCount As Integer
  Private MaxSegCount As Integer
  Private DomsWithSub As Dictionary(Of DomName, MyConfig.HNRedir)

  Private IsStopping As Boolean

  Private Listener As System.Net.HttpListener

  Public Property Host As IHost Implements IPlugInBase.Host

#Region "read only properties"

  Public Function GetPlugInTypeInfo() As Plugin.IPlugInBase.PlugInTypeInfo Implements JHSoftware.SimpleDNS.Plugin.IPlugInBase.GetTypeInfo
    With GetPlugInTypeInfo
      .Name = "HTTP Redirector"
      .Description = "Redirects HTTP requests to another URL / port"
      .InfoURL = "https://simpledns.plus/plugin-httpredir"
    End With
  End Function

#End Region

#Region "not implemented"
  Public Sub LoadState(ByVal state As String) Implements JHSoftware.SimpleDNS.Plugin.IPlugInBase.LoadState
  End Sub

  Public Function SaveState() As String Implements JHSoftware.SimpleDNS.Plugin.IPlugInBase.SaveState
    Return ""
  End Function

#End Region

#Region "other methods"

  Public Function Lookup(name As DomName, ipv6 As Boolean, req As IRequestContext) As Threading.Tasks.Task(Of LookupResult(Of SdnsIP)) Implements JHSoftware.SimpleDNS.Plugin.ILookupHost.LookupHost
    Return Threading.Tasks.Task.FromResult(Lookup2(name, ipv6, req))
  End Function
  Private Function Lookup2(name As DomName, ipv6 As Boolean, req As IRequestContext) As LookupResult(Of SdnsIP)
    If ipv6 Then
      If Cfg.BindIPv6 Is Nothing Then Return Nothing
    Else
      If Cfg.BindIPv4 Is Nothing Then Return Nothing
    End If

    Dim sc = name.SegmentCount
    If sc < MinSegCount Then Return Nothing
    If sc <= MaxSegCount AndAlso Cfg.Redirs.ContainsKey(name) Then
      Return New LookupResult(Of SdnsIP) With {.Value = Cfg.DnsIP(ipv6), .TTL = 5}
    End If
    If DomsWithSub.Count = 0 Then Return Nothing
    While sc > MinSegCount
      name = name.Parent
      sc -= 1
      If DomsWithSub.ContainsKey(name) Then
        Return New LookupResult(Of SdnsIP) With {.Value = Cfg.DnsIP(ipv6), .TTL = 5}
      End If
    End While
    Return Nothing
  End Function

  Public Function GetOptionsUI(ByVal instanceID As Guid, ByVal dataPath As String) As JHSoftware.SimpleDNS.Plugin.OptionsUI Implements JHSoftware.SimpleDNS.Plugin.IOptionsUI.GetOptionsUI
    Return New OptionsUI
  End Function

  Public Function InstanceConflict(ByVal config1 As String, ByVal config2 As String, ByRef errorMsg As String) As Boolean Implements JHSoftware.SimpleDNS.Plugin.IPlugInBase.InstanceConflict
    Dim cfg1 = MyConfig.LoadFromXML(config1)
    Dim cfg2 = MyConfig.LoadFromXML(config2)
    For Each bnd1 In cfg1.GetBindings
      For Each bnd2 In cfg2.GetBindings
        If bnd1.BindIP = bnd2.BindIP AndAlso bnd1.BindPort = bnd2.BindPort Then errorMsg = "Another HTTP Redirector plug-in uses the same IP address / port" : Return True
      Next
    Next
    Return False
  End Function

  Public Sub LoadConfig(ByVal config As String, ByVal instanceID As Guid, ByVal dataPath As String) Implements JHSoftware.SimpleDNS.Plugin.IPlugInBase.LoadConfig
    Cfg = MyConfig.LoadFromXML(config)
    MinSegCount = 9999
    MaxSegCount = 0
    DomsWithSub = New Dictionary(Of DomName, MyConfig.HNRedir)
    Dim sc As Integer
    For Each dom In Cfg.Redirs.Values
      If dom.SubDoms Then DomsWithSub.Add(dom.Name, dom)
      sc = dom.Name.SegmentCount
      If sc < MinSegCount Then MinSegCount = sc
      If sc > MaxSegCount Then MaxSegCount = sc
    Next
  End Sub

  Public Async Function StartService() As Threading.Tasks.Task Implements JHSoftware.SimpleDNS.Plugin.IPlugInBase.StartService
    IsStopping = False

    Try
      Listener = New System.Net.HttpListener
      Listener.IgnoreWriteExceptions = True
    Catch ex As Exception
      Host.LogLine("Could not initiate HTTP listener - Error: " & ex.Message)
      Exit Function
    End Try

    For Each pfx In Cfg.GetBindings
      Try
        Listener.Prefixes.Add(pfx.Prefix)
      Catch ex As Exception
        Host.LogLine("Could not add HTTP listener prefix " & pfx.Prefix & " - Error: " & ex.Message)
        Exit Function
      End Try
    Next

    Try
      Listener.Start()
      Listener.BeginGetContext(AddressOf ListenerCallBack, Listener)
    Catch ex As Exception
      Host.LogLine("Could not start HTTP listener - Error: " & ex.Message)
      Exit Function
    End Try

    Host.LogLine("Listening for HTTP requests")
  End Function

  Public Sub StopService() Implements JHSoftware.SimpleDNS.Plugin.IPlugInBase.StopService
    IsStopping = True
    Try
      Listener.Stop()
      Listener.Abort()
    Catch
    End Try
  End Sub

  Private Sub ListenerCallBack(ByVal ia As IAsyncResult)
    Try

      Dim ctx As System.Net.HttpListenerContext = Nothing
      Try
        ctx = Listener.EndGetContext(ia)
      Catch ex As Exception
        If IsStopping Then Exit Sub
        Host.LogLine("*** GetContext caused error: " & ex.Message)
        Exit Sub
      End Try

      Dim HostName = ctx.Request.UserHostName
      If HostName Is Nothing Then HostName = ""
      Dim i = HostName.LastIndexOf(":"c)
      If i > 0 Then HostName = HostName.Substring(0, i)
      Dim rd = FindRedir(HostName)

      Dim ToAddr = rd.ToURL
      If rd.Relative Then
        If Not ToAddr.EndsWith("/") Then ToAddr &= "/"
        HostName = ctx.Request.RawUrl.Trim
        If HostName.StartsWith("/") Then HostName = HostName.Substring(1)
        ToAddr &= HostName
      Else
        ToAddr = ToAddr.Replace("#HOST#", HostName)
        ToAddr = ToAddr.Replace("#PATH#", URLEncode(ctx.Request.Url.AbsolutePath))
        ToAddr = ToAddr.Replace("#QUERY#", URLEncode(ctx.Request.Url.Query))
      End If

      Dim RespBody As String
      If ctx.Request.HttpMethod = "HEAD" Then
        RespBody = ""
      Else
        If rd.Method = MyConfig.HNRedir.RedirMethod.Cloak Then
          RespBody = "<html>" & vbCrLf
          If rd.CloakTitle.Length > 0 Then RespBody &=
                      "<head>" & vbCrLf &
                      "<title>" & HTMLEncode(rd.CloakTitle) & "</title>" & vbCrLf &
                      "</head>" & vbCrLf
          RespBody &= "<frameset cols=""0,*"" framespacing=""0"" border=""0"" frameborder=""0"">" & vbCrLf &
                      "<frame name=""zero"" scrolling=""no"" noresize>" & vbCrLf &
                      "<frame name=""main"" src=""" & HTMLEncode(ToAddr) & """>" & vbCrLf &
                      "</frameset>" & vbCrLf &
                      "</html>" & vbCrLf
        Else
          RespBody = "<html>" & vbCrLf &
                     "<head>" & vbCrLf &
                     "<title>Document Moved</title>" & vbCrLf &
                     "</head>" & vbCrLf &
                     "<body>" & vbCrLf &
                     "<h1>Document Moved</h1>" & vbCrLf &
                     "<p>This document may be found <a href=""" & HTMLEncode(ToAddr) & """>here</a></p>" & vbCrLf &
                     "</body>" & vbCrLf &
                     "</html>" & vbCrLf
        End If
      End If

      If rd.Method <> MyConfig.HNRedir.RedirMethod.Cloak Then
        ctx.Response.AddHeader("Location", ToAddr)
        ctx.Response.StatusCode = If(rd.Method = MyConfig.HNRedir.RedirMethod.Status302, 302, 301)
      End If
      ctx.Response.KeepAlive = False
      ctx.Response.AddHeader("X-Powered-By", "Simple DNS Plus")
      ctx.Response.AddHeader("Cache-Control", "private")
      ctx.Response.ContentType = "text/html; charset=UTF-8"
      Dim ba = System.Text.Encoding.UTF8.GetBytes(RespBody)

      REM this must be before response.close - otherwise cannot access ctx anymore (fixed v. 1.0.1)
      Host.LogLine("HTTP request from " & ctx.Request.RemoteEndPoint.Address.ToString &
                           " for """ & ctx.Request.Url.ToString & """ redirected to """ & ToAddr & """")

      Try
        ctx.Response.Close(ba, False)
      Catch ex As System.Net.ProtocolViolationException
        REM bug report with this exception + "Cannot send a content-body with this verb-type."
        REM not sure what verb-type it was - we already take care of HEAD...
      End Try

markWait4Next:
      Listener.BeginGetContext(AddressOf ListenerCallBack, Listener)

    Catch ex As Exception
      Host.AsyncError(ex)
    End Try
  End Sub

  Private Function FindRedir(ByVal hn As String) As MyConfig.HNRedir
    If String.IsNullOrEmpty(hn) Then Return Cfg.DefaultRedir
    Dim hnDom As DomName = Nothing
    If Not DomName.TryParse(hn, hnDom) Then Return Cfg.DefaultRedir
    Dim sc = hnDom.SegmentCount
    If sc < MinSegCount Then Return Cfg.DefaultRedir
    Dim rd As MyConfig.HNRedir = Nothing
    If Cfg.Redirs.TryGetValue(hnDom, rd) Then Return rd
    If DomsWithSub.Count = 0 Then Return Cfg.DefaultRedir
    While sc > MinSegCount
      hnDom = hnDom.Parent
      sc -= 1
      If DomsWithSub.TryGetValue(hnDom, rd) Then Return rd
    End While
    Return Cfg.DefaultRedir
  End Function

  Private Function HTMLEncode(ByVal s As String) As String
    Dim sb As New System.Text.StringBuilder(s.Length)
    For i = 0 To s.Length - 1
      Select Case s(i)
        Case "&"c
          sb.Append("&amp;")
        Case "<"c
          sb.Append("&lt;")
        Case ">"c
          sb.Append("&gt;")
        Case """"c
          sb.Append("&quot;")
        Case "'"c
          sb.Append("&apos;")
        Case Else
          sb.Append(s(i))
      End Select
    Next
    Return sb.ToString
  End Function

  Private Function URLEncode(ByVal s As String) As String
    Dim ba = System.Text.Encoding.UTF8.GetBytes(s)
    Dim sb As New System.Text.StringBuilder(ba.Length)
    Dim b As Byte
    For i = 0 To ba.Length - 1
      b = ba(i)
      REM 0-9, A-Z, a-z, - .
      If (b >= 48 AndAlso b <= 57) OrElse
         (b >= 65 AndAlso b <= 90) OrElse
         (b >= 97 AndAlso b <= 122) OrElse
         (b = 45 Or b = 46) Then
        sb.Append(ChrW(b))
      Else
        sb.Append("%"c)
        sb.Append(b.ToString("X2"))
      End If
    Next
    Return sb.ToString
  End Function

#End Region

End Class
