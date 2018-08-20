Imports MySql.Data.MySqlClient

Module dataAdd

    Public Sub handlesVoteLogs()

        Try
            dbConnection()
            sql = "INSERT INTO `phinmaui_elections`.`voted_logs` (`BallotNo`,`IDNo`,`Name`,`Course`,`Department`,`President`,`VPInternal`,`VPExternal`,`Secretary`,`Auditor`,`Treasurer`,`Chairman`,`ViceChairman`,`LocalSecretary`,`LocalTreasurer`,`LocalAuditor`,`BoardMember1`,`BoardMember2`,`BoardMember3`,`BoardMember4`,`BoardMember5`,`Time`,`Date`) " & _
                  "VALUES (@BallotNo, @IDNo, @Name, @Course, @Department, @Pres, @VPIntern, @VPExtern, @Sec, @Aud, @Treas, @Chairman, @ViceChairman, @LSec, @LTreas, @LAud, @BoardMember, @BoardMember2, @BoardMember3, @BoardMember4, @BoardMember5, @Time, @Date);"
                cmd = New MySqlCommand
            With cmd
                .Connection = conn
                .CommandText = sql
                .Parameters.Clear()
                .Parameters.AddWithValue("@BallotNo", formVotingPane.eballotnoLbl.Text)
                .Parameters.AddWithValue("@IDNo", idno)
                .Parameters.AddWithValue("@Name", formConfirmation.nameLbl.Text)
                .Parameters.AddWithValue("@Course", formConfirmation.courseLbl.Text)
                .Parameters.AddWithValue("@Department", department)
                .Parameters.AddWithValue("@Pres", formConfirmation.presidentLbl.Text)
                .Parameters.AddWithValue("@VPIntern", formConfirmation.vpinternalLbl.Text)
                .Parameters.AddWithValue("@VPExtern", formConfirmation.vpexternalLbl.Text)
                .Parameters.AddWithValue("@Sec", formConfirmation.secretaryLbl.Text)
                .Parameters.AddWithValue("@Aud", formConfirmation.auditorLbl.Text)
                .Parameters.AddWithValue("@Treas", formConfirmation.treasurerLbl.Text)
                .Parameters.AddWithValue("@Chairman", formConfirmation.chairmanLbl.Text)
                .Parameters.AddWithValue("@ViceChairman", formConfirmation.vicechairmanLbl.Text)
                .Parameters.AddWithValue("@LSec", formConfirmation.lsecretaryLbl.Text)
                .Parameters.AddWithValue("@LTreas", formConfirmation.ltreasurerLbl.Text)
                .Parameters.AddWithValue("@LAud", formConfirmation.lauditorLbl.Text)
                .Parameters.AddWithValue("@BoardMember", formConfirmation.boardmem1Lbl.Text)
                .Parameters.AddWithValue("@BoardMember2", formConfirmation.boardmem2Lbl.Text)
                .Parameters.AddWithValue("@BoardMember3", formConfirmation.boardmem3Lbl.Text)
                .Parameters.AddWithValue("@BoardMember4", formConfirmation.boardmem4Lbl.Text)
                .Parameters.AddWithValue("@BoardMember5", formConfirmation.boardmem5Lbl.Text)
                .Parameters.AddWithValue("@Time", TimeOfDay.ToString("h:mm:ss tt"))
                .Parameters.AddWithValue("@Date", Date.Today.ToString("MMMM dd, yyyy"))
                result = .ExecuteNonQuery()
            End With
        Catch ex As MySqlException
            MsgBox(ex.Message)
        Finally
            conn.Close()
            updateNationalVotes()
            updateLocalVotes()
            department = ""
        End Try
    End Sub

End Module
