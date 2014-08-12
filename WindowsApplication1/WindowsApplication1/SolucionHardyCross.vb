Imports System.Windows.Forms.DataVisualization.Charting
Imports System.IO

Public Class SolucionHardyCross
    Public resulthardycross As New HardyCross()
    Private Sub SolucionHardyCross_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Tanque0.Text = 1
        Tanque1.Text = 258
        Tanque2.Text = 100
        Tanque3.Text = 100
        Tanque4.Text = 0
        Tanque5.Text = 260
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
        'MsgBox(Valv1.Value)
        'Aqui controlo los valores del HscrollBar, y los ultimos dos argumento de la función, dicen la bomba y la curva que se selecciona
        'resulthardycross.IncreaseLoss(Valv1.Value, Valv2.Value)
        resulthardycross.IncreaseLossAndSelectPump(Valv1.Value * 10, Valv2.Value * 10, CInt(NumBomba1480.Text) + 3, CInt(NumBombas0690.Text))

        'Llamar metodo para graficar las curvas de las bombas y los puntos de operacion
        chart1Diseno()

        Tub0.Text = Math.Round(resulthardycross.SolveHardyCross(0) * 1000, 2) & "[l/s]"
        Tub1.Text = Math.Round(resulthardycross.SolveHardyCross(1) * 1000, 2) & "[l/s]"
        Tub2.Text = Math.Round(resulthardycross.SolveHardyCross(2) * 1000, 2) & "[l/s]"
        Tub3.Text = Math.Round(resulthardycross.SolveHardyCross(3) * 1000, 2) & "[l/s]"
        Tub4.Text = Math.Round(resulthardycross.SolveHardyCross(4) * 1000, 2) & "[l/s]"
        Tub5.Text = Math.Round(resulthardycross.SolveHardyCross(5) * 1000, 2) & "[l/s]"
        Tub6.Text = Math.Round(resulthardycross.SolveHardyCross(6) * 1000, 2) & "[l/s]"
        Tub7.Text = Math.Abs(Math.Round(resulthardycross.SolveHardyCross(7) * 1000, 2)) & "[l/s]"
        Tub8.Text = Math.Round(resulthardycross.SolveHardyCross(8) * 1000, 2) & "[l/s]"
        'define backcolor for label
        Tub0.BackColor = Color.FromArgb(144, 206, 129)
        Tub1.BackColor = Color.FromArgb(144, 206, 129)
        Tub2.BackColor = Color.FromArgb(144, 206, 129)
        Tub3.BackColor = Color.FromArgb(144, 206, 129)
        Tub4.BackColor = Color.FromArgb(144, 206, 129)
        Tub5.BackColor = Color.FromArgb(144, 206, 129)
        Tub6.BackColor = Color.FromArgb(144, 206, 129)
        Tub7.BackColor = Color.FromArgb(144, 206, 129)
        Tub8.BackColor = Color.FromArgb(144, 206, 129)
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
            Bomba0690.Points.AddXY(Math.Round(NewBomba.CurvaDisenoEquipo.Item("Bomba_1_Jusepin")(0, i) * 0.06309, 2) * NBombas0690, Math.Round(NewBomba.CurvaDisenoEquipo.Item("Bomba_1_Jusepin")(1, i) / 3.28, 2))
            Bomba1480.Points.AddXY(Math.Round(NewBomba.CurvaDisenoEquipo.Item("Bomba_2_Jusepin")(0, i), 2) * NBombas1480, Math.Round(NewBomba.CurvaDisenoEquipo.Item("Bomba_2_Jusepin")(1, i), 2))
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
        Dim Caudal As Double = Math.Round(resulthardycross.SolveHardyCross(0) * 1000 / CInt(NumBomba1480.Text), 1)
        Dim Curve As Integer = CInt(NumBomba1480.Text)
        'Aqui deben ir condicionales de evaluación para garantizar al gráfica de puntos de 
        'operación dentro de los rangos de funcionamiento de la bomba
        'Las verificaciones deben hacercer en caudal y en head calculada
        Dim PuntoOperacion1480 As New Series()
        PuntoOperacion1480.Points.AddXY(Caudal, CurveHead(CInt(NumBomba1480.Text) + 3, Caudal / 1000))
        Chart2.Series.Add(PuntoOperacion1480)
        Chart2.Series("Series2").ChartType = SeriesChartType.Point
        Chart2.Series("Series2").BorderWidth = 3
        Chart2.Series("Series2").Label = Caudal & ";" & Math.Round(CurveHead(CInt(NumBomba1480.Text) + 3, Caudal / 1000), 1)
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
    'Aquí el caudal debe venir en l/s
    Private Function CurveHead(curva As Integer, caudal As Double) As Double
        'Este nivel de selec es para escoger la curva en función del número de bombas instaladas
        Select Case curva
            Case 1 'Aqui retorna los coeficientes de la curva para una sola curva, para bomba 0690
                Return caudal ^ 2 * -670900 + caudal * 9965 + 1630
            Case 2
                Return caudal ^ 2 * -167700 + caudal * 4983 + 1630
            Case 3
                Return caudal ^ 2 * -74500 + caudal * 3322 + 1630
                'Estas curvas son para la bomba 1480 4=1Bomba; 5=2Bombas; 6=3Bombas
            Case 4
                Return caudal ^ 2 * -266000 + caudal * 3706 + 1161
            Case 5
                Return caudal ^ 2 * -66500 + caudal * 1853 + 1161
            Case 6
                Return caudal ^ 2 * -29600 + caudal * 1235 + 1161
            Case Else
                Return caudal ^ 2 * -670900 + caudal * 9965 + 1630
        End Select
    End Function


    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Compo1.Click

    End Sub
End Class