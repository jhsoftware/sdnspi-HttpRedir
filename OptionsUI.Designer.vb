<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OptionsUI
  Inherits JHSoftware.SimpleDNS.Plugin.OptionsUI

    'UserControl overrides dispose to clean up the component list.
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
    Me.Label6 = New System.Windows.Forms.Label()
    Me.btnConfigIP = New System.Windows.Forms.Button()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.lblDefault = New System.Windows.Forms.Label()
    Me.btnConfigDef = New System.Windows.Forms.Button()
    Me.lstListen = New System.Windows.Forms.ListBox()
    Me.lstDoms = New AERListBoxMC()
    Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
    Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
    Me.SuspendLayout()
    '
    'Label6
    '
    Me.Label6.AutoSize = True
    Me.Label6.Location = New System.Drawing.Point(-3, 132)
    Me.Label6.Margin = New System.Windows.Forms.Padding(3, 13, 3, 0)
    Me.Label6.Name = "Label6"
    Me.Label6.Size = New System.Drawing.Size(107, 13)
    Me.Label6.TabIndex = 6
    Me.Label6.Text = "Redirect host names:"
    '
    'btnConfigIP
    '
    Me.btnConfigIP.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.btnConfigIP.Location = New System.Drawing.Point(328, 15)
    Me.btnConfigIP.Margin = New System.Windows.Forms.Padding(3, 0, 3, 0)
    Me.btnConfigIP.Name = "btnConfigIP"
    Me.btnConfigIP.Size = New System.Drawing.Size(65, 21)
    Me.btnConfigIP.TabIndex = 2
    Me.btnConfigIP.Text = "Set..."
    Me.btnConfigIP.UseVisualStyleBackColor = True
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Location = New System.Drawing.Point(-3, 0)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(158, 13)
    Me.Label2.TabIndex = 0
    Me.Label2.Text = "Protocols / IP addresses / Ports"
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(-3, 85)
    Me.Label1.Margin = New System.Windows.Forms.Padding(3, 13, 3, 0)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(82, 13)
    Me.Label1.TabIndex = 3
    Me.Label1.Text = "Default redirect:"
    '
    'lblDefault
    '
    Me.lblDefault.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.lblDefault.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.lblDefault.Location = New System.Drawing.Point(0, 98)
    Me.lblDefault.Margin = New System.Windows.Forms.Padding(0, 0, 3, 0)
    Me.lblDefault.Name = "lblDefault"
    Me.lblDefault.Padding = New System.Windows.Forms.Padding(1, 3, 3, 3)
    Me.lblDefault.Size = New System.Drawing.Size(322, 21)
    Me.lblDefault.TabIndex = 4
    Me.lblDefault.Text = "Not configured"
    '
    'btnConfigDef
    '
    Me.btnConfigDef.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.btnConfigDef.Location = New System.Drawing.Point(328, 98)
    Me.btnConfigDef.Name = "btnConfigDef"
    Me.btnConfigDef.Size = New System.Drawing.Size(65, 21)
    Me.btnConfigDef.TabIndex = 5
    Me.btnConfigDef.Text = "Set..."
    Me.btnConfigDef.UseVisualStyleBackColor = True
    '
    'lstListen
    '
    Me.lstListen.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.lstListen.FormattingEnabled = True
    Me.lstListen.Location = New System.Drawing.Point(0, 15)
    Me.lstListen.Name = "lstListen"
    Me.lstListen.SelectionMode = System.Windows.Forms.SelectionMode.None
    Me.lstListen.Size = New System.Drawing.Size(322, 56)
    Me.lstListen.TabIndex = 1
    '
    'lstDoms
    '
    Me.lstDoms.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.lstDoms.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2})
    Me.lstDoms.Location = New System.Drawing.Point(0, 148)
    Me.lstDoms.Name = "lstDoms"
    Me.lstDoms.Size = New System.Drawing.Size(393, 131)
    Me.lstDoms.Sortable = True
    Me.lstDoms.TabIndex = 7
    '
    'ColumnHeader1
    '
    Me.ColumnHeader1.Text = "Host name"
    Me.ColumnHeader1.Width = 145
    '
    'ColumnHeader2
    '
    Me.ColumnHeader2.Text = "Redirect to"
    Me.ColumnHeader2.Width = 145
    '
    'OptionsUI
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.Controls.Add(Me.lstListen)
    Me.Controls.Add(Me.btnConfigDef)
    Me.Controls.Add(Me.lblDefault)
    Me.Controls.Add(Me.btnConfigIP)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.lstDoms)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.Label6)
    Me.Name = "OptionsUI"
    Me.Size = New System.Drawing.Size(393, 282)
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
  Friend WithEvents Label6 As System.Windows.Forms.Label
  Friend WithEvents btnConfigIP As System.Windows.Forms.Button
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents lstDoms As AERListBoxMC
  Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
  Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents lblDefault As System.Windows.Forms.Label
  Friend WithEvents btnConfigDef As System.Windows.Forms.Button
  Friend WithEvents lstListen As ListBox
End Class
