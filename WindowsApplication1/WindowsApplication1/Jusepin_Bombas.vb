Imports System.Windows.Forms.DataVisualization.Charting
Imports WindowsApplication1.UnitsConvert
Imports WindowsApplication1.CurvasEquipos

Public Class Jusepin_Bombas
    'Esta variable sirve de auxiliar para saber cual equipo se está graficando actualmente
    Public EquipoActual As String
    'Metodo para crear gráfico que está incrustado en la primera vista, se grafica la curva de diseño on click sobre la etiqueta
    Private Sub chart1Diseno(maquina As String)
        ' el orden para definir los parametros de la máquina son:
        'Presión acutual, Temp actual,Zactual,PMactual, Kactual,RPMactula,Nombre de la Maquina
        Dim NewBomba As New CurvasEquipos
        Chart1.Series.Clear()
        Dim Diseno As New Series()
        Dim k As Integer = NewBomba.CurvaDisenoEquipo.Item(maquina).GetUpperBound(1)
        Dim NBombas As Integer = CInt(NumBombas.Text)
        For i As Integer = 0 To k
            'Ojo estos puntos estan en litros y la altura en [m]
            Diseno.Points.AddXY(Math.Round(NewBomba.CurvaDisenoEquipo.Item(maquina)(0, i) * 0.06309, 2) * NBombas, Math.Round(NewBomba.CurvaDisenoEquipo.Item(maquina)(1, i) / 3.28, 2))
        Next
        Chart1.Series.Add(Diseno)
        Chart1.Series("Series1").ChartType = SeriesChartType.Spline
        Chart1.Series("Series1").BorderWidth = 3
        Chart1.Series("Series1").ToolTip = "#VALY"
        'agregar marcador al gráfico
        Chart1.Series("Series1").MarkerStyle = MarkerStyle.Square
        Chart1.Titles.Clear()
        Chart1.Titles.Add("Curva de" & " " & maquina & " esta curva es para una bomba de 28 etápas")
        Chart1.ChartAreas(0).AxisX.Title = "Caudal [L/seg]"
        Chart1.ChartAreas(0).AxisY.Title = "Altura [m]"
        Chart1.ChartAreas(0).AxisX.MajorGrid.Enabled = False
        Chart1.ChartAreas(0).AxisY.MajorGrid.Enabled = False
        Chart1.ChartAreas(0).AxisY.Minimum = (Diseno.Points().FindMinByValue("Y").YValues(0) - 100)
        Chart1.BringToFront()
    End Sub
    Private Sub chartSimilitudTotal(maquina As String, NumEtapas As Integer, rpm As Integer)
        ' el orden para definir los parametros de la máquina son:
        'Presión acutual, Temp actual,Zactual,PMactual, Kactual,RPMactula,Nombre de la Maquina
        Dim NewBomba As New CurvasEquipos
        Dim CuvaBombaSimilitud As New Similitudes
        Chart1.Series.Clear()
        Dim series1 As New Series()
        Dim series2 As New Series()
        Dim k As Integer = NewBomba.CurvaDisenoEquipo.Item(maquina).GetUpperBound(1)
        Dim NBombas As Integer = CInt(NumBombas.Text)
        For i As Integer = 0 To k
            series1.Points.AddXY(Math.Round(NewBomba.CurvaDisenoEquipo.Item(maquina)(0, i) * 0.06309, 2) * NBombas, Math.Round(NewBomba.CurvaDisenoEquipo.Item(maquina)(1, i) / 3.28, 2))
            series2.Points.AddXY(Math.Round(CuvaBombaSimilitud.CurvaBombaEtapas(maquina, NumEtapas, rpm).Item(maquina)(0, i) * 0.06309, 2) * NBombas, Math.Round(CuvaBombaSimilitud.CurvaBombaEtapas(maquina, NumEtapas, rpm).Item(maquina)(1, i) / 3.28, 2))
            'series2.Points.AddXY(NewCompresor.CurvaDisenoCompresorRPM(maquina).Item(maquina)(0, i), NewCompresor.CurvaDisenoCompresorRPM(maquina).Item(maquina)(1, i))
        Next
        Chart1.Series.Add(series1)
        Chart1.Series.Add(series2)
        Chart1.Series("Series1").ChartType = SeriesChartType.Spline
        Chart1.Series("Series2").ChartType = SeriesChartType.Spline
        Chart1.Series("Series1").BorderWidth = 3
        Chart1.Series("Series2").BorderWidth = 3
        Chart1.Series("Series1").ToolTip = "#VALY"
        Chart1.Series("Series2").ToolTip = "#VALY"
        'agregar marcador al gráfico
        Chart1.Series("Series1").MarkerStyle = MarkerStyle.Square
        Chart1.Series("Series2").MarkerStyle = MarkerStyle.Square
        Chart1.Titles.Clear()
        Chart1.Titles.Add("Curva de similitud con número de etápas" & " " & maquina)
        Chart1.ChartAreas(0).AxisX.Title = "Caudal [L/seg]"
        Chart1.ChartAreas(0).AxisY.Title = "Altura [m]"
        Chart1.ChartAreas(0).AxisX.MajorGrid.Enabled = False
        Chart1.ChartAreas(0).AxisY.MajorGrid.Enabled = False
        Chart1.ChartAreas(0).AxisY.Minimum = (series2.Points().FindMinByValue("Y").YValues(0) - 100)
        Chart1.BringToFront()
    End Sub
    'Metodo para graficar en la segunda pestaña, normalmente aqui va grafico de potencia
    'Private Sub GraficoSegundaPestana(maquina As String, NumEtapas As Integer)
    '    ' el orden para definir los parametros de la máquina son:
    '    'Presión acutual, Temp actual,Zactual,PMactual, Kactual,RPMactula,Nombre de la Maquina
    '    Dim NewBomba As New CurvasEquipos
    '    Dim CuvaBombaSimilitud As New Similitudes
    '    Chart2.Series.Clear()
    '    Dim series1 As New Series()
    '    Dim series2 As New Series()
    '    Dim series3 As New Series()
    '    Dim k As Integer = NewBomba.CurvaDisenoEquipo.Item(maquina).GetUpperBound(1)
    '    For i As Integer = 0 To k
    '        series1.Points.AddXY(NewBomba.CurvaDisenoEquipo.Item(maquina)(0, i), NewBomba.CurvaDisenoEquipo.Item(maquina)(1, i))
    '        series2.Points.AddXY(CuvaBombaSimilitud.CurvaBombaEtapas(maquina, NumEtapas).Item(maquina)(0, i), CuvaBombaSimilitud.CurvaBombaEtapas(maquina, NumEtapas).Item(maquina)(1, i))
    '        'series2.Points.AddXY(NewCompresor.CurvaDisenoCompresorRPM(maquina).Item(maquina)(0, i), NewCompresor.CurvaDisenoCompresorRPM(maquina).Item(maquina)(1, i))
    '    Next
    '    Chart2.Series.Add(series1)
    '    Chart2.Series.Add(series2)
    '    Chart2.Series.Add(series3)
    '    Chart2.Series("Series1").ChartType = SeriesChartType.Spline
    '    Chart2.Series("Series2").ChartType = SeriesChartType.Spline
    '    Chart2.Series("Series3").ChartType = SeriesChartType.Spline
    '    Chart2.Series("Series1").BorderWidth = 3
    '    Chart2.Series("Series2").BorderWidth = 3
    '    Chart2.Series("Series3").BorderWidth = 3
    '    Chart2.Series("Series1").ToolTip = "#VALY"
    '    Chart2.Series("Series2").ToolTip = "#VALY"
    '    Chart2.Series("Series3").ToolTip = "#VALY"
    '    'agregar marcador al gráfico
    '    Chart2.Series("Series1").MarkerStyle = MarkerStyle.Square
    '    Chart2.Series("Series2").MarkerStyle = MarkerStyle.Square
    '    Chart2.Series("Series3").MarkerStyle = MarkerStyle.Square
    '    Chart2.Titles.Add("Curva de" & " " & maquina)
    '    Chart2.ChartAreas(0).AxisX.Title = "Caudal [ACFM]"
    '    Chart2.ChartAreas(0).AxisY.Title = "Relación de presión"
    '    Chart2.ChartAreas(0).AxisX.MajorGrid.Enabled = False
    '    Chart2.ChartAreas(0).AxisY.MajorGrid.Enabled = False
    'End Sub
    'cuando la Forma llamada Jusepin carga, se cambia el gráfico incrustado en la pestaña de la forma
    Private Sub Jusepin_Bombas_load(sender As Object, e As EventArgs) Handles MyBase.Load
        RPMUnidades.Text = "[RPM]"
        NumBombas.Text = 1
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        GasComposicion.Show()
    End Sub
    'Para Gráficar la primera bomba
    Private Sub Label12_Click(sender As Object, e As EventArgs) Handles Label12.Click
        Dim name As String = Label12.Text
        'Esta linea sirve para saber quien se está graficando actualmente, para el boton que envia hacer la similitud
        EquipoActual = name
        'Dim NewCompresor As New Similitudes(100, 300, 33, 230, 15, 23, name)
        Qdiseno.Text = Math.Round(441.76 * 0.06309 * CInt(NumBombas.Text), 2)
        Hdiseno.Text = 1363.7
        EficMax.Text = 76.6
        chart1Diseno(name)
    End Sub
    'Para Gráficar la segunda bomba
    Private Sub Label14_Click(sender As Object, e As EventArgs) Handles Label14.Click
        Dim name As String = Label14.Text
        'Esta linea sirve para saber quien se está graficando actualmente, para el boton que envia hacer la similitud
        EquipoActual = name
        Qdiseno.Text = Math.Round(441.76 * 0.06309 * CInt(NumBombas.Text), 2)
        Hdiseno.Text = 1363.7
        EficMax.Text = 76.6
        chart1Diseno(name)
    End Sub

    'Boton para hacer similitudes
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim RPMUnits, RPMValues As String
        Dim RPM, NumEtapas As Integer
        RPMUnits = RPMUnidades.Text
        RPMValues = RPMValor.Text
        ''''''''''''''''''''''''''''''''''''''''''
        'Aqui defines las condiciones de diseno del equipo que se selecciona, pasandole el argumento a este método
        'Dim NewCompresor As New Similitudes(Presion, Temperatura, 0.93, 18.17, 1.28, RPM, "compresor_1_Jusepin")
        If NEtapas.Text = "" And RPMValor.Text = "" Then
            NumEtapas = "28"
            RPM = 3580
        ElseIf NEtapas.Text = "" Then
            NumEtapas = "28"
            RPM = to_RPM(RPMUnits & "_" & RPMValues)
        ElseIf RPMValor.Text = "" Then
            NumEtapas = NEtapas.Text
            RPM = 3580
        Else
            NumEtapas = NEtapas.Text
            RPM = to_RPM(RPMUnits & "_" & RPMValues)
        End If
        Try
            chartSimilitudTotal(EquipoActual, NumEtapas, RPM)
        Catch ex As Exception
            MsgBox("Debe seleccionar un equipo para hacer similitud!")
        End Try

    End Sub


    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        SolucionSistemaBombeo.Show()
    End Sub

End Class