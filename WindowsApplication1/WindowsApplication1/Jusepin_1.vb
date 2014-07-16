Imports System.Windows.Forms.DataVisualization.Charting

Public Class Jusepin_1

    Private Sub chart(maquina As String)
        Chart1.Series.Clear()
        Dim series1 As New Series()
        Dim series2 As New Series()
        Dim k As Integer = 0
        For Each value As Decimal In ArrayOfValuesX("Sistema")
            series1.Points.AddXY(value, ArrayOfValuesY("Sistema")(k))
            series2.Points.AddXY(ArrayOfValuesX(maquina)(k), ArrayOfValuesY(maquina)(k))
            k = k + 1
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
        Chart1.Titles.Add("Curva de" & " " & maquina & " y Curva del Sistema")
        Chart1.ChartAreas(0).AxisX.Title = "Caudal [CFM]"
        Chart1.ChartAreas(0).AxisY.Title = "Relación de presión"
        Chart1.ChartAreas(0).AxisX.MajorGrid.Enabled = False
        Chart1.ChartAreas(0).AxisY.MajorGrid.Enabled = False
    End Sub

    Private Sub charts(maquina As String)
        Dim k As Integer
        Dim Chart1 As New Chart
        Dim ChartArea1 As New ChartArea()
        Chart1.ChartAreas.Add(ChartArea1)
        Dim series1 As New Series()
        Dim series2 As New Series()
        For Each value As Decimal In ArrayOfValuesX("Sistema")
            series1.Points.AddXY(value, ArrayOfValuesY("Sistema")(k))
            series2.Points.AddXY(ArrayOfValuesX(maquina)(k), ArrayOfValuesY(maquina)(k))
            k = k + 1
        Next

        series1.ChartArea = "ChartArea1"
        series2.ChartArea = "ChartArea1"
        Chart1.Series.Add(series1)
        Chart1.Series.Add(series2)
        Chart1.Series("Series1").ChartType = SeriesChartType.Spline
        Chart1.Series("Series2").ChartType = SeriesChartType.Spline
        Chart1.Series("Series1").BorderWidth = 3
        Chart1.Series("Series2").BorderWidth = 3
        'esta linea permite visualizar values of points on mouse hover
        Chart1.Series("Series1").ToolTip = "#VALY"
        Chart1.Series("Series2").ToolTip = "#VALY"
        'agregar marcador al gráfico
        Chart1.Series("Series1").MarkerStyle = MarkerStyle.Square
        Chart1.Series("Series2").MarkerStyle = MarkerStyle.Square

        Chart1.Titles.Add("Curva de" & " " & maquina & " y Curva del Sistema")
        Chart1.ChartAreas(0).AxisX.Title = "Caudal [CFM]"
        Chart1.ChartAreas(0).AxisY.Title = "Relación de presión"

        Chart1.ChartAreas(0).AxisX.MajorGrid.Enabled = False
        Chart1.ChartAreas(0).AxisY.MajorGrid.Enabled = False
        Chart1.Location = New System.Drawing.Point(0, 0)
        Chart1.Size = New System.Drawing.Size(340, 240)

        Chart1.BringToFront()
    End Sub
    Public Function ArrayOfValuesX(ByVal Maquina As String) As Array
        Select Case Maquina
            Case "Compre1"
                Return New Decimal(6) {2, 2.05, 2.1, 2.25, 2.4, 2.42, 2.39}
            Case "Compre2"
                Return New Decimal(6) {3, 3.05, 3.1, 3.25, 3.4, 3.42, 3.39}
            Case "Sistema"
                Return New Decimal(6) {1, 1.1, 2, 3.1, 3.5, 4.5, 5}
            Case Else
                Return New Decimal(6) {4, 4.05, 4.1, 4.25, 4.4, 4.42, 4.3}
        End Select
    End Function
    Public Function ArrayOfValuesY(ByVal Maquina As String) As Array
        Select Case Maquina
            Case "Compre1"
                Return New Decimal(6) {3, 2.92, 2.85, 2.7, 2.3, 1.62, 1.1}
            Case "Compre2"
                Return New Decimal(6) {4.1, 4.02, 3.9, 3.7, 3.4, 1.56, 1.3}
            Case "Sistema"
                Return New Decimal(6) {1 * 1.1, 1.1 * 1.1, 2 * 1.1, 3 * 1.1, 3.5 * 1.1, 4.5 * 1.1, 5 * 1.1}
            Case Else
                Return New Decimal(6) {6, 5.9, 5.7, 5.3, 4.6, 3.4, 1.5}
        End Select
    End Function


    Private Sub Jusepin_1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        chart("compre1")
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        GasComposicion.Show()
        Dim gravedadSpecificaDelGas As New ComposicionGas("C1:49;C2:38;C3:13;")
    End Sub
End Class