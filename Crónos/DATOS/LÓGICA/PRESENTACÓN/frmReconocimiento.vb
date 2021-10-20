Imports System.ComponentModel
Public Class frmReconocimiento
    Private dt As New DataTable

    Private Sub Limpiar()
        txtIdReconocimiento.Text = ""
        txtIdReconocimiento.Text = ""
        txtIdEmpleado.Text = ""
        txtEmpleado.Text = ""
        cmbReconocimiento.Text = ""
        txtDescripcion.Text = ""
        cmbMotivo.Text = ""
        txtGratificacion.Text = ""
        dtpFecha.Value = Date.Today
    End Sub

    Private Sub Activar()
        txtGratificacion.Enabled = True
        btnEmpleado.Enabled = True
        cmbReconocimiento.Enabled = True
        txtDescripcion.Enabled = True
        cmbMotivo.Enabled = True
        dtpFecha.Enabled = True
    End Sub

    Private Sub Desactivar()
        txtGratificacion.Enabled = False
        btnEmpleado.Enabled = False
        cmbReconocimiento.Enabled = False
        txtDescripcion.Enabled = False
        cmbMotivo.Enabled = False
        dtpFecha.Enabled = False
    End Sub

    Private Sub Ocultar_Columnas()
        dgvReconocimiento.Columns(1).Visible = False
        dgvReconocimiento.Columns(3).Visible = False
        dgvReconocimiento.Columns(6).Visible = False
        dgvReconocimiento.Columns(7).Visible = False
    End Sub

    Private Sub Mostrar()
        Try
            Dim funcion As New fReconocimiento
            dt = funcion.Mostrar_Reconocimiento
            dgvReconocimiento.Columns.Item("Eliminar").Visible = False

            If dt.Rows.Count <> 0 Then
                dgvReconocimiento.DataSource = dt
                txtBuscado.Enabled = True
                dgvReconocimiento.ColumnHeadersVisible = True
                llbInexistente.Visible = True
            Else
                dgvReconocimiento.DataSource = Nothing
                txtBuscado.Enabled = False
                dgvReconocimiento.ColumnHeadersVisible = False
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
                dgvReconocimiento.DataSource = dv
                Ocultar_Columnas()
            Else
                llbInexistente.Visible = True
                dgvReconocimiento.DataSource = Nothing
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
        Dim func As New fReconocimiento
        txtIdReconocimiento.Text = Format(func.Generar_Reconocimiento)
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Mostrar()
    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        Dim result As DialogResult
        result = MessageBox.Show("¿Realmente quiere modificar el registro?", "Modificando Registro", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)

        If result = DialogResult.OK Then
            If Me.ValidateChildren = True And txtIdReconocimiento.Text <> 0 And txtIdEmpleado.Text <> "" And cmbReconocimiento.Text <> "" And txtDescripcion.Text <> "" And cmbMotivo.Text <> "" And dtpFecha.Text <> "" And txtGratificacion.Text <> "" Then
                Try
                    Dim dts As New CReconocimiento
                    Dim func As New fReconocimiento

                    dts._idPremio = txtIdReconocimiento.Text
                    dts._idEmpleado = txtIdEmpleado.Text
                    dts._reconocimiento = cmbReconocimiento.Text
                    dts._descripcion = txtDescripcion.Text
                    dts._motivo = cmbMotivo.Text
                    dts._fecha = dtpFecha.Value
                    dts._gratificacion = txtGratificacion.Text

                    If func.Modificar_Reconocimiento(dts) Then
                        MessageBox.Show("Reconocimiento modificado correctamente", "Modificando Registro", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Mostrar()
                        Limpiar()
                    Else
                        MessageBox.Show("Reconocimiento no modificado, intente de nuevo", "Modificando Registro", MessageBoxButtons.OK, MessageBoxIcon.Information)
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
        If Me.ValidateChildren = True And txtIdEmpleado.Text <> "" And cmbReconocimiento.Text <> "" And txtDescripcion.Text <> "" And cmbMotivo.Text <> "" And dtpFecha.Text <> "" And txtGratificacion.Text <> "" Then
            Try
                Dim dts As New CReconocimiento
                Dim func As New fReconocimiento

                dts._idPremio = txtIdReconocimiento.Text
                dts._idEmpleado = txtIdEmpleado.Text
                dts._reconocimiento = cmbReconocimiento.Text
                dts._descripcion = txtDescripcion.Text
                dts._motivo = cmbMotivo.Text
                dts._fecha = dtpFecha.Value
                dts._gratificacion = txtGratificacion.Text

                If func.Insertar_Reconocimiento(dts) Then
                    MessageBox.Show("Reconocimiento registrado correctamente", "Guardando Registro", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Mostrar()
                    Limpiar()
                Else
                    MessageBox.Show("Reconocimiento no registrado, intente de nuevo", "Guardando Registro", MessageBoxButtons.OK, MessageBoxIcon.Information)
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

    Private Sub frmReconocimiento_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Mostrar()
        Limpiar()
        btnNuevo.Enabled = True
        btnSalir.Enabled = True
        btnGuardar.Enabled = False
        btnModificar.Enabled = False
        btnCancelar.Enabled = False
        Desactivar()
    End Sub

    Private Sub txtGratificacion_Validating(sender As Object, e As CancelEventArgs) Handles txtGratificacion.Validating
        If DirectCast(sender, TextBox).Text.Length > 0 Then
            Me.erpErrorIcono.SetError(sender, "")
        Else
            Me.erpErrorIcono.SetError(sender, "Ingresa Gratificación del Empleado (Puede ser 0), Dato Obligatorio")
        End If
    End Sub

    Private Sub txtIdEmpleado_Validating(sender As Object, e As CancelEventArgs) Handles txtIdEmpleado.Validating
        If DirectCast(sender, TextBox).Text.Length > 0 Then
            Me.erpErrorIcono.SetError(sender, "")
        Else
            Me.erpErrorIcono.SetError(sender, "Ingresa ID del Empleado, Dato Obligatorio")
        End If
    End Sub

    Private Sub cmbReconocimiento_Validating(sender As Object, e As CancelEventArgs) Handles cmbReconocimiento.Validating
        If DirectCast(sender, ComboBox).Text.Length > 0 Then
            Me.erpErrorIcono.SetError(sender, "")
        Else
            Me.erpErrorIcono.SetError(sender, "Selecciona el Reconocimiento del Empleado, Dato Obligatorio")
        End If
    End Sub

    Private Sub txtDescripcion_Validating(sender As Object, e As CancelEventArgs) Handles txtDescripcion.Validating
        If DirectCast(sender, TextBox).Text.Length > 0 Then
            Me.erpErrorIcono.SetError(sender, "")
        Else
            Me.erpErrorIcono.SetError(sender, "Ingresa la Descripción del Reconocimiento, Dato Obligatorio")
        End If
    End Sub

    Private Sub cmbMotivo_Validating(sender As Object, e As CancelEventArgs) Handles cmbMotivo.Validating
        If DirectCast(sender, ComboBox).Text.Length > 0 Then
            Me.erpErrorIcono.SetError(sender, "")
        Else
            Me.erpErrorIcono.SetError(sender, "Selecciona el Motivo del Reconocimiento, Dato Obligatorio")
        End If
    End Sub

    Private Sub dtpFecha_Validating(sender As Object, e As CancelEventArgs) Handles dtpFecha.Validating
        If DirectCast(sender, DateTimePicker).Value <> Nothing Then
            Me.erpErrorIcono.SetError(sender, "")
        Else
            Me.erpErrorIcono.SetError(sender, "Ingresa la Descripción del Reconocimiento, Dato Obligatorio")
        End If
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Dim result As DialogResult
        result = MessageBox.Show("Realmente desea eliminar la información seleccionada", "Eliminación de Registro", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)

        If result = DialogResult.OK Then
            Try
                For Each row As DataGridViewRow In dgvReconocimiento.Rows
                    Dim marcado As Boolean = Convert.ToBoolean(row.Cells("Eliminar").Value)

                    If marcado Then
                        Dim onekey As Integer = Convert.ToInt32(row.Cells("ID_Premio").Value)
                        Dim vdb As New CReconocimiento
                        Dim func As New fReconocimiento
                        vdb._idPremio = onekey

                        If func.Eliminar_Reconocimiento(vdb) Then
                        Else
                            MessageBox.Show("Reconocimiento no eliminado", "Eliminación de Registro", MessageBoxButtons.OK, MessageBoxIcon.Information)
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
            dgvReconocimiento.Columns.Item("Eliminar").Visible = True
            btnEliminar.Visible = True
        Else
            dgvReconocimiento.Columns.Item("Eliminar").Visible = False
            btnEliminar.Visible = False
        End If
    End Sub

    Private Sub dgvReconocimiento_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvReconocimiento.CellContentClick
        If e.ColumnIndex = Me.dgvReconocimiento.Columns.Item("Eliminar").Index Then
            Dim chkcell As DataGridViewCheckBoxCell = Me.dgvReconocimiento.Rows(e.RowIndex).Cells("Eliminar")
            chkcell.Value = Not chkcell.Value
        End If
    End Sub

    Private Sub dgvReconocimiento_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvReconocimiento.CellClick
        txtIdReconocimiento.Text = dgvReconocimiento.SelectedCells.Item(1).Value
        txtGratificacion.Text = dgvReconocimiento.SelectedCells.Item(2).Value
        txtIdEmpleado.Text = dgvReconocimiento.SelectedCells.Item(3).Value
        txtEmpleado.Text = dgvReconocimiento.SelectedCells.Item(4).Value
        cmbReconocimiento.Text = dgvReconocimiento.SelectedCells.Item(5).Value
        txtDescripcion.Text = dgvReconocimiento.SelectedCells.Item(6).Value
        cmbMotivo.Text = dgvReconocimiento.SelectedCells.Item(7).Value
        dtpFecha.Value = dgvReconocimiento.SelectedCells.Item(8).Value
        Activar()
        btnModificar.Enabled = True
        btnGuardar.Enabled = False
        btnCancelar.Enabled = True
        btnNuevo.Enabled = False
    End Sub

    Private Sub btnEmpleado_Click(sender As Object, e As EventArgs) Handles btnEmpleado.Click
        frmEmpleado.txtFlag.Text = "6"
        frmEmpleado.MdiParent = Crónos
        frmEmpleado.Show()
    End Sub
End Class