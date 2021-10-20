Imports System.Data.SqlClient
Imports System.Data
Imports System.Windows.Forms

Public Class fPermiso
    Inherits Conexion
    Dim cmd As New SqlCommand

    Public Function Mostrar_Permiso() As DataTable
        Try
            Conectar()
            cmd = New SqlCommand("Mostrar_Permiso")
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

    Public Function Insertar_Permiso(ByVal dts As CPermiso) As Boolean
        Try
            Conectar()
            cmd = New SqlCommand("Insertar_Permiso")
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = Conexion

            cmd.Parameters.AddWithValue("@codigo", dts._codigo)
            cmd.Parameters.AddWithValue("@tPermiso", dts._tPermiso)
            cmd.Parameters.AddWithValue("@alcance", dts._alcance)

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

    Public Function Modificar_Permiso(ByVal dts As CPermiso) As Boolean
        Try
            Conectar()
            cmd = New SqlCommand("Modificar_Permiso")
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = Conexion

            cmd.Parameters.AddWithValue("@idPermiso", dts._idPermiso)
            cmd.Parameters.AddWithValue("@codigo", dts._codigo)
            cmd.Parameters.AddWithValue("@tPermiso", dts._tPermiso)
            cmd.Parameters.AddWithValue("@alcance", dts._alcance)

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

    Public Function Eliminar_Permiso(ByVal dts As CPermiso) As Boolean
        Try
            Conectar()
            cmd = New SqlCommand("Eliminar_Permiso")
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = Conexion

            cmd.Parameters.AddWithValue("@idPermiso", SqlDbType.Int).Value = dts._idPermiso
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

    Public Function Generar_Permiso() As Integer
        Conexion.Open()
        cmd = New SqlCommand("Generar_Permiso", Conexion)


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
