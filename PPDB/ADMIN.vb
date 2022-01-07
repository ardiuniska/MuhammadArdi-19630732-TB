Imports System.Data.Odbc
Public Class ADMIN

    Private Sub ADMIN_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call kondisiawal()
    End Sub
    Sub kondisiawal()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox5.Clear()
        TextBox2.Focus()
        Call nootomatis()
    End Sub
    Sub nootomatis()
        Call Koneksi()
        cmd = New OdbcCommand("select * from admin order by idadmin desc", conn)
        rd = cmd.ExecuteReader
        rd.Read()
        If Not rd.HasRows Then
            TextBox1.Text = "1" + "001"
        Else
            TextBox1.Text = Val(Microsoft.VisualBasic.Mid(rd.Item("idadmin").ToString, 4, 3)) + 1
            If Len(TextBox1.Text) = 1 Then
                TextBox1.Text = "100" & TextBox1.Text & ""
            ElseIf Len(TextBox1.Text) = 2 Then
                TextBox1.Text = "10" & TextBox1.Text & ""
            ElseIf Len(TextBox1.Text) = 3 Then
                TextBox1.Text = "1" & TextBox1.Text & ""
            End If
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Then
            MessageBox.Show("Data Belum Lengkap", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        Call Koneksi()
        cmd = New OdbcCommand("select idadmin from admin where idadmin='" & TextBox1.Text & "'", conn)
        rd = cmd.ExecuteReader
        rd.Read()
        If rd.HasRows Then
            Dim EditData As String = "Update admin set nama='" & TextBox2.Text & "',password='" & TextBox3.Text & "',status='" & TextBox4.Text & "' where idadmin='" & TextBox1.Text & "'"
            cmd = New OdbcCommand(EditData, conn)
            cmd.ExecuteNonQuery()
            Call kondisiawal()
            Exit Sub
        ElseIf Not rd.HasRows Then
            Call Koneksi()
            Dim InputData As String = "Insert into admin values('" & TextBox1.Text & "','" & TextBox2.Text & "','" & TextBox3.Text & "','" & TextBox4.Text & "')"
            cmd = New OdbcCommand(InputData, conn)
            cmd.ExecuteNonQuery()
            MessageBox.Show("Data Berhasil Input", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Call kondisiawal()
        End If
    End Sub

    Private Sub TextBox5_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox5.KeyPress
        If e.KeyChar = Chr(13) Then
            Call Koneksi()
            Dim cariData As String = "select * from admin where idadmin='" & TextBox5.Text & "'"
            cmd = New OdbcCommand(cariData, conn)
            rd = cmd.ExecuteReader
            rd.Read()
            If rd.HasRows Then
                TextBox1.Text = rd.Item("idadmin")
                TextBox2.Text = rd.Item("nama")
                TextBox3.Text = rd.Item("password")
                TextBox4.Text = rd.Item("status")
            ElseIf Not rd.HasRows Then
                MessageBox.Show("Id admin Tidak Terdaftar", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                TextBox5.Clear()
                TextBox5.Focus()
            End If
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            TextBox3.PasswordChar = ""
        Else
            TextBox3.PasswordChar = "X"
        End If
    End Sub
End Class