Imports System.Windows.Forms.DataVisualization.Charting
Imports WindowsApplication1.UnitsConvert

Public Class Jusepin_Compresores
    'Metodo para crear gráfico que está incrustado en la primera vista, se grafica la curva de diseño on click sobre la etiqueta
    Private Sub chart1Diseno(maquina As String)
        ' el orden para definir los parametros de la máquina son:
        'Presión acutual, Temp actual,Zactual,PMactual, Kactual,RPMactula,Nombre de la Maquina
        Dim NewCompresor As New Similitudes(441, 283.9, 0.93, 18.17, 1.28, 12000, maquina)
        Chart1.Series.Clear()
        Dim Diseno As New Series()
        Dim k As Integer = NewCompresor.CurvaDisenoCompresorPresion.Item(maquina).GetUpperBound(1)
        For i As Integer = 0 To k
            Diseno.Points.AddXY(NewCompresor.CurvaDisenoCompresorPresion(maquina)(0, i), NewCompresor.CurvaDisenoCompresorPresion(maquina)(1, i))
        Next
        Chart1.Series.Add(Diseno)
        Chart1.Series("Series1").ChartType = SeriesChartType.Spline
        Chart1.Series("Series1").BorderWidth = 3
        Chart1.Series("Series1").ToolTip = "#VALY"
        'agregar marcador al gráfico
        Chart1.Series("Series1").MarkerStyle = MarkerStyle.Square
        Chart1.Titles.Clear()
        Chart1.Titles.Add("Curva de" & " " & maquina)
        Chart1.ChartAreas(0).AxisX.Title = "Caudal [ACFM]"
        Chart1.ChartAreas(0).AxisY.Title = "Relación de presión"
        Chart1.ChartAreas(0).AxisX.MajorGrid.Enabled = False
        Chart1.ChartAreas(0).AxisY.MajorGrid.Enabled = False
        Chart1.ChartAreas(0).AxisY.Minimum = (Diseno.Points().FindMinByValue("Y").YValues(0) - 50)
        Chart1.BringToFront()
    End Sub
    'Metodo para graficar en la segunda pestaña, normalmente aqui va grafico de potencia
    Private Sub chart2New(maquina As String)
        ' el orden para definir los parametros de la máquina son:
        'Presión acutual, Temp actual,Zactual,PMactual, Kactual,RPMactula,Nombre de la Maquina
        Dim NewCompresor As New Similitudes(441, 283, 0.93, 18.17, 1.28, 12000, maquina)
        Dim NewCompresor2 As New Similitudes(500, 300, 0.93, 18.17, 1.4, 11000, maquina)
        Chart2.Series.Clear()
        Dim series1 As New Series()
        Dim series2 As New Series()
        Dim series3 As New Series()
        Dim k As Integer = NewCompresor.CurvaDisenoCompresorRPM(maquina).Item(maquina).GetUpperBound(1)
        For i As Integer = 0 To k
            series1.Points.AddXY(NewCompresor.CurvaDisenoCompresorPresion.Item(maquina)(0, i), NewCompresor.CurvaCompresorHeadDiseno(maquina).Item(maquina)(i))
            series2.Points.AddXY(NewCompresor.CurvaDisenoCompresorRPM(maquina).Item(maquina)(0, i), NewCompresor.CurvaDisenoCompresorRPM(maquina).Item(maquina)(1, i))
        Next
        Chart2.Series.Add(series1)
        Chart2.Series.Add(series2)
        Chart2.Series.Add(series3)
        Chart2.Series("Series1").ChartType = SeriesChartType.Spline
        Chart2.Series("Series2").ChartType = SeriesChartType.Spline
        Chart2.Series("Series3").ChartType = SeriesChartType.Spline
        Chart2.Series("Series1").BorderWidth = 3
        Chart2.Series("Series2").BorderWidth = 3
        Chart2.Series("Series3").BorderWidth = 3
        Chart2.Series("Series1").ToolTip = "#VALY"
        Chart2.Series("Series2").ToolTip = "#VALY"
        Chart2.Series("Series3").ToolTip = "#VALY"
        'agregar marcador al gráfico
        Chart2.Series("Series1").MarkerStyle = MarkerStyle.Square
        Chart2.Series("Series2").MarkerStyle = MarkerStyle.Square
        Chart2.Series("Series3").MarkerStyle = MarkerStyle.Square
        Chart2.Titles.Add("Curva de" & " " & maquina)
        Chart2.ChartAreas(0).AxisX.Title = "Caudal [ACFM]"
        Chart2.ChartAreas(0).AxisY.Title = "Relación de presión"
        Chart2.ChartAreas(0).AxisX.MajorGrid.Enabled = False
        Chart2.ChartAreas(0).AxisY.MajorGrid.Enabled = False
    End Sub
    'Crear graph pasandole el tipo de maquina que se esta graficando como un parametro y el nuevo objeto para graficar haciendo similitud
    Private Sub chart1New(maquina As String, NewCompresorActual As Similitudes)
        'el orden para definir los parametros de la máquina son:
        'Presión acutual, Temp actual,Zactual,PMactual, Kactual,RPMactula,Nombre de la Maquina
        Dim NewCompresor As New Similitudes(441, 283.9, 0.93, 18.17, 1.28, 12000, maquina)
        Chart1.Series.Clear()
        Dim Diseno As New Series()
        Dim Cambio_RPM As New Series()
        Dim Cambio_Cond As New Series()
        Dim k As Integer = NewCompresor.CurvaDisenoCompresorPresion.Item(maquina).GetUpperBound(1)
        For i As Integer = 0 To k
            Diseno.Points.AddXY(NewCompresor.CurvaDisenoCompresorPresion(maquina)(0, i), NewCompresor.CurvaDisenoCompresorPresion(maquina)(1, i))
            Cambio_Cond.Points.AddXY(NewCompresorActual.CurvaCompresorPresionActual(maquina).Item(maquina)(0, i), NewCompresorActual.CurvaCompresorPresionActual(maquina).Item(maquina)(1, i))
        Next
        Chart1.Series.Add(Diseno)
        Chart1.Series.Add(Cambio_Cond)
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
        Chart1.Titles.Add("Curva de diseño" & " " & maquina)
        Chart1.ChartAreas(0).AxisX.Title = "Caudal [ACFM]"
        Chart1.ChartAreas(0).AxisY.Title = "Relación de presión"
        Chart1.ChartAreas(0).AxisX.MajorGrid.Enabled = False
        Chart1.ChartAreas(0).AxisY.MajorGrid.Enabled = False
        'Chart1.ChartAreas(0).AxisX.Maximum = (Cambio_Cond.Points().FindMaxByValue("X").YValues(1) + 50)
        Chart1.ChartAreas(0).AxisY.Minimum = (Cambio_Cond.Points().FindMinByValue("Y").YValues(0) - 50)
        Chart1.BringToFront()
    End Sub

    'cuando la Forma llamada Jusepin carga, se cambia el gráfico incrustado en la pestaña de la forma
    Private Sub Jusepin_1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        chart2New("compresor_1_Jusepin")
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        GasComposicion.Show()
    End Sub

    Private Sub Label12_Click(sender As Object, e As EventArgs) Handles Label12.Click
        Dim name As String = Label12.Text
        Dim NewCompresor As New Similitudes(100, 300, 33, 230, 15, 23, name)
        Tambiental.Text = NewCompresor.DictionarieCompresores.Item(name).Item(name & "_P1diseno")
        T1diseno.Text = NewCompresor.DictionarieCompresores.Item(name).Item(name & "_T1diseno")
        RPMdiseno.Text = NewCompresor.DictionarieCompresores.Item(name).Item(name & "_RPMdiseno")
        PMdiseno.Text = NewCompresor.DictionarieCompresores.Item(name).Item(name & "_PMdiseno")
        Zdiseno.Text = NewCompresor.DictionarieCompresores.Item(name).Item(name & "_Zdiseno")
        'Estos valores se definen por defecto para que no hayan errores cuando se haga click al boton 
        P1succion.Text = NewCompresor.DictionarieCompresores.Item(name).Item(name & "_P1diseno")
        T1succion.Text = NewCompresor.DictionarieCompresores.Item(name).Item(name & "_T1diseno")
        Coefdiseno.Text = NewCompresor.DictionarieCompresores.Item(name).Item(name & "_Kdiseno")
        chart1Diseno(name)
    End Sub

    'Boton para hacer similitudes
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim PresionUnits, PresionValue, TemperaturaUnits, TemperaturaValues, RPMUnits, RPMValues As String
        Dim Presion, Temperatura, RPM As Double
        PresionUnits = PresionUnidades.Text
        PresionValue = P1succion.Text
        Presion = to_Psi(PresionUnits & "_" & PresionValue)
        TemperaturaUnits = TemperaturaUnidades.Text
        TemperaturaValues = T1succion.Text
        Temperatura = to_Kelvin(TemperaturaUnits & "_" & TemperaturaValues)
        RPMUnits = RPMUnidades.Text
        RPMValues = RPMValor.Text
        RPM = to_RPM(RPMUnits & "_" & RPMValues)
        ''''''''''''''''''''''''''''''''''''''''''
        'Aqui defines las condiciones de diseno del equipo que se selecciona, pasandole el argumento a este método
        'Ojo que esto no está integrado con la selección de las etiquetas.. es necesario hacer un flag que permita
        'saber a quién se ha seleccionado
        Dim NewCompresor As New Similitudes(Presion, Temperatura, 0.93, 18.17, 1.28, RPM, "compresor_1_Jusepin")
        chart1New("compresor_1_Jusepin", NewCompresor)
    End Sub

End Class