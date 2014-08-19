Imports WindowsApplication1.ComposicionGas

Public Class HardyCross
    Public P As Double(,)
    Public RED As Double(,)
    Public PlotX() As Double
    Public PlotY() As Double
    Public Qf() As Double
    Dim nu As Double = 0.000001
    'Definicion de la viscosidad dinámica para incluir las variaciones de 
    'Densidad por linea
    Dim ViscosidadDinamica1 As Double = Fullviscosidad1
    Dim ViscosidadDinamica2 As Double = Fullviscosidad2
    Dim DensidadGas1 As Double = Fulldensidad1
    Dim DensidadGas2 As Double = Fulldensidad2
    Dim grav As Double = 9.8
    Dim tol As Double = 0.09
    Dim nmax As Integer = 10000
    Public iniF2 As Boolean
    Public iniF3 As Boolean

    Private MatrizP As String
    Public Property FullMatrizP() As String
        Get
            Return MatrizP
        End Get
        Set(ByVal value As String)
            MatrizP = value
        End Set
    End Property
    Private MatrizRed As String
    Public Property FullMatrizRed() As String
        Get
            Return MatrizRed
        End Get
        Set(ByVal value As String)
            MatrizRed = value
        End Set
    End Property
    Private Result As Double()
    Public Property FullResult() As Double()
        Get
            Return Result
        End Get
        Set(ByVal value As Double())
            Result = value
        End Set
    End Property
    Private viscosidad1 As Double
    Public Property Fullviscosidad1() As Double
        Get
            Return viscosidad1
        End Get
        Set(ByVal value As Double)
            viscosidad1 = value
        End Set
    End Property
    Private viscosidad2 As Double
    Public Property Fullviscosidad2() As Double
        Get
            Return viscosidad2
        End Get
        Set(ByVal value As Double)
            viscosidad2 = value
        End Set
    End Property
    Private densidad1 As Double
    Public Property Fulldensidad1() As Double
        Get
            Return densidad1
        End Get
        Set(ByVal value As Double)
            densidad1 = value
        End Set
    End Property
    Private densidad2 As Double
    Public Property Fulldensidad2() As Double
        Get
            Return densidad2
        End Get
        Set(ByVal value As Double)
            densidad2 = value
        End Set
    End Property
    'Metodo para resolver HardyCross, 
    Public Function SolveHardyCross() As Array
        'Dim Ptext As String = File.ReadAllText(pathP)
        'Dim REDtext As String = File.ReadAllText(pathRED)
        'Matriz P Y RED comentadas son las matrices del problema base de debuggeo
        'Dim Ptext As String = "1,0.1,0.001,1000,0,0,-100,60;0.5,0.1,0.001,1000,0,0,0,0;0.25,0.1,0.001,1000,0,0,0,0;0.5,0.1,0.001,1000,0,0,0,0;0.75,0.1,0.001,1000,0,0,0,0;0.25,0.1,0.001,7000,0,0,0,0"
        'Dim REDtext As String = "1,0,0,1,1,0,-30;0,1,1,-1,0,0,0;-1,-1,0,0,0,-1,-35"
        'Las matrices no comentadas con P y RED de sistema Real con bomba
        Dim Ptext As String = FullMatrizP
        Dim REDtext As String = FullMatrizRed
        'Aquí se definen las dimensiones de la matrices P y RED"
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
        Dim Velocidad(Caudales) As Double
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
                Rey(i) = Math.Abs(4 * Q(i) / (ViscosidadCinematica(i) * 3.14159265 * P(i, 1)))
                f(i) = ff(Rey(i), P(i, 2), P(i, 1))
                r(i) = 8 * f(i) / (3.14159265 ^ 2 * grav * P(i, 1) ^ 5) * (P(i, 3) + P(i, 1) * P(i, 4) / f(i))
                Try
                    Sentido(i) = Math.Sign(Q(i))
                Catch ex As Exception
                    MsgBox("Pruebe otra configuración!")
                    Exit While
                End Try

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
                    Velocidad(j) = Q(j) / (3.14159265 / 4 * P(j, 1) ^ 2)
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
                Exit While
            End If

        End While

        Return {Q, Velocidad}
    End Function
    'Constructor sin argumento
    Sub New()
        Me.MatrizP = MatrizP
        Me.MatrizRed = MatrizRed
        Me.viscosidad1 = viscosidad1
        Me.viscosidad2 = viscosidad2
        Me.densidad1 = densidad1
        Me.densidad2 = densidad2
    End Sub

    Private Function Norm(ByVal vector() As Double) As Double
        Dim sum As Double = 0
        For i = 0 To vector.GetUpperBound(0) - 1
            sum += vector(i) ^ 2
        Next
        Norm = (sum) ^ 0.5
    End Function
    'Funcion que retorna los valores de viscosidadCinemática en función de la tuberia numerada
    'Aquí es necesario tamb incluir la función para calcular la viscosidad del LNG
    Private Function ViscosidadCinematica(indice As Integer) As Double
        Select Case indice
            Case 0, 1, 2
                Return Fullviscosidad1 / Fulldensidad1
                'Return 0.1 / 1000
            Case 3
                Return Fullviscosidad1 / Fulldensidad1
                'Return 0.1 / 1000
            Case 4, 5, 6, 7, 8
                Return Fullviscosidad2 / Fulldensidad2
                'Return 0.1 / 1000
            Case Else
                Return Fullviscosidad2 / Fulldensidad2
        End Select
    End Function
    'funciones aux para solucionar el hardycross (factor de fricción )
    Private Function ff(ByVal Rey As Double, ByVal ep As Double, ByVal D As Double) As Double
        ff = 1.325 * (Math.Log(0.27 * ep / D + 5.74 * (Rey) ^ (-0.9))) ^ (-2)
    End Function
    Public Sub CambiarMatrizRed(first As String, second As String, third As String, fourth As String, fith As String)
        FullMatrizRed = "1,1,0,0,0,0,0,0,0," & first & ";0,-1,1,0,-1,0,-1,0,-1," & second & ";0,0,0,1,1,-1,0,0,0," & third & ";0,0,0,0,0,1,1,1,0," & fourth & ";0,0,0,0,0,0,0,-1,1," & fith
    End Sub
    'increaseHeadLoss Cambia la matriz P
    Public Sub IncreaseLossAndSelectPump(loss1 As String, loss2 As String, loss3 As String, loss4 As String, curva1480 As Integer, curva0690 As Integer)
        FullMatrizP = "1,0.07,0.001,100,0," & WhichCurve(curva1480)(0) & "," & WhichCurve(curva1480)(1) & "," & WhichCurve(curva1480)(2) & ";0.5,0.0508,0.001,100," & loss1 & ",0,0,0;0.5,0.07,0.001,100," & loss3 & ",0,0,0,0;1,0.07,0.001,100,0,0,0,0;0.5,0.07,0.001,100," & loss4 & ",0,0,0;0.5,0.07,0.001,500," & loss2 & ",0,0,0;1,0.07,0.001,500,0," & WhichCurve(curva0690)(0) & "," & WhichCurve(curva0690)(1) & "," & WhichCurve(curva0690)(2) & ";0.5,0.07,0.001,500,0,0,0,0;0.5,0.07,0.001,500,0,0,0,0"
    End Sub
    Private Function WhichCurve(curva As Integer) As Array
        'Este nivel de selec es para escoger la curva en función del número de bombas instaladas
        Select Case curva
            Case 1 'Aqui retorna los coeficientes de la curva para una sola curva, para bomba 0690
                Return {-670900, 9965, 1630}
            Case 2
                Return {-167700, 4983, 1630}
            Case 3
                Return {-74500, 3322, 1630}
                'Estas curvas son para la bomba 1480 4=1Bomba; 5=2Bombas; 6=3Bombas
            Case 4
                Return {-266000, 3706, 1161}
            Case 5
                Return {-66500, 1853, 1161}
            Case 6
                Return {-29600, 1235, 1161}
            Case Else
                Return {-670900, 9965, 1630}
        End Select
    End Function

End Class
