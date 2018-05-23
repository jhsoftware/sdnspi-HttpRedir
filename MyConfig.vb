Friend Class MyConfig

  Public BindNat As Boolean
  Public BindIP As JHSoftware.SimpleDNS.Plugin.IPAddressV4
  Public PublicIP As JHSoftware.SimpleDNS.Plugin.IPAddressV4
  Public BindPort As Integer

  Public DefaultRedir As HNRedir

  Public Redirs As New Dictionary(Of JHSoftware.SimpleDNS.Plugin.DomainName, HNRedir)

  Friend Function SaveToXML() As Xml.XmlDocument
    Dim doc = New Xml.XmlDocument
    Dim root = JHXML.PrepRoot(doc, "config")
    root.SetAttrBool("NAT", BindNat)
    root.SetAttribute("bindIP", BindIP.ToString)
    If BindNat Then
      root.SetAttribute("publicIP", PublicIP.ToString)
      If BindPort <> 80 Then root.SetAttrInt("bindPort", BindPort)
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
    With rv
      .BindNat = root.GetAttrBool("NAT")
      .BindIP = JHSoftware.SimpleDNS.Plugin.IPAddressV4.Parse(root.GetAttrStr("bindIP"))
      If .BindNat Then
        .PublicIP = JHSoftware.SimpleDNS.Plugin.IPAddressV4.Parse(root.GetAttrStr("publicIP"))
        .BindPort = root.GetAttrInt("bindPort", 80)
      Else
        .PublicIP = .BindIP
        .BindPort = 80
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

    Public Name As JHSoftware.SimpleDNS.Plugin.DomainName
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
        If Name <> JHSoftware.SimpleDNS.Plugin.DomainName.Root Then .SetAttribute("name", Name.ToString)
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
        .Name = JHSoftware.SimpleDNS.Plugin.DomainName.Parse(elem.GetAttrStr("name", "."))
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
