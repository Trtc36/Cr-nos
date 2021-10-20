Imports System.Data.SqlClient
Imports System.Data
Imports System.Windows.Forms
Public Class fUsuario
    Inherits Conexion
    Dim cmd As New SqlCommand

    Public Function Mostrar_Usuario() As DataTable
        Try
            Conectar()
            cmd = New SqlCommand("Mostrar_Usuario")
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

    Public Function Insertar_Usuario(ByVal dts As CUsuario) As Boolean
        Try
            Conectar()
            cmd = New SqlCommand("Insertar_Usuario")
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = Conexion

            cmd.Parameters.AddWithValue("@codigo", dts._codigo)
            cmd.Parameters.AddWithValue("@usuario", dts._usuario)
            cmd.Parameters.AddWithValue("@password", dts._password)
            cmd.Parameters.AddWithValue("@idEmpleado", dts._idEmpleado)
            cmd.Parameters.AddWithValue("@idPermiso", dts._idPermiso)
            cmd.Parameters.AddWithValue("@estatus", dts._estatus)

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

    Public Function Modificar_Usuario(ByVal dts As CUsuario) As Boolean
        Try
            Conectar()
            cmd = New SqlCommand("Modificar_usuario")
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = Conexion

            cmd.Parameters.AddWithValue("@idUsuario", dts._idUsuario)
            cmd.Parameters.AddWithValue("@codigo", dts._codigo)
            cmd.Parameters.AddWithValue("@usuario", dts._usuario)
            cmd.Parameters.AddWithValue("@password", dts._password)
            cmd.Parameters.AddWithValue("@idEmpleado", dts._idEmpleado)
            cmd.Parameters.AddWithValue("@idPermiso", dts._idPermiso)
            cmd.Parameters.AddWithValue("@estatus", dts._estatus)

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

    Public Function Eliminar_Usuario(ByVal dts As CUsuario) As Boolean
        Try
            Conectar()
            cmd = New SqlCommand("Eliminar_Usuario")
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = Conexion

            cmd.Parameters.AddWithValue("@idUsuario", SqlDbType.Int).Value = dts._idUsuario
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

    Public Function Generar_Usuario() As Integer
        Conexion.Open()
        cmd = New SqlCommand("Generar_Usuario", Conexion)


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

    Public Function Validar_Usuario(ByVal dts As CUsuario)
        Try
            Conectar()
            cmd = New SqlCommand("Valida_LogIn")
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = Conexion
            cmd.Parameters.AddWithValue("@Usuario", dts._usuario)
            cmd.Parameters.AddWithValue("@Password", dts._password)

            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader

            If dr.HasRows = True Then
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
End Class
