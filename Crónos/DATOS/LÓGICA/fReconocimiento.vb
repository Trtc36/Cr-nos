Imports System.Data.SqlClient
Imports System.Data
Imports System.Windows.Forms
Public Class fReconocimiento
    Inherits Conexion
    Dim cmd As New SqlCommand

    Public Function Mostrar_Reconocimiento() As DataTable
        Try
            Conectar()
            cmd = New SqlCommand("Mostrar_Reconocimiento")
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

    Public Function Insertar_Reconocimiento(ByVal dts As CReconocimiento) As Boolean
        Try
            Conectar()
            cmd = New SqlCommand("Insertar_Reconocimiento")
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = Conexion

            cmd.Parameters.AddWithValue("@idEmpleado", dts._idEmpleado)
            cmd.Parameters.AddWithValue("@reconocimiento", dts._reconocimiento)
            cmd.Parameters.AddWithValue("@descripcion", dts._descripcion)
            cmd.Parameters.AddWithValue("@motivo", dts._motivo)
            cmd.Parameters.AddWithValue("@fecha", dts._fecha)
            cmd.Parameters.AddWithValue("@gratificacion", dts._gratificacion)

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

    Public Function Modificar_Reconocimiento(ByVal dts As CReconocimiento) As Boolean
        Try
            Conectar()
            cmd = New SqlCommand("Modificar_Reconocimiento")
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = Conexion

            cmd.Parameters.AddWithValue("@idPremio", dts._idPremio)
            cmd.Parameters.AddWithValue("@idEmpleado", dts._idEmpleado)
            cmd.Parameters.AddWithValue("@reconocimiento", dts._reconocimiento)
            cmd.Parameters.AddWithValue("@descripcion", dts._descripcion)
            cmd.Parameters.AddWithValue("@motivo", dts._motivo)
            cmd.Parameters.AddWithValue("@fecha", dts._fecha)
            cmd.Parameters.AddWithValue("@gratificacion", dts._gratificacion)

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

    Public Function Eliminar_Reconocimiento(ByVal dts As CReconocimiento) As Boolean
        Try
            Conectar()
            cmd = New SqlCommand("Eliminar_Reconocimiento")
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = Conexion

            cmd.Parameters.AddWithValue("@idPremio", SqlDbType.Int).Value = dts._idPremio
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

    Public Function Generar_Reconocimiento() As Integer
        Conexion.Open()
        cmd = New SqlCommand("Generar_Reconocimiento", Conexion)


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
