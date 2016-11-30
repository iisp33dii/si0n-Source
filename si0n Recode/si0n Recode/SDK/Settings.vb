Imports si0n.cSDK
Public Class cSettings

    '<<< AIMBOT >>>'
    Public Aimbot As Boolean = True
    Public AimSpot As Integer = 6
    Public FovRifles As Integer = 10
    Public SmoothRifles As Integer = 15
    Public FovPistols As Integer = 10
    Public SmoothPistols As Integer = 15
    Public FovSnipers As Integer = 10
    Public SmoothSnipers As Integer = 15
    Public SleepTime As Integer = 300
    Public RangeBased As Boolean = True

    '<<< ESP >>>'
    Public ESP As Boolean = True
    Public ESPmode As Integer = 1
    Public ESPcolorEnemyVis As cConfig.RGBA
    Public ESPcolorEnemy As cConfig.RGBA
    Public ESPcolorTeammate As cConfig.RGBA
    Public ESPcolorWeapons As cConfig.RGBA
    Public ESPcolorGrenades As cConfig.RGBA
    Public ESPcolorBomb As cConfig.RGBA

    '<<< clrRender >>>'
    Public clrRender As Boolean = True

    '<<< TRIGGER >>>'
    Public Trigger As Boolean = True
    Public TriggerMode As Integer = 1

    '<<< MISC >>>'
    Public Bhop As Boolean = True
    Public Nohands As Boolean = True
    Public Thirdperson As Integer = 1
    Public Radar As Boolean = True
    Public Noflash As Boolean = True
    Public NoflashMaxAlpha As Integer = 50

    '<<< SkinChanger >>>'
    Public SkinChangera As Boolean = True

    '<<< KnifeChanger >>>'
    Public KnifeChangera As Boolean = True
    Public KnifeModel As Integer = 4

    '<<< SkinChanger >>>'
    Public Active As Boolean = True


    Public Function Load()
        Try

            KnifeChanger.Reset()

            '<<< AIMBOT >>>'
            Aimbot = cfg.read("AIMBOT", "Active")
            RangeBased = cfg.read("AIMBOT", "Rangebased")
            FovRifles = cfg.read("AIMBOT", "FovRifles")
            AimSpot = cfg.read("AIMBOT", "AimSpot")
            SmoothRifles = cfg.read("AIMBOT", "SmoothRifles")
            FovPistols = cfg.read("AIMBOT", "FovPistols")
            SmoothPistols = cfg.read("AIMBOT", "SmoothPistols")
            FovSnipers = cfg.read("AIMBOT", "FovSnipers")
            SmoothSnipers = cfg.read("AIMBOT", "SmoothSnipers")
            SleepTime = cfg.read("AIMBOT", "SleepTime")

            '<<< ESP >>>'
            ESP = cfg.read("ESP", "Active")
            ESPmode = cfg.read("ESP", "Mode")
            ESPcolorEnemy = cfg.ReadRGBA("ESP", "ColorEnemy")
            ESPcolorEnemyVis = cfg.ReadRGBA("ESP", "ColorEnemyVisible")
            ESPcolorTeammate = cfg.ReadRGBA("ESP", "ColorTeammate")
            ESPcolorWeapons = cfg.ReadRGBA("ESP", "ColorWeapons")
            ESPcolorGrenades = cfg.ReadRGBA("ESP", "ColorGrenades")
            ESPcolorBomb = cfg.ReadRGBA("ESP", "ColorBomb")


            '<<< ModelColor >>>'
            clrRender = cfg.read("MODELCOLOR", "Active")

            '<<< TRIGGER >>>'
            Trigger = cfg.read("TRIGGER", "Active")
            TriggerMode = cfg.read("TRIGGER", "Mode")

            '<<< MISC >>>'
            Bhop = cfg.read("MISC", "Bhop")
            Nohands = cfg.read("MISC", "Nohands")
            Bhop = cfg.read("MISC", "Bhop")
            Thirdperson = cfg.read("MISC", "Thirdperson")
            Radar = cfg.read("MISC", "Radar")
            Noflash = cfg.read("MISC", "Noflash")
            NoflashMaxAlpha = cfg.read("MISC", "NoflashMaxAlpha")

            '<<< KnifeChanger >>>'
            KnifeChangera = cfg.read("KNIFECHANGER", "Active")
            KnifeModel = cfg.read("KNIFECHANGER", "Model")

            '<<< KEYS >>>'
            KeyBinds.TriggerKey = cfg.read("KEYS", "Trigger")
            KeyBinds.SkinchangerKey = cfg.read("KEYS", "Skinchanger")
            KeyBinds.RankScannerKey = cfg.read("KEYS", "RankScanner")

            '<<< SkinChanger >>>
            SkinChangera = cfg.read("SKINS", "Active")
            SkinChanger.sDEAGLE = cfg.read("SKINS", "DEAGLE")
            SkinChanger.sDUALS = cfg.read("SKINS", "DUALS")
            SkinChanger.sFIVESEVEN = cfg.read("SKINS", "FIVESEVEN")
            SkinChanger.sGLOCK = cfg.read("SKINS", "GLOCK")
            SkinChanger.sAK47 = cfg.read("SKINS", "AK47")
            SkinChanger.sAUG = cfg.read("SKINS", "AUG")
            SkinChanger.sAWP = cfg.read("SKINS", "AWP")
            SkinChanger.sFAMAS = cfg.read("SKINS", "FAMAS")
            SkinChanger.sG3SG1 = cfg.read("SKINS", "G3SG1")
            SkinChanger.sGALILAR = cfg.read("SKINS", "GALILAR")
            SkinChanger.sM249 = cfg.read("SKINS", "M249")
            SkinChanger.sM4A4 = cfg.read("SKINS", "M4A4")
            SkinChanger.sMAC10 = cfg.read("SKINS", "MAC10")
            SkinChanger.sP90 = cfg.read("SKINS", "P90")
            SkinChanger.sUMP45 = cfg.read("SKINS", "UMP45")
            SkinChanger.sXM1014 = cfg.read("SKINS", "XM1014")
            SkinChanger.sBIZON = cfg.read("SKINS", "BIZON")
            SkinChanger.sMAG7 = cfg.read("SKINS", "MAG7")
            SkinChanger.sNEGEV = cfg.read("SKINS", "NEGEV")
            SkinChanger.sSAWEDOFF = cfg.read("SKINS", "SAWEDOFF")
            SkinChanger.sTEC9 = cfg.read("SKINS", "TEC9")
            SkinChanger.sP2000 = cfg.read("SKINS", "P2000")
            SkinChanger.sMP7 = cfg.read("SKINS", "MP7")
            SkinChanger.sMP9 = cfg.read("SKINS", "MP9")
            SkinChanger.sNOVA = cfg.read("SKINS", "NOVA")
            SkinChanger.sP250 = cfg.read("SKINS", "P250")
            SkinChanger.sSCAR20 = cfg.read("SKINS", "SCAR20")
            SkinChanger.sSG556 = cfg.read("SKINS", "SG556")
            SkinChanger.sSSG08 = cfg.read("SKINS", "SSG08")
            SkinChanger.sM4A1 = cfg.read("SKINS", "M4A1")
            SkinChanger.sUSP = cfg.read("SKINS", "USP")
            SkinChanger.sCZ75A = cfg.read("SKINS", "CZ75A")
            SkinChanger.sREVOLVER = cfg.read("SKINS", "REVOLVER")
            SkinChanger.sKnife = cfg.read("SKINS", "KNIFE")

        Catch ex As Exception
            cUsefulFuncs.wl(ex.ToString)
        End Try
    End Function

    Public Function Save()
        '<<< AIMBOT >>>'
        cfg.write("AIMBOT", "Active", Aimbot)
        cfg.write("AIMBOT", "Rangebased", RangeBased)
        cfg.write("AIMBOT", "FovRifles", FovRifles)
        cfg.write("AIMBOT", "AimSpot", AimSpot)
        cfg.write("AIMBOT", "SmoothRifles", SmoothRifles)
        cfg.write("AIMBOT", "FovPistols", FovPistols)
        cfg.write("AIMBOT", "SmoothPistols", SmoothPistols)
        cfg.write("AIMBOT", "FovSnipers", FovSnipers)
        cfg.write("AIMBOT", "SmoothSnipers", SmoothSnipers)
        cfg.write("AIMBOT", "SleepTime", SleepTime)

        '<<< ESP >>>'
        cfg.write("ESP", "Active", ESP)
        cfg.write("ESP", "Mode", ESPmode)
        cfg.WriteRGBA("ESP", "ColorEnemy", ESPcolorEnemy)
        cfg.WriteRGBA("ESP", "ColorEnemyVisible", ESPcolorEnemyVis)
        cfg.WriteRGBA("ESP", "ColorTeammate", ESPcolorTeammate)
        cfg.WriteRGBA("ESP", "ColorWeapons", ESPcolorWeapons)
        cfg.WriteRGBA("ESP", "ColorGrenades", ESPcolorGrenades)
        cfg.WriteRGBA("ESP", "ColorBomb", ESPcolorBomb)

        '<<< ModelColor >>>'
        cfg.write("MODELCOLOR", "Active", clrRender)

        '<<< TRIGGER >>>'
        cfg.write("TRIGGER", "Active", Trigger)
        cfg.write("TRIGGER", "Mode", TriggerMode)

        '<<< MISC >>>'
        cfg.write("MISC", "Bhop", Bhop)
        cfg.write("MISC", "Nohands", Nohands)
        cfg.write("MISC", "Thirdperson", Thirdperson)
        cfg.write("MISC", "Radar", Radar)
        cfg.write("MISC", "Noflash", Noflash)
        cfg.write("MISC", "NoflashMaxAlpha", NoflashMaxAlpha)

        '<<< KnifeChanger >>>'
        cfg.write("KNIFECHANGER", "Active", KnifeChangera)
        cfg.write("KNIFECHANGER", "Model", KnifeModel)

        '<<< KEYS >>>'
        cfg.write("KEYS", "Trigger", KeyBinds.TriggerKey)
        cfg.write("KEYS", "Skinchanger", KeyBinds.SkinchangerKey)
        cfg.write("KEYS", "RankScanner", KeyBinds.RankScannerKey)

        '<<< Skinchanger >>>
        cfg.write("SKINS", "Active", SkinChangera)
        cfg.write("SKINS", "DEAGLE", SkinChanger.sDEAGLE)
        cfg.write("SKINS", "DUALS", SkinChanger.sDUALS)
        cfg.write("SKINS", "FIVESEVEN", SkinChanger.sFIVESEVEN)
        cfg.write("SKINS", "GLOCK", SkinChanger.sGLOCK)
        cfg.write("SKINS", "AK47", SkinChanger.sAK47)
        cfg.write("SKINS", "AUG", SkinChanger.sAUG)
        cfg.write("SKINS", "AWP", SkinChanger.sAWP)
        cfg.write("SKINS", "FAMAS", SkinChanger.sFAMAS)
        cfg.write("SKINS", "G3SG1", SkinChanger.sG3SG1)
        cfg.write("SKINS", "GALILAR", SkinChanger.sGALILAR)
        cfg.write("SKINS", "M249", SkinChanger.sM249)
        cfg.write("SKINS", "M4A4", SkinChanger.sM4A4)
        cfg.write("SKINS", "MAC10", SkinChanger.sMAC10)
        cfg.write("SKINS", "P90", SkinChanger.sP90)
        cfg.write("SKINS", "UMP45", SkinChanger.sUMP45)
        cfg.write("SKINS", "XM1014", SkinChanger.sXM1014)
        cfg.write("SKINS", "BIZON", SkinChanger.sBIZON)
        cfg.write("SKINS", "MAG7", SkinChanger.sMAG7)
        cfg.write("SKINS", "NEGEV", SkinChanger.sNEGEV)
        cfg.write("SKINS", "SAWEDOFF", SkinChanger.sSAWEDOFF)
        cfg.write("SKINS", "TEC9", SkinChanger.sTEC9)
        cfg.write("SKINS", "P2000", SkinChanger.sP2000)
        cfg.write("SKINS", "MP7", SkinChanger.sMP7)
        cfg.write("SKINS", "MP9", SkinChanger.sMP9)
        cfg.write("SKINS", "NOVA", SkinChanger.sNOVA)
        cfg.write("SKINS", "P250", SkinChanger.sP250)
        cfg.write("SKINS", "SCAR20", SkinChanger.sSCAR20)
        cfg.write("SKINS", "SG556", SkinChanger.sSG556)
        cfg.write("SKINS", "SSG08", SkinChanger.sSSG08)
        cfg.write("SKINS", "M4A1", SkinChanger.sM4A1)
        cfg.write("SKINS", "USP", SkinChanger.sUSP)
        cfg.write("SKINS", "CZ75A", SkinChanger.sCZ75A)
        cfg.write("SKINS", "REVOLVER", SkinChanger.sREVOLVER)
        cfg.write("SKINS", "KNIFE", SkinChanger.sKnife)
    End Function
End Class
