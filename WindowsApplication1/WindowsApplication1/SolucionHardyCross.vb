Imports System.Windows.Forms.DataVisualization.Charting
Imports System.IO
Imports WindowsApplication1.UnitsConvert

Public Class SolucionHardyCross
    'Se crea el objeto solver del hardyCross
    Public resulthardycross As New HardyCross()

    ' Public GasComposicion1 As String =
    Private Sub SolucionHardyCross_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Las unidades de las alturas en los tanques es [psi]
        Tanque0.Text = 210
        Tanque1.Text = 202
        Tanque2.Text = 255
        Tanque3.Text = 255
        Tanque4.Text = 800
        Tanque5.Text = 205 '155 psig es la presión necesaria en el tanque de recirculación
        NumBomba1480.Text = "2"
        NumBombas0690.Text = "2"
        Visco1.Text = 0.001
        Visco2.Text = 0.001
        Visco3.Text = 0.001
        Densidad1.Text = 1000
        Densidad2.Text = 1000
        Densidad3.Text = (CDbl(Densidad1.Text) + CDbl(Densidad2.Text)) / 2
        NumEtapas0690.Text = 28
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
        Tanque2.Text = 255
        Tanque3.Text = 255
        Tanque4.Text = 800
        Tanque5.Text = 109
        NumBomba1480.Text = "2"
        NumBombas0690.Text = "2"
    End Sub
    'Boton que inicializa el calculo de HardyCross
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'aqui el flujo es, que se crea el objeto para calcular el hardycross a cada momento que se hace click en calcular
        'luego se redefine la matriz red invocando el método  cambiarmatrizred, que tiene como argumento los nuevos valores
        'para las diferencias de alturas en los tanques
        Dim first As String = Replace(to_MCA("[psi]_" & Tanque1.Text) - to_MCA("[psi]_" & Tanque0.Text), ",", ".")
        Dim second As String = Replace(to_MCA("[psi]_" & Tanque2.Text) - to_MCA("[psi]_" & Tanque1.Text), ",", ".")
        Dim third As String = Replace(to_MCA("[psi]_" & Tanque4.Text) - to_MCA("[psi]_" & Tanque5.Text), ",", ".")
        Dim fourth As String = Replace(to_MCA("[psi]_" & Tanque5.Text) - to_MCA("[psi]_" & Tanque3.Text), ",", ".")
        Dim fith As String = Replace(to_MCA("[psi]_" & Tanque3.Text) - to_MCA("[psi]_" & Tanque2.Text), ",", ".")

        'aqui invoco el metodo para definir la cambiar la matriz red
        resulthardycross.CambiarMatrizRed(first, second, third, fourth, fith)
        'Aqui controlo los valores del HscrollBar, y los ultimos dos argumento de la función, dicen la bomba y la curva que se selecciona
        'resulthardycross.IncreaseLoss(Valv1.Value, Valv2.Value)

        'Aqui algunas líneas para preprocesar los valores de las valvulas
        'la idea será definir un valor suficientemente grande cuando este completamente cerrada
        Dim PerdidaValv1 As Double
        Dim PerdidaValv2 As Double
        Dim PerdidaValv4 As Double

        If Valv2.Value = 91 Then
            PerdidaValv2 = (Valv2.Value + 3) * 25000
        ElseIf Valv2.Value = 0 Then
            PerdidaValv2 = 200
        Else
            PerdidaValv2 = Valv2.Value * 40
        End If

        If Valv4.Value = 91 Then
            PerdidaValv4 = (Valv4.Value + 3) * 7000
        ElseIf Valv4.Value = 0 Then
            PerdidaValv4 = 6000
        Else
            PerdidaValv4 = Valv4.Value * 2000
        End If

        If Valv1.Value = 91 Then
            PerdidaValv1 = Valv1.Value * 25000
        ElseIf Valv1.Value = 0 Then
            PerdidaValv1 = 1000
        Else
            PerdidaValv1 = Valv1.Value * 1000
        End If

        resulthardycross.IncreaseLossAndSelectPump(PerdidaValv1, PerdidaValv2, Valv3.Value * 100, PerdidaValv4, CInt(NumBomba1480.Text) + 3, CInt(NumBombas0690.Text), CInt(NumEtapas0690.Text))
        'MsgBox(Valv1.Value & Valv2.Value & Valv3.Value & Valv4.Value)
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

        Dim Resultados As Array = resulthardycross.SolveHardyCross
        'Dim ResultadosVelocidad As Array = resulthardycross.SolveHardyCross(1)
        chart1Diseno(Math.Round(Resultados(0)(0) * 1000, 2), Math.Round(Resultados(0)(6) * 1000, 2))
        'MsgBox("Valor 1era valv" & Valv1.Value & "Valor 2da valv" & Valv2.Value & "Valor 3era valv" & Valv3.Value & "Valor 4ta valv" & Valv4.Value)
        Try
            Tub0.Text = Math.Round(Resultados(0)(0) * 1000, 2) & "[l/s]"
            Tub1.Text = Math.Round(Resultados(0)(1) * 1000, 2) & "[l/s]"
            Tub2.Text = Math.Round(Resultados(0)(2) * 1000, 2) & "[l/s]"
            Tub3.Text = Math.Round(Resultados(0)(3) * 1000, 2) & "[l/s]"
            Tub4.Text = Math.Round(Resultados(0)(4) * 1000, 2) & "[l/s]"
            Tub5.Text = Math.Round(Resultados(0)(5) * 1000, 2) & "[l/s]"
            Tub6.Text = Math.Round(Resultados(0)(6) * 1000, 2) & "[l/s]"
            Tub7.Text = Math.Round(Resultados(0)(7) * 1000, 2) & "[l/s]"
            Tub8.Text = Math.Round(Resultados(0)(8) * 1000, 2) & "[l/s]"
            VelValv1.Text = "Vel válvula: " & Math.Abs(Math.Round(Resultados(1)(1), 2)) & " [m/s]"
            VelValv2.Text = "Vel válvula: " & Math.Abs(Math.Round(Resultados(1)(5), 2)) & " [m/s]"
            VelValv3.Text = "Vel válvula: " & Math.Abs(Math.Round(Resultados(1)(4), 2)) & " [m/s]"
            VelValv4.Text = "Vel válvula: " & Math.Abs(Math.Round(Resultados(1)(2), 2)) & " [m/s]"
        Catch ex As Exception
            MsgBox("Intente otra configuración!! Error Fatal....")
        End Try
        'Aquí condicional para disparar el método con el timer que permita hacer blinck del 
        'color backgroun de interes

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
        'Activar el Timer! Aqui comenzar a poner condicionales para conocer en que momento activar el timer para hacer resaltar 
        'el valor de interes
        'Timer1.Enabled = True
        'Dim diccionario As New Dictionary(Of String, Double)
        'diccionario.Add("Presion de Succión Compresor 1 [psi]", 14.0)
        'diccionario.Add("Presion de Succión Compresor 2 [psi]", 150)
        'diccionario.Add("Temperatura ambiental [°C]", 25)
        'For Each kvp As KeyValuePair(Of String, Double) In diccionario
        '    MsgBox("Aquí estoy sacando las llaves " & kvp.Key & "Y los valores " & kvp.Value)
        'Next

    End Sub

    Private Sub chart1Diseno(Caudal1480Sistema As Double, Caudal0690Sistema As Double)
        ' el orden para definir los parametros de la máquina son:
        'Presión acutual, Temp actual,Zactual,PMactual, Kactual,RPMactula,Nombre de la Maquina
        Dim NewBomba As New CurvasEquipos
        Chart1.Series.Clear()
        Chart2.Series.Clear()
        Chart3.Series.Clear()
        Chart4.Series.Clear()
        Dim Bomba0690 As New Series()
        Dim Bomba1480 As New Series()
        Dim Sistema0690 As New Series()
        Dim Sistema1480 As New Series()
        Dim k As Integer = NewBomba.CurvaDisenoEquipo.Item("Bomba_1_Jusepin").GetUpperBound(1)
        Dim NBombas0690 As Integer = CInt(NumBombas0690.Text)
        Dim NBombas1480 As Integer = CInt(NumBomba1480.Text)
        Dim Caudal0690 As Double = Math.Round(Caudal0690Sistema / NBombas0690, 2)
        Dim Caudal1480 As Double = Math.Round(Caudal1480Sistema / NBombas1480, 2)
        For i As Integer = 0 To k
            'Ojo estos puntos estan en L/s y la altura en [m]
            Bomba0690.Points.AddXY(Math.Round(NewBomba.CurvaDisenoEquipo.Item("Bomba_1_Jusepin")(0, i) * 0.06309, 2), Math.Round(NewBomba.CurvaDisenoEquipo.Item("Bomba_1_Jusepin")(1, i) / 3.28, 2))
            Bomba1480.Points.AddXY(Math.Round(NewBomba.CurvaDisenoEquipo.Item("Bomba_2_Jusepin")(0, i), 2), Math.Round(NewBomba.CurvaDisenoEquipo.Item("Bomba_2_Jusepin")(1, i), 2))
            Sistema0690.Points.AddXY(Math.Round(NewBomba.CurvaDisenoEquipo.Item("Bomba_1_Jusepin")(0, i) * 0.06309, 2) * NBombas0690, Math.Round(NewBomba.CurvaDisenoEquipo.Item("Bomba_1_Jusepin")(1, i) / 3.28, 2))
            Sistema1480.Points.AddXY(Math.Round(NewBomba.CurvaDisenoEquipo.Item("Bomba_2_Jusepin")(0, i), 2) * NBombas1480, Math.Round(NewBomba.CurvaDisenoEquipo.Item("Bomba_2_Jusepin")(1, i), 2))
        Next
        '-----------------------------------------------------------------------------
        '--------------Bloque para la bomba 0690 Chart1 ------------------------------
        '-----------------------------------------------------------------------------
        Chart1.Series.Add(Bomba0690)
        Chart1.Series(0).Name = "1 Bomba"
        Chart1.Series("1 Bomba").ChartType = SeriesChartType.Spline
        Chart1.Series("1 Bomba").BorderWidth = 3
        Chart1.Series("1 Bomba").MarkerStyle = MarkerStyle.Square
        '------------------ Aquí para agregar la serie de la bomba centrifuga--------------------
        '------------------ Calcula y define el punto de operación de la curva-------------------
        '------------------ En función del caudal manejado en la linea---------------------------
        'Dim Caudal0690 As Double = Math.Round(resulthardycross.SolveHardyCross(0)(6) * 1000 / CInt(NumBombas0690.Text), 1)
        'Aqui deben ir condicionales de evaluación para garantizar al gráfica de puntos de 
        'operación dentro de los rangos de funcionamiento de la bomba
        'Las verificaciones deben hacerce en caudal y en head calculada

        'Bloque Inclusión del punto de diseño de la máquina
        'Aquí el punto de diseño es en L/s
        Dim PuntoDiseno0690 As New Series()
        PuntoDiseno0690.Points.AddXY(29.1061, CurveHead(1, 28, 29.1061))
        Chart1.Series.Add(PuntoDiseno0690)
        Chart1.Series(1).Name = "Diseño"
        Chart1.Series("Diseño").ChartType = SeriesChartType.Point
        Chart1.Series("Diseño").BorderWidth = 3
        Chart1.Series("Diseño").Label = 29.11 & ";" & Math.Round(CurveHead(1, 28, 29.1061), 1)
        'Fin del bloque

        'Condición para saber si la bomba está funcionando en el rango de operación (la altura de la bomba da negativo)
        Try
            If CInt(CurveHead(1, 28, Caudal0690)) > 521 Then
                Dim PuntoOperacion0690 As New Series()
                PuntoOperacion0690.Points.AddXY(Caudal0690, CurveHead(1, 28, Caudal0690))
                Chart1.Series.Add(PuntoOperacion0690)
                Chart1.Series(2).Name = "Operación"
                Chart1.Series("Operación").ChartType = SeriesChartType.Point
                Chart1.Series("Operación").BorderWidth = 3
                Chart1.Series("Operación").Label = Caudal0690 & ";" & Math.Round(CurveHead(1, 28, Caudal0690), 1)

                If NPSHReq(2, Caudal0690) > CDbl(Tanque3.Text) Then
                    'Incluir sistema de alarmas de cambio de colores de fondo en la vista!
                    MsgBox("Existe riesgo de cavitación en las bombas 0690")
                End If
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
            Chart2.Series(0).Name = "1 Bomba"
            Chart2.Series("1 Bomba").ChartType = SeriesChartType.Spline
            Chart2.Series("1 Bomba").BorderWidth = 3
            Chart2.Series("1 Bomba").MarkerStyle = MarkerStyle.Square

            'Bloque Inclusión del punto de diseño de la máquina
            Dim PuntoDiseno1480 As New Series()
            PuntoDiseno1480.Points.AddXY(18.9538, CurveHead(4, 28, 18.9538))
            Chart2.Series.Add(PuntoDiseno1480)
            Chart2.Series(1).Name = "Diseño"
            Chart2.Series("Diseño").ChartType = SeriesChartType.Point
            Chart2.Series("Diseño").BorderWidth = 3
            Chart2.Series("Diseño").Label = 18.95 & ";" & Math.Round(CurveHead(4, 28, 18.95), 1)
            'Fin del bloque

            '------------------ Aquí para agregar la serie de la bomba centrifuga--------------------
            '------------------ Calcula y define el punto de operación de la curva-------------------
            '------------------ En función del caudal manejado en la linea---------------------------
            'Dim Caudal1480 As Double = Math.Round(resulthardycross.SolveHardyCross(0)(0) * 1000 / CInt(NumBomba1480.Text), 1)
            'Aqui deben ir condicionales de evaluación para garantizar al gráfica de puntos de 
            'operación dentro de los rangos de funcionamiento de la bomba
            'Las verificaciones deben hacerce en caudal y en head calculada

            'Condición para saber si la bomba está funcionando en el rango de operación (la altura de la bomba da negativo
            If CInt(CurveHead(4, 28, Caudal1480)) > 625 Then
                Dim PuntoOperacion1480 As New Series()
                PuntoOperacion1480.Points.AddXY(Caudal1480, CurveHead(4, 28, Caudal1480))
                Chart2.Series.Add(PuntoOperacion1480)
                Chart2.Series(2).Name = "Operación"
                Chart2.Series("Operación").ChartType = SeriesChartType.Point
                Chart2.Series("Operación").BorderWidth = 3
                Chart2.Series("Operación").Label = Caudal1480 & ";" & Math.Round(CurveHead(4, 28, Caudal1480), 1)

                If NPSHReq(1, Caudal1480) > CDbl(Tanque0.Text) Then
                    'Incluir sistema de alarmas de cambio de colores de fondo en la vista!
                    MsgBox("Existe riesgo de cavitación en las bombas 1480")
                End If
            Else
                MsgBox("La bomba 1480 está trabajando fuera del rango de operación funcional" & vbCrLf & "el caudal máximo manejado por bomba")
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



            '--------------Bloque de código para los graficos 3 ----------------------
            '-----------------------------------------------------------------------------
            '--------------Bloque para la bomba equivalente 0690 Chart3 ------------------------------
            '-----------------------------------------------------------------------------
            'Dim Caudal0690Sistema As Double = Math.Round(Caudal0690, 2)
            Chart3.Series.Add(Sistema0690)
            Chart3.Series(0).Name = NBombas0690 & " Bombas"
            Chart3.Series(NBombas0690 & " Bombas").ChartType = SeriesChartType.Spline
            Chart3.Series(NBombas0690 & " Bombas").BorderWidth = 3
            Chart3.Series(NBombas0690 & " Bombas").MarkerStyle = MarkerStyle.Square

            'Bloque de código para notar el punto de operación del sistema equivalente
            Dim PuntoDisenoNBombas0690 As New Series()
            PuntoDisenoNBombas0690.Points.AddXY(29.1061 * NBombas0690, CurveHead(NBombas0690, 28, 29.1061 * NBombas0690))
            Chart3.Series.Add(PuntoDisenoNBombas0690)
            Chart3.Series(1).Name = "Diseño"
            Chart3.Series("Diseño").ChartType = SeriesChartType.Point
            Chart3.Series("Diseño").BorderWidth = 3
            Chart3.Series("Diseño").Label = 29.11 * NBombas0690 & ";" & Math.Round(CurveHead(NBombas0690, 28, 29.1061 * NBombas0690), 1)
            'Fin del bloque

            'Condición para saber si la bomba está funcionando en el rango de operación (la altura de la bomba da negativo)
            If CInt(CurveHead(NBombas0690, 28, Caudal0690Sistema)) > 521 Then
                Dim PuntoOperacionSistema0690 As New Series()
                PuntoOperacionSistema0690.Points.AddXY(Caudal0690Sistema, CurveHead(NBombas0690, 28, Caudal0690Sistema))
                Chart3.Series.Add(PuntoOperacionSistema0690)
                Chart3.Series(2).Name = "Operación"
                Chart3.Series("Operación").ChartType = SeriesChartType.Point
                Chart3.Series("Operación").BorderWidth = 3
                Chart3.Series("Operación").Label = Caudal0690Sistema & ";" & Math.Round(CurveHead(NBombas0690, 28, Caudal0690Sistema), 1)
            End If
            Chart3.Titles.Clear()
            Chart3.Titles.Add("Curva Bomba 0690, esta curva es para una bomba de 28 etápas")
            Chart3.ChartAreas(0).AxisX.Title = "Caudal [L/seg]"
            Chart3.ChartAreas(0).AxisY.Title = "Altura [m]"
            Chart3.ChartAreas(0).AxisX.MajorGrid.Enabled = False
            Chart3.ChartAreas(0).AxisY.MajorGrid.Enabled = False
            Chart3.ChartAreas(0).AxisY.Minimum = (Sistema0690.Points().FindMinByValue("Y").YValues(0) - 100)
            '--------------Bloque de código para los graficos 4 ----------------------
            '-----------------------------------------------------------------------------
            '--------------Bloque para la bomba equivalente 0690 Chart4 ------------------------------
            '-----------------------------------------------------------------------------
            'Dim Caudal1480Sistema As Double = Math.Round(Caudal1480 * 1000, 2)
            Chart4.Series.Add(Sistema1480)
            Chart4.Series(0).Name = NBombas1480 & " Bombas"
            Chart4.Series(NBombas1480 & " Bombas").ChartType = SeriesChartType.Spline
            Chart4.Series(NBombas1480 & " Bombas").BorderWidth = 3
            Chart4.Series(NBombas1480 & " Bombas").ToolTip = "#valy"
            Chart4.Series(NBombas1480 & " Bombas").MarkerStyle = MarkerStyle.Square
            '------------------ Aquí para agregar la serie de la bomba centrifuga--------------------
            '------------------ Calcula y define el punto de operación de la curva-------------------
            '------------------ En función del caudal manejado en la linea---------------------------


            'Condición para saber si la bomba está funcionando en el rango de operación (la altura de la bomba da negativa
            If CInt(CurveHead(NBombas1480 + 3, 28, Caudal1480Sistema)) > 625 Then
                Dim PuntoOperacionSistema1480 As New Series()
                PuntoOperacionSistema1480.Points.AddXY(Caudal1480Sistema, CurveHead(NBombas1480 + 3, 28, Caudal1480Sistema))
                Chart4.Series.Add(PuntoOperacionSistema1480)
                Chart4.Series(1).Name = "Operación"
                Chart4.Series("Operación").ChartType = SeriesChartType.Point
                Chart4.Series("Operación").BorderWidth = 3
                Chart4.Series("Operación").Label = Caudal1480Sistema & ";" & Math.Round(CurveHead(NBombas1480 + 3, 28, Caudal1480Sistema), 1)
            End If

            '-----------Aqui termina la definición del grafico del punto de operación de la máquina------

            Chart4.Titles.Clear()
            Chart4.Titles.Add("Curva Bomba 1480")
            Chart4.ChartAreas(0).AxisX.Title = "Caudal [L/seg]"
            Chart4.ChartAreas(0).AxisY.Title = "Altura [m]"
            Chart4.ChartAreas(0).AxisX.MajorGrid.Enabled = False
            Chart4.ChartAreas(0).AxisY.MajorGrid.Enabled = False
            Chart4.ChartAreas(0).AxisY.Minimum = (Bomba1480.Points().FindMinByValue("Y").YValues(0) - 100)
        Catch ex As Exception
            MsgBox("Exepción de desbordamiento en esquema numérico.")
        End Try
       

        PuntoBomba1.BringToFront()
        PuntoBomba2.BringToFront()
        PuntoSistema1.BringToFront()
        PuntoSistema2.BringToFront()
        '---------------------------Aquí código para gestionar las alarmas de funcionamiento incorrecto por npsh----
        '-----------------------------------------------------------------------------------------------------------

       
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
    'Valor por defecto Chart1
    Private Sub PuntoSistema1_CheckedChanged(sender As Object, e As EventArgs) Handles PuntoSistema1.CheckedChanged
        Chart1.BringToFront()
        PuntoBomba1.BringToFront()
        PuntoSistema1.BringToFront()
    End Sub

    Private Sub PuntoBomba1_CheckedChanged(sender As Object, e As EventArgs) Handles PuntoBomba1.CheckedChanged
        Chart3.BringToFront()
        PuntoBomba1.BringToFront()
        PuntoSistema1.BringToFront()
    End Sub

    Private Sub PuntoSistema2_CheckedChanged(sender As Object, e As EventArgs) Handles PuntoSistema2.CheckedChanged
        Chart2.BringToFront()
        PuntoBomba2.BringToFront()
        PuntoSistema2.BringToFront()
    End Sub

    Private Sub PuntoBomba2_CheckedChanged(sender As Object, e As EventArgs) Handles PuntoBomba2.CheckedChanged
        Chart4.BringToFront()
        PuntoBomba2.BringToFront()
        PuntoSistema2.BringToFront()
    End Sub
End Class