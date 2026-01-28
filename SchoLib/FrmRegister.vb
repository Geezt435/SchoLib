Imports System.Data.SqlClient
Public Class FrmRegister
    Dim cn As New SqlConnection
    Dim cmd As New SqlCommand

    Sub Daftar()
        Dim dupeCheck As String = ""
        Using cnObj As New SqlClient.SqlConnection("Data Source=.\SQLEXPRESS;Initial Catalog=db_indomenu;Integrated Security=True")
            Using cmdObj As New SqlClient.SqlCommand("SELECT username FROM tb_users WHERE username = '" & txtusername.Text & "'", cnObj)
                cnObj.Open()
                Using readerObj As SqlClient.SqlDataReader = cmdObj.ExecuteReader
                    While readerObj.Read
                        dupeCheck = readerObj("username").ToString
                    End While
                End Using
                cnObj.Close()
            End Using
        End Using

        If dupeCheck.Contains(txtusername.Text) Then
            MsgBox("Username tidak boleh duplikat!", MsgBoxStyle.Exclamation, "Registration")
        ElseIf txtusername.TextLength < 3 Then
            MsgBox("Panjang Username tidak boleh dibawah 3!", MsgBoxStyle.Exclamation, "Registration")
        ElseIf txtpass.TextLength < 8 Then
            MsgBox("Panjang Password tidak boleh dibawah 8!", MsgBoxStyle.Exclamation, "Registration")
        ElseIf txttelp.TextLength < 7 Then
            MsgBox("Panjang Nomor Telepon tidak boleh dibawah 7!", MsgBoxStyle.Exclamation, "Registration")
        ElseIf txtusername.Text = "" Then
            MsgBox("Username tidak boleh dikosongkan!", MsgBoxStyle.Exclamation, "Registration")
        ElseIf txtpass.Text = "" Then
            MsgBox("Password tidak boleh dikosongkan!", MsgBoxStyle.Exclamation, "Registration")
        ElseIf txttelp.Text = "" Then
            MsgBox("Nomor Telepon tidak boleh dikosongkan!", MsgBoxStyle.Exclamation, "Registration")
        ElseIf txtpass.Text <> "" And txtusername.Text <> "" Then
            cn.Open()
            cmd.Connection = cn
            cmd.CommandText = "INSERT INTO tb_users VALUES ('" & txtusername.Text &
                "','" & txtpass.Text & "', 'membr', " & txttelp.Text & ")"
            cmd.ExecuteNonQuery()
            cn.Close()
            MsgBox("Berhasil mendaftarkan akun!", MsgBoxStyle.Information)
            FrmLogin.Visible = True
            Me.Visible = False
            bersih()
        End If
    End Sub

    Sub bersih()
        txtusername.Text = ""
        txtpass.Text = ""
        txttelp.Text = ""
    End Sub

    Private Sub FrmRegister_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        FrmLogin.Visible = True
    End Sub

    Private Sub FrmRegister_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cn.ConnectionString = "Data Source=.\SQLEXPRESS;Initial Catalog=db_indomenu;Integrated Security=True"
        txtusername.MaxLength = 30
        txtpass.MaxLength = 50
        txttelp.MaxLength = 20
        txtusername.Select()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        FrmLogin.Visible = True
        bersih()
        txtpass.Select()
        Me.Visible = False
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Daftar()
    End Sub

    Private Sub txtusername_KeyDown(sender As Object, e As KeyEventArgs) Handles txtusername.KeyDown
        If (e.KeyValue = 13) Then
            txtpass.Select()
        End If
    End Sub

    Private Sub txtpass_KeyDown(sender As Object, e As KeyEventArgs) Handles txtpass.KeyDown
        If (e.KeyValue = 13) Then
            txttelp.Select()
        End If
    End Sub

    Private Sub txttelp_KeyDown(sender As Object, e As KeyEventArgs) Handles txttelp.KeyDown
        If (e.KeyValue = 13) Then
            Daftar()
        End If
    End Sub
End Class