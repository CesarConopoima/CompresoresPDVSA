Imports System.Windows.Forms.DataVisualization.Charting

Public Class Form1

    Private Sub Form1_Load_1(sender As Object, e As EventArgs) Handles MyBase.Load
        'Panel2.BackColor = ColorTranslator.FromHtml("#f9e0b7")
        Panel3.BackColor = ColorTranslator.FromHtml("#072842")
        Me.BackColor = ColorTranslator.FromHtml("#0c436e")
        Label7.ForeColor = ColorTranslator.FromHtml("#FFFFFF")
        Label8.ForeColor = ColorTranslator.FromHtml("#FFFFFF")
        Label9.ForeColor = ColorTranslator.FromHtml("#FFFFFF")
        Label10.ForeColor = ColorTranslator.FromHtml("#FFFFFF")
        Label11.ForeColor = ColorTranslator.FromHtml("#FFFFFF")
        Label12.ForeColor = ColorTranslator.FromHtml("#FFFFFF")
        Label13.ForeColor = ColorTranslator.FromHtml("#FFFFFF")
        RichTextBox1.BackColor = ColorTranslator.FromHtml("#072842")
        RichTextBox2.BackColor = ColorTranslator.FromHtml("#072842")
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
            series3.Points.AddXY(similitud(maquina, factor)(k), ArrayOfValuesY(maquina)(k))
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
        Chart2.Series("Series1").MarkerStyle = MarkerStyle.Square
        Chart2.Series("Series2").MarkerStyle = MarkerStyle.Square
        Chart2.Series("Series3").MarkerStyle = MarkerStyle.Square
        Chart2.Series("Series1").ToolTip = "#VALY"
        Chart2.Series("Series2").ToolTip = "#VALY"
        Chart2.Series("Series3").ToolTip = "#VALY"
        Chart2.Series("Series1").BorderWidth = 3
        Chart2.Series("Series2").BorderWidth = 3
        Chart2.Series("Series3").BorderWidth = 3
        Chart2.Titles.Add("Curva de" & " " & maquina & " y Curva del Sistema Haciendo Similitud con RPM")
        Chart2.ChartAreas(0).AxisX.Title = "Caudal [CFM]"
        Chart2.ChartAreas(0).AxisY.Title = "Relación de presión"
        Chart2.ChartAreas(0).AxisX.MajorGrid.Enabled = False
        Chart2.ChartAreas(0).AxisY.MajorGrid.Enabled = False
        Chart2.Location = New System.Drawing.Point(175, 365)
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
        Chart1.Location = New System.Drawing.Point(175, 365)
        Chart1.Size = New System.Drawing.Size(340, 240)
        Me.Controls.Add(Chart1)
        Chart1.BringToFront()
    End Sub
    'función de interseption cuando se hace similitud en los valores Y de las curvas
    Public Function interception(ByVal Maquina As String, ByVal Sistema As String, ByVal factor As Double) As Decimal
        Dim Diference As Integer
        Dim value As Decimal
        Dim m1, m2, b1, b2 As Decimal

        For k As Integer = 0 To (ArrayOfValuesY(Sistema).Length - 1)
            Diference = ArrayOfValuesY(Maquina)(k) * factor - ArrayOfValuesY(Sistema)(k)
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
    'función para interseption cuando se hace la similitud en los valores x de las curvas
    Public Function interceptionXvalues(ByVal Maquina As String, ByVal Sistema As String, ByVal factor As Double) As Decimal
        Dim Diference As Integer
        Dim value As Decimal
        Dim m1, m2, b1, b2 As Decimal

        For k As Integer = 0 To (ArrayOfValuesY(Sistema).Length - 1)
            Diference = ArrayOfValuesY(Maquina)(k) - ArrayOfValuesY(Sistema)(k)
            If Diference < 0 Then
                m1 = (ArrayOfValuesY(Sistema)(k) - ArrayOfValuesY(Sistema)(k - 1)) / (ArrayOfValuesX(Sistema)(k) - ArrayOfValuesX(Sistema)(k - 1))
                m2 = (ArrayOfValuesY(Maquina)(k) - ArrayOfValuesY(Maquina)(k - 1)) / (ArrayOfValuesX(Maquina)(k) * factor - ArrayOfValuesX(Maquina)(k - 1) * factor)
                b1 = ArrayOfValuesY(Sistema)(k) - (m1 * ArrayOfValuesX(Sistema)(k))
                b2 = ArrayOfValuesY(Maquina)(k) - (m2 * ArrayOfValuesX(Maquina)(k) * factor)
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
        For Each value As Decimal In ArrayOfValuesX(maquina)
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

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        Dim rpm, Rp, Eficiencia, equipo As String
        equipo = "Compre1"
        rpm = "5000"
        Rp = "3.5"
        Eficiencia = "70%"
        FillTextBox(rpm, Rp, Eficiencia, equipo)
        charts("Compre1")
        Button3.Name = "Compre1" ' esta linea sirve para hacer track del equipo actual clikeado
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
        Dim rpm, Rp, Eficiencia, equipo As String
        equipo = "Compre2"
        rpm = "7500"
        Rp = "4"
        Eficiencia = "70%"
        FillTextBox(rpm, Rp, Eficiencia, equipo)
        charts("Compre2")
        Button3.Name = "Compre2"
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
        Dim rpm, Rp, Eficiencia, equipo As String
        equipo = "Compre3"
        rpm = "5500"
        Rp = "3.9"
        Eficiencia = "70%"
        FillTextBox(rpm, Rp, Eficiencia, equipo)
        charts("Compre3")
        Button3.Name = "Compre3"
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

    ' Este metodo muestra la forma donde está la carte psicrométrica
    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        Carta_de_psicrometria.Show()
    End Sub

    'Este metodo llena los text box con la info propia del equipo actualmente clickeado
    Private Sub FillTextBox(rpm As String, Rp As String, Eficiencia As String, equipo As String)
        TextBox1.Text = equipo
        TextBox2.Text = rpm
        TextBox3.Text = Rp
        TextBox4.Text = Eficiencia
        TextBox5.Text = rpm
        TextBox1.Enabled = False
        TextBox2.Enabled = False
        TextBox3.Enabled = False
        TextBox4.Enabled = False
        TextBox6.Enabled = False
        TextBox7.Enabled = False
    End Sub
    'Este metodo muestra cuál equipo está siendo mostrado 
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim actual As String
        actual = Button3.Name
        MsgBox(Button3.Name & "soy este")

    End Sub

    'Acción para mostrar gráfico con las dos curvas de similitud y calcular punto de intersepción
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim NewValue As Double
        Dim factor As Double
        Dim maquina As String
        maquina = TextBox1.Text
        NewValue = TextBox5.Text
        factor = CDbl(Val(NewValue)) / CDbl(Val(TextBox2.Text))
        chartsChanged(maquina, factor)
        TextBox6.Text = Math.Round(interceptionXvalues(maquina, "Sistema", 1.0), 2)
        TextBox7.Text = Math.Round(interceptionXvalues(maquina, "Sistema", factor), 2)
    End Sub

    ' botton para mostrar form4 que contiene código para cargar y ejecutar el hardyCross para Agua
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Form4.Show()
    End Sub

    Private Sub Button6_Click_1(sender As Object, e As EventArgs) Handles Button6.Click
        TablaBD.Show()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        VistaBienvenida.Show()
    End Sub
End Class
