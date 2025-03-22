Imports System.Data.SqlClient
Public Class Report
    Dim Con As New SqlConnection("Data Source=.\SQLEXPRESS;AttachDbFilename=D:\TYBCA20\New folder\PROJECT 23-24\Project\login\EyeDb.mdf;Integrated Security=True;User Instance=True")
    Dim dt As New DataTable
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

    Private Sub Label8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label8.Click
        Application.Exit()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        If Date1.Enabled = True And Date2.Enabled = True Then
            Con.Open()
            Dim cmd As New SqlCommand("select * from App where Date between @Date1 and @Date2", Con)
            cmd.Parameters.Add("Date1", SqlDbType.DateTime).Value = Date1.Value
            cmd.Parameters.Add("Date2", SqlDbType.DateTime).Value = Date2.Value
            Dim da As New SqlDataAdapter
            da.SelectCommand = cmd
            dt.Clear()
            Con.Close()
            da.Fill(dt)
            DataGridView1.DataSource = dt

        End If

        If TextBox1.Enabled = True Then
            Con.Open()
            Dim cmd As New SqlCommand("select * from App where Patient=@TextBox1", Con)
            cmd.Parameters.AddWithValue("TextBox1", TextBox1.Text)
            Dim da As New SqlDataAdapter
            da.SelectCommand = cmd
            dt.Clear()
            Con.Close()
            da.Fill(dt)
            DataGridView1.DataSource = dt
        End If
        



    End Sub

    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton1.CheckedChanged
        If RadioButton1.Checked = True Then
            TextBox1.Enabled = True
            Date1.Enabled = False
            Date2.Enabled = False

        End If
    End Sub

    Private Sub RadioButton2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton2.CheckedChanged
        If RadioButton2.Checked = True Then
            TextBox1.Enabled = False
            Date1.Enabled = True
            Date2.Enabled = True

        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        TextBox1.Text = ""
        Date1.Text = ""
        Date2.Text = ""
    End Sub

    Private Sub Report_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class