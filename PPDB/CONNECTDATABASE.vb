Imports System.Data.Odbc
Module CONNECTDATABASE
    Public conn As OdbcConnection
    Public da As OdbcDataAdapter
    Public ds As DataSet
    Public cmd As OdbcCommand
    Public rd As OdbcDataReader = Nothing
    Sub Koneksi()
        Try
            conn = New OdbcConnection("DSN=PPDB;MultipleActiveResultSets=true")
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If
        Catch ex As Exception
            MessageBox.Show("KONEKSI KE DATABASE GAGAL,SILAHKAN INFO OPERATOR", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub
End Module
