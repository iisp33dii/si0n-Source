Imports si0n.cSDK
Public Class Offsets
    '<< Undumped >>'
    Public Shared m_bDormant = &HE9
    Public Shared m_clrRender = &H70
    Public Shared m_dwInGame = &H100
    Public Shared m_nModelIndex = &H254
    Public Shared m_hViewModel = &H32FC
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
    Public Shared dwClientState = FindPattern.Scanf(mem.EngineDLL, "A1????????F30F1180????????D94604D905", 1, 0, True)
    Public Shared dwForceAttack = FindPattern.Scanf(mem.ClientDLL, "8915????????8B15????????F6C203740383CE04", 2, 0, True)
    Public Shared dwForceJump = FindPattern.Scanf(mem.ClientDLL, "8915????????8B15????????F6C203740383CE08", 2, 0, True)
    Public Shared dwGlowObjectManager = FindPattern.Scanf(mem.ClientDLL, "A1????????A801754E0F57C0", 1, 4, True)
    Public Shared dwLocalPlayer = FindPattern.Scanf(mem.ClientDLL, "A3????????C705????????????????E8????????59C36A", 1, 16, True)
    Public Shared dwRadarBase = FindPattern.Scanf(mem.ClientDLL, "A1????????8B0CB08B01FF50??463B35????????7CEA8B0D", 1, 0, True)
    Public Shared dwViewAngles = FindPattern.Scanf(mem.EngineDLL, "F30F1180????????D94604D905", 4, 0, False)
    Public Shared dwGlobalVars = FindPattern.Scanf(mem.ClientDLL, "A1????????5F8B4010", 1, 0, True)
    Public Shared dwPlayerResource = FindPattern.Scanf(mem.ClientDLL, "8B3D????????85FF0F84????????81C7", 2, 0, True)

    'Public Shared dwEntityList = ofs.read("signatures", "dwEntityList")
    'Public Shared dwClientState = ofs.read("signatures", "dwClientState")
    'Public Shared dwForceAttack = ofs.read("signatures", "dwForceAttack")
    'Public Shared dwForceJump = ofs.read("signatures", "dwForceJump")
    'Public Shared dwGlowObjectManager = ofs.read("signatures", "dwGlowObjectManager"
    'Public Shared dwLocalPlayer = ofs.read("signatures", "dwLocalPlayer")
    'Public Shared dwRadarBase = ofs.read("signatures", "dwRadarBase")
    'Public Shared dwViewAngles = ofs.read("signatures", "ViewAngles")

End Class
'Public Enum Offsets
'    m_fAccuracyPenalty = &H32C0
'    m_nForceBone = &H267C
'    m_iState = &H31F8
'    m_iClip1 = &H3204
'    m_flNextPrimaryAttack = &H31D8
'    m_bCanReload = &H3245
'    m_iPrimaryAmmoType = &H31FC
'    m_iWeaponID = &H32EC
'    m_zoomLevel = &H3350
'    m_bSpotted = &H939
'    m_bSpottedByMask = &H97C
'    m_hOwnerEntity = &H148
'    m_vecOrigin = &H134
'    m_iTeamNum = &HF0
'    m_flFlashMaxAlpha = &HA304
'    m_flFlashDuration = &HA308
'    m_iGlowIndex = &HA320
'    m_angEyeAngles = &HA9FC
'    m_iAccount = &HA9EC
'    m_ArmorValue = &HA9F8
'    m_bGunGameImmunity = &H38B0
'    m_iShotsFired = &HA2C0
'    CSPlayerResource = &H2EEF1AC
'    m_iCompetitiveRanking = &H1A44
'    m_iCompetitiveWins = &H1B48
'    m_iKills = &HBE8
'    m_iAssists = &HCEC
'    m_iDeaths = &HDF0
'    m_iPing = &HAE4
'    m_iScore = &H1940
'    m_szClan = &H4120
'    m_lifeState = &H25B
'    m_fFlags = &H100
'    m_iHealth = &HFC
'    m_hLastWeapon = &H32F8
'    m_hMyWeapons = &H2DE8
'    m_hActiveWeapon = &H2EE8
'    m_Local = &H2FAC
'    m_vecViewOffset = &H104
'    m_nTickBase = &H3424
'    m_vecVelocity = &H110
'    m_szLastPlaceName = &H35A8
'    m_vecPunch = &H301C
'    m_iCrossHairID = &HAA64
'    m_bDormant = &HE9
'    m_dwModel = &H6C
'    m_dwIndex = &H64
'    m_dwBoneMatrix = &H2698
'    m_bMoveType = &H258
'    m_dwClientState = &H5C22C4
'    m_dwLocalPlayerIndex = &H178
'    m_dwInGame = &H100
'    m_dwMaxPlayer = &H308
'    m_dwMapDirectory = &H180
'    m_dwMapname = &H284
'    m_dwPlayerInfo = &H523C
'    m_dwViewAngles = &H4D0C
'    m_dwViewMatrix = &H4AA2B14
'    m_dwEnginePosition = &H670934
'    m_dwRadarBase = &H4EE5D4C
'    m_dwRadarBasePointer = &H50
'    m_dwLocalPlayer = &HA8F53C
'    m_dwEntityList = &H4AB0F74
'    m_dwWeaponTable = &H4EF814C
'    m_dwWeaponTableIndex = &H3270
'    m_dwInput = &H4EFBAC0
'    m_dwGlobalVars = &H4DA218
'    m_dwGlowObject = &H4FC8B94
'    m_dwForceJump = &H4F47AB4
'    m_dwForceAttack = &H2EF0F78
'    m_dwSensitivity = &H0 'invalid
'    m_dwMouseEnable = &H0 'invalid



'    m_iItemDefinitionIndex = &H2F88
'    m_iAccountID = &H2FA8
'    m_OriginalOwnerXuidLow = &H3168
'    m_OriginalOwnerXuidHigh = &H316C
'    m_iItemIDLow = &H2FA4
'    m_iItemIDHigh = &H2FA0
'    m_nFallbackPaintKit = &H3170
'    m_nFallbackSeed = &H3174
'    m_flFallbackWear = &H3178
'    m_nFallbackStatTrak = &H317C

'    m_bIsScoped = &H387C
'    m_bIsDefusing = &H3894
'    m_szArmsModel = &H38F3
'    m_clrRender = &H70

'    m_nModelIndex = &H254
'    m_hViewModel = &H32FC
'    m_iWorldModelIndex = &H31E4

'End Enum


