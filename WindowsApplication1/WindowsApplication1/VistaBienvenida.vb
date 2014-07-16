Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.Windows.Forms
' NC-1 More namespaces.
Imports System.Data.SqlClient
Imports System.Configuration



Public Class VistaBienvenida
    Private UserID As Integer
    Private connect As String = WindowsApplication1.My.Settings.CompresoresConnectionString

    Private Sub VistaBienvenida_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox3.ReadOnly = True
    End Sub
    'Acción para crear usuario
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

    End Sub

    Private Function isUsuarioName() As Boolean
        If TextBox1.Text = "" Then
            MessageBox.Show("Ingrese un nombre de usuario porfavor")
            Return False
        Else
            Return True
        End If
    End Function

    'boton para cerrar ventana de app
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    'boton para definir nuevo usuario y leer dato en una nueva forma
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim conn As New SqlConnection(connect)
        Dim cmd As New SqlCommand
        Dim cmdInsert As New SqlCommand
        Dim adapter As New SqlDataAdapter()
        Dim ds As New DataSet()

        Dim i As Integer = 0
        Dim sql As String = Nothing


        ' Dim da As New CompresoresDataSet1TableAdapters.UsuarioTableAdapter
        ' Dim dt As New CompresoresDataSet1.UsuarioDataTable
        ' Dim dr As CompresoresDataSet1.UsuarioRow

        ' dr = dt.NewRow
        ' dr.ID_usuario = 3
        ' dr.nombre = "User 3"
        ' dr.descripcion = "Operador 3"
        ' dt.AddUsuarioRow(dr)
        ' da.Update(dt)

        'Este bloque de aquí tamb crea la entrada en la BD pero no lo guarda :s
        'Dim usuarioTableAdapter As New CompresoresDataSet1TableAdapters.UsuarioTableAdapter()
        'usuarioTableAdapter.Insert(3, "User 3", "oper 3")
        'usuarioTableAdapter.Insert(4, "User 4", "oper 4")
        '' Hasta aquí llega el bloque

        sql = "SELECT nombre,descripcion FROM Usuario"


        'Este Bloque tamb sirve para hacer un update en la bd, pero no es permanente

    
        'CompresoresDataSet11.Usuario.Rows.Add(data)
        'UsuarioTableAdapter1.Update(CompresoresDataSet11.Usuario)

        Try
            conn.Open()
            cmd = New SqlCommand(sql, conn)
            adapter.SelectCommand = cmd
            adapter.Fill(ds)
            adapter.Dispose()
            cmd.Dispose()
            conn.Close()

            ComboBox1.DataSource = ds.Tables(0)
            'ComboBox1.DisplayMember = "nombre"
            ComboBox1.DisplayMember = "nombre"
            ' in this way you can fetch the data contained in db
            TextBox4.Text = ds.Tables(0).Rows(0).Item(0)
            TextBox5.Text = ds.Tables(0).Rows(1).Item(0)

        Catch ex As Exception
            MsgBox("Can not open connection ! ")
        End Try
        
    End Sub
End Class