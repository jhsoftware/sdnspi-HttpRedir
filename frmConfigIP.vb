Imports System.Windows.Forms

Public Class frmConfigIP

  Public WithEvents IPCtrl As Control
  Friend ServerIPs As List(Of JHSoftware.SimpleDNS.Plugin.OptionsUI.IPandSubnet)

  Friend Sub LoadDefaults()
    Dim AllPrivate As Boolean = True
    For Each ipsn In ServerIPs
      REM only IPv4
      If ipsn.IPAddr.IPVersion <> 4 Then Continue For
      REM no loopback - won't happen
      '      If ipsn.IPAddr = JHSoftware.SimpleDNS.Plugin.IPAddressV4.Loopback Then Continue For
      ddDirect.Items.Add(ipsn.IPAddr)
      ddNat.Items.Add(ipsn.IPAddr)
      If IPisPrivate(DirectCast(ipsn.IPAddr, JHSoftware.SimpleDNS.Plugin.IPAddressV4)) Then
        If ddNat.SelectedIndex < 0 Then ddNat.SelectedIndex = ddNat.Items.Count - 1
      Else
        AllPrivate = False
        If ddDirect.SelectedIndex < 0 Then ddDirect.SelectedIndex = ddDirect.Items.Count - 1
      End If
    Next
    If ddDirect.Items.Count > 0 AndAlso ddDirect.SelectedIndex < 0 Then ddDirect.SelectedIndex = 0
    If ddNat.Items.Count > 0 AndAlso ddNat.SelectedIndex < 0 Then ddNat.SelectedIndex = 0
    If AllPrivate Then radNAT.Checked = True
  End Sub

  Private Sub frmConfigIP_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    pnlNAT.Controls.Add(IPCtrl)
    IPCtrl.Location = txtDummy.Location
    IPCtrl.TabIndex = txtDummy.TabIndex
    btnDetect.Left = IPCtrl.Right + 6
  End Sub

  Private Sub radDirect_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radDirect.CheckedChanged, radNAT.CheckedChanged
    pnlDirect.Enabled = (radDirect.Checked)
    pnlNAT.Enabled = (radNAT.Checked)
  End Sub

  Private Function IPisPrivate(ByVal ip As JHSoftware.SimpleDNS.Plugin.IPAddressV4) As Boolean
    Dim ba = ip.GetBytes
    If ba(0) = 10 Then Return True
    If ba(0) = 172 And ba(1) >= 16 And ba(1) <= 31 Then Return True
    If ba(0) = 192 And ba(1) = 168 Then Return True
    If ba(0) = 169 And ba(1) = 254 Then Return True
    Return False
  End Function

  Private Sub btnDetect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDetect.Click
    Me.Cursor = Cursors.WaitCursor
    Application.DoEvents()
    Dim wc As New System.Net.WebClient
    Dim ip As JHSoftware.SimpleDNS.Plugin.IPAddressV4
    Try
      ip = JHSoftware.SimpleDNS.Plugin.IPAddressV4.Parse(wc.DownloadString("http://www.whatismyip.com/automation/n09230945.asp"))
      If ip.IPVersion <> 4 Then Throw New Exception
    Catch
      Me.Cursor = Cursors.Default
      MessageBox.Show("Could not determine public IP address", "Public IP address", MessageBoxButtons.OK, MessageBoxIcon.Warning)
      Exit Sub
    End Try
    IPCtrl.Text = ip.ToString
    Me.Cursor = Cursors.Default
  End Sub

  Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
    Dim ip As JHSoftware.SimpleDNS.Plugin.IPAddressV4 = Nothing
    Dim port As Integer
    If radDirect.Checked Then
      If ddDirect.SelectedIndex < 0 Then MessageBox.Show("No IP address is seleted", "IP / Port", MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Sub
    Else
      If IPCtrl.Text.Trim.Length = 0 Then MessageBox.Show("Public IP address cannot be blank", "IP / Port", MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Sub
      If Not JHSoftware.SimpleDNS.Plugin.IPAddressV4.TryParse(IPCtrl.Text.Trim, ip) OrElse _
         ip.IPVersion <> 4 Then MessageBox.Show("Invalid public IP address", "IP / Port", MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Sub
      If ddNat.SelectedIndex < 0 Then MessageBox.Show("No local IP address is seleted", "IP / Port", MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Sub
      If Not Integer.TryParse(txtPort.Text.Trim, port) OrElse _
         (port < 1 Or port > 65535) Then MessageBox.Show("Invalid local port number", "IP / Port", MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Sub
    End If
    DialogResult = Windows.Forms.DialogResult.OK
    Me.Close()
  End Sub

End Class
