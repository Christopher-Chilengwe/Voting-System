Imports MySql.Data.MySqlClient

Module dataConnection

    Public Sub dbConnection()

        conn = New MySqlConnection
        conn.ConnectionString = "server=172.16.0.210;user id=phinmaui;password=yappari4;database=phinmaui_elections"
        conn.Open()

    End Sub

End Module
