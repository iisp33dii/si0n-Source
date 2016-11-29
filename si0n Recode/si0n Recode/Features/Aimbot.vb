Imports si0n.cSDK
Imports si0n.Offsets
Imports si0n.cUsefulFuncs
Public Class cAimbot

    Private Target As New cBasePlayer(Nothing)
    Private bOnce As Boolean = True

    Public Structure UserCmd_t
        Dim command_number As Integer
        Dim tick_count As Integer
        Dim viewangles As Vec3
        Dim aimdirection As Vec3
        Dim forwardmove As Single
        Dim sidemove As Single
        Dim upmove As Single
        Dim buttons As Integer
        Dim impulse As Byte
        Dim weaponselect As Integer
        Dim weaponsubtype As Integer
        Dim random_seed As Integer
        Dim mousedx As Short
        Dim mousedy As Short
        Dim hasbeenpredicted As Boolean
    End Structure

    Public Sub Aimbot(Aimspot As Integer, Fov As Single, Smooth As Integer, FovPistols As Single, SmoothPistol As Integer, FovSnipers As Single, SmoothSnipers As Integer)
        If GetAsyncKeyState(1) Then
            If pLocalPlayer.ActiveWeapon.Clip > 0 Then

                Dim _FOV As Single
                Dim _Smooth As Integer
                Dim _StopAfter1Shot As Boolean

                Select Case pLocalPlayer.ActiveWeapon.Type
                    Case ENUMS.WeaponType.Pistol
                        _FOV = FovPistols
                        _Smooth = SmoothPistol
                        _StopAfter1Shot = True
                        Aimspot = 6
                    Case ENUMS.WeaponType.Sniper
                        _FOV = FovSnipers
                        _Smooth = SmoothSnipers
                        _StopAfter1Shot = True
                    Case ENUMS.WeaponType.Rifle
                        _FOV = Fov
                        _Smooth = Smooth
                        _StopAfter1Shot = False
                    Case ENUMS.WeaponType.SMG
                        _FOV = Fov
                        _Smooth = Smooth
                        _StopAfter1Shot = False
                    Case ENUMS.WeaponType.Heavy
                        _FOV = Fov
                        _Smooth = Smooth
                        _StopAfter1Shot = False
                    Case Else
                        _FOV = 0
                        _Smooth = 10000
                End Select

                If bOnce Then
                    _FOV /= 10

                    '  wl(GetNextEnemyToCrosshair(6, 0) & " " & GetNextEnemyToCrosshairRangebased(6, 0) / 10)

                    If GetTargetFov(Aimspot, Settings.RangeBased) <= _FOV Then
                        If Not Target.ptr = Nothing Then bOnce = False
                    Else
                        bOnce = True
                    End If
                End If

                If Not bOnce And Target.ptr And Not Target.isJumping Then

                    Dim Ang As New Vec3(0, 0, 0)

                    If _StopAfter1Shot And pLocalPlayer.ShotsFired < 1 Then
                        Dim Aimspot2 As Integer = 6
                        If pLocalPlayer.ActiveWeapon.ID = ENUMS.ItemDefinitionIndex.AWP Then Aimspot2 = 4
                        Ang = SmoothAng(ClampAngle(CalcAngle(pLocalPlayer.OriginVec, Target.BonePosition(6), pLocalPlayer.PunchAngle, pLocalPlayer.ViewOffset, 2, 2)), _Smooth)
                    ElseIf Not _StopAfter1Shot And Target.SpottedByMask Then
                        Ang = SmoothAng(ClampAngle(CalcAngle(pLocalPlayer.OriginVec, Target.BonePosition(Aimspot), pLocalPlayer.PunchAngle, pLocalPlayer.ViewOffset, 2, 2)), _Smooth)
                    End If

                    If Ang.x + Ang.y + Ang.z <> 0 Then Engine.SetAngles(ClampAngle(Ang)) ' SetAnglesSilent(Ang) 

                End If

                    If Not IsValid(Target) Then
                    sleep(Settings.SleepTime)
                    bOnce = True
                End If

            End If
        Else
            bOnce = True
        End If
    End Sub

        'dis doesnt work
    'Private Sub SetAnglesSilent(Angle As Vec3)

      '  Dim userCMDSequenceNum As Integer = 0
     '   Dim oldAngles As Vec3
     '   Dim userCMD As Integer

       ' Dim curSequenceNum As Integer = mem.rdInt(Engine.Clientstate + &H4C7C) + 1
      '  userCMD += (curSequenceNum Mod 150) * &H64

       ' While userCMDSequenceNum <> curSequenceNum
        '    oldAngles = Engine.ViewAngles
       '     userCMDSequenceNum = mem.rdInt(userCMD + &H4)
      '      wl(curSequenceNum & " " & userCMDSequenceNum)
      '  End While

      '  Angle = ClampAngle(Angle)

      '  wl(mem.ReadMemory(Of Vec3)(userCMD + &HC).tostring)

     '   For i = 0 To 20
            mem.WriteStruct(Of Vec3)(userCMD + &HC, Angle)
     '   Next
      '  Engine.SetAngles(oldAngles)
      '  sleep(6)

  '  End Sub

    'Private Function SetSendPacket(mode As Boolean)
    '    If mode Then
    '        mem.WrtByte(dwsendpacket, 1)
    '    Else
    '        mem.WrtByte(dwsendpacket, 0)
    '    End If
    'End Function

    Private Function IsValid(trgt As cBasePlayer)
        If trgt.Health > 0 And Not trgt.Dormant Then Return True Else Return False
    End Function

    Private Function GetTargetFov(Bone As Integer, Rangebased As Boolean) As Single
        If Rangebased Then
            Return GetNextEnemyToCrosshairRangebased(Bone, Target.ptr) / 10
        Else
            Return GetNextEnemyToCrosshair(Bone, Target.ptr)
        End If
    End Function

    Public Function GetNextEnemyToCrosshairRangebased(Bone As Integer, ByRef pPointer As Integer) As Single
        Dim Fov As Single
        Dim pAngles As Vec3 = Engine.ViewAngles()

        Dim PlayerArray(32) As Integer
        Dim AngleArray(32) As Single


        For i As Integer = 1 To 32
            Dim CurPlayer As New cBasePlayer(cBasePlayer.PointerByIndex(i))

            Dim pAngle As Vec3 = CurPlayer.BonePosition(Bone)
            pAngle = CalcAngle(pLocalPlayer.OriginVec, pAngle, pLocalPlayer.PunchAngle, pLocalPlayer.ViewOffset, 2, 2)
            pAngle = ClampAngle(pAngle)
            Dim iDiff As Single = Get3dDistance(pAngle, pAngles)

            PlayerArray(i) = CurPlayer.ptr
            AngleArray(i) = iDiff
        Next

        Dim ClosestPlayer As Integer = 0
        Dim ClosestAngle As Single = 360

        For i As Integer = 1 To 32
            Dim pPlayer As New cBasePlayer(PlayerArray(i))
            Dim pAngle As Single = AngleArray(i)

            Dim CurPlayerTeam As Integer = pPlayer.Team
            Dim Dormant As Boolean = pPlayer.Dormant
            Dim Health As Integer = pPlayer.Health

            Dim pOriginVec As Vec3 = pPlayer.OriginVec
            pOriginVec.z += 64

            If CurPlayerTeam <> pLocalPlayer.Team And (Not Dormant) And Health > 0 And pAngle < ClosestAngle Then
                ClosestPlayer = pPlayer.ptr
                ClosestAngle = pAngle
                Fov = pAngle

            End If
        Next

        Dim pNearestPlayer As New cBasePlayer(ClosestPlayer)
        Dim myAngle As Vec3 = ClampAngle(Engine.ViewAngles + pLocalPlayer.PunchAngle)
        Dim enemyAngle As Vec3 = CalcAngle(pLocalPlayer.OriginVec, pNearestPlayer.BonePosition(Bone), pLocalPlayer.PunchAngle, pLocalPlayer.ViewOffset, 2, 2)

        Dim AngleY = enemyAngle.y - myAngle.y
        If AngleY < 0 Then AngleY *= -1

        Dim AngleX = enemyAngle.x - myAngle.x
        If AngleX < 0 Then AngleX *= -1

        Dim r = Get3dDistance(pLocalPlayer.OriginVec, pNearestPlayer.OriginVec)

        Dim FovFractionY = Math.Sqrt(2 * r * r - 2 * r * r * Math.Cos(Deg2Rad(AngleY)))
        Dim FovFractionX = Math.Sqrt(2 * r * r - 2 * r * r * Math.Cos(Deg2Rad(AngleX)))

        Fov = Math.Sqrt((FovFractionY * FovFractionY) + (FovFractionX * FovFractionX))

        pPointer = ClosestPlayer
        Return Fov
    End Function

    Public Function Deg2Rad(input As Integer)
        Return input * Math.PI / 180
    End Function

    Public Function GetNextEnemyToCrosshair(Bone As Integer, ByRef pPointer As Integer) As Single
        Dim Fov As Single
        Dim pAngles As Vec3 = Engine.ViewAngles()

        Dim PlayerArray(32) As Integer
        Dim AngleArray(32) As Single


        For i As Integer = 1 To 32
            Dim CurPlayer As New cBasePlayer(cBasePlayer.PointerByIndex(i))

            Dim pAngle As Vec3 = CurPlayer.BonePosition(Bone)
            pAngle = CalcAngle(pLocalPlayer.OriginVec, pAngle, pLocalPlayer.PunchAngle, pLocalPlayer.ViewOffset, 2, 2)
            pAngle = ClampAngle(pAngle)
            Dim iDiff As Single = Get3dDistance(pAngle, pAngles)

            PlayerArray(i) = CurPlayer.ptr
            AngleArray(i) = iDiff
        Next

        Dim ClosestPlayer As Integer = 0
        Dim ClosestAngle As Single = 360

        For i As Integer = 1 To 32
            Dim pPlayer As New cBasePlayer(PlayerArray(i))
            Dim pAngle As Single = AngleArray(i)

            Dim CurPlayerTeam As Integer = pPlayer.Team
            Dim Dormant As Boolean = pPlayer.Dormant
            Dim Health As Integer = pPlayer.Health

            Dim pOriginVec As Vec3 = pPlayer.OriginVec
            pOriginVec.z += 64

            If CurPlayerTeam <> pLocalPlayer.Team And (Not Dormant) And Health > 0 And pAngle < ClosestAngle Then
                ClosestPlayer = pPlayer.ptr
                ClosestAngle = pAngle
                Fov = pAngle

            End If
        Next
        pPointer = ClosestPlayer
        Return Fov
    End Function

    Private Function CalcAngle(PlayerPosition As Vec3, EnemyPosition As Vec3, PunchAngle As Vec3, ViewOffset As Vec3, YawRecoilReductionFactor As Single, PitchRecoilReductionFactor As Single)
        Dim AimAngle As New Vec3(0, 0, 0)
        Dim Delta As New Vec3(PlayerPosition.x - EnemyPosition.x, PlayerPosition.y - EnemyPosition.y, (PlayerPosition.z + ViewOffset.z) - EnemyPosition.z)
        Dim Hyp As Single = Math.Sqrt(Delta.x * Delta.x + Delta.y * Delta.y)

        AimAngle.x = Math.Atan(Delta.z / Hyp) * 57.29578F - PunchAngle.x * YawRecoilReductionFactor
        AimAngle.y = Math.Atan(Delta.y / Delta.x) * 57.29578F - PunchAngle.y * PitchRecoilReductionFactor
        AimAngle.z = 0

        If Delta.x >= 0.0 Then AimAngle.y += 180.0F
        Return ClampAngle(AimAngle)
    End Function

    Private Function ClampAngle(ViewAngle As Vec3)
        If ViewAngle.x > 89.0F And ViewAngle.x <= 180.0F Then ViewAngle.x = 89.0F
        If ViewAngle.x > 180.0F Then ViewAngle.x -= 360
        If ViewAngle.x < -89.0F Then ViewAngle.x = -89.0F
        If ViewAngle.y > 180.0F Then ViewAngle.y -= 360
        If ViewAngle.y < -180.0F Then ViewAngle.y += 360
        If ViewAngle.z <> 0 Then ViewAngle.z = 0
        Return ViewAngle
    End Function

    Public Function Get3dDistance(PlayerPosition As Vec3, EnemyPosition As Vec3)
        Return Math.Sqrt(Math.Pow(EnemyPosition.x - PlayerPosition.x, 2.0F) + Math.Pow(EnemyPosition.y - PlayerPosition.y, 2.0F) + Math.Pow(EnemyPosition.z - PlayerPosition.z, 2.0F))
    End Function

    Public Function SmoothAng(AimAng As Vec3, SmoothPercent As Single)
        If SmoothPercent <= 10 Then Return ClampAngle(AimAng)
        SmoothPercent = SmoothPercent / 10
        Dim Delta As New Vec3(0, 0, 0)
        Dim ViewAngle As Vec3 = Engine.ViewAngles

        Delta.x = ViewAngle.x - AimAng.x
        Delta.y = ViewAngle.y - AimAng.y
        Delta.z = ViewAngle.z - AimAng.z
        Delta = ClampAngle(Delta)

        AimAng.x = ViewAngle.x - Delta.x / SmoothPercent
        AimAng.y = ViewAngle.y - Delta.y / SmoothPercent
        AimAng.z = ViewAngle.z - Delta.z / SmoothPercent

        Return ClampAngle(AimAng)
    End Function


End Class
