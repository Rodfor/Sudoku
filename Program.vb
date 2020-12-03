Imports System

Module Program
    Dim Cellen As New Lijst


    Sub Main()
        Dim x As Short = 1
        Dim y As Short = 1
        Dim z As Short = 1

        Console.WriteLine("Start")

        While x < 9
            y = 1
            While y < 9
                Dim C As New Cell

                Cellen.Add(C)
                y += 1
            End While
            x += 1
        End While

        Console.WriteLine("Cellen gemaakt")

        For Each C As Cell In Cellen
            If C.X = 1 AndAlso C.Y = 7 Then C.Waarde = 4
            If C.X = 2 AndAlso C.Y = 1 Then C.Waarde = 8

            If C.X = 2 AndAlso C.Y = 3 Then C.Waarde = 3
            If C.X = 2 AndAlso C.Y = 6 Then C.Waarde = 4

            If C.X = 3 AndAlso C.Y = 8 Then C.Waarde = 1
            If C.X = 3 AndAlso C.Y = 9 Then C.Waarde = 9
            If C.X = 3 AndAlso C.Y = 6 Then C.Waarde = 7

            If C.X = 4 AndAlso C.Y = 2 Then C.Waarde = 5
            If C.X = 4 AndAlso C.Y = 3 Then C.Waarde = 4
            If C.X = 4 AndAlso C.Y = 4 Then C.Waarde = 1
            If C.X = 4 AndAlso C.Y = 6 Then C.Waarde = 8

            If C.X = 5 AndAlso C.Y = 8 Then C.Waarde = 6

            If C.X = 6 AndAlso C.Y = 9 Then C.Waarde = 7
            If C.X = 6 AndAlso C.Y = 1 Then C.Waarde = 2
            If C.X = 6 AndAlso C.Y = 4 Then C.Waarde = 9

            If C.X = 7 AndAlso C.Y = 1 Then C.Waarde = 3
            If C.X = 7 AndAlso C.Y = 2 Then C.Waarde = 8

            If C.X = 8 AndAlso C.Y = 7 Then C.Waarde = 3
            If C.X = 8 AndAlso C.Y = 8 Then C.Waarde = 5
            If C.X = 8 AndAlso C.Y = 1 Then C.Waarde = 4
            If C.X = 8 AndAlso C.Y = 6 Then C.Waarde = 2

            If C.X = 9 AndAlso C.Y = 4 Then C.Waarde = 6
            If C.X = 9 AndAlso C.Y = 9 Then C.Waarde = 1
            If C.X = 9 AndAlso C.Y = 2 Then C.Waarde = 7

            Select Case C.X
                Case 1 To 3
                    Select Case C.Y
                        Case 1 To 3
                            C.Z = 1
                        Case 4 To 6
                            C.Z = 4
                        Case 7 To 9
                            C.Z = 7
                    End Select
                Case 4 To 6
                    Select Case C.Y
                        Case 1 To 3
                            C.Z = 8
                        Case 4 To 6
                            C.Z = 5
                        Case 7 To 9
                            C.Z = 2
                    End Select
                Case 7 To 9
                    Select Case C.Y
                        Case 1 To 3
                            C.Z = 9
                        Case 4 To 6
                            C.Z = 3
                        Case 7 To 9
                            C.Z = 6
                    End Select
            End Select
        Next

        Console.WriteLine("Start solving")

        If Solve() Then
            For Each C As Cell In Cellen
                Console.WriteLine($"x = {C.X}, Y = {C.Y}, Val = {C.Waarde}")
            Next
        Else
            Console.WriteLine("Geen uitkomst gevonden")
            For Each C As Cell In Cellen
                Console.WriteLine($"x = {C.X}, Y = {C.Y}, Val = {C.Waarde}")
            Next
        End If
        'Select Case C.X
        '    Case 1
        '        X1.Add(C)
        '    Case 2
        '        X2.Add(C)
        '    Case 3
        '        x3.Add(C)
        '    Case 4
        '        X4.Add(C)
        '    Case 5
        '        X5.Add(C)
        '    Case 6
        '        x6.Add(C)
        '    Case 7
        '        X7.Add(C)
        '    Case 8
        '        X8.Add(C)
        '    Case 9
        '        X9.Add(C)
        'End Select

        'Select Case C.Y
        '    Case 1
        '        Y1.Add(C)
        '    Case 2
        '        Y2.Add(C)
        '    Case 3
        '        Y3.Add(C)
        '    Case 4
        '        Y4.Add(C)
        '    Case 5
        '        Y5.Add(C)
        '    Case 6
        '        Y6.Add(C)
        '    Case 7
        '        Y7.Add(C)
        '    Case 8
        '        Y8.Add(C)
        '    Case 9
        '        Y9.Add(C)
        'End Select

    End Sub

    Public Function Solve()
        Dim C As Cell
        Dim num As Short

        C = Cellen.GetFirstEmpty()

        If C Is Nothing Then
            Return True
        End If

        For num = 1 To 9
            If CheckConstraint(C, num) Then
                C.Waarde = num
            End If

            Console.Write("a")

            If Solve() Then
                Return True
            End If

            Console.Write("b")

            C.Waarde = 0
        Next

        Return False
    End Function


    Public Function CheckConstraint(cel, num)
        Return Not inX(cel, num) AndAlso Not inY(cel, num) AndAlso Not inZ(cel, num)
    End Function

    Public Function inX(cel, num)

        For Each C As Cell In Cellen
            If C.X = cel.x Then
                If C.Waarde = num Then
                    Return True
                End If
            End If
        Next

        Return False
    End Function

    Public Function inY(cel, num)
        For Each C As Cell In Cellen
            If C.Y = cel.Y Then
                If C.Waarde = num Then
                    Return True
                End If
            End If
        Next

        Return False
    End Function

    Public Function inZ(cel, num)
        For Each C As Cell In Cellen
            If C.Z = cel.Z Then
                If C.Waarde = num Then
                    Return True
                End If
            End If
        Next

        Return False
    End Function

End Module

Public Class Cell
    Public Property X As Short

    Public Property Y As Short

    Public Property Z As Short

    Public Property Waarde As Short = 0


End Class


    Public Class Lijst
        Inherits List(Of Cell)

    Public Function GetFirstEmpty()
        Dim I As Short = 0

        While I < Me.Count()
            If Me.Item(I).Waarde = 0 Then
                Return Me.Item(I)
            End If
            I += 1
        End While


        Return Nothing
    End Function
End Class
