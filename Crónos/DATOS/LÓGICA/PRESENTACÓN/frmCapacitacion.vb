Imports System.ComponentModel

Public Class frmCapacitacion
    Private dt As New DataTable
    Dim func As New fCapacitacion

    Private Sub Limpiar()
        txtIdCapacitacion.Text = ""
        txtCodigo.Text = ""
        txtNombre.Text = ""
        txtIdCapacitacion.Text = ""
        txtTema.Text = ""
        dtpFecha.Value = Date.Today
    End Sub

    Private Sub Activar()
        txtNombre.Enabled = True
        txtTema.Enabled = True
        dtpFecha.Enabled = True
    End Sub

    Private Sub Desactivar()
        txtNombre.Enabled = False
        txtTema.Enabled = False
        dtpFecha.Enabled = False
    End Sub

    Private Sub Ocultar_Columnas()
        dgvCapacitacion.Columns(1).Visible = False
        dgvCapacitacion.Columns(4).Visible = False
    End Sub

    Private Sub Mostrar()
        Try
            Dim funcion As New fCapacitacion
            dt = funcion.Mostrar_Capacitacion
            dgvCapacitacion.Columns.Item("Eliminar").Visible = False

            If dt.Rows.Count <> 0 Then
                dgvCapacitacion.DataSource = dt
                txtBuscado.Enabled = True
                dgvCapacitacion.ColumnHeadersVisible = True
                llbInexistente.Visible = True
            Else
                dgvCapacitacion.DataSource = Nothing
                txtBuscado.Enabled = False
                dgvCapacitacion.ColumnHeadersVisible = False
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
                dgvCapacitacion.DataSource = dv
                Ocultar_Columnas()
            Else
                llbInexistente.Visible = True
                dgvCapacitacion.DataSource = Nothing
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
        txtIdCapacitacion.Text = Format(func.Generar_Capacitacion)
        codigo = Format(func.Generar_Capacitacion, "0000")
        txtCodigo.Text = "CRONOSCAP" + codigo
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Mostrar()
    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        Dim result As DialogResult
        result = MessageBox.Show("¿Realmente quiere modificar el registro?", "Modificando Registro", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)

        If result = DialogResult.OK Then
            If Me.ValidateChildren = True And txtIdCapacitacion.Text <> 0 And txtCodigo.Text <> "" And txtNombre.Text <> "" And txtTema.Text <> "" And dtpFecha.Text <> "" Then
                Try
                    Dim dts As New CCapacitacion
                    Dim func As New fCapacitacion

                    dts._idCapacitacion = txtIdCapacitacion.Text
                    dts._codigo = txtCodigo.Text
                    dts._nombre = txtNombre.Text
                    dts._tema = txtTema.Text
                    dts._fecha = dtpFecha.Text

                    If func.Modificar_Capacitacion(dts) Then
                        MessageBox.Show("Capacitación modificado correctamente", "Modificando Registro", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Mostrar()
                        Limpiar()

                    Else
                        MessageBox.Show("Capacitación no modificado, intente de nuevo", "Modificando Registro", MessageBoxButtons.OK, MessageBoxIcon.Information)
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
        If Me.ValidateChildren = True And txtCodigo.Text <> "" And txtNombre.Text <> "" And txtTema.Text <> "" And dtpFecha.Text <> "" Then
            Try
                Dim dts As New CCapacitacion
                Dim func As New fCapacitacion

                dts._codigo = txtCodigo.Text
                dts._nombre = txtNombre.Text
                dts._tema = txtTema.Text
                dts._fecha = dtpFecha.Text

                If func.Insertar_Capacitacion(dts) Then
                    MessageBox.Show("Capacitación registrado correctamente", "Guardando Registro", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Mostrar()
                    Limpiar()
                Else
                    MessageBox.Show("Capacitación no registrado, intente de nuevo", "Guardando Registro", MessageBoxButtons.OK, MessageBoxIcon.Information)
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

    Private Sub frmCapacitacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
            Me.erpErrorIcono.SetError(sender, "Ingresa el Código del Agente, Dato Obligatorio")
        End If
    End Sub

    Private Sub txtNombre_Validating(sender As Object, e As CancelEventArgs) Handles txtNombre.Validating
        If DirectCast(sender, TextBox).Text.Length > 0 Then
            Me.erpErrorIcono.SetError(sender, "")
        Else
            Me.erpErrorIcono.SetError(sender, "Ingresa el Nombre de la Capacitación del Agente, Dato Obligatorio")
        End If
    End Sub

    Private Sub txtTema_Validating(sender As Object, e As CancelEventArgs) Handles txtTema.Validating
        If DirectCast(sender, TextBox).Text.Length > 0 Then
            Me.erpErrorIcono.SetError(sender, "")
        Else
            Me.erpErrorIcono.SetError(sender, "Ingresa el Tema de la Capacitación del Agente, Dato Obligatorio")
        End If
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Dim result As DialogResult
        result = MessageBox.Show("Realmente desea eliminar la información seleccionada", "Eliminación de Registro", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)

        If result = DialogResult.OK Then
            Try
                For Each row As DataGridViewRow In dgvCapacitacion.Rows
                    Dim marcado As Boolean = Convert.ToBoolean(row.Cells("Eliminar").Value)

                    If marcado Then
                        Dim onekey As Integer = Convert.ToInt32(row.Cells("ID_Capacitacion").Value)
                        Dim vdb As New CCapacitacion
                        Dim func As New fCapacitacion
                        vdb._idCapacitacion = onekey

                        If func.Eliminar_Capacitacion(vdb) Then
                        Else
                            MessageBox.Show("Capacitación no eliminado", "Eliminación de Registro", MessageBoxButtons.OK, MessageBoxIcon.Information)
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
            dgvCapacitacion.Columns.Item("Eliminar").Visible = True
            btnEliminar.Visible = True
        Else
            dgvCapacitacion.Columns.Item("Eliminar").Visible = False
            btnEliminar.Visible = False
        End If
    End Sub

    Private Sub dgvCapacitacion_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCapacitacion.CellContentClick
        If e.ColumnIndex = Me.dgvCapacitacion.Columns.Item("Eliminar").Index Then
            Dim chkcell As DataGridViewCheckBoxCell = Me.dgvCapacitacion.Rows(e.RowIndex).Cells("Eliminar")
            chkcell.Value = Not chkcell.Value
        End If
    End Sub

    Private Sub DgvCapacitacion_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCapacitacion.CellClick
        txtIdCapacitacion.Text = dgvCapacitacion.SelectedCells.Item(1).Value
        txtCodigo.Text = dgvCapacitacion.SelectedCells.Item(2).Value
        txtNombre.Text = dgvCapacitacion.SelectedCells.Item(3).Value
        dtpFecha.Value = dgvCapacitacion.SelectedCells.Item(4).Value
        txtTema.Text = dgvCapacitacion.SelectedCells.Item(5).Value
        Activar()
        btnModificar.Enabled = True
        btnGuardar.Enabled = False
        btnCancelar.Enabled = True
        btnNuevo.Enabled = False
    End Sub

    Private Sub dgvCapacitacion_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCapacitacion.CellDoubleClick
        If txtFlag.Text = "1" Then
            frmCapacitacionEmpleado.txtIdCapacitacion.Text = dgvCapacitacion.SelectedCells.Item(1).Value
            frmCapacitacionEmpleado.txtCapacitacion.Text = dgvCapacitacion.SelectedCells.Item(3).Value
            Me.Close()
        End If
    End Sub
End Class