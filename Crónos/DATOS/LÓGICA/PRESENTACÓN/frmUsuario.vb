Imports System.ComponentModel
Public Class frmUsuario
    Private dt As New DataTable
    Dim func As New fUsuario

    Private Sub Limpiar()
        txtIdUsuario.Text = ""
        txtCodigo.Text = ""
        txtIdEmpleado.Text = ""
        txtNEmpleado.Text = ""
        txtPEmpleado.Text = ""
        txtMEmpleado.Text = ""
        txtUsuario.Text = ""
        txtContraseña.Text = ""
        txtIdPermiso.Text = ""
        txtPermiso.Text = ""
        cmbEstatus.Text = ""
    End Sub

    Private Sub Activar()
        btnEmpleado.Enabled = True
        btnPermiso.Enabled = True
        btnGenerar.Enabled = True
        txtContraseña.Enabled = True
        cmbEstatus.Enabled = True
    End Sub

    Private Sub Desactivar()
        btnEmpleado.Enabled = False
        btnPermiso.Enabled = False
        btnGenerar.Enabled = False
        txtContraseña.Enabled = False
        cmbEstatus.Enabled = False
    End Sub

    Private Sub Ocultar_Columnas()
        dgvUsuario.Columns(1).Visible = False
        dgvUsuario.Columns(3).Visible = False
        dgvUsuario.Columns(5).Visible = False
        dgvUsuario.Columns(6).Visible = False
        dgvUsuario.Columns(8).Visible = False
        dgvUsuario.Columns(9).Visible = False
    End Sub

    Private Sub Mostrar()
        Try
            Dim funcion As New fUsuario
            dt = funcion.Mostrar_Usuario
            dgvUsuario.Columns.Item("Eliminar").Visible = False

            If dt.Rows.Count <> 0 Then
                dgvUsuario.DataSource = dt
                txtBuscado.Enabled = True
                dgvUsuario.ColumnHeadersVisible = True
                llbInexistente.Visible = True
            Else
                dgvUsuario.DataSource = Nothing
                txtBuscado.Enabled = False
                dgvUsuario.ColumnHeadersVisible = False
                llbInexistente.Visible = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        btnNuevo.Enabled = True
        btnGuardar.Enabled = False
        btnCancelar.Enabled = False
        btnModificar.Enabled = False
        btnSalir.Enabled = True
        btnBuscar.Enabled = True

        Buscar()
    End Sub

    Private Sub Buscar()
        Try
            Dim ds As New DataSet
            ds.Tables.Add(dt.Copy)
            Dim dv As New DataView(ds.Tables(0))

            dv.RowFilter = cmbBuscar.Text & " like '" & txtBuscado.Text & "%'"

            If dv.Count <> 0 Then
                llbInexistente.Visible = False
                dgvUsuario.DataSource = dv
                Ocultar_Columnas()
            Else
                llbInexistente.Visible = True
                dgvUsuario.DataSource = Nothing
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        Limpiar()
        Activar()
        btnCancelar.Enabled = True
        btnGuardar.Enabled = True
        btnNuevo.Enabled = False
        btnModificar.Enabled = False
        Dim codigo As String
        codigo = Format(func.Generar_Usuario, "0000")
        txtIdUsuario.Text = Format(func.Generar_Usuario)
        txtCodigo.Text = "CRONOSUSU" + codigo
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Mostrar()
    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        Dim result As DialogResult
        result = MessageBox.Show("¿Realmente quiere modificar el registro?", "Modificando Registro", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)

        If result = DialogResult.OK Then
            If Me.ValidateChildren = True And txtIdUsuario.Text <> 0 And txtCodigo.Text <> "" And txtUsuario.Text <> "" And txtContraseña.Text <> "" And txtIdEmpleado.Text <> "" And txtIdPermiso.Text <> "" And cmbEstatus.Text <> "" Then
                Try
                    Dim dts As New CUsuario
                    Dim func As New fUsuario

                    dts._idUsuario = txtIdUsuario.Text
                    dts._codigo = txtCodigo.Text
                    dts._usuario = txtUsuario.Text
                    dts._password = txtContraseña.Text
                    dts._idEmpleado = txtIdEmpleado.Text
                    dts._idPermiso = txtIdPermiso.Text
                    dts._estatus = cmbEstatus.Text

                    If func.Modificar_Usuario(dts) Then
                        MessageBox.Show("Usuario modificado correctamente", "Modificando Registro", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Mostrar()
                        Limpiar()
                    Else
                        MessageBox.Show("Usuario no modificado, intente de nuevo", "Modificando Registro", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Mostrar()
                        Limpiar()
                    End If
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
                Desactivar()
            Else
                MessageBox.Show("Faltan datos por ingresar", "Modificando Registro", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Limpiar()
        Desactivar()
        btnNuevo.Enabled = True
        btnSalir.Enabled = True
        btnGuardar.Enabled = False
        btnModificar.Enabled = False
        btnCancelar.Enabled = False
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If Me.ValidateChildren = True And txtIdUsuario.Text <> 0 And txtCodigo.Text <> "" And txtUsuario.Text <> "" And txtContraseña.Text <> "" And txtIdEmpleado.Text <> "" And txtIdPermiso.Text <> "" And cmbEstatus.Text <> "" Then
            Try
                Dim dts As New CUsuario
                Dim func As New fUsuario

                dts._codigo = txtCodigo.Text
                dts._usuario = txtUsuario.Text
                dts._password = txtContraseña.Text
                dts._idEmpleado = txtIdEmpleado.Text
                dts._idPermiso = txtIdPermiso.Text
                dts._estatus = cmbEstatus.Text

                If func.Insertar_Usuario(dts) Then
                    MessageBox.Show("Usuario registrado correctamente", "Guardando Registro", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Mostrar()
                    Limpiar()
                Else
                    MessageBox.Show("Usuario no registrado, intente de nuevo", "Guardando Registro", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Mostrar()
                    Limpiar()
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            Desactivar()
        Else
            MessageBox.Show("Faltan datos por ingresar", "Guardando Registro", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Close()
    End Sub

    Private Sub frmUsuario_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Mostrar()
        Limpiar()
        btnNuevo.Enabled = True
        btnSalir.Enabled = True
        btnGuardar.Enabled = False
        btnModificar.Enabled = False
        btnCancelar.Enabled = False
        Desactivar()
    End Sub

    Private Sub txtCodigo_Validating(sender As Object, e As CancelEventArgs) Handles txtCodigo.Validating
        If DirectCast(sender, TextBox).Text.Length > 0 Then
            Me.erpErrorIcono.SetError(sender, "")
        Else
            Me.erpErrorIcono.SetError(sender, "Ingresa el Código del Usuario, Dato Obligatorio")
        End If
    End Sub

    Private Sub txtIdEmpleado_Validating(sender As Object, e As CancelEventArgs) Handles txtIdEmpleado.Validating
        If DirectCast(sender, TextBox).Text.Length > 0 Then
            Me.erpErrorIcono.SetError(sender, "")
        Else
            Me.erpErrorIcono.SetError(sender, "Ingresa el ID del Empleado, Dato Obligatorio")
        End If
    End Sub

    Private Sub txtUsuario_Validating(sender As Object, e As CancelEventArgs) Handles txtUsuario.Validating
        If DirectCast(sender, TextBox).Text.Length > 0 Then
            Me.erpErrorIcono.SetError(sender, "")
        Else
            Me.erpErrorIcono.SetError(sender, "Genera el Nombre del Usuario, Dato Obligatorio")
        End If
    End Sub

    Private Sub txtContraseña_Validating(sender As Object, e As CancelEventArgs) Handles txtContraseña.Validating
        If DirectCast(sender, TextBox).Text.Length > 0 Then
            Me.erpErrorIcono.SetError(sender, "")
        Else
            Me.erpErrorIcono.SetError(sender, "Ingresa el Password del Usuario, Dato Obligatorio")
        End If
    End Sub

    Private Sub txtIdPermiso_Validating(sender As Object, e As CancelEventArgs) Handles txtIdPermiso.Validating
        If DirectCast(sender, TextBox).Text.Length > 0 Then
            Me.erpErrorIcono.SetError(sender, "")
        Else
            Me.erpErrorIcono.SetError(sender, "Selecciona el Permiso del Usuario, Dato Obligatorio")
        End If
    End Sub

    Private Sub cmbEstatus_Validating(sender As Object, e As CancelEventArgs) Handles cmbEstatus.Validating
        If DirectCast(sender, ComboBox).Text.Length > 0 Then
            Me.erpErrorIcono.SetError(sender, "")
        Else
            Me.erpErrorIcono.SetError(sender, "Selecciona el Estatus del Usuario, Dato Obligatorio")
        End If
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Dim result As DialogResult
        result = MessageBox.Show("Realmente desea eliminar la información seleccionada", "Eliminación de Registro", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)

        If result = DialogResult.OK Then
            Try
                For Each row As DataGridViewRow In dgvUsuario.Rows
                    Dim marcado As Boolean = Convert.ToBoolean(row.Cells("Eliminar").Value)

                    If marcado Then
                        Dim onekey As Integer = Convert.ToInt32(row.Cells("ID_Usuario").Value)
                        Dim vdb As New CUsuario
                        Dim func As New fUsuario
                        vdb._idUsuario = onekey

                        If func.Eliminar_Usuario(vdb) Then
                        Else
                            MessageBox.Show("Usuario no eliminado", "Eliminación de Registro", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                    End If
                Next
                Call Mostrar()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Else
            MessageBox.Show("Cancelando eliminación de registro", "Eliminación de Registro", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Mostrar()
        End If
        Limpiar()
    End Sub

    Private Sub chbEliminar_CheckedChanged(sender As Object, e As EventArgs) Handles chbEliminar.CheckedChanged
        If chbEliminar.CheckState = CheckState.Checked Then
            dgvUsuario.Columns.Item("Eliminar").Visible = True
            btnEliminar.Visible = True
        Else
            dgvUsuario.Columns.Item("Eliminar").Visible = False
            btnEliminar.Visible = False
        End If
    End Sub

    Private Sub dgvUsuario_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvUsuario.CellContentClick
        If e.ColumnIndex = Me.dgvUsuario.Columns.Item("Eliminar").Index Then
            Dim chkcell As DataGridViewCheckBoxCell = Me.dgvUsuario.Rows(e.RowIndex).Cells("Eliminar")
            chkcell.Value = Not chkcell.Value
        End If
    End Sub

    Private Sub dgvUsuario_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvUsuario.CellClick
        txtIdUsuario.Text = dgvUsuario.SelectedCells.Item(1).Value
        txtCodigo.Text = dgvUsuario.SelectedCells.Item(2).Value
        txtIdEmpleado.Text = dgvUsuario.SelectedCells.Item(3).Value
        txtNEmpleado.Text = dgvUsuario.SelectedCells.Item(4).Value
        txtPEmpleado.Text = dgvUsuario.SelectedCells.Item(5).Value
        txtMEmpleado.Text = dgvUsuario.SelectedCells.Item(6).Value
        txtUsuario.Text = dgvUsuario.SelectedCells.Item(7).Value
        txtContraseña.Text = dgvUsuario.SelectedCells.Item(8).Value
        txtIdPermiso.Text = dgvUsuario.SelectedCells.Item(9).Value
        txtPermiso.Text = dgvUsuario.SelectedCells.Item(10).Value
        cmbEstatus.Text = dgvUsuario.SelectedCells.Item(11).Value
        Activar()
        btnModificar.Enabled = True
        btnGuardar.Enabled = False
        btnCancelar.Enabled = True
        btnNuevo.Enabled = False
    End Sub

    Private Sub btnEmpleado_Click(sender As Object, e As EventArgs) Handles btnEmpleado.Click
        frmEmpleado.txtFlag.Text = "7"
        frmEmpleado.MdiParent = Crónos
        frmEmpleado.Show()
    End Sub

    Private Sub btnPermiso_Click(sender As Object, e As EventArgs) Handles btnPermiso.Click
        frmPermiso.txtFlag.Text = "1"
        frmPermiso.MdiParent = Crónos
        frmPermiso.Show()
    End Sub

    Private Sub btnGenerar_Click(sender As Object, e As EventArgs) Handles btnGenerar.Click
        Dim Nombre() As Char = txtNEmpleado.Text.ToArray
        Dim Paterno() As Char = txtPEmpleado.Text.ToArray

        Dim Usuario = Nombre(0) + Paterno + Format(func.Generar_Usuario)
        txtUsuario.Text = Usuario
    End Sub
End Class