Imports System.Data.SqlClient
Imports System.Data
Imports System.Windows.Forms

Public Class fProveedor
    Inherits Conexion
    Dim cmd As New SqlCommand

    Public Function Mostrar_Proveedor() As DataTable
        Try
            Conectar()
            cmd = New SqlCommand("Mostrar_Proveedor")
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

    Public Function Insertar_Proveedor(ByVal dts As CProveedor) As Boolean
        Try
            Conectar()
            cmd = New SqlCommand("Insertar_Proveedor")
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = Conexion

            cmd.Parameters.AddWithValue("@codigo", dts._codigo)
            cmd.Parameters.AddWithValue("@tProveedor", dts._tProveedor)
            cmd.Parameters.AddWithValue("@personalidad", dts._personalidad)
            cmd.Parameters.AddWithValue("@rSocial", dts._rSocial)
            cmd.Parameters.AddWithValue("@nombre", dts._nombre)
            cmd.Parameters.AddWithValue("@paterno", dts._paterno)
            cmd.Parameters.AddWithValue("@materno", dts._materno)
            cmd.Parameters.AddWithValue("@RFC", dts._RFC)
            cmd.Parameters.AddWithValue("@tVialidad", dts._tVialidad)
            cmd.Parameters.AddWithValue("@nVialidad", dts._nVialidad)
            cmd.Parameters.AddWithValue("@colonia", dts._colonia)
            cmd.Parameters.AddWithValue("@ciudad", dts._ciudad)
            cmd.Parameters.AddWithValue("@estado", dts._estado)
            cmd.Parameters.AddWithValue("@cp", dts._cp)
            cmd.Parameters.AddWithValue("@telefono", dts._telefono)
            cmd.Parameters.AddWithValue("@mail", dts._mail)

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

    Public Function Modificar_Proveedor(ByVal dts As CProveedor) As Boolean
        Try
            Conectar()
            cmd = New SqlCommand("Modificar_Proveedor")
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = Conexion

            cmd.Parameters.AddWithValue("@idProveedor", dts._idProveedor)
            cmd.Parameters.AddWithValue("@codigo", dts._codigo)
            cmd.Parameters.AddWithValue("@tProveedor", dts._tProveedor)
            cmd.Parameters.AddWithValue("@personalidad", dts._personalidad)
            cmd.Parameters.AddWithValue("@rSocial", dts._rSocial)
            cmd.Parameters.AddWithValue("@nombre", dts._nombre)
            cmd.Parameters.AddWithValue("@paterno", dts._paterno)
            cmd.Parameters.AddWithValue("@materno", dts._materno)
            cmd.Parameters.AddWithValue("@RFC", dts._RFC)
            cmd.Parameters.AddWithValue("@tVialidad", dts._tVialidad)
            cmd.Parameters.AddWithValue("@nVialidad", dts._nVialidad)
            cmd.Parameters.AddWithValue("@colonia", dts._colonia)
            cmd.Parameters.AddWithValue("@ciudad", dts._ciudad)
            cmd.Parameters.AddWithValue("@estado", dts._estado)
            cmd.Parameters.AddWithValue("@cp", dts._cp)
            cmd.Parameters.AddWithValue("@telefono", dts._telefono)
            cmd.Parameters.AddWithValue("@mail", dts._mail)

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

    Public Function Eliminar_Proveedor(ByVal dts As CProveedor) As Boolean
        Try
            Conectar()
            cmd = New SqlCommand("Eliminar_Proveedor")
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = Conexion

            cmd.Parameters.AddWithValue("@idProveedor", SqlDbType.Int).Value = dts._idProveedor
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

    Public Function Generar_Proveedor() As Integer
        Conexion.Open()
        cmd = New SqlCommand("Generar_Proveedor", Conexion)


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
