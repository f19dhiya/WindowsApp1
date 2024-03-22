Imports System.Runtime.Remoting.Messaging

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
        Dim studentId As String = TextBox1.Text
        If String.IsNullOrEmpty(studentId) Then
            MessageBox.Show("Please enter a student ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBox1.Focus()
            Return
        ElseIf studentId.Length <> 5 Then
            MessageBox.Show("Invalid student ID length. Please enter exactly 5 characters.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBox1.Focus()
            Return
        ElseIf Not System.Text.RegularExpressions.Regex.IsMatch(studentId, "^[S]\d{4}$") Then
            MessageBox.Show("Invalid student ID format. Please enter a student ID starting with 'S' followed by 4 digits.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBox1.Focus()
            Return
        End If



        If String.IsNullOrEmpty(TextBox2.Text) Then
            MessageBox.Show("please enter a first name.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBox2.Focus()
            Return
        ElseIf IsNumeric(TextBox2.Text) Then
            MessageBox.Show("please enter valid first name.,", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBox2.Focus()
            Return
        ElseIf system.Text.RegularExpressions.Regex.IsMatch(TextBox2.Text, "[\d\w]") Then
            MessageBox.Show("first name cannot digits or special characters.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBox2.Focus()
            Return
        ElseIf Not System.Text.RegularExpressions.Regex.IsMatch(TextBox2.Text, "^[a-zA-Z]+&") Then
            MessageBox.Show("first name cannotcontain alphanumeric characters.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
        ElseIf System.Text.RegularExpressions.Regex.IsMatch(TextBox3.Text, "[\d\W]") Then
            MessageBox.Show("Last name cannot contain digits or special characters.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBox3.Focus()
            Return
        ElseIf Not System.Text.RegularExpressions.Regex.IsMatch(TextBox3.Text, "^[a-zA-Z]+$") Then
            MessageBox.Show("Last name cannot contain alphanumeric characters.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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


        If Not String.IsNullOrWhiteSpace(TextBox4.Text) AndAlso Not System.Text.RegularExpressions.Regex.IsMatch(TextBox4.Text, "[^a-zA-Z0-9._%+-]+@gmail.com") Then
            MessageBox.Show("Please enter a valid email address.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBox4.Focus()
            Return
        End If


        If String.IsNullOrEmpty(TextBox5.Text) Then
            MessageBox.Show("Please enter father's name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBox5.Focus()
            Return
        ElseIf System.Text.RegularExpressions.Regex.IsMatch(TextBox4.Text, "[\d\W]") Then
            MessageBox.Show("father's name cannot contain digits or special characters.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBox5.Focus()
            Return
        ElseIf Not System.Text.RegularExpressions.Regex.IsMatch(TextBox5.Text, "^[a-zA-Z]+$") Then
            MessageBox.Show("father's name cannot contain alphanumeric characters.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBox5.Focus()
            Return
        End If


        If String.IsNullOrEmpty(TextBox6.Text) Then
            MessageBox.Show("Please enter the occupation.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBox6.Focus()
            Return
        ElseIf System.Text.RegularExpressions.Regex.IsMatch(TextBox6.Text, "[\d\W]") Then
            MessageBox.Show("occupation cannot contain digits or special characters.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBox6.Focus()
            Return
        ElseIf Not System.Text.RegularExpressions.Regex.IsMatch(TextBox6.Text, "^[a-zA-Z]+$") Then
            MessageBox.Show("occuption cannot contain alphanumeric characters.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBox6.Focus()
            Return
        End If


        If String.IsNullOrWhiteSpace(TextBox7.Text) Then
            MessageBox.Show("Please enter the city.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBox7.Focus()
            Return
        ElseIf System.Text.RegularExpressions.Regex.IsMatch(TextBox7.Text, "[\d\W]") Then
            MessageBox.Show("City cannot cain digits or special characters.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBox7.Focus()
            Return
        ElseIf Not System.Text.RegularExpressions.Regex.IsMatch(TextBox7.Text, "^[a-zA-Z]+$") Then
            MessageBox.Show("City cannot contain alphanumeric characters.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
            Return
        ElseIf System.Text.RegularExpressions.Regex.IsMatch(TextBox8.Text, "^[1-9][0-9]{5}$") Then
            MessageBox.Show("invalid pincode.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBox8.Focus()
            Return
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
    End Sub


End Class