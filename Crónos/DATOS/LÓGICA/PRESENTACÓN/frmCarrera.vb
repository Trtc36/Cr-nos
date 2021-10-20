Imports System.ComponentModel
Public Class frmCarrera
    Private dt As New DataTable
    Dim func As New fCarrera

    Private Sub Limpiar()
        txtIdCarrera.Text = ""
        txtCodigo.Text = ""
        txtCarrera.Text = ""
        cmbNivel.Text = ""
    End Sub

    Private Sub Activar()
        txtCarrera.Enabled = True
        cmbNivel.Enabled = True
    End Sub

    Private Sub Desactivar()
        txtCarrera.Enabled = False
        cmbNivel.Enabled = False
    End Sub

    Private Sub Ocultar_Columnas()
        dgvCarrera.Columns(1).Visible = False
    End Sub

    Private Sub Mostrar()
        Try
            Dim funcion As New fCarrera
            dt = funcion.Mostrar_Carrera
            dgvCarrera.Columns.Item("Eliminar").Visible = False

            If dt.Rows.Count <> 0 Then
                dgvCarrera.DataSource = dt
                txtBuscado.Enabled = True
                dgvCarrera.ColumnHeadersVisible = True
                llbInexistente.Visible = True
            Else
                dgvCarrera.DataSource = Nothing
                txtBuscado.Enabled = False
                dgvCarrera.ColumnHeadersVisible = False
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
                dgvCarrera.DataSource = dv
                Ocultar_Columnas()
            Else
                llbInexistente.Visible = True
                dgvCarrera.DataSource = Nothing
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub frmCarrera_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
        codigo = Format(func.Generar_Carrera, "0000")
        txtIdCarrera.Text = Format(func.Generar_Carrera)
        txtCodigo.Text = "CRONOSCAR" + codigo
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Mostrar()
    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        Dim result As DialogResult
        result = MessageBox.Show("¿Realmente quiere modificar el registro?", "Modificando Registro", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)

        If result = DialogResult.OK Then
            If Me.ValidateChildren = True And txtIdCarrera.Text <> 0 And txtCodigo.Text <> "" And txtCarrera.Text <> "" And cmbNivel.Text <> "" Then
                Try
                    Dim dts As New CCarrera
                    Dim func As New fCarrera

                    dts._idCarrera = txtIdCarrera.Text
                    dts._codigo = txtCodigo.Text
                    dts._carrera = txtCarrera.Text
                    dts._nivel = cmbNivel.Text

                    If func.Modificar_Carrera(dts) Then
                        MessageBox.Show("Carrera modificada correctamente", "Modificando Registro", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Mostrar()
                        Limpiar()
                    Else
                        MessageBox.Show("Carrera no modificada, intente de nuevo", "Modificando Registro", MessageBoxButtons.OK, MessageBoxIcon.Information)
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
        If Me.ValidateChildren = True And txtCodigo.Text <> "" And txtCarrera.Text <> "" And cmbNivel.Text <> "" Then
            Try
                Dim dts As New CCarrera
                Dim func As New fCarrera

                dts._codigo = txtCodigo.Text
                dts._carrera = txtCarrera.Text
                dts._nivel = cmbNivel.Text

                If func.Insertar_Carrera(dts) Then
                    MessageBox.Show("Carrera registrada correctamente", "Guardando Registro", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Mostrar()
                    Limpiar()
                Else
                    MessageBox.Show("Carrera no registrada, intente de nuevo", "Guardando Registro", MessageBoxButtons.OK, MessageBoxIcon.Information)
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
            Me.erpErrorIcono.SetError(sender, "Ingresa el Código de la Carrera, Dato Obligatorio")
        End If
    End Sub

    Private Sub txtCarrera_Validating(sender As Object, e As CancelEventArgs) Handles txtCarrera.Validating
        If DirectCast(sender, TextBox).Text.Length > 0 Then
            Me.erpErrorIcono.SetError(sender, "")
        Else
            Me.erpErrorIcono.SetError(sender, "Ingresa el Nombre de la Carrera, Dato Obligatorio")
        End If
    End Sub

    Private Sub cmbNivel_Validating(sender As Object, e As CancelEventArgs) Handles cmbNivel.Validating
        If DirectCast(sender, ComboBox).Text.Length > 0 Then
            Me.erpErrorIcono.SetError(sender, "")
        Else
            Me.erpErrorIcono.SetError(sender, "Selecciona el Nivel de la Carrera, Dato Obligatorio")
        End If
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Dim result As DialogResult
        result = MessageBox.Show("Realmente desea eliminar la información seleccionada", "Eliminación de Registro", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)

        If result = DialogResult.OK Then
            Try
                For Each row As DataGridViewRow In dgvCarrera.Rows
                    Dim marcado As Boolean = Convert.ToBoolean(row.Cells("Eliminar").Value)

                    If marcado Then
                        Dim onekey As Integer = Convert.ToInt32(row.Cells("ID_Carrera").Value)
                        Dim vdb As New CCarrera
                        Dim func As New fCarrera
                        vdb._idCarrera = onekey

                        If func.Eliminar_Carrera(vdb) Then
                        Else
                            MessageBox.Show("Carrera no eliminada", "Eliminación de Registro", MessageBoxButtons.OK, MessageBoxIcon.Information)
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
            dgvCarrera.Columns.Item("Eliminar").Visible = True
            btnEliminar.Visible = True
        Else
            dgvCarrera.Columns.Item("Eliminar").Visible = False
            btnEliminar.Visible = False
        End If
    End Sub

    Private Sub dgvCarrera_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCarrera.CellClick
        txtIdCarrera.Text = dgvCarrera.SelectedCells.Item(1).Value
        txtCodigo.Text = dgvCarrera.SelectedCells.Item(2).Value
        txtCarrera.Text = dgvCarrera.SelectedCells.Item(3).Value
        cmbNivel.Text = dgvCarrera.SelectedCells.Item(4).Value
        Activar()
        btnModificar.Enabled = True
        btnGuardar.Enabled = False
        btnCancelar.Enabled = True
        btnNuevo.Enabled = False
    End Sub

    Private Sub dgvCarrera_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCarrera.CellContentClick
        If e.ColumnIndex = Me.dgvCarrera.Columns.Item("Eliminar").Index Then
            Dim chkcell As DataGridViewCheckBoxCell = Me.dgvCarrera.Rows(e.RowIndex).Cells("Eliminar")
            chkcell.Value = Not chkcell.Value
        End If
    End Sub

    Private Sub dgvCarrera_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCarrera.CellDoubleClick
        If txtFlag.Text = "1" Then
            frmEmpleado.txtIdCarrera.Text = dgvCarrera.SelectedCells.Item(1).Value
            frmEmpleado.txtCarrera.Text = dgvCarrera.SelectedCells.Item(3).Value
            Me.Close()
        End If
    End Sub

End Class