Imports System.Data.Odbc
Public Class PENDAFTARAN

    Private Sub PENDAFTARAN_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call KONDISIAWAL()
    End Sub
    Sub KONDISIAWAL()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox5.Clear()
        TextBox6.Clear()
        TextBox7.Clear()
        TextBox8.Clear()
        TextBox9.Clear()
        TextBox10.Clear()
        TextBox11.Clear()
        TextBox12.Clear()
        TextBox13.Clear()
        TextBox14.Clear()
        TextBox15.Clear()
        TextBox16.Clear()
        TextBox17.Clear()
        TextBox18.Clear()
        TextBox19.Clear()
        TextBox20.Clear()
        TextBox21.Clear()
        TextBox22.Clear()
        TextBox23.Clear()
        TextBox24.Clear()
        TextBox25.Clear()
        TextBox26.Clear()
        TextBox27.Clear()
        TextBox28.Clear()
        TextBox29.Clear()
        TextBox30.Clear()
        TextBox31.Clear()
        TextBox32.Clear()
        TextBox33.Clear()
        TextBox2.Focus()
        ComboBox1.Text = ""
        ComboBox2.Text = ""
        ComboBox3.Text = ""
        ComboBox4.Text = ""
        ComboBox5.Text = ""
        ComboBox6.Text = ""
        ComboBox7.Text = ""
        ComboBox8.Text = ""
        Call NDAFTAR()
    End Sub
    Sub NDAFTAR()
        Call Koneksi()
        cmd = New OdbcCommand("select * from PENDAFTARAN order by NDAFTAR desc", conn)
        rd = cmd.ExecuteReader
        rd.Read()
        If Not rd.HasRows Then
            TextBox1.Text = "1" + "001"
        Else
            TextBox1.Text = Val(Microsoft.VisualBasic.Mid(rd.Item("NDAFTAR").ToString, 4, 3)) + 1
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
        If TextBox1.Text = "" Or TextBox2.Text = "" Or ComboBox1.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Or TextBox5.Text = "" Or TextBox6.Text = "" Or ComboBox2.Text = "" Or TextBox7.Text = "" Or TextBox8.Text = "" Or TextBox9.Text = "" Or TextBox10.Text = "" Or TextBox11.Text = "" Or TextBox12.Text = "" Or TextBox13.Text = "" Or TextBox14.Text = "" Or ComboBox3.Text = "" Or ComboBox4.Text = "" Or TextBox15.Text = "" Or TextBox16.Text = "" Or TextBox17.Text = "" Or TextBox18.Text = "" Or TextBox19.Text = "" Or TextBox20.Text = "" Or TextBox21.Text = "" Or TextBox22.Text = "" Or ComboBox5.Text = "" Or TextBox23.Text = "" Or TextBox24.Text = "" Or ComboBox6.Text = "" Or TextBox25.Text = "" Or TextBox26.Text = "" Or ComboBox7.Text = "" Or TextBox27.Text = "" Or TextBox28.Text = "" Or ComboBox8.Text = "" Or TextBox29.Text = "" Or TextBox30.Text = "" Or TextBox31.Text = "" Or TextBox32.Text = "" Or TextBox33.Text = "" Then
            MessageBox.Show("Data Belum Lengkap,Semua Feilds Harus Di Isi", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        Call Koneksi()
        cmd = New OdbcCommand("select NDAFTAR from PENDAFTARAN where NDAFTAR='" & TextBox1.Text & "'", conn)
        rd = cmd.ExecuteReader
        rd.Read()
        If rd.HasRows Then
            Dim EDIT As String = "Update PENDAFTARAN set NAMA='" & TextBox2.Text & "',JK='" & ComboBox1.Text & "',NISN='" & TextBox3.Text & "',TL='" & TextBox4.Text & "',TGL='" & TextBox5.Text & "',NIK='" & TextBox6.Text & "',AGAMA='" & ComboBox2.Text & "',KKHUSUS='" & TextBox7.Text & "',ALAMAT='" & TextBox8.Text & "',RT='" & TextBox9.Text & "',RW='" & TextBox10.Text & "',DUSUN='" & TextBox11.Text & "',KELUARAHAN='" & TextBox12.Text & "', KECAMATAN='" & TextBox13.Text & "',KDPOS='" & TextBox14.Text & "',JTINGGAL='" & ComboBox3.Text & "',TRANSPORTASI='" & ComboBox4.Text & "',TELEPON='" & TextBox15.Text & "',HP='" & TextBox16.Text & "',E_MAIL='" & TextBox17.Text & "',NO_PESERTA_UN='" & TextBox18.Text & "',TKIP='" & TextBox19.Text & "',NOKIP='" & TextBox20.Text & "',AYAH='" & TextBox21.Text & "',THLAHIRA='" & TextBox22.Text & "',JPA='" & ComboBox5.Text & "',PEKERJAANA='" & TextBox23.Text & "',PENGHASILANA='" & TextBox24.Text & "',KKHUSUSA='" & ComboBox6.Text & "',IBU='" & TextBox25.Text & "',THLAHIRI='" & TextBox26.Text & "',JPI='" & ComboBox7.Text & "',PEKERJAANI='" & TextBox27.Text & "',PENGHASILANI='" & TextBox28.Text & "',KKHUSUSI='" & ComboBox8.Text & "',BB='" & TextBox29.Text & "',TB='" & TextBox30.Text & "',JRKS='" & TextBox31.Text & "', WTKS='" & TextBox32.Text & "',SAUDARA='" & TextBox33.Text & "' WHERE NDAFTAR ='" & TextBox1.Text & "'"
            cmd = New OdbcCommand(EDIT, conn)
            cmd.ExecuteNonQuery()
            MessageBox.Show("Data Berhasil Di Edit", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Call KONDISIAWAL()
            Exit Sub
        ElseIf Not rd.HasRows Then
            Call Koneksi()
            Dim InputData As String = "Insert into PENDAFTARAN values('" & TextBox1.Text & "', '" & TextBox2.Text & "', '" & ComboBox1.Text & "', '" & TextBox3.Text & "', '" & TextBox4.Text & "', '" & TextBox5.Text & "', '" & TextBox6.Text & "', '" & ComboBox2.Text & "', '" & TextBox7.Text & "', '" & TextBox8.Text & "', '" & TextBox9.Text & "', '" & TextBox10.Text & "', '" & TextBox11.Text & "', '" & TextBox12.Text & "', '" & TextBox13.Text & "', '" & TextBox14.Text & "', '" & ComboBox3.Text & "', '" & ComboBox4.Text & "', '" & TextBox15.Text & "', '" & TextBox16.Text & "', '" & TextBox17.Text & "', '" & TextBox18.Text & "', '" & TextBox19.Text & "', '" & TextBox20.Text & "', '" & TextBox21.Text & "', '" & TextBox22.Text & "', '" & ComboBox5.Text & "', '" & TextBox23.Text & "', '" & TextBox24.Text & "', '" & ComboBox6.Text & "', '" & TextBox25.Text & "', '" & TextBox26.Text & "', '" & ComboBox7.Text & "', '" & TextBox27.Text & "', '" & TextBox28.Text & "', '" & ComboBox8.Text & "', '" & TextBox29.Text & "', '" & TextBox30.Text & "', '" & TextBox31.Text & "', '" & TextBox32.Text & "', '" & TextBox33.Text & "')"
            cmd = New OdbcCommand(InputData, conn)
            cmd.ExecuteNonQuery()
            MessageBox.Show("Data Berhasil Di Input", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Call KONDISIAWAL()
        End If
    End Sub

    Private Sub TextBox34_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox34.KeyPress
        If e.KeyChar = Chr(13) Then
            On Error Resume Next
            Call Koneksi()
            Dim cariData As String = "select * from PENDAFTARAN where NISN='" & TextBox34.Text & "'"
            cmd = New OdbcCommand(cariData, conn)
            rd = cmd.ExecuteReader
            rd.Read()
            If rd.HasRows Then
                TextBox1.Text = rd.Item("NDAFTAR")
                TextBox2.Text = rd.Item("NAMA")
                ComboBox1.Text = rd.Item("JK")
                TextBox3.Text = rd.Item("NISN")
                TextBox4.Text = rd.Item("TL")
                TextBox5.Text = rd.Item("TGL")
                TextBox6.Text = rd.Item("NIK")
                ComboBox2.Text = rd.Item("AGAMA")
                TextBox7.Text = rd.Item("KKHUSUS")
                TextBox8.Text = rd.Item("ALAMAT")
                TextBox9.Text = rd.Item("RT")
                TextBox10.Text = rd.Item("RW")
                TextBox11.Text = rd.Item("DUSUN")
                TextBox12.Text = rd.Item("KELUARAHAN")
                TextBox13.Text = rd.Item("KECAMATAN")
                TextBox14.Text = rd.Item("KDPOS")
                ComboBox3.Text = rd.Item("JTINGGAL")
                ComboBox4.Text = rd.Item("TRANSPORTASI")
                TextBox15.Text = rd.Item("TELEPON")
                TextBox16.Text = rd.Item("HP")
                TextBox17.Text = rd.Item("E_MAIL")
                TextBox18.Text = rd.Item("NO_PESERTA_UN")
                TextBox19.Text = rd.Item("TKIP")
                TextBox20.Text = rd.Item("NOKIP")
                TextBox21.Text = rd.Item("AYAH")
                TextBox22.Text = rd.Item("THLAHIRA")
                ComboBox5.Text = rd.Item("JPA")
                TextBox23.Text = rd.Item("PEKERJAANA")
                TextBox24.Text = rd.Item("PENGHASILANA")
                ComboBox6.Text = rd.Item("KKHUSUSA")
                TextBox25.Text = rd.Item("IBU")
                TextBox26.Text = rd.Item("THLAHIRI")
                ComboBox7.Text = rd.Item("JPI")
                TextBox27.Text = rd.Item("PEKERJAANI")
                TextBox28.Text = rd.Item("PENGHASILANI")
                ComboBox8.Text = rd.Item("KKHUSUSI")
                TextBox29.Text = rd.Item("BB")
                TextBox30.Text = rd.Item("TB")
                TextBox31.Text = rd.Item("JRKS")
                TextBox32.Text = rd.Item("WTKS")
                TextBox33.Text = rd.Item("SAUDARA")
                TextBox34.Clear()
                TextBox34.Focus()
            Else
                MessageBox.Show("NISN Tida Terdaftar", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If TextBox2.Text = "" Then
            MessageBox.Show("Tidak Ada Data Yang Dipilih Untuk Di Hapus", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        If MessageBox.Show("Yakin Ingin Hapus Data", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.Yes Then
            Call Koneksi()
            Dim HapusData As String = "delete from PENDAFTARAN where NDAFTAR='" & TextBox1.Text & "'"
            cmd = New OdbcCommand(HapusData, conn)
            cmd.ExecuteNonQuery()
            MessageBox.Show("Data Berhasil Hapus", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Call KONDISIAWAL()
        End If
    End Sub
End Class