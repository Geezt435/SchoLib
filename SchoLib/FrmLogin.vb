Imports System.Data.SqlClient
Public Class FrmLogin
    Dim cn As New SqlConnection
    Dim cmd As New SqlCommand

    Sub ClearText()
        txtpass.Text = ""
        txtusername.Text = ""
        txtusername.Select()
    End Sub

    Sub Login()
        If txtusername.Text = "" Or txtpass.Text = "" Then
            MsgBox("Username dan Password wajib diisi!", MsgBoxStyle.Exclamation, "Login")
            ClearText()
        Else
            cn.ConnectionString = "Data Source=.\SQLEXPRESS;Initial Catalog=db_indomenu;Integrated Security=True"
            cmd.Connection = cn
            cn.Open()
            cmd.CommandText = "SELECT username, password, role FROM tb_users WHERE password='" & txtpass.Text &
                "' and username='" & txtusername.Text & "'"
            Dim rd As SqlDataReader = cmd.ExecuteReader
            rd.Read()

            ' Kenapa tidak bisa rd hak sebelumnya karena charnya 10, jadinya ada spasi, contoh "admin     " daripada "admin"
            ' Jadinya ndak kebaca, makanya diubah jadi char(5) menggantikan char(10), serta "member    " diubah menjadi "membr"
            If rd.HasRows Then
                If (rd("role") = "admin") Then
                    FrmHome.txtrole.Text = "Anda adalah Admin!"
                ElseIf (rd("role") = "owner") Then
                    FrmHome.txtrole.Text = "Anda adalah Owner!"
                ElseIf (rd("role") = "cwner") Then
                    FrmHome.txtrole.Text = "Anda adalah Co-Owner!"
                ElseIf (rd("role") = "membr") Then
                    FrmHome.txtrole.Text = "Anda adalah Member!"
                Else
                    FrmHome.txtrole.Text = ("Anda adalah " + rd("role") + "!")
                End If
                FrmHome.Show()
                Me.Visible = False
                ClearText()
            Else
                MsgBox("Username dan Password salah!", MsgBoxStyle.Critical)
                ClearText()
            End If
        End If
        cn.Close()
    End Sub

    Private Sub btnlogin_Click(sender As Object, e As EventArgs) Handles btnlogin.Click
        Login()
    End Sub

    Private Sub btndaftar_Click(sender As Object, e As EventArgs) Handles btndaftar.Click
        FrmRegister.Show()
        Me.Visible = False
        ClearText()
    End Sub

    Private Sub FrmLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtusername.MaxLength = 30
        txtpass.MaxLength = 50
    End Sub

    Private Sub txtusername_KeyDown(sender As Object, e As KeyEventArgs) Handles txtusername.KeyDown
        If (e.KeyValue = 13) Then
            txtpass.Select()
        End If
    End Sub

    Private Sub txtpass_KeyDown(sender As Object, e As KeyEventArgs) Handles txtpass.KeyDown
        If (e.KeyValue = 13) Then
            Login()
        End If
    End Sub
End Class