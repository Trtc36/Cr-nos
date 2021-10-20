Imports System.Data.SqlClient
Imports System.Data
Imports System.Windows.Forms

Public Class fVenta
    Inherits Conexion
    Dim cmd As New SqlCommand

    Public Function Mostrar_Venta() As DataTable
        Try
            Conectar()
            cmd = New SqlCommand("Mostrar_Venta")
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

    Public Function Insertar_Venta(ByVal dts As CVenta) As Boolean
        Try
            Conectar()
            cmd = New SqlCommand("Insertar_Venta")
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = Conexion

            cmd.Parameters.AddWithValue("@folio", dts._folio)
            cmd.Parameters.AddWithValue("@fecha", dts._fecha)
            cmd.Parameters.AddWithValue("@idCliente", dts._idCliente)
            cmd.Parameters.AddWithValue("@tVenta", dts._tVenta)
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

    Public Function Modificar_Venta(ByVal dts As CVenta) As Boolean
        Try
            Conectar()
            cmd = New SqlCommand("Modificar_Venta")
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = Conexion

            cmd.Parameters.AddWithValue("@idVenta", dts._idVenta)
            cmd.Parameters.AddWithValue("@folio", dts._folio)
            cmd.Parameters.AddWithValue("@fecha", dts._fecha)
            cmd.Parameters.AddWithValue("@idCliente", dts._idCliente)
            cmd.Parameters.AddWithValue("@tVenta", dts._tVenta)
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

    Public Function Eliminar_Venta(ByVal dts As CVenta) As Boolean
        Try
            Conectar()
            cmd = New SqlCommand("Eliminar_Venta")
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = Conexion

            cmd.Parameters.AddWithValue("@idVenta", SqlDbType.Int).Value = dts._idVenta
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

    Public Function Generar_FVenta() As Integer
        Conexion.Open()
        cmd = New SqlCommand("Generar_FVenta", Conexion)


        Dim param As New SqlParameter("@folio", SqlDbType.Int)
        param.Direction = ParameterDirection.Output
        With cmd
            .CommandType = CommandType.StoredProcedure
            .Parameters.Add(param)
            .ExecuteNonQuery()
            Conexion.Close()
            Return .Parameters("@folio").Value
        End With
    End Function
End Class
