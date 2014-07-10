Public Class Informacion_Planta
    Private ID As String
    Private nombre As String
    Private descripcion As String
    Private ubicacion As String
    Private contacto As String
    Private ultimaVezAbierto As String

    Public Sub New(ID As String, nombre As String, descripcion As String, ubicacion As String, contacto As String, ultimaVezAbierto As String)
        Me.ID = ID
        Me.nombre = nombre
        Me.descripcion = descripcion
        Me.ubicacion = ubicacion
        Me.contacto = contacto
        Me.ultimaVezAbierto = ultimaVezAbierto
    End Sub

    Public Property FullID() As String
        Get
            Return Me.ID
        End Get
        Set(value As String)
            Me.ID = value
        End Set
    End Property

    Public Property FullNombre() As String
        Get
            Return Me.nombre
        End Get
        Set(value As String)
            Me.nombre = value
        End Set
    End Property

    Public Property FullDescripcion() As String
        Get
            Return Me.descripcion
        End Get
        Set(value As String)
            Me.descripcion = value
        End Set
    End Property
    Public Property FullUbicacion() As String
        Get
            Return Me.ubicacion
        End Get
        Set(value As String)
            Me.ubicacion = value
        End Set
    End Property
    Public Property FullContacto() As String
        Get
            Return Me.contacto
        End Get
        Set(value As String)
            Me.contacto = value
        End Set
    End Property
    Public Property FullHistorial() As String
        Get
            Return Me.ultimaVezAbierto
        End Get
        Set(value As String)
            Me.ultimaVezAbierto = value
        End Set
    End Property


End Class
