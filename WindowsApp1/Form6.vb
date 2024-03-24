Imports MySql.Data.MySqlClient

Public Class Form6
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ' Hide Form6 and show the home form
        Me.Hide()
        home.Show()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' Hide Form6 and show Form5
        Me.Hide()
        Form5.Show()
    End Sub

    Private Sub Form6_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Load ComboBox1 with stuid values
        LoadStuidComboBox()

        ' Load ComboBox2 with eid values
        LoadEidComboBox()
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

    Private Sub LoadEidComboBox()
        Dim connectionString As String = "server=localhost;user=root;password=admin;database=tms;"
        Dim query As String = "SELECT eid FROM enrollment"

        Try
            Using connection As New MySqlConnection(connectionString)
                Using command As New MySqlCommand(query, connection)
                    connection.Open()
                    Using reader As MySqlDataReader = command.ExecuteReader()
                        While reader.Read()
                            ComboBox2.Items.Add(reader("eid").ToString())
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"An error occurred while loading eid values: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        ' Calculate and display total amount for the selected eid in TextBox4
        Dim connectionString As String = "server=localhost;user=root;password=admin;database=tms;"
        Dim query As String = "SELECT SUM(ctutionfees + cmaterialfees) AS totalAmount FROM feea WHERE cid IN (SELECT cid FROM enrollment WHERE eid = @eid)"

        Try
            Using connection As New MySqlConnection(connectionString)
                Using command As New MySqlCommand(query, connection)
                    command.Parameters.AddWithValue("@eid", ComboBox2.SelectedItem)

                    connection.Open()
                    Dim totalAmount As Object = command.ExecuteScalar()
                    If totalAmount IsNot Nothing AndAlso Not DBNull.Value.Equals(totalAmount) Then
                        TextBox4.Text = Convert.ToDecimal(totalAmount).ToString("0.00")
                    Else
                        TextBox4.Text = "0.00"
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"An error occurred while calculating total amount: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class
