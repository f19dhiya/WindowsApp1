Imports System.Runtime.Remoting.Messaging
Imports MySql.Data.MySqlClient

Public Class Form3
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        home.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
        Form2.Show()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Hide()
        Form4.Show()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If String.IsNullOrEmpty(TextBox2.Text) Then
            MessageBox.Show("please enter a first name.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBox2.Focus()
            Return
        ElseIf IsNumeric(TextBox2.Text) Then
            MessageBox.Show("please enter valid first name.,", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBox2.Focus()
            Return
        End If


        If String.IsNullOrEmpty(TextBox3.Text) Then
            MessageBox.Show("Please enter a last name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBox3.Focus()
            Return
        ElseIf IsNumeric(TextBox3.Text) Then
            MessageBox.Show("Please e valid last name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBox3.Focus()
            Return
        End If



        If String.IsNullOrEmpty(ComboBox1.Text) Then
            MessageBox.Show("Please select the gender.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ComboBox1.Focus()
            Return
        End If


        If String.IsNullOrEmpty(ComboBox1.Text) Then
            MessageBox.Show("Please select the gender.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ComboBox1.Focus()
            Return
        End If


        If DateTimePicker1.Value = DateTime.Today Then
            MessageBox.Show("Please enter a valid date of birth.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            DateTimePicker1.Focus()
            Return
        End If

        If DateTimePicker1.Value > DateTime.Today Then
            MessageBox.Show("Date of birth cannot be in the future.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            DateTimePicker1.Focus()
            Return
        End If

        If (DateTime.Today - DateTimePicker1.Value).TotalDays < (19 * 365.25) Then
            MessageBox.Show("Student must be at least 19 years old to register.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            DateTimePicker1.Focus()
            Return
        End If

        If (DateTime.Today - DateTimePicker1.Value).TotalDays > (25 * 365.25) Then
            MessageBox.Show("invalid date of birth.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            DateTimePicker1.Focus()
            Return
        End If


        If String.IsNullOrEmpty(TextBox5.Text) Then
            MessageBox.Show("Please enter father's name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBox5.Focus()
            Return
        End If


        If String.IsNullOrEmpty(TextBox6.Text) Then
            MessageBox.Show("Please enter the occupation.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBox6.Focus()
            Return
        End If


        If String.IsNullOrWhiteSpace(TextBox7.Text) Then
            MessageBox.Show("Please enter the city.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBox7.Focus()
            Return
        End If

        If String.IsNullOrEmpty(ComboBox2.Text) Then
            MessageBox.Show("Please select a state.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ComboBox2.Focus()
            Return
        End If


        If String.IsNullOrWhiteSpace(TextBox8.Text) Then
            MessageBox.Show("Please enter the pincode.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBox8.Focus()
        End If


        If String.IsNullOrWhiteSpace(TextBox9.Text) Then
            MessageBox.Show("Please enter the phone number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBox9.Focus()
            Return
        ElseIf TextBox5.Text.Length > 13 AndAlso IsNumeric(TextBox9.Text) Then
            MessageBox.Show("Please enter a valid phone number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBox9.Focus()
            Return

        End If
        SaveToDatabase()

    End Sub
    Private Sub SaveToDatabase()
        Dim connectionString As String = "server=localhost;user=root;password=admin;database=tms;"

        Try
            Using connection As New MySqlConnection(connectionString)
                Dim query As String = "INSERT INTO student (stufname, stulname, stugender, studob, stuemail, stuphoneno, stufathername, stuoccupation, stucity, stustate, stuposcode) VALUES (@stufname, @stulname, @stugender, @studob, @stuemail, @stuphoneno, @stufathername, @stuoccupation, @stucity, @stustate, @stuposcode)"

                Using command As New MySqlCommand(query, connection)
                    ' Add parameters with values from form controls
                    command.Parameters.AddWithValue("@stufname", TextBox2.Text)
                    command.Parameters.AddWithValue("@stulname", TextBox3.Text)
                    command.Parameters.AddWithValue("@stugender", ComboBox1.Text)
                    command.Parameters.AddWithValue("@studob", DateTimePicker1.Value.Date)
                    command.Parameters.AddWithValue("@stuemail", TextBox4.Text)
                    command.Parameters.AddWithValue("@stuphoneno", TextBox9.Text)
                    command.Parameters.AddWithValue("@stufathername", TextBox5.Text)
                    command.Parameters.AddWithValue("@stuoccupation", TextBox6.Text)
                    command.Parameters.AddWithValue("@stucity", TextBox7.Text)
                    command.Parameters.AddWithValue("@stustate", ComboBox2.Text)
                    command.Parameters.AddWithValue("@stuposcode", TextBox8.Text)

                    connection.Open()
                    command.ExecuteNonQuery()
                    MessageBox.Show("Student data saved successfully.")
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
   
End Class