Imports System.ComponentModel
Public Class frmPermiso
    Private dt As New DataTable
    Dim func As New fPermiso

    Private Sub Limpiar()
        txtIdPermiso.Text = ""
        txtCodigo.Text = ""
        cmbTipo.Text = ""
        cmbAlcance.Text = ""
    End Sub

    Private Sub Activar()
        cmbTipo.Enabled = True
        cmbAlcance.Enabled = True
    End Sub

    Private Sub Desactivar()
        cmbTipo.Enabled = False
        cmbAlcance.Enabled = False
    End Sub

    Private Sub Ocultar_Columnas()
        dgvPermiso.Columns(1).Visible = False
        dgvPermiso.Columns(4).Visible = False
    End Sub

    Private Sub Mostrar()
        Try
            Dim funcion As New fPermiso
            dt = funcion.Mostrar_Permiso
            dgvPermiso.Columns.Item("Eliminar").Visible = False

            If dt.Rows.Count <> 0 Then
                dgvPermiso.DataSource = dt
                txtBuscado.Enabled = True
                dgvPermiso.ColumnHeadersVisible = True
                llbInexistente.Visible = True
            Else
                dgvPermiso.DataSource = Nothing
                txtBuscado.Enabled = False
                dgvPermiso.ColumnHeadersVisible = False
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
                dgvPermiso.DataSource = dv
                Ocultar_Columnas()
            Else
                llbInexistente.Visible = True
                dgvPermiso.DataSource = Nothing
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
        codigo = Format(func.Generar_Permiso, "0000")
        txtIdPermiso.Text = Format(func.Generar_Permiso)
        txtCodigo.Text = "CRONOSPER" + codigo
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Mostrar()
    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        Dim result As DialogResult
        result = MessageBox.Show("¿Realmente quiere modificar el registro?", "Modificando Registro", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)

        If result = DialogResult.OK Then
            If Me.ValidateChildren = True And txtIdPermiso.Text <> 0 And txtCodigo.Text <> "" And cmbTipo.Text <> "" And cmbAlcance.Text <> "" Then
                Try
                    Dim dts As New CPermiso
                    Dim func As New fPermiso

                    dts._idPermiso = txtIdPermiso.Text
                    dts._codigo = txtCodigo.Text
                    dts._tPermiso = cmbTipo.Text
                    dts._alcance = cmbAlcance.Text

                    If func.Modificar_Permiso(dts) Then
                        MessageBox.Show("Permiso de Acceso modificado correctamente", "Modificando Registro", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Mostrar()
                        Limpiar()
                    Else
                        MessageBox.Show("Permiso de Acceso no modificado, intente de nuevo", "Modificando Registro", MessageBoxButtons.OK, MessageBoxIcon.Information)
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
        If Me.ValidateChildren = True And txtCodigo.Text <> "" And cmbTipo.Text <> "" And cmbAlcance.Text <> "" Then
            Try
                Dim dts As New CPermiso
                Dim func As New fPermiso

                dts._codigo = txtCodigo.Text
                dts._tPermiso = cmbTipo.Text
                dts._alcance = cmbAlcance.Text

                If func.Insertar_Permiso(dts) Then
                    MessageBox.Show("Permiso de Acceso registrado correctamente", "Guardando Registro", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Mostrar()
                    Limpiar()
                Else
                    MessageBox.Show("Permiso de Acceso no registrado, intente de nuevo", "Guardando Registro", MessageBoxButtons.OK, MessageBoxIcon.Information)
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

    Private Sub frmPermiso_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
            Me.erpErrorIcono.SetError(sender, "Ingresa el Código del Permiso de Acceso, Dato Obligatorio")
        End If
    End Sub

    Private Sub cmbTipo_Validating(sender As Object, e As CancelEventArgs) Handles cmbTipo.Validating
        If DirectCast(sender, ComboBox).Text.Length > 0 Then
            Me.erpErrorIcono.SetError(sender, "")
        Else
            Me.erpErrorIcono.SetError(sender, "Ingresa el Tipo del Permiso de Acceso, Dato Obligatorio")
        End If
    End Sub

    Private Sub cmbAlcance_Validating(sender As Object, e As CancelEventArgs) Handles cmbAlcance.Validating
        If DirectCast(sender, ComboBox).Text.Length > 0 Then
            Me.erpErrorIcono.SetError(sender, "")
        Else
            Me.erpErrorIcono.SetError(sender, "Ingresa el Alcance del Permiso de Acceso, Dato Obligatorio")
        End If
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Dim result As DialogResult
        result = MessageBox.Show("Realmente desea eliminar la información seleccionada", "Eliminación de Registro", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)

        If result = DialogResult.OK Then
            Try
                For Each row As DataGridViewRow In dgvPermiso.Rows
                    Dim marcado As Boolean = Convert.ToBoolean(row.Cells("Eliminar").Value)

                    If marcado Then
                        Dim onekey As Integer = Convert.ToInt32(row.Cells("ID_Permiso").Value)
                        Dim vdb As New CPermiso
                        Dim func As New fPermiso
                        vdb._idPermiso = onekey

                        If func.Eliminar_Permiso(vdb) Then
                        Else
                            MessageBox.Show("Permiso de Acceso no eliminado", "Eliminación de Registro", MessageBoxButtons.OK, MessageBoxIcon.Information)
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
            dgvPermiso.Columns.Item("Eliminar").Visible = True
            btnEliminar.Visible = True
        Else
            dgvPermiso.Columns.Item("Eliminar").Visible = False
            btnEliminar.Visible = False
        End If
    End Sub

    Private Sub dgvPermiso_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvPermiso.CellContentClick
        If e.ColumnIndex = Me.dgvPermiso.Columns.Item("Eliminar").Index Then
            Dim chkcell As DataGridViewCheckBoxCell = Me.dgvPermiso.Rows(e.RowIndex).Cells("Eliminar")
            chkcell.Value = Not chkcell.Value
        End If
    End Sub

    Private Sub dgvPermiso_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvPermiso.CellClick
        txtIdPermiso.Text = dgvPermiso.SelectedCells.Item(1).Value
        txtCodigo.Text = dgvPermiso.SelectedCells.Item(2).Value
        cmbTipo.Text = dgvPermiso.SelectedCells.Item(3).Value
        cmbAlcance.Text = dgvPermiso.SelectedCells.Item(4).Value
        Activar()
        btnModificar.Enabled = True
        btnGuardar.Enabled = False
        btnCancelar.Enabled = True
        btnNuevo.Enabled = False
    End Sub

    Private Sub dgvPermiso_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvPermiso.CellDoubleClick
        If txtFlag.Text = "1" Then
            frmUsuario.txtIdPermiso.Text = dgvPermiso.SelectedCells.Item(1).Value
            frmUsuario.txtPermiso.Text = dgvPermiso.SelectedCells.Item(3).Value
            Me.Close()
        End If
    End Sub
End Class