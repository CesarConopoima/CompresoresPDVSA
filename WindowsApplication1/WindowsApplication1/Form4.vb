Imports System.IO
Public Class Form4
    Public P As Double(,)
    Public RED As Double(,)
    Public PlotX() As Double
    Public PlotY() As Double
    Public Qf() As Double
    Dim nu As Double
    Dim grav As Double
    Dim tol As Double
    Dim nmax As Integer
    Public iniF2 As Boolean
    Public iniF3 As Boolean
    Public pathP As String = "C:\Users\Sala de Tesistas pre\Desktop\_hardyCrossAbra\1_P.txt"
    Public pathRED As String = "C:\Users\Sala de Tesistas pre\Desktop\_hardyCrossAbra\2_RED.txt"

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim Ptext As String = File.ReadAllText(pathP)
        Dim REDtext As String = File.ReadAllText(pathRED)

        Dim RowsP As Integer = Split(Ptext, vbCr).Length
        Dim ColsP As Integer = Split(Split(Ptext, vbCr)(0), ",").Length
        Dim RowsRED As Integer = Split(REDtext, vbCr).Length
        Dim ColsRED As Integer = Split(Split(REDtext, vbCr)(0), ",").Length

        MsgBox("Texto: " & Ptext & "Filas: " & RowsP & " Cols: " & ColsP)
        MsgBox("Texto: " & REDtext & "Filas: " & RowsRED & " Cols: " & ColsRED)
        'Aquí se le da la dimensión a la matriz P 
        ReDim P(RowsP, ColsP)
        'Con esta estructura de control se rellena la matriz P
        For i = 0 To P.GetUpperBound(0) - 1
            For j = 0 To P.GetUpperBound(1) - 1
                P(i, j) = Val(Split(Split(Ptext, vbCr)(i), ",")(j))

            Next
        Next
        'Aquí se le da la dimensión a la matriz RED
        ReDim RED(RowsRED, ColsRED)
        'Con esta estructura de control se rellena la matriz RED
        For i = 0 To RED.GetUpperBound(0) - 1
            For j = 0 To RED.GetUpperBound(1) - 1
                RED(i, j) = Val(Split(Split(REDtext, vbCr)(i), ",")(j))
                MsgBox(RED(i, j) & "     ")
            Next
        Next

    End Sub

End Class