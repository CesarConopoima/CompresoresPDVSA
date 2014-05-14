Imports System.Windows.Forms.DataVisualization.Charting

Public Class Form1
    Public Sub chart()
        Dim k As Integer
        k = 0
        Dim Chart2 As New Chart
        'Il ne contient rien
        ' Créer ChartArea (zone graphique)
        Dim ChartArea1 As New ChartArea()
        ' Ajouter le  Chart Area à la Collection ChartAreas du  Chart
        Chart2.ChartAreas.Add(ChartArea1)
        ' Créer deux  data series (qui contiendront les DataPoint)
        Dim series1 As New Series()
        Dim series2 As New Series()
        Dim series3 As New Series()
        ' one method to include points to the graph having an array
        For Each value As Double In ArrayOfValuesX("Compre1")
            series1.Points.AddXY(value, ArrayOfValuesY("Compre1")(k))
            series2.Points.AddXY(ArrayOfValuesX("Compre2")(k), ArrayOfValuesY("Compre2")(k))
            series3.Points.AddXY(ArrayOfValuesX("Compre3")(k), ArrayOfValuesY("Compre3")(k))
            k = k + 1
        Next


        'On indique d'afficher ces Series sur le ChartArea1
        series1.ChartArea = "ChartArea1"
        series2.ChartArea = "ChartArea1"
        series3.ChartArea = "ChartArea1"
        ' Ajouter les series à la collection Series du chart
        Chart2.Series.Add(series1)
        Chart2.Series.Add(series2)
        Chart2.Series.Add(series3)
        ' Agregar series en dos arreglos
        Chart2.Series("Series1").ChartType = SeriesChartType.Spline
        Chart2.Series("Series2").ChartType = SeriesChartType.Spline
        Chart2.Series("Series3").ChartType = SeriesChartType.Spline
        Chart2.Titles.Add("FirstGraph")
        ' Positionner le controle Chart
        Chart2.Location = New System.Drawing.Point(45, 120)
        ' Dimensionner le Chart.

        Chart2.Size = New System.Drawing.Size(360, 260)
        ' Ajouter le chart à la form
        Me.Controls.Add(Chart2)
    End Sub

    '' este metodo parece necesario para poder llamar los objetos que estan
    '' en la forma
    Private Sub Form1_Load(sender As Object, e As EventArgs)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        chart()
    End Sub

    Private Sub messageOfImg(sender As Object, e As EventArgs) Handles PictureBox1.Click
        MsgBox("There first compressor")
    End Sub
    Public Function ArrayOfValuesX(ByVal Maquina As String) As Array
        Select Case Maquina
            Case "Compre1"
                Return New Double(6) {1, 2, 3, 4, 5, 6, 7}
            Case "Compre2"
                Return New Double(6) {3, 4, 5, 6, 7, 8, 9}
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
            Case Else
                Return New Long(6) {6, 5.9, 5.7, 5.3, 4.6, 3.4, 1.5}
        End Select
    End Function

End Class
