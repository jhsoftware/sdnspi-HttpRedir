Friend Class MyConfig

  Public ProtoHTTP As Boolean = True
  Public ProtoHTTPS As Boolean = False

  Public BindIPv4 As SdnsIPv4
  Public BindIPv6 As SdnsIPv6

  Public NatIP As SdnsIPv4
  Public NatMap80 As Integer = 80
  Public NatMap443 As Integer = 443

  Public DefaultRedir As HNRedir

  Public Redirs As New Dictionary(Of DomName, HNRedir)

  Friend Function DnsIP(ipV6 As Boolean) As SdnsIP
    If ipV6 Then Return BindIPv6
    Return If(NatIP IsNot Nothing, NatIP, BindIPv4)
  End Function

  Friend Iterator Function GetBindings() As IEnumerable(Of Binding)
    If BindIPv4 IsNot Nothing Then
      Dim Nat = NatIP IsNot Nothing
      If ProtoHTTP Then Yield New Binding With {.SSL = False, .BindIP = BindIPv4, .BindPort = If(Nat, NatMap80, 80), .NatIP = NatIP}
      If ProtoHTTPS Then Yield New Binding With {.SSL = True, .BindIP = BindIPv4, .BindPort = If(Nat, NatMap443, 443), .NatIP = NatIP}
    End If
    If BindIPv6 IsNot Nothing Then
      If ProtoHTTP Then Yield New Binding With {.SSL = False, .BindIP = BindIPv6, .BindPort = 80}
      If ProtoHTTPS Then Yield New Binding With {.SSL = True, .BindIP = BindIPv6, .BindPort = 443}
    End If
  End Function

  Class Binding
    Friend SSL As Boolean
    Friend BindIP As SdnsIP
    Friend BindPort As Integer
    Friend NatIP As SdnsIPv4

    Function Prefix() As String
      Return If(SSL, "https://", "http://") & If(BindIP.IPVersion = 6, "[" & BindIP.ToString & "]", BindIP.ToString) & ":" & BindPort & "/"
    End Function

    Overrides Function ToString() As String
      Return If(SSL, "HTTPS / ", "HTTP / ") & If(NatIP IsNot Nothing, NatIP.ToString & " / " & If(SSL, "443", "80") & " >> ", "") & BindIP.ToString() & " / " & BindPort
    End Function
  End Class

  Friend Function SaveToXML() As Xml.XmlDocument
    Dim doc = New Xml.XmlDocument
    Dim root = JHXML.PrepRoot(doc, "config")
    root.SetAttrInt("Version", 2)

    root.SetAttrBool("HTTP", ProtoHTTP)
    root.SetAttrBool("HTTPS", ProtoHTTPS)

    If BindIPv4 IsNot Nothing Then root.SetAttribute("BindIPv4", BindIPv4.ToString)
    If BindIPv6 IsNot Nothing Then root.SetAttribute("BindIPv6", BindIPv6.ToString)

    If NatIP IsNot Nothing Then
      root.SetAttribute("NatIP", NatIP.ToString)
      If NatMap80 <> 80 Then root.SetAttrInt("NatMapHTTP", NatMap80)
      If NatMap443 <> 443 Then root.SetAttrInt("NatMapHTTPS", NatMap443)
    End If

    DefaultRedir.SaveToXML(root.CreateChildElement("Default"))

    For Each dom In Redirs.Values
      DirectCast(dom, MyConfig.HNRedir).SaveToXML(root.CreateChildElement("HostName"))
    Next
    Return doc
  End Function

  Friend Shared Function LoadFromXML(ByVal s As String) As MyConfig
    Dim rv As New MyConfig
    Dim doc = New Xml.XmlDocument
    doc.LoadXml(s)
    Dim root = DirectCast(doc.GetElementsByTagName("config").Item(0), Xml.XmlElement)
    Dim Version = root.GetAttrInt("Version", 1)
    With rv
      If Version < 1 OrElse Version > 2 Then Throw New Exception("Unknown configuration file version")

      If Version = 1 Then
        .ProtoHTTP = True
        .ProtoHTTPS = False

        .BindIPv4 = SdnsIPv4.Parse(root.GetAttrStr("bindIP"))
        .BindIPv6 = Nothing

        Dim BehindNat = root.GetAttrBool("NAT")
        If BehindNat Then
          .NatIP = SdnsIPv4.Parse(root.GetAttrStr("publicIP"))
          .NatMap80 = root.GetAttrInt("bindPort", 80)
          .NatMap443 = 443
        End If
      Else
        .ProtoHTTP = root.GetAttrBool("HTTP")
        .ProtoHTTPS = root.GetAttrBool("HTTPS")

        If root.HasAttribute("BindIPv4") Then .BindIPv4 = SdnsIPv4.Parse(root.GetAttrStr("BindIPv4"))
        If root.HasAttribute("BindIPv6") Then .BindIPv6 = SdnsIPv6.Parse(root.GetAttrStr("BindIPv6"))

        If root.HasAttribute("NatIP") Then
          .NatIP = SdnsIPv4.Parse(root.GetAttrStr("NatIP"))
          .NatMap80 = root.GetAttrInt("NatMapHTTP", 80)
          .NatMap443 = root.GetAttrInt("NatMapHTTPS", 443)
        End If
      End If

      .DefaultRedir = HNRedir.LoadFromXML(DirectCast(root.GetElementsByTagName("Default")(0), Xml.XmlElement))

      Dim dom As HNRedir
      For Each elem2 As Xml.XmlElement In root.GetElementsByTagName("HostName")
        dom = HNRedir.LoadFromXML(elem2)
        .Redirs.Add(dom.Name, dom)
      Next

    End With
    Return rv
  End Function

  Friend Class HNRedir
    Implements AERListBoxMC.IItem

    Public Name As DomName
    Public SubDoms As Boolean
    Public ToURL As String
    Public Relative As Boolean
    Public Method As RedirMethod
    Public CloakTitle As String

    Friend Enum RedirMethod
      Status302 = 0
      Status301 = 1
      Cloak = 2
    End Enum

    Public Function ColumnText(ByVal index As Integer) As String Implements AERListBoxMC.IItem.ColumnText
      Select Case index
        Case 0
          Return Name.ToString
        Case 1
          Return ToURL
      End Select
      Return Nothing
    End Function

    Public Function ColumnCompare(ByVal colIndex As Integer, ByVal otherItem As AERListBoxMC.IItem) As Integer Implements AERListBoxMC.IItem.ColumnCompareTo
      With DirectCast(otherItem, HNRedir)
        Select Case colIndex
          Case 0
            Return Name.CompareTo(.Name)
          Case 1
            Return ToURL.CompareTo(.ToURL)
        End Select
      End With
    End Function

    Public Sub SaveToXML(ByVal elem As Xml.XmlElement)
      With elem
        If Name <> DomName.Root Then .SetAttribute("name", Name.ToString)
        If SubDoms Then .SetAttrBool("subNames", True)
        .SetAttribute("URL", ToURL)
        If Relative Then .SetAttrBool("relative", True)
        Select Case Method
          Case RedirMethod.Status302
            .SetAttribute("method", "302")
          Case RedirMethod.Status301
            .SetAttribute("method", "301")
          Case RedirMethod.Cloak
            .SetAttribute("method", "cloak")
        End Select
        If CloakTitle.Length > 0 Then .SetAttribute("cloakTitle", CloakTitle)
      End With
    End Sub

    Public Shared Function LoadFromXML(ByVal elem As Xml.XmlElement) As HNRedir
      Dim rv As New HNRedir
      With rv
        .Name = DomName.Parse(elem.GetAttrStr("name", "."))
        .SubDoms = elem.GetAttrBool("subNames")
        .ToURL = elem.GetAttrStr("URL")
        .Relative = elem.GetAttrBool("relative")
        Select Case elem.GetAttrStr("method").ToLower
          Case "302"
            .Method = RedirMethod.Status302
          Case "301"
            .Method = RedirMethod.Status301
          Case "cloak"
            .Method = RedirMethod.Cloak
        End Select
        .CloakTitle = elem.GetAttrStr("cloakTitle")
      End With
      Return rv
    End Function

  End Class

End Class
