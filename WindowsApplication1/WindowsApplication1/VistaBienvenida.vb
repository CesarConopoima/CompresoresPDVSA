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
        Dim conn As New SqlConnection(connect)
        Dim cmd As New SqlCommand
        Dim reader As SqlDataReader


        'fetch data from table addapter
        Dim tableAdapter As New CompresoresDataSet1TableAdapters.UsuarioTableAdapter
        MsgBox(tableAdapter.GetDataBy().Rows(0)(0)) 'trying to exploit query results

        'MsgBox(tableAdapter.GetDataBy().nombreColumn)

        cmd.CommandText = "SELECT nombre,descripcion FROM Usuario"
        cmd.CommandType = CommandType.Text
        cmd.Connection = conn

        conn.Open()

        reader = cmd.ExecuteReader()

        If reader.HasRows() Then
            Do While reader.Read()
                ReadSingleRow(CType(reader, IDataRecord))
            Loop
        End If

        conn.Close()
        'Estas lineas son de prueba
        'If isUsuarioName() Then
        '    Dim conn As New SqlConnection(connect)

        '    ' NC-7 Create a SqlCommand, and identify it as a stored procedure.
        '    Dim cmdNewCustomer As New SqlCommand("Compresores.uspNewUsuario", conn)
        '    cmdNewCustomer.CommandType = CommandType.StoredProcedure

        '    ' NC-8 Add input parameter from the stored procedure and specify what to use as its value.
        '    cmdNewCustomer.Parameters.Add(New SqlParameter("@nombre", SqlDbType.NVarChar, 40))
        '    cmdNewCustomer.Parameters("@nombre").Value = TextBox1.Text

        '    ' NC-9 Add output parameter.
        '    cmdNewCustomer.Parameters.Add(New SqlParameter("@ID_usuario", SqlDbType.Int))
        '    cmdNewCustomer.Parameters("@ID_usuario").Direction = ParameterDirection.Output

        '    ' NC-10 try-catch-finally
        '    Try
        '        ' NC-11 Open the connection.
        '        conn.Open()

        '        ' NC-12 Run the stored procedure.
        '        cmdNewCustomer.ExecuteNonQuery()

        '        ' NC-13 Customer ID is an IDENTITY value from the database. 
        '        Me.UserID = CInt(cmdNewCustomer.Parameters("@ID_usuario").Value)
        '        Me.TextBox3.Text = Convert.ToString(UserID)

        '    Catch
        '        ' NC-14 A simple catch.
        '        MessageBox.Show("Customer ID was not returned. Account could not be created.")
        '    Finally
        '        ' NC-15 Close the connection.
        '        conn.Close()
        '    End Try
        'End If
    End Sub


    Private Sub ReadSingleRow(ByVal record As IDataRecord)
        MsgBox(String.Format("{0}, {1}", record(0), record(1)))
    End Sub



    Private Function isUsuarioName() As Boolean
        If TextBox1.Text = "" Then
            MessageBox.Show("Ingrese un nombre de usuario porfavor")
            Return False
        Else
            Return True
        End If
    End Function

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
End Class