<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConfigIP
  Inherits System.Windows.Forms.Form

  'Form overrides dispose to clean up the component list.
  <System.Diagnostics.DebuggerNonUserCode()> _
  Protected Overrides Sub Dispose(ByVal disposing As Boolean)
    Try
      If disposing AndAlso components IsNot Nothing Then
        components.Dispose()
      End If
    Finally
      MyBase.Dispose(disposing)
    End Try
  End Sub

  'Required by the Windows Form Designer
  Private components As System.ComponentModel.IContainer

  'NOTE: The following procedure is required by the Windows Form Designer
  'It can be modified using the Windows Form Designer.  
  'Do not modify it using the code editor.
  <System.Diagnostics.DebuggerStepThrough()> _
  Private Sub InitializeComponent()
    Me.txtMap80 = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.chkNAT = New System.Windows.Forms.CheckBox()
        Me.pnlNAT = New System.Windows.Forms.Panel()
        Me.IPCtrl = New JHSoftware.SimpleDNS.ctlIP()
        Me.lblMap443 = New System.Windows.Forms.Label()
        Me.txtMap443 = New System.Windows.Forms.TextBox()
        Me.lblMap80 = New System.Windows.Forms.Label()
        Me.btnDetect = New System.Windows.Forms.Button()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.chkHTTPS = New System.Windows.Forms.CheckBox()
        Me.chkHTTP = New System.Windows.Forms.CheckBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.ddIPv6 = New System.Windows.Forms.ComboBox()
        Me.ddIPv4 = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.pnlNAT.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtMap80
        '
        Me.txtMap80.Location = New System.Drawing.Point(231, 74)
        Me.txtMap80.Margin = New System.Windows.Forms.Padding(0, 3, 3, 3)
        Me.txtMap80.MaxLength = 5
        Me.txtMap80.Name = "txtMap80"
        Me.txtMap80.Size = New System.Drawing.Size(43, 20)
        Me.txtMap80.TabIndex = 16
        Me.txtMap80.Text = "80"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(-3, 53)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(345, 13)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "NAT router port mappings to this computer's local IPv4 address (above):"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(-3, 3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(159, 13)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Public IP address of NAT router:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.chkNAT)
        Me.GroupBox1.Controls.Add(Me.pnlNAT)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 195)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(15, 10, 15, 10)
        Me.GroupBox1.Size = New System.Drawing.Size(398, 179)
        Me.GroupBox1.TabIndex = 8
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "NAT Router"
        '
        'chkNAT
        '
        Me.chkNAT.AutoSize = True
        Me.chkNAT.Location = New System.Drawing.Point(18, 26)
        Me.chkNAT.Name = "chkNAT"
        Me.chkNAT.Size = New System.Drawing.Size(255, 17)
        Me.chkNAT.TabIndex = 9
        Me.chkNAT.Text = "This computer is behind a NAT router (IPv4 only)"
        Me.chkNAT.UseVisualStyleBackColor = True
        '
        'pnlNAT
        '
        Me.pnlNAT.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlNAT.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.pnlNAT.Controls.Add(Me.IPCtrl)
        Me.pnlNAT.Controls.Add(Me.lblMap443)
        Me.pnlNAT.Controls.Add(Me.txtMap443)
        Me.pnlNAT.Controls.Add(Me.lblMap80)
        Me.pnlNAT.Controls.Add(Me.btnDetect)
        Me.pnlNAT.Controls.Add(Me.Label1)
        Me.pnlNAT.Controls.Add(Me.txtMap80)
        Me.pnlNAT.Controls.Add(Me.Label2)
        Me.pnlNAT.Enabled = False
        Me.pnlNAT.Location = New System.Drawing.Point(37, 49)
        Me.pnlNAT.Name = "pnlNAT"
        Me.pnlNAT.Size = New System.Drawing.Size(344, 124)
        Me.pnlNAT.TabIndex = 10
        '
        'IPCtrl
        '
        Me.IPCtrl.AutoSize = True
        Me.IPCtrl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.IPCtrl.IPVersion = JHSoftware.SimpleDNS.IPVersionEnum.IPv4
        Me.IPCtrl.Location = New System.Drawing.Point(-1, 19)
        Me.IPCtrl.Name = "IPCtrl"
        Me.IPCtrl.Size = New System.Drawing.Size(174, 22)
        Me.IPCtrl.TabIndex = 0
        Me.IPCtrl.Value = Nothing
        '
        'lblMap443
        '
        Me.lblMap443.AutoSize = True
        Me.lblMap443.Enabled = False
        Me.lblMap443.Location = New System.Drawing.Point(-3, 103)
        Me.lblMap443.Name = "lblMap443"
        Me.lblMap443.Size = New System.Drawing.Size(245, 13)
        Me.lblMap443.TabIndex = 17
        Me.lblMap443.Text = "Public port 443 (HTTPS) is mapped to private port:"
        '
        'txtMap443
        '
        Me.txtMap443.Enabled = False
        Me.txtMap443.Location = New System.Drawing.Point(245, 99)
        Me.txtMap443.Margin = New System.Windows.Forms.Padding(0, 3, 3, 3)
        Me.txtMap443.MaxLength = 5
        Me.txtMap443.Name = "txtMap443"
        Me.txtMap443.Size = New System.Drawing.Size(43, 20)
        Me.txtMap443.TabIndex = 18
        Me.txtMap443.Text = "443"
        '
        'lblMap80
        '
        Me.lblMap80.AutoSize = True
        Me.lblMap80.Location = New System.Drawing.Point(-4, 77)
        Me.lblMap80.Name = "lblMap80"
        Me.lblMap80.Size = New System.Drawing.Size(232, 13)
        Me.lblMap80.TabIndex = 15
        Me.lblMap80.Text = "Public port 80 (HTTP) is mapped to private port:"
        '
        'btnDetect
        '
        Me.btnDetect.Location = New System.Drawing.Point(179, 19)
        Me.btnDetect.Name = "btnDetect"
        Me.btnDetect.Size = New System.Drawing.Size(55, 21)
        Me.btnDetect.TabIndex = 13
        Me.btnDetect.Text = "Detect"
        Me.btnDetect.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOK.Location = New System.Drawing.Point(254, 380)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 19
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(335, 380)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 20
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.chkHTTPS)
        Me.GroupBox2.Controls.Add(Me.chkHTTP)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(398, 78)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Protocols"
        '
        'chkHTTPS
        '
        Me.chkHTTPS.AutoSize = True
        Me.chkHTTPS.Location = New System.Drawing.Point(18, 51)
        Me.chkHTTPS.Name = "chkHTTPS"
        Me.chkHTTPS.Size = New System.Drawing.Size(324, 17)
        Me.chkHTTPS.TabIndex = 2
        Me.chkHTTPS.Text = "HTTPS (port 443) - Requires manual binding of SSL certificates"
        Me.chkHTTPS.UseVisualStyleBackColor = True
        '
        'chkHTTP
        '
        Me.chkHTTP.AutoSize = True
        Me.chkHTTP.Checked = True
        Me.chkHTTP.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkHTTP.Location = New System.Drawing.Point(18, 28)
        Me.chkHTTP.Name = "chkHTTP"
        Me.chkHTTP.Size = New System.Drawing.Size(97, 17)
        Me.chkHTTP.TabIndex = 1
        Me.chkHTTP.Text = "HTTP (port 80)"
        Me.chkHTTP.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.ddIPv6)
        Me.GroupBox3.Controls.Add(Me.ddIPv4)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Location = New System.Drawing.Point(12, 96)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(398, 93)
        Me.GroupBox3.TabIndex = 3
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Listen on local IP addresses"
        '
        'ddIPv6
        '
        Me.ddIPv6.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ddIPv6.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ddIPv6.FormattingEnabled = True
        Me.ddIPv6.Location = New System.Drawing.Point(53, 55)
        Me.ddIPv6.Name = "ddIPv6"
        Me.ddIPv6.Size = New System.Drawing.Size(328, 21)
        Me.ddIPv6.TabIndex = 7
        '
        'ddIPv4
        '
        Me.ddIPv4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ddIPv4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ddIPv4.FormattingEnabled = True
        Me.ddIPv4.Location = New System.Drawing.Point(53, 25)
        Me.ddIPv4.Name = "ddIPv4"
        Me.ddIPv4.Size = New System.Drawing.Size(328, 21)
        Me.ddIPv4.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(15, 58)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(32, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "IPv6:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(15, 29)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(32, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "IPv4:"
        '
        'frmConfigIP
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(422, 415)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmConfigIP"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Protocols / IP addresses / NAT"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.pnlNAT.ResumeLayout(False)
        Me.pnlNAT.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txtMap80 As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents pnlNAT As System.Windows.Forms.Panel
    Friend WithEvents btnDetect As System.Windows.Forms.Button
    Friend WithEvents lblMap443 As Label
    Friend WithEvents txtMap443 As TextBox
    Friend WithEvents lblMap80 As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents chkHTTPS As CheckBox
    Friend WithEvents chkHTTP As CheckBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents chkNAT As CheckBox
    Friend WithEvents ddIPv6 As ComboBox
    Friend WithEvents ddIPv4 As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents IPCtrl As ctlIP
End Class
