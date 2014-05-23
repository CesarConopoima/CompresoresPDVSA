Imports System.Windows.Forms.DataVisualization.Charting

Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs)
    End Sub
    'Este método grafica las curvas del compresor haciendo similitud en función del nuevo 
    'valor de rpm puesto en la form3 

    Public Sub chartsChanged(maquina As String, factor As Decimal)
        Dim k As Integer
        Dim Chart2 As New Chart
        Dim ChartArea1 As New ChartArea()
        Chart2.ChartAreas.Add(ChartArea1)
        Dim series1 As New Series()
        Dim series2 As New Series()
        Dim series3 As New Series()
        For Each value As Decimal In ArrayOfValuesX("Sistema")
            series1.Points.AddXY(value, ArrayOfValuesY("Sistema")(k))
            series2.Points.AddXY(ArrayOfValuesX(maquina)(k), ArrayOfValuesY(maquina)(k))
            series3.Points.AddXY(ArrayOfValuesX(maquina)(k), similitud(maquina, factor)(k))
            k = k + 1
        Next
        series1.ChartArea = "ChartArea1"
        series2.ChartArea = "ChartArea1"
        series3.ChartArea = "ChartArea1"
        Chart2.Series.Add(series1)
        Chart2.Series.Add(series2)
        Chart2.Series.Add(series3)
        Chart2.Series("Series1").ChartType = SeriesChartType.Spline
        Chart2.Series("Series2").ChartType = SeriesChartType.Spline
        Chart2.Series("Series3").ChartType = SeriesChartType.Spline
        Chart2.Series("Series1").BorderWidth = 2
        Chart2.Series("Series2").BorderWidth = 2
        Chart2.Series("Series3").BorderWidth = 2
        Chart2.Titles.Add("Curva de" & " " & maquina & " y Curva del Sistema Haciendo Similitud con RPM")
        Chart2.ChartAreas(0).AxisX.Title = "Caudal"
        Chart2.ChartAreas(0).AxisY.Title = "Relación de presión"
        Chart2.ChartAreas(0).AxisX.MajorGrid.Enabled = False
        Chart2.ChartAreas(0).AxisY.MajorGrid.Enabled = False
        Chart2.Location = New System.Drawing.Point(20, 365)
        Chart2.Size = New System.Drawing.Size(340, 240)
        Me.Controls.Add(Chart2)
        Chart2.BringToFront()
    End Sub
    ' metodo para hacer charts teniendo como argumento cual maquina se quiere graficar
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
        Chart1.Series("Series1").BorderWidth = 2
        Chart1.Series("Series2").BorderWidth = 2
        Chart1.Series("Series1").IsValueShownAsLabel = True
        Chart1.Series("Series2").IsValueShownAsLabel = True
        Chart1.Titles.Add("Curva de" & " " & maquina & " y Curva del Sistema")
        Chart1.ChartAreas(0).AxisX.Title = "Caudal"
        Chart1.ChartAreas(0).AxisY.Title = "Relación de presión"
        Chart1.ChartAreas(0).AxisX.MajorGrid.Enabled = False
        Chart1.ChartAreas(0).AxisY.MajorGrid.Enabled = False
        Chart1.Location = New System.Drawing.Point(20, 365)
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
        equipo = "Compre1"
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
        equipo = "Compre2"
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
        equipo = "Compre3"
        rpm = "5500"
        Rp = "3.9"
        Eficiencia = "70%"
        Form3.Show()
        Form3.DefineProperties(rpm, Rp, Eficiencia, equipo)
    End Sub
    'Fin del bloque de que acciones propias de las images.!!

    'Función para evaluar intersepción de curvas para definir punto de operacion
    'el metodo que la llame debería tomar ese valor y incluirlo el chart actual mostrado
    Public Function interception(ByVal Maquina As String, ByVal Sistema As String, ByVal factor As Double) As Decimal
        Dim Diference As Integer
        Dim value As Decimal
        Dim m1, m2, b1, b2 As Decimal

        For k As Integer = 0 To (ArrayOfValuesY(Sistema).Length - 1)
            Diference = ArrayOfValuesY(Maquina)(k) - ArrayOfValuesY(Sistema)(k)
            If Diference < 0 Then
                m1 = (ArrayOfValuesY(Sistema)(k) - ArrayOfValuesY(Sistema)(k - 1)) / (ArrayOfValuesX(Sistema)(k) - ArrayOfValuesX(Sistema)(k - 1))
                m2 = (ArrayOfValuesY(Maquina)(k) * factor - ArrayOfValuesY(Maquina)(k - 1) * factor) / (ArrayOfValuesX(Maquina)(k) - ArrayOfValuesX(Maquina)(k - 1))
                b1 = ArrayOfValuesY(Sistema)(k) - (m1 * ArrayOfValuesX(Sistema)(k))
                b2 = ArrayOfValuesY(Maquina)(k) * factor - (m2 * ArrayOfValuesX(Maquina)(k))
                value = (b1 - b2) / (m2 - m1)
                Return value
                Exit For
            End If
        Next
    End Function

    ' función para hacer similitud, parametrizado con el factor Utilizado en el metodo para Gráficar 
    ' en chartsChanged
    Public Function similitud(maquina As String, factor As Decimal) As Array
        Dim k As Integer
        Dim similitudInCurve(6) As Decimal ' ojo aquí quizas se pueda automatizar con el tamaño del arreglo que se le hara similitud
        For Each value As Decimal In ArrayOfValuesY(maquina)
            similitudInCurve(k) = value * factor
            k = k + 1
        Next
        Return similitudInCurve
    End Function

    'Ojo con esta metodología la cantidad de lineas escala con la cantidad de equipos disponibles
    'en la linea
    'aqui los puntos de operación de las curvas ficticias de los equipos

    Public Function ArrayOfValuesX(ByVal Maquina As String) As Array
        Select Case Maquina
            Case "Compre1"
                Return New Decimal(6) {1, 2, 3, 4, 5, 6, 7}
            Case "Compre2"
                Return New Decimal(6) {3, 4, 5, 6, 7, 8, 9}
            Case "Sistema"
                Return New Decimal(6) {1, 2, 4, 6, 9, 11.5, 12.5}
            Case Else
                Return New Decimal(6) {5, 6, 7, 8, 9, 10, 11}
        End Select
    End Function
    Public Function ArrayOfValuesY(ByVal Maquina As String) As Array
        Select Case Maquina
            Case "Compre1"
                Return New Decimal(6) {2, 1.92, 1.85, 1.7, 1.3, 0.62, 0.1}
            Case "Compre2"
                Return New Decimal(6) {3.1, 3.02, 2.9, 2.7, 2.4, 0.56, 0.3}
            Case "Sistema"
                Return New Decimal(6) {0.25, 0.9, 1.5, 2.5, 3.9, 5.6, 8}
            Case Else
                Return New Decimal(6) {6, 5.9, 5.7, 5.3, 4.6, 3.4, 1.5}
        End Select
    End Function
    ' La clase asociada hace operaciones de matrices, en uso hasta que se desarrolle la propia
    Private Sub Button1_Click(sender As Object, e As EventArgs)
        Dim matrix As New Matrix2(2, 2) ' asi se crea una matriz cuadrada de la clase Matrix2
        Dim matrix2 As New Matrix2(1, 1)
        ' a method to handle inproper incommens of users
        MsgBox(interception("Compre1", "Sistema", 1.0))
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        charts("Compre1")
        ' ojo esta linea de codigo no es correcta, la referencia del repertorio
        ' es local
        PictureBox5.Image = System.Drawing.Bitmap.FromFile("C:\Users\Sala de Tesistas pre\Desktop\_CesarConopoima_vb\images\compressor.jpg")
    End Sub
    Private Sub Label1_DoubleClick(sender As Object, e As EventArgs) Handles Label1.DoubleClick
        Dim rpm, Rp, Eficiencia, equipo As String
        equipo = "Compre1"
        rpm = "5000"
        Rp = "3.5"
        Eficiencia = "70%"
        Form3.Show()
        Form3.DefineProperties(rpm, Rp, Eficiencia, equipo)
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click
        charts("Compre2")
        ' ojo esta linea de codigo no es correcta, la referencia del repertorio
        ' es local
        PictureBox5.Image = System.Drawing.Bitmap.FromFile("C:\Users\Sala de Tesistas pre\Desktop\_CesarConopoima_vb\images\compressor2.jpg")
    End Sub
    Private Sub Label2_DoubleClick(sender As Object, e As EventArgs) Handles Label2.DoubleClick
        Dim rpm, Rp, Eficiencia, equipo As String
        equipo = "Compre2"
        rpm = "7500"
        Rp = "4"
        Eficiencia = "70%"
        Form3.Show()
        Form3.DefineProperties(rpm, Rp, Eficiencia, equipo)
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click
        charts("Compre3")
        ' ojo esta linea de codigo no es correcta, la referencia del repertorio
        ' es local
        PictureBox5.Image = System.Drawing.Bitmap.FromFile("C:\Users\Sala de Tesistas pre\Desktop\_CesarConopoima_vb\images\compressor3.jpg")
    End Sub
    Private Sub Label3_DoubleClick(sender As Object, e As EventArgs) Handles Label3.DoubleClick
        Dim rpm, Rp, Eficiencia, equipo As String
        equipo = "Compre3"
        rpm = "5500"
        Rp = "3.9"
        Eficiencia = "70%"
        Form3.Show()
        Form3.DefineProperties(rpm, Rp, Eficiencia, equipo)
    End Sub
End Class
