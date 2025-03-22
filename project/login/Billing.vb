Imports System.Data.SqlClient
Imports System.Drawing.Printing

Public Class Billing
    Dim con As New SqlConnection("Data Source=.\SQLEXPRESS;AttachDbFilename=D:\TYBCA20\New folder\PROJECT 23-24\Project\login\EyeDb.mdf;Integrated Security=True;User Instance=True")
    Dim dt As New DataTable
    Dim i As Integer = 0
    Dim GrdTotal As Integer
    Dim st1 = 0, key = 0

    Private Sub Reset()

    End Sub


    Private Sub Label8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label8.Click
        Application.Exit()
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

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        login.Show()
        Me.Hide()
    End Sub

    Private Sub Label9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label9.Click
        pt.Show()
        Me.Hide()
    End Sub

 


    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)

    End Sub

    Private Sub Billing_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Appoinment()

    End Sub
 

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If txt_ac.Text = "" Or ComboBox1.Text = "" Then
            MsgBox("Enter Charge")
        ElseIf PT_CB.Text = "" Then
            MsgBox("select name")
        Else
            Dim rnum As Integer = DataGridView1.Rows.Add()
            i = i + 1
            Dim total = Convert.ToInt32(txt_ac.Text) + Convert.ToInt32(ComboBox1.Text)
            DataGridView1.Rows.Item(rnum).Cells("column1").Value = i
            DataGridView1.Rows.Item(rnum).Cells("column2").Value = PT_CB.Text
            DataGridView1.Rows.Item(rnum).Cells("column3").Value = txt_ac.Text
            DataGridView1.Rows.Item(rnum).Cells("column4").Value = CB_Tr.Text
            DataGridView1.Rows.Item(rnum).Cells("column5").Value = ComboBox1.Text
            DataGridView1.Rows.Item(rnum).Cells("column6").Value = DateTimePicker1.Text
            DataGridView1.Rows.Item(rnum).Cells("column7").Value = total


            GrdTotal = total
            Dim tot As String
            tot = (Convert.ToString(GrdTotal))
            Label3.Text = (Convert.ToString(GrdTotal))
            Add()
            Reset()
        End If

    End Sub
    Private Sub Add()
        Dim name As String
        Dim appcharge As Integer
        Dim treatment As String
        Dim cost As Integer


        name = PT_CB.Text
        appcharge = txt_ac.Text
        treatment = CB_Tr.Text
        cost = ComboBox1.Text



        con.Open()
        Dim cmd As New SqlCommand("insert into bill values('" & name & "','" & appcharge & "','" & treatment & "','" & cost & "'," & GrdTotal & ",'" & DateTimePicker1.Text & "')", con)
        cmd.ExecuteNonQuery()
        Dim da As New SqlDataAdapter(cmd)
        Dim dt As New DataTable()
        MessageBox.Show("Insert Successfuly")
        con.Close()

    End Sub
    Private Sub Appoinment()
        Dim cmd As New SqlCommand("select * from tt1", con)
        Dim ad As New SqlDataAdapter(cmd)
        Dim table As New DataTable()
        ad.Fill(table)

        CB_Tr.DataSource = table
        CB_Tr.DisplayMember = "Name"
        CB_Tr.ValueMember = "Name"
        ComboBox1.DataSource = table
        ComboBox1.DisplayMember = "Cost"
        ComboBox1.ValueMember = "Cost"

        Dim sm As New SqlCommand("select * from pt1", con)
        Dim aa As New SqlDataAdapter(sm)
        Dim table1 As New DataTable()
        aa.Fill(table1)

        PT_CB.DataSource = table1
        PT_CB.DisplayMember = "Name"
        PT_CB.ValueMember = "Name"


        '  
    End Sub

    Private Sub loaddata()
        con.Open()
        Dim cmd As New SqlCommand("select * from bill", con)
        cmd.ExecuteNonQuery()
        Dim da As New SqlDataAdapter(cmd)
        da.Fill(dt)
        DataGridView1.DataSource = dt
        con.Close()
        Displayitem()

    End Sub
   
    Private Sub Displayitem()
        con.Open()
        Dim cmd As New SqlCommand("select * from bill", con)
        Dim da As New SqlDataAdapter(cmd)
        Dim builder As New SqlCommandBuilder(da)
        Dim ds As New DataSet
        da.Fill(ds)
        DataGridView1.DataSource = ds.Tables(0)
        con.Close()

    End Sub
    Dim WithEvents PD As New PrintDocument
    Dim PPD As New PrintPreviewDialog
    Dim longpaper As Integer
    Private Sub Pd_BeginPrint1(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles PD.BeginPrint
        Dim pagesetup As New PageSettings
        pagesetup.PaperSize = New PaperSize("Custom", 350, 500)
        PD.DefaultPageSettings = pagesetup
    End Sub

    Private Sub Pd_Print(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PD.PrintPage
        Dim f8 As New Font("Calibri", 8, FontStyle.Regular)
        Dim f10 As New Font("Calibri", 10, FontStyle.Regular)
        Dim f10b As New Font("Calibri", 10, FontStyle.Bold)
        Dim f14 As New Font("Calibri", 14, FontStyle.Bold)

        Dim leftmargin As New Integer
        Dim centermargin As New Integer
        Dim rightmargin As New Integer
        centermargin = PD.DefaultPageSettings.PaperSize.Width / 2
        leftmargin = PD.DefaultPageSettings.Margins.Left
        rightmargin = PD.DefaultPageSettings.PaperSize.Width
        'font alignment
        Dim rightas As New StringFormat
        Dim center As New StringFormat
        rightas.Alignment = StringAlignment.Far
        center.Alignment = StringAlignment.Center

        Dim line As String
        line = "------------------------------------------------------------------------------------------------------"

        e.Graphics.DrawString("Eye Care Optical", f14, Brushes.Black, centermargin, 2, center)
        e.Graphics.DrawString("ANAND,GUJRAT", f10, Brushes.Black, centermargin, 30, center)
        e.Graphics.DrawString("Tel + 7698580673", f8, Brushes.Black, centermargin, 45, center)

        e.Graphics.DrawString("Id", f8, Brushes.Black, 0, 60)
        e.Graphics.DrawString(":", f10, Brushes.Black, 50, 60)
        e.Graphics.DrawString("HST250011", f8, Brushes.Black, 70, 60)

        e.Graphics.DrawString("Cashier", f8, Brushes.Black, 0, 75)
        e.Graphics.DrawString(":", f10, Brushes.Black, 50, 75)
        e.Graphics.DrawString("Harshil", f8, Brushes.Black, 70, 75)

        ' e.Graphics.DrawString("07/28/2023 | (18.00)", f8, Brushes.Black, 0, 90)

        e.Graphics.DrawString(line, f8, Brushes.Black, 0, 100)
        e.Graphics.DrawString("name", f10b, Brushes.Black, 10, 90)
        e.Graphics.DrawString("Treatment", f10b, Brushes.Black, 80, 90)
        e.Graphics.DrawString("Treatment-charges", f10b, Brushes.Black, 150, 90)
        e.Graphics.DrawString("Appoi-cost", f10b, Brushes.Black, 270, 90)

        Dim height As New Integer 'dgv postion
        Dim i As Long

        DataGridView1.AllowUserToAddRows = False
        For row As Integer = 0 To DataGridView1.RowCount - 1
            height += 15
            e.Graphics.DrawString(DataGridView1.Rows(row).Cells(1).Value.ToString, f10, Brushes.Black, 0, 100 + height)
            e.Graphics.DrawString(DataGridView1.Rows(row).Cells(3).Value.ToString, f10, Brushes.Black, 80, 100 + height)
            e.Graphics.DrawString(DataGridView1.Rows(row).Cells(4).Value.ToString, f10, Brushes.Black, 200, 100 + height)
            i = DataGridView1.Rows(row).Cells(6).Value
            DataGridView1.Rows(row).Cells(5).Value = Format(i, "##,##0")
            e.Graphics.DrawString(DataGridView1.Rows(row).Cells(2).Value.ToString, f10, Brushes.Black, 310, 100 + height, rightas)
        Next
        Dim hights2 As Integer
        bTotal()
        hights2 = 110 + height
        e.Graphics.DrawString(line, f8, Brushes.Black, 0, hights2)
        e.Graphics.DrawString("Total : " & Format(total, "##,##0"), f10b, Brushes.Black, rightmargin, 15 + hights2, rightas)
        ' e.Graphics.DrawString("Qty", f10b, Brushes.Black, 90, 15 + hights2)


        e.Graphics.DrawString("Health Care serivce", f10, Brushes.Black, centermargin, 55 + hights2, center)
    End Sub
    Dim total As Integer
    Sub bTotal()

        total = Label3.Text
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        PPD.Document = PD
        PPD.ShowDialog()
    End Sub


    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        PT_CB.Text = ""
        txt_ac.Text = ""
        CB_Tr.Text = ""
        ComboBox1.Text = ""
        Label3.Text = ""
        GrdTotal = 0
        DataGridView1.Rows.Clear()
        DataGridView1.Refresh()
    End Sub

    Private Sub PictureBox6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox6.Click
        Appoinment()
    End Sub
    

End Class