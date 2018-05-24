Imports System.Windows.Forms

Public Class frmConfigIP

  Public WithEvents IPCtrl As Control

  Friend Sub LoadConfig(sender As OptionsUI, cfg As MyConfig)
    REM setup form
    IPCtrl = sender.GetIPCtrl(True, False)
    pnlNAT.Controls.Add(IPCtrl)
    IPCtrl.Location = txtDummy.Location
    IPCtrl.TabIndex = txtDummy.TabIndex
    btnDetect.Left = IPCtrl.Right + 6

    REM load local ip addresses
    ddIPv4.Items.Clear()
    ddIPv4.Items.Add("None")
    ddIPv4.SelectedIndex = 0
    ddIPv6.Items.Clear()
    ddIPv6.Items.Add("None")
    ddIPv6.SelectedIndex = 0
    For Each ipsn In sender.GetServerIPs()
      If ipsn.IPAddr.IPVersion = 4 Then ddIPv4.Items.Add(ipsn.IPAddr) Else ddIPv6.Items.Add(ipsn.IPAddr)
    Next

    REM load configuration
    chkHTTP.Checked = cfg.ProtoHTTP
    chkHTTPS.Checked = cfg.ProtoHTTPS
    If cfg.BindIPv4 IsNot Nothing Then
      For i = 1 To ddIPv4.Items.Count - 1
        If cfg.BindIPv4 = DirectCast(ddIPv4.Items(i), Plugin.IPAddress) Then ddIPv4.SelectedIndex = i : Exit For
      Next
    End If
    If cfg.BindIPv6 IsNot Nothing Then
      For i = 1 To ddIPv6.Items.Count - 1
        If cfg.BindIPv6 = DirectCast(ddIPv6.Items(i), Plugin.IPAddress) Then ddIPv6.SelectedIndex = i : Exit For
      Next
    End If
    If cfg.NatIP IsNot Nothing Then
      chkNAT.Checked = True
      IPCtrl.Text = cfg.NatIP.ToString
      txtMap80.Text = cfg.NatMap80.ToString
      txtMap443.Text = cfg.NatMap443.ToString
    End If
  End Sub

  Friend Sub SaveConfig(cfg As MyConfig)
    cfg.ProtoHTTP = chkHTTP.Checked
    cfg.ProtoHTTPS = chkHTTPS.Checked

    cfg.BindIPv4 = If(ddIPv4.SelectedIndex > 0, DirectCast(ddIPv4.SelectedItem, Plugin.IPAddressV4), Nothing)
    cfg.BindIPv6 = If(ddIPv6.SelectedIndex > 0, DirectCast(ddIPv6.SelectedItem, Plugin.IPAddressV6), Nothing)

    If chkNAT.Checked Then
      cfg.NatIP = Plugin.IPAddressV4.Parse(IPCtrl.Text.Trim)
      Integer.TryParse(txtMap80.Text.Trim, cfg.NatMap80)
      Integer.TryParse(txtMap443.Text.Trim, cfg.NatMap443)
    Else
      cfg.NatIP = Nothing
    End If
  End Sub

  Private Sub btnDetect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDetect.Click
    Me.Cursor = Cursors.WaitCursor
    Application.DoEvents()
    Dim wc As New System.Net.WebClient
    Dim ip As Plugin.IPAddressV4
    Try
      ip = Plugin.IPAddressV4.Parse(wc.DownloadString("http://ipecho.net/plain"))
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
    REM protocols
    If Not chkHTTP.Checked AndAlso Not chkHTTPS.Checked Then MessageBox.Show("No protocol seleted", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Sub

    REM listen on IPs
    If ddIPv4.SelectedIndex = 0 AndAlso ddIPv6.SelectedIndex = 0 Then MessageBox.Show("No Listen on local IP address seleted", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Sub

    REM connection
    If chkNAT.Checked Then
      If ddIPv4.SelectedIndex = 0 Then MessageBox.Show("When behind a NAT router, a local IPv4 address must be selected", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Sub
      If IPCtrl.Text.Trim.Length = 0 Then MessageBox.Show("Public IP address of NAT router cannot be blank", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Sub
      Dim ip As Plugin.IPAddress = Nothing
      If Not JHSoftware.SimpleDNS.Plugin.IPAddressV4.TryParse(IPCtrl.Text.Trim, ip) OrElse
         ip.IPVersion <> 4 Then MessageBox.Show("Invalid public IP address of NAT router", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Sub
      Dim port1, port2 As Integer
      If chkHTTP.Checked Then
        If Not Integer.TryParse(txtMap80.Text.Trim, port1) OrElse
         (port1 < 1 Or port1 > 65535) Then MessageBox.Show("Invalid NAT port 80 map port number", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Sub
      End If
      If chkHTTPS.Checked Then
        If Not Integer.TryParse(txtMap443.Text.Trim, port2) OrElse
         (port2 < 1 Or port2 > 65535) Then MessageBox.Show("Invalid NAT port 443 map port number", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Sub
      End If
      If chkHTTP.Checked AndAlso chkHTTPS.Checked AndAlso port1 = port2 Then MessageBox.Show("NAT mapped ports cannot be the same", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Sub
    End If

    DialogResult = Windows.Forms.DialogResult.OK
    Me.Close()
    End Sub

  Private Sub chkHTTP_CheckedChanged(sender As Object, e As EventArgs) Handles chkHTTP.CheckedChanged, chkHTTPS.CheckedChanged
    lblMap80.Enabled = chkHTTP.Checked
    txtMap80.Enabled = chkHTTP.Checked
    lblMap443.Enabled = chkHTTPS.Checked
    txtMap443.Enabled = chkHTTPS.Checked
  End Sub

  Private Sub chkNAT_CheckedChanged(sender As Object, e As EventArgs) Handles chkNAT.CheckedChanged
    pnlNAT.Enabled = (chkNAT.Checked)
  End Sub

  Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click

  End Sub
End Class
