Imports si0n.cSDK
Imports si0n.Offsets
Imports si0n.cUsefulFuncs
Imports si0n.ENUMS
Imports System.Runtime.InteropServices

Public Class cESP
    Public Shared pEspPlayer As New cBasePlayer(Nothing)
    Dim rnd As New Random

    Public Structure Color_t
        Dim R As Single
        Dim G As Single
        Dim B As Single
        Dim A As Single
    End Structure

    Public Structure GlowObject_t
        Dim pEntity As Integer
        Dim r As Single
        Dim g As Single
        Dim b As Single
        Dim a As Single
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=16)>
        Public unk1 As Byte()
        Dim RenderWhenOccluded As Boolean
        Dim RenderWhenUnoccluded As Boolean
        Dim FullBloom As Boolean
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=12)>
        Public unk2 As Byte()
    End Structure

    Public Structure clr_s
        Dim r As Byte
        Dim g As Byte
        Dim b As Byte
        Dim a As Byte
    End Structure

    Public clr As New clr_s
    Dim Col As New Color_t

    Public Sub GlowESP(Esp As Boolean, ModelColor As Boolean, Mode As Integer)
        If Mode = 1 Then
            GlowESPplayersonly(Esp, ModelColor)
        ElseIf Mode = 2 Then
            GlowESPall(Esp, ModelColor)
        End If
    End Sub

    Public Sub GlowESPplayersonly(Esp As Boolean, ModelColor As Boolean)
        For i = 1 To MAXPLAYERS
            pEspPlayer.ptr = cBasePlayer.PointerByIndex(i)

            If pEspPlayer.Dormant Then Continue For
            If pEspPlayer.Health < 1 Then Continue For
            If pEspPlayer.Team = pLocalPlayer.Team Then Continue For

            If Esp And pEspPlayer.SpottedByMask Then
                pEspPlayer.Glow(Settings.ESPcolorEnemyVis.r / 255, Settings.ESPcolorEnemyVis.g / 255, Settings.ESPcolorEnemyVis.b / 255, Settings.ESPcolorEnemyVis.a / 255, True, False, False)
            ElseIf Esp Then
                pEspPlayer.Glow(Settings.ESPcolorEnemy.r / 255, Settings.ESPcolorEnemy.g / 255, Settings.ESPcolorEnemy.b / 255, Settings.ESPcolorEnemy.a / 255, True, False, False)
            End If

            If ModelColor Then pEspPlayer.clrRender(255, 100, 0, 255)
        Next
    End Sub

    Public GlowObject As GlowObject_t

    Public Sub GlowESPall(Esp As Boolean, ModelColor As Boolean)
        If Not GetAsyncKeyState(KeyBinds.SkinchangerKey) Then
            Dim GlowObjectManager As Integer = mem.rdInt(mem.ClientDLL + dwGlowObjectManager)
            Dim GlowObjectCount As Integer = mem.rdInt(mem.ClientDLL + dwGlowObjectManager + &H4)

            If GlowObjectCount > 1 Then
                For i = 1 To GlowObjectCount
                    If mem.rdInt(GlowObjectManager + (i * &H38)) Then
                        GlowObject = mem.ReadMemory(Of GlowObject_t)(GlowObjectManager + (i * &H38))
                        If GlowObject.pEntity Then
                            Dim ClassID As Integer = GetClassID(mem.rdInt(GlowObjectManager + (i * &H38)))
                            GlowObject = SetColor(ClassID, GlowObject, mem.rdInt(GlowObjectManager + (i * &H38)))
                            mem.WriteStruct(Of GlowObject_t)(GlowObjectManager + (i * &H38), GlowObject)
                            If ModelColor Then mem.WriteStruct(Of clr_s)(mem.rdInt(GlowObjectManager + (i * &H38)) + m_clrRender, GetRenderColorFromGlowObject(GlowObject))
                        End If
                    End If
                Next
            End If

        ElseIf GetAsyncKeyState(KeyBinds.SkinchangerKey) Then
            sleep(500)
        End If
    End Sub

    Private Function GetClassID(add As Integer) As Integer
        Dim one As Integer = mem.rdInt(add + &H8)
        Dim two As Integer = mem.rdInt(one + 2 * &H4)
        Dim three As Integer = mem.rdInt(two + 1)
        Dim ClassID As Integer = mem.rdInt(three + 20)
        Return ClassID
    End Function

    Private Function SetColor(cID As Integer, GlowObject As GlowObject_t, ptr As Integer) As GlowObject_t
        Select Case cID
            Case ClassID.CSPlayer
                pEspPlayer.ptr = ptr
                If pEspPlayer.Team <> pLocalPlayer.Team Then
                    If pEspPlayer.SpottedByMask Then
                        GlowObject.r = Settings.ESPcolorEnemyVis.r / 255
                        GlowObject.g = Settings.ESPcolorEnemyVis.g / 255
                        GlowObject.b = Settings.ESPcolorEnemyVis.b / 255
                        GlowObject.a = Settings.ESPcolorEnemyVis.a / 255

                    Else
                        GlowObject.r = Settings.ESPcolorEnemy.r / 255
                        GlowObject.g = Settings.ESPcolorEnemy.g / 255
                        GlowObject.b = Settings.ESPcolorEnemy.b / 255
                        GlowObject.a = Settings.ESPcolorEnemy.a / 255

                    End If
                Else
                    GlowObject.r = Settings.ESPcolorTeammate.r / 255
                    GlowObject.g = Settings.ESPcolorTeammate.g / 255
                    GlowObject.b = Settings.ESPcolorTeammate.b / 255
                    GlowObject.a = Settings.ESPcolorTeammate.a / 255
                End If

            Case ClassID.AK47, ClassID.DEagle, ClassID.WeaponAug, ClassID.WeaponBizon, ClassID.WeaponElite, ClassID.WeaponGalilAR, ClassID.WeaponUMP45, ClassID.WeaponMAC10, ClassID.WeaponFiveSeven, ClassID.WeaponTec9, ClassID.WeaponXM1014, ClassID.WeaponSawedoff, ClassID.WeaponAWP, ClassID.WeaponG3SG1, ClassID.WeaponGalil, ClassID.WeaponGlock, ClassID.WeaponHKP2000, ClassID.WeaponM249, ClassID.WeaponM4A1, ClassID.WeaponM3, ClassID.WeaponMP7, ClassID.WeaponMP9, ClassID.WeaponMP5Navy, ClassID.WeaponMag7, ClassID.WeaponNOVA, ClassID.WeaponNegev, ClassID.WeaponP250, ClassID.WeaponP90, ClassID.WeaponSCAR20, ClassID.SCAR17, ClassID.WeaponSG552, ClassID.WeaponSG556, ClassID.WeaponSSG08, ClassID.WeaponBizon
                GlowObject.r = Settings.ESPcolorWeapons.r / 255
                GlowObject.g = Settings.ESPcolorWeapons.g / 255
                GlowObject.b = Settings.ESPcolorWeapons.b / 255
                GlowObject.a = Settings.ESPcolorWeapons.a / 255

            Case ClassID.BaseCSGrenadeProjectile, ClassID.DecoyGrenade, ClassID.DecoyProjectile, ClassID.HEGrenade, ClassID.SmokeGrenade, ClassID.MolotovGrenade, ClassID.SmokeGrenadeProjectile, ClassID.MolotovProjectile, ClassID.IncendiaryGrenade, ClassID.Flashbang, ClassID.ParticleSmokeGrenade, ClassID.ParticleFire
                GlowObject.r = Settings.ESPcolorGrenades.r / 255
                GlowObject.g = Settings.ESPcolorGrenades.g / 255
                GlowObject.b = Settings.ESPcolorGrenades.b / 255
                GlowObject.a = Settings.ESPcolorGrenades.a / 255

            'Case ClassID.Chicken, ClassID.Hostage, ClassID.HostageCarriableProp
            '    GlowObject.R = 1.0F
            '    GlowObject.G = 0.3F
            '    GlowObject.B = 0.5F

            Case ClassID.C4, ClassID.PlantedC4
                GlowObject.r = Settings.ESPcolorBomb.r / 255
                GlowObject.g = Settings.ESPcolorBomb.g / 255
                GlowObject.b = Settings.ESPcolorBomb.b / 255
                GlowObject.a = Settings.ESPcolorBomb.a / 255

            Case Else
                GlowObject.RenderWhenOccluded = False
                GlowObject.RenderWhenUnoccluded = False
                GlowObject.FullBloom = False
                Return GlowObject
        End Select
        GlowObject.RenderWhenOccluded = True
        GlowObject.RenderWhenUnoccluded = False
        GlowObject.FullBloom = False
        Return GlowObject
    End Function

    Public Function GetRenderColorFromGlowObject(GlowObject As GlowObject_t) As clr_s
        clr.r = 255 * GlowObject.r
        clr.g = 255 * GlowObject.g
        clr.b = 255 * GlowObject.b
        clr.a = 255 * GlowObject.a
        Return clr
    End Function
End Class