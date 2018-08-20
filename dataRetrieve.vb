Imports MySql.Data.MySqlClient

Module dataRetrieve

    Public Sub retrievestudentinfo()

        Try
            dbConnection()
            sql = "SELECT * from student_data WHERE ID_No = '" & formLogin.idnumberTB.Text & "';"
            cmd = New MySqlCommand(sql, conn)
            da = New MySqlDataAdapter
            dt = New DataTable
            da.SelectCommand = cmd
            da.Fill(dt)

            If dt.Rows.Count > 0 Then
                idno = dt.Rows(0).Item(0)
                fullname = dt.Rows(0).Item(1) + ", " + dt.Rows(0).Item(2) + " " + dt.Rows(0).Item(3)
                lastname = dt.Rows(0).Item(1)
                course = dt.Rows(0).Item(4)
                activation = dt.Rows(0).Item(5)
                voted = dt.Rows(0).Item(6)
                If formLogin.idnumberTB.Text = idno And formLogin.lastnameTB.Text = lastname Then
                    If activation = False Then
                        MsgBox("Activation Required!")
                        clearLogin()
                        formLogin.idnumberTB.Focus()
                    Else
                        If voted = True Then
                            MsgBox("You have already voted!")
                            clearLogin()
                            formLogin.idnumberTB.Focus()
                        Else
                            MsgBox("Welcome " & fullname & "!")
                            retrieveballotno()
                            retrievelocalcandidates()
                            formVotingPane.Show()
                            formLogin.Hide()
                            formVotingPane.studentnameLbl.Text = fullname
                            formVotingPane.courseLbl.Text = course
                            formVotingPane.eballotnoLbl.Text = eballotno
                            clearLogin()
                        End If
                    End If
                Else
                    MsgBox("Incorrect Inputs!")
                    clearLogin()
                    formLogin.idnumberTB.Focus()
                End If
            Else
                MsgBox("Incorrect Inputs!")
                clearLogin()
                formLogin.idnumberTB.Focus()
            End If
        Catch ex As MySqlException
            MsgBox(ex.Message)
            clearLogin()
        Finally
            conn.Close()
        End Try

    End Sub

    Public Sub retrieveballotno()

        Try
            dbConnection()
            sql = "SELECT * from eballot_archive WHERE ID_No = @IDNo;"
            cmd = New MySqlCommand(sql, conn)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@IDNo", formLogin.idnumberTB.Text)
            dr = cmd.ExecuteReader
            While dr.Read
                eballotno = dr.GetString("Ballot_No")
            End While
        Catch ex As MySqlException
            MsgBox(ex.Message)
        Finally
            conn.Close()
            dr.Close()
        End Try

    End Sub

    Public Sub retrievelocalcandidates()

        'College of Education
        If course = "BEED-GEN ED" Then
            COEDCandidates()
            department = "COED"
        ElseIf course = "BEED-PRE-SCHOOL" Then
            COEDCandidates()
            department = "COED"
        ElseIf course = "BEED-SPED" Then
            COEDCandidates()
            department = "COED"
        ElseIf course = "BSED-ENGLISH" Then
            COEDCandidates()
            department = "COED"

            'College of Management and Accountancy
        ElseIf course = "BSA" Then
            CMACandidates()
            department = "CMA"
        ElseIf course = "BSAT" Then
            CMACandidates()
            department = "CMA"
        ElseIf course = "BSBA-FM" Then
            CMACandidates()
            department = "CMA"
        ElseIf course = "BSBA-MM" Then
            CMACandidates()
            department = "CMA"
        ElseIf course = "BSHRM" Then
            CMACandidates()
            department = "CMA"
        ElseIf course = "BSTM" Then
            CMACandidates()
            department = "CMA"

            'College of Engineering
        ElseIf course = "BSCE" Then
            COECandidates()
            department = "COE"

            'College of Criminal Justice
        ElseIf course = "BSCRIM" Then
            CCJECandidates()
            department = "CCJE"

            'College of Information Technology Education
        ElseIf course = "BSIT" Then
            CITECandidates()
            department = "CITE"
        ElseIf course = "BSCS" Then
            CITECandidates()
            department = "CITE"

            'College of Allied Health and Sciences
        ElseIf course = "BSN" Then
            CAHSCandidates()
            department = "CAHS"

            'College of Maritime Education
        ElseIf course = "ELSP" Then
            COMECandidates()
            department = "COME"
        ElseIf course = "BSMARE" Then
            COMECandidates()
            department = "COME"

            'College of Arts and Sciences
        ElseIf course = "AB" Then
            CASCandidates()
            department = "CAS"
        ElseIf course = "BSPSYCH" Then
            CASCandidates()
            department = "CAS"
        End If

    End Sub

    Public Sub CASCandidates()

        formVotingPane.chairmanCB1.Text = "GAMBALAN, ELYNN JIZZA G.(SDA)"
        formVotingPane.chairmanCB2.Visible = False
        formVotingPane.vicechairmanCB1.Text = "DE LA CRUZ, JOSEPH V.(SDA)"
        formVotingPane.vicechairmanCB2.Visible = False
        formVotingPane.lsecretaryCB1.Text = "PORTILLO, JAMES P.(SDA)"
        formVotingPane.lsecretaryCB2.Visible = False
        formVotingPane.ltreasurerCB1.Text = "GABALES, ZYRAH F.(SDA)"
        formVotingPane.ltreasurerCB2.Visible = False
        formVotingPane.lauditorCB1.Visible = False
        formVotingPane.lauditorCB2.Visible = False
        formVotingPane.Label6.Visible = False
        formVotingPane.Label7.Visible = False
        formVotingPane.boardmemberCB1.Visible = False
        formVotingPane.boardmemberCB2.Visible = False
        formVotingPane.boardmemberCB3.Visible = False
        formVotingPane.boardmemberCB4.Visible = False
        formVotingPane.boardmemberCB5.Visible = False

    End Sub

    Public Sub COMECandidates()

        formVotingPane.chairmanCB1.Text = "CHAVEZ, JASTINE G.(SDA)"
        formVotingPane.chairmanCB2.Visible = False
        formVotingPane.vicechairmanCB1.Text = "PACANA, ACE JOHN T.(SDA)"
        formVotingPane.vicechairmanCB2.Visible = False
        formVotingPane.lsecretaryCB1.Text = "ARANDUQUE, ARVIN G.(SDA)"
        formVotingPane.lsecretaryCB2.Visible = False
        formVotingPane.ltreasurerCB1.Text = "CORDERO, JOSHUA D.(SDA)"
        formVotingPane.ltreasurerCB2.Visible = False
        formVotingPane.lauditorCB1.Text = "JALANDONI, ARTHUR A.(SDA)"
        formVotingPane.lauditorCB2.Visible = False
        formVotingPane.boardmemberCB1.Text = "MAGDADERO, LESTER T.(SDA)"
        formVotingPane.boardmemberCB2.Text = "MOTIN, RAPHY D.(SDA)"
        formVotingPane.boardmemberCB3.Text = "TANANGUNAN, CLAUDE JOHN G.(SDA)"
        formVotingPane.boardmemberCB4.Visible = False
        formVotingPane.boardmemberCB5.Visible = False

    End Sub

    Public Sub CAHSCandidates()

        formVotingPane.chairmanCB1.Text = "SEGOBRE, JOHN MARCO(KSP)"
        formVotingPane.chairmanCB2.Visible = False
        formVotingPane.vicechairmanCB1.Text = "GARGACERAN, DYNA G.(KSP)"
        formVotingPane.vicechairmanCB2.Visible = False
        formVotingPane.lsecretaryCB1.Text = "IBANEZ, JANICE B.(KSP)"
        formVotingPane.lsecretaryCB2.Visible = False
        formVotingPane.ltreasurerCB1.Text = "LASTIMOSO, CECILE(KSP)"
        formVotingPane.ltreasurerCB2.Visible = False
        formVotingPane.lauditorCB1.Text = "ESPORA, RHEA MAE E.(KSP)"
        formVotingPane.lauditorCB2.Visible = False
        formVotingPane.boardmemberCB1.Text = "ANGARAY, MAYBEL(KSP)"
        formVotingPane.boardmemberCB2.Visible = False
        formVotingPane.boardmemberCB3.Visible = False
        formVotingPane.boardmemberCB4.Visible = False
        formVotingPane.boardmemberCB5.Visible = False

    End Sub

    Public Sub CITECandidates()

        formVotingPane.chairmanCB1.Text = "CORDOVERO, CHESKA A.(KSP)"
        formVotingPane.chairmanCB2.Visible = False
        formVotingPane.vicechairmanCB1.Text = "TUERES, ANTHONY VICK D.(KSP)"
        formVotingPane.vicechairmanCB2.Visible = False
        formVotingPane.lsecretaryCB1.Text = "AYUPAN, PAMELA JOYCE G.(KSP)"
        formVotingPane.lsecretaryCB2.Visible = False
        formVotingPane.ltreasurerCB1.Text = "ENDENCIO, MARIENELL ANN(KSP)"
        formVotingPane.ltreasurerCB2.Visible = False
        formVotingPane.lauditorCB1.Text = "LALATRAVA, JEFF LAWRENCE C.(KSP)"
        formVotingPane.lauditorCB2.Visible = False
        formVotingPane.boardmemberCB1.Text = "AMADO, CHRISTIAN GABRIEL C.(KSP)"
        formVotingPane.boardmemberCB2.Text = "ESQUERA, CYRILLE OLIVER E.(KSP)"
        formVotingPane.boardmemberCB3.Visible = False
        formVotingPane.boardmemberCB4.Visible = False
        formVotingPane.boardmemberCB5.Visible = False

    End Sub

    Public Sub CCJECandidates()

        formVotingPane.chairmanCB1.Text = "FRENCH, MARY KRIS A.(KSP)"
        formVotingPane.chairmanCB2.Visible = False
        formVotingPane.vicechairmanCB1.Text = "BINAS, SCARLET JUNE D.(KSP)"
        formVotingPane.vicechairmanCB2.Visible = False
        formVotingPane.lsecretaryCB1.Text = "CELESTRE, PAULINE ANNE P.(KSP)"
        formVotingPane.lsecretaryCB2.Visible = False
        formVotingPane.ltreasurerCB1.Text = "DEYPALUBOS, JOLIEN D.(KSP)"
        formVotingPane.ltreasurerCB2.Visible = False
        formVotingPane.lauditorCB1.Text = "VALENCIA, EMILINE F.(KSP)"
        formVotingPane.lauditorCB2.Visible = False
        formVotingPane.boardmemberCB1.Text = "ALFARO, STEPHANIE E.(KSP)"
        formVotingPane.boardmemberCB2.Text = "NAVARRO, KLARYSH L.(KSP)"
        formVotingPane.boardmemberCB3.Text = "PARTO, BILLY JOE B.(KSP)"
        formVotingPane.boardmemberCB4.Text = "PERMO, RODOLFO B. III(KSP)"
        formVotingPane.boardmemberCB5.Text = "TAGUDAR, CHRYSTAL MAY HOPE(KSP)"

    End Sub

    Public Sub COECandidates()

        formVotingPane.chairmanCB1.Text = "JALEA, EDEN GRACE T.(SDA)"
        formVotingPane.chairmanCB2.Visible = False
        formVotingPane.vicechairmanCB1.Text = "AQUINO, DAN DEREK B.(SDA)"
        formVotingPane.vicechairmanCB2.Visible = False
        formVotingPane.lsecretaryCB1.Text = "SARET, JESSUH MAREE B.(SDA)"
        formVotingPane.lsecretaryCB2.Visible = False
        formVotingPane.ltreasurerCB1.Text = "PINGSON, MARY ANGELIE T.(SDA)"
        formVotingPane.ltreasurerCB2.Visible = False
        formVotingPane.lauditorCB1.Text = "SAGO-ON, ARIANE SHANE(SDA)"
        formVotingPane.lauditorCB2.Visible = False
        formVotingPane.boardmemberCB1.Text = "BELTRAN, NOEL VINCENT(SDA)"
        formVotingPane.boardmemberCB2.Visible = False
        formVotingPane.boardmemberCB3.Visible = False
        formVotingPane.boardmemberCB4.Visible = False
        formVotingPane.boardmemberCB5.Visible = False

    End Sub

    Public Sub CMACandidates()

        formVotingPane.chairmanCB1.Text = "ALMAZAN, ARCY MAE A.(KSP)"
        formVotingPane.chairmanCB2.Text = "MAHINAY, KRINZZE CARRIE I.(SDA)"
        formVotingPane.vicechairmanCB1.Text = "BUENO, PAULINE GRACE(KSP)"
        formVotingPane.vicechairmanCB2.Text = "LOPEZ, REGINO G.(SDA)"
        formVotingPane.lsecretaryCB1.Text = "COOPERA, PHOBIE ANN B.(KSP)"
        formVotingPane.lsecretaryCB2.Visible = False
        formVotingPane.ltreasurerCB1.Text = "LUCAS, RACHELLE REDEN I.(SDA)"
        formVotingPane.ltreasurerCB2.Text = "PEDROSA, HANNAH C.(KSP)"
        formVotingPane.lauditorCB1.Text = "JOMENTO, JOYCE C.(SDA)"
        formVotingPane.lauditorCB2.Text = "TACUEL, VIRRYL P.(KSP)"
        formVotingPane.boardmemberCB1.Text = "DIAMANTE, ANGEL MAE D.(KSP)"
        formVotingPane.boardmemberCB2.Text = "EBALLA, STEPHANY SHANE(KSP)"
        formVotingPane.boardmemberCB3.Text = "GAJO, ERIC JASON T.(KSP)"
        formVotingPane.boardmemberCB4.Text = "LAJO, JONNA MAE G.(KSP)"
        formVotingPane.boardmemberCB5.Visible = False


    End Sub

    Public Sub COEDCandidates()

        formVotingPane.chairmanCB1.Text = "PANES, KRISTEL JANE P.(IND)"
        formVotingPane.chairmanCB2.Visible = False
        formVotingPane.vicechairmanCB1.Text = "CHAVEZ, ART CHRISTIAN S.(IND)"
        formVotingPane.vicechairmanCB2.Visible = False
        formVotingPane.lsecretaryCB1.Text = "CAMAYODO, KIZZY MHAE(IND)"
        formVotingPane.lsecretaryCB2.Visible = False
        formVotingPane.ltreasurerCB1.Text = "GERMINAL, RE-ANN JOY A.(IND)"
        formVotingPane.ltreasurerCB2.Visible = False
        formVotingPane.lauditorCB1.Text = "DIANON, ERMA MAE C.(IND)"
        formVotingPane.lauditorCB2.Visible = False
        formVotingPane.boardmemberCB1.Text = "BARGO, LYRA Z.(IND)"
        formVotingPane.boardmemberCB2.Text = "PUMAREN, JOHNEL C.(IND)"
        formVotingPane.boardmemberCB3.Visible = False
        formVotingPane.boardmemberCB4.Visible = False
        formVotingPane.boardmemberCB5.Visible = False

    End Sub

End Module
