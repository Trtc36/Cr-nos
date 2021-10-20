Imports System.ComponentModel
Public Class frmCapacitacionEmpleado
    Private dt As New DataTable
    Dim func As New fCEmpleado

    Private Sub Limpiar()
        txtIdCapacitacion.Text = ""
        txtCapacitacion.Text = ""
        txtIdEmpleado.Text = ""
        txtEmpleado.Text = ""
    End Sub

    Private Sub Activar()
        btnCapacitacion.Enabled = True
        btnEmpleado.Enabled = True
    End Sub

    Private Sub Desactivar()
        btnCapacitacion.Enabled = False
        btnEmpleado.Enabled = False
    End Sub

    Private Sub Ocultar_Columnas()
        dgvCEmpleado.Columns(1).Visible = False
        dgvCEmpleado.Columns(3).Visible = False
    End Sub

    Private Sub Mostrar()
        Try
            Dim funcion As New fCEmpleado
            dt = funcion.Mostrar_CEmpleado
            dgvCEmpleado.Columns.Item("Eliminar").Visible = False

            If dt.Rows.Count <> 0 Then
                dgvCEmpleado.DataSource = dt
                txtBuscado.Enabled = True
                dgvCEmpleado.ColumnHeadersVisible = True
                llbInexistente.Visible = True
                Ocultar_Columnas()
            Else
                dgvCEmpleado.DataSource = Nothing
                txtBuscado.Enabled = False
                dgvCEmpleado.ColumnHeadersVisible = False
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
                dgvCEmpleado.DataSource = dv
            Else
                llbInexistente.Visible = True
                dgvCEmpleado.DataSource = Nothing
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
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Mostrar()
    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        Dim result As DialogResult
        result = MessageBox.Show("¿Realmente quiere modificar el registro?", "Modificando Registro", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)

        If result = DialogResult.OK Then
            If Me.ValidateChildren = True And txtIdCapacitacion.Text <> 0 And txtIdEmpleado.Text <> 0 Then
                Try
                    Dim dts As New CCapacitacionEmpleado
                    Dim func As New fCEmpleado

                    dts._idCapacitacion = txtIdCapacitacion.Text
                    dts._idEmpleado = txtIdEmpleado.Text


                    If func.Modificar_CEmpleado(dts) Then
                        MessageBox.Show("Capacitacion de Empleado modificada correctamente", "Modificando Registro", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Mostrar()
                        Limpiar()
                    Else
                        MessageBox.Show("Capacitacion de Empleado no modificada, intente de nuevo", "Modificando Registro", MessageBoxButtons.OK, MessageBoxIcon.Information)
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
        If Me.ValidateChildren = True And txtIdCapacitacion.Text <> 0 And txtIdEmpleado.Text <> 0 Then
            Try
                Dim dts As New CCapacitacionEmpleado
                Dim func As New fCEmpleado

                dts._idCapacitacion = txtIdCapacitacion.Text
                dts._idEmpleado = txtIdEmpleado.Text

                If func.Insertar_CEmpleado(dts) Then
                    MessageBox.Show("Capacitación de Empleado registrada correctamente", "Guardando Registro", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Mostrar()
                    Limpiar()
                Else
                    MessageBox.Show("Capacitación de Empleado no registrada, intente de nuevo", "Guardando Registro", MessageBoxButtons.OK, MessageBoxIcon.Information)
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

    Private Sub frmCapacitacionEmpleado_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Mostrar()
        Limpiar()
        btnNuevo.Enabled = True
        btnSalir.Enabled = True
        btnGuardar.Enabled = False
        btnModificar.Enabled = False
        btnCancelar.Enabled = False
    End Sub


    Private Sub txtIdCapacitacion_Validating(sender As Object, e As CancelEventArgs) Handles txtIdCapacitacion.Validating
        If DirectCast(sender, TextBox).Text.Length > 0 Then
            Me.erpErrorIcono.SetError(sender, "")
        Else
            Me.erpErrorIcono.SetError(sender, "Ingresa el Id de la Capacitación, Dato Obligatorio")
        End If
    End Sub

    Private Sub txtIdEmpleado_Validating(sender As Object, e As CancelEventArgs) Handles txtIdEmpleado.Validating
        If DirectCast(sender, TextBox).Text.Length > 0 Then
            Me.erpErrorIcono.SetError(sender, "")
        Else
            Me.erpErrorIcono.SetError(sender, "Ingresa el Id del Empleado, Dato Obligatorio")
        End If
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Dim result As DialogResult
        result = MessageBox.Show("Realmente desea eliminar la información seleccionada", "Eliminación de Registro", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)

        If result = DialogResult.OK Then
            Try
                For Each row As DataGridViewRow In dgvCEmpleado.Rows
                    Dim marcado As Boolean = Convert.ToBoolean(row.Cells("Eliminar").Value)

                    If marcado Then
                        Dim onekey As Integer = Convert.ToInt32(row.Cells("ID_Capacitacion").Value)
                        Dim onekey2 As Integer = Convert.ToInt32(row.Cells("ID_Empleado").Value)
                        Dim vdb As New CCapacitacionEmpleado
                        Dim func As New fCEmpleado
                        vdb._idCapacitacion = onekey
                        vdb._idEmpleado = onekey2

                        If func.Eliminar_CEmpleado(vdb) Then
                        Else
                            MessageBox.Show("Capacitación de Empleado no eliminado", "Eliminación de Registro", MessageBoxButtons.OK, MessageBoxIcon.Information)
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
            dgvCEmpleado.Columns.Item("Eliminar").Visible = True
            btnEliminar.Visible = True
        Else
            dgvCEmpleado.Columns.Item("Eliminar").Visible = False
            btnEliminar.Visible = False
        End If
    End Sub

    Private Sub dgvCEmpleado_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCEmpleado.CellContentClick
        txtIdCapacitacion.Text = dgvCEmpleado.SelectedCells.Item(1).Value
        txtCapacitacion.Text = dgvCEmpleado.SelectedCells.Item(2).Value
        txtIdEmpleado.Text = dgvCEmpleado.SelectedCells.Item(3).Value
        txtEmpleado.Text = dgvCEmpleado.SelectedCells.Item(4).Value
        btnModificar.Enabled = True
        btnGuardar.Enabled = False
        btnCancelar.Enabled = True
        btnNuevo.Enabled = False
    End Sub

    Private Sub dgvCEmpleado_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCEmpleado.CellClick
        If e.ColumnIndex = Me.dgvCEmpleado.Columns.Item("Eliminar").Index Then
            Dim chkcell As DataGridViewCheckBoxCell = Me.dgvCEmpleado.Rows(e.RowIndex).Cells("Eliminar")
            chkcell.Value = Not chkcell.Value
        End If
    End Sub

    Private Sub btnCapacitacion_Click(sender As Object, e As EventArgs) Handles btnCapacitacion.Click
        frmCapacitacion.txtFlag.Text = "1"
        frmCapacitacion.MdiParent = Crónos
        frmCapacitacion.Show()
    End Sub

    Private Sub btnEmpleado_Click(sender As Object, e As EventArgs) Handles btnEmpleado.Click
        frmEmpleado.txtFlag.Text = "1"
        frmEmpleado.MdiParent = Crónos
        frmEmpleado.Show()
    End Sub
End Class