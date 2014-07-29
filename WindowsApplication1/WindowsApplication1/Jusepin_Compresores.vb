Imports System.Windows.Forms.DataVisualization.Charting
Imports WindowsApplication1.UnitsConvert
Imports WindowsApplication1.Similitudes

Public Class Jusepin_Compresores
    Public CondicionesCompresor1 As Double()

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

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Carta_de_psicrometria.Show()
    End Sub

    Private Sub Label12_Click(sender As Object, e As EventArgs) Handles Label12.Click
        Dim name As String = Label12.Text
        Label11.Text = "Condiciones cambiantes " & name
        Stroke.Text = DictionarieCompresores.Item(name).Item(name & "_Stroke")
        Diametro.Text = DictionarieCompresores.Item(name).Item(name & "_Diametro")
        DiametroBiela.Text = DictionarieCompresores.Item(name).Item(name & "_DiametroBiela")
        Area.Text = DictionarieCompresores.Item(name).Item(name & "_Area")
        RPM.Text = DictionarieCompresores.Item(name).Item(name & "_RPM")
    End Sub
    'Etiqueta para el segundo compresor
    Private Sub Label19_Click(sender As Object, e As EventArgs) Handles Label19.Click
        'En esta linea se limpian los valores de los textbox, Cálculados para el compresor 1
        Pdescarga.Clear()
        Tdescarga.Clear()
        FlujoMasico.Clear()
        FlujoVolumetrico.Clear()
        Potencia.Clear()
        Dim name As String = Label19.Text
        Label11.Text = "Condiciones cambiantes " & name
        Stroke.Text = DictionarieCompresores.Item(name).Item(name & "_Stroke")
        Diametro.Text = DictionarieCompresores.Item(name).Item(name & "_Diametro")
        DiametroBiela.Text = DictionarieCompresores.Item(name).Item(name & "_DiametroBiela")
        Area.Text = DictionarieCompresores.Item(name).Item(name & "_Area")
        RPM.Text = DictionarieCompresores.Item(name).Item(name & "_RPM")
    End Sub
    'Boton para hacer CALCULAR en función de las relaciones de compresión
    'la temperatura 2 en la descarga del equipo, el flujo másico y volumétrico y la potencia
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        'Esta linea cambia el texto de la etiqueta de la img, para que sepan el estado de su cálculo
        'Parametros Termodinámicos
        Dim MaquinaActual As String = Split(Label11.Text, " ").Last
        'Aquí poner estructura de control donde se pregunte que máquina se esta trabajando y calcular en función de eso

        If MaquinaActual = "compresor_Jusepin_1" Then
            Try
                Dim PresionDescarga As Double = CDbl(Pdescarga.Text)
                Dim TempSuccion As Double = CDbl(Tambiental.Text)
                Dim PresionSuccion As Double = 14.5
                'Parametros Geométricos
                Dim DCilindro As Double = CDbl(Diametro.Text)
                Dim DBiela As Double = CDbl(DiametroBiela.Text)
                Dim Corrida As Double = CDbl(Stroke.Text)
                Dim RPMActual As Double = CDbl(RPM.Text)
                'Creación de objeto para tener las funciones propias de los cálculos de cantidades físicas
                Dim CalculosCompresores As New CalculosCompresores
                'Aquí el orden de los argumentos de la función son KGas, P2,P1,T1,ns
                Tdescarga.Text = Math.Round(CalculosCompresores.TempDescarga(1.4, PresionDescarga, PresionSuccion, TempSuccion, 1), 2)
                FlujoVolumetrico.Text = Math.Round(CalculosCompresores.FlujoVolumetrico_SimpleEfecto(DCilindro, Corrida, RPMActual), 2)
                'Esta variable guarda los valores de presión y temp en la descarga del compresor1
                'Ella se redefine cada vez que se hace calcular y estamos en el compresor1
                CondicionesCompresor1 = {PresionDescarga, Math.Round(CalculosCompresores.TempDescarga(1.4, PresionDescarga, PresionSuccion, TempSuccion, 1), 2)}
                'Definición de las etiquetas que estan en la imag
                TextDescargaCompresor1.Text = "Presión" & vbCrLf & Pdescarga.Text & "[psi]" & vbCrLf & "Temperatura" & vbCrLf & Tdescarga.Text & "[°C]"
                TextTempIntercambiador.Text = "Temperatura" & vbCrLf & Tdescarga.Text & "[°C]"
            Catch ex As Exception
                MsgBox("Defina el valor de: " & vbCrLf & "**Presión de descarga" & vbCrLf & "**Las condiciones ambientales")
            End Try
        End If
        'Condicional para saber si el compresor 2 está seleccionado y al mismo tiempo las
        'condiciones del compresor 1 ya fueron cálculadas

        If TextDescargaCompresor1.Text.Contains("Presión") And MaquinaActual = "compresor_Jusepin_2" Then
            Try
                Dim PresionDescarga As Double = CDbl(Pdescarga.Text)
                Dim PresionSuccion As Double = CondicionesCompresor1(0)
                Dim TempSuccion As Double = CondicionesCompresor1(1)
                Dim CalculosCompresores As New CalculosCompresores

                If PresionDescarga <= PresionSuccion Then
                    MsgBox("La presión de descarga del segundo compresor es menor o igual a la presión de succión")
                Else
                    Tdescarga.Text = Math.Round(CalculosCompresores.TempDescarga(1.4, PresionDescarga, PresionSuccion, TempSuccion, 1), 2)
                    TextDescargaCompresor2.Text = "Presión" & vbCrLf & Pdescarga.Text & "[psi]" & vbCrLf & "Temperatura" & vbCrLf & Tdescarga.Text & "[°C]"
                End If

            Catch ex As Exception
                MsgBox("Defina la presión de descarga para el segundo compresor!")
            End Try

        End If
        'Guardar en una variable los valores calculados en los textbox para uso en el cálculo de compresore 2

    End Sub

    'Desabilita la edición de los textBoxes
    Private Sub Jusepin_Compresores_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Tdescarga.Enabled = False
        FlujoMasico.Enabled = False
        FlujoVolumetrico.Enabled = False
        Potencia.Enabled = False
        Tambiental.Enabled = False
        HumedadRelativa.Enabled = False
        HumedadAbsoluta.Enabled = False
        Stroke.Enabled = False
        Diametro.Enabled = False
        DiametroBiela.Enabled = False
        Area.Enabled = False
        RPM.Enabled = False
    End Sub

    'Selección de carrera simple cálculo del caudal como simple efecto
    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        Dim MaquinaActual As String = Split(Label11.Text, " ").Last
        If MaquinaActual = "compresor_Jusepin_1" Then
            Try
                Dim PresionDescarga As Double = CDbl(Pdescarga.Text)
                Dim TempSuccion As Double = CDbl(Tambiental.Text)
                Dim PresionSuccion As Double = 14.5
                'Parametros Geométricos
                Dim DCilindro As Double = CDbl(Diametro.Text)
                Dim Corrida As Double = CDbl(Stroke.Text)
                Dim RPMActual As Double = CDbl(RPM.Text)
                Dim CalculosCompresores As New CalculosCompresores
                'Aquí el orden de los argumentos de la función son KGas, P2,P1,T1,ns
                Tdescarga.Text = Math.Round(CalculosCompresores.TempDescarga(1.4, PresionDescarga, PresionSuccion, TempSuccion, 1), 2)
                FlujoVolumetrico.Text = Math.Round(CalculosCompresores.FlujoVolumetrico_SimpleEfecto(DCilindro, Corrida, RPMActual), 2)
            Catch ex As Exception
                MsgBox("Defina el valor de: " & vbCrLf & "**Presión de descarga" & vbCrLf & "**Las condiciones ambientales")
            End Try
        End If
    End Sub

    'Selección de carrera simple cálculo del caudal como doble efecto
    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        Dim MaquinaActual As String = Split(Label11.Text, " ").Last
        If MaquinaActual = "compresor_Jusepin_1" Then
            Try
                Dim PresionDescarga As Double = CDbl(Pdescarga.Text)
                Dim TempSuccion As Double = CDbl(Tambiental.Text)
                Dim PresionSuccion As Double = 14.5
                'Parametros Geométricos
                Dim DCilindro As Double = CDbl(Diametro.Text)
                Dim DBiela As Double = CDbl(DiametroBiela.Text)
                Dim Corrida As Double = CDbl(Stroke.Text)
                Dim RPMActual As Double = CDbl(RPM.Text)
                Dim CalculosCompresores As New CalculosCompresores
                'Aquí el orden de los argumentos de la función son KGas, P2,P1,T1,ns
                Tdescarga.Text = Math.Round(CalculosCompresores.TempDescarga(1.4, PresionDescarga, PresionSuccion, TempSuccion, 1), 2)
                FlujoVolumetrico.Text = Math.Round(CalculosCompresores.FlujoVolumetrico_DoubleEfecto(DCilindro, DBiela, Corrida, RPMActual), 2)
            Catch ex As Exception
                MsgBox("Defina el valor de: " & vbCrLf & "**Presión de descarga" & vbCrLf & "**Las condiciones ambientales")
            End Try
        End If
    End Sub
End Class