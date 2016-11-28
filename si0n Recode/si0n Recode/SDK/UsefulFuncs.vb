
Public Class cUsefulFuncs

    Public Declare Function GetAsyncKeyState Lib "user32" (ByVal vKey As Long) As Integer

    Public Shared Sub sleep(amount As Integer)
        Threading.Thread.Sleep(amount)
    End Sub
    Public Shared Sub wl(text As String)
        Console.WriteLine(text)
    End Sub

    Public Shared Function ConvertToBinary(xValue As Long, maxpower As Integer) As String
        Dim i As Long, x As Long, bin As String
        bin = ""
        x = xValue

        If x > 2 ^ maxpower Then Return Nothing

        If x < 0 Then bin = bin + "1" Else bin = bin + "0"

        For i = maxpower To 0 Step -1
            If x And (2 ^ i) Then
                bin = bin + "1"
            Else
                bin = bin + "0"
            End If
        Next
        Return bin
    End Function

#Region "Caption/ WindowText"
    Private Declare Function GetForegroundWindow Lib "user32" Alias "GetForegroundWindow" () As IntPtr
    Private Declare Auto Function GetWindowText Lib "user32" (ByVal hWnd As System.IntPtr, ByVal lpString As System.Text.StringBuilder, ByVal cch As Integer) As Integer

    Public Shared Function GetCaption() As String
        Dim Caption As New System.Text.StringBuilder(256)
        Dim hWnd As IntPtr = GetForegroundWindow()
        GetWindowText(hWnd, Caption, Caption.Capacity)
        Return Caption.ToString()
    End Function
#End Region

    Public Shared Sub CheckIfAppIsAllreadyRunning()
        Dim pProcess As Process() = Process.GetProcessesByName("si0n")
        Dim pID As Integer = Process.GetCurrentProcess.Id
        For i = 0 To pProcess.Length - 1
            If pProcess(i).Id <> pID Then pProcess(i).Kill()
        Next
    End Sub

    Public Shared Sub RestartIfCsgoNotValid()
        If Process.GetProcessesByName("csgo").Length <= 0 Then
            Dim RunningProcess() As Process = Process.GetProcessesByName("si0n")
            Dim ProgramPath As String = RunningProcess(0).MainModule.FileName
            RunningProcess(0).Kill()
            Process.Start(ProgramPath)
        End If
    End Sub
End Class
