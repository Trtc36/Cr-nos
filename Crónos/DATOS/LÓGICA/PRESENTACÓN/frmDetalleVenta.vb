Public Class frmDetalleVenta
    Private dt As New DataTable

    Private Sub Limpiar()
        txtIdProducto.Text = ""
        txtProducto.Text = ""
        txtPrecio.Text = ""
        nudCantidad.Value = 0
        nudStock.Value = 0
    End Sub

    Private Sub Activar()
        btnProducto.Enabled = True
        nudCantidad.Enabled = True
    End Sub

    Private Sub Desactivar()
        btnProducto.Enabled = False
        nudCantidad.Enabled = False
    End Sub
    Private Sub Ocultar_Columnas()
        dgvDVentas.Columns(1).Visible = False
        dgvDVentas.Columns(3).Visible = False
    End Sub

    Private Sub Mostrar()
        Try
            Dim funcion As New fDVenta
            dt = funcion.Mostrar_DVenta
            dgvDVentas.Columns.Item("Eliminar").Visible = False

            If dt.Rows.Count <> 0 Then
                dgvDVentas.DataSource = dt
                dgvDVentas.ColumnHeadersVisible = True
                llbInexistente.Visible = False
                Ocultar_Columnas()
            Else
                dgvDVentas.DataSource = Nothing
                dgvDVentas.ColumnHeadersVisible = False
                llbInexistente.Visible = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        btnNuevo.Enabled = True
        btnAgregar.Enabled = False
        btnCancelar.Enabled = False
        Buscar()
    End Sub

    Private Sub Buscar()
        Try
            Dim ds As New DataSet
            ds.Tables.Add(dt.Copy)
            Dim dv As New DataView(ds.Tables(0))

            dv.RowFilter = "Folio='" & txtFolio.Text & "'"
            If dv.Count <> 0 Then
                llbInexistente.Visible = False
                dgvDVentas.DataSource = dv
            Else
                llbInexistente.Visible = True
                dgvDVentas.DataSource = Nothing
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        Limpiar()
        Activar()
        btnAgregar.Enabled = True
        btnCancelar.Enabled = True
        btnNuevo.Enabled = False
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Close()
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        If Me.ValidateChildren = True And txtFolio.Text <> "" And txtIdProducto.Text <> "" And nudCantidad.Text <> 0 And txtPrecio.Text <> "" Then
            Try
                Dim dts As New CDVenta
                Dim func As New fDVenta

                dts._folio = txtFolio.Text
                dts._idProducto = txtIdProducto.Text
                dts._cantidad = nudCantidad.Value
                dts._pVenta = txtPrecio.Text

                If func.Insertar_DVenta(dts) Then
                    If func.Disminuir_Stock(dts) Then
                        dts._idProducto = txtIdProducto.Text
                        dts._cantidad = nudCantidad.Value
                        nudStock.Value = nudStock.Value - nudCantidad.Value
                    End If
                    MessageBox.Show("Producto fue añadido correctamente a la venta", "Guardando Registro", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Mostrar()
                    Limpiar()
                Else
                    MessageBox.Show("Producto no añadido, intente de nuevo", "Guardando Registro", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Mostrar()
                    Limpiar()
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Else
            MessageBox.Show("Faltan datos por ingresar", "Guardando Registro", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

        Limpiar()
        Desactivar()
        btnNuevo.Enabled = True
        btnAgregar.Enabled = False
        btnCancelar.Enabled = False
    End Sub

    Private Sub frmDetalleVenta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Mostrar()
        Limpiar()
        btnNuevo.Enabled = True
        btnAgregar.Enabled = False
        btnCancelar.Enabled = False
        Desactivar()
    End Sub

    Private Sub chbEliminar_CheckedChanged(sender As Object, e As EventArgs) Handles chbEliminar.CheckedChanged
        If chbEliminar.CheckState = CheckState.Checked Then
            dgvDVentas.Columns.Item("Eliminar").Visible = True
        Else
            dgvDVentas.Columns.Item("Eliminar").Visible = False
        End If
    End Sub

    Private Sub dgvDVentas_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDVentas.CellContentClick
        If e.ColumnIndex = Me.dgvDVentas.Columns.Item("Eliminar").Index Then
            Dim chkcell As DataGridViewCheckBoxCell = Me.dgvDVentas.Rows(e.RowIndex).Cells("Eliminar")
            chkcell.Value = Not chkcell.Value
        End If
    End Sub

    Private Sub btnQuitar_Click(sender As Object, e As EventArgs) Handles btnQuitar.Click
        Dim result As DialogResult
        result = MessageBox.Show("Realmente desea eliminar el Producto de la venta", "Eliminar Registro", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)

        If result = DialogResult.OK Then
            Try
                For Each row As DataGridViewRow In dgvDVentas.Rows
                    Dim marcado As Boolean = Convert.ToBoolean(row.Cells("Eliminar").Value)

                    If marcado Then
                        Dim onekey As Integer = Convert.ToInt32(row.Cells("ID_DVenta").Value)
                        Dim vdb As New CDVenta
                        Dim func As New fDVenta
                        vdb._idDVenta = onekey
                        vdb._folio = dgvDVentas.SelectedCells.Item(2).Value
                        vdb._idProducto = dgvDVentas.SelectedCells.Item(3).Value
                        vdb._cantidad = dgvDVentas.SelectedCells.Item(5).Value
                        vdb._pVenta = dgvDVentas.SelectedCells.Item(6).Value




                        If func.Eliminar_DVenta(vdb) Then
                            If func.Aumentar_Stock(vdb) Then
                                nudStock.Value = nudStock.Value + nudCantidad.Value
                            End If
                        Else
                            MessageBox.Show("Producto eliminado de la venta", "Eliminar Registro", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                    End If
                Next
                Call Mostrar()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Else
            MessageBox.Show("Cancelando eliminación de registro", "Eliminar Registro", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Mostrar()
        End If
        Limpiar()
    End Sub

    Private Sub btnProducto_Click(sender As Object, e As EventArgs) Handles btnProducto.Click
        frmProducto.txtFlag.Text = "2"
        frmProducto.MdiParent = Crónos
        frmProducto.Show()
    End Sub

    Private Sub nudCantidad_ValueChanged(sender As Object, e As EventArgs) Handles nudCantidad.ValueChanged
        Dim Cantidad As Double
        Cantidad = nudCantidad.Value

        If nudCantidad.Value > nudStock.Value Then
            MessageBox.Show("La cantidad a vender supera Stock", "Error al vender el producto", MessageBoxButtons.OK, MessageBoxIcon.Information)
            btnAgregar.Visible = False
            nudCantidad.Value = nudStock.Value
        Else
            btnAgregar.Visible = True
        End If
    End Sub

    
End Class