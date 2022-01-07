Imports System.Data.Odbc
Public Class LOGIN

    Private Sub lOGIN_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call AWAL()
    End Sub
    Sub AWAL()
        UsernameTextBox.Clear()
        PasswordTextBox.Clear()
        UsernameTextBox.Focus()
    End Sub
    Sub TAMPILSEKOLAH()
        Call Koneksi()
        Dim cariData As String = "select * from SEKOLAH WHERE ID='" & UTAMA.Label10.Text & "'"
        cmd = New OdbcCommand(cariData, conn)
        rd = cmd.ExecuteReader
        rd.Read()
        If rd.HasRows Then
            UTAMA.Label1.Text = rd.Item("NAMASEKOLAH")
            UTAMA.Label2.Text = rd.Item("ALAMAT")
            UTAMA.Label3.Text = rd.Item("ALENGKAP")
            UTAMA.Label5.Text = rd.Item("KEPSEK")
            UTAMA.Label6.Text = rd.Item("NIP")
        End If

    End Sub
    Sub BUKA()
        UTAMA.LogoffToolStripMenuItem.Enabled = True
        UTAMA.MasterToolStripMenuItem.Enabled = True
        UTAMA.UtlityToolStripMenuItem.Enabled = True
        UTAMA.LaporanToolStripMenuItem.Enabled = True
        UTAMA.WindowsToolStripMenuItem.Enabled = True
        UTAMA.GroupBox1.Enabled = True
        UTAMA.GroupBox2.Enabled = True
        UTAMA.StatusStrip1.Visible = True
        UTAMA.LoginToolStripMenuItem.Enabled = False
        Call TAMPILSEKOLAH()
    End Sub

    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        On Error Resume Next
        Call Koneksi()
        Dim cari As String
        cari = "select * from ADMIN where NAMA='" & UsernameTextBox.Text & "' and PASSWORD='" & PasswordTextBox.Text & "'"
        cmd = New OdbcCommand(cari, conn)
        rd = cmd.ExecuteReader
        rd.Read()
        If rd.HasRows Then
            Call buka()
            UTAMA.ToolStripStatusLabel1.Text = rd!NAMA
            UTAMA.ToolStripStatusLabel3.Text = rd!STATUS
            UsernameTextBox.Text = ""
            PasswordTextBox.Text = ""
            Me.Close()
        ElseIf Not rd.HasRows Then
            MessageBox.Show("Id Atau Password Salah", "Warnig", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Call AWAL()
        End If
    End Sub
End Class
