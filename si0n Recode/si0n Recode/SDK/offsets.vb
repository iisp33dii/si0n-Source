Imports si0n.cSDK
Public Class Offsets
    '<< Undumped >>'
    Public Shared m_bDormant = &HE9
    Public Shared m_clrRender = &H70
    Public Shared m_dwInGame = &H108
    Public Shared m_nModelIndex = &H254
    Public Shared m_hViewModel = &H32DC
    Public Shared m_iWorldModelIndex = &H31E4
    Public Shared m_szArmsModel = &H38F3
    Public Shared m_iObserverMode = &H336C

    '<< Dumped netvars>>'
    Public Shared m_bGunGameImmunity = ofs.read("netvars", "m_bGungameImmunity")
    Public Shared m_bSpotted = ofs.read("netvars", "m_bSpotted")
    Public Shared m_bSpottedByMask = ofs.read("netvars", "m_bSpottedByMask")
    Public Shared m_dwBoneMatrix = ofs.read("netvars", "m_dwBoneMatrix")
    Public Shared m_fFlags = ofs.read("netvars", "m_fFlags")
    Public Shared m_iItemIDHigh = ofs.read("netvars", "m_iItemIDHigh")
    Public Shared m_OriginalOwnerXuidHigh = ofs.read("netvars", "m_OriginalOwnerXuidHigh")
    Public Shared m_OriginalOwnerXuidLow = ofs.read("netvars", "m_OriginalOwnerXuidLow")
    Public Shared m_nFallbackPaintKit = ofs.read("netvars", "m_nFallbackPaintKit")
    Public Shared m_nFallbackSeed = ofs.read("netvars", "m_nFallbackSeed")
    Public Shared m_nFallbackStatTrak = ofs.read("netvars", "m_nFallbackStatTrak")
    Public Shared m_flFallbackWear = ofs.read("netvars", "m_flFallbackWear")
    Public Shared m_iAccountID = ofs.read("netvars", "m_iAccountID")
    Public Shared m_iHealth = ofs.read("netvars", "m_iHealth")
    Public Shared m_iTeamNum = ofs.read("netvars", "m_iTeamNum")
    Public Shared m_flFlashDuration = ofs.read("netvars", "m_flFlashDuration")
    Public Shared m_flFlashMaxAlpha = ofs.read("netvars", "m_flFlashMaxAlpha")
    Public Shared m_vecOrigin = ofs.read("netvars", "m_vecOrigin")
    Public Shared m_aimPunchAngle = ofs.read("netvars", "m_aimPunchAngle")
    Public Shared m_vecViewOffset = ofs.read("netvars", "m_vecViewOffset")
    Public Shared m_iShotsFired = ofs.read("netvars", "m_iShotsFired")
    Public Shared m_iCrosshairId = ofs.read("netvars", "m_iCrosshairId")
    Public Shared m_hActiveWeapon = ofs.read("netvars", "m_hActiveWeapon")
    Public Shared m_vecVelocity = ofs.read("netvars", "m_vecVelocity")
    Public Shared m_iItemDefinitionIndex = ofs.read("netvars", "m_iItemDefinitionIndex")
    Public Shared m_iGlowIndex = ofs.read("netvars", "m_iGlowIndex")
    Public Shared m_iClip1 = ofs.read("netvars", "m_iClip1")
    Public Shared m_hMyWeapons = ofs.read("netvars", "m_hMyWeapons")
    Public Shared m_iCompetitiveWins = ofs.read("netvars", "m_iCompetitiveWins")
    Public Shared m_iCompetitiveRanking = ofs.read("netvars", "m_iCompetitiveRanking")

    '<< Dumped sigs>>'
    Public Shared dwEntityList = FindPattern.Scanf(mem.ClientDLL, "BB????????83FF010F8C????????3BF8", 1, 0, True)
    Public Shared dwClientState = FindPattern.Scanf(mem.EngineDLL, "A1????????33D26A006A0033C989B0", 1, 0, True)
    Public Shared dwForceAttack = FindPattern.Scanf(mem.ClientDLL, "890D????????8B0D????????8BF28BC183CE04", 2, 0, True)
    Public Shared dwForceJump = FindPattern.Scanf(mem.ClientDLL, "890D????????8B0D????????8BF28BC183CE08", 2, 0, True)
    Public Shared dwGlowObjectManager = FindPattern.Scanf(mem.ClientDLL, "A1????????A801754B", &H1, &H4, True)
    Public Shared dwLocalPlayer = FindPattern.Scanf(mem.ClientDLL, "A3????????C705????????????????E8????????59C36A??", 1, 16, True)
    Public Shared dwRadarBase = FindPattern.Scanf(mem.ClientDLL, "A1????????8B0CB08B01FF50??463B35????????7CEA8B0D", 1, 0, True)
    Public Shared dwViewAngles = FindPattern.Scanf(mem.EngineDLL, "F30F1180????????D94604D905", 4, 0, False)
    Public Shared dwGlobalVars = FindPattern.Scanf(mem.EngineDLL, "F30F1180????????D94604D905", 4, 0, False)
    Public Shared dwPlayerResource = FindPattern.Scanf(mem.ClientDLL, "8B3D????????85FF0F84????????81C7", 2, 0, True)
End Class
