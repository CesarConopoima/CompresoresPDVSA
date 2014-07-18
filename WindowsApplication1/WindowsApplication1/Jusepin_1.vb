Imports System.Windows.Forms.DataVisualization.Charting

Public Class Jusepin_1
    'Metodo para crear gráfico que está incrustado en la primera vista
    Private Sub chart(maquina As String)
        Dim NewCompresor As New Similitudes(100, 300, 33, 230, 15, 23, "compresor_1_Jusepin")
        Chart1.Series.Clear()
        Dim series1 As New Series()
        Dim series2 As New Series()
        Dim k As Integer = NewCompresor.CurvaDisenoCompresorPresion.Item(maquina).GetUpperBound(1)
        For i As Integer = 0 To k
            series1.Points.AddXY(NewCompresor.CurvaDisenoCompresorPresion.Item(maquina)(0, i), NewCompresor.CurvaDisenoCompresorHead(maquina).Item(maquina)(i))
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
        Chart1.Titles.Add("Curva de" & " " & maquina)
        Chart1.ChartAreas(0).AxisX.Title = "Caudal [CFM]"
        Chart1.ChartAreas(0).AxisY.Title = "Relación de presión"
        Chart1.ChartAreas(0).AxisX.MajorGrid.Enabled = False
        Chart1.ChartAreas(0).AxisY.MajorGrid.Enabled = False
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
    'cuando la Forma llamada Jusepin carga, se cambia el gráfico incrustado en la pestaña de la forma
    Private Sub Jusepin_1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim NewCompresor As New Similitudes(100, 300, 33, 230, 15, 23, "Jusepin")
        P1diseno.Text = NewCompresor.DictionarieCompresores.Item("compresor_1_Jusepin").Item("compresor_1_Jusepin_P1Diseno")
        T1diseno.Text = NewCompresor.DictionarieCompresores.Item("compresor_2_Jusepin").Item("compresor_2_Jusepin_T1Diseno")
        proff.Text = NewCompresor.CurvaDisenoCompresorHead("compresor_1_Jusepin").Item("compresor_1_Jusepin").Count
        chart("compresor_1_Jusepin")
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        GasComposicion.Show()
    End Sub
End Class