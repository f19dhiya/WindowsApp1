Imports System.Data.SqlClient
Imports System.Runtime.Remoting.Services
Imports System.Text.RegularExpressions
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports MySql.Data.MySqlClient


Public Class Form2

    Dim connectionString As String = "server=localhost;user=root;password=admin;database=tms;"

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        home.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click




        If String.IsNullOrEmpty(ComboBox1.Text) Then
            MessageBox.Show("Please select a course name .", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ComboBox1.Focus()
            Return
        End If

        If String.IsNullOrWhiteSpace(TextBox3.Text) Then
            MessageBox.Show("tuition fee must be a non- negative decimal value.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBox3.Focus()
            Return
        End If

        If String.IsNullOrWhiteSpace(TextBox4.Text) Then
            MessageBox.Show("material fee must be a non- negative decimal value.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBox4.Focus()
            Return
        End If

        If String.IsNullOrEmpty(ComboBox2.Text) Then
            MessageBox.Show("please select course duration .", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ComboBox2.Focus()
            Return
        End If

        If String.IsNullOrWhiteSpace(TextBox6.Text) Then
            MessageBox.Show("Please enter the course strength.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBox6.Focus()
            Return
        ElseIf TextBox6.Text.Length > 2 AndAlso IsNumeric(TextBox6.Text) Then
            MessageBox.Show("Please enter a valid course strength.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBox6.Focus()
            Return
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        ' Assuming Form3 is correctly set up and intended to be shown next
        Me.Hide()
        Form3.Show()

        ' Database insertion starts here
        Dim connectionString As String = "server=localhost;user=root;password=admin;database=tms;"
        Try
            Using connection As New MySqlConnection(connectionString)
                Dim query As String = "INSERT INTO courses (cname, ctutionfees, cmaterialfees, Cduration, Cstrength) VALUES (@cname, @ctutionfees, @cmaterialfees, @Cduration, @Cstrength)"

                Using command As New MySqlCommand(query, connection)
                    ' Add parameters with values from your form controls
                    command.Parameters.AddWithValue("@cname", ComboBox1.Text)
                    command.Parameters.AddWithValue("@ctutionfees", TextBox3.Text)
                    command.Parameters.AddWithValue("@cmaterialfees", TextBox4.Text)
                    command.Parameters.AddWithValue("@Cduration", ComboBox2.Text)
                    command.Parameters.AddWithValue("@Cstrength", TextBox6.Text)

                    connection.Open()
                    command.ExecuteNonQuery()
                    MessageBox.Show("Course data saved successfully.")
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


End Class
