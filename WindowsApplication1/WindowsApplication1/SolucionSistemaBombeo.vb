Imports System.Windows.Forms.DataVisualization.Charting
Imports System.IO
Public Class SolucionSistemaBombeo
    Public P As Double(,)
    Public RED As Double(,)
    Public PlotX() As Double
    Public PlotY() As Double
    Public Qf() As Double
    Dim nu As Double = 0.000001
    Dim grav As Double = 9.8
    Dim tol As Double = 0.1
    Dim nmax As Integer = 200
    Public iniF2 As Boolean
    Public iniF3 As Boolean
    'Public pathP As String = "C:\Users\Sala de Tesistas pre\Desktop\_hardyCrossAbra\1_P.txt"
    'Public pathRED As String = "C:\Users\Sala de Tesistas pre\Desktop\_hardyCrossAbra\2_RED.txt"

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'Dim Ptext As String = File.ReadAllText(pathP)
        'Dim REDtext As String = File.ReadAllText(pathRED)

        Dim Ptext As String = "1,0.1,0.001,1000,0,0,-100,60;0.5,0.1,0.001,1000,0,0,0,0;0.25,0.1,0.001,1000,0,0,0,0;0.5,0.1,0.001,1000,0,0,0,0;0.75,0.1,0.001,1000,0,0,0,0;0.25,0.1,0.001,7000,0,0,0,0"
        Dim REDtext As String = "1,0,0,1,1,0,-30;0,1,1,-1,0,0,0;-1,-1,0,0,0,-1,-35"
        'Aquí se definen las dimensiones de la matrices P y RED
        Dim RowsP As Integer = Split(Ptext, ";").Length
        Dim ColsP As Integer = Split(Split(Ptext, ";")(0), ",").Length
        Dim RowsRED As Integer = Split(REDtext, ";").Length
        Dim ColsRED As Integer = Split(Split(REDtext, ";")(0), ",").Length

        'Esta sección engloba la definisión de las matrices P y RED
        'MsgBox("Texto: " & Ptext & "Filas: " & RowsP & " Cols: " & ColsP)
        'MsgBox("Texto: " & REDtext & "Filas: " & RowsRED & " Cols: " & ColsRED)
        'Aquí se le da la dimensión a la matriz P 
        ReDim P(RowsP, ColsP)
        'Con esta estructura de control se rellena la matriz P
        For i = 0 To P.GetUpperBound(0) - 1
            For j = 0 To P.GetUpperBound(1) - 1
                P(i, j) = Val(Split(Split(Ptext, ";")(i), ",")(j))
            Next
        Next
        'Aquí se le da la dimensión a la matriz RED
        ReDim RED(RowsRED, ColsRED)
        'Con esta estructura de control se rellena la matriz RED
        For i = 0 To RED.GetUpperBound(0) - 1
            For j = 0 To RED.GetUpperBound(1) - 1
                RED(i, j) = Val(Split(Split(REDtext, ";")(i), ",")(j))
            Next
        Next
        ' Aquí termina la definición de las matrices P y RED
        '-------------------------------------------------------------------------------
        '-------------------------------------------------------------------------------
        '-------------------------------------------------------------------------------
        ' Aquí comienzan las definiciones para el método numérico de cálculo de Hardy cross

        Dim Caudales As Integer = P.GetUpperBound(0)
        Dim Ciclos As Integer = RED.GetUpperBound(0)
        Dim Logic(Caudales) As Double
        Dim Qant(Caudales) As Double
        Dim Rey(Caudales) As Double
        Dim f(Caudales) As Double
        Dim r(Caudales) As Double
        Dim Sentido(Caudales) As Integer
        Dim RQ(Ciclos) As Double
        Dim G(Ciclos) As Double
        Dim DQ(Ciclos) As Double
        Dim n As Integer = 0
        Dim Q(Caudales) As Double
        Dim x = New Double() {0.0}
        Dim y = New Double() {P(0, 0)}

        For i = 0 To Caudales - 1
            Logic(i) = 1
            Qant(i) = 0
            Q(i) = P(i, 0)
        Next
        For j = 0 To Ciclos - 1
            RQ(j) = 0
            G(j) = 0
            DQ(j) = 0
        Next

        While Norm(Logic) > 0

            For i = 0 To Caudales - 1
                Rey(i) = Math.Abs(4 * Q(i) / (nu * 3.14159265 * P(i, 1)))
                f(i) = ff(Rey(i), P(i, 2), P(i, 1))
                r(i) = 8 * f(i) / (3.14159265 ^ 2 * grav * P(i, 1) ^ 5) * (P(i, 3) + P(i, 1) * P(i, 4) / f(i))
                Sentido(i) = Math.Sign(Q(i))
            Next

            For i = 0 To Ciclos - 1
                RQ(i) = 0
                G(i) = 0
                For j = 0 To Caudales - 1
                    RQ(i) += RED(i, j) * (r(j) * Q(j) * Math.Abs(Q(j)) - Sentido(j) * (P(j, 5) * Q(j) ^ 2 + P(j, 6) * Math.Abs(Q(j)) + P(j, 7)))
                    G(i) += Math.Abs(RED(i, j)) * (2 * r(j) * Math.Abs(Q(j)))
                    G(i) += RED(i, j) * (-Sentido(j) * (P(j, 6) + 2 * P(j, 5) * Math.Abs(Q(j))))
                Next
                RQ(i) += RED(i, Caudales)
                DQ(i) = -RQ(i) / G(i)
            Next

            For j = 0 To Caudales - 1
                Qant(j) = Q(j)

                For i = 0 To Ciclos - 1
                    Q(j) += RED(i, j) * DQ(i)
                Next
            Next

            For i = 0 To Caudales - 1
                If (Math.Abs(Math.Abs(Qant(i)) - Math.Abs(Q(i))) / Math.Abs(Q(i)) * 100) < tol Then
                    Logic(i) = 0
                End If
            Next
            n += 1
            ReDim Preserve x(x.GetUpperBound(0) + 1)
            ReDim Preserve y(y.GetUpperBound(0) + 1)
            x(n) = n
            y(n) = Q(0)
            'MsgBox("Nmax es: " & nmax)
            'MsgBox("n es: " & n)
            If n > nmax Then
                MsgBox("Algo va mal, se terminaron las iteraciones, ultimo caudal: " & Val(Q(0)))
                MsgBox("Iteraciones: " & n)
                Exit While
            End If

        End While
        Qf = Q
        PlotX = x
        PlotY = y

        Chart1.Series.Clear()

        Dim series1 As New Series()
        Dim k As Integer = 0
        For Each value As Decimal In Qf
            series1.Points.AddXY(k, value * 1000)
            k = k + 1
        Next
        Chart1.Series.Add(series1)
        Chart1.Series("Series1").MarkerStyle = MarkerStyle.Square
        Chart1.Titles.Clear()
        Chart1.Titles.Add("Distribución de caudales en las tuberias numeradas")
        Chart1.ChartAreas(0).AxisX.Title = "Numeración de tuberias"
        Chart1.ChartAreas(0).AxisY.Title = "Cuadal en L/s"
        Chart1.ChartAreas(0).AxisX.MajorGrid.Enabled = False
        Chart1.ChartAreas(0).AxisY.MajorGrid.Enabled = False
        Chart1.BringToFront()
        'MsgBox(Math.Round(Val(Qf(0)), 5))
        'Dim Chart1 As New Chart
        'Chart1.Series(0).Points.DataBindXY(PlotX, PlotY)
        'Chart1.Show()

    End Sub
    'funciones aux para solucionar el hardyCross (la normal de un vector, la distancia)
    Public Function Norm(ByVal vector() As Double) As Double
        Dim sum As Double = 0
        For i = 0 To vector.GetUpperBound(0) - 1
            sum += vector(i) ^ 2
        Next
        Norm = (sum) ^ 0.5
    End Function
    'funciones aux para solucionar el hardycross (factor de fricción )
    Public Function ff(ByVal Rey As Double, ByVal ep As Double, ByVal D As Double) As Double
        ff = 1.325 * (Math.Log(0.27 * ep / D + 5.74 * (Rey) ^ (-0.9))) ^ (-2)
    End Function


    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'CompresoresDataSet1.Codo' table. You can move, or remove it, as needed.

    End Sub

    '------------------------------------------------------------------
    '------------------------------------------------------------------
    '------------------------------------------------------------------

End Class