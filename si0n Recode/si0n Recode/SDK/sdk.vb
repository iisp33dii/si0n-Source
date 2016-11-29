Imports si0n.Offsets
Public Class cSDK
    Public Const MAXPLAYERS = 32
    Public Const GameCaption As String = "Counter-Strike: Global Offensive"

    Public Shared Caption As String = String.Empty
    Public Shared InGame As Boolean
    Public Shared TabX As Boolean

    Public Shared mem As New cMemoryManager
    Public Shared Engine As New cEngine
    Public Shared Settings As New cSettings
    Public Shared FindPattern As New cFindPattern
    Public Shared cfg As New cConfig(System.AppDomain.CurrentDomain.BaseDirectory & "Config.ini")
    Public Shared ofs As New cConfig(System.AppDomain.CurrentDomain.BaseDirectory & "Offsets.ini")

    Public Shared Misc As New cMisc
    Public Shared Aimbot As New cAimbot
    Public Shared ESP As New cESP
    Public Shared Triggerbot As New cTriggerbot
    Public Shared KnifeChanger As New cKnifeChanger
    Public Shared SkinChanger As New cSkinchanger

    Public Shared pLocalPlayer As New cBasePlayer(Nothing)
End Class
