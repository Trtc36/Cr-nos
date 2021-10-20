Imports System.ComponentModel
Public Class frmCompra
    Private dt As New DataTable
    Dim func As New fCompra

    Private Sub Limpiar()
        txtIdCompra.Text = ""
        txtFolio.Text = ""
        dtpFecha.Value = Date.Today
        txtIdProveedor.Text = ""
        txtProveedor.Text = ""
        cmbtPago.Text = ""
        cmbtCompra.Text = ""
        txtIdAgente.Text = ""
        txtAgente.Text = ""
    End Sub

    Private Sub Activar()
        dtpFecha.Enabled = True
        cmbtPago.Enabled = True
        cmbtCompra.Enabled = True
        btnProveedor.Enabled = True
        btnAgente.Enabled = True
    End Sub

    Private Sub Desactivar()
        dtpFecha.Enabled = False
        cmbtPago.Enabled = False
        cmbtCompra.Enabled = False
        btnProveedor.Enabled = False
        btnAgente.Enabled = False
    End Sub

    Private Sub Ocultar_Columnas()
        dgvCompra.Columns(1).Visible = False
        dgvCompra.Columns(4).Visible = False
        dgvCompra.Columns(8).Visible = False
    End Sub

    Private Sub Mostrar()
        Try
            Dim funcion As New fCompra
            dt = funcion.Mostrar_Compra
            dgvCompra.Columns.Item("Eliminar").Visible = False

            If dt.Rows.Count <> 0 Then
                dgvCompra.DataSource = dt
                txtBuscado.Enabled = True
                dgvCompra.ColumnHeadersVisible = True
                llbInexistente.Visible = True
            Else
                dgvCompra.DataSource = Nothing
                txtBuscado.Enabled = False
                dgvCompra.ColumnHeadersVisible = False
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
                dgvCompra.DataSource = dv
                Ocultar_Columnas()
            Else
                llbInexistente.Visible = True
                dgvCompra.DataSource = Nothing
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
        codigo = Format(func.Generar_FCompra, "000000")
        txtIdCompra.Text = Format(func.Generar_FCompra)
        txtFolio.Text = "F - " + codigo
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Mostrar()
    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        Dim result As DialogResult
        result = MessageBox.Show("¿Realmente quiere modificar el registro?", "Modificando Registro", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)

        If result = DialogResult.OK Then
            If Me.ValidateChildren = True And txtIdCompra.Text <> 0 And txtFolio.Text <> "" And dtpFecha.Value <> Nothing And txtIdProveedor.Text <> "" And cmbtPago.Text <> "" And cmbtCompra.Text <> "" And txtIdAgente.Text <> "" Then
                Try
                    Dim dts As New CCompra
                    Dim func As New fCompra

                    dts._idCompra = txtIdCompra.Text
                    dts._folio = txtFolio.Text
                    dts._fecha = dtpFecha.Value
                    dts._idProveedor = txtIdProveedor.Text
                    dts._tPago = cmbtPago.Text
                    dts._tCompra = cmbtCompra.Text
                    dts._idAgente = txtIdAgente.Text

                    If func.Modificar_Compra(dts) Then
                        MessageBox.Show("Compra modificada correctamente", "Modificando Registro", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Mostrar()
                        Limpiar()
                    Else
                        MessageBox.Show("Compra no modificada, intente de nuevo", "Modificando Registro", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Mostrar()
                        Limpiar()
                    End If
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
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
        If Me.ValidateChildren = True And txtIdCompra.Text <> 0 And txtFolio.Text <> "" And dtpFecha.Value <> Nothing And txtIdProveedor.Text <> "" And cmbtPago.Text <> "" And cmbtCompra.Text <> "" And txtIdAgente.Text <> "" Then
            Try
                Dim dts As New CCompra
                Dim func As New fCompra

                dts._idCompra = txtIdCompra.Text
                dts._folio = txtFolio.Text
                dts._fecha = dtpFecha.Value
                dts._idProveedor = txtIdProveedor.Text
                dts._tPago = cmbtPago.Text
                dts._tCompra = cmbtCompra.Text
                dts._idAgente = txtIdAgente.Text

                If func.Insertar_Compra(dts) Then
                    MessageBox.Show("Compra registrada correctamente", "Guardando Registro", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Mostrar()
                    Limpiar()
                Else
                    MessageBox.Show("Compra no registrada, intente de nuevo", "Guardando Registro", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Mostrar()
                    Limpiar()
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Else
            MessageBox.Show("Faltan datos por ingresar", "Guardando Registro", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Close()
    End Sub

    Private Sub frmCompra_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
            Me.erpErrorIcono.SetError(sender, "Ingresa el Folio de la Compra, Dato Obligatorio")
        End If
    End Sub

    Private Sub dtpFecha_Validating(sender As Object, e As CancelEventArgs) Handles dtpFecha.Validating
        If DirectCast(sender, DateTimePicker).Value <> Nothing Then
            Me.erpErrorIcono.SetError(sender, "")
        Else
            Me.erpErrorIcono.SetError(sender, "Ingresa la Fecha de la Compra, Dato Obligatorio")
        End If
    End Sub

    Private Sub txtIdProveedor_Validating(sender As Object, e As CancelEventArgs) Handles txtIdProveedor.Validating
        If DirectCast(sender, TextBox).Text.Length > 0 Then
            Me.erpErrorIcono.SetError(sender, "")
        Else
            Me.erpErrorIcono.SetError(sender, "Ingresa ID del Proveedor de la Compra, Dato Obligatorio")
        End If
    End Sub

    Private Sub cmbtPago_Validating(sender As Object, e As CancelEventArgs) Handles cmbtPago.Validating
        If DirectCast(sender, ComboBox).Text.Length > 0 Then
            Me.erpErrorIcono.SetError(sender, "")
        Else
            Me.erpErrorIcono.SetError(sender, "Ingresa el Tipo de Pago de la Compra, Dato Obligatorio")
        End If
    End Sub

    Private Sub cmbtCompra_Validating(sender As Object, e As CancelEventArgs) Handles cmbtCompra.Validating
        If DirectCast(sender, ComboBox).Text.Length > 0 Then
            Me.erpErrorIcono.SetError(sender, "")
        Else
            Me.erpErrorIcono.SetError(sender, "Ingresa el Tipo de la Compra, Dato Obligatorio")
        End If
    End Sub

    Private Sub txtIdAgente_Validating(sender As Object, e As CancelEventArgs) Handles txtIdAgente.Validating
        If DirectCast(sender, TextBox).Text.Length > 0 Then
            Me.erpErrorIcono.SetError(sender, "")
        Else
            Me.erpErrorIcono.SetError(sender, "Ingresa el ID del Agente de la Compra, Dato Obligatorio")
        End If
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Dim result As DialogResult
        result = MessageBox.Show("Realmente desea eliminar la información seleccionada", "Eliminación de Registro", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)

        If result = DialogResult.OK Then
            Try
                For Each row As DataGridViewRow In dgvCompra.Rows
                    Dim marcado As Boolean = Convert.ToBoolean(row.Cells("Eliminar").Value)

                    If marcado Then
                        Dim onekey As Integer = Convert.ToInt32(row.Cells("ID_Compras").Value)
                        Dim vdb As New CCompra
                        Dim func As New fCompra
                        vdb._idCompra = onekey

                        If func.Eliminar_Compra(vdb) Then
                        Else
                            MessageBox.Show("Compra no eliminada", "Eliminación de Registro", MessageBoxButtons.OK, MessageBoxIcon.Information)
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
            dgvCompra.Columns.Item("Eliminar").Visible = True
            btnEliminar.Visible = True
        Else
            dgvCompra.Columns.Item("Eliminar").Visible = False
            btnEliminar.Visible = False
        End If
    End Sub

    Private Sub dgvCompra_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCompra.CellContentClick
        If e.ColumnIndex = Me.dgvCompra.Columns.Item("Eliminar").Index Then
            Dim chkcell As DataGridViewCheckBoxCell = Me.dgvCompra.Rows(e.RowIndex).Cells("Eliminar")
            chkcell.Value = Not chkcell.Value
        End If
    End Sub

    Private Sub dgvCompra_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCompra.CellClick
        txtIdCompra.Text = dgvCompra.SelectedCells.Item(1).Value
        txtFolio.Text = dgvCompra.SelectedCells.Item(2).Value
        dtpFecha.Value = dgvCompra.SelectedCells.Item(3).Value
        txtIdProveedor.Text = dgvCompra.SelectedCells.Item(4).Value
        txtProveedor.Text = dgvCompra.SelectedCells.Item(5).Value
        cmbtPago.Text = dgvCompra.SelectedCells.Item(6).Value
        cmbtCompra.Text = dgvCompra.SelectedCells.Item(7).Value
        txtIdAgente.Text = dgvCompra.SelectedCells.Item(8).Value
        txtAgente.Text = dgvCompra.SelectedCells.Item(9).Value
        Activar()
        btnModificar.Enabled = True
        btnGuardar.Enabled = False
        btnCancelar.Enabled = True
        btnNuevo.Enabled = False
    End Sub

    Private Sub btnProveedor_Click(sender As Object, e As EventArgs) Handles btnProveedor.Click
        frmProveedor.txtFlag.Text = "3"
        frmProveedor.MdiParent = Crónos
        frmProveedor.Show()
    End Sub

    Private Sub btnAgente_Click(sender As Object, e As EventArgs) Handles btnAgente.Click
        frmAgente.txtFlag.Text = "1"
        frmAgente.MdiParent = Crónos
        frmAgente.Show()
    End Sub

    Private Sub Cargar_Detalle()
        frmDetalleCompra.txtFolio.Text = dgvCompra.SelectedCells.Item(2).Value
        frmDetalleCompra.dtpFecha.Value = dgvCompra.SelectedCells.Item(3).Value
        frmDetalleCompra.txtIdProveedor.Text = dgvCompra.SelectedCells.Item(4).Value
        frmDetalleCompra.txtIdAgente.Text = dgvCompra.SelectedCells.Item(8).Value
        frmDetalleCompra.txtProveedor.Text = dgvCompra.SelectedCells.Item(5).Value
        frmDetalleCompra.txtAgente.Text = dgvCompra.SelectedCells.Item(9).Value
        frmDetalleCompra.MdiParent = Crónos
        frmDetalleCompra.Show()
    End Sub

    Private Sub dgvCompra_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCompra.CellContentDoubleClick
        Cargar_Detalle()
    End Sub
End Class