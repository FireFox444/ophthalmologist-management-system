Imports System.Data.SqlClient
Public Class Treatment
    Dim Con As New SqlConnection("Data Source=.\SQLEXPRESS;AttachDbFilename=D:\TYBCA20\New folder\PROJECT 23-24\Project\login\EyeDb.mdf;Integrated Security=True;User Instance=True")
    Dim dt As New DataTable
    Private Sub Label7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label7.Click
        Application.Exit()

    End Sub

    Private Sub Label2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label2.Click
        Patient.Show()
        Me.Hide()
    End Sub

    Private Sub Label11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label11.Click
        Appointment.Show()
        Me.Hide()
    End Sub

    Private Sub Label12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label12.Click
        Billing.Show()
        Me.Hide()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        login.Show()
        Me.Hide()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim Name As String
        Dim Cost As Integer
        Dim Description As String

        Name = TextBox1.Text
        Cost = TextBox2.Text
        Description = TextBox3.Text

        Con.Open()
        Dim cmd As New SqlCommand("insert into tt1 values ('" & Name & "','" & Cost & "','" & Description & "')", Con)
        cmd.ExecuteNonQuery()
        Dim da As New SqlDataAdapter(cmd)
        Dim dt As New DataTable()
        MessageBox.Show("Insert Successfuly")
        Con.Close()
        LoadDataInGridView()
    End Sub


    Public Sub LoadDataInGridView()
        Dim cmd As New SqlCommand("select * from tt1", Con)
        Dim da As New SqlDataAdapter(cmd)
        Dim dt As New DataTable()
        da.Fill(dt)
        DataGridView1.DataSource = dt
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click


        Dim Name As String
        Dim Cost As Integer
        Dim Description As String




        Name = TextBox1.Text
        Cost = TextBox2.Text
        Description = TextBox3.Text

        Con.Open()
        Dim cmd As New SqlCommand("update tt1 SET Cost='" & Cost & "',Description='" & Description & "' where Name='" & Name & "' ", Con)
        cmd.ExecuteNonQuery()
        Dim da As New SqlDataAdapter(cmd)
        Dim dt As New DataTable()
        MsgBox("Patients Details Updated")
        Con.Close()
        LoadDataInGridView()
    End Sub

    Private Sub Treatment_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadDataInGridView()

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim nm As String

        nm = TextBox1.Text

        Dim cmd As New SqlCommand("delete from tt1 where Name='" & nm & "' ", Con)
        Con.Open()
        cmd.ExecuteNonQuery()
        Con.Close()
        MsgBox("Data Deleted Succesfully")
        Displayitem()

    End Sub
    Private Sub Displayitem()
        Con.Open()
        Dim cmd As New SqlCommand("select * from tt1", Con)
        Dim da As New SqlDataAdapter(cmd)
        Dim builder As New SqlCommandBuilder(da)
        Dim ds As New DataSet
        da.Fill(ds)
        DataGridView1.DataSource = ds.Tables(0)
        Con.Close()
    End Sub
    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
        TextBox1.Text = row.Cells(0).Value.ToString
        TextBox2.Text = row.Cells(1).Value.ToString
        TextBox3.Text = row.Cells(2).Value.ToString
    

    End Sub

    Private Sub TextBox3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox3.TextChanged

    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
       
    End Sub

    Private Sub Label8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label8.Click
        pt.Show()
        Me.Hide()
    End Sub

    Private Sub TextBox2_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox2.Leave
        Dim Cost As String = TextBox2.Text
        If Cost.Length <= 5 Then

        Else
            MsgBox("enter the amount of treatment under 5 number")
        End If

    End Sub
End Class