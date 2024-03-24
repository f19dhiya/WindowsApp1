Imports MySql.Data.MySqlClient
Imports System.IO
Imports System.Text

Public Class home
    Private Sub home_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        Form2.Show()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
        Form3.Show()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Form4.Show()
        Me.Hide()

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Form5.Show()
        Me.Hide()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Form6.Show()
        Me.Hide()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Application.Exit()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        ' Generate and save receipt
        GenerateReceipt()
    End Sub

    Private Sub GenerateReceipt()
        Dim connectionString As String = "server=localhost;user=root;password=admin;database=tms;"
        Dim query As String = "SELECT * FROM payment"

        Try
            Using connection As New MySqlConnection(connectionString)
                Using command As New MySqlCommand(query, connection)
                    Dim table As New DataTable()

                    connection.Open()

                    ' Load data into DataTable
                    Using adapter As New MySqlDataAdapter(command)
                        adapter.Fill(table)
                    End Using

                    ' Generate receipt content
                    Dim receiptContent As String = GenerateReceiptContent(table)

                    ' Save receipt to file
                    Dim saveFileDialog As New SaveFileDialog()
                    saveFileDialog.Filter = "Text files (*.txt)|*.txt"
                    saveFileDialog.Title = "Save Receipt"
                    saveFileDialog.FileName = "payment_receipt.txt"

                    If saveFileDialog.ShowDialog() = DialogResult.OK Then
                        Dim fileName As String = saveFileDialog.FileName

                        ' Write content to file
                        Using writer As New StreamWriter(fileName)
                            writer.Write(receiptContent)
                        End Using

                        MessageBox.Show("Receipt saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"An error occurred while generating receipt: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function GenerateReceiptContent(table As DataTable) As String
        Dim sb As New StringBuilder()

        ' Header
        sb.AppendLine("Payment Receipt")
        sb.AppendLine("------------------------------")

        ' Data
        For Each row As DataRow In table.Rows
            sb.AppendLine($"Payment ID: {row("pid")}")
            sb.AppendLine($"Student ID: {row("stuid")}")
            sb.AppendLine($"Enrollment ID: {row("eid")}")
            sb.AppendLine($"Payment Date: {Convert.ToDateTime(row("pdate")):MM/dd/yyyy}")
            sb.AppendLine($"Amount: {Convert.ToDecimal(row("amount")):C}")
            sb.AppendLine($"Payment Method: {row("pmethord")}")
            sb.AppendLine("------------------------------")
        Next

        Return sb.ToString()
    End Function

End Class