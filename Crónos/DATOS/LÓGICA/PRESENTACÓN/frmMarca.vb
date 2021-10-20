Imports System.ComponentModel
Public Class frmMarca
    Private dt As New DataTable
    Dim func As New fMarca

    Private Sub Limpiar()
        txtIdMarca.Text = ""
        txtCodigo.Text = ""
        txtMarca.Text = ""
        txtDescripcion.Text = ""
    End Sub

    Private Sub Activar()
        txtMarca.Enabled = True
        txtDescripcion.Enabled = True
    End Sub

    Private Sub Desactivar()
        txtMarca.Enabled = False
        txtDescripcion.Enabled = False
    End Sub

    Private Sub Ocultar_Columnas()
        dgvMarcas.Columns(1).Visible = False
        dgvMarcas.Columns(4).Visible = False
    End Sub

    Private Sub Mostrar()
        Try
            Dim funcion As New fMarca
            dt = funcion.Mostrar_Marca
            dgvMarcas.Columns.Item("Eliminar").Visible = False

            If dt.Rows.Count <> 0 Then
                dgvMarcas.DataSource = dt
                txtBuscado.Enabled = True
                dgvMarcas.ColumnHeadersVisible = True
                llbInexistente.Visible = True
            Else
                dgvMarcas.DataSource = Nothing
                txtBuscado.Enabled = False
                dgvMarcas.ColumnHeadersVisible = False
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
                dgvMarcas.DataSource = dv
                Ocultar_Columnas()
            Else
                llbInexistente.Visible = True
                dgvMarcas.DataSource = Nothing
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
        codigo = Format(func.Generar_Marca, "0000")
        txtIdMarca.Text = Format(func.Generar_Marca)
        txtCodigo.Text = "CRONOSMAR" + codigo
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Mostrar()
    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        Dim result As DialogResult
        result = MessageBox.Show("¿Realmente quiere modificar el registro?", "Modificando Registro", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)

        If result = DialogResult.OK Then
            If Me.ValidateChildren = True And txtIdMarca.Text <> 0 And txtCodigo.Text <> "" And txtMarca.Text <> "" And txtDescripcion.Text <> "" Then
                Try
                    Dim dts As New CMarca
                    Dim func As New fMarca

                    dts._idMarca = txtIdMarca.Text
                    dts._codigo = txtCodigo.Text
                    dts._marca = txtMarca.Text
                    dts._descripcion = txtDescripcion.Text

                    If func.Modificar_Marca(dts) Then
                        MessageBox.Show("Marca modificada correctamente", "Modificando Registro", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Mostrar()
                        Limpiar()
                    Else
                        MessageBox.Show("Marca no modificada, intente de nuevo", "Modificando Registro", MessageBoxButtons.OK, MessageBoxIcon.Information)
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
        If Me.ValidateChildren = True And txtCodigo.Text <> "" And txtMarca.Text <> "" And txtDescripcion.Text <> "" Then
            Try
                Dim dts As New CMarca
                Dim func As New fMarca

                dts._codigo = txtCodigo.Text
                dts._marca = txtMarca.Text
                dts._descripcion = txtDescripcion.Text

                If func.Insertar_Marca(dts) Then
                    MessageBox.Show("Marca registrada correctamente", "Guardando Registro", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Mostrar()
                    Limpiar()
                Else
                    MessageBox.Show("Marca no registrada, intente de nuevo", "Guardando Registro", MessageBoxButtons.OK, MessageBoxIcon.Information)
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

    Private Sub frmMarca_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
            Me.erpErrorIcono.SetError(sender, "Ingresa el Código de la Marca, Dato Obligatorio")
        End If
    End Sub

    Private Sub txtMarca_Validating(sender As Object, e As CancelEventArgs) Handles txtMarca.Validating
        If DirectCast(sender, TextBox).Text.Length > 0 Then
            Me.erpErrorIcono.SetError(sender, "")
        Else
            Me.erpErrorIcono.SetError(sender, "Ingresa el Nombre de la Marca, Dato Obligatorio")
        End If
    End Sub

    Private Sub txtDescripcion_Validating(sender As Object, e As CancelEventArgs) Handles txtDescripcion.Validating
        If DirectCast(sender, TextBox).Text.Length > 0 Then
            Me.erpErrorIcono.SetError(sender, "")
        Else
            Me.erpErrorIcono.SetError(sender, "Ingresa la Descripción de la Marca, Dato Obligatorio")
        End If
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Dim result As DialogResult
        result = MessageBox.Show("Realmente desea eliminar la información seleccionada", "Eliminación de Registro", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)

        If result = DialogResult.OK Then
            Try
                For Each row As DataGridViewRow In dgvMarcas.Rows
                    Dim marcado As Boolean = Convert.ToBoolean(row.Cells("Eliminar").Value)

                    If marcado Then
                        Dim onekey As Integer = Convert.ToInt32(row.Cells("ID_Marca").Value)
                        Dim vdb As New CMarca
                        Dim func As New fMarca
                        vdb._idMarca = onekey

                        If func.Eliminar_Marca(vdb) Then
                        Else
                            MessageBox.Show("Marca no eliminada", "Eliminación de Registro", MessageBoxButtons.OK, MessageBoxIcon.Information)
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
            dgvMarcas.Columns.Item("Eliminar").Visible = True
            btnEliminar.Visible = True
        Else
            dgvMarcas.Columns.Item("Eliminar").Visible = False
            btnEliminar.Visible = False
        End If
    End Sub

    Private Sub dgvMarcas_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvMarcas.CellContentClick
        If e.ColumnIndex = Me.dgvMarcas.Columns.Item("Eliminar").Index Then
            Dim chkcell As DataGridViewCheckBoxCell = Me.dgvMarcas.Rows(e.RowIndex).Cells("Eliminar")
            chkcell.Value = Not chkcell.Value
        End If
    End Sub

    Private Sub dgvMarcas_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvMarcas.CellClick
        txtIdMarca.Text = dgvMarcas.SelectedCells.Item(1).Value
        txtCodigo.Text = dgvMarcas.SelectedCells.Item(2).Value
        txtMarca.Text = dgvMarcas.SelectedCells.Item(3).Value
        txtDescripcion.Text = dgvMarcas.SelectedCells.Item(4).Value
        Activar()
        btnModificar.Enabled = True
        btnGuardar.Enabled = False
        btnCancelar.Enabled = True
        btnNuevo.Enabled = False
    End Sub

    Private Sub dgvMarcas_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvMarcas.CellDoubleClick
        If txtFlag.Text = "1" Then
            frmModelo.txtIdMarca.Text = dgvMarcas.SelectedCells.Item(1).Value
            frmModelo.txtMarca.Text = dgvMarcas.SelectedCells.Item(3).Value
            Me.Close()
        End If
    End Sub
End Class