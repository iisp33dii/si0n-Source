Imports si0n.Structs
Imports System.Math

Public Class cray
    'Credits to Mercy for his Raytracing resources
    'http://www.unknowncheats.me/forum/counterstrike-global-offensive/136361-external-ray-tracing-ray-aabb.html
    Dim origin, direction, directionInverse As Vec3

    Public Sub Ray(_origin As Vec3, _direction As Vec3)
        origin = _origin
        direction = _direction

        directionInverse.x = 1.0F / direction.x
        directionInverse.y = 1.0F / direction.y
        directionInverse.z = 1.0F / direction.z
    End Sub

    Public Sub New(_origin As Vec3, _direction As Vec3)
        origin = _origin
        direction = _direction
        directionInverse = New Vec3(1.0F / direction.x, 1.0F / direction.y, 1.0F / direction.z)
    End Sub

    Public Shared Function AngleToDirection(angle As Vec3) As Vec3
        angle.x = angle.x * 3.14159265 / 180
        angle.y = angle.y * 3.14159265 / 180

        Dim sinYaw As Single = Sin(angle.y)
        Dim cosYaw As Single = Cos(angle.y)

        Dim sinPitch As Single = Sin(angle.x)
        Dim cosPitch As Single = Cos(angle.x)

        Dim direction As Vec3 = angle
        direction.x = cosPitch * cosYaw
        direction.y = cosPitch * sinYaw
        direction.z = -sinPitch

        Return direction
    End Function

    Public Function Trace(leftbottom As Vec3, righttop As Vec3, ByRef distance As Single) As Boolean

        If (direction.x = 0.0F And (origin.x < Min(leftbottom.x, righttop.x) Or origin.x > Max(leftbottom.x, righttop.x))) Then Return False

        If (direction.y = 0.0F And (origin.y < Min(leftbottom.y, righttop.y) Or origin.y > Max(leftbottom.y, righttop.y))) Then Return False


        If direction.z = 0.0F And (origin.z < Min(leftbottom.z, righttop.z Or origin.z > Max(leftbottom.z, righttop.z))) Then Return False

        Dim t1 As Single = (leftbottom.x - origin.x) * directionInverse.x
        Dim t2 As Single = (righttop.x - origin.x) * directionInverse.x
        Dim t3 As Single = (leftbottom.y - origin.y) * directionInverse.y
        Dim t4 As Single = (righttop.y - origin.y) * directionInverse.y
        Dim t5 As Single = (leftbottom.z - origin.z) * directionInverse.z
        Dim t6 As Single = (righttop.z - origin.z) * directionInverse.z


        Dim tmin As Single = Max(Max(Min(t1, t2), Min(t3, t4)), Min(t5, t6))
        Dim tmax As Single = Min(Min(Max(t1, t2), Max(t3, t4)), Max(t5, t6))

        If tmax < 0 Then
            distance = tmax
            Return False
        End If


        If tmin > tmax Then
            distance = tmax
            Return False
        End If

        distance = tmin
        Return True
    End Function
End Class


