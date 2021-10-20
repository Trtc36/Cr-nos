Imports System.Data.SqlClient
Imports System.Data
Imports System.Windows.Forms

Public Class fHSueldos
    Inherits Conexion
    Dim cmd As New SqlCommand

    Public Function Mostrar_HSueldo() As DataTable
        Try
            Conectar()
            cmd = New SqlCommand("Mostrar_HSueldo")
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

    Public Function Insertar_HSueldo(ByVal dts As CHSueldos) As Boolean
        Try
            Conectar()
            cmd = New SqlCommand("Insertar_HSueldo")
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = Conexion

            cmd.Parameters.AddWithValue("@sueldo", dts._sueldo)
            cmd.Parameters.AddWithValue("@fecha", dts._fecha)
            cmd.Parameters.AddWithValue("@idEmpleado", dts._idEmpleado)

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

    Public Function Modificar_HSueldos(ByVal dts As CHSueldos) As Boolean
        Try
            Conectar()
            cmd = New SqlCommand("Modificar_HSueldo")
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = Conexion

            cmd.Parameters.AddWithValue("@idSueldo", dts._idSueldo)
            cmd.Parameters.AddWithValue("@sueldo", dts._sueldo)
            cmd.Parameters.AddWithValue("@fecha", dts._fecha)
            cmd.Parameters.AddWithValue("@idEmpleado", dts._idEmpleado)

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

    Public Function Eliminar_HSueldo(ByVal dts As CHSueldos) As Boolean
        Try
            Conectar()
            cmd = New SqlCommand("Eliminar_HSueldo")
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = Conexion

            cmd.Parameters.AddWithValue("@idSueldo", SqlDbType.Int).Value = dts._idSueldo
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

    Public Function Generar_Sueldo() As Integer
        Conexion.Open()
        cmd = New SqlCommand("Generar_Sueldo", Conexion)


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
