Imports System.Windows.Forms

Public Class frmDomain

  Friend lst As AERListBoxMC

  Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
    If txtDom.Enabled Then
      If txtDom.Text.Trim.Length = 0 Then
        MessageBox.Show("Domain name is blank", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        txtDom.Focus()
        Exit Sub
      End If
      Dim d As DomName = Nothing
      If Not DomName.TryParse(txtDom.Text.Trim, d) OrElse
         d = DomName.Root Then
        MessageBox.Show("Invalid domain name", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        txtDom.Focus()
        Exit Sub
      End If
    End If
    Dim x = txtURL.Text.Trim
    If Not x.StartsWith("http://", StringComparison.InvariantCultureIgnoreCase) AndAlso _
       Not x.StartsWith("https://", StringComparison.InvariantCultureIgnoreCase) Then
      MessageBox.Show("Redirect URL must start with http:// or https://", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      txtURL.Focus()
      Exit Sub
    End If

    If lst IsNot Nothing Then
      If Not lst.CompleteEditItem(SaveData, AddressOf CompItem) Then Exit Sub
    End If
    Me.DialogResult = System.Windows.Forms.DialogResult.OK
    Me.Close()
  End Sub

  Private Function CompItem(ByVal itm1 As Object, ByVal itm2 As Object) As Boolean
    Return (DirectCast(itm1, MyConfig.HNRedir).Name = DirectCast(itm2, MyConfig.HNRedir).Name)
  End Function

  Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
    Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
    Me.Close()
  End Sub

  Friend Sub LoadData(ByVal dom As MyConfig.HNRedir)
    If txtDom.Enabled Then
      txtDom.Text = dom.Name.ToString
      chkSubDom.Checked = dom.SubDoms
    End If
    txtURL.Text = dom.ToURL
    If dom.Relative Then radRelative.Checked = True Else radExact.Checked = True
    Select Case dom.Method
      Case MyConfig.HNRedir.RedirMethod.Status302
        rad302.Checked = True
      Case MyConfig.HNRedir.RedirMethod.Status301
        rad301.Checked = True
      Case Else
        radCloak.Checked = True
    End Select
    txtTitle.Text = dom.CloakTitle
  End Sub

  Friend Function SaveData() As MyConfig.HNRedir
    Dim rv As New MyConfig.HNRedir
    If txtDom.Enabled Then
      rv.Name = DomName.Parse(txtDom.Text.Trim)
      rv.SubDoms = chkSubDom.Checked
    Else
      rv.Name = DomName.Root
    End If
    rv.ToURL = txtURL.Text.Trim
    rv.Relative = radRelative.Checked
    If rad302.Checked Then
      rv.Method = MyConfig.HNRedir.RedirMethod.Status302
    ElseIf rad301.Checked Then
      rv.Method = MyConfig.HNRedir.RedirMethod.Status301
    Else
      rv.Method = MyConfig.HNRedir.RedirMethod.Cloak
    End If
    rv.CloakTitle = txtTitle.Text.Trim
    Return rv
  End Function

  Private Sub frmDomain_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    txtURL.Select(txtDom.Text.Length, 0)
  End Sub

  Private Sub rad302_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rad302.CheckedChanged, rad301.CheckedChanged, radCloak.CheckedChanged
    txtTitle.Enabled = radCloak.Checked
  End Sub
End Class
