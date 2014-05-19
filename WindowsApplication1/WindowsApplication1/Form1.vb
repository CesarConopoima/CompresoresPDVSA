Imports System.Windows.Forms.DataVisualization.Charting

Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs)
    End Sub
    ' metodo para hacer charts teniendo como argumento cual maquina se quiere graficar
    Private Sub charts(maquina As String)
        Dim k As Integer
        Dim Chart1 As New Chart
        Dim ChartArea1 As New ChartArea()
        Chart1.ChartAreas.Add(ChartArea1)
        Dim series1 As New Series()
        Dim series2 As New Series()
        For Each value As Double In ArrayOfValuesX("Sistema")
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
        Chart1.Titles.Add("Curva de" & " " & maquina & " y Curva del Sistema")
        Chart1.Location = New System.Drawing.Point(20, 290)
        Chart1.Size = New System.Drawing.Size(340, 240)
        Me.Controls.Add(Chart1)
        Chart1.BringToFront()
    End Sub


    'Este método grafica las curvas del compresor haciendo similitud en función del nuevo 
    'valor de rpm puesto en la form3 
    Public Sub chartsChanged(maquina As String, factor As Double)
        Dim k As Integer
        Dim Chart1 As New Chart
        Dim ChartArea1 As New ChartArea()
        Chart1.ChartAreas.Add(ChartArea1)
        Dim series1 As New Series()
        Dim series2 As New Series()
        Dim series3 As New Series()
        Dim similitudInCurve(6) As Double
        For Each value As Double In ArrayOfValuesY(maquina)
            similitudInCurve(k) = value * factor
            k = k + 1
        Next
        k = 0
        For Each value As Double In ArrayOfValuesX("Sistema")
            series1.Points.AddXY(value, ArrayOfValuesY("Sistema")(k))
            series2.Points.AddXY(ArrayOfValuesX("compre1")(k), ArrayOfValuesY("compre1")(k))
            series3.Points.AddXY(ArrayOfValuesX(maquina)(k), similitudInCurve(k))
            k = k + 1
        Next
        series1.ChartArea = "ChartArea1"
        series2.ChartArea = "ChartArea1"
        series3.ChartArea = "ChartArea1"
        Chart1.Series.Add(series1)
        Chart1.Series.Add(series2)
        Chart1.Series.Add(series3)
        Chart1.Series("Series1").ChartType = SeriesChartType.Spline
        Chart1.Series("Series2").ChartType = SeriesChartType.Spline
        Chart1.Series("Series3").ChartType = SeriesChartType.Spline
        Chart1.Titles.Add("Curva de" & " " & maquina & " y Curva del Sistema Haciendo Similitud con RPM")
        Chart1.Location = New System.Drawing.Point(20, 290)
        Chart1.Size = New System.Drawing.Size(340, 240)
        Me.Controls.Add(Chart1)
        Chart1.BringToFront()
    End Sub

    'Acción que se lleva a cabo on click de las imagenes y en doble click de las mismas
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        charts("Compre1")
    End Sub
    Public Sub PictureBox1_Double_Click(sender As Object, e As EventArgs) Handles PictureBox1.DoubleClick
        Dim rpm, Rp, Eficiencia, equipo As String
        equipo = "compre1"
        rpm = "5000"
        Rp = "3.5"
        Eficiencia = "70%"
        Form3.Show()
        Form3.DefineProperties(rpm, Rp, Eficiencia, equipo)
    End Sub
    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        charts("Compre2")
    End Sub
    Public Sub PictureBox2_Duble_Click(sender As Object, e As EventArgs) Handles PictureBox2.DoubleClick
        Dim rpm, Rp, Eficiencia, equipo As String
        equipo = "compre2"
        rpm = "7500"
        Rp = "4"
        Eficiencia = "70%"
        Form3.Show()
        Form3.DefineProperties(rpm, Rp, Eficiencia, equipo)
    End Sub
    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        charts("Compre3")
    End Sub
    Public Sub PictureBox3_Double_Click(sender As Object, e As EventArgs) Handles PictureBox3.DoubleClick
        Dim rpm, Rp, Eficiencia, equipo As String
        equipo = "compre3"
        rpm = "5500"
        Rp = "3.9"
        Eficiencia = "70%"
        Form3.Show()
        Form3.DefineProperties(rpm, Rp, Eficiencia, equipo)
    End Sub
    'Fin del bloque de que acciones propias de las images.!!
    'Ojo con esta metodología la cantidad de lineas escala con la cantidad de equipos disponibles
    'en la linea


    'aqui los puntos de operación de las curvas ficticias de los equipos
    Public Function ArrayOfValuesX(ByVal Maquina As String) As Array
        Select Case Maquina
            Case "Compre1"
                Return New Double(6) {1, 2, 3, 4, 5, 6, 7}
            Case "Compre2"
                Return New Double(6) {3, 4, 5, 6, 7, 8, 9}
            Case "Sistema"
                Return New Double(6) {1, 2.5, 4.5, 6.9, 8.5, 10.5, 11}
            Case Else
                Return New Double(6) {5, 6, 7, 8, 9, 10, 11}
        End Select
    End Function
    Public Function ArrayOfValuesY(ByVal Maquina As String) As Array
        Select Case Maquina
            Case "Compre1"
                Return New Long(6) {2, 1.92, 1.93, 1.7, 1.3, 0.618, 0.1}
            Case "Compre2"
                Return New Long(6) {3.1, 3.02, 2.9, 2.7, 2.4, 0.56, 0.3}
            Case "Sistema"
                Return New Long(6) {0.3, 0.56, 1.7, 2.9, 3.02, 4, 5.5}
            Case Else
                Return New Long(6) {6, 5.9, 5.7, 5.3, 4.6, 3.4, 1.5}
        End Select
    End Function
End Class
