Imports System.Data.Odbc
Public Class UTAMA
    Private Sub UTAMA_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call KUNCI()
        ToolStripStatusLabel5.Text = Today
        ToolStripStatusLabel7.Text = TimeOfDay
    End Sub
    Sub KUNCI()
        LogoffToolStripMenuItem.Enabled = False
        MasterToolStripMenuItem.Enabled = False
        UtlityToolStripMenuItem.Enabled = False
        LaporanToolStripMenuItem.Enabled = False
        WindowsToolStripMenuItem.Enabled = False
        GroupBox1.Enabled = False
        GroupBox2.Enabled = False
        StatusStrip1.Visible = False
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        SEKOLAH.ShowDialog()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        PENDAFTARAN.Show()
        PENDAFTARAN.MdiParent = Me
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        KELAS.Show()
        KELAS.MdiParent = Me
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        JURUSAN.Show()
        JURUSAN.MdiParent = Me
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        GURU.Show()
        GURU.MdiParent = Me
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        FASILITAS.Show()
        FASILITAS.MdiParent = Me
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click

    End Sub

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        LAPORAN.Show()
        LAPORAN.MdiParent = Me
    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        Dim PANGGIL As String
        PANGGIL = "FORMULIR.xlsx"
        Process.Start(PANGGIL)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        ADMIN.ShowDialog()
    End Sub

    Private Sub LoginToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LoginToolStripMenuItem.Click
        LOGIN.ShowDialog()
    End Sub

    Private Sub LogoutToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LogoutToolStripMenuItem1.Click
        End
    End Sub

    Private Sub LogoutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LogoffToolStripMenuItem.Click
        Call KUNCI()
    End Sub

    Private Sub LaporanToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LaporanToolStripMenuItem.Click
        LAPORAN.Show()
        LAPORAN.MdiParent = Me
    End Sub

    Private Sub AbsenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AbsenToolStripMenuItem.Click
        ADMIN.ShowDialog()
    End Sub

    Private Sub PPDBToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PPDBToolStripMenuItem.Click
        PENDAFTARAN.Show()
        PENDAFTARAN.MdiParent = Me
    End Sub

    Private Sub KelasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KelasToolStripMenuItem.Click
        KELAS.Show()
        KELAS.MdiParent = Me
    End Sub

    Private Sub JurusanToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles JurusanToolStripMenuItem.Click
        JURUSAN.Show()
        JURUSAN.MdiParent = Me
    End Sub
End Class
