Imports System.Data.SqlClient
Imports System.Data
Imports System.Windows.Forms

Public Class fDesempeño
    Inherits Conexion
    Dim cmd As New SqlCommand

    Public Function Mostrar_Desempeño() As DataTable
        Try
            Conectar()
            cmd = New SqlCommand("Mostrar_Desempeño")
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

    Public Function Insertar_Desempeño(ByVal dts As CDesempeño) As Boolean
        Try
            Conectar()
            cmd = New SqlCommand("Insertar_Desempeño")
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = Conexion

            cmd.Parameters.AddWithValue("@idEmpleado", dts._idEmpleado)
            cmd.Parameters.AddWithValue("@fecha", dts._fecha)
            cmd.Parameters.AddWithValue("@cMensual", dts._cMensual)
            cmd.Parameters.AddWithValue("@pAlcance", dts._pAlcance)
            cmd.Parameters.AddWithValue("@eDirecta", dts._eDirecta)
            cmd.Parameters.AddWithValue("@eTotal", dts._eTotal)

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

    Public Function Modificar_Desempeño(ByVal dts As CDesempeño) As Boolean
        Try
            Conectar()
            cmd = New SqlCommand("Modificar_Desempeño")
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = Conexion

            cmd.Parameters.AddWithValue("@idEvaluacion", dts._idEvaluacion)
            cmd.Parameters.AddWithValue("@idEmpleado", dts._idEmpleado)
            cmd.Parameters.AddWithValue("@fecha", dts._fecha)
            cmd.Parameters.AddWithValue("@cMensual", dts._cMensual)
            cmd.Parameters.AddWithValue("@pAlcance", dts._pAlcance)
            cmd.Parameters.AddWithValue("@eDirecta", dts._eDirecta)
            cmd.Parameters.AddWithValue("@eTotal", dts._eTotal)

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

    Public Function Eliminar_Desempeño(ByVal dts As CDesempeño) As Boolean
        Try
            Conectar()
            cmd = New SqlCommand("Eliminar_Desempeño")
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = Conexion

            cmd.Parameters.AddWithValue("@idEvaluacion", SqlDbType.Int).Value = dts._idEvaluacion
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

    Public Function Generar_Desempeño() As Integer
        Conexion.Open()
        cmd = New SqlCommand("Generar_Desempeño", Conexion)


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
