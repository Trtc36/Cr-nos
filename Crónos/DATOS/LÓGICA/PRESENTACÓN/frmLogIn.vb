Public Class frmLogIn
    Public contador As Integer = 0
    Dim permiso As Boolean

    Dim conexion As Conexion = New Conexion()

    Private Sub btnEntrar_Click(sender As Object, e As EventArgs) Handles btnEntrar.Click
        Try
            Dim dts As New CUsuario
            Dim func As New fUsuario

            dts._usuario = txtUsuario.Text
            dts._password = txtContraseña.Text

            If func.Validar_Usuario(dts) = True Then
                Crónos.Show()
                Me.Hide()
            Else
                MsgBox("Datos incorrectos, intente de nuevo", MsgBoxStyle.Information, "Acceso denegado")
                txtUsuario.Clear()
                txtContraseña.Clear()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        End
    End Sub
End Class
