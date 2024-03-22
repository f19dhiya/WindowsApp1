Public Class login

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        TextBox1.Clear()
        MaskedTextBox1.Clear()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text = "Admin" And MaskedTextBox1.Text = "123" Then
            MessageBox.Show("USERNAME IS AUTHENTICATED")
            home.Show()
        Else
            MessageBox.Show("RECHECK YOUR USERNAME OR PASSWORD")
        End If
    End Sub
End Class