Imports si0n.Offsets
Imports si0n.cSDK
Public Class cBasePlayer
    Public ptr As Integer

    Public Sub New(Pointer As Integer)
        ptr = Pointer
    End Sub

    Public Shared Function LocalPlayer() As Integer
        Return mem.rdInt(mem.ClientDLL + dwLocalPlayer)
    End Function

    Public Shared Function PointerByIndex(Index As Integer) As Integer
        Return mem.rdInt(mem.ClientDLL + dwEntityList + ((Index - 1) * 16))
    End Function

    Public Function Health() As Integer
        Return mem.rdInt(ptr + m_iHealth)
    End Function

    Public Function fFlags() As Integer
        Return mem.rdInt(ptr + m_fFlags)
    End Function

    Public Function Team() As Integer
        Return mem.rdInt(ptr + m_iTeamNum)
    End Function

    Public Function Dormant() As Boolean
        Return mem.rdInt(ptr + m_bDormant)
    End Function

    Public Function FlashDuration() As Integer
        Return mem.rdFloat(ptr + m_flFlashDuration)
    End Function

    Public Function FlashMaxAlpha() As Integer
        Return mem.rdInt(ptr + m_flFlashMaxAlpha)
    End Function

    Public Function OriginVec() As Vec3
        Return mem.ReadMemory(Of Vec3)(ptr + m_vecOrigin)
    End Function

    Public Function PunchAngle() As Vec3
        Return mem.ReadMemory(Of Vec3)(ptr + m_aimPunchAngle)
    End Function

    Public Function ViewOffset() As Vec3
        Return mem.ReadMemory(Of Vec3)(ptr + m_vecViewOffset)
    End Function

    Public Function Spotted() As Boolean
        Return mem.rdInt(ptr + m_bSpotted)
    End Function

    Public Function ShotsFired() As Integer
        Return mem.rdInt(ptr + m_iShotsFired)
    End Function

    Public Function IncrossIndex()
        Return mem.rdInt(ptr + m_iCrosshairId)
    End Function

    Public Function Name(Index As Integer) As String
        Dim RadarBase As Integer = mem.rdInt(mem.ClientDLL + dwRadarBase)
        Dim Radar As Integer = mem.rdInt(RadarBase + &H20)
        Dim sName As String = mem.rdString(Radar + (&H1EC * (Index) + &H3C))
        Return sName
    End Function

    Public Function Wins(Index As Integer) As Integer
        Dim GameResources As Integer = mem.rdInt(mem.ClientDLL + dwPlayerResource)
        Return mem.rdInt(GameResources + m_iCompetitiveWins + (Index * 4))
    End Function

    Public Ranks As String() = {"Unranked", "Silver I", "Silver II", "Silver III", "Silver IV", "Silver Elite", "Silver Elite Master", "Gold Nova I", "Gold Nova II", "Gold Nova III", "Gold Nova Elite", "Master Guardian I", "Master Guardian II", "Master Guardian Elite", "Distinguished Master Guardian", "Legendary Eagle", "Legendary Eagle Master", "Supreme Master First Class", "The Global Elite"}

    Public Function Rank(Index As Integer) As String
        Dim GameResources As Integer = mem.rdInt(mem.ClientDLL + dwPlayerResource)
        Dim r As Integer = mem.rdInt(GameResources + m_iCompetitiveRanking + (Index * 4))
        If r <= Ranks.Length Then Return Ranks(r) Else Return "Error"
    End Function

    Public Function isJumping() As Boolean
        Dim fflags As Integer = mem.rdInt(ptr + m_fFlags)
        If fflags = 770 Or fflags = 774 Then Return True Else Return False
    End Function

    Public Function Immune() As Boolean
        Return mem.rdInt(ptr + m_bGunGameImmunity)
    End Function

    Public Function SpottedByMask() As Boolean
        Try
            Dim y As String = cUsefulFuncs.ConvertToBinary(mem.rdInt(ptr + m_bSpottedByMask), 30)
            Dim x As Char = y(y.Count - mem.rdInt(LocalPlayer() + &H64))
            If x = "1" Then Return True Else Return False
        Catch ex As Exception
            Return False
        End Try
    End Function

    'Thanks to Illusionisten  http://www.unknowncheats.me/forum/1592080-post53.html
    Public Function BonePosition(BoneID As Integer) As Vec3
        Dim BoneMatrix As Integer = mem.rdInt(ptr + m_dwBoneMatrix)
        Dim buffer As Byte() = New Byte(36) {}
        buffer = mem.rdMem(BoneMatrix + &H30 * BoneID + &HC, 36)
        Return New Vec3(BitConverter.ToSingle(buffer, 0), BitConverter.ToSingle(buffer, 16), BitConverter.ToSingle(buffer, 32))
    End Function

    Public Function ActiveWeapon() As cBaseWeapon
        Dim WeaponIndex As Integer = mem.rdInt(ptr + m_hActiveWeapon) And &HFFFF
        Return New cBaseWeapon(mem.rdInt(mem.ClientDLL + dwEntityList + (WeaponIndex - 1) * &H10))
    End Function


    Public Function Velocity() As Single
        Return mem.ReadMemory(Of Vec3)(LocalPlayer() + m_vecVelocity).Length
    End Function

    Public Sub Glow(Glow_r As Single, Glow_g As Single, Glow_b As Single, Glow_a As Single, Glow_rwo As Boolean, Glow_rwuo As Boolean, Glow_fb As Boolean)
        Dim GlowIndex As Integer = mem.rdInt(ptr + m_iGlowIndex)
        Dim GlowObjectManager As Integer = mem.rdInt(mem.ClientDLL + dwGlowObjectManager)
        Dim GlowObject As cESP.GlowObject_t = mem.ReadMemory(Of cESP.GlowObject_t)(GlowObjectManager + (GlowIndex * &H38))

        GlowObject.r = Glow_r
        GlowObject.g = Glow_g
        GlowObject.b = Glow_b
        GlowObject.a = Glow_a
        GlowObject.RenderWhenOccluded = Glow_rwo
        GlowObject.RenderWhenUnoccluded = Glow_rwuo
        GlowObject.FullBloom = Glow_fb

        mem.WriteStruct(Of cESP.GlowObject_t)(GlowObjectManager + (GlowIndex * &H38), GlowObject)
    End Sub

    Public Structure clr_s
        Dim r As Byte
        Dim g As Byte
        Dim b As Byte
        Dim a As Byte
    End Structure

    Public clr As New clr_s

    Public Sub clrRender(R As Byte, G As Byte, B As Byte, A As Byte)
        clr.r = R
        clr.g = G
        clr.b = B
        clr.a = A
        mem.WriteStruct(Of clr_s)(ptr + m_clrRender, clr)
    End Sub

    Public Shared Sub ForceJump(val As Integer)
        mem.WrtInt(mem.ClientDLL + dwForceJump, val)
    End Sub

    Public Shared Sub ForceAttack(Delay1 As Integer, Delay2 As Integer, Delay3 As Integer)
        cUsefulFuncs.sleep(Delay1)
        mem.WrtInt(mem.ClientDLL + dwForceAttack, 5)
        cUsefulFuncs.sleep(Delay2)
        mem.WrtInt(mem.ClientDLL + dwForceAttack, 4)
        cUsefulFuncs.sleep(Delay3)
    End Sub
End Class
