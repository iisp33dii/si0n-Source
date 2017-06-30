Imports si0n.Offsets
Imports si0n.cSDK
Public Class cEngine

    Public Function Clientstate() As Integer
        Return mem.rdInt(mem.EngineDLL + dwClientState)
    End Function

    Public Function Ingame() As Boolean
        Return mem.rdInt(Clientstate() + m_dwInGame) > 5
    End Function

    Public Function MaxPlayers() As Integer
        Return mem.rdInt(Clientstate() + &H308)
    End Function

    Public Sub SetAngles(ang As Vec3)
        Dim clienstate As Integer = Clientstate()
        mem.WrtFloat(clienstate + dwViewAngles, ang.x)
        mem.WrtFloat(clienstate + dwViewAngles + &H4, ang.y)
        'mem.WriteStruct(Of Vec3)(GetClientstate() + m_dwViewAngles, ang)
    End Sub

    Public Function ViewAngles() As Vec3
        Return mem.ReadMemory(Of Vec3)(Clientstate() + dwViewAngles)
    End Function

    Public Sub Fullupdate()
        ESP.GlowPause = True
        cUsefulFuncs.sleep(100)
        mem.WrtInt(Clientstate() + &H174, -1)
        cUsefulFuncs.sleep(100)
        ESP.GlowPause = False
    End Sub
End Class
