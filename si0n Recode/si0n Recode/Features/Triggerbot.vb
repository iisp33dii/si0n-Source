Imports si0n.cSDK
Imports si0n.Offsets
Imports si0n.cUsefulFuncs
Public Class cTriggerbot

    Private pTriggerPlayer As New cBasePlayer(Nothing)

    Public Sub Triggerbot(Mode As Integer)
        If GetAsyncKeyState(KeyBinds.TriggerKey) Then
            If Mode = 1 Then
                '<< bad HitboxTrigger with hardcoded hitboxes and no vischeck >>

                Aimbot.GetNextEnemyToCrosshair(8, pTriggerPlayer.ptr)
                If pTriggerPlayer.Health > 0 And Not pTriggerPlayer.Dormant Then

                    Dim bBone As Vec3 = pTriggerPlayer.BonePosition(8) + New Vec3(0, 0, 3)
                    Dim BottomHitboxHead As Vec3 = New Vec3(bBone.x - 2.54F, bBone.y - 4.145F, bBone.z - 7.0F)
                    Dim TopHitboxHead As Vec3 = New Vec3(bBone.x + 2.54F, bBone.y + 4.145F, bBone.z + 3.0F)


                    Dim hBone As Vec3 = pTriggerPlayer.BonePosition(3)
                    Dim BottomHitboxBody As Vec3 = New Vec3(hBone.x - 7.0F, hBone.y - 5.5F, hBone.z - 25.0F)
                    Dim TopHitboxBody As Vec3 = New Vec3(hBone.x + 7.0F, hBone.y + 5.5F, hBone.z + 15.0F)

                    Dim viewDirection As Vec3 = cray.AngleToDirection(Engine.ViewAngles())
                    Dim viewRay As New cray(pLocalPlayer.OriginVec + pLocalPlayer.ViewOffset, viewDirection)
                    Dim distance As Single

                    If viewRay.Trace(BottomHitboxHead, TopHitboxHead, distance) Or viewRay.Trace(BottomHitboxBody, TopHitboxBody, distance) Then
                        Dim WeaponId As Integer = pLocalPlayer.ActiveWeapon.ID
                        If WeaponId <> ENUMS.ItemDefinitionIndex.TASER Then
                            cBasePlayer.ForceAttack(0, 12, 10)
                        ElseIf WeaponId = ENUMS.ItemDefinitionIndex.TASER And GetDistance(pLocalPlayer.OriginVec, pTriggerPlayer.OriginVec) <= 128 Then
                            cBasePlayer.ForceAttack(0, 12, 10)
                        End If
                    End If
                End If

            ElseIf Mode = 2 Then
                '<< casual incross trigger >>
                Dim IncrossIndex As Integer = pLocalPlayer.IncrossIndex
                If IncrossIndex > 0 And IncrossIndex < 65 Then
                    pTriggerPlayer.ptr = cBasePlayer.PointerByIndex(IncrossIndex)
                    If Not pTriggerPlayer.Team = pLocalPlayer.Team Then
                        Dim WeaponId As Integer = pLocalPlayer.ActiveWeapon.ID
                        If WeaponId <> ENUMS.ItemDefinitionIndex.TASER Then
                            cBasePlayer.ForceAttack(0, 12, 10)
                        ElseIf WeaponId = ENUMS.ItemDefinitionIndex.TASER And GetDistance(pLocalPlayer.OriginVec, pTriggerPlayer.OriginVec) <= 128 Then
                            cBasePlayer.ForceAttack(0, 12, 10)
                        End If
                    End If
                End If
            End If
        End If
    End Sub

    Private Function GetDistance(v1 As Vec3, v2 As Vec3) As Single
        Return Math.Sqrt((v1.x - v2.x) * (v1.x - v2.x) + (v1.y - v2.y) * (v1.y - v2.y) + (v1.z - v2.z) * (v1.z - v2.z))
    End Function

End Class
