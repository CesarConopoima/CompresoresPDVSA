Imports System.Windows.Forms.DataVisualization.Charting
Imports WindowsApplication1.UnitsConvert
Imports WindowsApplication1.Similitudes
Public Class SB_CC_Detalle

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        GasComposicion.Show()
    End Sub

    Private Sub chart1Actual(maquina As String, NewCompresorActual As Similitudes, Chart As Chart)
        ' el orden para definir los parametros de la máquina son:
        'Presión acutual, Temp actual,Zactual,PMactual, Kactual,RPMactula,Nombre de la Maquina
        'el orden para definir los parametros de la máquina son:
        'Presión acutual, Temp actual,Zactual,PMactual, Kactual,RPMactula,Nombre de la Maquina
        Dim NewCompresor As New Similitudes(441, 283.9, 0.93, 18.17, 1.28, 12000, maquina) 'Este compresor es el original por diseño de la máquina en cuestión
        Chart.Series.Clear()
        Dim Diseno As New Series()
        Dim Cambio_RPM As New Series()
        Dim Cambio_Cond As New Series()
        Dim k As Integer = NewCompresor.CurvaDisenoCompresorPresion.Item(maquina).GetUpperBound(1)
        For i As Integer = 0 To k
            Diseno.Points.AddXY(NewCompresor.CurvaDisenoCompresorPresion(maquina)(0, i), NewCompresor.CurvaDisenoCompresorPresion(maquina)(1, i))
            Cambio_Cond.Points.AddXY(NewCompresorActual.CurvaCompresorPresionActual(maquina).Item(maquina)(0, i), NewCompresorActual.CurvaCompresorPresionActual(maquina).Item(maquina)(1, i))
        Next
        Chart.Series.Add(Diseno)
        Chart.Series.Add(Cambio_Cond)
        Chart.Series(0).Name = "Diseño"
        Chart.Series(1).Name = "Similitud"
        Chart.Series("Diseño").ChartType = SeriesChartType.Spline
        Chart.Series("Similitud").ChartType = SeriesChartType.Spline
        Chart.Series("Diseño").BorderWidth = 3
        Chart.Series("Similitud").BorderWidth = 3
        Chart.Series("Diseño").ToolTip = "#VALY"
        Chart.Series("Similitud").ToolTip = "#VALY"
        'agregar marcador al gráfico
        Chart.Series("Diseño").MarkerStyle = MarkerStyle.Square
        Chart.Series("Similitud").MarkerStyle = MarkerStyle.Square
        Chart.Titles.Clear()
        Chart.Titles.Add("Curva de diseño y curva equivalente de similitud para " & " " & maquina)
        Chart.ChartAreas(0).AxisX.Title = "Caudal [ACFM]"
        Chart.ChartAreas(0).AxisY.Title = "Presión [psia]"
        Chart.ChartAreas(0).AxisX.MajorGrid.Enabled = False
        Chart.ChartAreas(0).AxisY.MajorGrid.Enabled = False
        'It's necessary a logic here to always have graphs to view, in order to get minor and max from correct serie
        If Cambio_Cond.Points().FindMinByValue("Y").YValues(0) < Diseno.Points().FindMinByValue("Y").YValues(0) Then
            Chart.ChartAreas(0).AxisY.Maximum = (Diseno.Points().FindMaxByValue("Y").YValues(0) + 10)
            Chart.ChartAreas(0).AxisY.Minimum = (Cambio_Cond.Points().FindMinByValue("Y").YValues(0) - 10)
        Else
            Chart.ChartAreas(0).AxisY.Maximum = (Cambio_Cond.Points().FindMaxByValue("Y").YValues(0) + 10)
            Chart.ChartAreas(0).AxisY.Minimum = (Diseno.Points().FindMinByValue("Y").YValues(0) - 10)
        End If
        Chart.BringToFront()
    End Sub

    Private Sub SB_CC_Detalle_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Aqui creo el objeto TurboCompresor con las condiciones de diseño
        Dim TurboCompresor As New Similitudes(441, 283.9, 0.93, 18.17, 1.28, 13400, "Turbo_Expansor")
        Dim Compresor_1 As New Similitudes(441, 283.9, 0.93, 18.17, 1.28, 11000, "Compresor_1_TrenB")
        Dim Compresor_2 As New Similitudes(441, 283.9, 0.93, 18.17, 1.28, 11000, "Compresor_2_TrenB")
        chart1Actual("Turbo_Expansor", TurboCompresor, Chart1)
        chart1Actual("Compresor_1_TrenB", Compresor_1, Chart2)
        chart1Actual("Compresor_2_TrenB", Compresor_2, Chart3)
        PUnitsTurbo.Text = "[psi]"
        TUnitsTurbo.Text = "[K]"
        VelUnitsTurbo.Text = "[RPM]"
        PValueTurbo.Text = DictionarieCompresores.Item("Turbo_Expansor").Item("Turbo_Expansor" & "_P1diseno")
        TValueTurbo.Text = DictionarieCompresores.Item("Turbo_Expansor").Item("Turbo_Expansor" & "_T1diseno")
        VelValueTurbo.Text = DictionarieCompresores.Item("Turbo_Expansor").Item("Turbo_Expansor" & "_RPMdiseno")
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
                m = (SimilitudPressure - Compressor.CurvaCompresorPresionActual(maquina).Item(maquina)(1, i - 1)) / (Caudal - Compressor.CurvaCompresorPresionActual(maquina).Item(maquina)(0, i - 1))
                b = SimilitudPressure - m * Caudal
                CaudalValue = (DischargePressure - b) / m
                flag = False
                Exit For
            End If
        Next
        Return CaudalValue
    End Function

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim TurboCompresor As New Similitudes(441, 283.9, 0.93, 18.17, 1.28, 13400, "Turbo_Expansor")
        Dim DischargePressure As Double = to_Psi(PUnitsDescargaTurbo.Text & "_" & PValueDescargaTurbo.Text)
        If WorkingCaudal(DischargePressure, "Turbo_Expansor", TurboCompresor) = 0 Then
            MsgBox("El punto de funcionamiento que definió, está fuera del rango de operación, la presión es muy baja!")
        Else
            MsgBox(WorkingCaudal(DischargePressure, "Turbo_Expansor", TurboCompresor))
        End If

    End Sub
End Class