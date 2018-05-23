Namespace System.Runtime.CompilerServices
  'TODO: remove this when upgrading to .NET 3.5
  Friend NotInheritable Class ExtensionAttribute
    Inherits System.Attribute
  End Class
End Namespace

Module JHXML
  <System.Runtime.CompilerServices.Extension()> _
  Function GetAttrBool(ByVal elem As Xml.XmlElement, ByVal name As String, Optional ByVal defVal As Boolean = False) As Boolean
    If Not elem.HasAttribute(name) Then Return defVal
    Return (elem.GetAttribute(name).ToLowerInvariant.Trim = "true")
  End Function

  <System.Runtime.CompilerServices.Extension()>
  Sub SetAttrBool(ByVal elem As Xml.XmlElement, ByVal name As String, ByVal value As Boolean)
    elem.SetAttribute(name, If(value, "true", "false"))
  End Sub

  <System.Runtime.CompilerServices.Extension()> _
  Function GetAttrInt(ByVal elem As Xml.XmlElement, ByVal name As String, Optional ByVal defVal As Integer = 0) As Integer
    If Not elem.HasAttribute(name) Then Return defVal
    Dim rv As Integer
    If Not Integer.TryParse(elem.GetAttribute(name), rv) Then Return defVal
    Return rv
  End Function

  <System.Runtime.CompilerServices.Extension()>
  Sub SetAttrInt(ByVal elem As Xml.XmlElement, ByVal name As String, ByVal value As Integer)
    elem.SetAttribute(name, value.ToString)
  End Sub

  <System.Runtime.CompilerServices.Extension()> _
  Function GetAttrStr(ByVal elem As Xml.XmlElement, ByVal name As String, Optional ByVal defVal As String = "") As String
    If Not elem.HasAttribute(name) Then Return defVal
    Return elem.GetAttribute(name)
  End Function

  <System.Runtime.CompilerServices.Extension()>
  Function CreateChildElement(ByVal elem As Xml.XmlElement, ByVal name As String) As Xml.XmlElement
    Dim rv = elem.OwnerDocument.CreateElement(name)
    elem.AppendChild(rv)
    Return rv
  End Function

  <System.Runtime.CompilerServices.Extension()>
  Friend Function PrepRoot(ByVal doc As Xml.XmlDocument, ByVal rootName As String) As Xml.XmlElement
    doc.AppendChild(doc.CreateXmlDeclaration("1.0", Nothing, Nothing))
    Dim rv As Xml.XmlElement = doc.CreateElement(rootName)
    doc.AppendChild(rv)
    Return rv
  End Function

End Module

