Imports System.Data.SqlClient
Imports System.Data
Imports System.Windows.Forms

Public Class fProducto
    Inherits Conexion
    Dim cmd As New SqlCommand

    Public Function Mostrar_Producto() As DataTable
        Try
            Conectar()
            cmd = New SqlCommand("Mostrar_Producto")
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

    Public Function Insertar_Prodcuto(ByVal dts As CProducto) As Boolean
        Try
            Conectar()
            cmd = New SqlCommand("Insertar_Producto")
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = Conexion

            cmd.Parameters.AddWithValue("@codigo", dts._codigo)
            cmd.Parameters.AddWithValue("@nombre", dts._nombre)
            cmd.Parameters.AddWithValue("@stock", dts._stock)
            cmd.Parameters.AddWithValue("@idModelo", dts._idModelo)
            cmd.Parameters.AddWithValue("@idCategoria", dts._idCategoria)
            cmd.Parameters.AddWithValue("@idProveedor", dts._idProveedor)
            cmd.Parameters.AddWithValue("@pVenta", dts._pVenta)
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

    Public Function Modificar_Producto(ByVal dts As CProducto) As Boolean
        Try
            Conectar()
            cmd = New SqlCommand("Modificar_Producto")
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = Conexion

            cmd.Parameters.AddWithValue("@idProducto", dts._idProducto)
            cmd.Parameters.AddWithValue("@codigo", dts._codigo)
            cmd.Parameters.AddWithValue("@nombre", dts._nombre)
            cmd.Parameters.AddWithValue("@stock", dts._stock)
            cmd.Parameters.AddWithValue("@idModelo", dts._idModelo)
            cmd.Parameters.AddWithValue("@idCategoria", dts._idCategoria)
            cmd.Parameters.AddWithValue("@idProveedor", dts._idProveedor)
            cmd.Parameters.AddWithValue("@pVenta", dts._pVenta)
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

    Public Function Eliminar_Producto(ByVal dts As CProducto) As Boolean
        Try
            Conectar()
            cmd = New SqlCommand("Eliminar_Producto")
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = Conexion

            cmd.Parameters.AddWithValue("@idProducto", SqlDbType.Int).Value = dts._idProducto
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

    Public Function Generar_Producto() As Integer
        Conexion.Open()
        cmd = New SqlCommand("Generar_Producto", Conexion)


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
