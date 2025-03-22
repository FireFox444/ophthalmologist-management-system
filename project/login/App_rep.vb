Imports System.Data.SqlClient
Public Class App_rep
    Dim con As New SqlConnection("Data Source=.\SQLEXPRESS;AttachDbFilename=D:\TYBCA20\New folder\PROJECT 23-24\Project\login\EyeDb.mdf;Integrated Security=True;User Instance=True")
    Dim dt As New DataTable()

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        filterbycatagory()
    End Sub
    Private Sub filterbycatagory()
        If searchbox.selectedindex = 0 Then
            con.Open()
            Dim cmd As New SqlCommand("select * from pt1", con)
            Dim da As New SqlDataAdapter(cmd)
            Dim builder As New SqlCommandBuilder(da)
            Dim ds As New DataSet
            da.Fill(ds)
            DataGridView1.DataSource = ds.Tables(0)
            con.Close()

        ElseIf searchbox.SelectedIndex = 1 Then

            con.Open()
            Dim cmd As New SqlCommand("select * from App", con)
            Dim da As New SqlDataAdapter(cmd)
            Dim builder As New SqlCommandBuilder(da)
            Dim ds As New DataSet
            da.Fill(ds)
            DataGridView1.DataSource = ds.Tables(0)
            con.Close()

        ElseIf searchbox.SelectedIndex = 2 Then

            con.Open()
            Dim cmd As New SqlCommand("select * from tt1", con)
            Dim da As New SqlDataAdapter(cmd)
            Dim builder As New SqlCommandBuilder(da)
            Dim ds As New DataSet
            da.Fill(ds)
            DataGridView1.DataSource = ds.Tables(0)
            con.Close()

        ElseIf searchbox.SelectedIndex = 3 Then

            con.Open()
            Dim cmd As New SqlCommand("select * from bill", con)
            Dim da As New SqlDataAdapter(cmd)
            Dim builder As New SqlCommandBuilder(da)
            Dim ds As New DataSet
            da.Fill(ds)
            DataGridView1.DataSource = ds.Tables(0)
            con.Close()
        End If
    End Sub

    Private Sub Label7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label7.Click
        Patient.Show()
        Me.Hide()

    End Sub

    Private Sub Label11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label11.Click
        Appointment.Show()
        Me.Hide()

    End Sub

    Private Sub Label12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label12.Click
        Treatment.Show()
        Me.Hide()

    End Sub

    Private Sub Label2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label2.Click
        Billing.Show()
        Me.Hide()

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        login.Show()
        Me.Hide()

    End Sub

    Private Sub Label3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label3.Click
        Application.Exit()
    End Sub
End Class