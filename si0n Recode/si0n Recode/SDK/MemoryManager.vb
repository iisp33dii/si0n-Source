Imports System.Runtime.ConstrainedExecution
Imports System.Runtime.InteropServices
Imports System.Security
Imports System.Text
Imports si0n

Public Class cMemoryManager

#Region "WinAPI"
    <DllImport("kernel32.dll", SetLastError:=True)>
    Public Shared Function ReadProcessMemory(
    ByVal hProcess As Integer,
    ByVal lpBaseAddress As Integer,
    <Out()> ByVal lpBuffer As Byte(),
    ByVal dwSize As Integer,
    ByRef lpNumberOfBytesRead As Integer) As Boolean
    End Function

    <DllImport("kernel32.dll", SetLastError:=True)>
    Public Shared Function WriteProcessMemory(
    ByVal hProcess As Integer,
    ByVal lpBaseAddress As Integer,
    ByVal lpBuffer As Byte(),
    ByVal nSize As Int32,
    <Out()> ByRef lpNumberOfBytesWritten As Integer) As Boolean
    End Function

    <DllImport("kernel32.dll", SetLastError:=True)>
    Public Shared Function OpenProcess(
    ByVal dwDesiredAcces As Integer,
    ByVal bInheritHandle As Boolean,
    ByVal processID As Integer
     ) As Integer
    End Function

    <DllImport("kernel32.dll", SetLastError:=True)>
    <ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)>
    <SuppressUnmanagedCodeSecurity>
    Public Shared Function CloseHandle(ByVal hObject As IntPtr) As <MarshalAs(UnmanagedType.Bool)> Boolean
    End Function
#End Region

    Private pProcess As Process()
    Private ProcHandle As Integer
    Public ClientDLL As Integer
    Public EngineDLL As Integer

    Public Function Setup(ProcessName As String) As Boolean
        pProcess = Process.GetProcessesByName(ProcessName)
        If pProcess.Length > 0 Then
            ProcHandle = OpenProcess(2035711, False, pProcess(0).Id)
            If ProcHandle > 0 Then
                For Each [Module] As System.Diagnostics.ProcessModule In pProcess(0).Modules
                    If [Module].ModuleName = "engine.dll" Then
                        EngineDLL = [Module].BaseAddress
                    End If
                    If [Module].ModuleName = "client_panorama.dll" Then
                        ClientDLL = [Module].BaseAddress
                    End If
                    If EngineDLL > 0 And ClientDLL > 0 Then Return True
                Next
            End If
        End If
        Return False
    End Function

    Public Function rdMem(Offset As Integer, Size As Integer) As Byte()
        Dim buffer As Byte() = New Byte(Size - 1) {}
        ReadProcessMemory(ProcHandle, Offset, buffer, Size, 0)
        Return buffer
    End Function

    Public Sub WrtMem(pOffset As Integer, pBytes As Byte())
        WriteProcessMemory(ProcHandle, pOffset, pBytes, pBytes.Length, 0)
    End Sub

    Public Function rdInt(pOffset As Integer) As Integer
        Return BitConverter.ToInt32(rdMem(pOffset, 4), 0)
    End Function

    Public Sub WrtInt(pOffset As Integer, pBytes As Integer)
        WrtMem(pOffset, BitConverter.GetBytes(pBytes))
    End Sub

    Public Function rdShort(pOffset As Integer) As Short
        Return BitConverter.ToInt16(rdMem(pOffset, 4), 0)
    End Function

    Public Sub WrtShort(pOffset As Integer, pBytes As Short)
        WrtMem(pOffset, BitConverter.GetBytes(pBytes))
    End Sub

    Public Function rdFloat(pOffset As Integer) As Single
        Return BitConverter.ToSingle(rdMem(pOffset, 4), 0)
    End Function

    Public Sub WrtFloat(pOffset As Integer, pBytes As Single)
        WrtMem(pOffset, BitConverter.GetBytes(pBytes))
    End Sub

    Public Sub WrtByte(pOffset As Integer, pBytes As Byte)
        WrtMem(pOffset, BitConverter.GetBytes(CShort(pBytes)))
    End Sub

    Public Function ReadMemory(Of T)(address As Integer) As T
        Dim buffer As Byte()
        Dim length As Integer = Marshal.SizeOf(GetType(T))

        If GetType(T) Is GetType(Byte()) Then
            buffer = New Byte(length - 1) {}
        Else
            buffer = New Byte(Marshal.SizeOf(GetType(T)) - 1) {}
        End If

        If Not ReadProcessMemory(ProcHandle, New IntPtr(address), buffer, New IntPtr(buffer.Length), IntPtr.Zero) Then Return Nothing

        If GetType(T) Is GetType(Byte()) Then Return CType(CType(buffer, Object), T)

        Dim gcHandle As GCHandle = GCHandle.Alloc(buffer, GCHandleType.Pinned)
        Dim returnObject As T
        returnObject = CType(Marshal.PtrToStructure(gcHandle.AddrOfPinnedObject, GetType(T)), T)
        gcHandle.Free()
        Return returnObject
    End Function

    Public Function rdString(address As Integer) As String
        Dim buffer As Byte() = New Byte(27) {}
        ReadProcessMemory(ProcHandle, address, buffer, buffer.Length, 0)
        Return Encoding.Unicode.GetString(buffer).Trim
    End Function

    Public Function rdStringASCII(address As Integer) As String
        Dim buffer As Byte() = New Byte(27) {}
        ReadProcessMemory(ProcHandle, address, buffer, buffer.Length, 0)
        Return Encoding.ASCII.GetString(buffer).Trim
    End Function

    Public Sub WriteStruct(Of T)(address As Integer, mystruct As T)
        Dim Ptr As IntPtr = Marshal.AllocHGlobal(Marshal.SizeOf(mystruct))
        Dim ByteArray(Marshal.SizeOf(mystruct) - 1) As Byte

        Marshal.StructureToPtr(mystruct, Ptr, False)

        Marshal.Copy(Ptr, ByteArray, 0, Marshal.SizeOf(mystruct))
        Marshal.FreeHGlobal(Ptr)

        WrtMem(address, ByteArray)
    End Sub
End Class
