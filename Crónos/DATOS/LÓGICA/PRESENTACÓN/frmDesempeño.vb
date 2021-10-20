Imports System.ComponentModel

Public Class frmDesempeño
    Private dt As New DataTable
    Dim func As New fDesempeño

    Private Sub Limpiar()
        txtIdEvaluacion.Text = ""
        txtIdEmpleado.Text = ""
        txtEmpleado.Text = ""
        dtpFecha.Value = Date.Today
        txtCuota.Text = ""
        nudAlcance.Value = 0
        nudEvaluacion.Value = 0
        txtTotal.Text = ""
    End Sub

    Private Sub Activar()
        dtpFecha.Enabled = True
        txtCuota.Enabled = True
        nudAlcance.Enabled = True
        nudEvaluacion.Enabled = True
    End Sub

    Public Sub Desactivar()
        dtpFecha.Enabled = False
        txtCuota.Enabled = False
        nudAlcance.Enabled = False
        nudEvaluacion.Enabled = False
    End Sub

    Public Sub Ocultar_Columnas()
        dgvDesempeño.Columns(1).Visible = False
        dgvDesempeño.Columns(2).Visible = False
        dgvDesempeño.Columns(6).Visible = False
        dgvDesempeño.Columns(7).Visible = False
    End Sub

    Public Sub Mostrar()
        Try
            Dim funcion As New fDesempeño
            dt = funcion.Mostrar_Desempeño
            dgvDesempeño.Columns.Item("Eliminar").Visible = False

            If dt.Rows.Count <> 0 Then
                dgvDesempeño.DataSource = dt
                txtBuscado.Enabled = True
                dgvDesempeño.ColumnHeadersVisible = True
                llbInexistente.Visible = False
            Else
                dgvDesempeño.DataSource = Nothing
                txtBuscado.Enabled = False
                dgvDesempeño.ColumnHeadersVisible = False
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
                dgvDesempeño.DataSource = dv
                Ocultar_Columnas()
            Else
                llbInexistente.Visible = True
                dgvDesempeño.DataSource = Nothing
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
        txtIdEvaluacion.Text = Format(func.Generar_Desempeño)
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Mostrar()
    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        Dim result As DialogResult
        result = MessageBox.Show("¿Realmente quiere modificar el registro?", "Modificando Registro", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)

        If result = DialogResult.OK Then
            If Me.ValidateChildren = True And txtIdEvaluacion.Text <> 0 And txtIdEmpleado.Text <> "" And dtpFecha.Text <> "" And txtCuota.Text <> "" And nudAlcance.Text <> 0 And nudEvaluacion.Text <> 0 And txtTotal.Text <> "" Then
                Try
                    Dim dts As New CDesempeño
                    Dim func As New fDesempeño

                    dts._idEvaluacion = txtIdEvaluacion.Text
                    dts._idEmpleado = txtIdEmpleado.Text
                    dts._fecha = dtpFecha.Value
                    dts._cMensual = txtCuota.Text
                    dts._pAlcance = nudAlcance.Value
                    dts._eDirecta = nudEvaluacion.Value
                    dts._eTotal = txtTotal.Text

                    If func.Modificar_Desempeño(dts) Then
                        MessageBox.Show("Evaluación modificada correctamente", "Modificando Registro", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Mostrar()
                        Limpiar()
                    Else
                        MessageBox.Show("Evaluación no modificada, intente de nuevo", "Modificando Registro", MessageBoxButtons.OK, MessageBoxIcon.Information)
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
        If Me.ValidateChildren = True And txtIdEmpleado.Text <> "" And dtpFecha.Text <> "" And txtCuota.Text <> "" And nudAlcance.Text <> 0 And nudEvaluacion.Text <> 0 And txtTotal.Text <> "" Then
            Try
                Dim dts As New CDesempeño
                Dim func As New fDesempeño

                dts._idEmpleado = txtIdEmpleado.Text
                dts._fecha = dtpFecha.Value
                dts._cMensual = txtCuota.Text
                dts._pAlcance = nudAlcance.Value
                dts._eDirecta = nudEvaluacion.Value
                dts._eTotal = txtTotal.Text

                If func.Insertar_Desempeño(dts) Then
                    MessageBox.Show("Evaluación registrada correctamente", "Guardando Registro", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Mostrar()
                    Limpiar()
                Else
                    MessageBox.Show("Evaluación no registrada, intente de nuevo", "Guardando Registro", MessageBoxButtons.OK, MessageBoxIcon.Information)
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

    Private Sub frmDesempeño_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Mostrar()
        Limpiar()
        btnNuevo.Enabled = True
        btnSalir.Enabled = True
        btnGuardar.Enabled = False
        btnModificar.Enabled = False
        btnCancelar.Enabled = False
        Desactivar()
    End Sub

    Private Sub txtIdEmpleado_Validating(sender As Object, e As CancelEventArgs) Handles txtIdEmpleado.Validating
        If DirectCast(sender, TextBox).Text.Length > 0 Then
            Me.erpErrorIcono.SetError(sender, "")
        Else
            Me.erpErrorIcono.SetError(sender, "Ingresa el ID del Empleado, Dato Obligatorio")
        End If
    End Sub

    Private Sub dtpFecha_Validating(sender As Object, e As CancelEventArgs) Handles dtpFecha.Validating
        If DirectCast(sender, DateTimePicker).Text <> "" Then
            Me.erpErrorIcono.SetError(sender, "")
        Else
            Me.erpErrorIcono.SetError(sender, "Ingresa la Fecha, Dato Obligatorio")
        End If
    End Sub

    Private Sub txtCuota_Validating(sender As Object, e As CancelEventArgs) Handles txtCuota.Validating
        If DirectCast(sender, TextBox).Text.Length > 0 Then
            Me.erpErrorIcono.SetError(sender, "")
        Else
            Me.erpErrorIcono.SetError(sender, "Ingresa la Couta Mensual del Empleado, Dato Obligatorio")
        End If
    End Sub

    Private Sub nudAlcance_Validating(sender As Object, e As CancelEventArgs) Handles nudAlcance.Validating
        If DirectCast(sender, NumericUpDown).Value <> 0 Then
            Me.erpErrorIcono.SetError(sender, "")
        Else
            Me.erpErrorIcono.SetError(sender, "Ingresa el % del Alcance del Empleado, Dato Obligatorio")
        End If
    End Sub

    Private Sub nudEvaluacion_Validating(sender As Object, e As CancelEventArgs) Handles nudEvaluacion.Validating
        If DirectCast(sender, NumericUpDown).Value <> 0 Then
            Me.erpErrorIcono.SetError(sender, "")
        Else
            Me.erpErrorIcono.SetError(sender, "Ingresa el % de Evaluación del Jefe Directo del Empleado, Dato Obligatorio")
        End If
    End Sub

    Private Sub txtTotal_Validating(sender As Object, e As CancelEventArgs) Handles txtTotal.Validating
        If DirectCast(sender, TextBox).Text.Length > 0 Then
            Me.erpErrorIcono.SetError(sender, "")
        Else
            Me.erpErrorIcono.SetError(sender, "Calcula la evaluación del Empleado, Dato Obligatorio")
        End If
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Dim result As DialogResult
        result = MessageBox.Show("Realmente desea eliminar la información seleccionada", "Eliminación de Registro", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)

        If result = DialogResult.OK Then
            Try
                For Each row As DataGridViewRow In dgvDesempeño.Rows
                    Dim marcado As Boolean = Convert.ToBoolean(row.Cells("Eliminar").Value)

                    If marcado Then
                        Dim onekey As Integer = Convert.ToInt32(row.Cells("ID_Evaluacion").Value)
                        Dim vdb As New CDesempeño
                        Dim func As New fDesempeño
                        vdb._idEvaluacion = onekey

                        If func.Eliminar_Desempeño(vdb) Then
                        Else
                            MessageBox.Show("Evaluación no eliminada", "Eliminación de Registro", MessageBoxButtons.OK, MessageBoxIcon.Information)
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
            dgvDesempeño.Columns.Item("Eliminar").Visible = True
            btnEliminar.Visible = True
        Else
            dgvDesempeño.Columns.Item("Eliminar").Visible = False
            btnEliminar.Visible = False
        End If
    End Sub

    Private Sub dgvDesempeño_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDesempeño.CellContentClick
        If e.ColumnIndex = Me.dgvDesempeño.Columns.Item("Eliminar").Index Then
            Dim chkcell As DataGridViewCheckBoxCell = Me.dgvDesempeño.Rows(e.RowIndex).Cells("Eliminar")
            chkcell.Value = Not chkcell.Value
        End If
    End Sub

    Private Sub dgvDesempeño_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDesempeño.CellClick
        txtIdEvaluacion.Text = dgvDesempeño.SelectedCells.Item(1).Value
        txtIdEmpleado.Text = dgvDesempeño.SelectedCells.Item(2).Value
        txtEmpleado.Text = dgvDesempeño.SelectedCells.Item(3).Value
        dtpFecha.Value = dgvDesempeño.SelectedCells.Item(4).Value
        txtCuota.Text = dgvDesempeño.SelectedCells.Item(5).Value
        nudAlcance.Value = dgvDesempeño.SelectedCells.Item(6).Value
        nudEvaluacion.Value = dgvDesempeño.SelectedCells.Item(7).Value
        txtTotal.Text = dgvDesempeño.SelectedCells.Item(8).Value
        Activar()
        btnModificar.Enabled = True
        btnGuardar.Enabled = False
        btnCancelar.Enabled = True
        btnNuevo.Enabled = False
    End Sub

    Private Sub btnEmpleado_Click(sender As Object, e As EventArgs) Handles btnEmpleado.Click
        frmEmpleado.txtFlag.Text = "2"
        frmEmpleado.MdiParent = Crónos
        frmEmpleado.Show()
    End Sub

    Private Sub btnCalcular_Click(sender As Object, e As EventArgs) Handles btnCalcular.Click
        Dim total As Double
        total = (nudAlcance.Value + nudEvaluacion.Value) / 2
        txtTotal.Text = total
    End Sub

    Private Sub btnAyuda_Click(sender As Object, e As EventArgs) Handles btnAyuda.Click
        MessageBox.Show("Este dato lo debe proporcionar el supervisor, ponte en contacto con él.", "Calculo de Couta Mensual", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
End Class