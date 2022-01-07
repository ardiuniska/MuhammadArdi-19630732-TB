Imports System.Data.Odbc
Public Class FASILITAS

    Private Sub FASILITAS_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call KONDISIAWAL()
        TextBox3.Text = Today
        Label15.Text = UTAMA.ToolStripStatusLabel1.Text
    End Sub
    Sub KONDISIAWAL()
        TextBox2.Clear()
        TextBox4.Clear()
        TextBox5.Clear()
        TextBox7.Clear()
        TextBox8.Clear()
        TextBox6.Clear()
        TextBox2.Focus()
        Call AUTOIDFASILITAS()
        Call MUNCULDATAFASILITAS()
    End Sub
    Sub AUTOIDFASILITAS()
        Call Koneksi()
        cmd = New OdbcCommand("select * from FASILITAS order by idFASILITAS desc", conn)
        rd = cmd.ExecuteReader
        rd.Read()
        If Not rd.HasRows Then
            TextBox1.Text = "FS" + "001"
        Else
            TextBox1.Text = Val(Microsoft.VisualBasic.Mid(rd.Item("idFASILITAS").ToString, 4, 3)) + 1
            If Len(TextBox1.Text) = 1 Then
                TextBox1.Text = "FS00" & TextBox1.Text & ""
            ElseIf Len(TextBox1.Text) = 2 Then
                TextBox1.Text = "FS0" & TextBox1.Text & ""
            ElseIf Len(TextBox1.Text) = 3 Then
                TextBox1.Text = "FS" & TextBox1.Text & ""
            End If
        End If
    End Sub
    Sub MUNCULDATAFASILITAS()
        Call Koneksi()
        da = New OdbcDataAdapter("select * from FASILITAS", conn)
        ds = New DataSet
        da.Fill(ds)
        DataGridView1.DataSource = ds.Tables(0)
        DataGridView1.Columns(0).HeaderText = "ID FASILITAS"
        DataGridView1.Columns(1).HeaderText = "NAMA"
        DataGridView1.Columns(2).HeaderText = "TGLINPUT"
        DataGridView1.Columns(3).HeaderText = "TGLBELI"
        DataGridView1.Columns(4).HeaderText = "JUMLAH"
        DataGridView1.Columns(5).HeaderText = "HBELI"
        DataGridView1.Columns(6).HeaderText = "UNTUK"
        DataGridView1.Columns(7).HeaderText = "KETERANGAN"
        DataGridView1.Columns(8).HeaderText = "USER_INPUT"
        DataGridView1.RowsDefaultCellStyle.BackColor = Color.LightBlue
        DataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke
        DataGridView1.Columns(1).Width = 250
        DataGridView1.Columns(7).Width = 350
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Or TextBox5.Text = "" Or TextBox7.Text = "" Or TextBox6.Text = "" Or Label15.Text = "" Then
            MessageBox.Show("Data Belum Lengkap", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        Call Koneksi()
        cmd = New OdbcCommand("select idFASILITAS from FASILITAS where idFASILITAS='" & TextBox1.Text & "'", conn)
        rd = cmd.ExecuteReader
        rd.Read()
        If rd.HasRows Then
            Dim EditData As String = "Update FASILITAS set NAMA='" & TextBox2.Text & "',TGLBELI='" & TextBox4.Text & "',JUMLAH='" & TextBox5.Text & "',HBELI='" & TextBox6.Text & "',UNTUK='" & TextBox7.Text & "',KETERANGAN='" & TextBox8.Text & "' where idFASILITAS='" & TextBox1.Text & "'"
            cmd = New OdbcCommand(EditData, conn)
            cmd.ExecuteNonQuery()
            Call KONDISIAWAL()
            Exit Sub
        ElseIf Not rd.HasRows Then
            Call Koneksi()
            Dim InputData As String = "Insert into FASILITAS values('" & TextBox1.Text & "','" & TextBox2.Text & "','" & Format(Now, "yyyy-MM-dd") & "','" & TextBox4.Text & "','" & TextBox5.Text & "','" & TextBox6.Text & "','" & TextBox7.Text & "','" & TextBox8.Text & "','" & Label15.Text & "')"
            cmd = New OdbcCommand(InputData, conn)
            cmd.ExecuteNonQuery()
            MessageBox.Show("Data Berhasil Input", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Call KONDISIAWAL()
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If TextBox2.Text = "" Then
            MessageBox.Show("Tidak Ada Data Yang Dipilih Untuk Di Hapus", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        If MessageBox.Show("Yakin Ingin Hapus Data", "Warning", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            Call Koneksi()
            Dim HapusData As String = "delete from FASILITAS where IDFASILITAS='" & TextBox1.Text & "'"
            cmd = New OdbcCommand(HapusData, conn)
            cmd.ExecuteNonQuery()
            MessageBox.Show("Data Berhasil Hapus", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Call KONDISIAWAL()
        End If
    End Sub

    Private Sub TextBox9_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox9.TextChanged
        Call Koneksi()
        da = New OdbcDataAdapter("select * from fasilitas where NAMA like'%" & TextBox9.Text & "%'", conn)
        ds = New DataSet
        da.Fill(ds)
        DataGridView1.DataSource = ds.Tables(0)
    End Sub

    Private Sub DataGridView1_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseClick
        TextBox1.Text = DataGridView1.Rows(e.RowIndex).Cells(0).Value
        TextBox2.Text = DataGridView1.Rows(e.RowIndex).Cells(1).Value
        TextBox3.Text = DataGridView1.Rows(e.RowIndex).Cells(2).Value
        TextBox4.Text = DataGridView1.Rows(e.RowIndex).Cells(3).Value
        TextBox5.Text = DataGridView1.Rows(e.RowIndex).Cells(4).Value
        TextBox6.Text = DataGridView1.Rows(e.RowIndex).Cells(5).Value
        TextBox7.Text = DataGridView1.Rows(e.RowIndex).Cells(6).Value
        TextBox8.Text = DataGridView1.Rows(e.RowIndex).Cells(7).Value
        Label15.Text = DataGridView1.Rows(e.RowIndex).Cells(8).Value
    End Sub
End Class