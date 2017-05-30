Imports si0n.cSDK
Imports si0n.Offsets
Imports si0n.ENUMS
Imports si0n.cUsefulFuncs

Public Class cSkinchanger

    Public sDEAGLE = 39
    Public sDUALS = 39
    Public sFIVESEVEN = 39
    Public sGLOCK = 39
    Public sAK47 = 39
    Public sAUG = 39
    Public sAWP = 39
    Public sFAMAS = 39
    Public sG3SG1 = 39
    Public sGALILAR = 39
    Public sM249 = 39
    Public sM4A4 = 39
    Public sMAC10 = 39
    Public sP90 = 39
    Public sUMP45 = 39
    Public sXM1014 = 39
    Public sBIZON = 39
    Public sMAG7 = 39
    Public sNEGEV = 39
    Public sSAWEDOFF = 39
    Public sTEC9 = 39
    Public sP2000 = 39
    Public sMP7 = 39
    Public sMP9 = 39
    Public sNOVA = 39
    Public sP250 = 39
    Public sSCAR20 = 39
    Public sSG556 = 39
    Public sSSG08 = 39
    Public sM4A1 = 39
    Public sUSP = 39
    Public sCZ75A = 39
    Public sREVOLVER = 39
    Public sKnife = ENUMS.WeaponSkin.Tiger_Tooth

    Private rnd As New Random
    Private pWeapon As New cBaseWeapon(Nothing)

    Public Sub Skinchanger()

        For i = 1 To 9
            Dim curWeaponIndex As Integer = mem.rdInt(pLocalPlayer.ptr + m_hMyWeapons + ((i - 1) * &H4)) And &HFFF
            Dim curWeaponEnt As Integer = mem.rdInt(mem.ClientDLL + dwEntityList + (curWeaponIndex - 1) * &H10)
            pWeapon.ptr = curWeaponEnt
            Dim Xuid As Integer = pLocalPlayer.ActiveWeapon.XuID
            mem.WrtInt(pWeapon.ptr + m_iItemIDHigh, -1)
            mem.WrtInt(pWeapon.ptr + m_OriginalOwnerXuidLow, 0)
            mem.WrtInt(pWeapon.ptr + m_OriginalOwnerXuidHigh, 0)
            mem.WrtInt(pWeapon.ptr + m_nFallbackPaintKit, GetWeaponSkin(pWeapon.ID))
            mem.WrtInt(pWeapon.ptr + m_nFallbackSeed, rnd.Next(1, Integer.MaxValue - 1))
            mem.WrtFloat(pWeapon.ptr + m_flFallbackWear, 0.001)
            mem.WrtInt(pWeapon.ptr + m_iAccountID, Xuid)
        Next
    End Sub

    Private Function GetWeaponSkin(WeaponID As Integer)
        Select Case WeaponID
            Case ItemDefinitionIndex.AK47
                Return sAK47
            Case ItemDefinitionIndex.AUG
                Return sAUG
            Case ItemDefinitionIndex.AWP
                Return sAWP
            Case ItemDefinitionIndex.BIZON
                Return sBIZON
            Case ItemDefinitionIndex.CZ75A
                Return sCZ75A
            Case ItemDefinitionIndex.DEAGLE
                Return sDEAGLE
            Case ItemDefinitionIndex.ELITE
                Return sDUALS
            Case ItemDefinitionIndex.FAMAS
                Return sFAMAS
            Case ItemDefinitionIndex.FIVESEVEN
                Return sFIVESEVEN
            Case ItemDefinitionIndex.G3SG1
                Return sG3SG1
            Case ItemDefinitionIndex.GALILAR
                Return sGALILAR
            Case ItemDefinitionIndex.GLOCK
                Return sGLOCK
            Case ItemDefinitionIndex.M249
                Return sM249
            Case ItemDefinitionIndex.M4A1
                Return sM4A1
            Case ItemDefinitionIndex.M4A4
                Return sM4A4
            Case ItemDefinitionIndex.MAC10
                Return sMAC10
            Case ItemDefinitionIndex.MAG7
                Return sMAG7
            Case ItemDefinitionIndex.MP7
                Return sMP7
            Case ItemDefinitionIndex.MP9
                Return sMP9
            Case ItemDefinitionIndex.NEGEV
                Return sNEGEV
            Case ItemDefinitionIndex.NOVA
                Return sNOVA
            Case ItemDefinitionIndex.P2000
                Return sP2000
            Case ItemDefinitionIndex.P250
                Return sP250
            Case ItemDefinitionIndex.P90
                Return sP90
            Case ItemDefinitionIndex.REVOLVER
                Return sREVOLVER
            Case ItemDefinitionIndex.SAWEDOFF
                Return sSAWEDOFF
            Case ItemDefinitionIndex.SCAR20
                Return sSCAR20
            Case ItemDefinitionIndex.SG556
                Return sSG556
            Case ItemDefinitionIndex.SSG08
                Return sSSG08
            Case ItemDefinitionIndex.TEC9
                Return sTEC9
            Case ItemDefinitionIndex.UMP45
                Return sUMP45
            Case ItemDefinitionIndex.USP
                Return sUSP
            Case ItemDefinitionIndex.XM1014
                Return sXM1014
            Case ItemDefinitionIndex.KNIFE_BAYONET
                Return sKnife
            Case ItemDefinitionIndex.KNIFE_BUTTERFLY
                Return sKnife
            Case ItemDefinitionIndex.KNIFE_FALCHION
                Return sKnife
            Case ItemDefinitionIndex.KNIFE_FLIP
                Return sKnife
            Case ItemDefinitionIndex.KNIFE_GUT
                Return sKnife
            Case ItemDefinitionIndex.KNIFE_KARAMBIT
                Return sKnife
            Case ItemDefinitionIndex.KNIFE_M9_BAYONET
                Return sKnife
            Case ItemDefinitionIndex.KNIFE_TACTICAL
                Return sKnife
            Case Else
                Return False
        End Select
    End Function

End Class
