Imports System.Data.SqlClient
Imports System.Data
Imports System.Windows.Forms

Public Class fCEmpleado
    Inherits Conexion
    Dim cmd As New SqlCommand

    Public Function Mostrar_CEmpleado() As DataTable
        Try
            Conectar()
            cmd = New SqlCommand("Mostrar_CEmpleado")
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

    Public Function Insertar_CEmpleado(ByVal dts As CCapacitacionEmpleado) As Boolean
        Try
            Conectar()
            cmd = New SqlCommand("Insertar_CEmpleado")
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = Conexion

            cmd.Parameters.AddWithValue("@idCapacitacion", dts._idCapacitacion)
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

    Public Function Modificar_CEmpleado(ByVal dts As CCapacitacionEmpleado) As Boolean
        Try
            Conectar()
            cmd = New SqlCommand("Modificar_CEmpleado")
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = Conexion

            cmd.Parameters.AddWithValue("@idEmpleado", dts._idEmpleado)
            cmd.Parameters.AddWithValue("@idCapacitacion", dts._idCapacitacion)
           
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

    Public Function Eliminar_CEmpleado(ByVal dts As CCapacitacionEmpleado) As Boolean
        Try
            Conectar()
            cmd = New SqlCommand("Eliminar_CEmpleado")
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = Conexion

            cmd.Parameters.AddWithValue("@idEmpleado", SqlDbType.Int).Value = dts._idEmpleado
            cmd.Parameters.AddWithValue("@idCapacitacion", dts._idCapacitacion)

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
End Class
