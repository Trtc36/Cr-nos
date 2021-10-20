Imports System.Data.SqlClient
Imports System.Data
Imports System.Windows.Forms

Public Class fCapacitacion
    Inherits Conexion
    Dim cmd As New SqlCommand

    Public Function Mostrar_Capacitacion() As DataTable
        Try
            Conectar()
            cmd = New SqlCommand("Mostrar_Capacitacion")
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

    Public Function Insertar_Capacitacion(ByVal dts As CCapacitacion) As Boolean
        Try
            Conectar()
            cmd = New SqlCommand("Insertar_Capacitacion")
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = Conexion

            cmd.Parameters.AddWithValue("@codigo", dts._codigo)
            cmd.Parameters.AddWithValue("@nombre", dts._nombre)
            cmd.Parameters.AddWithValue("@fecha", dts._fecha)
            cmd.Parameters.AddWithValue("@tema", dts._tema)
           
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

    Public Function Modificar_Capacitacion(ByVal dts As CCapacitacion) As Boolean
        Try
            Conectar()
            cmd = New SqlCommand("Modificar_Capacitacion")
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = Conexion

            cmd.Parameters.AddWithValue("@idCapacitacion", dts._idCapacitacion)
            cmd.Parameters.AddWithValue("@codigo", dts._codigo)
            cmd.Parameters.AddWithValue("@nombre", dts._nombre)
            cmd.Parameters.AddWithValue("@fecha", dts._fecha)
            cmd.Parameters.AddWithValue("@tema", dts._tema)
            
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

    Public Function Eliminar_Capacitacion(ByVal dts As CCapacitacion) As Boolean
        Try
            Conectar()
            cmd = New SqlCommand("Eliminar_Capacitacion")
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = Conexion

            cmd.Parameters.AddWithValue("@idCapacitacion", SqlDbType.Int).Value = dts._idCapacitacion
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

    Public Function Generar_Capacitacion() As Integer
        Conexion.Open()
        cmd = New SqlCommand("Generar_Capacitacion", Conexion)


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
