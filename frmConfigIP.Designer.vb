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
    Me.ddDirect = New System.Windows.Forms.ComboBox
    Me.Label4 = New System.Windows.Forms.Label
    Me.txtPort = New System.Windows.Forms.TextBox
    Me.txtDummy = New System.Windows.Forms.TextBox
    Me.ddNat = New System.Windows.Forms.ComboBox
    Me.Label3 = New System.Windows.Forms.Label
    Me.Label2 = New System.Windows.Forms.Label
    Me.Label1 = New System.Windows.Forms.Label
    Me.radDirect = New System.Windows.Forms.RadioButton
    Me.radNAT = New System.Windows.Forms.RadioButton
    Me.GroupBox1 = New System.Windows.Forms.GroupBox
    Me.pnlDirect = New System.Windows.Forms.Panel
    Me.pnlNAT = New System.Windows.Forms.Panel
    Me.btnDetect = New System.Windows.Forms.Button
    Me.btnOK = New System.Windows.Forms.Button
    Me.btnCancel = New System.Windows.Forms.Button
    Me.GroupBox1.SuspendLayout()
    Me.pnlDirect.SuspendLayout()
    Me.pnlNAT.SuspendLayout()
    Me.SuspendLayout()
    '
    'ddDirect
    '
    Me.ddDirect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.ddDirect.FormattingEnabled = True
    Me.ddDirect.Location = New System.Drawing.Point(0, 19)
    Me.ddDirect.Name = "ddDirect"
    Me.ddDirect.Size = New System.Drawing.Size(120, 21)
    Me.ddDirect.TabIndex = 1
    '
    'Label4
    '
    Me.Label4.AutoSize = True
    Me.Label4.Location = New System.Drawing.Point(-3, 3)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(232, 13)
    Me.Label4.TabIndex = 0
    Me.Label4.Text = "Perform rediction on port 80 TCP on IP address:"
    '
    'txtPort
    '
    Me.txtPort.Location = New System.Drawing.Point(161, 69)
    Me.txtPort.MaxLength = 5
    Me.txtPort.Name = "txtPort"
    Me.txtPort.Size = New System.Drawing.Size(43, 20)
    Me.txtPort.TabIndex = 5
    Me.txtPort.Text = "80"
    '
    'txtDummy
    '
    Me.txtDummy.Location = New System.Drawing.Point(0, 19)
    Me.txtDummy.Name = "txtDummy"
    Me.txtDummy.Size = New System.Drawing.Size(44, 20)
    Me.txtDummy.TabIndex = 1
    Me.txtDummy.Visible = False
    '
    'ddNat
    '
    Me.ddNat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.ddNat.FormattingEnabled = True
    Me.ddNat.Location = New System.Drawing.Point(0, 69)
    Me.ddNat.Name = "ddNat"
    Me.ddNat.Size = New System.Drawing.Size(120, 21)
    Me.ddNat.TabIndex = 3
    '
    'Label3
    '
    Me.Label3.AutoSize = True
    Me.Label3.Location = New System.Drawing.Point(127, 72)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(28, 13)
    Me.Label3.TabIndex = 4
    Me.Label3.Text = "port:"
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Location = New System.Drawing.Point(-3, 53)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(240, 13)
    Me.Label2.TabIndex = 2
    Me.Label2.Text = "NAT router maps port 80 TCP to local IP address:"
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(-3, 3)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(159, 13)
    Me.Label1.TabIndex = 0
    Me.Label1.Text = "Public IP address of NAT router:"
    '
    'radDirect
    '
    Me.radDirect.AutoSize = True
    Me.radDirect.Checked = True
    Me.radDirect.Location = New System.Drawing.Point(18, 26)
    Me.radDirect.Name = "radDirect"
    Me.radDirect.Size = New System.Drawing.Size(148, 17)
    Me.radDirect.TabIndex = 0
    Me.radDirect.TabStop = True
    Me.radDirect.Text = "Direct Internet connection"
    Me.radDirect.UseVisualStyleBackColor = True
    '
    'radNAT
    '
    Me.radNAT.AutoSize = True
    Me.radNAT.Location = New System.Drawing.Point(18, 111)
    Me.radNAT.Name = "radNAT"
    Me.radNAT.Size = New System.Drawing.Size(122, 17)
    Me.radNAT.TabIndex = 2
    Me.radNAT.Text = "Behind a NAT router"
    Me.radNAT.UseVisualStyleBackColor = True
    '
    'GroupBox1
    '
    Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.GroupBox1.Controls.Add(Me.pnlDirect)
    Me.GroupBox1.Controls.Add(Me.pnlNAT)
    Me.GroupBox1.Controls.Add(Me.radDirect)
    Me.GroupBox1.Controls.Add(Me.radNAT)
    Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
    Me.GroupBox1.Name = "GroupBox1"
    Me.GroupBox1.Padding = New System.Windows.Forms.Padding(15, 10, 15, 10)
    Me.GroupBox1.Size = New System.Drawing.Size(292, 250)
    Me.GroupBox1.TabIndex = 0
    Me.GroupBox1.TabStop = False
    Me.GroupBox1.Text = "How is this computer connected to the Internet?"
    '
    'pnlDirect
    '
    Me.pnlDirect.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
    Me.pnlDirect.Controls.Add(Me.Label4)
    Me.pnlDirect.Controls.Add(Me.ddDirect)
    Me.pnlDirect.Location = New System.Drawing.Point(39, 49)
    Me.pnlDirect.Name = "pnlDirect"
    Me.pnlDirect.Size = New System.Drawing.Size(237, 45)
    Me.pnlDirect.TabIndex = 1
    '
    'pnlNAT
    '
    Me.pnlNAT.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
    Me.pnlNAT.Controls.Add(Me.btnDetect)
    Me.pnlNAT.Controls.Add(Me.Label1)
    Me.pnlNAT.Controls.Add(Me.txtDummy)
    Me.pnlNAT.Controls.Add(Me.txtPort)
    Me.pnlNAT.Controls.Add(Me.ddNat)
    Me.pnlNAT.Controls.Add(Me.Label2)
    Me.pnlNAT.Controls.Add(Me.Label3)
    Me.pnlNAT.Enabled = False
    Me.pnlNAT.Location = New System.Drawing.Point(39, 134)
    Me.pnlNAT.Name = "pnlNAT"
    Me.pnlNAT.Size = New System.Drawing.Size(245, 97)
    Me.pnlNAT.TabIndex = 3
    '
    'btnDetect
    '
    Me.btnDetect.Location = New System.Drawing.Point(50, 19)
    Me.btnDetect.Name = "btnDetect"
    Me.btnDetect.Size = New System.Drawing.Size(55, 21)
    Me.btnDetect.TabIndex = 6
    Me.btnDetect.Text = "Detect"
    Me.btnDetect.UseVisualStyleBackColor = True
    '
    'btnOK
    '
    Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.btnOK.Location = New System.Drawing.Point(148, 268)
    Me.btnOK.Name = "btnOK"
    Me.btnOK.Size = New System.Drawing.Size(75, 23)
    Me.btnOK.TabIndex = 1
    Me.btnOK.Text = "OK"
    Me.btnOK.UseVisualStyleBackColor = True
    '
    'btnCancel
    '
    Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
    Me.btnCancel.Location = New System.Drawing.Point(229, 268)
    Me.btnCancel.Name = "btnCancel"
    Me.btnCancel.Size = New System.Drawing.Size(75, 23)
    Me.btnCancel.TabIndex = 2
    Me.btnCancel.Text = "Cancel"
    Me.btnCancel.UseVisualStyleBackColor = True
    '
    'frmConfigIP
    '
    Me.AcceptButton = Me.btnOK
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.CancelButton = Me.btnCancel
    Me.ClientSize = New System.Drawing.Size(316, 303)
    Me.Controls.Add(Me.btnCancel)
    Me.Controls.Add(Me.btnOK)
    Me.Controls.Add(Me.GroupBox1)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "frmConfigIP"
    Me.ShowInTaskbar = False
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
    Me.Text = "IP address / port"
    Me.GroupBox1.ResumeLayout(False)
    Me.GroupBox1.PerformLayout()
    Me.pnlDirect.ResumeLayout(False)
    Me.pnlDirect.PerformLayout()
    Me.pnlNAT.ResumeLayout(False)
    Me.pnlNAT.PerformLayout()
    Me.ResumeLayout(False)

  End Sub
  Friend WithEvents ddDirect As System.Windows.Forms.ComboBox
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents txtPort As System.Windows.Forms.TextBox
  Friend WithEvents txtDummy As System.Windows.Forms.TextBox
  Friend WithEvents ddNat As System.Windows.Forms.ComboBox
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents radDirect As System.Windows.Forms.RadioButton
  Friend WithEvents radNAT As System.Windows.Forms.RadioButton
  Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
  Friend WithEvents btnOK As System.Windows.Forms.Button
  Friend WithEvents btnCancel As System.Windows.Forms.Button
  Friend WithEvents pnlNAT As System.Windows.Forms.Panel
  Friend WithEvents pnlDirect As System.Windows.Forms.Panel
  Friend WithEvents btnDetect As System.Windows.Forms.Button

End Class
