Imports MySql.Data.MySqlClient
Public Class Form4
    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Load ComboBox1 with stuid values
        LoadStuidComboBox()

        ' Load ComboBox2 with cid values
        LoadCidComboBox()
    End Sub

    Private Sub LoadStuidComboBox()
        Dim connectionString As String = "server=localhost;user=root;password=admin;database=tms;"
        Dim query As String = "SELECT stuid FROM student"

        Try
            Using connection As New MySqlConnection(connectionString)
                Using command As New MySqlCommand(query, connection)
                    connection.Open()
                    Using reader As MySqlDataReader = command.ExecuteReader()
                        While reader.Read()
                            ComboBox1.Items.Add(reader("stuid").ToString())
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"An error occurred while loading stuid values: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadCidComboBox()
        Dim connectionString As String = "server=localhost;user=root;password=admin;database=tms;"
        Dim query As String = "SELECT cid FROM courses"

        Try
            Using connection As New MySqlConnection(connectionString)
                Using command As New MySqlCommand(query, connection)
                    connection.Open()
                    Using reader As MySqlDataReader = command.ExecuteReader()
                        While reader.Read()
                            ComboBox2.Items.Add(reader("cid").ToString())
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"An error occurred while loading cid values: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' Commit the changes to the enrollment table
        SaveToEnrollment()
    End Sub

    Private Sub SaveToEnrollment()
        Dim connectionString As String = "server=localhost;user=root;password=admin;database=tms;"
        Dim query As String = "INSERT INTO enrollment (stuid, cid, date) VALUES (@stuid, @cid, @date)"

        Try
            Using connection As New MySqlConnection(connectionString)
                Using command As New MySqlCommand(query, connection)
                    command.Parameters.AddWithValue("@stuid", ComboBox1.SelectedItem)
                    command.Parameters.AddWithValue("@cid", ComboBox2.SelectedItem)
                    command.Parameters.AddWithValue("@date", DateTimePicker1.Value.Date)

                    connection.Open()
                    command.ExecuteNonQuery()
                    MessageBox.Show("Enrollment data saved successfully.")
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"An error occurred while saving enrollment data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class