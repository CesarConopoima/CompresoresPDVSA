Imports System.IO
Public Class Intro
    Dim Tiempo As Integer
    'Dim bucle As Integer

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim i As Integer
        Tiempo = Tiempo + 1
        'i = Tiempo + 80000 - bucle
        If (Tiempo <= 200) Then
            'bucle = bucle - 100
            i = Tiempo + 80000 '- bucle
        Else
            i = 200 + 80000
        End If
        IntroImagen.Image = Image.FromFile(Path.GetFullPath("MikeSIMpng\MiguelSIM") + Convert.ToString(i) + ".png")
    End Sub

    Private Sub Intro_Load(sender As Object, e As EventArgs) Handles Me.Load
        'bucle = 0
    End Sub

    Private Sub IntroImagen_Click(sender As Object, e As EventArgs) Handles IntroImagen.Click

    End Sub
End Class
