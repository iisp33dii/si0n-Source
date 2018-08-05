Imports si0n.cSDK
Imports si0n.Offsets
Imports si0n.cUsefulFuncs
Imports si0n.ENUMS
Public Class cKnifeChanger

    ''Credits for this go to Klorik on UC

    Private Structure tSkinModel
        Public off1 As Integer
        Public off2 As Integer
    End Structure

    Private SkinModel As New tSkinModel
    Private NeedIndexes As Boolean = True
    Private StartPoint As Integer
    Private KnifeID As Integer

    Public Sub KnifeChanger(KnifeModel As Integer)

        Dim WeaponBase As Integer = pLocalPlayer.ActiveWeapon.ptr
        Dim WeaponDefID As Integer = pLocalPlayer.ActiveWeapon.ID

        If NeedIndexes Then
            Dim hWeapon As Integer = mem.rdInt(pLocalPlayer.ptr + m_hViewModel)
            Dim KnifeBase As Integer = mem.rdInt(mem.ClientDLL + dwEntityList + ((hWeapon And &HFFF) - 1) * &H10)

            Select Case WeaponDefID
                Case ItemDefinitionIndex.USP
                    StartPoint = mem.rdInt(KnifeBase + m_nModelIndex)
                    KnifeID = StartPoint + 28 + (3 * KnifeModel - 3)
                    NeedIndexes = False
                Case ItemDefinitionIndex.GLOCK
                    StartPoint = mem.rdInt(KnifeBase + m_nModelIndex)
                    KnifeID = StartPoint + 273 + (3 * KnifeModel - 3)
                    NeedIndexes = False
                Case ItemDefinitionIndex.P2000
                    StartPoint = mem.rdInt(KnifeBase + m_nModelIndex)
                    KnifeID = StartPoint + 128 + (3 * KnifeModel - 3)
                    NeedIndexes = False
                Case ItemDefinitionIndex.DEAGLE
                    StartPoint = mem.rdInt(KnifeBase + m_nModelIndex)
                    KnifeID = StartPoint + 300 + (3 * KnifeModel - 3)
                    NeedIndexes = False
            End Select

            'Console.WriteLine(KnifeID)

        ElseIf pLocalPlayer.ActiveWeapon.Clip = -1 And pLocalPlayer.ActiveWeapon.Type = WeaponType.Knife And Not NeedIndexes And WeaponBase >= 1000 Then
            Dim hWeapon As Integer = mem.rdInt(pLocalPlayer.ptr + m_hViewModel)
            Dim KnifeBase As Integer = mem.rdInt(mem.ClientDLL + dwEntityList + ((hWeapon And &HFFF) - 1) * &H10)

            If KnifeBase >= 1000 Then
                setKnifeData(KnifeID)

                If pLocalPlayer.ActiveWeapon.Clip = -1 And pLocalPlayer.ActiveWeapon.Type = WeaponType.Knife And mem.rdInt(KnifeBase + m_nModelIndex) <> KnifeID Then
                    mem.WrtInt(KnifeBase + m_nModelIndex, KnifeID)
                End If

                Dim tmpSkinModel As tSkinModel = mem.ReadMemory(Of tSkinModel)(WeaponBase + m_iWorldModelIndex)

                If pLocalPlayer.ActiveWeapon.Clip = -1 And pLocalPlayer.ActiveWeapon.Type = WeaponType.Knife And tmpSkinModel.off1 <> KnifeID + 1 Or tmpSkinModel.off2 <> KnifeID Then
                    mem.WrtInt(WeaponBase + m_nModelIndex, SkinModel.off1)        
                    mem.WrtInt(WeaponBase + m_iWorldModelIndex, SkinModel.off1)
                    mem.WrtInt(WeaponBase + m_iWorldModelIndex + &H4, SkinModel.off2)
                    'mem.WriteStruct(Of tSkinModel)(WeaponBase + m_iWorldModelIndex, tmpSkinModel)
                End If

                If pLocalPlayer.ActiveWeapon.Clip = -1 And pLocalPlayer.ActiveWeapon.Type = WeaponType.Knife And mem.rdShort(WeaponBase + m_iItemDefinitionIndex) <> GetKnifeID(KnifeModel) Then
                    mem.WrtShort(WeaponBase + m_iItemDefinitionIndex, GetKnifeID(KnifeModel))
                End If

            End If
        End If
    End Sub

    Public Sub Reset()
        NeedIndexes = True
    End Sub

    Private Sub setKnifeData(knifeID As Integer)
        SkinModel.off1 = knifeID + 1
        SkinModel.off2 = knifeID
    End Sub

    Private Function GetKnifeID(ID As Integer) As Integer
        Select Case ID
            Case 1
                Return 500
            Case 2
                Return 505
            Case 3
                Return 506
            Case 4
                Return 507
            Case 5
                Return 508
            Case 6
                Return 509
            Case 7
                Return 512
            Case 8
                Return 514
            Case 9
                Return 515
            Case 10
                Return 516
            Case Else
                Return 42
        End Select
        '(m_iViewModelIndex, m_iWorldModelIndex, m_iItemDefinitionIndex)
        '(379, 380, 500), // KNIFE_BAYONET
        '(382, 383, 505), // KNIFE_FLIP
        '(385, 386, 506), // KNIFE_GUT
        '(388, 389, 507), // KNIFE_KARAMBIT
        '(391, 392, 508), // KNIFE_M9BAYONET
        '(394, 395, 509), // KNIFE_TACTICAL
        '(397, 398, 510), // KNIFE_FALCHION
        '(400, 401, 511), // KNIFE_BOWIE
        '(403, 404, 515), // KNIFE_BUTTERFLY
        '(406, 407, 516), // KNIFE_SHADOWDAGGERS
    End Function

End Class
