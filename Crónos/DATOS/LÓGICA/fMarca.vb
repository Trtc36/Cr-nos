Imports System.Data.SqlClient
Imports System.Data
Imports System.Windows.Forms

Public Class fMarca
    Inherits Conexion
    Dim cmd As New SqlCommand

    Public Function Mostrar_Marca() As DataTable
        Try
            Conectar()
            cmd = New SqlCommand("Mostrar_Marca")
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

    Public Function Insertar_Marca(ByVal dts As CMarca) As Boolean
        Try
            Conectar()
            cmd = New SqlCommand("Insertar_Marca")
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = Conexion

            cmd.Parameters.AddWithValue("@codigo", dts._codigo)
            cmd.Parameters.AddWithValue("@marca", dts._marca)
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

    Public Function Modificar_Marca(ByVal dts As CMarca) As Boolean
        Try
            Conectar()
            cmd = New SqlCommand("Modificar_Marca")
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = Conexion

            cmd.Parameters.AddWithValue("idMarca", dts._idMarca)
            cmd.Parameters.AddWithValue("@codigo", dts._codigo)
            cmd.Parameters.AddWithValue("@marca", dts._marca)
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

    Public Function Eliminar_Marca(ByVal dts As CMarca) As Boolean
        Try
            Conectar()
            cmd = New SqlCommand("Eliminar_Marca")
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = Conexion

            cmd.Parameters.AddWithValue("@idMarca", SqlDbType.Int).Value = dts._idMarca
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

    Public Function Generar_Marca() As Integer
        Conexion.Open()
        cmd = New SqlCommand("Generar_Marca", Conexion)


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
