Imports si0n.cSDK
Imports si0n.Offsets
Imports si0n.cUsefulFuncs
Public Class cMisc

    Private pRadarPlayer As New cBasePlayer(Nothing)

    Public Sub Bhop()
        If GetAsyncKeyState(32) And pLocalPlayer.Velocity > 20 Then
            Dim fflags As Integer = pLocalPlayer.fFlags
            If fflags < 263 And fflags <> 257 Then
                cBasePlayer.ForceJump(4)
            Else
                cBasePlayer.ForceJump(5)
            End If
        End If
    End Sub

    Public Sub Noflash(value As Integer)

        If GetAsyncKeyState(Keys.Down) Then
            If pLocalPlayer.FlashMaxAlpha <> value Then
                mem.WrtFloat(pLocalPlayer.ptr + m_flFlashMaxAlpha, value)
            End If
        End If
    End Sub

    Public Sub Radar()
        For i = 1 To MAXPLAYERS
            pRadarPlayer.ptr = cBasePlayer.PointerByIndex(i)
            If pRadarPlayer.Spotted = 0 And pRadarPlayer.Health > 0 And Not pRadarPlayer.Dormant Then mem.WrtInt(pRadarPlayer.ptr + m_bSpotted, 1)
        Next
    End Sub

    Public Sub Nohands()
        If mem.rdInt(pLocalPlayer.ptr + m_szArmsModel) <> -1 Then
            mem.WrtInt(pLocalPlayer.ptr + m_szArmsModel, -1)
        End If
    End Sub

    Private b0nce As Boolean = False
    Public Sub ThirdPerson(Mode As Integer)

        Select Case Mode
            Case 1
                b0nce = True
                mem.WrtInt(pLocalPlayer.ptr + m_iObserverMode, 1)
                'Case 2
                '    b0nce = True
                '    mem.WrtInt(pLocalPlayer.ptr + m_iObserverMode, 3)
            Case Else
                If b0nce Then mem.WrtInt(pLocalPlayer.ptr + m_iObserverMode, 0)
        End Select
    End Sub



    Public Sub Test()

    End Sub



    Public Sub Rankscan()
        Dim pPlayer As New cBasePlayer(Nothing)

        Dim cOld As ConsoleColor = Console.ForegroundColor

        wl("")
        wl("================================================================================")
        wl("")
        Console.ForegroundColor = ConsoleColor.Magenta
        Console.WriteLine("{0,-20} {1,-10} {2,-10}", "[Name]", "[Wins]", "[Rank]")
        Console.ForegroundColor = ConsoleColor.Red
        wl("")
        wl("Terrorists")
        Console.ForegroundColor = cOld
        For i = 1 To 32
            pPlayer.ptr = cBasePlayer.PointerByIndex(i)
            If pPlayer.ptr And pPlayer.Team = 2 Then
                Console.WriteLine("{0,-20} {1,-10} {2,-10}", pPlayer.Name(i), pPlayer.Wins(i), pPlayer.Rank(i))
            End If
        Next
        wl("")
        Console.ForegroundColor = ConsoleColor.Blue
        wl("Counter-Terrorists")
        Console.ForegroundColor = cOld
        For i = 1 To 32
            pPlayer.ptr = cBasePlayer.PointerByIndex(i)
            If pPlayer.ptr And pPlayer.Team = 3 Then
                Console.WriteLine("{0,-20} {1,-10} {2,-10}", pPlayer.Name(i), pPlayer.Wins(i), pPlayer.Rank(i))
            End If
        Next
        Console.ForegroundColor = cOld
        sleep(500)
    End Sub
End Class


