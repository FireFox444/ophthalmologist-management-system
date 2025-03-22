Public Class login

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If txt_admin.Text = "" Or txt_password.Text = "" Then
            MsgBox("Enter UserName and Password")
        ElseIf txt_admin.Text = "Admin" And txt_password.Text = "password" Then
            Me.Hide()
            Dim obj = New Patient
            obj.Show()
        Else
            MsgBox("Wrong UserName and Password")
        End If

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        txt_admin.Text = ""
        txt_password.Text = ""

    End Sub

    Private Sub Label4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label4.Click
        Application.Exit()
    End Sub

    Private Sub login_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
