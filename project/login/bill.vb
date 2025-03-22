Imports System.Data.SqlClient
Imports Microsoft.Office.Core
Imports excel = Microsoft.Office.Interop.Excel
Imports excelAutoFormet = Microsoft.Office.Interop.Excel.XlRangeAutoFormat
Imports Microsoft.Office.Interop
Imports System.Data
Imports System.Xml.XPath
Imports System.Drawing.Printing
Public Class bill
    Dim con As New SqlConnection("Data Source=.\SQLEXPRESS;AttachDbFilename=D:\TYBCA20\New folder\PROJECT 23-24\Project\login\EyeDb.mdf;Integrated Security=True;User Instance=True")
    Dim dt As New DataTable()
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        filterbycatagory()
    End Sub
    Private Sub filterbycatagory()
        If searchbox.SelectedIndex = 0 Then

            pt.Show()

        ElseIf searchbox.SelectedIndex = 1 Then

            app.Show()
            Me.Hide()

        ElseIf searchbox.SelectedIndex = 2 Then

            tt.Show()
            Me.Hide()

        
        End If
    End Sub

    Private Sub bill_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Displayitem()

        DataGridView1.Refresh()
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

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Date1.Enabled = True And Date2.Enabled = True Then
            con.Open()
            Dim cmd As New SqlCommand("select * from bill where Date between @Date1 and @Date2", con)
            cmd.Parameters.Add("Date1", SqlDbType.DateTime).Value = Date1.Value
            cmd.Parameters.Add("Date2", SqlDbType.DateTime).Value = Date2.Value
            Dim da As New SqlDataAdapter
            da.SelectCommand = cmd
            dt.Clear()
            con.Close()
            da.Fill(dt)
            DataGridView1.DataSource = dt

        End If

        If TextBox1.Enabled = True Then
            con.Open()
            Dim cmd As New SqlCommand("select * from bill where Patient=@Patient", con)
            cmd.Parameters.AddWithValue("Patient", TextBox1.Text)
            Dim da As New SqlDataAdapter
            da.SelectCommand = cmd
            dt.Clear()
            con.Close()
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
    Private Sub Displayitem()
        Con.Open()
        Dim cmd As New SqlCommand("select * from bill", con)
        Dim da As New SqlDataAdapter(cmd)
        Dim builder As New SqlCommandBuilder(da)
        Dim ds As New DataSet
        da.Fill(ds)
        DataGridView1.DataSource = ds.Tables(0)
        Con.Close()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        TextBox1.Text = ""
        Date1.Text = ""
        Date2.Text = ""
        searchbox.Text = ""
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Try




            Button2.Text = "Please wait......"
            Button2.Enabled = False

            SaveFileDialog1.Filter = "Excel Document(*.xlsx)|*.xlsx"
            If SaveFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                Dim xlApp As Microsoft.Office.Interop.Excel.Application
                Dim xlworkbook As Microsoft.Office.Interop.Excel.Workbook
                Dim xlworksheet As Microsoft.Office.Interop.Excel.Worksheet
                Dim misvalue As Object = System.Reflection.Missing.Value
                Dim i As Integer
                Dim j As Integer

                xlApp = New Microsoft.Office.Interop.Excel.Application
                xlworkbook = xlApp.Workbooks.Add(misvalue)
                xlworksheet = xlworkbook.Sheets("sheet1")

                For i = 0 To DataGridView1.RowCount - 2
                    For j = 0 To DataGridView1.ColumnCount - 1
                        For k As Integer = 1 To DataGridView1.Columns.Count
                            xlworksheet.Cells(1, k) = DataGridView1.Columns(k - 1).HeaderText
                            xlworksheet.Cells(i + 2, j + 1) = DataGridView1(j, i).Value.ToString()

                        Next
                    Next
                Next

                xlworksheet.SaveAs(SaveFileDialog1.FileName)
                xlworkbook.Close()
                xlApp.Quit()

                reseaseobject(xlApp)
                reseaseobject(xlworkbook)
                reseaseobject(xlworksheet)

                MsgBox("successfully saved" & vbCrLf & "File are saved at : " & SaveFileDialog1.FileName, MsgBoxStyle.Information)

                Button2.Text = "Export to MS Excel"
                Button2.Enabled = True
            End If
        Catch ex As Exception
            MessageBox.Show("Failed to save !!!", "Error message", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return

        End Try
    End Sub
    Private Sub reseaseobject(ByVal obj As Object)
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            obj = Nothing
        Finally
            GC.Collect()

        End Try
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        ppd.Document = Pd
        ppd.ShowDialog()
    End Sub
    Dim WithEvents Pd As New PrintDocument
    Dim ppd As New PrintPreviewDialog
    Dim longpaper As Integer

    Private Sub Pd_BeginPrint1(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles Pd.BeginPrint
        Dim pagesetup As New PageSettings
        pagesetup.PaperSize = New PaperSize("Custom", 250, 500)
        Pd.DefaultPageSettings = pagesetup
    End Sub

    Private Sub Pd_Print(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles Pd.PrintPage
        Dim f8 As New Font("Calibri", 8, FontStyle.Regular)
        Dim f10 As New Font("Calibri", 10, FontStyle.Regular)
        Dim f10b As New Font("Calibri", 10, FontStyle.Bold)
        Dim f14 As New Font("Calibri", 14, FontStyle.Bold)

        Dim leftmargin As New Integer
        Dim centermargin As New Integer
        Dim rightmargin As New Integer
        centermargin = Pd.DefaultPageSettings.PaperSize.Width / 2
        leftmargin = Pd.DefaultPageSettings.Margins.Left
        rightmargin = Pd.DefaultPageSettings.PaperSize.Width

        Dim rightas As New StringFormat
        Dim center As New StringFormat
        rightas.Alignment = StringAlignment.Far
        center.Alignment = StringAlignment.Center

        Dim line As String
        line = "---------------------------------------------------------------------------------------------------------------------"

        e.Graphics.DrawString("EYE CARE", f14, Brushes.Black, centermargin, 2, center)
        e.Graphics.DrawString("ANAND,GUJRAT", f10, Brushes.Black, centermargin, 30, center)
        e.Graphics.DrawString("tel +91 6351785524", f8, Brushes.Black, centermargin, 45, center)

        e.Graphics.DrawString("Id", f8, Brushes.Black, 0, 60)
        e.Graphics.DrawString(":", f10, Brushes.Black, 50, 60)
        e.Graphics.DrawString("H54277", f8, Brushes.Black, 70, 60)

        e.Graphics.DrawString("Dr.", f8, Brushes.Black, 0, 75)
        e.Graphics.DrawString(":", f10, Brushes.Black, 50, 75)
        e.Graphics.DrawString("Harshil", f8, Brushes.Black, 70, 75)
        'fetching the customer name 




        e.Graphics.DrawString(line, f8, Brushes.Black, 0, 120)

        e.Graphics.DrawString("ID", f10b, Brushes.Black, 3, 130)
        e.Graphics.DrawString("Name", f10b, Brushes.Black, 50, 130)
        e.Graphics.DrawString("Charges", f10b, Brushes.Black, 120, 130)
        e.Graphics.DrawString("Cost", f10b, Brushes.Black, 200, 130)


        Dim height As New Integer
        ' Dim i As Long

        DataGridView1.AllowUserToAddRows = False
        For row As Integer = 0 To DataGridView1.RowCount - 1
            height += 15
            e.Graphics.DrawString(DataGridView1.Rows(row).Cells(0).Value.ToString, f10, Brushes.Black, 0, 140 + height)
            e.Graphics.DrawString(DataGridView1.Rows(row).Cells(1).Value.ToString, f10, Brushes.Black, 50, 140 + height)
            e.Graphics.DrawString(DataGridView1.Rows(row).Cells(2).Value.ToString, f10, Brushes.Black, 120, 140 + height)
            e.Graphics.DrawString(DataGridView1.Rows(row).Cells(4).Value.ToString, f10, Brushes.Black, 200, 140 + height)

            'i = DataGridView1.Rows(row).Cells(2).Value
            'DataGridView1.Rows(row).Cells(1).Value = Format(i, "##,##0")
            'e.Graphics.DrawString(DataGridView1.Rows(row).Cells(2).Value.ToString, f10, Brushes.Black, rightmargin, 140 + height, rightas)
        Next
       ' Dim hights2 As Integer
        'bTotal()
        'hights2 = 150 + height
        'e.Graphics.DrawString(line, f8, Brushes.Black, 0, hights2)

        'e.Graphics.DrawString("Total : " & Format(total, "##,##0"), f10b, Brushes.Black, rightmargin, 15 + hights2, rightas)


        'e.Graphics.DrawString("Thanks for Shopping", f10, Brushes.Black, centermargin, 40 + hights2, center)
        'e.Graphics.DrawString("Ghanshyam Grocery Store", f10, Brushes.Black, centermargin, 55 + hights2, center)
    End Sub
    Private Sub Displayitem1()
        con.Open()
        Dim cmd As New SqlCommand("select * from bill", con)
        Dim da As New SqlDataAdapter(cmd)
        Dim builder As New SqlCommandBuilder(da)
        Dim ds As New DataSet
        da.Fill(ds)
        DataGridView1.DataSource = ds.Tables(0)
        con.Close()
    End Sub
    Private Sub PictureBox6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox6.Click
        Displayitem1()
    End Sub
End Class