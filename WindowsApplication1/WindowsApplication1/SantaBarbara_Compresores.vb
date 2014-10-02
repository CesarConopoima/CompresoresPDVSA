Imports System.Windows.Forms.DataVisualization.Charting
Imports WindowsApplication1.UnitsConvert
Imports WindowsApplication1.Similitudes

Public Class SantaBarbara_Compresores
    Public CondicionesCompresor1 As Double()

    Private Sub Label12_Click(sender As Object, e As EventArgs) Handles Label12.Click
        Dim name As String = Label12.Text
        'En esta línea se limpian los textBoxes 
        CleanTextBoxes()
        Label11.Text = "Condiciones cambiantes " & name
        Stroke.Text = DictionarieCompresores.Item(name).Item(name & "_Stroke")
        Diametro.Text = DictionarieCompresores.Item(name).Item(name & "_Diametro")
        'DiametroBiela.Text = DictionarieCompresores.Item(name).Item(name & "_DiametroBiela")
        Area.Text = DictionarieCompresores.Item(name).Item(name & "_Area")
        RPM.Text = DictionarieCompresores.Item(name).Item(name & "_RPM")
    End Sub
    'Etiqueta para el segundo compresor
    Private Sub Label19_Click(sender As Object, e As EventArgs) Handles Label19.Click
        Dim name As String = Label19.Text
        'En esta linea se limpian los valores de los textbox, Cálculados para el compresor 1
        CleanTextBoxes()
        Label11.Text = "Condiciones cambiantes " & Name
        Stroke.Text = DictionarieCompresores.Item(name).Item(name & "_Stroke")
        Diametro.Text = DictionarieCompresores.Item(name).Item(name & "_Diametro")
        'DiametroBiela.Text = DictionarieCompresores.Item(name).Item(name & "_DiametroBiela")
        Area.Text = DictionarieCompresores.Item(name).Item(name & "_Area")
        RPM.Text = DictionarieCompresores.Item(name).Item(name & "_RPM")
    End Sub
    '-----------------------------------------------------------------------------------------------
    'Boton para hacer CALCULAR en función de las relaciones de compresión
    'la temperatura 2 en la descarga del equipo, el flujo másico y volumétrico y la potencia
    '-----------------------------------------------------------------------------------------------
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        'Esta linea cambia el texto de la etiqueta de la img, para que sepan el estado de su cálculo
        'Parametros Termodinámicos
        Dim MaquinaActual As String = Split(Label11.Text, " ").Last
        'Aquí poner estructura de control donde se pregunte que máquina se esta trabajando y calcular en función de eso

        If MaquinaActual = "compresor_SB_1" Then
            'Parámetros Termodinámicos
            Dim PresionDescargaInput As String = PresionUnidades.Text & "_" & Pdescarga.Text
            Dim PresionDescarga As Double = to_Psi(PresionDescargaInput)
            Dim TempSuccion As Double = CDbl(Replace(Tambiental.Text, ".", ",")) * 1.8 + 491.67 'Esta Temperatura esta en Rankine, pues la entrada esta en °C
            Dim PresionSuccion As Double = 14.7 '[Unidades en Psi]
            Dim ZGas As Double = 1
            Dim RGas As Double = 8314.3 / 28.97
            Dim KGas As Double = 1.4
            'Parametros Geométricos
            Dim DCilindro As Double = CDbl(Diametro.Text)
            'Dim DBiela As Double = CDbl(DiametroBiela.Text)
            Dim Corrida As Double = CDbl(Stroke.Text)
            Dim RPMActual As Double = CDbl(RPM.Text)

            'Creación de objeto para tener las funciones propias de los cálculos de cantidades físicas
            Dim CalculosCompresores As New CalculosCompresores
            'Calculo de cantidades derivadas de las condiciones de funcionamiento de la máquina
            Dim EficienciaVol As Double = 0.7415 'Ojo esto debería tener una rutina de calculo asociada que no está aun programada
            Dim FlujoVol As Double = Math.Round(CalculosCompresores.FlujoVolumetrico_SimpleEfecto(DCilindro, Corrida, RPMActual) * EficienciaVol, 2)
            Dim FlujoMass As Double = Math.Round((CalculosCompresores.FlujoMasico(FlujoVol, PresionSuccion * 6894.75729, ZGas, RGas, TempSuccion * 5 / 9)) / 3600, 2)
            Dim DeltaEntalpia As Double = Math.Round(CalculosCompresores.CambioEntalpiaIsoentropica(PresionSuccion, PresionDescarga, TempSuccion * 5 / 9, KGas, RGas, 1, 1, 1))

            'Aquí el orden de los argumentos de la función son KGas, P2,P1,T1,ns
            Tdescarga.Text = Math.Round(CalculosCompresores.TempDescarga(1.4, PresionDescarga, PresionSuccion, TempSuccion, 1), 2)
            'Por defecto se calcula el flujo volumétrico para una acción de simple efecto
            FlujoVolumetrico.Text = FlujoVol
            'En este cálculo la Temperatura de succión debe estar en K
            FlujoMasico.Text = FlujoMass
            Potencia.Text = Math.Round(CalculosCompresores.Potencia(FlujoMass, DeltaEntalpia, 0.7415, 1, 0.9), 2)

            'Definición de las etiquetas que estan en la imag
            TextDescargaCompresor1.Text = "Presión" & vbCrLf & to_Psi(PresionUnidades.Text & "_" & Pdescarga.Text) & "[psi]" & vbCrLf & "Temperatura" & vbCrLf & Tdescarga.Text & "[R]"
            Dim ValueTempAeroenfriador As String = TemperaturaUnidades.Text & "_" & TextTempIntercambiador.Text
            'Por defecto la temp del aeroenfriador es la temp de descarga del compresor
            TempAeroenfriador.Text = Math.Round(CalculosCompresores.TempDescarga(1.4, PresionDescarga, PresionSuccion, TempSuccion, 1), 2)
            TextTempIntercambiador.Text = "Temperatura" & vbCrLf & "Aeroenfriador:" & vbCrLf & TempAeroenfriador.Text & " [R]"
            'Esta variable guarda los valores de Presion y Temperatura en la descarga del compresor1
            'Ella se redefine cada vez que se hace calcular y estamos en el compresor1

            'Este vector guarda las condiciones de operación del compresor 1, Presión en la descar,FlujoMasico,TempDelAeroenfriado,PotenciaConsumidaCompresor1
            CondicionesCompresor1 = {PresionDescarga, FlujoMass, Math.Round(CalculosCompresores.TempDescarga(1.4, PresionDescarga, PresionSuccion, TempSuccion, 1), 2), Math.Round(CalculosCompresores.Potencia(FlujoMass, DeltaEntalpia, 0.7415, 1, 0.9), 2)}
            'Llenar la info resumen en la parte derecha
            InfoCompre1.Text = Math.Round(PresionDescarga / 14.7, 2) & "   " & Math.Round((Math.Round(CalculosCompresores.TempDescarga(1.4, PresionDescarga, PresionSuccion, TempSuccion, 1), 2) - 491) * 5 / 9, 2) & "  [°C]" & "    " & Math.Round(CalculosCompresores.Potencia(FlujoMass, DeltaEntalpia, 0.7415, 1, 0.9), 2) & " [Kw]"
            'Condicional para evaluar si la presión de descarga es mayor a la presión atmosferica
            If PresionDescarga <= 14.7 Then
                MsgBox("La presión de descarga es menor a la presión atmosférica" & vbCrLf & "porfavor escriba un valor mayor a:" & vbCrLf & "14.7 [psi], 101352.932 [Pa], 101.352 [Kpa], 0.1[Mpa], 1.0135 [Bar]")
            End If

        ElseIf TextDescargaCompresor1.Text.Contains("Presión") And MaquinaActual = "compresor_SB_2" Then
            'Condiciones termondinámicas
            Dim PresionDescargaInput As String = PresionUnidades.Text & "_" & Pdescarga.Text
            Dim PresionDescarga As Double = to_Psi(PresionDescargaInput)
            Dim PresionSuccion As Double = CondicionesCompresor1(0)
            Dim FlujoMasicoSistema As Double = CondicionesCompresor1(1)
            Dim TempDescargaCompre1 As Double = CondicionesCompresor1(2)
            Dim PotenciaCompre1 As Double = CondicionesCompresor1(3)
            Dim CalculosCompresores As New CalculosCompresores
            Dim ZGas As Double = 1
            Dim RGas As Double = 8314.3 / 28.97
            Dim KGas As Double = 1.4
            'Parametros Geométricos
            Dim DCilindro As Double = CDbl(Diametro.Text)
            'Dim DBiela As Double = CDbl(DiametroBiela.Text)
            Dim Corrida As Double = CDbl(Stroke.Text)
            Dim RPMActual As Double = CDbl(RPM.Text)
            'Calculo de variables derivadas propias del compresor
            Dim EficienciaVol As Double = 0.877 'Ojo esto debería tener una rutina de calculo asociada que no está aun programada
            Dim FlujoVol As Double = Math.Round(CalculosCompresores.FlujoVolumetrico_SimpleEfecto(DCilindro, Corrida, RPMActual) * EficienciaVol, 2)
            'Dim FlujoMass As Double = Math.Round((CalculosCompresores.FlujoMasico(FlujoVol, PresionSuccion * 6894.75729, ZGas, RGas, TempSuccion * 5 / 9)) / 3600, 2)

            'Vieja temp de succión para satisfacer el flujo másico, el cálculo es diferente
            'Dim TempSuccion As Double = (CalculosCompresores.TempAeroenfriador(FlujoMasicoSistema, FlujoVol, PresionSuccion * 6894.75729, TempDescargaCompre1 * 5 / 9)) * 9 / 5 'Esta función esta definida as Private al final de la clase
            Dim TempSuccion As Double = TempSuccionCompre2()
            Dim DeltaEntalpia As Double = Math.Round(CalculosCompresores.CambioEntalpiaIsoentropica(PresionSuccion, PresionDescarga, TempSuccion * 5 / 9, KGas, RGas, 1, 1, 1))
            'TempAeroenfriador.Text = Math.Round(TempSuccion, 2)

            If PresionDescarga <= PresionSuccion Then
                MsgBox("La presión de descarga del segundo compresor es menor" & vbCrLf & "o igual a la presión de succión")
            Else
                Tdescarga.Text = Math.Round(CalculosCompresores.TempDescarga(1.4, PresionDescarga, PresionSuccion, TempSuccion, 1), 2)
                FlujoVolumetrico.Text = FlujoVol
                FlujoMasico.Text = FlujoMasicoSistema 'Este valor es fijo pues es el flujo másico físico del sistema
                Potencia.Text = Math.Round(CalculosCompresores.Potencia(FlujoMasicoSistema, DeltaEntalpia, 0.7415, 1, 0.9), 2)
                TextDescargaCompresor2.Text = "Presión" & vbCrLf & Pdescarga.Text & "[psi]" & vbCrLf & "Temperatura" & vbCrLf & Tdescarga.Text & "[R]"
                InfoCompre2.Text = Math.Round(PresionDescarga / PresionSuccion, 2) & "   " & Math.Round((Math.Round(CalculosCompresores.TempDescarga(1.4, PresionDescarga, PresionSuccion, TempSuccion, 1), 2) - 491) * 5 / 9, 2) & "  [°C]" & "    " & Math.Round(CalculosCompresores.Potencia(FlujoMasicoSistema, DeltaEntalpia, 0.7415, 1, 0.9), 2) & " [Kw]"
                InfoEnfriador1.Text = Math.Round((TempSuccion - 491) * 5 / 9, 2) & "  [°C]"
                'calculo de la temp despues del aeroenfriador

                'Definición de variables y condiciones para cálcular el condensado de la línea despues del aeroenfriador
                Dim ValueHumedadAbs As Double = (CDbl(HumedadAbsoluta.Text)) / 1000 'Humedad absoluta entre 1000 para llevarla a unidades consistentes
                Dim PresionActual As Double = PresionSuccion * 6894.75729 'Para pasar de [psi] to [Pa]
                Dim TempActual As Double = TempSuccion * 5 / 9 'Esta viene en Rankine, necesario pasar a Kelvin por eso el factor de adelante
                Dim FlujoMasicoAire As Double = CDbl(FlujoMasico.Text)
                Dim EstimacionCondensado As New CalculoCondensado(ValueHumedadAbs, PresionActual, TempActual, FlujoMasicoAire)
                'Aquí debería ir algun flag para determinar cuando haya condensado y poner un msgbox y una alarma visual!!
                If EstimacionCondensado.LiquidoCondensado() > 0 Then
                    MsgBox("Existe condensado en la línea del aeroenfridor!." & vbCrLf &
                           "Cuidado con el golpe líquido en sus válvulas!!")
                    Timer1.Enabled = True
                End If
                InfoCondensado.Text = Math.Round(EstimacionCondensado.LiquidoCondensado() * 60, 3) & "   [Litros/min]"
                'Mostrar la Temperatura de Rocio en el label de la descarga del intercambiador

                'Crear un objeto diferente para tener la temp de Rocio
                Dim EstimacionTemperaturaRocio As New CalculoCondensado(ValueHumedadAbs, PresionDescarga * 6894.75729, CDbl(Tdescarga.Text) * 5 / 9, FlujoMasicoAire)
                TempRucio.Text = "Temperatura de rocio" & vbCrLf & Math.Round(EstimacionTemperaturaRocio.TempRocio()) & " [°C]" _
                                & vbCrLf & "@  " & PresionDescargaInput

                'Definición de variables para guardar las cantidades globales de interes del sistema
                Dim PotenciaConsumida As Double = PotenciaCompre1 + Math.Round(CalculosCompresores.Potencia(FlujoMasicoSistema, DeltaEntalpia, 0.7415, 1, 0.9), 2)
                Dim RelacionCompresionGlobal As Double = Math.Round(Math.Sqrt(PresionDescarga / PresionSuccion * PresionSuccion / 14.7), 2)
                InfoGlobal.Text = RelacionCompresionGlobal & "       " & PotenciaConsumida & " [Kw]"
            End If
        Else
            MsgBox("Seleccione un Compresor para ser evaluado!")
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
        Area.Enabled = False
        RPM.Enabled = False
        PresionUnidades.Text = "[psi]"
        TemperaturaUnidades.Text = "[R]"
    End Sub

    Private Sub CleanTextBoxes()
        Pdescarga.Clear()
        Tdescarga.Clear()
        FlujoMasico.Clear()
        FlujoVolumetrico.Clear()
        Potencia.Clear()
        TempAeroenfriador.Clear()
    End Sub

    'Boton para hacer set de la temperatura despues del aeroenfriador que será la temperatura de succión del compresor2
    'Se llama "Set"

    Private Sub Button3_Click(sender As Object, e As EventArgs)
        'Agregar un Flag para saber si se esta editando al compresor 1
        Dim MaquinaActual As String = Split(Label11.Text, " ").Last
        Try
            If MaquinaActual = "compresor_SB_1" Then
                Dim TemperaturaAeroenfria As String = TemperaturaUnidades.Text & "_" & TempAeroenfriador.Text
                'Primero es necesario hacer una validación del valor de Temperatura que se esta Definiendo despues 
                'Del aeroenfriador.. para que no se acepten valores mayores a la temp en la descarga del compresor
                Dim TempValueAeroenfria As Double = to_Rankine(TemperaturaAeroenfria)
                Dim TempDescargaCompresor As Double = CDbl(Tdescarga.Text)
                If TempValueAeroenfria > TempDescargaCompresor Then
                    MsgBox("La Temperatura despues del aeroenfriador no debe ser mayor que la temperatura" & vbCrLf & "en la descarga del compresor!")
                    TempAeroenfriador.Text = Tdescarga.Text
                Else
                    TextTempIntercambiador.Text = "Temperatura" & vbCrLf & "Aeroenfriador:" & vbCrLf & TempAeroenfriador.Text & " " & TemperaturaUnidades.Text
                    'Este msgbox invita a recalcular para guardar el nuevo valor de temperatura de succión para el 2do compresor
                End If
            ElseIf MaquinaActual = "compresor_SB_2" Then
                Dim TempIntercambiador As String = Split(TextTempIntercambiador.Text, vbCrLf).Last
                MsgBox("La Temperatura de succión del compresor ya fué definida, es: " & TempIntercambiador)
            End If
        Catch ex As Exception
            MsgBox("Debe definir las condiciones del compresor_SB_1!")
        End Try

    End Sub

    'Función especializada para retornar el valor de temperatura de succión del segundo 
    'compresor en [R] para usar en los calculo de compresión esta función solo sera llamada para
    'calculos del segundo compresor.

    Private Function TempSuccionCompre2() As Double
        Dim UnitsTemp As String = Split(Split(TextTempIntercambiador.Text, vbCrLf).Last, " ").Last
        Dim ValueTemp As String = Split(Split(TextTempIntercambiador.Text, vbCrLf).Last, " ").First
        Return to_Rankine(UnitsTemp & "_" & ValueTemp)
    End Function

    'Botones y text para mostrar la carta psicrométrica
    'Private Sub Label13_Click(sender As Object, e As EventArgs) Handles Label13.Click
    '    Carta_de_psicrometria.Show()
    'End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Carta_de_psicrometria.Show()
    End Sub

    'Acciones asociada a la pestaña de menu incrustado en la parte superior
    Private Sub CerrarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CerrarToolStripMenuItem.Click
        Me.Close()
    End Sub
    Private Sub GenerarReporteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GenerarReporteToolStripMenuItem.Click
        Dim Reporte As New GeneradorReporte
        Reporte.WriteFile()
    End Sub
    'Timer para mostrar las alarmas cambiando el background de algunos textos a voluntad.
    Dim blink As Boolean
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If (blink) Then
            Me.InfoCondensado.BackColor = Color.FromArgb(253, 186, 109)
            blink = False
        Else
            Me.InfoCondensado.BackColor = Color.FromArgb(255, 250, 250)
            blink = True
        End If
    End Sub

End Class