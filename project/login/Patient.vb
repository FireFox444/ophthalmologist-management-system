Imports System.Data.SqlClient
Public Class Patient
    Dim Con As New SqlConnection("Data Source=.\SQLEXPRESS;AttachDbFilename=D:\TYBCA20\New folder\PROJECT 23-24\Project\login\EyeDb.mdf;Integrated Security=True;User Instance=True")
    Dim dt As New DataTable
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim iname As String
        Dim phone As String
        Dim add As String
        Dim DOB As String
        Dim Gen As String
        Dim age As Integer



        iname = PatNameTb.Text
        phone = PatPhoneTb.Text
        add = PatAddTb.Text
        DOB = DOBDate.Text
        Gen = GenCb.Text
        age = txt_age.Text


        Con.Open()
        Dim cmd As New SqlCommand("insert into pt1 values('" & iname & "','" & add & "','" & DOB & "','" & age & "','" & phone & "','" & Gen & "')", Con)
        cmd.ExecuteNonQuery()
        Dim da As New SqlDataAdapter(cmd)
        Dim dt As New DataTable()
        MessageBox.Show("Insert Successfuly")
        Con.Close()
        LoadDataInGridView()
        Displayitem()

    End Sub
    Public Sub LoadDataInGridView()
        Dim cmd As New SqlCommand("select * from pt1", Con)
        Dim da As New SqlDataAdapter(cmd)
        Dim dt As New DataTable()
        da.Fill(dt)
        DataGridView1.DataSource = dt
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        login.Show()
        Me.Hide()
    End Sub

    Private Sub Label8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label8.Click
        Application.Exit()

    End Sub

    Private Sub Label10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label10.Click
        Appointment.Show()
        Me.Hide()
    End Sub

    Private Sub Label11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label11.Click
        Treatment.Show()
        Me.Hide()
    End Sub

    Private Sub Label12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label12.Click
        Billing.Show()
        Me.Hide()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim iname As String
        Dim phone As String
        Dim add As String
        Dim DOB As String
        Dim Gen As String
        Dim age As Integer



        iname = PatNameTb.Text
        phone = PatPhoneTb.Text
        add = PatAddTb.Text
        DOB = DOBDate.Text
        Gen = GenCb.Text
        age = txt_age.Text


        Con.Open()
        Dim cmd As New SqlCommand("update pt1 SET Phone='" & phone & "',Addr='" & add & "',DOB='" & DOB & "',Age='" & age & "' where Name='" & iname & "' ", Con)
        cmd.ExecuteNonQuery()
        Dim da As New SqlDataAdapter(cmd)
        Dim dt As New DataTable()
        MsgBox("Patients Details Updated")
        Con.Close()
        LoadDataInGridView()
        Displayitem()

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim name As String
        name = PatNameTb.Text
        Dim cmd As New SqlCommand("delete from pt1 where Name='" & name & "' ", Con)
        Con.Open()
        cmd.ExecuteNonQuery()
        Con.Close()
        MsgBox("Data Deleted Succesfully")
        Displayitem()


    End Sub

    Private Sub Patient_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadDataInGridView()
        Displayitem()
    End Sub

    Private Sub Displayitem()
        Con.Open()
        Dim cmd As New  SqlCommand("select * from pt1", Con)
        Dim da As New SqlDataAdapter(cmd)
        Dim builder As New SqlCommandBuilder(da)
        Dim ds As New DataSet
        da.Fill(ds)
        DataGridView1.DataSource = ds.Tables(0)
        Con.Close()
    End Sub
    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)

        PatNameTb.Text = row.Cells(1).Value.ToString
        PatAddTb.Text = row.Cells(2).Value.ToString
        DOBDate.Text = row.Cells(3).Value.ToString
        txt_age.Text = row.Cells(4).Value.ToString
        PatPhoneTb.Text = row.Cells(5).Value.ToString
        GenCb.Text = row.Cells(6).Value.ToString


    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click

        txt_age.Text = ""
        PatNameTb.Text = ""
        PatPhoneTb.Text = ""
        PatAddTb.Text = ""
        DOBDate.Text = ""
        GenCb.Text = ""
    End Sub

    Private Sub Label15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label15.Click
        pt.Show()
        Me.Hide()
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub PatPhoneTb_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PatPhoneTb.Leave
        Dim mno As String = PatPhoneTb.Text
        If mno.Length <> 10 Then
            MsgBox("Mobile number must be of 10 Digit")
        End If


    End Sub

    Private Sub PatNameTb_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles PatNameTb.KeyPress
        If Not Char.IsLetter(e.KeyChar) And Not e.KeyChar = Chr(Keys.Delete) And Not e.KeyChar = Chr(Keys.Back) And Not e.KeyChar = Chr(Keys.Space) Then
            e.Handled = True
            MsgBox("Enter valid name")
        End If
    End Sub

    Private Sub lable1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lable1.Click

    End Sub
End Class