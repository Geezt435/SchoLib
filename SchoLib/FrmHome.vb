Public Class FrmHome

    Private Sub FrmHome_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        FrmLogin.Visible = True
    End Sub
End Class