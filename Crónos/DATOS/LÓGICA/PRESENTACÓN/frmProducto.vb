Imports System.ComponentModel
Public Class frmProducto
    Private dt As New DataTable
    Dim func As New fProducto

    Private Sub Limpiar()
        txtIdProducto.Text = ""
        txtCodigo.Text = ""
        txtStock.Text = ""
        txtNombre.Text = ""
        txtIdModelo.Text = ""
        txtModelo.Text = ""
        txtIdCategoria.Text = ""
        txtCategoria.Text = ""
        txtIdProveedor.Text = ""
        txtProveedor.Text = ""
        txtPrecioVenta.Text = ""
        txtPrecioCompra.Text = ""
    End Sub

    Private Sub Activar()
        txtNombre.Enabled = True
        btnModelo.Enabled = True
        btnCategoria.Enabled = True
        btnProveedor.Enabled = True
        txtPrecioVenta.Enabled = True
        txtPrecioCompra.Enabled = True
    End Sub

    Private Sub Desactivar()
        txtNombre.Enabled = False
        btnModelo.Enabled = False
        btnCategoria.Enabled = False
        btnProveedor.Enabled = False
        txtPrecioVenta.Enabled = False
        txtPrecioCompra.Enabled = False
    End Sub

    Private Sub Ocultar_Columnas()
        dgvProductos.Columns(1).Visible = False
        dgvProductos.Columns(5).Visible = False
        dgvProductos.Columns(7).Visible = False
        dgvProductos.Columns(9).Visible = False
    End Sub

    Private Sub Mostrar()
        Try
            Dim funcion As New fProducto
            dt = funcion.Mostrar_Producto
            dgvProductos.Columns.Item("Eliminar").Visible = False

            If dt.Rows.Count <> 0 Then
                dgvProductos.DataSource = dt
                txtBuscado.Enabled = True
                dgvProductos.ColumnHeadersVisible = True
                llbInexistente.Visible = True
            Else
                dgvProductos.DataSource = Nothing
                txtBuscado.Enabled = False
                dgvProductos.ColumnHeadersVisible = False
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
                dgvProductos.DataSource = dv
                Ocultar_Columnas()
            Else
                llbInexistente.Visible = True
                dgvProductos.DataSource = Nothing
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
        codigo = Format(func.Generar_Producto, "0000")
        txtIdProducto.Text = Format(func.Generar_Producto)
        txtCodigo.Text = "CRONOSPROD" + codigo
        txtStock.Text = 0
        txtStock.Enabled = False
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Mostrar()
    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        Dim result As DialogResult
        result = MessageBox.Show("¿Realmente quiere modificar el registro?", "Modificando Registro", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)

        If result = DialogResult.OK Then
            If Me.ValidateChildren = True And txtIdProducto.Text <> 0 And txtCodigo.Text <> "" And txtNombre.Text <> "" And txtStock.Text <> "" And txtIdModelo.Text <> "" And txtIdCategoria.Text <> "" And txtIdProveedor.Text <> "" And txtPrecioVenta.Text <> "" And txtPrecioCompra.Text Then
                Try
                    Dim dts As New CProducto
                    Dim func As New fProducto

                    dts._idProducto = txtIdProducto.Text
                    dts._codigo = txtCodigo.Text
                    dts._nombre = txtNombre.Text
                    dts._stock = txtStock.Text
                    dts._idModelo = txtIdModelo.Text
                    dts._idCategoria = txtIdCategoria.Text
                    dts._idProveedor = txtIdProveedor.Text
                    dts._pVenta = txtPrecioVenta.Text
                    dts._pCompra = txtPrecioCompra.Text

                    If func.Modificar_Producto(dts) Then
                        MessageBox.Show("Producto modificado correctamente", "Modificando Registro", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Mostrar()
                        Limpiar()
                    Else
                        MessageBox.Show("Producto no modificado, intente de nuevo", "Modificando Registro", MessageBoxButtons.OK, MessageBoxIcon.Information)
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
        If Me.ValidateChildren = True And txtIdProducto.Text <> 0 And txtCodigo.Text <> "" And txtNombre.Text <> "" And txtStock.Text <> "" And txtIdModelo.Text <> "" And txtIdCategoria.Text <> "" And txtIdProveedor.Text <> "" And txtPrecioVenta.Text <> "" And txtPrecioCompra.Text Then
            Try
                Dim dts As New CProducto
                Dim func As New fProducto

                dts._codigo = txtCodigo.Text
                dts._nombre = txtNombre.Text
                dts._stock = txtStock.Text
                dts._idModelo = txtIdModelo.Text
                dts._idCategoria = txtIdCategoria.Text
                dts._idProveedor = txtIdProveedor.Text
                dts._pVenta = txtPrecioVenta.Text
                dts._pCompra = txtPrecioCompra.Text

                If func.Insertar_Prodcuto(dts) Then
                    MessageBox.Show("Producto registrado correctamente", "Guardando Registro", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Mostrar()
                    Limpiar()
                Else
                    MessageBox.Show("Producto no registrado, intente de nuevo", "Guardando Registro", MessageBoxButtons.OK, MessageBoxIcon.Information)
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

    Private Sub frmProducto_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
            Me.erpErrorIcono.SetError(sender, "Ingresa el Código del Producto, Dato Obligatorio")
        End If
    End Sub

    Private Sub txtStock_Validating(sender As Object, e As CancelEventArgs) Handles txtStock.Validating
        If DirectCast(sender, TextBox).Text.Length > 0 Then
            Me.erpErrorIcono.SetError(sender, "")
        Else
            Me.erpErrorIcono.SetError(sender, "Ingresa el Stick del Producto, Dato Obligatorio")
        End If
    End Sub

    Private Sub txtNombre_Validating(sender As Object, e As CancelEventArgs) Handles txtNombre.Validating
        If DirectCast(sender, TextBox).Text.Length > 0 Then
            Me.erpErrorIcono.SetError(sender, "")
        Else
            Me.erpErrorIcono.SetError(sender, "Ingresa el Nombre del Producto, Dato Obligatorio")
        End If
    End Sub

    Private Sub txtIdModelo_Validating(sender As Object, e As CancelEventArgs) Handles txtIdModelo.Validating
        If DirectCast(sender, TextBox).Text.Length > 0 Then
            Me.erpErrorIcono.SetError(sender, "")
        Else
            Me.erpErrorIcono.SetError(sender, "Ingresa el ID del Modelo del Producto, Dato Obligatorio")
        End If
    End Sub

    Private Sub txtIdCategoria_Validating(sender As Object, e As CancelEventArgs) Handles txtIdCategoria.Validating
        If DirectCast(sender, TextBox).Text.Length > 0 Then
            Me.erpErrorIcono.SetError(sender, "")
        Else
            Me.erpErrorIcono.SetError(sender, "Ingresa el ID del Categoría del Producto, Dato Obligatorio")
        End If
    End Sub

    Private Sub txtIdProveedor_Validating(sender As Object, e As CancelEventArgs) Handles txtIdProveedor.Validating
        If DirectCast(sender, TextBox).Text.Length > 0 Then
            Me.erpErrorIcono.SetError(sender, "")
        Else
            Me.erpErrorIcono.SetError(sender, "Ingresa el ID del Proveedor del Producto, Dato Obligatorio")
        End If
    End Sub

    Private Sub txtPrecioVenta_Validating(sender As Object, e As CancelEventArgs) Handles txtPrecioVenta.Validating
        If DirectCast(sender, TextBox).Text.Length > 0 Then
            Me.erpErrorIcono.SetError(sender, "")
        Else
            Me.erpErrorIcono.SetError(sender, "Ingresa el Precio de Venta del Producto, Dato Obligatorio")
        End If
    End Sub

    Private Sub txtPrecioCompra_Validating(sender As Object, e As CancelEventArgs) Handles txtPrecioCompra.Validating
        If DirectCast(sender, TextBox).Text.Length > 0 Then
            Me.erpErrorIcono.SetError(sender, "")
        Else
            Me.erpErrorIcono.SetError(sender, "Ingresa el Precio de Compra del Producto, Dato Obligatorio")
        End If
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Dim result As DialogResult
        result = MessageBox.Show("Realmente desea eliminar la información seleccionada", "Eliminación de Registro", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)

        If result = DialogResult.OK Then
            Try
                For Each row As DataGridViewRow In dgvProductos.Rows
                    Dim marcado As Boolean = Convert.ToBoolean(row.Cells("Eliminar").Value)

                    If marcado Then
                        Dim onekey As Integer = Convert.ToInt32(row.Cells("ID_Producto").Value)
                        Dim vdb As New CProducto
                        Dim func As New fProducto
                        vdb._idProducto = onekey

                        If func.Eliminar_Producto(vdb) Then
                        Else
                            MessageBox.Show("Producto no eliminado", "Eliminación de Registro", MessageBoxButtons.OK, MessageBoxIcon.Information)
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
            dgvProductos.Columns.Item("Eliminar").Visible = True
            btnEliminar.Visible = True
        Else
            dgvProductos.Columns.Item("Eliminar").Visible = False
            btnEliminar.Visible = False
        End If
    End Sub

    Private Sub dgvProductos_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvProductos.CellContentClick
        If e.ColumnIndex = Me.dgvProductos.Columns.Item("Eliminar").Index Then
            Dim chkcell As DataGridViewCheckBoxCell = Me.dgvProductos.Rows(e.RowIndex).Cells("Eliminar")
            chkcell.Value = Not chkcell.Value
        End If
    End Sub

    Private Sub dgvProductos_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvProductos.CellClick
        txtIdProducto.Text = dgvProductos.SelectedCells.Item(1).Value
        txtCodigo.Text = dgvProductos.SelectedCells.Item(2).Value
        txtStock.Text = dgvProductos.SelectedCells.Item(3).Value
        txtNombre.Text = dgvProductos.SelectedCells.Item(4).Value
        txtIdModelo.Text = dgvProductos.SelectedCells.Item(5).Value
        txtModelo.Text = dgvProductos.SelectedCells.Item(6).Value
        txtIdCategoria.Text = dgvProductos.SelectedCells.Item(7).Value
        txtCategoria.Text = dgvProductos.SelectedCells.Item(8).Value
        txtIdProveedor.Text = dgvProductos.SelectedCells.Item(9).Value
        txtProveedor.Text = dgvProductos.SelectedCells.Item(10).Value
        txtPrecioVenta.Text = dgvProductos.SelectedCells.Item(11).Value
        txtPrecioCompra.Text = dgvProductos.SelectedCells.Item(12).Value
        Activar()
        btnModificar.Enabled = True
        btnGuardar.Enabled = False
        btnCancelar.Enabled = True
        btnNuevo.Enabled = False
    End Sub

    Private Sub btnModelo_Click(sender As Object, e As EventArgs) Handles btnModelo.Click
        frmModelo.txtFlag.Text = "1"
        frmModelo.MdiParent = Crónos
        frmModelo.Show()
    End Sub

    Private Sub btnCategoria_Click(sender As Object, e As EventArgs) Handles btnCategoria.Click
        frmCategoria.txtFlag.Text = "1"
        frmCategoria.MdiParent = Crónos
        frmCategoria.Show()
    End Sub

    Private Sub btnProveedor_Click(sender As Object, e As EventArgs) Handles btnProveedor.Click
        frmProveedor.txtFlag.Text = "2"
        frmProveedor.MdiParent = Crónos
        frmProveedor.Show()
    End Sub

    Private Sub dgvProductos_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvProductos.CellDoubleClick
        If txtFlag.Text = "1" Then
            frmDetalleCompra.txtIdProducto.Text = dgvProductos.SelectedCells.Item(1).Value
            frmDetalleCompra.txtProducto.Text = dgvProductos.SelectedCells.Item(4).Value
            frmDetalleCompra.nudStock.Value = dgvProductos.SelectedCells.Item(3).Value
            frmDetalleCompra.txtPrecio.Text = dgvProductos.SelectedCells.Item(12).Value
            Me.Close()
        ElseIf txtFlag.Text = "2" Then
            frmDetalleVenta.txtIdProducto.Text = dgvProductos.SelectedCells.Item(1).Value
            frmDetalleVenta.txtProducto.Text = dgvProductos.SelectedCells.Item(4).Value
            frmDetalleVenta.nudStock.Value = dgvProductos.SelectedCells(3).Value
            frmDetalleVenta.txtPrecio.Text = dgvProductos.SelectedCells.Item(11).Value
            Me.Close()
        End If
    End Sub
End Class