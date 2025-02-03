Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub button_almacen_Click(sender As Object, e As EventArgs) Handles button_almacen.Click
        Form2.Show()
        Me.Hide()
    End Sub

    Private Sub Button_exit_Click(sender As Object, e As EventArgs) Handles Button_exit.Click
        Close()
    End Sub

    Private Sub button_caja_Click(sender As Object, e As EventArgs) Handles button_caja.Click
        FormCaja.Show()
        Me.Hide()
    End Sub
End Class
