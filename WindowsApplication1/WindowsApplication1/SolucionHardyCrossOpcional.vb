Imports System.Windows.Forms.DataVisualization.Charting
Imports System.IO
Imports WindowsApplication1.UnitsConvert

Public Class SolucionHardyCrossOpcional
    'Se crea el objeto solver del hardyCross
    Public resulthardycross As New HardyCross()

    ' Public GasComposicion1 As String =
    Private Sub SolucionHardyCross_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Las unidades de las alturas en los tanques es [psi]
        Tanque0.Text = 188
        Tanque1.Text = 188
        Tanque4.Text = 720
        NumBomba1480.Text = "2"
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
        Tanque0.Text = 210
        Tanque1.Text = 202
        Tanque4.Text = 800
        NumBomba1480.Text = "2"
    End Sub
    'Boton que inicializa el calculo de HardyCross
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'aqui el flujo es, que se crea el objeto para calcular el hardycross a cada momento que se hace click en calcular
        'luego se redefine la matriz red invocando el método  cambiarmatrizred, que tiene como argumento los nuevos valores
        'para las diferencias de alturas en los tanques
        Dim first As String = Replace(to_MCA("[psi]_" & Tanque1.Text) - to_MCA("[psi]_" & Tanque0.Text), ",", ".")
        Dim second As String = Replace(to_MCA("[psi]_" & Tanque4.Text) - to_MCA("[psi]_" & Tanque1.Text), ",", ".")
        

        'aqui invoco el metodo para definir la cambiar la matriz red
        'resulthardycross.FullMatrizP = "1,0.1524,0.005,48,0,0,0,0;0.1,0.1524,0.005,50,0,0,0,0;0.9,0.1524,0.005,400,0,0,0,0"
        'resulthardycross.FullMatrizRed = "1,1,0,-10;0,-1,1,5"
        resulthardycross.CambiarMatrizRed2(first, second)
        resulthardycross.IncreaseLossAndSelectPump2(Valv1.Value * 15000, Valv2.Value * 500, CInt(NumBomba1480.Text) + 3)

        resulthardycross.Fullviscosidad1 = CDbl(Visco1.Text)
        resulthardycross.Fullviscosidad2 = CDbl(Visco2.Text)
        resulthardycross.Fulldensidad1 = CDbl(Densidad1.Text)
        resulthardycross.Fulldensidad2 = CDbl(Densidad2.Text)
   


        Dim Resultados As Array = resulthardycross.SolveHardyCross
        'Dim ResultadosVelocidad As Array = resulthardycross.SolveHardyCross(1)
        chart1Diseno(Math.Round(Resultados(0)(0) * 1000, 2))
        'MsgBox("Valor 1era valv" & Valv1.Value & "Valor 2da valv" & Valv2.Value & "Valor 3era valv" & Valv3.Value & "Valor 4ta valv" & Valv4.Value)
        Try
            
        Catch ex As Exception
            MsgBox("Intente otra configuración!! Error Fatal....")
        End Try
        'Aquí condicional para disparar el método con el timer que permita hacer blinck del 
        'color backgroun de interes

        'Define backcolor for label
        Tub0.Text = Math.Round(Resultados(0)(0) * 1000, 2)
        Tub1.Text = Math.Round(Resultados(0)(1) * 1000, 2)
        Tub2.Text = Math.Round(Resultados(0)(2) * 1000, 2)

        VelValv1.Text = Math.Round(Resultados(1)(1), 2) & " [m/s]"
        VelValv2.Text = Math.Round(Resultados(1)(2), 2) & " [m/s]"

        Tub0.BackColor = Color.FromArgb(144, 206, 129)
        Tub1.BackColor = Color.FromArgb(144, 206, 129)
        Tub2.BackColor = Color.FromArgb(144, 206, 129)
        VelValv1.BackColor = Color.FromArgb(253, 186, 109)
        VelValv2.BackColor = Color.FromArgb(253, 186, 109)

        'RGB para hacer orange 253,186,109
        'Activar el Timer! Aqui comenzar a poner condicionales para conocer en que momento activar el timer para hacer resaltar 
        'el valor de interes
        'Timer1.Enabled = True
        

    End Sub

    Private Sub chart1Diseno(Caudal1480Sistema As Double)
        ' el orden para definir los parametros de la máquina son:
        'Presión acutual, Temp actual,Zactual,PMactual, Kactual,RPMactula,Nombre de la Maquina
        Dim NewBomba As New CurvasEquipos
        Chart1.Series.Clear()
        Chart2.Series.Clear()
        ' Dim Bomba0690 As New Series()
        Dim Bomba1480 As New Series()
        Dim Sistema1480 As New Series()
        Dim k As Integer = NewBomba.CurvaDisenoEquipo.Item("Bomba_1_Jusepin").GetUpperBound(1)
        Dim NBombas1480 As Integer = CInt(NumBomba1480.Text)
        Dim Caudal1480 As Double = Math.Round(Caudal1480Sistema / NBombas1480, 2)
        For i As Integer = 0 To k
            'Ojo estos puntos estan en L/s y la altura en [m]
            Bomba1480.Points.AddXY(Math.Round(NewBomba.CurvaDisenoEquipo.Item("Bomba_2_Jusepin")(0, i), 2), Math.Round(NewBomba.CurvaDisenoEquipo.Item("Bomba_2_Jusepin")(1, i), 2))
            Sistema1480.Points.AddXY(Math.Round(NewBomba.CurvaDisenoEquipo.Item("Bomba_2_Jusepin")(0, i), 2) * NBombas1480, Math.Round(NewBomba.CurvaDisenoEquipo.Item("Bomba_2_Jusepin")(1, i), 2))
        Next
        '-----------------------------------------------------------------------------
        '--------------Bloque para la bomba 0690 Chart1 ------------------------------
        '-----------------------------------------------------------------------------
        Chart1.Series.Add(Bomba1480)
        Chart1.Series(0).Name = "1 Bomba"
        Chart1.Series("1 Bomba").ChartType = SeriesChartType.Spline
        Chart1.Series("1 Bomba").BorderWidth = 3
        Chart1.Series("1 Bomba").MarkerStyle = MarkerStyle.Square

        Chart2.Series.Add(Sistema1480)
        Chart2.Series(0).Name = NBombas1480 & " Bombas"
        Chart2.Series(NBombas1480 & " Bombas").ChartType = SeriesChartType.Spline
        Chart2.Series(NBombas1480 & " Bombas").BorderWidth = 3
        Chart2.Series(NBombas1480 & " Bombas").MarkerStyle = MarkerStyle.Square

        'Bloque Inclusión del punto de diseño de la máquina
        'Aquí el punto de diseño es en L/s
        Dim PuntoDiseno1480 As New Series()
        PuntoDiseno1480.Points.AddXY(18.9538, CurveHead(4, 28, 18.9538))
        Chart1.Series.Add(PuntoDiseno1480)
        Chart1.Series(1).Name = "Diseño"
        Chart1.Series("Diseño").ChartType = SeriesChartType.Point
        Chart1.Series("Diseño").BorderWidth = 3
        Chart1.Series("Diseño").Label = 18.95 & ";" & Math.Round(CurveHead(4, 28, 18.95), 1)
        'Fin del bloque

        Dim PuntoDisenoNBombas1480 As New Series()
        PuntoDisenoNBombas1480.Points.AddXY(18.95 * NBombas1480, CurveHead(NBombas1480 + 3, 28, 18.95 * NBombas1480))
        Chart2.Series.Add(PuntoDisenoNBombas1480)
        Chart2.Series(1).Name = "Diseño"
        Chart2.Series("Diseño").ChartType = SeriesChartType.Point
        Chart2.Series("Diseño").BorderWidth = 3
        Chart2.Series("Diseño").Label = 18.95 * NBombas1480 & ";" & Math.Round(CurveHead(NBombas1480 + 3, 28, 18.95 * NBombas1480), 1)
        ' Condición para saber si la bomba está funcionando en el rango de operación (la altura de la bomba da negativo)
        Try
            If CInt(CurveHead(4, 28, Caudal1480)) > 625 Then
                Dim PuntoOperacion1480 As New Series()
                PuntoOperacion1480.Points.AddXY(Caudal1480, CurveHead(4, 28, Caudal1480))
                Chart1.Series.Add(PuntoOperacion1480)
                Chart1.Series(2).Name = "Operación"
                Chart1.Series("Operación").ChartType = SeriesChartType.Point
                Chart1.Series("Operación").BorderWidth = 3
                Chart1.Series("Operación").Label = Caudal1480 & ";" & Math.Round(CurveHead(4, 28, Caudal1480), 1)

                Dim PuntoOperacionSistema1480 As New Series()
                PuntoOperacionSistema1480.Points.AddXY(Caudal1480Sistema, CurveHead(NBombas1480 + 3, 28, Caudal1480Sistema))
                Chart2.Series.Add(PuntoOperacionSistema1480)
                Chart2.Series(2).Name = "Operación"
                Chart2.Series("Operación").ChartType = SeriesChartType.Point
                Chart2.Series("Operación").BorderWidth = 3
                Chart2.Series("Operación").Label = Caudal1480Sistema & ";" & Math.Round(CurveHead(NBombas1480 + 3, 28, Caudal1480Sistema), 1)

                If NPSHReq(1, Caudal1480) > CDbl(Tanque0.Text) Then
                    'Incluir sistema de alarmas de cambio de colores de fondo en la vista!
                    MsgBox("Existe riesgo de cavitación en las bombas 1480")
                End If
            Else
                'MsgBox("La bomba 1480 está trabajando fuera del rango de operación funcional" & vbCrLf & "el caudal máximo manejado por bomba")
            End If
            Chart1.Titles.Clear()
            Chart1.Titles.Add("Curva Bomba 1480")
            Chart1.ChartAreas(0).AxisX.Title = "Caudal [L/seg]"
            Chart1.ChartAreas(0).AxisY.Title = "Altura [m]"
            Chart1.ChartAreas(0).AxisX.MajorGrid.Enabled = False
            Chart1.ChartAreas(0).AxisY.MajorGrid.Enabled = False
            Chart1.ChartAreas(0).AxisY.Minimum = (Bomba1480.Points().FindMinByValue("Y").YValues(0) - 100)
            Chart1.BringToFront()
            '------------------------------------------------------------------------------------------------------
            Chart2.Titles.Clear()
            Chart2.Titles.Add("Curva del sistema 1480")
            Chart2.ChartAreas(0).AxisX.Title = "Caudal [L/seg]"
            Chart2.ChartAreas(0).AxisY.Title = "Altura [m]"
            Chart2.ChartAreas(0).AxisX.MajorGrid.Enabled = False
            Chart2.ChartAreas(0).AxisY.MajorGrid.Enabled = False
            Chart2.ChartAreas(0).AxisY.Minimum = (Bomba1480.Points().FindMinByValue("Y").YValues(0) - 100)
            Chart2.BringToFront()

        Catch ex As Exception
            MsgBox("Error de desbordamiento, el modelo no convergió a ninguna solución")
        End Try





    End Sub
    'Función que contiene las cttes de las bombas centrifugas
    'Aquí el caudal debe venir en l/s, esto sirve para conseguir el punto de operación y graficarlo en la curva de la bomba
    Private Function CurveHead(curva As Integer, NumEtapas0690 As Integer, caudal As Double) As Double
        'Este nivel de selección es para escoger la curva en función del número de bombas instaladas
        Select Case curva
            Case 1 'Aqui retorna los coeficientes para una sola curva (1Bomba), para la 0690
                Return NumEtapas0690 / 28 * (caudal ^ 2 * -0.6709 + caudal * 9.965 + 1630)
            Case 2
                Return NumEtapas0690 / 28 * (caudal ^ 2 * -0.1677 + caudal * 4.983 + 1630)
            Case 3
                Return NumEtapas0690 / 28 * (caudal ^ 2 * -0.0745 + caudal * 3.322 + 1630)
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

    Private Function NPSHReq(curva As Integer, caudal As Double) As Double
        Select Case curva
            Case 1 ' La primera curva sera la curva del npsh para las bombas 1480
                Return 0.00005 * caudal ^ 4 - 0.0023 * caudal ^ 3 + 0.0345 * caudal ^ 2 - 0.1732 * caudal + 5.1996
            Case 2 ' esta curva sera la curva del npsh para las bombas 0690
                Return 0.00001 * caudal ^ 4 - 0.0012 * caudal ^ 3 + 0.0377 * caudal ^ 2 - 0.5633 * caudal + 8.151
            Case Else
                Return 0.00005 * caudal ^ 4 - 0.0023 * caudal ^ 3 + 0.0345 * caudal ^ 2 - 0.1732 * caudal + 5.1996
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