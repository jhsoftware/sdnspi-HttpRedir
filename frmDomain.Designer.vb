<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDomain
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
    Me.btnOK = New System.Windows.Forms.Button
    Me.btnCancel = New System.Windows.Forms.Button
    Me.GroupBox1 = New System.Windows.Forms.GroupBox
    Me.Panel2 = New System.Windows.Forms.Panel
    Me.radExact = New System.Windows.Forms.RadioButton
    Me.radRelative = New System.Windows.Forms.RadioButton
    Me.Panel1 = New System.Windows.Forms.Panel
    Me.radCloak = New System.Windows.Forms.RadioButton
    Me.txtTitle = New System.Windows.Forms.TextBox
    Me.rad301 = New System.Windows.Forms.RadioButton
    Me.rad302 = New System.Windows.Forms.RadioButton
    Me.chkSubDom = New System.Windows.Forms.CheckBox
    Me.Label4 = New System.Windows.Forms.Label
    Me.txtURL = New System.Windows.Forms.TextBox
    Me.Label2 = New System.Windows.Forms.Label
    Me.Label1 = New System.Windows.Forms.Label
    Me.txtDom = New System.Windows.Forms.TextBox
    Me.GroupBox1.SuspendLayout()
    Me.Panel2.SuspendLayout()
    Me.Panel1.SuspendLayout()
    Me.SuspendLayout()
    '
    'btnOK
    '
    Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.btnOK.Location = New System.Drawing.Point(245, 294)
    Me.btnOK.Name = "btnOK"
    Me.btnOK.Size = New System.Drawing.Size(75, 23)
    Me.btnOK.TabIndex = 1
    Me.btnOK.Text = "OK"
    '
    'btnCancel
    '
    Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
    Me.btnCancel.Location = New System.Drawing.Point(326, 294)
    Me.btnCancel.Name = "btnCancel"
    Me.btnCancel.Size = New System.Drawing.Size(75, 23)
    Me.btnCancel.TabIndex = 2
    Me.btnCancel.Text = "Cancel"
    '
    'GroupBox1
    '
    Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.GroupBox1.Controls.Add(Me.Panel2)
    Me.GroupBox1.Controls.Add(Me.Panel1)
    Me.GroupBox1.Controls.Add(Me.chkSubDom)
    Me.GroupBox1.Controls.Add(Me.Label4)
    Me.GroupBox1.Controls.Add(Me.Label2)
    Me.GroupBox1.Controls.Add(Me.Label1)
    Me.GroupBox1.Controls.Add(Me.txtDom)
    Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
    Me.GroupBox1.Name = "GroupBox1"
    Me.GroupBox1.Padding = New System.Windows.Forms.Padding(15, 10, 15, 15)
    Me.GroupBox1.Size = New System.Drawing.Size(389, 276)
    Me.GroupBox1.TabIndex = 0
    Me.GroupBox1.TabStop = False
    Me.GroupBox1.Text = "Redirect"
    '
    'Panel2
    '
    Me.Panel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.Panel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
    Me.Panel2.Controls.Add(Me.radExact)
    Me.Panel2.Controls.Add(Me.radRelative)
    Me.Panel2.Controls.Add(Me.txtURL)
    Me.Panel2.Location = New System.Drawing.Point(86, 82)
    Me.Panel2.Margin = New System.Windows.Forms.Padding(3, 13, 3, 3)
    Me.Panel2.Name = "Panel2"
    Me.Panel2.Size = New System.Drawing.Size(285, 77)
    Me.Panel2.TabIndex = 4
    '
    'radExact
    '
    Me.radExact.AutoSize = True
    Me.radExact.CheckAlign = System.Drawing.ContentAlignment.TopLeft
    Me.radExact.Location = New System.Drawing.Point(0, 43)
    Me.radExact.Margin = New System.Windows.Forms.Padding(3, 0, 3, 3)
    Me.radExact.Name = "radExact"
    Me.radExact.Size = New System.Drawing.Size(263, 30)
    Me.radExact.TabIndex = 2
    Me.radExact.Text = "Exact URL - optional substitutions (URL encoded):" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "             #HOST#, #PATH#, #" & _
        "QUERY#"
    Me.radExact.UseVisualStyleBackColor = True
    '
    'radRelative
    '
    Me.radRelative.AutoSize = True
    Me.radRelative.Checked = True
    Me.radRelative.Location = New System.Drawing.Point(0, 23)
    Me.radRelative.Margin = New System.Windows.Forms.Padding(3, 0, 3, 3)
    Me.radRelative.Name = "radRelative"
    Me.radRelative.Size = New System.Drawing.Size(258, 17)
    Me.radRelative.TabIndex = 1
    Me.radRelative.TabStop = True
    Me.radRelative.Text = "Relative URL - append requested path and query"
    Me.radRelative.UseVisualStyleBackColor = True
    '
    'Panel1
    '
    Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.Panel1.Controls.Add(Me.radCloak)
    Me.Panel1.Controls.Add(Me.txtTitle)
    Me.Panel1.Controls.Add(Me.rad301)
    Me.Panel1.Controls.Add(Me.rad302)
    Me.Panel1.Location = New System.Drawing.Point(86, 175)
    Me.Panel1.Margin = New System.Windows.Forms.Padding(3, 13, 3, 3)
    Me.Panel1.Name = "Panel1"
    Me.Panel1.Size = New System.Drawing.Size(285, 85)
    Me.Panel1.TabIndex = 6
    '
    'radCloak
    '
    Me.radCloak.AutoSize = True
    Me.radCloak.Location = New System.Drawing.Point(0, 40)
    Me.radCloak.Margin = New System.Windows.Forms.Padding(3, 0, 3, 3)
    Me.radCloak.Name = "radCloak"
    Me.radCloak.Size = New System.Drawing.Size(269, 17)
    Me.radCloak.TabIndex = 2
    Me.radCloak.Text = "Cloaked - Hide redirect URL in frame page with title:"
    Me.radCloak.UseVisualStyleBackColor = True
    '
    'txtTitle
    '
    Me.txtTitle.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.txtTitle.Enabled = False
    Me.txtTitle.Location = New System.Drawing.Point(18, 58)
    Me.txtTitle.Margin = New System.Windows.Forms.Padding(3, 0, 3, 3)
    Me.txtTitle.Name = "txtTitle"
    Me.txtTitle.Size = New System.Drawing.Size(267, 20)
    Me.txtTitle.TabIndex = 3
    '
    'rad301
    '
    Me.rad301.AutoSize = True
    Me.rad301.Location = New System.Drawing.Point(0, 20)
    Me.rad301.Margin = New System.Windows.Forms.Padding(3, 0, 3, 3)
    Me.rad301.Name = "rad301"
    Me.rad301.Size = New System.Drawing.Size(173, 17)
    Me.rad301.TabIndex = 1
    Me.rad301.TabStop = True
    Me.rad301.Text = "Status 301 Moved Permanently"
    Me.rad301.UseVisualStyleBackColor = True
    '
    'rad302
    '
    Me.rad302.AutoSize = True
    Me.rad302.Checked = True
    Me.rad302.Location = New System.Drawing.Point(0, 0)
    Me.rad302.Name = "rad302"
    Me.rad302.Size = New System.Drawing.Size(203, 17)
    Me.rad302.TabIndex = 0
    Me.rad302.TabStop = True
    Me.rad302.Text = "Status 302 Found (moved temporarily)"
    Me.rad302.UseVisualStyleBackColor = True
    '
    'chkSubDom
    '
    Me.chkSubDom.AutoSize = True
    Me.chkSubDom.Location = New System.Drawing.Point(86, 49)
    Me.chkSubDom.Margin = New System.Windows.Forms.Padding(3, 0, 3, 3)
    Me.chkSubDom.Name = "chkSubDom"
    Me.chkSubDom.Size = New System.Drawing.Size(136, 17)
    Me.chkSubDom.TabIndex = 2
    Me.chkSubDom.Text = "Including all sub-names"
    Me.chkSubDom.UseVisualStyleBackColor = True
    '
    'Label4
    '
    Me.Label4.AutoSize = True
    Me.Label4.Location = New System.Drawing.Point(18, 177)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(46, 13)
    Me.Label4.TabIndex = 5
    Me.Label4.Text = "Method:"
    '
    'txtURL
    '
    Me.txtURL.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.txtURL.Location = New System.Drawing.Point(0, 0)
    Me.txtURL.Margin = New System.Windows.Forms.Padding(3, 13, 3, 3)
    Me.txtURL.Name = "txtURL"
    Me.txtURL.Size = New System.Drawing.Size(285, 20)
    Me.txtURL.TabIndex = 0
    Me.txtURL.Text = "http://"
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Location = New System.Drawing.Point(18, 85)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(62, 13)
    Me.Label2.TabIndex = 3
    Me.Label2.Text = "Redirect to:"
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(18, 29)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(61, 13)
    Me.Label1.TabIndex = 0
    Me.Label1.Text = "Host name:"
    '
    'txtDom
    '
    Me.txtDom.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.txtDom.Location = New System.Drawing.Point(86, 26)
    Me.txtDom.Margin = New System.Windows.Forms.Padding(3, 0, 3, 3)
    Me.txtDom.Name = "txtDom"
    Me.txtDom.Size = New System.Drawing.Size(285, 20)
    Me.txtDom.TabIndex = 1
    '
    'frmDomain
    '
    Me.AcceptButton = Me.btnOK
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.CancelButton = Me.btnCancel
    Me.ClientSize = New System.Drawing.Size(413, 329)
    Me.Controls.Add(Me.GroupBox1)
    Me.Controls.Add(Me.btnCancel)
    Me.Controls.Add(Me.btnOK)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "frmDomain"
    Me.ShowInTaskbar = False
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
    Me.Text = "Redirect"
    Me.GroupBox1.ResumeLayout(False)
    Me.GroupBox1.PerformLayout()
    Me.Panel2.ResumeLayout(False)
    Me.Panel2.PerformLayout()
    Me.Panel1.ResumeLayout(False)
    Me.Panel1.PerformLayout()
    Me.ResumeLayout(False)

  End Sub
  Friend WithEvents btnOK As System.Windows.Forms.Button
  Friend WithEvents btnCancel As System.Windows.Forms.Button
  Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
  Friend WithEvents radRelative As System.Windows.Forms.RadioButton
  Friend WithEvents radExact As System.Windows.Forms.RadioButton
  Friend WithEvents txtURL As System.Windows.Forms.TextBox
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents txtDom As System.Windows.Forms.TextBox
  Friend WithEvents txtTitle As System.Windows.Forms.TextBox
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents chkSubDom As System.Windows.Forms.CheckBox
  Friend WithEvents Panel1 As System.Windows.Forms.Panel
  Friend WithEvents radCloak As System.Windows.Forms.RadioButton
  Friend WithEvents rad301 As System.Windows.Forms.RadioButton
  Friend WithEvents rad302 As System.Windows.Forms.RadioButton
  Friend WithEvents Panel2 As System.Windows.Forms.Panel

End Class
