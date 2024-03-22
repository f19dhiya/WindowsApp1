Imports System.Runtime.Remoting.Services
Imports System.Text.RegularExpressions
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class Form2
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        home.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim courseId As String = TextBox1.Text.Trim()
        If String.IsNullOrEmpty(courseId) Then
            MessageBox.Show("Please enter a course ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)


        ElseIf Not System.Text.RegularExpressions.Regex.IsMatch(courseId, "^C[1-9]\d{0,4}$") Then
            MessageBox.Show("Invalid course ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End If



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
        Me.Hide()
        Form3.Show()

    End Sub


End Class
