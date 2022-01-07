Imports System.Data.Odbc
Public Class GURU

    Private Sub GURU_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call KONDISIAWAL()
        TextBox4.Text = Today
    End Sub
    Sub KONDISIAWAL()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox5.Clear()
        TextBox6.Clear()
        TextBox7.Clear()
        TextBox2.Focus()
        Call AUTOIDGURU()
        Call MUNCULDATAGURU()
    End Sub
    Sub AUTOIDGURU()
        Call Koneksi()
        cmd = New OdbcCommand("select * from GURU order by idGURU desc", conn)
        rd = cmd.ExecuteReader
        rd.Read()
        If Not rd.HasRows Then
            TextBox1.Text = "PG" + "001"
        Else
            TextBox1.Text = Val(Microsoft.VisualBasic.Mid(rd.Item("idGURU").ToString, 4, 3)) + 1
            If Len(TextBox1.Text) = 1 Then
                TextBox1.Text = "PGS00" & TextBox1.Text & ""
            ElseIf Len(TextBox1.Text) = 2 Then
                TextBox1.Text = "PG0" & TextBox1.Text & ""
            ElseIf Len(TextBox1.Text) = 3 Then
                TextBox1.Text = "PG" & TextBox1.Text & ""
            End If
        End If
    End Sub
    Sub MUNCULDATAGURU()
        Call Koneksi()
        da = New OdbcDataAdapter("select * from GURU", conn)
        ds = New DataSet
        da.Fill(ds)
        DataGridView1.DataSource = ds.Tables(0)
        DataGridView1.Columns(0).HeaderText = "ID GURU"
        DataGridView1.Columns(1).HeaderText = "NAMA"
        DataGridView1.Columns(2).HeaderText = "NIP"
        DataGridView1.Columns(3).HeaderText = "TGLAJAR"
        DataGridView1.Columns(4).HeaderText = "ALAMAT"
        DataGridView1.Columns(5).HeaderText = "NIK"
        DataGridView1.Columns(6).HeaderText = "KETGURU"
        DataGridView1.RowsDefaultCellStyle.BackColor = Color.LightBlue
        DataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke
        DataGridView1.Columns(1).Width = 250
        DataGridView1.Columns(4).Width = 350
        DataGridView1.Columns(6).Width = 350
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Or TextBox5.Text = "" Or TextBox6.Text = "" Or TextBox7.Text = "" Then
            MessageBox.Show("Data Belum Lengkap", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        Call Koneksi()
        cmd = New OdbcCommand("select idGURU from GURU where idGURU='" & TextBox1.Text & "'", conn)
        rd = cmd.ExecuteReader
        rd.Read()
        If rd.HasRows Then
            Dim EditData As String = "Update GURU set NAMA='" & TextBox2.Text & "',NIP='" & TextBox3.Text & "',ALAMAT='" & TextBox5.Text & "',NIK='" & TextBox6.Text & "',KETGURU='" & TextBox7.Text & "' where idGURU='" & TextBox1.Text & "'"
            cmd = New OdbcCommand(EditData, conn)
            cmd.ExecuteNonQuery()
            Call KONDISIAWAL()
            Exit Sub
        ElseIf Not rd.HasRows Then
            Call Koneksi()
            Dim InputData As String = "Insert into GURU values('" & TextBox1.Text & "','" & TextBox2.Text & "','" & TextBox3.Text & "','" & Format(Now, "yyyy-MM-dd") & "','" & TextBox5.Text & "','" & TextBox6.Text & "','" & TextBox7.Text & "')"
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
        TextBox5.Text = DataGridView1.Rows(e.RowIndex).Cells(4).Value
        TextBox6.Text = DataGridView1.Rows(e.RowIndex).Cells(5).Value
        TextBox7.Text = DataGridView1.Rows(e.RowIndex).Cells(6).Value
    End Sub

    Private Sub TextBox8_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox8.TextChanged
        Call Koneksi()
        da = New OdbcDataAdapter("select * from GURU where NAMA like'%" & TextBox8.Text & "%'", conn)
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
            Dim HapusData As String = "delete from GURU where IDGURU='" & TextBox1.Text & "'"
            cmd = New OdbcCommand(HapusData, conn)
            cmd.ExecuteNonQuery()
            MessageBox.Show("Data Berhasil Hapus", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Call KONDISIAWAL()
        End If
    End Sub
End Class