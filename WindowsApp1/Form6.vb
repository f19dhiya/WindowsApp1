Imports MySql.Data.MySqlClient

Public Class Form6
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
        ' Calculate and display amount in TextBox4 based on selected eid
        Dim connectionString As String = "server=localhost;user=root;password=admin;database=tms;"
        Dim query As String = "SELECT cid FROM enrollment WHERE eid = @eid"

        Try
            Using connection As New MySqlConnection(connectionString)
                Using command As New MySqlCommand(query, connection)
                    command.Parameters.AddWithValue("@eid", ComboBox2.SelectedItem)

                    connection.Open()
                    Dim cid As Integer = Convert.ToInt32(command.ExecuteScalar())

                    ' Calculate amount based on ctutionfees and cmaterialfees from feea table
                    Dim amount As Decimal = GetCourseAmount(cid)

                    TextBox4.Text = amount.ToString()
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"An error occurred while calculating amount: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function GetCourseAmount(ByVal cid As Integer) As Decimal
        Dim connectionString As String = "server=localhost;user=root;password=admin;database=tms;"
        Dim query As String = "SELECT SUM(ctutionfees + cmaterialfees) AS totalAmount FROM feea WHERE cid = @cid"

        Try
            Using connection As New MySqlConnection(connectionString)
                Using command As New MySqlCommand(query, connection)
                    command.Parameters.AddWithValue("@cid", cid)

                    connection.Open()
                    Dim result As Object = command.ExecuteScalar()

                    If result IsNot Nothing AndAlso Not DBNull.Value.Equals(result) Then
                        Return Convert.ToDecimal(result)
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"An error occurred while fetching course amount: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return 0
    End Function

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

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        ' Commit the changes to the payment table
        SaveToPayment()
    End Sub

    Private Sub SaveToPayment()
        Dim connectionString As String = "server=localhost;user=root;password=admin;database=tms;"
        Dim query As String = "INSERT INTO payment (stuid, eid, pdate, amount, pmethord) VALUES (@stuid, @eid, @pdate, @amount, @pmethord)"

        Try
            Using connection As New MySqlConnection(connectionString)
                Using command As New MySqlCommand(query, connection)
                    command.Parameters.AddWithValue("@stuid", ComboBox1.SelectedItem)
                    command.Parameters.AddWithValue("@eid", ComboBox2.SelectedItem)
                    command.Parameters.AddWithValue("@pdate", DateTimePicker1.Value.Date)
                    command.Parameters.AddWithValue("@amount", Decimal.Parse(TextBox4.Text))
                    command.Parameters.AddWithValue("@pmethord", ComboBox3.SelectedItem)

                    connection.Open()
                    command.ExecuteNonQuery()
                    MessageBox.Show("Payment data saved successfully.")
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"An error occurred while saving payment data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class
