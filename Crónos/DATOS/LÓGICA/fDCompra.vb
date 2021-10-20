Imports System.Data.SqlClient
Imports System.Data
Imports System.Windows.Forms

Public Class fDCompra
    Inherits Conexion
    Dim cmd As New SqlCommand

    Public Function Mostrar_DCompra() As DataTable
        Try
            Conectar()
            cmd = New SqlCommand("Mostrar_DCompra")
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

    Public Function Insertar_DCompra(ByVal dts As CDCompra) As Boolean
        Try
            Conectar()
            cmd = New SqlCommand("Insertar_DCompra")
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = Conexion

            cmd.Parameters.AddWithValue("@folio", dts._folio)
            cmd.Parameters.AddWithValue("@idProducto", dts._idProducto)
            cmd.Parameters.AddWithValue("@cantidad", dts._cantidad)
            cmd.Parameters.AddWithValue("@pCompra", dts._pCompra)

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

    Public Function Modificar_DCompra(ByVal dts As CDCompra) As Boolean
        Try
            Conectar()
            cmd = New SqlCommand("Modificar_DCompra")
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = Conexion

            cmd.Parameters.AddWithValue("@idDCompra", dts._idDCompra)
            cmd.Parameters.AddWithValue("@folio", dts._folio)
            cmd.Parameters.AddWithValue("@idProducto", dts._idProducto)
            cmd.Parameters.AddWithValue("@cantidad", dts._cantidad)
            cmd.Parameters.AddWithValue("@pCompra", dts._pCompra)

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

    Public Function Eliminar_DCompra(ByVal dts As CDCompra) As Boolean
        Try
            Conectar()
            cmd = New SqlCommand("Eliminar_DCompra")
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = Conexion

            cmd.Parameters.Add("@idDCompra", SqlDbType.Int).Value = dts._idDCompra
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

    Public Function Aumentar_Stock(ByVal dts As CDCompra) As Boolean
        Try
            Conectar()
            cmd = New SqlCommand("Aumentar_Stock")
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = Conexion

            cmd.Parameters.AddWithValue("@idProducto", dts._idProducto)
            cmd.Parameters.AddWithValue("@Cantidad", dts._Cantidad)

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

    Public Function Disminuir_Stock(ByVal dts As CDCompra) As Boolean
        Try
            Conectar()
            cmd = New SqlCommand("Disminuir_Stock")
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = Conexion

            cmd.Parameters.AddWithValue("@idProducto", dts._idProducto)
            cmd.Parameters.AddWithValue("@Cantidad", dts._Cantidad)

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
End Class
