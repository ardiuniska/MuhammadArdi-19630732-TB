Imports System.Data.Odbc
Public Class SEKOLAH

    Private Sub SEKOLAH_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call KONDISIAWAL()
        Call TAMPILSEKOLAH()
    End Sub
    Sub KONDISIAWAL()
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox5.Clear()
    End Sub
    Sub TAMPILSEKOLAH()
        Call Koneksi()
        Dim cariData As String = "select * from SEKOLAH WHERE ID='" & Label13.Text & "'"
        cmd = New OdbcCommand(cariData, conn)
        rd = cmd.ExecuteReader
        rd.Read()
        If rd.HasRows Then
            TextBox1.Text = rd.Item("NAMASEKOLAH")
            TextBox2.Text = rd.Item("ALAMAT")
            TextBox3.Text = rd.Item("ALENGKAP")
            TextBox4.Text = rd.Item("KEPSEK")
            TextBox5.Text = rd.Item("NIP")
        End If

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Or TextBox5.Text = "" Then
            MessageBox.Show("Data Belum Lengkap", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        Call Koneksi()
        cmd = New OdbcCommand("select ID from sekolah where ID='" & Label13.Text & "'", conn)
        rd = cmd.ExecuteReader
        rd.Read()
        If rd.HasRows Then
            Dim EditData As String = "Update sekolah set namasekolah='" & TextBox1.Text & "',alamat='" & TextBox2.Text & "',alengkap='" & TextBox3.Text & "',kepsek='" & TextBox4.Text & "',nip='" & TextBox5.Text & "' where id='" & Label13.Text & "'"
            cmd = New OdbcCommand(EditData, conn)
            cmd.ExecuteNonQuery()
            MessageBox.Show("Data BerhasiL Edit", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Call KONDISIAWAL()
            Call TAMPILSEKOLAH()
            Exit Sub
        ElseIf Not rd.HasRows Then
            Call Koneksi()
            Dim InputData As String = "Insert into sekolah values('" & Label13.Text & "','" & TextBox1.Text & "','" & TextBox2.Text & "','" & TextBox3.Text & "','" & TextBox4.Text & "','" & TextBox5.Text & "')"
            cmd = New OdbcCommand(InputData, conn)
            cmd.ExecuteNonQuery()
            MessageBox.Show("Data BerhasiL Simpan", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Call KONDISIAWAL()
            Call TAMPILSEKOLAH()
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If MessageBox.Show("Yakin Ingin Hapus Data", "Warning", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            Call Koneksi()
            Dim HapusData As String = "delete from SEKOLAH where ID='" & Label13.Text & "'"
            cmd = New OdbcCommand(HapusData, conn)
            cmd.ExecuteNonQuery()
            MessageBox.Show("Data Berhasil Hapus", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Call KONDISIAWAL()
        End If
    End Sub
End Class