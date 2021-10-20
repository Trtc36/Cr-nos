Public Class frmDetalleCompra
    Private dt As New DataTable
    Public Sub Limpiar()
        txtIdProducto.Text = ""
        txtProducto.Text = ""
        nudCantidad.Value = 0
        nudStock.Value = 0
    End Sub

    Public Sub Activar()
        btnProducto.Enabled = True
        nudCantidad.Enabled = True
    End Sub

    Public Sub Desactivar()
        btnProducto.Enabled = False
        nudCantidad.Enabled = False
    End Sub
    Private Sub Ocultar_Columnas()
        dgvDCompras.Columns(1).Visible = False
        dgvDCompras.Columns(3).Visible = False
    End Sub

    Private Sub Mostrar()
        Try
            Dim funcion As New fDCompra
            dt = funcion.Mostrar_DCompra
            dgvDCompras.Columns.Item("Eliminar").Visible = False

            If dt.Rows.Count <> 0 Then
                dgvDCompras.DataSource = dt
                dgvDCompras.ColumnHeadersVisible = True
                llbInexistente.Visible = False
            Else
                dgvDCompras.DataSource = Nothing
                dgvDCompras.ColumnHeadersVisible = False
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
                dgvDCompras.DataSource = dv
                Ocultar_Columnas()
            Else
                llbInexistente.Visible = True
                dgvDCompras.DataSource = Nothing
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
        Limpiar()
        Desactivar()
        btnNuevo.Enabled = True
        btnAgregar.Enabled = False
        btnImprimir.Enabled = False
        btnCancelar.Enabled = False
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        If Me.ValidateChildren = True And txtIdProducto.Text <> "" And txtFolio.Text <> "" And nudCantidad.Text <> "" And txtPrecio.Text <> "" Then
            Try
                Dim dts As New CDCompra
                Dim func As New fDCompra

                dts._folio = txtFolio.Text
                dts._idProducto = txtIdProducto.Text
                dts._cantidad = nudCantidad.Value
                dts._pCompra = txtPrecio.Text

                If func.Insertar_DCompra(dts) Then
                    If func.Aumentar_Stock(dts) Then
                        dts._idProducto = txtIdProducto.Text
                        dts._cantidad = nudCantidad.Text
                        nudStock.Value = nudStock.Value + nudCantidad.Value
                    End If
                    MessageBox.Show("Producto fue añadido correctamente a la Compra", "Guardando Registro", MessageBoxButtons.OK, MessageBoxIcon.Information)
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

    Private Sub frmDetalleCompra_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Mostrar()
        Limpiar()
        btnNuevo.Enabled = True
        btnAgregar.Enabled = False
        btnCancelar.Enabled = False
        Desactivar()
    End Sub

    Private Sub chbEliminar_CheckedChanged(sender As Object, e As EventArgs) Handles chbEliminar.CheckedChanged
        If chbEliminar.CheckState = CheckState.Checked Then
            dgvDCompras.Columns.Item("Eliminar").Visible = True
            btnQuitar.Visible = True
        Else
            dgvDCompras.Columns.Item("Eliminar").Visible = False
            btnQuitar.Visible = False
        End If
    End Sub

    Private Sub dgvDCompras_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDCompras.CellContentClick
        If e.ColumnIndex = Me.dgvDCompras.Columns.Item("Eliminar").Index Then
            Dim chkcell As DataGridViewCheckBoxCell = Me.dgvDCompras.Rows(e.RowIndex).Cells("Eliminar")
            chkcell.Value = Not chkcell.Value
        End If
    End Sub

    Private Sub btnQuitar_Click(sender As Object, e As EventArgs) Handles btnQuitar.Click
        Dim result As DialogResult
        result = MessageBox.Show("Realmente desea eliminar el producto de la venta", "Eliminar Registro", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)

        If result = DialogResult.OK Then
            Try
                For Each row As DataGridViewRow In dgvDCompras.Rows
                    Dim marcado As Boolean = Convert.ToBoolean(row.Cells("Eliminar").Value)

                    If marcado Then
                        Dim onekey As Integer = Convert.ToInt32(row.Cells("ID_DCompra").Value)
                        Dim vdb As New CDCompra
                        Dim func As New fDCompra
                        vdb._idDCompra = onekey
                        vdb._folio = dgvDCompras.SelectedCells.Item(2).Value
                        vdb._idProducto = dgvDCompras.SelectedCells.Item(3).Value
                        vdb._cantidad = dgvDCompras.SelectedCells.Item(5).Value
                        vdb._pCompra = dgvDCompras.SelectedCells.Item(6).Value



                        If func.Eliminar_DCompra(vdb) Then
                            If func.Disminuir_Stock(vdb) Then
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
        frmProducto.txtFlag.Text = "1"
        frmProducto.MdiParent = Crónos
        frmProducto.Show()
    End Sub

End Class