Imports System.ComponentModel
Public Class frmCategoria
    Private dt As New DataTable
    Dim func As New fCategoria

    Private Sub Limpiar()
        txtIdCategoria.Text = ""
        txtCodigo.Text = ""
        txtCategoria.Text = ""
        txtDescripcion.Text = ""
    End Sub

    Private Sub Activar()
        txtCategoria.Enabled = True
        txtDescripcion.Enabled = True
    End Sub

    Private Sub Desactivar()
        txtCategoria.Enabled = False
        txtDescripcion.Enabled = False
    End Sub

    Private Sub Ocultar_Columnas()
        dgvCategoria.Columns(1).Visible = False
        dgvCategoria.Columns(4).Visible = False
    End Sub

    Private Sub Mostrar()
        Try
            Dim funcion As New fCategoria
            dt = funcion.Mostrar_Categoria
            dgvCategoria.Columns.Item("Eliminar").Visible = False

            If dt.Rows.Count <> 0 Then
                dgvCategoria.DataSource = dt
                txtBuscado.Enabled = True
                dgvCategoria.ColumnHeadersVisible = True
                llbInexistente.Visible = True
            Else
                dgvCategoria.DataSource = Nothing
                txtBuscado.Enabled = False
                dgvCategoria.ColumnHeadersVisible = False
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
                dgvCategoria.DataSource = dv
                Ocultar_Columnas()
            Else
                llbInexistente.Visible = True
                dgvCategoria.DataSource = Nothing
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub frmCategoria_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Mostrar()
        Limpiar()
        btnNuevo.Enabled = True
        btnSalir.Enabled = True
        btnGuardar.Enabled = False
        btnModificar.Enabled = False
        btnCancelar.Enabled = False
        Desactivar()
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        Limpiar()
        Activar()
        btnCancelar.Enabled = True
        btnGuardar.Enabled = True
        btnNuevo.Enabled = False
        btnModificar.Enabled = False
        Dim codigo As String
        codigo = Format(func.Generar_Categoria, "0000")
        txtIdCategoria.Text = Format(func.Generar_Categoria)
        txtCodigo.Text = "CRONOSCAT" + codigo
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Mostrar()
    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        Dim result As DialogResult
        result = MessageBox.Show("¿Realmente quiere modificar el registro?", "Modificando Registro", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)

        If result = DialogResult.OK Then
            If Me.ValidateChildren = True And txtIdCategoria.Text <> 0 And txtCodigo.Text <> "" And txtCategoria.Text <> "" And txtDescripcion.Text <> "" Then
                Try
                    Dim dts As New CCategoria
                    Dim func As New fCategoria

                    dts._idCategoria = txtIdCategoria.Text
                    dts._codigo = txtCodigo.Text
                    dts._categoria = txtCategoria.Text
                    dts._descripcion = txtDescripcion.Text

                    If func.Modificar_Categoria(dts) Then
                        MessageBox.Show("Categoría modificada correctamente", "Modificando Registro", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Mostrar()
                        Limpiar()
                    Else
                        MessageBox.Show("Categoría no modificada, intente de nuevo", "Modificando Registro", MessageBoxButtons.OK, MessageBoxIcon.Information)
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
        Desactivar()
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
        If Me.ValidateChildren = True And txtCodigo.Text <> "" And txtCategoria.Text <> "" And txtDescripcion.Text <> "" Then
            Try
                Dim dts As New CCategoria
                Dim func As New fCategoria

                dts._codigo = txtCodigo.Text
                dts._categoria = txtCategoria.Text
                dts._descripcion = txtDescripcion.Text

                If func.Insertar_Categoria(dts) Then
                    MessageBox.Show("Categoría registrada correctamente", "Guardando Registro", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Mostrar()
                    Limpiar()
                Else
                    MessageBox.Show("Categoría no registrada, intente de nuevo", "Guardando Registro", MessageBoxButtons.OK, MessageBoxIcon.Information)
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

    Private Sub txtCodigo_Validating(sender As Object, e As CancelEventArgs) Handles txtCodigo.Validating
        If DirectCast(sender, TextBox).Text.Length > 0 Then
            Me.erpErrorIcono.SetError(sender, "")
        Else
            Me.erpErrorIcono.SetError(sender, "Ingresa el Código del Categoría, Dato Obligatorio")
        End If
    End Sub

    Private Sub txtCategoria_Validating(sender As Object, e As CancelEventArgs) Handles txtCategoria.Validating
        If DirectCast(sender, TextBox).Text.Length > 0 Then
            Me.erpErrorIcono.SetError(sender, "")
        Else
            Me.erpErrorIcono.SetError(sender, "Ingresa la Categoría, Dato Obligatorio")
        End If
    End Sub

    Private Sub txtDescripcion_Validating(sender As Object, e As CancelEventArgs) Handles txtDescripcion.Validating
        If DirectCast(sender, TextBox).Text.Length > 0 Then
            Me.erpErrorIcono.SetError(sender, "")
        Else
            Me.erpErrorIcono.SetError(sender, "Ingresa la Descripción de la Categoría, Dato Obligatorio")
        End If
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Dim result As DialogResult
        result = MessageBox.Show("Realmente desea eliminar la información seleccionada", "Eliminación de Registro", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)

        If result = DialogResult.OK Then
            Try
                For Each row As DataGridViewRow In dgvCategoria.Rows
                    Dim marcado As Boolean = Convert.ToBoolean(row.Cells("Eliminar").Value)

                    If marcado Then
                        Dim onekey As Integer = Convert.ToInt32(row.Cells("ID_Categoria").Value)
                        Dim vdb As New CCategoria
                        Dim func As New fCategoria
                        vdb._idCategoria = onekey

                        If func.Eliminar_Categoria(vdb) Then
                        Else
                            MessageBox.Show("Categoría no eliminada", "Eliminación de Registro", MessageBoxButtons.OK, MessageBoxIcon.Information)
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
            dgvCategoria.Columns.Item("Eliminar").Visible = True
            btnEliminar.Visible = True
        Else
            dgvCategoria.Columns.Item("Eliminar").Visible = False
            btnEliminar.Visible = False
        End If
    End Sub

    Private Sub dgvCategoria_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCategoria.CellContentClick
        If e.ColumnIndex = Me.dgvCategoria.Columns.Item("Eliminar").Index Then
            Dim chkcell As DataGridViewCheckBoxCell = Me.dgvCategoria.Rows(e.RowIndex).Cells("Eliminar")
            chkcell.Value = Not chkcell.Value
        End If
    End Sub

    Private Sub dgvCategoria_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCategoria.CellClick
        txtIdCategoria.Text = dgvCategoria.SelectedCells.Item(1).Value
        txtCodigo.Text = dgvCategoria.SelectedCells.Item(2).Value
        txtCategoria.Text = dgvCategoria.SelectedCells.Item(3).Value
        txtDescripcion.Text = dgvCategoria.SelectedCells.Item(4).Value
        Activar()
        btnModificar.Enabled = True
        btnGuardar.Enabled = False
        btnCancelar.Enabled = True
        btnNuevo.Enabled = False
    End Sub

    Private Sub dgvCategoria_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCategoria.CellDoubleClick
        If txtFlag.Text = "1" Then
            frmProducto.txtIdCategoria.Text = dgvCategoria.SelectedCells.Item(1).Value
            frmProducto.txtCategoria.Text = dgvCategoria.SelectedCells.Item(3).Value
            Me.Close()
        End If
    End Sub

End Class