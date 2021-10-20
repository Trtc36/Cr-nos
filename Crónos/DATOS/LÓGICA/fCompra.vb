Imports System.Data.SqlClient
Imports System.Data
Imports System.Windows.Forms

Public Class fCompra
    Inherits Conexion
    Dim cmd As New SqlCommand

    Public Function Mostrar_Compra() As DataTable
        Try
            Conectar()
            cmd = New SqlCommand("Mostrar_Compra")
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

    Public Function Insertar_Compra(ByVal dts As CCompra) As Boolean
        Try
            Conectar()
            cmd = New SqlCommand("Insertar_Compra")
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = Conexion

            cmd.Parameters.AddWithValue("@folio", dts._folio)
            cmd.Parameters.AddWithValue("@fecha", dts._fecha)
            cmd.Parameters.AddWithValue("@idProveedor", dts._idProveedor)
            cmd.Parameters.AddWithValue("@tPago", dts._tPago)
            cmd.Parameters.AddWithValue("@tCompra", dts._tCompra)
            cmd.Parameters.AddWithValue("@idAgente", dts._idAgente)

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

    Public Function Modificar_Compra(ByVal dts As CCompra) As Boolean
        Try
            Conectar()
            cmd = New SqlCommand("Modificar_Compra")
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = Conexion

            cmd.Parameters.AddWithValue("@idCompra", dts._idCompra)
            cmd.Parameters.AddWithValue("@folio", dts._folio)
            cmd.Parameters.AddWithValue("@fecha", dts._fecha)
            cmd.Parameters.AddWithValue("@idProveedor", dts._idProveedor)
            cmd.Parameters.AddWithValue("@tPago", dts._tPago)
            cmd.Parameters.AddWithValue("@tCompra", dts._tCompra)
            cmd.Parameters.AddWithValue("@idAgente", dts._idAgente)

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

    Public Function Eliminar_Compra(ByVal dts As CCompra) As Boolean
        Try
            Conectar()
            cmd = New SqlCommand("Eliminar_Compra")
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = Conexion

            cmd.Parameters.AddWithValue("@idCompra", SqlDbType.Int).Value = dts._idCompra
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

    Public Function Generar_FCompra() As Integer
        Conexion.Open()
        cmd = New SqlCommand("Generar_FCompra", Conexion)


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
