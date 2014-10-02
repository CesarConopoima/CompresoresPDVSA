Imports System.IO
Public Class GeneradorReporte

    Private FileAndUserName As String
    Public Property FullFileAndUserName() As String
        Get
            Return FileAndUserName
        End Get
        Set(ByVal value As String)
            FileAndUserName = value
        End Set
    End Property

    Public Sub WriteFile()
        Dim pathToFile As String = Path.GetFullPath("Reportes")
        'Dim FileName As String = FullFileAndUserName
        Dim FileName As String = "\Reporte2.txt"
        Dim file As System.IO.StreamWriter
        file = My.Computer.FileSystem.OpenTextFileWriter(pathToFile & FileName, True)
        file.WriteLine("Hello There, this is my first Report!!" & vbCrLf & vbCrLf & _
                       "And this a second line which I use to append in a better way")
        file.Close()
        Shell("notepad.exe " & pathToFile & FileName, AppWinStyle.MaximizedFocus)
        'AppActivate(FileName & " - Notepad")

    End Sub
    'Para construir esta clase, se utilizara la fecha y hora del momento en que se realizo
    'El nombre del usuario "que será demandado en un windows prompt" y el nombre de la planta y susbsistema
    'que se está evaluando
    Sub New(FileAndUserName As String)
        Me.FileAndUserName = FileAndUserName
    End Sub
    Sub New()
        Me.FileAndUserName = FileAndUserName
    End Sub

End Class
