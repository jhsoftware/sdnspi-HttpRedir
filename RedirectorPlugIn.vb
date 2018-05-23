Imports JHSoftware.SimpleDNS.Plugin

Public Class RedirectorPlugIn
  Implements IGetHostPlugIn

  Private Cfg As MyConfig
  Private MinSegCount As Integer
  Private MaxSegCount As Integer
  Private DomsWithSub As Dictionary(Of DomainName, MyConfig.HNRedir)

  Private IsStopping As Boolean

  Private Listener As System.Net.HttpListener

#Region "events"
  Public Event LogLine(ByVal text As String) Implements JHSoftware.SimpleDNS.Plugin.IPlugInBase.LogLine
  Public Event AsyncError(ByVal ex As System.Exception) Implements JHSoftware.SimpleDNS.Plugin.IGetHostPlugIn.AsyncError
  Public Event SaveConfig(ByVal config As String) Implements JHSoftware.SimpleDNS.Plugin.IGetHostPlugIn.SaveConfig
#End Region

#Region "read only properties"

  Public Function GetPlugInTypeInfo() As JHSoftware.SimpleDNS.Plugin.IPlugInBase.PlugInTypeInfo Implements JHSoftware.SimpleDNS.Plugin.IPlugInBase.GetPlugInTypeInfo
    With GetPlugInTypeInfo
      .Name = "HTTP Redirector"
      .Description = "Redirects HTTP requests to another URL / port"
      .InfoURL = "http://www.simpledns.com/kb.aspx?kbid=1258"
      .ConfigFile = False
    End With
  End Function

  Public Function GetDNSAskAbout() As JHSoftware.SimpleDNS.Plugin.DNSAskAboutGH Implements JHSoftware.SimpleDNS.Plugin.IGetHostPlugIn.GetDNSAskAbout
    With GetDNSAskAbout
      .ForwardIPv4 = True
    End With
  End Function

#End Region

#Region "not implemented"
  Public Sub LookupReverse(ByVal req As IDNSRequest, ByRef resultName As JHSoftware.SimpleDNS.Plugin.DomainName, ByRef resultTTL As Integer) Implements JHSoftware.SimpleDNS.Plugin.IGetHostPlugIn.LookupReverse
  End Sub

  Public Sub LookupTXT(ByVal req As IDNSRequest, ByRef resultText As String, ByRef resultTTL As Integer) Implements JHSoftware.SimpleDNS.Plugin.IGetHostPlugIn.LookupTXT
  End Sub

  Public Sub LoadState(ByVal state As String) Implements JHSoftware.SimpleDNS.Plugin.IPlugInBase.LoadState
  End Sub

  Public Function SaveState() As String Implements JHSoftware.SimpleDNS.Plugin.IPlugInBase.SaveState
    Return ""
  End Function

#End Region

#Region "other methods"
  Public Sub Lookup(ByVal req As IDNSRequest, ByRef resultIP As IPAddress, ByRef resultTTL As Integer) Implements JHSoftware.SimpleDNS.Plugin.IGetHostPlugIn.Lookup
    Dim lookupName = req.QName
    Dim sc = lookupName.SegmentCount
    If sc < MinSegCount Then Exit Sub
    If sc <= MaxSegCount AndAlso Cfg.Redirs.ContainsKey(lookupName) Then
      resultIP = Cfg.PublicIP
      resultTTL = 5
      Exit Sub
    End If
    If DomsWithSub.Count = 0 Then Exit Sub
    While sc > MinSegCount
      lookupName = lookupName.Parent
      sc -= 1
      If DomsWithSub.ContainsKey(lookupName) Then
        resultIP = Cfg.PublicIP
        resultTTL = 5
        Exit Sub
      End If
    End While
  End Sub

  Public Function GetOptionsUI(ByVal instanceID As Guid, ByVal dataPath As String) As JHSoftware.SimpleDNS.Plugin.OptionsUI Implements JHSoftware.SimpleDNS.Plugin.IPlugInBase.GetOptionsUI
    Return New OptionsUI
  End Function

  Public Function InstanceConflict(ByVal config1 As String, ByVal config2 As String, ByRef errorMsg As String) As Boolean Implements JHSoftware.SimpleDNS.Plugin.IPlugInBase.InstanceConflict
    Dim cfg1 = MyConfig.LoadFromXML(config1)
    Dim cfg2 = MyConfig.LoadFromXML(config2)
    If cfg1.BindIP.Equals(cfg2.BindIP) AndAlso cfg1.BindPort = cfg2.BindPort Then
      errorMsg = "Another HTTP Redirector plug-in uses the same IP address / port"
      Return True
    End If
    Return False
  End Function

  Public Sub LoadConfig(ByVal config As String, ByVal instanceID As Guid, ByVal dataPath As String, ByRef maxThreads As Integer) Implements JHSoftware.SimpleDNS.Plugin.IPlugInBase.LoadConfig
    Cfg = MyConfig.LoadFromXML(config)
    MinSegCount = 9999
    MaxSegCount = 0
    DomsWithSub = New Dictionary(Of DomainName, MyConfig.HNRedir)
    Dim sc As Integer
    For Each dom In Cfg.Redirs.Values
      If dom.SubDoms Then DomsWithSub.Add(dom.Name, dom)
      sc = dom.Name.SegmentCount
      If sc < MinSegCount Then MinSegCount = sc
      If sc > MaxSegCount Then MaxSegCount = sc
    Next
  End Sub

  Public Sub StartService() Implements JHSoftware.SimpleDNS.Plugin.IPlugInBase.StartService
    IsStopping = False

    Try
      Listener = New System.Net.HttpListener
      Listener.IgnoreWriteExceptions = True
      Listener.Prefixes.Add("http://" & Cfg.BindIP.ToString & ":" & Cfg.BindPort & "/")
      Listener.Start()
    Catch ex As Exception
      RaiseEvent LogLine("HTTP listener not started - Error: " & ex.Message)
      Exit Sub
    End Try

    Listener.BeginGetContext(AddressOf ListenerCallBack, Listener)

    RaiseEvent LogLine("Listening for HTTP requests on " & Cfg.BindIP.ToString & " port " & Cfg.BindPort)
  End Sub

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
        RaiseEvent LogLine("*** GetContext caused error: " & ex.Message)
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
          If rd.CloakTitle.Length > 0 Then RespBody &= _
                      "<head>" & vbCrLf & _
                      "<title>" & HTMLEncode(rd.CloakTitle) & "</title>" & vbCrLf & _
                      "</head>" & vbCrLf
          RespBody &= "<frameset cols=""0,*"" framespacing=""0"" border=""0"" frameborder=""0"">" & vbCrLf & _
                      "<frame name=""zero"" scrolling=""no"" noresize>" & vbCrLf & _
                      "<frame name=""main"" src=""" & HTMLEncode(ToAddr) & """>" & vbCrLf & _
                      "</frameset>" & vbCrLf & _
                      "</html>" & vbCrLf
        Else
          RespBody = "<html>" & vbCrLf & _
                     "<head>" & vbCrLf & _
                     "<title>Document Moved</title>" & vbCrLf & _
                     "</head>" & vbCrLf & _
                     "<body>" & vbCrLf & _
                     "<h1>Document Moved</h1>" & vbCrLf & _
                     "<p>This document may be found <a href=""" & HTMLEncode(ToAddr) & """>here</a></p>" & vbCrLf & _
                     "</body>" & vbCrLf & _
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
      RaiseEvent LogLine("HTTP request from " & ctx.Request.RemoteEndPoint.Address.ToString & _
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
      RaiseEvent AsyncError(ex)
    End Try
  End Sub

  Private Function FindRedir(ByVal hn As String) As MyConfig.HNRedir
    If String.IsNullOrEmpty(hn) Then Return Cfg.DefaultRedir
    Dim hnDom As DomainName = Nothing
    If Not DomainName.TryParse(hn, hnDom) Then Return Cfg.DefaultRedir
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
      If (b >= 48 AndAlso b <= 57) OrElse _
         (b >= 65 AndAlso b <= 90) OrElse _
         (b >= 97 AndAlso b <= 122) OrElse _
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
