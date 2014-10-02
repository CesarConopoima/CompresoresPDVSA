Imports System.Windows.Forms.DataVisualization.Charting
Imports WindowsApplication1.UnitsConvert
Imports WindowsApplication1.Similitudes

Public Class SantaBarbara_CC
    'Metodo para crear gráfico que está incrustado en la primera vista, se grafica la curva de diseño on click sobre la etiqueta
    Private Sub chart1Diseno(maquina As String)
        ' el orden para definir los parametros de la máquina son:
        'Presión acutual, Temp actual,Zactual,PMactual, Kactual,RPMactula,Nombre de la Maquina
        Dim NewCompresor As New Similitudes(441, 283.71, 0.93, 18.17, 1.28, 13400, maquina)
        Chart1.Series.Clear()
        Dim Diseno As New Series()
        Dim k As Integer = NewCompresor.CurvaDisenoCompresorPresion(maquina).GetUpperBound(1)
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
        Chart1.ChartAreas(0).AxisY.Title = "Presión [psia]"
        Chart1.ChartAreas(0).AxisX.MajorGrid.Enabled = False
        Chart1.ChartAreas(0).AxisY.MajorGrid.Enabled = False
        Chart1.ChartAreas(0).AxisY.Maximum = (Diseno.Points().FindMinByValue("Y").YValues(0) + 10)
        Chart1.ChartAreas(0).AxisY.Minimum = (Diseno.Points().FindMinByValue("Y").YValues(0) - 10)
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
        Chart2.ChartAreas(0).AxisY.Title = "Presión [psia]"
        Chart2.ChartAreas(0).AxisX.MajorGrid.Enabled = False
        Chart2.ChartAreas(0).AxisY.MajorGrid.Enabled = False
    End Sub
    'Crear graph pasandole el tipo de maquina que se esta graficando como un parametro y el nuevo objeto para graficar haciendo similitud
    Private Sub chart1New(maquina As String, NewCompresorActual As Similitudes)
        'el orden para definir los parametros de la máquina son:
        'Presión acutual, Temp actual,Zactual,PMactual, Kactual,RPMactula,Nombre de la Maquina
        Dim NewCompresor As New Similitudes(441, 283.9, 0.93, 18.17, 1.28, 12000, maquina) 'Este compresor es el original por diseño de la máquina en cuestión
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
        Chart1.Series(0).Name = "Diseño"
        Chart1.Series(1).Name = "Similitud"
        Chart1.Series("Diseño").ChartType = SeriesChartType.Spline
        Chart1.Series("Similitud").ChartType = SeriesChartType.Spline
        Chart1.Series("Diseño").BorderWidth = 3
        Chart1.Series("Similitud").BorderWidth = 3
        Chart1.Series("Diseño").ToolTip = "#VALY"
        Chart1.Series("Similitud").ToolTip = "#VALY"
        'agregar marcador al gráfico
        Chart1.Series("Diseño").MarkerStyle = MarkerStyle.Square
        Chart1.Series("Similitud").MarkerStyle = MarkerStyle.Square
        Chart1.Titles.Clear()
        Chart1.Titles.Add("Curva de diseño y curva equivalente de similitud para " & " " & maquina)
        Chart1.ChartAreas(0).AxisX.Title = "Caudal [ACFM]"
        Chart1.ChartAreas(0).AxisY.Title = "Presión [psia]"
        Chart1.ChartAreas(0).AxisX.MajorGrid.Enabled = False
        Chart1.ChartAreas(0).AxisY.MajorGrid.Enabled = False
        'It's necessary a logic here to always have graphs to view, in order to get minor and max from correct serie
        If Cambio_Cond.Points().FindMinByValue("Y").YValues(0) < Diseno.Points().FindMinByValue("Y").YValues(0) Then
            Chart1.ChartAreas(0).AxisY.Maximum = (Diseno.Points().FindMaxByValue("Y").YValues(0) + 10)
            Chart1.ChartAreas(0).AxisY.Minimum = (Cambio_Cond.Points().FindMinByValue("Y").YValues(0) - 10)
        Else
            Chart1.ChartAreas(0).AxisY.Maximum = (Cambio_Cond.Points().FindMaxByValue("Y").YValues(0) + 10)
            Chart1.ChartAreas(0).AxisY.Minimum = (Diseno.Points().FindMinByValue("Y").YValues(0) - 10)
        End If
        Chart1.BringToFront()
    End Sub

    'cuando la Forma llamada Jusepin carga, se cambia el gráfico incrustado en la pestaña de la forma
    Private Sub Jusepin_1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        chart2New("Turbo_Expansor")
        chart1Diseno("Turbo_Expansor")
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        GasComposicion.Show()
    End Sub

    Private Sub label12_click(sender As Object, e As EventArgs) Handles TurboExpansor.Click
        Dim name As String = TurboExpansor.text
        Dim newcompresor As New Similitudes(100, 300, 33, 230, 15, 23, name)
        P1diseno.Text = DictionarieCompresores.Item(name).Item(name & "_P1diseno")
        T1diseno.Text = DictionarieCompresores.Item(name).Item(name & "_T1diseno")
        RPMdiseno.Text = DictionarieCompresores.Item(name).Item(name & "_RPMdiseno")
        PMdiseno.Text = DictionarieCompresores.Item(name).Item(name & "_PMdiseno")
        Zdiseno.Text = DictionarieCompresores.Item(name).Item(name & "_Zdiseno")
        Coefdiseno.Text = DictionarieCompresores.Item(name).Item(name & "_Kdiseno")
        'estos valores se definen por defecto para que no hayan errores cuando se haga click al boton 
        P1succion.Text = DictionarieCompresores.Item(name).Item(name & "_P1diseno")
        T1succion.Text = DictionarieCompresores.Item(name).Item(name & "_T1diseno")
        RPMValor.Text = DictionarieCompresores.Item(name).Item(name & "_RPMdiseno")
        PMSuccion.Text = Math.Round(DictionarieCompresores.Item(name).Item(name & "_PMdiseno"), 2)
        CoefPolitroSuccion.Text = Math.Round(DictionarieCompresores.Item(name).Item(name & "_Kdiseno"), 2)
        PresionUnits.Text = "[psi]"
        TempUnits.Text = "[K]"
        RPMUnits.Text = "[RPM]"
        chart1Diseno(name)
        'Aquí incluire al nombre de la maquína en cuestion para luego hacer similitud con la 
        'máquina correcta
        FlagForSimilitud.Text = "Condiciones cambiantes para " & name
    End Sub
    'On click del compresor 1 del trenB, se muestran las condiciones de diseño en los tags
    Private Sub Label20_Click(sender As Object, e As EventArgs) Handles Compresor1.Click
        Dim name As String = Compresor1.Text
        Dim newcompresor As New Similitudes(100, 300, 33, 230, 15, 23, name)
        P1diseno.Text = DictionarieCompresores.Item(name).Item(name & "_P1diseno")
        T1diseno.Text = DictionarieCompresores.Item(name).Item(name & "_T1diseno")
        RPMdiseno.Text = DictionarieCompresores.Item(name).Item(name & "_RPMdiseno")
        PMdiseno.Text = DictionarieCompresores.Item(name).Item(name & "_PMdiseno")
        Zdiseno.Text = DictionarieCompresores.Item(name).Item(name & "_Zdiseno")
        Coefdiseno.Text = DictionarieCompresores.Item(name).Item(name & "_Kdiseno")
        'estos valores se definen por defecto para que no hayan errores cuando se haga click al boton 
        P1succion.Text = DictionarieCompresores.Item(name).Item(name & "_P1diseno")
        T1succion.Text = DictionarieCompresores.Item(name).Item(name & "_T1diseno")
        RPMValor.Text = DictionarieCompresores.Item(name).Item(name & "_RPMdiseno")
        PMSuccion.Text = Math.Round(DictionarieCompresores.Item(name).Item(name & "_PMdiseno"), 2)
        CoefPolitroSuccion.Text = Math.Round(DictionarieCompresores.Item(name).Item(name & "_Kdiseno"), 2)
        PresionUnits.Text = "[psi]"
        TempUnits.Text = "[K]"
        RPMUnits.Text = "[RPM]"
        chart1Diseno(name)
        FlagForSimilitud.Text = "Condiciones cambiantes para " & name
    End Sub
    'Boton para hacer similitudes, recoge los distintos valores de las condiciones en
    'la succión para hacer similitud
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim maquina As String = Split(FlagForSimilitud.Text, " ").Last
        Dim Presion, Temperatura, RPM, PM, CoefPolitropico As Double
        Try
            Presion = to_Psi(PresionUnits.Text & "_" & P1succion.Text)
            Temperatura = to_Kelvin(TempUnits.Text & "_" & T1succion.Text)
            RPM = to_RPM(RPMUnits.Text & "_" & RPMValor.Text)
            PM = CDbl(PMSuccion.Text)
            CoefPolitropico = CDbl(CoefPolitroSuccion.Text)

            ''''''''''''''''''''''''''''''''''''''''''
            'Aqui defines las condiciones de diseno del equipo que se selecciona, pasandole el argumento a este método
            'Ojo que esto no está integrado con la selección de las etiquetas.. es necesario hacer un flag que permita
            'saber a quién se ha seleccionado
            Dim NewCompresor As New Similitudes(Presion, Temperatura, 0.93, PM, CoefPolitropico, RPM, maquina)
            chart1New(maquina, NewCompresor)
        Catch ex As Exception
            MsgBox("Escoja un compresor!.")
        End Try

       
    End Sub
    'Aqui función para determinar el caudal apartir de la curva de simitud de una maquíana y el presión de descarga
    'el argumento de esta función es la presión de descarga en cuestion en [psi], el nombre de la máquina y un objeto Similitud que es la máquina en las nuevas condiciones de operación
    Private Function WorkingCaudal(DischargePressure As Double, maquina As String, Compressor As Similitudes) As Integer
        Dim SimilitudPressure, Caudal, m, b, CaudalValue As Double
        Dim flag As Boolean = True
        Dim k As Integer = Compressor.CurvaDisenoCompresorPresion.Item(maquina).GetUpperBound(1)
        For i As Integer = 0 To k
            SimilitudPressure = Compressor.CurvaCompresorPresionActual(maquina).Item(maquina)(1, i)
            Caudal = Compressor.CurvaCompresorPresionActual(maquina).Item(maquina)(0, i)
            If SimilitudPressure < DischargePressure And flag = True Then
                'Ojo aquí hay un flag, puede suceder que desde el principio se tenga el punto por encima de la curva
                MsgBox(SimilitudPressure & "  " & DischargePressure & i)
                m = (SimilitudPressure - Compressor.CurvaCompresorPresionActual(maquina).Item(maquina)(1, i - 1)) / (Caudal - Compressor.CurvaCompresorPresionActual(maquina).Item(maquina)(0, i - 1))
                b = SimilitudPressure - m * Caudal
                CaudalValue = (DischargePressure - b) / m
                flag = False
                Exit For
            End If
        Next
        Return CaudalValue
    End Function

    Private Sub CalculateCaudal_Click(sender As Object, e As EventArgs) Handles CalculateCaudal.Click
        SB_CC_Detalle.Show()
        'Dim maquina As String = Split(FlagForSimilitud.Text, " ").Last
        'Dim Presion, Temperatura, RPM, PM, CoefPolitropico, PressureAtDischarge As Double
        'Presion = to_Psi(PresionUnits.Text & "_" & P1succion.Text)
        'Temperatura = to_Kelvin(TempUnits.Text & "_" & T1succion.Text)
        'RPM = to_RPM(RPMUnits.Text & "_" & RPMValor.Text)
        'PM = CDbl(PMSuccion.Text)
        'CoefPolitropico = CDbl(CoefPolitroSuccion.Text)
        'PressureAtDischarge = to_Psi(DischargePresionUnits.Text & "_" & PresionDescarga.Text)

        ' ''''''''''''''''''''''''''''''''''''''''''
        ''Aqui defines las condiciones de diseno del equipo que se selecciona, pasandole el argumento a este método
        ''Ojo que esto no está integrado con la selección de las etiquetas.. es necesario hacer un flag que permita
        ''saber a quién se ha seleccionado
        'Dim NewCompresor As New Similitudes(Presion, Temperatura, 0.93, PM, CoefPolitropico, RPM, maquina)
        'If maquina = "Turbo_Expansor" And CDbl(PresionDescarga.Text) <> 0 Then
        '    Try
        '        If WorkingCaudal(PressureAtDischarge, maquina, NewCompresor) = 0 Then
        '            MsgBox("El punto de funcionamiento que definió, está fuera del rango de operación, la presión es muy baja!")
        '        Else
        '            MsgBox(WorkingCaudal(PressureAtDischarge, maquina, NewCompresor))
        '        End If
        '    Catch ex As Exception
        '        MsgBox("El punto de funcionamiento que definió, está fuera del rango de operación, la presión es muy alta!")
        '    End Try

        'End If
    End Sub

End Class