Imports System.Data.Odbc
Public Class KELAS
    Private Sub KELAS_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call KONDISIAWAL()
    End Sub
    Sub KONDISIAWAL()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox5.Clear()
        TextBox2.Focus()
        Call AUTOIDKELAS()
        Call MUNCULDATAKELAS()
    End Sub
    Sub AUTOIDKELAS()
        Call Koneksi()
        cmd = New OdbcCommand("select * from kelas order by idkelas desc", conn)
        rd = cmd.ExecuteReader
        rd.Read()
        If Not rd.HasRows Then
            TextBox1.Text = "KLS" + "001"
        Else
            TextBox1.Text = Val(Microsoft.VisualBasic.Mid(rd.Item("idkelas").ToString, 4, 3)) + 1
            If Len(TextBox1.Text) = 1 Then
                TextBox1.Text = "KLS00" & TextBox1.Text & ""
            ElseIf Len(TextBox1.Text) = 2 Then
                TextBox1.Text = "KLS0" & TextBox1.Text & ""
            ElseIf Len(TextBox1.Text) = 3 Then
                TextBox1.Text = "KLS" & TextBox1.Text & ""
            End If
        End If
    End Sub
    Sub MUNCULDATAKELAS()
        Call Koneksi()
        da = New OdbcDataAdapter("select * from kelas", conn)
        ds = New DataSet
        da.Fill(ds)
        DataGridView1.DataSource = ds.Tables(0)
        DataGridView1.Columns(0).HeaderText = "ID KELAS"
        DataGridView1.Columns(1).HeaderText = "NO KELAS"
        DataGridView1.Columns(2).HeaderText = "KAPASITAS"
        DataGridView1.Columns(3).HeaderText = "KETERANGAN"
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
        cmd = New OdbcCommand("select idkelas from kelas where idkelas='" & TextBox1.Text & "'", conn)
        rd = cmd.ExecuteReader
        rd.Read()
        If rd.HasRows Then
            Dim EditData As String = "Update kelas set nokelas='" & TextBox2.Text & "',kapasitas='" & TextBox3.Text & "',Keterangan='" & TextBox4.Text & "' where idkelas='" & TextBox1.Text & "'"
            cmd = New OdbcCommand(EditData, conn)
            cmd.ExecuteNonQuery()
            Call KONDISIAWAL()
            Exit Sub
        ElseIf Not rd.HasRows Then
            Call Koneksi()
            Dim InputData As String = "Insert into kelas values('" & TextBox1.Text & "','" & TextBox2.Text & "','" & TextBox3.Text & "','" & TextBox4.Text & "')"
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
        da = New OdbcDataAdapter("select * from kelas where idkelas like'%" & TextBox5.Text & "%'", conn)
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
            Dim HapusData As String = "delete from KELAS where IDKELAS='" & TextBox1.Text & "'"
            cmd = New OdbcCommand(HapusData, conn)
            cmd.ExecuteNonQuery()
            MessageBox.Show("Data Berhasil Hapus", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Call KONDISIAWAL()
        End If
    End Sub
End Class