Public Class LAPORAN

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        CrystalReportViewer1.ReportSource = "SISWA.rpt"
        CrystalReportViewer1.RefreshReport()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        CrystalReportViewer1.ReportSource = "KELAS.rpt"
        CrystalReportViewer1.RefreshReport()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        CrystalReportViewer1.ReportSource = "JURUSAN.rpt"
        CrystalReportViewer1.RefreshReport()
    End Sub
End Class