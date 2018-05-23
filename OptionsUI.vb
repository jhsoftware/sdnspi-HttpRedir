Public Class OptionsUI

  Private Cfg As New MyConfig

  Private Sub btnConfigIP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConfigIP.Click
    Dim frm = New frmConfigIP
    frm.IPCtrl = GetIPCtrl(True, False)
    frm.ServerIPs = GetServerIPs.Invoke
    frm.LoadDefaults()
    If Cfg.BindIP IsNot Nothing Then
      If Cfg.BindNat Then
        frm.radNAT.Checked = True
        frm.IPCtrl.Text = Cfg.PublicIP.ToString
        For i = 0 To frm.ddNat.Items.Count - 1
          If DirectCast(frm.ddNat.Items(i), JHSoftware.SimpleDNS.Plugin.IPAddressV4).Equals(Cfg.BindIP) Then frm.ddNat.SelectedIndex = i : Exit For
        Next
        frm.txtPort.Text = Cfg.BindPort.ToString
      Else
        frm.radDirect.Checked = True
        For i = 0 To frm.ddDirect.Items.Count - 1
          If DirectCast(frm.ddDirect.Items(i), JHSoftware.SimpleDNS.Plugin.IPAddressV4).Equals(Cfg.BindIP) Then frm.ddDirect.SelectedIndex = i : Exit For
        Next
        frm.txtPort.Text = "80"
      End If
    End If
    If frm.ShowDialog() <> DialogResult.OK Then Exit Sub

    Cfg.BindNat = frm.radNAT.Checked
    If Cfg.BindNat Then
      Cfg.PublicIP = JHSoftware.SimpleDNS.Plugin.IPAddressV4.Parse(frm.IPCtrl.Text.Trim)
      Cfg.BindIP = DirectCast(frm.ddNat.SelectedItem, JHSoftware.SimpleDNS.Plugin.IPAddressV4)
      Cfg.BindPort = Integer.Parse(frm.txtPort.Text.Trim)
    Else
      Cfg.BindIP = DirectCast(frm.ddDirect.SelectedItem, JHSoftware.SimpleDNS.Plugin.IPAddressV4)
      Cfg.PublicIP = Cfg.BindIP
      Cfg.BindPort = 80
    End If

    SayIPPort()
  End Sub

  Private Sub SayIPPort()
    If Cfg.BindNat Then
      lblIPPort.Text = Cfg.PublicIP.ToString & ":80 >> " & Cfg.BindIP.ToString & ":" & Cfg.BindPort
    Else
      lblIPPort.Text = Cfg.BindIP.ToString & ":" & Cfg.BindPort
    End If
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
    If Cfg.BindIP Is Nothing Then
      MessageBox.Show("IP address / port not configured", "HTTP Redirector", MessageBoxButtons.OK, MessageBoxIcon.Error)
      Return False
    End If
    If Cfg.DefaultRedir Is Nothing Then
      MessageBox.Show("Default redirect URL not configured", "HTTP Redirector", MessageBoxButtons.OK, MessageBoxIcon.Error)
      Return False
    End If
    If Not RemoteGUI Then
      If Not System.Net.HttpListener.IsSupported Then
        MessageBox.Show("This plug-in does not run on this Windows version." & vbCrLf & _
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
