Imports System.Data.SqlClient
Public Class Appointment
    Dim con As New SqlConnection("Data Source=.\SQLEXPRESS;AttachDbFilename=D:\TYBCA20\New folder\PROJECT 23-24\Project\login\EyeDb.mdf;Integrated Security=True;User Instance=True")
    Dim cmd As SqlCommand
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim Patient As String
        Dim Da As String
        Dim Time As String
        Dim Treatment As String
        

        Patient = PT_CB.Text
        Da = AppDate.Text
        Time = ComboBox1.Text
        Treatment = TrCB.Text
       

        con.Open()
        Dim cmd As New SqlCommand("insert into App values('" & Patient & "','" & Da & "','" & Time & "','" & Treatment & "')", con)
        cmd.ExecuteNonQuery()
        'Dim da As New SqlDataAdapter(cmd)
        'Dim dt As New DataTable()
        MessageBox.Show("Insert Successfuly")
        con.Close()
        LoadDataInGridView()
    End Sub

    Private Sub Label2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label2.Click
        Patient.Show()
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

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        login.Show()
        Me.Hide()
    End Sub

    Private Sub Label9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label9.Click
        Application.Exit()

    End Sub

    Public Sub LoadDataInGridView()
        Dim cmd As New SqlCommand("select * from App", con)
        Dim da As New SqlDataAdapter(cmd)
        Dim dt As New DataTable()
        da.Fill(dt)
        DataGridView1.DataSource = dt
    End Sub

    Private Sub Appoinment_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadDataInGridView()
        'Dim cmd As New SqlCommand("select * from tt1", con)
        'Dim ad As New SqlDataAdapter(cmd)
        'Dim table As New DataTable()
        'ad.Fill(table)

        'TrCB.DataSource = table
        'TrCB.DisplayMember = "Name"
        'TrCB.ValueMember = "Name"

        'Dim sm As New SqlCommand("select * from pt1", con)
        'Dim aa As New SqlDataAdapter(sm)
        'Dim table1 As New DataTable()
        'aa.Fill(table1)

        'PT_CB.DataSource = table1
        'PT_CB.DisplayMember = "Name"
        'PT_CB.ValueMember = "Name"
        Displayitem()
        Appoinment()

    End Sub

    Private Sub Appoinment()
        Dim cmd As New SqlCommand("select * from tt1", con)
        Dim ad As New SqlDataAdapter(cmd)
        Dim table As New DataTable()
        ad.Fill(table)

        TrCB.DataSource = table
        TrCB.DisplayMember = "Name"
        TrCB.ValueMember = "Name"

        Dim sm As New SqlCommand("select * from pt1", con)
        Dim aa As New SqlDataAdapter(sm)
        Dim table1 As New DataTable()
        aa.Fill(table1)

        PT_CB.DataSource = table1
        PT_CB.DisplayMember = "Name"
        PT_CB.ValueMember = "Name"
    End Sub

    Private Sub tt()

    End Sub

    Private Sub Label7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim patients As String
        patients = PT_CB.Text

        Dim cmd As New SqlCommand("delete from App where Patient='" & patients & "' ", con)
        con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
        MsgBox("Data Deleted Succesfully")
        Displayitem()

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim Patient As String
        Dim Da1 As String
        Dim Treatment As String
        Dim Time As String
        
        Patient = PT_CB.Text
        Da1 = AppDate.Text
        Treatment = TrCB.Text
        Time = ComboBox1.Text
        


        con.Open()
        Dim cmd As New SqlCommand("update App SET Date='" & Da1 & "',Time='" & Time & "',Treatment='" & Treatment & "' where Patient = '" & Patient & "' ", con)
        cmd.ExecuteNonQuery()
        Dim da As New SqlDataAdapter(cmd)
        Dim dt As New DataTable()
        MsgBox("Patients Details Updated")
        con.Close()
        LoadDataInGridView()

    End Sub
    Private Sub Displayitem()
        Con.Open()
        Dim cmd As New SqlCommand("select * from App", con)
        Dim da As New SqlDataAdapter(cmd)
        Dim builder As New SqlCommandBuilder(da)
        Dim ds As New DataSet
        da.Fill(ds)
        DataGridView1.DataSource = ds.Tables(0)
        Con.Close()
    End Sub
    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
        PT_CB.Text = row.Cells(0).Value.ToString
        AppDate.Text = row.Cells(1).Value.ToString
        TrCB.Text = row.Cells(3).Value.ToString
        ComboBox1.Text = row.Cells(2).Value.ToString
       


    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        PT_CB.Text = ""
        AppDate.Text = ""
        TrCB.Text = ""
        ComboBox1.Text = ""
        
    End Sub

    Private Sub Label7_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label7.Click
        pt.Show()
        Me.Hide()
    End Sub

    Private Sub TrCB_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrCB.SelectedIndexChanged

    End Sub
    Private Sub PictureBox6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox6.Click
        Appoinment()
    End Sub

    Private Sub PT_CB_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PT_CB.SelectedIndexChanged

    End Sub
End Class