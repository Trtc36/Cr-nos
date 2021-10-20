Imports System.Data.SqlClient
Imports System.Data
Imports System.Windows.Forms

Public Class fPuesto
    Inherits Conexion
    Dim cmd As New SqlCommand

    Public Function Mostrar_Puesto() As DataTable
        Try
            Conectar()
            cmd = New SqlCommand("Mostrar_Puesto")
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

    Public Function Insertar_Puesto(ByVal dts As CPuesto) As Boolean
        Try
            Conectar()
            cmd = New SqlCommand("Insertar_Puesto")
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = Conexion

            cmd.Parameters.AddWithValue("@codigo", dts._codigo)
            cmd.Parameters.AddWithValue("@puesto", dts._puesto)
            cmd.Parameters.AddWithValue("@descripcion", dts._descripcion)
            cmd.Parameters.AddWithValue("@responsabilidades", dts._responsabilidades)
            cmd.Parameters.AddWithValue("@obligaciones", dts._obligaciones)
            cmd.Parameters.AddWithValue("@sAutorizado", dts._sAutorizado)

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

    Public Function Modificar_Puesto(ByVal dts As CPuesto) As Boolean
        Try
            Conectar()
            cmd = New SqlCommand("Modificar_Puesto")
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = Conexion

            cmd.Parameters.AddWithValue("@idPuesto", dts._idPuesto)
            cmd.Parameters.AddWithValue("@codigo", dts._codigo)
            cmd.Parameters.AddWithValue("@puesto", dts._puesto)
            cmd.Parameters.AddWithValue("@descripcion", dts._descripcion)
            cmd.Parameters.AddWithValue("@responsabilidades", dts._responsabilidades)
            cmd.Parameters.AddWithValue("@obligaciones", dts._obligaciones)
            cmd.Parameters.AddWithValue("@sAutorizado", dts._sAutorizado)

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

    Public Function Eliminar_Puesto(ByVal dts As CPuesto) As Boolean
        Try
            Conectar()
            cmd = New SqlCommand("Eliminar_Puesto")
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = Conexion

            cmd.Parameters.AddWithValue("@idPuesto", SqlDbType.Int).Value = dts._idPuesto
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

    Public Function Generar_Puesto() As Integer
        Conexion.Open()
        cmd = New SqlCommand("Generar_Puesto", Conexion)


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
