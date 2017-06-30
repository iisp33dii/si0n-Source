Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Text
Public Class cConfig
    Private Declare Ansi Function WritePrivateProfileString Lib "kernel32" Alias "WritePrivateProfileStringA" (ByVal lpApplicationName As String, ByVal lpKeyName As String, ByVal lpString As String, ByVal lpFileName As String) As Integer

    <DllImport("kernel32", EntryPoint:="GetPrivateProfileString")>
    Private Shared Function ReadINI(
        ByVal Sektion As String, ByVal Key As String, ByVal StandartVal As String,
        ByVal Result As StringBuilder, ByVal Size As Int32, ByVal Dateiname As String) As Int32
    End Function

    Public Structure RGBA
        Dim r As Single
        Dim g As Single
        Dim b As Single
        Dim a As Single

        Public Sub New(_r As Single, _g As Single, _b As Single, _a As Single)
            r = _r
            g = _g
            b = _b
            a = _a
        End Sub
    End Structure

    Public ConfigPath As String

    Public Sub New(_ConfigPath As String)
        ConfigPath = _ConfigPath
    End Sub

    Public Function exists()
        If File.Exists(ConfigPath) Then Return True
        Return False
    End Function

    Public Function createConfig()
        File.Create(ConfigPath)
        Return True
    End Function

    Public Function read(Sektion As String, Parameter As String)
        Dim sb As StringBuilder = New StringBuilder(1024)

        ReadINI(Sektion, Parameter, "", sb, sb.Capacity, ConfigPath)
        Return sb.ToString
    End Function

    Public Function write(Sektion As String, Parameter As String, ByVal Value As String) As Boolean
        WritePrivateProfileString(Sektion, Parameter, Value, ConfigPath)
        Return True
    End Function

    Public Function ReadRGBA(Sektion As String, Parameter As String) As RGBA
        Dim sb As StringBuilder = New StringBuilder(1024)
        ReadINI(Sektion, Parameter, "", sb, sb.Capacity, ConfigPath)

        Dim cs As String() = sb.ToString.Split("/")
        Dim cc As RGBA
        cc.r = cs(0)
        cc.g = cs(1)
        cc.b = cs(2)
        cc.a = cs(3)

        Return cc
    End Function

    Public Function WriteRGBA(Sektion As String, Parameter As String, RGBAcolor As RGBA)
        Dim cString As String = """" & RGBAcolor.r & "/" & RGBAcolor.g & "/" & RGBAcolor.b & "/" & RGBAcolor.a & """"
        WritePrivateProfileString(Sektion, Parameter, cString, ConfigPath)
        Return True
    End Function

    Public Function RGBAtoString(RGBAColor As RGBA) As String
        Dim c As RGBA = RGBAColor
        Return "red: " & c.r & ", green: " & c.g & ", blue: " & c.b & ", alpha: " & c.a
    End Function
End Class
