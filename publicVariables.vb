Imports MySql.Data.MySqlClient

Module publicVariables

    Public conn As MySqlConnection
    Public cmd As MySqlCommand
    Public da As MySqlDataAdapter
    Public dr As MySqlDataReader
    Public dt As DataTable
    Public sql As String
    Public idno As String
    Public course As String
    Public fullname As String
    Public lastname As String
    Public department As String
    Public eballotno As String
    Public activation As Boolean
    Public voted As Boolean
    Public votecounts As Integer = 0
    Public result As Integer

    'Handles Candidates

    Public pres, vpintern, vpextern, sec, aud, treas, chair, vicechair, lsec, ltreas, laud, boardmem1, boardmem2, boardmem3, boardmem4, boardmem5 As String
    Public undecided As String = "UNDERVOTE"
End Module
