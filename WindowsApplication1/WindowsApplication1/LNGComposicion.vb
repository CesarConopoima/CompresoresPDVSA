Imports WindowsApplication1.UnitsConvert
Public Class LNGComposicion

    Private Sub LNGComposicion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox1.Enabled = False
        TextBox2.Enabled = False
        TextBox3.Enabled = False
        TextBox4.Enabled = False
        CO2.Enabled = False
        N2.Enabled = False
        TempMezclaUnits.Text = "[R]"
        For Each c As Control In Me.Controls
            If c.GetType Is GetType(TextBox) Then
                If c.Name.Contains("TextBox") = False Then
                    c.Text = 0
                End If
            End If
        Next
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'Ojo con el textBox para C2, se llama C2_ y C6+ se llama C6 simplemente
        Dim k As Integer = 0
        Dim porcentaje As Double
        Dim flag As Boolean = False
        Dim TMezcla As Double = to_Rankine(TempMezclaUnits.Text & "_" & TextBox5.Text)
        'Iterador a traves de textboxes to determine if la composición suma 1
        For Each c As Control In Me.Controls
            If c.GetType Is GetType(TextBox) Then
                If c.Name.Contains("TextBox") = False Then
                    Try
                        porcentaje += CDbl(Replace(c.Text, ".", ","))
                    Catch ex As Exception
                        MsgBox("Llene los valores de la cromatografía!!" & vbCrLf & ex.Message)
                        flag = True
                        Exit For
                    End Try

                End If
            End If
        Next
        If porcentaje <> 100 And flag = False Then
            MsgBox("Tu composición no es correcta, debe sumar 100!!" & "actualmente suma " & porcentaje)
        ElseIf porcentaje = 100 Then
            Dim propiedadesDelGas As New ComposicionGas(cadenaGas())
            TextBox1.Text = propiedadesDelGas.GetPropertiesOfGasesMix(0)
            TextBox2.Text = propiedadesDelGas.GetPropertiesOfGasesMix(1)
            TextBox3.Text = propiedadesDelGas.GetPropertiesOfGasesMix(2)
            TextBox4.Text = propiedadesDelGas.ViscosidadEquivalente(TMezcla)
        End If
        'Aqui condición para conocer que tanque y que composición estamos hablando
        If id.Text = "Composición 1" Then

        ElseIf id.Text = "Composición 2" Then
        End If
    End Sub

    Private Function cadenaGas() As String
        Dim cadena As String = ""

        For Each c As Control In Me.Controls
            If c.GetType Is GetType(TextBox) Then
                If c.Name.Contains("TextBox") = False Then
                    cadena += c.Name & ":" & c.Text & ";"
                End If
            End If
        Next
        Return cadena
    End Function

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        CO2.Enabled = True
        N2.Enabled = True
    End Sub

End Class