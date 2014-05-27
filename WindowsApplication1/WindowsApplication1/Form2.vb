Public Class Form2
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    End Sub

    Private Sub PictureBox1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseMove
        'transformation for coordinates of temp
        Dim factorX, factorY As Double
        Dim pointX, pointY As Integer
        Dim brsh As New SolidBrush(Color.FromArgb(48, 157, 216))
        Dim g As Graphics = PictureBox1.CreateGraphics()
        factorX = 65 / 638
        factorY = 33 / 354
        If e.X > 33 And e.X < 671 And (e.Y > 40 And e.Y < 394) Then
            TextBox1.Text = 55 - (671 - e.X) * factorX
            TextBox2.Text = 0 + (394 - e.Y) * factorY
            pointX = 671
            pointY = 394
            ' g.DrawLine(Pens.Blue, pointX, e.Y, e.X, e.Y)  'draw horizontal line4:
            ' g.DrawLine(Pens.Red, e.X, pointY, e.X, e.Y)   'draw vertical line
        Else
            TextBox1.Text = "not defined"
            TextBox2.Text = "not defined"
        End If
        'Draw a filled circle in the map to make drag and drop 
        'g.FillEllipse(brsh, 460, 215, 12, 12)

    End Sub

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

End Class