Imports System.IO
Public Class Inicio
    Dim PlantaJusepin As Informacion_Planta
    Dim PlantaSantaBarbara As Informacion_Planta
    Dim PlantaSanJoaquin As Informacion_Planta
    Dim interruptor As Integer

    Private Sub Button1_GotFocus(sender As Object, e As EventArgs) Handles Button1.GotFocus
        interruptor = 1
        If (interruptor = 1) Then
            Mapa.Image = Image.FromFile(Path.GetFullPath("ImgPresentacion/IMG-20140609-WA0000-1.png"))
        End If
    End Sub

    Private Sub Button1_LostFocus(sender As Object, e As EventArgs) Handles Button1.LostFocus
        If (interruptor = 0) Then
            Mapa.Image = Image.FromFile(Path.GetFullPath("ImgPresentacion/IMG-20140609-WA0000.jpg"))
        End If
    End Sub

    Private Sub Button1_MouseHover(sender As Object, e As EventArgs) Handles Button1.MouseHover
        mostrarFoto(1)
        Mapa.Image = Image.FromFile(Path.GetFullPath("ImgPresentacion/IMG-20140609-WA0000-1.png"))
    End Sub

    Private Sub Button1_MouseLeave(sender As Object, e As EventArgs) Handles Button1.MouseLeave
        Mapa.Image = Image.FromFile(Path.GetFullPath("ImgPresentacion/IMG-20140609-WA0000.jpg"))
        apagarFotos()
    End Sub

    Private Sub Button2_GotFocus(sender As Object, e As EventArgs) Handles Button2.GotFocus
        interruptor = 1
        If (interruptor = 1) Then
            Mapa.Image = Image.FromFile(Path.GetFullPath("ImgPresentacion/IMG-20140609-WA0000-2.png"))
        End If
    End Sub

    Private Sub Button2_MouseHover(sender As Object, e As EventArgs) Handles Button2.MouseHover
        mostrarFoto(2)
        Mapa.Image = Image.FromFile(Path.GetFullPath("ImgPresentacion/IMG-20140609-WA0000-2.png"))
    End Sub

    Private Sub Button2_MouseLeave(sender As Object, e As EventArgs) Handles Button2.MouseLeave
        Mapa.Image = Image.FromFile(Path.GetFullPath("ImgPresentacion/IMG-20140609-WA0000.jpg"))
        apagarFotos()
    End Sub

    Private Sub Button3_GotFocus(sender As Object, e As EventArgs) Handles Button3.GotFocus
        interruptor = 1
        If (interruptor = 1) Then
            Mapa.Image = Image.FromFile(Path.GetFullPath("ImgPresentacion/IMG-20140609-WA0000-3.png"))
        End If
    End Sub

    Private Sub Button3_MouseHover(sender As Object, e As EventArgs) Handles Button3.MouseHover
        mostrarFoto(3)
        Mapa.Image = Image.FromFile(Path.GetFullPath("ImgPresentacion/IMG-20140609-WA0000-3.png"))
    End Sub

    Private Sub Button3_MouseLeave(sender As Object, e As EventArgs) Handles Button3.MouseLeave
        Mapa.Image = Image.FromFile(Path.GetFullPath("ImgPresentacion/IMG-20140609-WA0000.jpg"))
        apagarFotos()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        interruptor = 0
        apagarFotos()
        Me.PlantaJusepin = New Informacion_Planta("PDVSA-TRENC-001", "Planta Jusepin", "Planta de Extraccion de Gas", "situada al norte del Estado Monagas, 30 km al oeste de Maturín", "+58-426-XXX-XX-XX", DateString)
        Me.PlantaSantaBarbara = New Informacion_Planta("PDVSA-TRENC-002", "Planta Santa Teresa", "Planta de Extraccion de Gas", "situada al norte del Estado Monagas, 30 km al oeste de Maturín", "+58-426-XXX-XX-XX", DateString)
        Me.PlantaSanJoaquin = New Informacion_Planta("PDVSA-TRENC-003", "Planta Jose", "Planta de Extraccion de Gas", "situada al norte del Estado Monagas, 30 km al oeste de Maturín", "+58-426-XXX-XX-XX", DateString)
    End Sub

    Public Sub llenarInformacion(Planta As Informacion_Planta)
        LabelID.Text = Planta.FullID
        LabelNombre.Text = Planta.FullNombre
        LabelDescripcion.Text = Planta.FullDescripcion
        LabelUbicacion.Text = Planta.FullUbicacion
        LabelContacto.Text = Planta.FullContacto
        LabelFecha.Text = Planta.FullHistorial
        LabelSubsistema.Text = "Sin Selección"
    End Sub

    Public Sub mostrarFoto(numero As Integer)
        If (numero = 1) Then
            FotoJusepin.Visible = True
        End If

        If (numero = 3) Then
            FotoSanJoaquin.Visible = True
        End If
        If (numero = 2) Then
            FotoSantaBarbara.Visible = True
        End If

    End Sub

    Public Sub apagarFotos()
        FotoJusepin.Visible = False
        FotoSanJoaquin.Visible = False
        FotoSantaBarbara.Visible = False
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        SubSistema1.Image = Image.FromFile(Path.GetFullPath("ImgPresentacion/CompresionJusepinIntro.png"))
        SubSistema1.Width = Image.FromFile(Path.GetFullPath("ImgPresentacion/CompresionJusepinIntro.png")).Width
        SubSistema1.Height = Image.FromFile(Path.GetFullPath("ImgPresentacion/CompresionJusepinIntro.png")).Height
        SubSistema2.Image = Image.FromFile(Path.GetFullPath("ImgPresentacion/BombasJusepinIntro.png"))
        SubSistema2.Width = Image.FromFile(Path.GetFullPath("ImgPresentacion/BombasJusepinIntro.png")).Width
        SubSistema2.Height = Image.FromFile(Path.GetFullPath("ImgPresentacion/BombasJusepinIntro.png")).Height
        llenarInformacion(Me.PlantaJusepin)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        SubSistema1.Image = Image.FromFile(Path.GetFullPath("ImgPresentacion/CompresionJusepinIntro.png"))
        SubSistema1.Width = Image.FromFile(Path.GetFullPath("ImgPresentacion/CompresionJusepinIntro.png")).Width
        SubSistema1.Height = Image.FromFile(Path.GetFullPath("ImgPresentacion/CompresionJusepinIntro.png")).Height
        llenarInformacion(Me.PlantaSantaBarbara)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        llenarInformacion(Me.PlantaSanJoaquin)
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim nameOfSystem As String = LabelNombre.Text
        Dim nameOfSubSystem As String = LabelSubsistema.Text

        If LabelSubsistema.Text = "Sin Selección" Then
            MsgBox("Seleccione un Subsistema a estudiar!")
        ElseIf LabelSubsistema.Text = "Sistema de Compresores Reciprocantes" And nameOfSystem = "Planta Jusepin" Then
            Jusepin_1.Show()
        ElseIf LabelSubsistema.Text = "Sistema de Bombas LNG" And nameOfSystem = "Planta Jusepin" Then
            Jusepin_Bombas.Show()
        End If
        
    End Sub

    Private Sub SubSistema1_Click(sender As Object, e As EventArgs) Handles SubSistema1.Click
        'Ojo no esta Generalizado es necesario saber primero de que sistema se trata para conocer el 
        'verdadero nombre de este label
        LabelSubsistema.Text = "Sistema de Compresores Reciprocantes"
    End Sub

    Private Sub SubSistema2_Click(sender As Object, e As EventArgs) Handles SubSistema2.Click
        'Ojo no esta Generalizado es necesario saber primero de que sistema se trata para conocer el 
        'verdadero nombre de este label
        LabelSubsistema.Text = "Sistema de Bombas LNG"
    End Sub
End Class
