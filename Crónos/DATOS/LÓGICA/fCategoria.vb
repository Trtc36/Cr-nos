Imports System.Data.SqlClient
Imports System.Data
Imports System.Windows.Forms

Public Class fCategoria
    Inherits Conexion
    Dim cmd As New SqlCommand

    Public Function Mostrar_Categoria() As DataTable
        Try
            Conectar()
            cmd = New SqlCommand("Mostrar_Categoria")
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = Conexion

            If cmd.ExecuteNonQuery Then
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Return dt
            Else
                Return Nothing
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        Finally
            Desconectar()
        End Try
    End Function

    Public Function Insertar_Categoria(ByVal dts As CCategoria) As Boolean
        Try
            Conectar()
            cmd = New SqlCommand("Insertar_Categoria")
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = Conexion

            cmd.Parameters.AddWithValue("@codigo", dts._codigo)
            cmd.Parameters.AddWithValue("@categoria", dts._categoria)
            cmd.Parameters.AddWithValue("@descripcion", dts._descripcion)

            If cmd.ExecuteNonQuery Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        Finally
            Desconectar()
        End Try
    End Function

    Public Function Modificar_Categoria(ByVal dts As CCategoria) As Boolean
        Try
            Conectar()
            cmd = New SqlCommand("Modificar_Categoria")
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = Conexion

            cmd.Parameters.AddWithValue("@idCategoria", dts._idCategoria)
            cmd.Parameters.AddWithValue("@codigo", dts._codigo)
            cmd.Parameters.AddWithValue("@categoria", dts._categoria)
            cmd.Parameters.AddWithValue("@descripcion", dts._descripcion)

            If cmd.ExecuteNonQuery Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        Finally
            Desconectar()
        End Try
    End Function

    Public Function Eliminar_Categoria(ByVal dts As CCategoria) As Boolean
        Try
            Conectar()
            cmd = New SqlCommand("Eliminar_Categoria")
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = Conexion

            cmd.Parameters.AddWithValue("@idCategoria", SqlDbType.Int).Value = dts._idCategoria
            If cmd.ExecuteNonQuery Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function

    Public Function Generar_Categoria() As Integer
        Conexion.Open()
        cmd = New SqlCommand("Generar_Categoria", Conexion)


        Dim param As New SqlParameter("@codigo", SqlDbType.Int)
        param.Direction = ParameterDirection.Output
        With cmd
            .CommandType = CommandType.StoredProcedure
            .Parameters.Add(param)
            .ExecuteNonQuery()
            Conexion.Close()
            Return .Parameters("@codigo").Value
        End With
    End Function
End Class
