Imports System.Windows.Forms.DataVisualization.Charting
Imports System.IO

Public Class SolucionHardyCross
    'Se crea el objeto solver del hardyCross
    Public resulthardycross As New HardyCross()

    ' Public GasComposicion1 As String =
    Private Sub SolucionHardyCross_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Tanque0.Text = 1
        Tanque1.Text = 10
        Tanque2.Text = 100
        Tanque3.Text = 100
        Tanque4.Text = 0
        Tanque5.Text = 77
        NumBomba1480.Text = "2"
        NumBombas0690.Text = "2"
        Visco1.Text = 0.001
        Visco2.Text = 0.001
        Visco3.Text = 0.001
        Densidad1.Text = 1000
        Densidad2.Text = 1000
        Densidad3.Text = (CDbl(Densidad1.Text) + CDbl(Densidad2.Text)) / 2
        Visco1.Enabled = False
        Visco2.Enabled = False
        Visco3.Enabled = False
        Densidad1.Enabled = False
        Densidad2.Enabled = False
        Densidad3.Enabled = False
        'Desabilitar el timer para que no parpadee
        Timer1.Enabled = False
    End Sub
    Private Sub SolucionHardyCross_resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        Tanque0.Text = 1
        Tanque1.Text = 10
        Tanque2.Text = 100
        Tanque3.Text = 100
        Tanque4.Text = 0
        Tanque5.Text = 77
        NumBomba1480.Text = "2"
        NumBombas0690.Text = "2"
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'aqui el flujo es, que se crea el objeto para calcular el hardycross a cada momento que se hace click en calcular
        'luego se redefine la matriz red invocando el método  cambiarmatrizred, que tiene como argumento los nuevos valores
        'para las diferencias de alturas en los tanques
        Dim first As String = (CInt(Tanque1.Text) - CInt(Tanque0.Text))
        Dim second As String = (CInt(Tanque2.Text) - CInt(Tanque1.Text))
        Dim third As String = (CInt(Tanque4.Text) - CInt(Tanque5.Text))
        Dim fourth As String = (CInt(Tanque5.Text) - CInt(Tanque3.Text))
        Dim fith As String = (CInt(Tanque3.Text) - CInt(Tanque2.Text))
        'aqui invoco el metodo para definir la cambiar la matriz red
        resulthardycross.CambiarMatrizRed(first, second, third, fourth, fith)
        'Aqui controlo los valores del HscrollBar, y los ultimos dos argumento de la función, dicen la bomba y la curva que se selecciona
        'resulthardycross.IncreaseLoss(Valv1.Value, Valv2.Value)
        resulthardycross.IncreaseLossAndSelectPump(Valv1.Value * 200, Valv2.Value * 200, Valv3.Value * 100, Valv4.Value * 100, CInt(NumBomba1480.Text) + 3, CInt(NumBombas0690.Text))
        'Ok ahora es necesario pasarle los argumentos de la cadena de gas que se esta utilizando
        'Y la temperatura actual de al mezcla para que calcule el hardyCross considerando los
        'cambios de temp den la mezcla de los gases

        resulthardycross.Fullviscosidad1 = CDbl(Visco1.Text)
        resulthardycross.Fullviscosidad2 = CDbl(Visco2.Text)
        resulthardycross.Fulldensidad1 = CDbl(Densidad1.Text)
        resulthardycross.Fulldensidad2 = CDbl(Densidad2.Text)
        'resulthardycross.Fuu

        'MsgBox(DensidadGas1.DensidadDeMezcla(0.59))
        'MsgBox(DensidadGas1.ViscosidadEquivalente(583))
        'Llamar metodo para graficar las curvas de las bombas y los puntos de operacion
        chart1Diseno()
        Try
            Tub0.Text = Math.Round(resulthardycross.SolveHardyCross(0)(0) * 1000, 2) & "[l/s]"
            Tub1.Text = Math.Round(resulthardycross.SolveHardyCross(0)(1) * 1000, 2) & "[l/s]"
            Tub2.Text = Math.Round(resulthardycross.SolveHardyCross(0)(2) * 1000, 2) & "[l/s]"
            Tub3.Text = Math.Round(resulthardycross.SolveHardyCross(0)(3) * 1000, 2) & "[l/s]"
            Tub4.Text = Math.Round(resulthardycross.SolveHardyCross(0)(4) * 1000, 2) & "[l/s]"
            Tub5.Text = Math.Round(resulthardycross.SolveHardyCross(0)(5) * 1000, 2) & "[l/s]"
            Tub6.Text = Math.Round(resulthardycross.SolveHardyCross(0)(6) * 1000, 2) & "[l/s]"
            Tub7.Text = Math.Round(resulthardycross.SolveHardyCross(0)(7) * 1000, 2) & "[l/s]"
            Tub8.Text = Math.Round(resulthardycross.SolveHardyCross(0)(8) * 1000, 2) & "[l/s]"
            VelValv1.Text = "Vel válvula: " & Math.Abs(Math.Round(resulthardycross.SolveHardyCross(1)(1), 2)) & " [m/s]"
            VelValv2.Text = "Vel válvula: " & Math.Abs(Math.Round(resulthardycross.SolveHardyCross(1)(5), 2)) & " [m/s]"
            VelValv3.Text = "Vel válvula: " & Math.Abs(Math.Round(resulthardycross.SolveHardyCross(1)(4), 2)) & " [m/s]"
            VelValv4.Text = "Vel válvula: " & Math.Abs(Math.Round(resulthardycross.SolveHardyCross(1)(2), 2)) & " [m/s]"
        Catch ex As Exception
            MsgBox("Intente otra configuración!! Fatal Error....")
        End Try
        'Aquí condicional para disparar el método con el timer que permita hacer blinck del 
        'color backgrounde interes

        'Define backcolor for label
        Tub0.BackColor = Color.FromArgb(144, 206, 129)
        Tub1.BackColor = Color.FromArgb(144, 206, 129)
        Tub2.BackColor = Color.FromArgb(144, 206, 129)
        Tub3.BackColor = Color.FromArgb(144, 206, 129)
        Tub4.BackColor = Color.FromArgb(144, 206, 129)
        Tub5.BackColor = Color.FromArgb(144, 206, 129)
        Tub6.BackColor = Color.FromArgb(144, 206, 129)
        Tub7.BackColor = Color.FromArgb(144, 206, 129)
        Tub8.BackColor = Color.FromArgb(144, 206, 129)
        'RGB para hacer orange 253,186,109
        Timer1.Enabled = True
    End Sub

    Private Sub chart1Diseno()
        ' el orden para definir los parametros de la máquina son:
        'Presión acutual, Temp actual,Zactual,PMactual, Kactual,RPMactula,Nombre de la Maquina
        Dim NewBomba As New CurvasEquipos
        Chart1.Series.Clear()
        Chart2.Series.Clear()
        Dim Bomba0690 As New Series()
        Dim Bomba1480 As New Series()
        Dim k As Integer = NewBomba.CurvaDisenoEquipo.Item("Bomba_1_Jusepin").GetUpperBound(1)
        Dim NBombas0690 As Integer = CInt(NumBombas0690.Text)
        Dim NBombas1480 As Integer = CInt(NumBomba1480.Text)
        For i As Integer = 0 To k
            'Ojo estos puntos estan en L/s y la altura en [m]
            Bomba0690.Points.AddXY(Math.Round(NewBomba.CurvaDisenoEquipo.Item("Bomba_1_Jusepin")(0, i) * 0.06309, 2), Math.Round(NewBomba.CurvaDisenoEquipo.Item("Bomba_1_Jusepin")(1, i) / 3.28, 2))
            Bomba1480.Points.AddXY(Math.Round(NewBomba.CurvaDisenoEquipo.Item("Bomba_2_Jusepin")(0, i), 2), Math.Round(NewBomba.CurvaDisenoEquipo.Item("Bomba_2_Jusepin")(1, i), 2))
        Next
        '-----------------------------------------------------------------------------
        '--------------Bloque para la bomba 0690 Chart1 ------------------------------
        '-----------------------------------------------------------------------------
        Chart1.Series.Add(Bomba0690)
        Chart1.Series("Series1").ChartType = SeriesChartType.Spline
        Chart1.Series("Series1").BorderWidth = 3
        Chart1.Series("Series1").ToolTip = "#VALY"
        'agregar marcador al gráfico
        Chart1.Series("Series1").MarkerStyle = MarkerStyle.Square
        '------------------ Aquí para agregar la serie de la bomba centrifuga--------------------
        '------------------ Calcula y define el punto de operación de la curva-------------------
        '------------------ En función del caudal manejado en la linea---------------------------
        Dim Caudal0690 As Double = Math.Round(resulthardycross.SolveHardyCross(0)(6) * 1000 / CInt(NumBombas0690.Text), 1)
        'Aqui deben ir condicionales de evaluación para garantizar al gráfica de puntos de 
        'operación dentro de los rangos de funcionamiento de la bomba
        'Las verificaciones deben hacerce en caudal y en head calculada

        'Condición para saber si la bomba está funcionando en el rango de operación (la altura de la bomba da negativo)
        If CInt(CurveHead(1, Caudal0690)) > 521 Then
            Dim PuntoOperacion0690 As New Series()
            PuntoOperacion0690.Points.AddXY(Caudal0690, CurveHead(1, Caudal0690))
            Chart1.Series.Add(PuntoOperacion0690)
            Chart1.Series("Series2").ChartType = SeriesChartType.Point
            Chart1.Series("Series2").BorderWidth = 3
            Chart1.Series("Series2").Label = Caudal0690 & ";" & Math.Round(CurveHead(CInt(NumBombas0690.Text), Caudal0690 / 1000), 1)
        Else
            MsgBox("La bomba 0690 está trabajando fuera del rango de operación funcional" & vbCrLf & "el caudal máximo manejado por bomba:")
        End If
        Chart1.Titles.Clear()
        Chart1.Titles.Add("Curva Bomba 0690, esta curva es para una bomba de 28 etápas")
        Chart1.ChartAreas(0).AxisX.Title = "Caudal [L/seg]"
        Chart1.ChartAreas(0).AxisY.Title = "Altura [m]"
        Chart1.ChartAreas(0).AxisX.MajorGrid.Enabled = False
        Chart1.ChartAreas(0).AxisY.MajorGrid.Enabled = False
        Chart1.ChartAreas(0).AxisY.Minimum = (Bomba0690.Points().FindMinByValue("Y").YValues(0) - 100)
        Chart1.BringToFront()
        '-----------------------------------------------------------------------------
        '--------------Bloque para la bomba 1480 Chart2 ------------------------------
        '-----------------------------------------------------------------------------
        'Ojo aqui la curva de esta bomba ya esta en las unidades correctas para trabajar L/s y m
        'Define new serie to add a single point to the chart
        Chart2.Series.Add(Bomba1480)
        Chart2.Series("Series1").ChartType = SeriesChartType.Spline
        Chart2.Series("Series1").BorderWidth = 3
        Chart2.Series("Series1").ToolTip = "#valy"
        Chart2.Series("Series1").MarkerStyle = MarkerStyle.Square
        '------------------ Aquí para agregar la serie de la bomba centrifuga--------------------
        '------------------ Calcula y define el punto de operación de la curva-------------------
        '------------------ En función del caudal manejado en la linea---------------------------
        Dim Caudal1480 As Double = Math.Round(resulthardycross.SolveHardyCross(0)(0) * 1000 / CInt(NumBomba1480.Text), 1)
        'Aqui deben ir condicionales de evaluación para garantizar al gráfica de puntos de 
        'operación dentro de los rangos de funcionamiento de la bomba
        'Las verificaciones deben hacerce en caudal y en head calculada

        'Condición para saber si la bomba está funcionando en el rango de operación (la altura de la bomba da negativo)

        If CInt(CurveHead(4, Caudal1480)) > 625 Then
            Dim PuntoOperacion1480 As New Series()
            PuntoOperacion1480.Points.AddXY(Caudal1480, CurveHead(4, Caudal1480))
            Chart2.Series.Add(PuntoOperacion1480)
            Chart2.Series("Series2").ChartType = SeriesChartType.Point
            Chart2.Series("Series2").BorderWidth = 3
            Chart2.Series("Series2").Label = Caudal1480 & ";" & Math.Round(CurveHead(CInt(NumBomba1480.Text) + 3, Caudal1480 / 1000), 1)
        Else
            MsgBox("La bomba 1480 está trabajando fuera del rango de operación funcional" & vbCrLf & "el caudal máximo manejado por bomba:")
        End If
       
        '-----------Aqui termina la definición del grafico del punto de operación de la máquina------

        Chart2.Titles.Clear()
        Chart2.Titles.Add("Curva Bomba 1480")
        Chart2.ChartAreas(0).AxisX.Title = "Caudal [L/seg]"
        Chart2.ChartAreas(0).AxisY.Title = "Altura [m]"
        Chart2.ChartAreas(0).AxisX.MajorGrid.Enabled = False
        Chart2.ChartAreas(0).AxisY.MajorGrid.Enabled = False
        Chart2.ChartAreas(0).AxisY.Minimum = (Bomba1480.Points().FindMinByValue("Y").YValues(0) - 100)
        Chart2.BringToFront()
    End Sub
    'Función que contiene las cttes de las bombas centrifugas
    'Aquí el caudal debe venir en l/s, esto sirve para conseguir el punto de operación
    Private Function CurveHead(curva As Integer, caudal As Double) As Double
        'Este nivel de selec es para escoger la curva en función del número de bombas instaladas
        Select Case curva
            Case 1 'Aqui retorna los coeficientes de la curva para una sola curva, para bomba 0690
                Return caudal ^ 2 * -0.6709 + caudal * 9.965 + 1630
            Case 2
                Return caudal ^ 2 * -0.1677 + caudal * 4.983 + 1630
            Case 3
                Return caudal ^ 2 * -0.0745 + caudal * 3.322 + 1630
                'Estas curvas son para la bomba 1480 4=1Bomba; 5=2Bombas; 6=3Bombas
            Case 4
                Return caudal ^ 2 * -0.266 + caudal * 3.706 + 1161
            Case 5
                Return caudal ^ 2 * -0.0665 + caudal * 1.853 + 1161
            Case 6
                Return caudal ^ 2 * -0.0296 + caudal * 1.235 + 1161
            Case Else
                Return caudal ^ 2 * -0.6709 + caudal * 9.965 + 1630
        End Select
    End Function

    'Labels para cambiar la composición del gas que se está definiendo
    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Compo1.Click
        LNGComposicion.Show()
        LNGComposicion.id.Text = "Composición 1"
    End Sub
    Private Sub Compo2_Click(sender As Object, e As EventArgs) Handles Composicion_2.Click
        LNGComposicion.Show()
        LNGComposicion.id.Text = "Composición 2"
    End Sub
    'Piece of code to make blinck what so ever do I want
    Dim blink As Boolean

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If (blink) Then
            Me.Tub0.BackColor = Color.FromArgb(253, 186, 109)
            blink = False
        Else
            Me.Tub0.BackColor = Color.FromArgb(144, 206, 129)
            blink = True
        End If
    End Sub

End Class