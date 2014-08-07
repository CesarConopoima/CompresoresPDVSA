Public Class Carta_de_psicrometria
    ' atencion 
    ' textbox5 es Humedad Relativa
    ' textbox1 es temp de bulbo seca
    ' textbox2 es humedad absoluta

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Enable dropping.
        TextBox2.Enabled = False
        Me.BackColor = ColorTranslator.FromHtml("#0c436e")

    End Sub
    'este método hace track de la posición del mouse conforme se mueve y sirve
    'para tomar acciones en función de la posición del mouse
    'la asignación de valores aquí están apagadas
    Private Sub PictureBox1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseMove
        'transformation for coordinates of temp
        Dim factorX, factorY, TempBS, W, Psat, Pv, HR As Double
        Dim pointX, pointY As Integer
        Dim brsh As New SolidBrush(Color.FromArgb(48, 157, 216))
        Dim g As Graphics = PictureBox1.CreateGraphics()
        factorX = 65 / 638
        factorY = 33 / 354
        TempBS = (55 - (671 - e.X) * factorX)
        W = (394 - e.Y) * factorY
        Psat = 611.21 * Math.Exp((18.678 - TempBS / 234.5) * TempBS / (257.14 + TempBS)) ' Está en [Pa]
        Pv = (W / 1000 * 101325) / (0.622 + W / 1000)
        HR = (Pv / Psat) * 100
        If e.X > 33 And e.X < 671 And (e.Y > 40 And e.Y < 394) And HR < 100.01 Then
            pointX = 671
            pointY = 394
        ElseIf e.X = 33 Or e.X = 671 Or (e.Y = 40 Or e.Y = 394) Or HR = 100.01 Then
            TextBox5.Text = Math.Round(HR, 2)
        End If
    End Sub
    'código para implementar mouse position and add shapes and forms to then
    Private Sub PictureBox1_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseClick
        'transformation for coordinates of temp
        Dim factorX, factorY As Double
        Dim pointX, pointY As Integer
        Dim pn As New Pen(Color.FromArgb(101, 200, 157))
        Dim brsh As New SolidBrush(Color.FromArgb(48, 157, 216))
        Dim g As Graphics = PictureBox1.CreateGraphics()
        factorX = 65 / 638
        factorY = 33 / 354
        If e.X > 33 And e.X < 671 And (e.Y > 40 And e.Y < 394) Then
            pointX = 671
            pointY = 394
        End If
    End Sub

    Private Sub PictureBox1_Click(sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.Click
        Dim factorX, factorY, TempBS, W, Psat, Pv, HR As Double
        Dim pointX, pointY As Integer
        Dim brsh As New SolidBrush(Color.FromArgb(48, 157, 216))
        Dim g As Graphics = PictureBox1.CreateGraphics()
        factorX = 65 / 638
        factorY = 33 / 354
        TempBS = (55 - (671 - e.X) * factorX)
        W = (394 - e.Y) * factorY
        Psat = 611.21 * Math.Exp((18.678 - TempBS / 234.5) * TempBS / (257.14 + TempBS)) ' Está en [Pa]
        Pv = (W / 1000 * 101325) / (0.622 + W / 1000) 'Está en [Pa]
        HR = (Pv / Psat) * 100
        If e.X > 33 And e.X < 671 And (e.Y > 40 And e.Y < 394) And HR < 100.01 Then
            TextBox1.Text = Math.Round(55 - (671 - e.X) * factorX, 2)
            TextBox2.Text = Math.Round((394 - e.Y) * factorY, 2)
            TextBox3.Text = Math.Round(Psat, 2)
            TextBox4.Text = Math.Round(Pv, 2)
            TextBox5.Text = Math.Round(HR, 2)
            pointX = 671
            pointY = 394
            PictureBox2.Location = New Point(e.X - PictureBox2.Width / 2, e.Y - PictureBox2.Height / 2)
        ElseIf e.X = 33 Or e.X = 671 Or (e.Y = 40 Or e.Y = 394) Or HR = 100.01 Then
            TextBox1.Text = Math.Round(55 - (671 - e.X) * factorX, 2)
            TextBox2.Text = Math.Round((394 - e.Y) * factorY, 2)
            TextBox3.Text = Math.Round(Psat, 2)
            TextBox4.Text = Math.Round(Pv, 2)
            TextBox5.Text = Math.Round(HR, 2)
        End If
    End Sub

    'Boton acción para desplazar la img al nuevo punto de operación
    'y cálcula el nuevo valor de humedad absoluta
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' pendiente verificar que el input esta con el formating correcto
        Dim HR, TempBS As Double
        HR = CDbl(Val(TextBox5.Text))
        TempBS = CDbl(Val(TextBox1.Text))
        TransformationAndMove(HR, TempBS)
    End Sub

   
    Private Sub TransformationAndMove(n1 As Double, n2 As Double)
        Dim factorX, factorY, Psat, X, Y, W As Double
        factorX = 65 / 638
        factorY = 33 / 354
        Psat = 611.21 * Math.Exp((18.678 - n2 / 234.5) * n2 / (257.14 + n2)) ' Está en [Pa]
        W = (0.622 * n1 / 100 * Psat / (101325 - n1 / 100 * Psat)) * 1000
        X = 671 - (55 - n2) / factorX
        Y = 394 - W / factorY
        TextBox2.Text = Math.Round(W, 2)
        PictureBox2.Location = New Point(X - PictureBox2.Width / 2, Y - PictureBox2.Height / 2)
    End Sub
    'Definir los valores de Humedad Relativa, temp bulbo seco y humedad absoluta en la Forma que lo llama
    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        Jusepin_Compresores.Tambiental.Text = TextBox1.Text
        Jusepin_Compresores.HumedadRelativa.Text = TextBox5.Text
        Jusepin_Compresores.HumedadAbsoluta.Text = TextBox2.Text
        Me.Close()
    End Sub


End Class