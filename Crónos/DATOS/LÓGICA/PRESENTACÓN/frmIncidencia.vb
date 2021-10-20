Imports System.ComponentModel
Public Class frmIncidencia
    Private dt As New DataTable

    Public Sub Limpiar()
        txtIdIncidencia.Text = ""
        txtIdEmpleado.Text = ""
        txtEmpleado.Text = ""
        dtpFecha.Value = Date.Today
        cmbTipo.Text = ""
        cmbArea.Text = ""
    End Sub

    Public Sub Activar()
        dtpFecha.Enabled = True
        cmbTipo.Enabled = True
        cmbArea.Enabled = True
        btnEmpleado.Enabled = True
    End Sub

    Public Sub Desactivar()
        dtpFecha.Enabled = False
        cmbTipo.Enabled = False
        cmbArea.Enabled = False
        btnEmpleado.Enabled = False
    End Sub

    Public Sub Ocultar_Columnas()
        dgvIncidencia.Columns(1).Visible = False
        dgvIncidencia.Columns(2).Visible = False
    End Sub

    Public Sub Mostrar()
        Try
            Dim funcion As New fIncidencia
            dt = funcion.Mostrar_Incidencia
            dgvIncidencia.Columns.Item("Eliminar").Visible = False

            If dt.Rows.Count <> 0 Then
                dgvIncidencia.DataSource = dt
                txtBuscado.Enabled = True
                dgvIncidencia.ColumnHeadersVisible = True
                llbInexistente.Visible = True
            Else
                dgvIncidencia.DataSource = Nothing
                txtBuscado.Enabled = False
                dgvIncidencia.ColumnHeadersVisible = False
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
                dgvIncidencia.DataSource = dv
                Ocultar_Columnas()
            Else
                llbInexistente.Visible = True
                dgvIncidencia.DataSource = Nothing
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
        Dim func As New fIncidencia
        txtIdIncidencia.Text = Format(func.Generar_Incidencia)
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Mostrar()
    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        Dim result As DialogResult
        result = MessageBox.Show("¿Realmente quiere modificar el registro?", "Modificando Registro", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)

        If result = DialogResult.OK Then
            If Me.ValidateChildren = True And txtIdIncidencia.Text <> 0 And txtIdEmpleado.Text <> "" And dtpFecha.Text <> "" And cmbTipo.Text <> "" And cmbArea.Text <> "" Then
                Try
                    Dim dts As New CIncidencia
                    Dim func As New fIncidencia

                    dts._idIncidencia = txtIdIncidencia.Text
                    dts._idEmpleado = txtIdEmpleado.Text
                    dts._fecha = dtpFecha.Value
                    dts._tIncidencia = cmbTipo.Text
                    dts._area = cmbArea.Text

                    If func.Modificar_Incidencia(dts) Then
                        MessageBox.Show("Incidencia modificada correctamente", "Modificando Registro", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Mostrar()
                        Limpiar()
                    Else
                        MessageBox.Show("Incidencia no modificada, intente de nuevo", "Modificando Registro", MessageBoxButtons.OK, MessageBoxIcon.Information)
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
        If Me.ValidateChildren = True And txtIdEmpleado.Text <> "" And dtpFecha.Text <> "" And cmbTipo.Text <> "" And cmbArea.Text <> "" Then
            Try
                Dim dts As New CIncidencia
                Dim func As New fIncidencia

                dts._idEmpleado = txtIdEmpleado.Text
                dts._fecha = dtpFecha.Value
                dts._tIncidencia = cmbTipo.Text
                dts._area = cmbArea.Text

                If func.Insertar_Incidencia(dts) Then
                    MessageBox.Show("Incidencia registrada correctamente", "Guardando Registro", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Mostrar()
                    Limpiar()
                Else
                    MessageBox.Show("Incidencia no registrada, intente de nuevo", "Guardando Registro", MessageBoxButtons.OK, MessageBoxIcon.Information)
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

    Private Sub frmIncidencia_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
        If DirectCast(sender, DateTimePicker).Value <> Nothing Then
            Me.erpErrorIcono.SetError(sender, "")
        Else
            Me.erpErrorIcono.SetError(sender, "Selecciona la Fecha de la Incidencia, Dato Obligatorio")
        End If
    End Sub

    Private Sub cmbTipo_Validating(sender As Object, e As CancelEventArgs) Handles cmbTipo.Validating
        If DirectCast(sender, ComboBox).Text.Length > 0 Then
            Me.erpErrorIcono.SetError(sender, "")
        Else
            Me.erpErrorIcono.SetError(sender, "Selecciona el Tipo de Incidencia, Dato Obligatorio")
        End If
    End Sub


    Private Sub cmbArea_Validating(sender As Object, e As CancelEventArgs) Handles cmbArea.Validating
        If DirectCast(sender, ComboBox).Text.Length > 0 Then
            Me.erpErrorIcono.SetError(sender, "")
        Else
            Me.erpErrorIcono.SetError(sender, "Selecciona el Área del Empleado, Dato Obligatorio")
        End If
    End Sub



    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Dim result As DialogResult
        result = MessageBox.Show("Realmente desea eliminar la información seleccionada", "Eliminación de Registro", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)

        If result = DialogResult.OK Then
            Try
                For Each row As DataGridViewRow In dgvIncidencia.Rows
                    Dim marcado As Boolean = Convert.ToBoolean(row.Cells("Eliminar").Value)

                    If marcado Then
                        Dim onekey As Integer = Convert.ToInt32(row.Cells("ID_Incidencia").Value)
                        Dim vdb As New CIncidencia
                        Dim func As New fIncidencia
                        vdb._idIncidencia = onekey

                        If func.Eliminar_Incidencia(vdb) Then
                        Else
                            MessageBox.Show("Incidencia no eliminado", "Eliminación de Registro", MessageBoxButtons.OK, MessageBoxIcon.Information)
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
            dgvIncidencia.Columns.Item("Eliminar").Visible = True
            btnEliminar.Visible = True
        Else
            dgvIncidencia.Columns.Item("Eliminar").Visible = False
            btnEliminar.Visible = False
        End If
    End Sub

    Private Sub dgvIncidencia_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvIncidencia.CellContentClick
        If e.ColumnIndex = Me.dgvIncidencia.Columns.Item("Eliminar").Index Then
            Dim chkcell As DataGridViewCheckBoxCell = Me.dgvIncidencia.Rows(e.RowIndex).Cells("Eliminar")
            chkcell.Value = Not chkcell.Value
        End If
    End Sub

    Private Sub dgvIncidencia_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvIncidencia.CellClick
        txtIdIncidencia.Text = dgvIncidencia.SelectedCells.Item(1).Value
        txtIdEmpleado.Text = dgvIncidencia.SelectedCells.Item(2).Value
        txtEmpleado.Text = dgvIncidencia.SelectedCells.Item(3).Value
        dtpFecha.Value = dgvIncidencia.SelectedCells.Item(4).Value
        cmbTipo.Text = dgvIncidencia.SelectedCells.Item(5).Value
        cmbArea.Text = dgvIncidencia.SelectedCells.Item(6).Value
        Activar()
        btnModificar.Enabled = True
        btnGuardar.Enabled = False
        btnCancelar.Enabled = True
        btnNuevo.Enabled = False
    End Sub

    Private Sub btnEmpleado_Click(sender As Object, e As EventArgs) Handles btnEmpleado.Click
        frmEmpleado.txtFlag.Text = "4"
        frmEmpleado.MdiParent = Crónos
        frmEmpleado.Show()
    End Sub

End Class