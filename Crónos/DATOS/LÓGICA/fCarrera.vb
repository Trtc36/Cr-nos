Imports System.Data.SqlClient
Imports System.Data
Imports System.Windows.Forms

Public Class fCarrera
    Inherits Conexion
    Dim cmd As New SqlCommand

    Public Function Mostrar_Carrera() As DataTable
        Try
            Conectar()
            cmd = New SqlCommand("Mostrar_Carrera")
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

    Public Function Insertar_Carrera(ByVal dts As CCarrera) As Boolean
        Try
            Conectar()
            cmd = New SqlCommand("Insertar_Carrera")
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = Conexion

            cmd.Parameters.AddWithValue("@codigo", dts._codigo)
            cmd.Parameters.AddWithValue("@carrera", dts._carrera)
            cmd.Parameters.AddWithValue("@nivel", dts._nivel)
            
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

    Public Function Modificar_Carrera(ByVal dts As CCarrera) As Boolean
        Try
            Conectar()
            cmd = New SqlCommand("Modificar_Carrera")
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = Conexion

            cmd.Parameters.AddWithValue("@idCarrera", dts._idCarrera)
            cmd.Parameters.AddWithValue("@codigo", dts._codigo)
            cmd.Parameters.AddWithValue("@carrera", dts._carrera)
            cmd.Parameters.AddWithValue("@nivel", dts._nivel)

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

    Public Function Eliminar_Carrera(ByVal dts As CCarrera) As Boolean
        Try
            Conectar()
            cmd = New SqlCommand("Eliminar_Carrera")
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = Conexion

            cmd.Parameters.AddWithValue("@idCarrera", SqlDbType.Int).Value = dts._idCarrera
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

    Public Function Generar_Carrera() As Integer
        Conexion.Open()
        cmd = New SqlCommand("Generar_Carrera", Conexion)


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
