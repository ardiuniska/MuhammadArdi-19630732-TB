Imports System.Data.Odbc
Public Class JURUSAN

    Private Sub JURUSAN_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call KONDISIAWAL()
        TextBox3.Text = Today
        TextBox4.Text = UTAMA.ToolStripStatusLabel1.Text
    End Sub
    Sub KONDISIAWAL()
        TextBox2.Clear()
        TextBox5.Clear()
        TextBox2.Focus()
        Call AUTOIDJURUSAN()
        Call MUNCULDATAJURUSAN()
    End Sub
    Sub AUTOIDJURUSAN()
        Call Koneksi()
        cmd = New OdbcCommand("select * from JURUSAN order by idJURUSAN desc", conn)
        rd = cmd.ExecuteReader
        rd.Read()
        If Not rd.HasRows Then
            TextBox1.Text = "JS" + "001"
        Else
            TextBox1.Text = Val(Microsoft.VisualBasic.Mid(rd.Item("idJURUSAN").ToString, 4, 3)) + 1
            If Len(TextBox1.Text) = 1 Then
                TextBox1.Text = "JS00" & TextBox1.Text & ""
            ElseIf Len(TextBox1.Text) = 2 Then
                TextBox1.Text = "JS0" & TextBox1.Text & ""
            ElseIf Len(TextBox1.Text) = 3 Then
                TextBox1.Text = "JS" & TextBox1.Text & ""
            End If
        End If
    End Sub
    Sub MUNCULDATAJURUSAN()
        Call Koneksi()
        da = New OdbcDataAdapter("select * from JURUSAN", conn)
        ds = New DataSet
        da.Fill(ds)
        DataGridView1.DataSource = ds.Tables(0)
        DataGridView1.Columns(0).HeaderText = "ID JURUSAN"
        DataGridView1.Columns(1).HeaderText = "NAMA"
        DataGridView1.Columns(2).HeaderText = "TGLBUAT"
        DataGridView1.Columns(3).HeaderText = "USER_INPUT"
        DataGridView1.RowsDefaultCellStyle.BackColor = Color.LightBlue
        DataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke
        DataGridView1.Columns(3).Width = 550
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Then
            MessageBox.Show("Data Belum Lengkap", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        Call Koneksi()
        cmd = New OdbcCommand("select idJURUSAN from JURUSAN where idJURUSAN='" & TextBox1.Text & "'", conn)
        rd = cmd.ExecuteReader
        rd.Read()
        If rd.HasRows Then
            Dim EditData As String = "Update JURUSAN set NAMA='" & TextBox2.Text & "' where idJURUSAN='" & TextBox1.Text & "'"
            cmd = New OdbcCommand(EditData, conn)
            cmd.ExecuteNonQuery()
            Call KONDISIAWAL()
            Exit Sub
        ElseIf Not rd.HasRows Then
            Call Koneksi()
            Dim InputData As String = "Insert into JURUSAN values('" & TextBox1.Text & "','" & TextBox2.Text & "','" & Format(Now, "yyyy-MM-dd") & "','" & TextBox4.Text & "')"
            cmd = New OdbcCommand(InputData, conn)
            cmd.ExecuteNonQuery()
            MessageBox.Show("Data Berhasil Input", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Call KONDISIAWAL()
        End If
    End Sub

    Private Sub DataGridView1_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseClick
        TextBox1.Text = DataGridView1.Rows(e.RowIndex).Cells(0).Value
        TextBox2.Text = DataGridView1.Rows(e.RowIndex).Cells(1).Value
        TextBox3.Text = DataGridView1.Rows(e.RowIndex).Cells(2).Value
        TextBox4.Text = DataGridView1.Rows(e.RowIndex).Cells(3).Value
    End Sub

    Private Sub TextBox5_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox5.TextChanged
        Call Koneksi()
        da = New OdbcDataAdapter("select * from JURUSAN where NAMA like'%" & TextBox5.Text & "%'", conn)
        ds = New DataSet
        da.Fill(ds)
        DataGridView1.DataSource = ds.Tables(0)
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If TextBox2.Text = "" Then
            MessageBox.Show("Tidak Ada Data Yang Dipilih Untuk Di Hapus", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        If MessageBox.Show("Yakin Ingin Hapus Data", "Warning", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            Call Koneksi()
            Dim HapusData As String = "delete from JURUSAN where IDJURUSAN='" & TextBox1.Text & "'"
            cmd = New OdbcCommand(HapusData, conn)
            cmd.ExecuteNonQuery()
            MessageBox.Show("Data Berhasil Hapus", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Call KONDISIAWAL()
        End If
    End Sub
End Class