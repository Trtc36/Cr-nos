Imports System.Data.SqlClient
Imports System.Data
Imports System.Windows.Forms

Public Class fAgente
    Inherits Conexion
    Dim cmd As New SqlCommand

    Public Function Mostrar_Agente() As DataTable
        Try
            Conectar()
            cmd = New SqlCommand("Mostrar_Agente")
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

    Public Function Insertar_Agente(ByVal dts As CAgente) As Boolean
        Try
            Conectar()
            cmd = New SqlCommand("Insertar_Agente")
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = Conexion

            cmd.Parameters.AddWithValue("@codigo", dts._codigo)
            cmd.Parameters.AddWithValue("@nombre", dts._nombre)
            cmd.Parameters.AddWithValue("@paterno", dts._paterno)
            cmd.Parameters.AddWithValue("@materno", dts._materno)
            cmd.Parameters.AddWithValue("@telefono", dts._telefono)
            cmd.Parameters.AddWithValue("@mail", dts._mail)
            cmd.Parameters.AddWithValue("@idProveedor", dts._idProveedor)

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

    Public Function Modificar_Agente(ByVal dts As CAgente) As Boolean
        Try
            Conectar()
            cmd = New SqlCommand("Modificar_Agente")
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = Conexion

            cmd.Parameters.AddWithValue("@idAgente", dts._idAgente)
            cmd.Parameters.AddWithValue("@codigo", dts._codigo)
            cmd.Parameters.AddWithValue("@nombre", dts._nombre)
            cmd.Parameters.AddWithValue("@paterno", dts._paterno)
            cmd.Parameters.AddWithValue("@materno", dts._materno)
            cmd.Parameters.AddWithValue("@telefono", dts._telefono)
            cmd.Parameters.AddWithValue("@mail", dts._mail)
            cmd.Parameters.AddWithValue("@idProveedor", dts._idProveedor)

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

    Public Function Eliminar_Agente(ByVal dts As CAgente) As Boolean
        Try
            Conectar()
            cmd = New SqlCommand("Eliminar_Agente")
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = Conexion

            cmd.Parameters.AddWithValue("@idAgente", SqlDbType.Int).Value = dts._idAgente
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

    Public Function Generar_Agente() As Integer
        Conexion.Open()
        cmd = New SqlCommand("Generar_Agente", Conexion)


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
