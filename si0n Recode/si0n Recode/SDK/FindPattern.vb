Imports System.Globalization
Imports System.Text.RegularExpressions
Imports si0n.cSDK
Public Class cFindPattern

    Public Function Scanf(Dll As Integer, Pattern As String, Extra As Integer, Offset As Integer, ModeSubtract As Boolean) As Integer
        Dim Off As Integer = BitConverter.ToInt32(mem.rdMem(AobScan(Dll, &H1800000, Pattern, 0) + Extra, 4), 0) + Offset
        If ModeSubtract Then Off -= Dll
        Return Off
    End Function

    Private Function AobScan(ByVal Base As Integer, ByVal _Range As Integer, ByVal Signature As String, ByVal Instance As Integer) As Integer
        'Credits to whoever the fuck created this :)
        If (Signature <> String.Empty) Then
            Dim New_String As String = Regex.Replace(Signature.Replace("??", "3F"), "[^a-fA-F0-9]", "")
            Dim Count As Integer = -1
            Dim SearchFor As Byte() = New Byte((New_String.Length / 2) - 1) {}
            For i As Integer = 0 To SearchFor.Length - 1
                SearchFor(i) = Byte.Parse(New_String.Substring(i * 2, 2), NumberStyles.HexNumber)
            Next i
            Dim Sin As Byte() = mem.rdMem(Base, _Range)

            Dim Z As Integer = 0, P As Integer = 0
            Dim iEnd As Integer = If(SearchFor.Length < &H20, SearchFor.Length, &H20)
            Dim sBytes As Integer() = New Integer(&H100 - 1) {}
            For j As Integer = 0 To iEnd - 1
                If (SearchFor(j) = &H3F) Then
                    Z = (Z Or (CInt(1) << ((iEnd - j) - 1)))
                End If
            Next j
            If (Z <> 0) Then
                For k As Integer = 0 To sBytes.Length - 1
                    sBytes(k) = Z
                Next k
            End If
            Z = 1
            Dim index As Integer = (iEnd - 1)
            Do While (index >= 0)
                sBytes(SearchFor(index)) = (sBytes(SearchFor(index)) Or Z)
                index -= 1
                Z = (Z << 1)
            Loop
            Do While (P <= (Sin.Length - SearchFor.Length))
                Z = (SearchFor.Length - 1)
                Dim last As Integer = SearchFor.Length
                Dim m As Integer = -1
                Do While (m <> 0)
                    m = (m And sBytes(Sin(P + Z)))
                    If (m <> 0) Then
                        If (Z = 0) Then
                            Count += 1
                            If Count = Instance Then
                                Return Base + P
                            End If
                            P += 2
                        End If
                        last = Z
                    End If
                    Z -= 1
                    m = (m << 1)
                Loop
                P += last
            Loop
        End If
        Return -1
    End Function
End Class
