Imports si0n.cSDK
Imports si0n.Offsets
Imports si0n.ENUMS
Public Class cBaseWeapon
    Public ptr As Integer

    Public Sub New(Pointer As Integer)
        ptr = Pointer
    End Sub

    Public Function Clip()
        Return mem.rdInt(ptr + m_iClip1)
    End Function

    Public Function ID()
        Return mem.rdShort(ptr + m_iItemDefinitionIndex)
    End Function

    Public Function XuID()
        Return mem.rdInt(ptr + m_OriginalOwnerXuidLow)
    End Function


    Public Function Type() As Short
        Select Case ID()
            Case 1
                Return WeaponType.Pistol 'Deagle"
            Case 2
                Return WeaponType.Pistol 'Duals"
            Case 3
                Return WeaponType.Pistol 'FiveSeven"
            Case 4
                Return WeaponType.Pistol 'Glock"
            Case 7
                Return WeaponType.Rifle 'AK47"
            Case 8
                Return WeaponType.Rifle 'AUG"
            Case 9
                Return WeaponType.Sniper 'AWP"
            Case 10
                Return WeaponType.Rifle 'Famas"
            Case 11
                Return WeaponType.Sniper 'G3SG1"
            Case 13
                Return WeaponType.Rifle 'Galil"
            Case 14
                Return WeaponType.Heavy 'M249"
            Case 16
                Return WeaponType.Rifle 'M4A4"
            Case 17
                Return WeaponType.SMG 'Mac10"
            Case 19
                Return WeaponType.SMG 'P90"
            Case 24
                Return WeaponType.SMG 'UMP45"
            Case 25
                Return WeaponType.Shotgun 'XM1014"
            Case 26
                Return WeaponType.SMG 'Bizon"
            Case 27
                Return WeaponType.Shotgun    'Mag7"
            Case 28
                Return WeaponType.Heavy 'Negev"
            Case 29
                Return WeaponType.Shotgun 'Sawedoff"
            Case 30
                Return WeaponType.Pistol 'Tec9"
            Case 31
                Return -1'Taser"
            Case 32
                Return WeaponType.Pistol 'P2000"
            Case 33
                Return WeaponType.SMG 'MP7"
            Case 34
                Return WeaponType.SMG 'MP9"
            Case 35
                Return WeaponType.Shotgun 'Nova"
            Case 36
                Return WeaponType.Pistol 'P250"
            Case 38
                Return WeaponType.Sniper 'Scar20"
            Case 39
                Return WeaponType.Rifle 'SG556"
            Case 40
                Return WeaponType.Sniper 'SSG08"
            Case 42
                Return WeaponType.Knife 'Knife"
            Case 43
                Return WeaponType.Grenade 'Flashbang"
            Case 44
                Return WeaponType.Grenade 'Grenade"
            Case 45
                Return WeaponType.Grenade 'Smoke"
            Case 46
                Return WeaponType.Grenade 'Molotov"
            Case 47
                Return WeaponType.Grenade 'Decoy"
            Case 48
                Return WeaponType.Grenade 'Molotov"
            Case 49
                Return -1 'C4"
            Case 59
                Return WeaponType.Knife 'Knife"
            Case 60
                Return WeaponType.Rifle 'M4A1"
            Case 61
                Return WeaponType.Pistol 'USP"
            Case 63
                Return WeaponType.Pistol 'CZ75"
            Case 64
                Return WeaponType.Pistol 'Revolver"
            Case 500
                Return WeaponType.Knife 'Bayonet"
            Case 505
                Return WeaponType.Knife 'Flipknife"
            Case 506
                Return WeaponType.Knife 'Gutknife"
            Case 507
                Return WeaponType.Knife 'Karambit"
            Case 508
                Return WeaponType.Knife 'M9 Bayonet"
            Case 509
                Return WeaponType.Knife 'Huntsman"
            Case 512
                Return WeaponType.Knife 'Falchion"
            Case 515
                Return WeaponType.Knife 'Butterfly
            Case 516
                Return WeaponType.Knife 'Knife"
            Case Else
                Return -1 'Unknown Weapon"
        End Select
    End Function

    Public Function Name() As String
        Select Case ID()
            Case 1
                Return "Deagle"
            Case 2
                Return "Duals"
            Case 3
                Return "FiveSeven"
            Case 4
                Return "Glock"
            Case 7
                Return "AK47"
            Case 8
                Return "AUG"
            Case 9
                Return "AWP"
            Case 10
                Return "Famas"
            Case 11
                Return "G3SG1"
            Case 13
                Return "Galil"
            Case 14
                Return "M249"
            Case 16
                Return "M4A4"
            Case 17
                Return "Mac10"
            Case 19
                Return "P90"
            Case 24
                Return "UMP45"
            Case 25
                Return "XM1014"
            Case 26
                Return "Bizon"
            Case 27
                Return "Mag7"
            Case 28
                Return "Negev"
            Case 29
                Return "Sawedoff"
            Case 30
                Return "Tec9"
            Case 31
                Return "Taser"
            Case 32
                Return "P2000"
            Case 33
                Return "MP7"
            Case 34
                Return "MP9"
            Case 35
                Return "Nova"
            Case 36
                Return "P250"
            Case 38
                Return "Scar20"
            Case 39
                Return "SG556"
            Case 40
                Return "SSG08"
            Case 42
                Return "Knife"
            Case 43
                Return "Flashbang"
            Case 44
                Return "Grenade"
            Case 45
                Return "Smoke"
            Case 46
                Return "Molotov"
            Case 47
                Return "Decoy"
            Case 48
                Return "Molotov"
            Case 49
                Return "C4"
            Case 59
                Return "Knife"
            Case 60
                Return "M4A1"
            Case 61
                Return "USP"
            Case 63
                Return "CZ75"
            Case 64
                Return "Revolver"
            Case 500
                Return "Bayonet"
            Case 505
                Return "Flipknife"
            Case 506
                Return "Gutknife"
            Case 507
                Return "Karambit"
            Case 508
                Return "M9 Bayonet"
            Case 509
                Return "Huntsman"
            Case 512
                Return "Falchion"
            Case 515
                Return "Butterfly "
            Case 516
                Return "Knife"
            Case Else
                Return "Unknown Weapon"
        End Select
    End Function

End Class
