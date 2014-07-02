Public Class Form3

    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    End Sub

    Sub DefineProperties(rpm As String, rp As String, eficiencia As String, equipo As String)
        TextBox1.Text = rpm 'estas propiedades se consultan en la base de datos
        TextBox2.Text = rp  'estas propiedades se consultan en la base de datos
        TextBox3.Text = eficiencia 'estas propiedades se consultan en la base de datos
        TextBox4.Text = equipo 'estas propiedades se consultan en la base de datos
        TextBox5.Text = rpm
    End Sub
    ' Este método debería cargar el nuevo punto de diseño del equipo
    ' y hacer el nuevo gráfico
    Public Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim NewValue As Double
        Dim factor As Double
        Dim maquina As String

        maquina = TextBox4.Text
        NewValue = TextBox5.Text
        factor = CDbl(Val(NewValue)) / CDbl(Val(TextBox2.Text))
        Form1.chartsChanged(maquina, factor)

        TextBox6.Text = Math.Round(Form1.interception(maquina, "Sistema", 1.0), 2)
        TextBox7.Text = Math.Round(Form1.interception(maquina, "Sistema", factor), 2)

    End Sub
    'Este boton es el de cancelar la edición de las propiedades
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Close()
    End Sub

End Class