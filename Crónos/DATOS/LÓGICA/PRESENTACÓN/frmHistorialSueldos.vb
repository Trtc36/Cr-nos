Imports System.ComponentModel
Public Class frmHistorialSueldos
    Private dt As New DataTable


    Public Sub Limpiar()
        txtIdSueldo.Text = ""
        txtSueldo.Text = ""
        dtpFecha.Value = Date.Today
        txtIdEmpleado.Text = ""
        txtCEmpleado.Text = ""
        txtNEmpleado.Text = ""
        txtPEmpleado.Text = ""
        txtMEmpleado.Text = ""
    End Sub

    Public Sub Activar()
        txtSueldo.Enabled = True
        dtpFecha.Enabled = True
        btnEmpleado.Enabled = True
    End Sub

    Public Sub Desactivar()
        txtSueldo.Enabled = False
        dtpFecha.Enabled = False
        btnEmpleado.Enabled = False
    End Sub

    Public Sub Ocultar_Columnas()
        dgvHistorial.Columns(1).Visible = False
        dgvHistorial.Columns(4).Visible = False
        dgvHistorial.Columns(8).Visible = False
    End Sub

    Public Sub Mostrar()
        Try
            Dim funcion As New fHSueldos
            dt = funcion.Mostrar_HSueldo
            dgvHistorial.Columns.Item("Eliminar").Visible = False

            If dt.Rows.Count <> 0 Then
                dgvHistorial.DataSource = dt
                txtBuscado.Enabled = True
                dgvHistorial.ColumnHeadersVisible = True
                llbInexistente.Visible = True
            Else
                dgvHistorial.DataSource = Nothing
                txtBuscado.Enabled = False
                dgvHistorial.ColumnHeadersVisible = False
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

    Public Sub Buscar()
        Try
            Dim ds As New DataSet
            ds.Tables.Add(dt.Copy)
            Dim dv As New DataView(ds.Tables(0))

            dv.RowFilter = cmbBuscar.Text & " like '" & txtBuscado.Text & "%'"

            If dv.Count <> 0 Then
                llbInexistente.Visible = False
                dgvHistorial.DataSource = dv
                Ocultar_Columnas()
            Else
                llbInexistente.Visible = True
                dgvHistorial.DataSource = Nothing
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        Dim func As New fHSueldos
        Limpiar()
        Activar()
        btnCancelar.Enabled = True
        btnGuardar.Enabled = True
        btnNuevo.Enabled = False
        btnModificar.Enabled = False
        txtIdSueldo.Text = Format(func.Generar_Sueldo)
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Mostrar()
    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        Dim result As DialogResult
        result = MessageBox.Show("¿Realmente quiere modificar el registro?", "Modificando Registro", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)

        If result = DialogResult.OK Then
            If Me.ValidateChildren = True And txtIdSueldo.Text <> 0 And txtSueldo.Text <> "" And txtIdEmpleado.Text <> "" Then
                Try
                    Dim dts As New CHSueldos
                    Dim func As New fHSueldos

                    dts._idSueldo = txtIdSueldo.Text
                    dts._sueldo = txtSueldo.Text
                    dts._fecha = dtpFecha.Value
                    dts._idEmpleado = txtIdEmpleado.Text

                    If func.Modificar_HSueldos(dts) Then
                        MessageBox.Show("Sueldo modificado correctamente", "Modificando Registro", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Mostrar()
                        Limpiar()
                    Else
                        MessageBox.Show("Sueldo no modificado, intente de nuevo", "Modificando Registro", MessageBoxButtons.OK, MessageBoxIcon.Information)
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
        If Me.ValidateChildren = True And txtSueldo.Text <> "" And txtIdEmpleado.Text <> "" Then
            Try
                Dim dts As New CHSueldos
                Dim func As New fHSueldos

                dts._idSueldo = txtIdSueldo.Text
                dts._sueldo = txtSueldo.Text
                dts._fecha = dtpFecha.Value
                dts._idEmpleado = txtIdEmpleado.Text

                If func.Insertar_HSueldo(dts) Then
                    MessageBox.Show("Sueldo registrado correctamente", "Guardando Registro", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Mostrar()
                    Limpiar()
                Else
                    MessageBox.Show("Sueldo no registrado, intente de nuevo", "Guardando Registro", MessageBoxButtons.OK, MessageBoxIcon.Information)
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

    Private Sub frmHistorialSueldos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Mostrar()
        Limpiar()
        btnNuevo.Enabled = True
        btnSalir.Enabled = True
        btnGuardar.Enabled = False
        btnModificar.Enabled = False
        btnCancelar.Enabled = False
        Desactivar()
    End Sub

    Private Sub txtSueldo_Validating(sender As Object, e As CancelEventArgs) Handles txtSueldo.Validating
        If DirectCast(sender, TextBox).Text.Length > 0 Then
            Me.erpErrorIcono.SetError(sender, "")
        Else
            Me.erpErrorIcono.SetError(sender, "Ingresa el Sueldo del Empleado, Dato Obligatorio")
        End If
    End Sub

    Private Sub dtpFecha_Validating(sender As Object, e As CancelEventArgs) Handles dtpFecha.Validating
        If DirectCast(sender, DateTimePicker).Text.Length > 0 Then
            Me.erpErrorIcono.SetError(sender, "")
        Else
            Me.erpErrorIcono.SetError(sender, "Ingresa la Fecha de Actualización, Dato Obligatorio")
        End If
    End Sub

    Private Sub txtIdEmpleado_Validating(sender As Object, e As CancelEventArgs) Handles txtIdEmpleado.Validating
        If DirectCast(sender, TextBox).Text.Length > 0 Then
            Me.erpErrorIcono.SetError(sender, "")
        Else
            Me.erpErrorIcono.SetError(sender, "Selecciona el Id del Empleado, Dato Obligatorio")
        End If
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Dim result As DialogResult
        result = MessageBox.Show("Realmente desea eliminar la información seleccionada", "Eliminación de Registro", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)

        If result = DialogResult.OK Then
            Try
                For Each row As DataGridViewRow In dgvHistorial.Rows
                    Dim marcado As Boolean = Convert.ToBoolean(row.Cells("Eliminar").Value)

                    If marcado Then
                        Dim onekey As Integer = Convert.ToInt32(row.Cells("ID_Sueldo").Value)
                        Dim vdb As New CHSueldos
                        Dim func As New fHSueldos
                        vdb._idSueldo = onekey

                        If func.Eliminar_HSueldo(vdb) Then
                        Else
                            MessageBox.Show("Sueldo no eliminado", "Eliminación de Registro", MessageBoxButtons.OK, MessageBoxIcon.Information)
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
            dgvHistorial.Columns.Item("Eliminar").Visible = True
            btnEliminar.Visible = True
        Else
            dgvHistorial.Columns.Item("Eliminar").Visible = False
            btnEliminar.Visible = False
        End If
    End Sub

    Private Sub dgvHistorial_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvHistorial.CellContentClick
        If e.ColumnIndex = Me.dgvHistorial.Columns.Item("Eliminar").Index Then
            Dim chkcell As DataGridViewCheckBoxCell = Me.dgvHistorial.Rows(e.RowIndex).Cells("Eliminar")
            chkcell.Value = Not chkcell.Value
        End If
    End Sub

    Private Sub dgvHistorial_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvHistorial.CellClick
        txtIdSueldo.Text = dgvHistorial.SelectedCells.Item(1).Value
        txtSueldo.Text = dgvHistorial.SelectedCells.Item(2).Value
        dtpFecha.Value = dgvHistorial.SelectedCells.Item(3).Value
        txtIdEmpleado.Text = dgvHistorial.SelectedCells.Item(4).Value
        txtCEmpleado.Text = dgvHistorial.SelectedCells.Item(5).Value
        txtNEmpleado.Text = dgvHistorial.SelectedCells.Item(6).Value
        txtPEmpleado.Text = dgvHistorial.SelectedCells.Item(7).Value
        txtMEmpleado.Text = dgvHistorial.SelectedCells.Item(8).Value
        Activar()
        btnModificar.Enabled = True
        btnGuardar.Enabled = False
        btnCancelar.Enabled = True
        btnNuevo.Enabled = False
    End Sub

    Private Sub btnEmpleado_Click(sender As Object, e As EventArgs) Handles btnEmpleado.Click
        frmEmpleado.txtFlag.Text = "3"
        frmEmpleado.MdiParent = Crónos
        frmEmpleado.Show()
    End Sub
End Class