Public Class OptionsUI

  Private Cfg As New MyConfig

  Private Sub btnConfigIP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConfigIP.Click
    Dim frm = New frmConfigIP
    frm.LoadConfig(Me, Cfg)
    If frm.ShowDialog() <> DialogResult.OK Then Exit Sub
    frm.SaveConfig(Cfg)
    SayIPPort()
  End Sub

  Private Sub SayIPPort()
    lstListen.Items.Clear()
    For Each bnd In Cfg.GetBindings
      lstListen.Items.Add(bnd)
    Next
  End Sub

  Private Sub btnConfigDef_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConfigDef.Click
    Dim frm = New frmDomain
    frm.txtDom.Text = "<DEFAULT>"
    frm.txtDom.Enabled = False
    frm.chkSubDom.Enabled = False
    If Cfg.DefaultRedir IsNot Nothing Then frm.LoadData(Cfg.DefaultRedir)
    If frm.ShowDialog() <> DialogResult.OK Then Exit Sub
    Cfg.DefaultRedir = frm.SaveData
    lblDefault.Text = Cfg.DefaultRedir.ToURL
  End Sub

  Private Sub lstDoms_EditItem(ByVal curItem As Object) Handles lstDoms.EditItem
    Dim frm = New frmDomain
    frm.lst = lstDoms
    If curItem IsNot Nothing Then frm.LoadData(DirectCast(curItem, MyConfig.HNRedir))
    frm.ShowDialog()
  End Sub

  Public Overrides Function ValidateData() As Boolean
    If Cfg.BindIPv4 Is Nothing AndAlso Cfg.BindIPv6 Is Nothing Then
      MessageBox.Show("Protocols / IP addresses / Ports is not configured", "HTTP Redirector", MessageBoxButtons.OK, MessageBoxIcon.Error)
      Return False
    End If
    If Cfg.DefaultRedir Is Nothing Then
      MessageBox.Show("Default redirect URL not configured", "HTTP Redirector", MessageBoxButtons.OK, MessageBoxIcon.Error)
      Return False
    End If
    If Not RemoteGUI Then
      If Not System.Net.HttpListener.IsSupported Then
        MessageBox.Show("This plug-in does not run on this Windows version." & vbCrLf &
                        "Windows XP SP2 / Server 2003 or later is required.", "HTTP Redirector", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Return False
      End If
    End If
    Return True
  End Function

  Public Overrides Function SaveData() As String
    Cfg.Redirs.Clear()
    Dim dom As MyConfig.HNRedir
    For i = 0 To lstDoms.Count - 1
      dom = DirectCast(lstDoms.Item(i), MyConfig.HNRedir)
      Cfg.Redirs.Add(dom.Name, dom)
    Next
    Return Cfg.SaveToXML.OuterXml
  End Function

  Public Overrides Sub LoadData(ByVal config As String)
    If config Is Nothing Then Exit Sub 'new instance
    Cfg = MyConfig.LoadFromXML(config)
    SayIPPort()
    lblDefault.Text = Cfg.DefaultRedir.ToURL
    For Each rd In Cfg.Redirs.Values
      lstDoms.Add(rd)
    Next
  End Sub
End Class
