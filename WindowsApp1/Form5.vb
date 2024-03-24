Imports MySql.Data.MySqlClient

Public Class Form5
    Private Sub Form5_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Load ComboBox1 with cid values
        LoadCidComboBox()

        ' Hide Label5 and Label6 initially
        Label5.Visible = False
        Label6.Visible = False
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
                            ComboBox1.Items.Add(reader("cid").ToString())
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"An error occurred while loading cid values: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        ' Show Label5 and Label6
        Label5.Visible = True
        Label6.Visible = True

        ' Fetch and display ctutionfees and cmaterialfees based on the selected cid
        Dim connectionString As String = "server=localhost;user=root;password=admin;database=tms;"
        Dim query As String = "SELECT ctutionfees, cmaterialfees FROM courses WHERE cid = @cid"

        Try
            Using connection As New MySqlConnection(connectionString)
                Using command As New MySqlCommand(query, connection)
                    command.Parameters.AddWithValue("@cid", ComboBox1.SelectedItem)

                    connection.Open()
                    Using reader As MySqlDataReader = command.ExecuteReader()
                        If reader.Read() Then
                            Label5.Text = reader("ctutionfees").ToString()
                            Label6.Text = reader("cmaterialfees").ToString()
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"An error occurred while fetching course fees: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' Hide Form5 and show the home form
        Me.Hide()
        home.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ' Hide Form5 and show Form4
        Me.Hide()
        Form4.Show()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        ' Push changes to the feea table
        SaveToFeaa()
        MessageBox.Show("Data addded Succesfully")

        ' Hide Form5 and show Form6
        Me.Hide()
        Form6.Show()
    End Sub

    Private Sub SaveToFeaa()
        If ComboBox1.SelectedItem IsNot Nothing Then
            Dim connectionString As String = "server=localhost;user=root;password=admin;database=tms;"
            Dim query As String = "INSERT INTO feea (cid, ctutionfees, cmaterialfees) VALUES (@cid, @ctutionfees, @cmaterialfees)"

            Try
                Using connection As New MySqlConnection(connectionString)
                    Using command As New MySqlCommand(query, connection)
                        command.Parameters.AddWithValue("@cid", ComboBox1.SelectedItem)
                        command.Parameters.AddWithValue("@ctutionfees", Label5.Text.Replace("Tuition Fees: $", ""))
                        command.Parameters.AddWithValue("@cmaterialfees", Label6.Text.Replace("Material Fees: $", ""))

                        connection.Open()
                        command.ExecuteNonQuery()
                    End Using
                End Using
            Catch ex As Exception
                MessageBox.Show($"An error occurred while saving to feea table: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Else
            MessageBox.Show("Please select a course.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
End Class
