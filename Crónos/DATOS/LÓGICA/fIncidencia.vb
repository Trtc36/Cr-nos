Imports System.Data.SqlClient
Imports System.Data
Imports System.Windows.Forms

Public Class fIncidencia
    Inherits Conexion
    Dim cmd As New SqlCommand

    Public Function Mostrar_Incidencia() As DataTable
        Try
            Conectar()
            cmd = New SqlCommand("Mostrar_Incidencia")
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

    Public Function Insertar_Incidencia(ByVal dts As CIncidencia) As Boolean
        Try
            Conectar()
            cmd = New SqlCommand("Insertar_Incidencia")
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = Conexion

            cmd.Parameters.AddWithValue("@idEmpleado", dts._idEmpleado)
            cmd.Parameters.AddWithValue("@fecha", dts._fecha)
            cmd.Parameters.AddWithValue("@tIncidencia", dts._tIncidencia)
            cmd.Parameters.AddWithValue("@area", dts._area)

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

    Public Function Modificar_Incidencia(ByVal dts As CIncidencia) As Boolean
        Try
            Conectar()
            cmd = New SqlCommand("Modificar_Incidencia")
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = Conexion

            cmd.Parameters.AddWithValue("@idIncidencia", dts._idIncidencia)
            cmd.Parameters.AddWithValue("@idEmpleado", dts._idEmpleado)
            cmd.Parameters.AddWithValue("@fecha", dts._fecha)
            cmd.Parameters.AddWithValue("@tIncidencia", dts._tIncidencia)
            cmd.Parameters.AddWithValue("@area", dts._area)

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

    Public Function Eliminar_Incidencia(ByVal dts As CIncidencia) As Boolean
        Try
            Conectar()
            cmd = New SqlCommand("Eliminar_Incidencia")
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = Conexion

            cmd.Parameters.AddWithValue("@idIncidencia", SqlDbType.Int).Value = dts._idIncidencia
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

    Public Function Generar_Incidencia() As Integer
        Conexion.Open()
        cmd = New SqlCommand("Generar_Incidencia", Conexion)


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
