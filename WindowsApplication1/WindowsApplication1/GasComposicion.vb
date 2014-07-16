Public Class GasComposicion

    Private Sub GasComposicion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox12.Enabled = False
        TextBox13.Enabled = False
        TextBox14.Enabled = False
        TextBox15.Enabled = False
        IC4.Enabled = False
        NC4.Enabled = False
        NC5.Enabled = False
        IC5.Enabled = False
        C6.Enabled = False
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

        'iterador a traves de textboxes todetermine if la composición suma 1
        For Each c As Control In Me.Controls
            If c.GetType Is GetType(TextBox) Then
                If c.Name.Contains("TextBox") = False Then
                    Try
                        porcentaje += CDbl(c.Text)
                    Catch ex As Exception
                        MsgBox("Llene los valores de la cromatografia!!" & vbCrLf & ex.Message)
                        flag = True
                        Exit For
                    End Try

                End If
            End If
        Next
        If porcentaje <> 100 And flag = False Then
            MsgBox("Tu composición no esta correcta, debe sumar 100!!")
        ElseIf porcentaje = 100 Then
            MsgBox(cadenaGas)
            Dim propiedadesDelGas As New ComposicionGas(cadenaGas())
            TextBox15.Text = propiedadesDelGas.getSpecifcGravity()
            TextBox12.Text = propiedadesDelGas.GetPropertiesOfGasesMix(0)
            TextBox13.Text = propiedadesDelGas.GetPropertiesOfGasesMix(1)
            TextBox14.Text = propiedadesDelGas.GetPropertiesOfGasesMix(2)
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
        IC4.Enabled = True
        NC4.Enabled = True
        NC5.Enabled = True
        IC5.Enabled = True
        C6.Enabled = True
    End Sub
End Class