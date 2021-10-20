Imports System.ComponentModel
Public Class frmVenta
    Private dt As New DataTable
    Dim func As New fVenta

    Private Sub Limpiar()
        txtIdVenta.Text = ""
        txtFolio.Text = ""
        dtpFecha.Value = Date.Today
        txtIdCliente.Text = ""
        txtCliente.Text = ""
        cmbtVenta.Text = ""
        txtIdEmpleado.Text = ""
        txtEmpleado.Text = ""
    End Sub

    Private Sub Activar()
        dtpFecha.Enabled = True
        cmbtVenta.Enabled = True
        btnCliente.Enabled = True
        btnEmpleado.Enabled = True
    End Sub

    Private Sub Desactivar()
        dtpFecha.Enabled = False
        cmbtVenta.Enabled = False
        btnCliente.Enabled = False
        btnEmpleado.Enabled = False
    End Sub

    Private Sub Ocultar_Columnas()
        dgvVenta.Columns(1).Visible = False
        dgvVenta.Columns(4).Visible = False
        dgvVenta.Columns(7).Visible = False
    End Sub

    Private Sub Mostrar()
        Try
            Dim funcion As New fVenta
            dt = funcion.Mostrar_Venta
            dgvVenta.Columns.Item("Eliminar").Visible = False

            If dt.Rows.Count <> 0 Then
                dgvVenta.DataSource = dt
                txtBuscado.Enabled = True
                dgvVenta.ColumnHeadersVisible = True
                llbInexistente.Visible = True
            Else
                dgvVenta.DataSource = Nothing
                txtBuscado.Enabled = False
                dgvVenta.ColumnHeadersVisible = False
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
                dgvVenta.DataSource = dv
                Ocultar_Columnas()
            Else
                llbInexistente.Visible = True
                dgvVenta.DataSource = Nothing
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
        codigo = Format(func.Generar_FVenta, "0000")
        txtIdVenta.Text = Format(func.Generar_FVenta)
        txtFolio.Text = "F" + codigo
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Mostrar()
    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        Dim result As DialogResult
        result = MessageBox.Show("¿Realmente quiere modificar el registro?", "Modificando Registro", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)

        If result = DialogResult.OK Then
            If Me.ValidateChildren = True And txtIdVenta.Text <> 0 And txtFolio.Text <> "" And dtpFecha.Value <> Nothing And txtIdCliente.Text <> "" And cmbtVenta.Text <> "" And txtIdEmpleado.Text <> "" Then
                Try
                    Dim dts As New CVenta
                    Dim func As New fVenta

                    dts._idVenta = txtIdVenta.Text
                    dts._folio = txtFolio.Text
                    dts._fecha = dtpFecha.Value
                    dts._idCliente = txtIdCliente.Text
                    dts._tVenta = cmbtVenta.Text
                    dts._idEmpleado = txtIdEmpleado.Text

                    If func.Modificar_Venta(dts) Then
                        MessageBox.Show("Venta modificada correctamente", "Modificando Registro", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Mostrar()
                        Limpiar()
                    Else
                        MessageBox.Show("Venta no modificada, intente de nuevo", "Modificando Registro", MessageBoxButtons.OK, MessageBoxIcon.Information)
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
        If Me.ValidateChildren = True And txtIdVenta.Text <> 0 And txtFolio.Text <> "" And dtpFecha.Value <> Nothing And txtIdCliente.Text <> "" And cmbtVenta.Text <> "" And txtIdEmpleado.Text <> "" Then
            Try
                Dim dts As New CVenta
                Dim func As New fVenta

                dts._folio = txtFolio.Text
                dts._fecha = dtpFecha.Value
                dts._idCliente = txtIdCliente.Text
                dts._tVenta = cmbtVenta.Text
                dts._idEmpleado = txtIdEmpleado.Text

                If func.Insertar_Venta(dts) Then
                    MessageBox.Show("Venta registrada correctamente", "Guardando Registro", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Mostrar()
                    Limpiar()
                Else
                    MessageBox.Show("Venta no registrada, intente de nuevo", "Guardando Registro", MessageBoxButtons.OK, MessageBoxIcon.Information)
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

    Private Sub frmVenta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Mostrar()
        Limpiar()
        btnNuevo.Enabled = True
        btnSalir.Enabled = True
        btnGuardar.Enabled = False
        btnModificar.Enabled = False
        btnCancelar.Enabled = False
        Desactivar()
    End Sub

    Private Sub txtFolio_Validating(sender As Object, e As CancelEventArgs) Handles txtFolio.Validating
        If DirectCast(sender, TextBox).Text.Length > 0 Then
            Me.erpErrorIcono.SetError(sender, "")
        Else
            Me.erpErrorIcono.SetError(sender, "Ingresa el Folio de la Venta, Dato Obligatorio")
        End If
    End Sub

    Private Sub dtpFecha_Validating(sender As Object, e As CancelEventArgs) Handles dtpFecha.Validating
        If DirectCast(sender, DateTimePicker).Value <> Nothing Then
            Me.erpErrorIcono.SetError(sender, "")
        Else
            Me.erpErrorIcono.SetError(sender, "Selecciona la Fecha de la Venta, Dato Obligatorio")
        End If
    End Sub

    Private Sub txtIdCliente_Validating(sender As Object, e As CancelEventArgs) Handles txtIdCliente.Validating
        If DirectCast(sender, TextBox).Text.Length > 0 Then
            Me.erpErrorIcono.SetError(sender, "")
        Else
            Me.erpErrorIcono.SetError(sender, "Selecciona el ID del Cliente de la Venta, Dato Obligatorio")
        End If
    End Sub

    Private Sub cmbtVenta_Validating(sender As Object, e As CancelEventArgs) Handles cmbtVenta.Validating
        If DirectCast(sender, ComboBox).Text.Length > 0 Then
            Me.erpErrorIcono.SetError(sender, "")
        Else
            Me.erpErrorIcono.SetError(sender, "Selecciona el Tipo de la Venta, Dato Obligatorio")
        End If
    End Sub

    Private Sub txtIdEmpleado_Validating(sender As Object, e As CancelEventArgs) Handles txtIdEmpleado.Validating
        If DirectCast(sender, TextBox).Text.Length > 0 Then
            Me.erpErrorIcono.SetError(sender, "")
        Else
            Me.erpErrorIcono.SetError(sender, "Selecciona el ID del Empleado de la Venta, Dato Obligatorio")
        End If
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Dim result As DialogResult
        result = MessageBox.Show("Realmente desea eliminar la información seleccionada", "Eliminación de Registro", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)

        If result = DialogResult.OK Then
            Try
                For Each row As DataGridViewRow In dgvVenta.Rows
                    Dim marcado As Boolean = Convert.ToBoolean(row.Cells("Eliminar").Value)

                    If marcado Then
                        Dim onekey As Integer = Convert.ToInt32(row.Cells("ID_Venta").Value)
                        Dim vdb As New CVenta
                        Dim func As New fVenta
                        vdb._idVenta = onekey

                        If func.Eliminar_Venta(vdb) Then
                        Else
                            MessageBox.Show("Venta no eliminada", "Eliminación de Registro", MessageBoxButtons.OK, MessageBoxIcon.Information)
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
            dgvVenta.Columns.Item("Eliminar").Visible = True
            btnEliminar.Visible = True
        Else
            dgvVenta.Columns.Item("Eliminar").Visible = False
            btnEliminar.Visible = False
        End If
    End Sub

    Private Sub dgvVenta_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvVenta.CellContentClick
        If e.ColumnIndex = Me.dgvVenta.Columns.Item("Eliminar").Index Then
            Dim chkcell As DataGridViewCheckBoxCell = Me.dgvVenta.Rows(e.RowIndex).Cells("Eliminar")
            chkcell.Value = Not chkcell.Value
        End If
    End Sub

    Private Sub dgvVenta_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvVenta.CellClick
        txtIdVenta.Text = dgvVenta.SelectedCells.Item(1).Value
        txtFolio.Text = dgvVenta.SelectedCells.Item(2).Value
        dtpFecha.Value = dgvVenta.SelectedCells.Item(3).Value
        txtIdCliente.Text = dgvVenta.SelectedCells.Item(4).Value
        txtCliente.Text = dgvVenta.SelectedCells.Item(5).Value
        cmbtVenta.Text = dgvVenta.SelectedCells.Item(6).Value
        txtIdEmpleado.Text = dgvVenta.SelectedCells.Item(7).Value
        txtEmpleado.Text = dgvVenta.SelectedCells.Item(8).Value
        Activar()
        btnModificar.Enabled = True
        btnGuardar.Enabled = False
        btnCancelar.Enabled = True
        btnNuevo.Enabled = False
    End Sub

    Private Sub btnCliente_Click(sender As Object, e As EventArgs) Handles btnCliente.Click
        frmCliente.txtFlag.text = "1"
        frmCliente.MdiParent = Crónos
        frmCliente.Show()
    End Sub

    Private Sub btnEmpleado_Click(sender As Object, e As EventArgs) Handles btnEmpleado.Click
        frmEmpleado.txtFlag.Text = "8"
        frmEmpleado.MdiParent = Crónos
        frmEmpleado.Show()
    End Sub

    Private Sub Cargar_Datos()
        frmDetalleVenta.txtFolio.Text = dgvVenta.SelectedCells.Item(2).Value
        frmDetalleVenta.txtIdCliente.Text = dgvVenta.SelectedCells.Item(4).Value
        frmDetalleVenta.txtCliente.Text = dgvVenta.SelectedCells.Item(5).Value
        frmDetalleVenta.txtIdVendedor.Text = dgvVenta.SelectedCells.Item(7).Value
        frmDetalleVenta.txtVendedor.Text = dgvVenta.SelectedCells.Item(8).Value
        frmDetalleVenta.dtpFecha.Value = dgvVenta.SelectedCells.Item(3).Value
        frmDetalleVenta.txtTipo.Text = dgvVenta.SelectedCells.Item(6).Value
        frmDetalleVenta.MdiParent = Crónos
        frmDetalleVenta.Show()
    End Sub
    Private Sub dgvVenta_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvVenta.CellContentDoubleClick
        Cargar_Datos()
    End Sub
End Class