'Librerias utilizadas para manejar los datos con SQL
Imports System.Data
Imports System.Data.SqlClient

Public Class Conexion
    'Estableciendo la conexión con la base de datos, (Se busca la cadena en Proyecto>Propiedades de Crónos> COnfiguración)
    Public Conexion As SqlConnection = New SqlConnection("Data Source=DESKTOP-6M8F774\DEVJR;Initial Catalog=Relojería;Integrated Security=True")

    'Creación de variables para la consulta
    Private cmb As SqlCommandBuilder
    Public ds As DataSet = New DataSet()
    Public da As SqlDataAdapter ' Ejecuta el comando
    Public comando As SqlCommand 'Comando a ejecutar
    Public respuesta As SqlDataReader 'Lector del comando
    Public dt As DataTable

    Public Function Conectar()
        Try
            Conexion = New SqlConnection(My.Settings.RelojeríaConnectionString) 'La conexion se realiza con el nombre de la cadena de conexión
            Conexion.Open()
            'MessageBox.Show("Conectado") 'Este mensaje una vez probada la conexión debe comentarse
            Return True
        Catch ex As Exception
            MsgBox("Error de Conexión")
            Return False
        End Try
    End Function

    Public Function Desconectar()
        Try
            If (Conexion.State = ConnectionState.Open) Then
                Conexion.Close()
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function

    Public Sub Consulta(ByRef sql As String, ByVal tabla As String)
        ds.Tables.Clear()
        da = New SqlDataAdapter(sql, Conexion)
        cmb = New SqlCommandBuilder(da)
        da.Fill(ds, tabla)
    End Sub

    Function Insertar(ByVal sql)
        Conexion.Open()
        comando = New SqlCommand(sql, Conexion)
        Dim i As Integer = comando.ExecuteNonQuery()
        If (i > 0) Then
            Return True
        Else
            Return False
        End If
    End Function

    Sub llenarDVG(ByVal sql As String, ByVal dvg As DataGridView)
        Try
            da = New SqlDataAdapter(sql, Conexion)
            dt = New DataTable
            da.Fill(dt)
            dvg.DataSource = dt
        Catch ex As Exception
            MessageBox.Show("No se lleno el DatGridView debido a" + ex.ToString)
        End Try
    End Sub
End Class
