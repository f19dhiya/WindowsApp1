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

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        ' Assuming Form3 is correctly set up and intended to be shown next
        Me.Hide()
        Form3.Show()


    End Sub


End Class
