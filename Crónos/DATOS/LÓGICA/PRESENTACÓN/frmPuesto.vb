Imports System.ComponentModel
Public Class frmPuesto
    Private dt As New DataTable
    Dim func As New fPuesto

    Private Sub Limpiar()
        txtIdPuesto.Text = ""
        txtCodigo.Text = ""
        txtPuesto.Text = ""
        txtDescripcion.Text = ""
        txtResponsabilidades.Text = ""
        txtObligaciones.Text = ""
        txtSAutorizado.Text = ""
    End Sub

    Private Sub Activar()
        txtPuesto.Enabled = True
        txtDescripcion.Enabled = True
        txtResponsabilidades.Enabled = True
        txtObligaciones.Enabled = True
        txtSAutorizado.Enabled = True
    End Sub

    Private Sub Desactivar()
        txtPuesto.Enabled = False
        txtDescripcion.Enabled = False
        txtResponsabilidades.Enabled = False
        txtObligaciones.Enabled = False
        txtSAutorizado.Enabled = False
    End Sub

    Private Sub Ocultar_Columnas()
        dgvPuesto.Columns(1).Visible = False
        dgvPuesto.Columns(4).Visible = False
        dgvPuesto.Columns(5).Visible = False
        dgvPuesto.Columns(6).Visible = False
    End Sub

    Private Sub Mostrar()
        Try
            Dim funcion As New fPuesto
            dt = funcion.Mostrar_Puesto
            dgvPuesto.Columns.Item("Eliminar").Visible = False

            If dt.Rows.Count <> 0 Then
                dgvPuesto.DataSource = dt
                txtBuscado.Enabled = True
                dgvPuesto.ColumnHeadersVisible = True
                llbInexistente.Visible = True
            Else
                dgvPuesto.DataSource = Nothing
                txtBuscado.Enabled = False
                dgvPuesto.ColumnHeadersVisible = False
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
                dgvPuesto.DataSource = dv
                Ocultar_Columnas()
            Else
                llbInexistente.Visible = True
                dgvPuesto.DataSource = Nothing
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub dgvPuesto_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvPuesto.CellDoubleClick
        If txtFlag.Text = "1" Then
            frmEmpleado.txtIdPuesto.Text = dgvPuesto.SelectedCells.Item(1).Value
            frmEmpleado.txtPuesto.Text = dgvPuesto.SelectedCells.Item(3).Value
            Me.Close()
        End If
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        Limpiar()
        Activar()
        btnCancelar.Enabled = True
        btnGuardar.Enabled = True
        btnNuevo.Enabled = False
        btnModificar.Enabled = False
        Dim codigo As String
        codigo = Format(func.Generar_Puesto, "0000")
        txtIdPuesto.Text = Format(func.Generar_Puesto)
        txtCodigo.Text = "CRONOSPUE" + codigo
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Mostrar()
    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        Dim result As DialogResult
        result = MessageBox.Show("¿Realmente quiere modificar el registro?", "Modificando Registro", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)

        If result = DialogResult.OK Then
            If Me.ValidateChildren = True And txtIdPuesto.Text <> 0 And txtCodigo.Text <> "" And txtPuesto.Text <> "" And txtDescripcion.Text <> "" And txtResponsabilidades.Text <> "" And txtObligaciones.Text <> "" And txtSAutorizado.Text <> "" Then
                Try
                    Dim dts As New CPuesto
                    Dim func As New fPuesto

                    dts._idPuesto = txtIdPuesto.Text
                    dts._codigo = txtCodigo.Text
                    dts._puesto = txtPuesto.Text
                    dts._descripcion = txtDescripcion.Text
                    dts._responsabilidades = txtResponsabilidades.Text
                    dts._obligaciones = txtObligaciones.Text
                    dts._sAutorizado = txtSAutorizado.Text

                    If func.Modificar_Puesto(dts) Then
                        MessageBox.Show("Puesto modificado correctamente", "Modificando Registro", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Mostrar()
                        Limpiar()
                    Else
                        MessageBox.Show("Pusto no modificado, intente de nuevo", "Modificando Registro", MessageBoxButtons.OK, MessageBoxIcon.Information)
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
        If Me.ValidateChildren = True And txtIdPuesto.Text <> 0 And txtCodigo.Text <> "" And txtPuesto.Text <> "" And txtDescripcion.Text <> "" And txtResponsabilidades.Text <> "" And txtObligaciones.Text <> "" And txtSAutorizado.Text <> "" Then
            Try
                Dim dts As New CPuesto
                Dim func As New fPuesto


                dts._codigo = txtCodigo.Text
                dts._puesto = txtPuesto.Text
                dts._descripcion = txtDescripcion.Text
                dts._responsabilidades = txtResponsabilidades.Text
                dts._obligaciones = txtObligaciones.Text
                dts._sAutorizado = txtSAutorizado.Text

                If func.Insertar_Puesto(dts) Then
                    MessageBox.Show("Puesto registrado correctamente", "Guardando Registro", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Mostrar()
                    Limpiar()
                Else
                    MessageBox.Show("Puesto no registrado, intente de nuevo", "Guardando Registro", MessageBoxButtons.OK, MessageBoxIcon.Information)
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

    Private Sub frmPuesto_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
            Me.erpErrorIcono.SetError(sender, "Ingresa el Código del Puesto, Dato Obligatorio")
        End If
    End Sub

    Private Sub txtPuesto_Validating(sender As Object, e As CancelEventArgs) Handles txtPuesto.Validating
        If DirectCast(sender, TextBox).Text.Length > 0 Then
            Me.erpErrorIcono.SetError(sender, "")
        Else
            Me.erpErrorIcono.SetError(sender, "Ingresa el Nombre del Puesto, Dato Obligatorio")
        End If
    End Sub

    Private Sub txtDescripcion_Validating(sender As Object, e As CancelEventArgs) Handles txtDescripcion.Validating
        If DirectCast(sender, TextBox).Text.Length > 0 Then
            Me.erpErrorIcono.SetError(sender, "")
        Else
            Me.erpErrorIcono.SetError(sender, "Ingresa la Descripción del Puesto, Dato Obligatorio")
        End If
    End Sub

    Private Sub txtResponsabilidades_Validating(sender As Object, e As CancelEventArgs) Handles txtResponsabilidades.Validating
        If DirectCast(sender, TextBox).Text.Length > 0 Then
            Me.erpErrorIcono.SetError(sender, "")
        Else
            Me.erpErrorIcono.SetError(sender, "Ingresa las Responsabilidades del Puesto, Dato Obligatorio")
        End If
    End Sub

    Private Sub txtObligaciones_Validating(sender As Object, e As CancelEventArgs) Handles txtObligaciones.Validating
        If DirectCast(sender, TextBox).Text.Length > 0 Then
            Me.erpErrorIcono.SetError(sender, "")
        Else
            Me.erpErrorIcono.SetError(sender, "Ingresa las Obligaciones del Puesto, Dato Obligatorio")
        End If
    End Sub

    Private Sub txtSAutorizado_Validating(sender As Object, e As CancelEventArgs) Handles txtSAutorizado.Validating
        If DirectCast(sender, TextBox).Text.Length > 0 Then
            Me.erpErrorIcono.SetError(sender, "")
        Else
            Me.erpErrorIcono.SetError(sender, "Ingresa el Sueldo Autorizado del Puesto, Dato Obligatorio")
        End If
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Dim result As DialogResult
        result = MessageBox.Show("Realmente desea eliminar la información seleccionada", "Eliminación de Registro", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)

        If result = DialogResult.OK Then
            Try
                For Each row As DataGridViewRow In dgvPuesto.Rows
                    Dim marcado As Boolean = Convert.ToBoolean(row.Cells("Eliminar").Value)

                    If marcado Then
                        Dim onekey As Integer = Convert.ToInt32(row.Cells("ID_Puesto").Value)
                        Dim vdb As New CPuesto
                        Dim func As New fPuesto
                        vdb._idPuesto = onekey

                        If func.Eliminar_Puesto(vdb) Then
                        Else
                            MessageBox.Show("Puesto no eliminado", "Eliminación de Registro", MessageBoxButtons.OK, MessageBoxIcon.Information)
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
            dgvPuesto.Columns.Item("Eliminar").Visible = True
            btnEliminar.Visible = True
        Else
            dgvPuesto.Columns.Item("Eliminar").Visible = False
            btnEliminar.Visible = False
        End If
    End Sub

    Private Sub dgvPuesto_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvPuesto.CellContentClick
        If e.ColumnIndex = Me.dgvPuesto.Columns.Item("Eliminar").Index Then
            Dim chkcell As DataGridViewCheckBoxCell = Me.dgvPuesto.Rows(e.RowIndex).Cells("Eliminar")
            chkcell.Value = Not chkcell.Value
        End If
    End Sub

    Private Sub dgvPuesto_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvPuesto.CellClick
        txtIdPuesto.Text = dgvPuesto.SelectedCells.Item(1).Value
        txtCodigo.Text = dgvPuesto.SelectedCells.Item(2).Value
        txtPuesto.Text = dgvPuesto.SelectedCells.Item(3).Value
        txtDescripcion.Text = dgvPuesto.SelectedCells.Item(4).Value
        txtResponsabilidades.Text = dgvPuesto.SelectedCells.Item(5).Value
        txtObligaciones.Text = dgvPuesto.SelectedCells.Item(6).Value
        txtSAutorizado.Text = dgvPuesto.SelectedCells.Item(7).Value
        Activar()
        btnModificar.Enabled = True
        btnGuardar.Enabled = False
        btnCancelar.Enabled = True
        btnNuevo.Enabled = False
    End Sub
End Class