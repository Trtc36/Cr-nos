Imports System.ComponentModel
Public Class frmEmpleado
    Private dt As New DataTable
    Dim func As New fEmpleado

    Public Sub Limpiar()
        txtIdEmpleado.Text = ""
        txtCodigo.Text = ""
        txtNombre.Text = ""
        txtPaterno.Text = ""
        txtMaterno.Text = ""
        dtpNacimiento.Value = Date.Today
        cmbtVialidad.Text = ""
        txtnVialidad.Text = ""
        txtColonia.Text = ""
        txtCiudad.Text = ""
        cmbEstado.Text = ""
        txtCP.Text = ""
        txtTelefono.Text = ""
        txtMail.Text = ""
        cmbEstatus.Text = ""
        txtIdPuesto.Text = ""
        txtPuesto.Text = ""
        txtIdCarrera.Text = ""
        txtCarrera.Text = ""
        dtpIngreso.Value = Date.Today
        dtpSalida.Value = Date.Today
    End Sub
    Private Sub Activar()
        txtNombre.Enabled = True
        txtPaterno.Enabled = True
        txtMaterno.Enabled = True
        dtpNacimiento.Enabled = True
        cmbtVialidad.Enabled = True
        txtnVialidad.Enabled = True
        txtColonia.Enabled = True
        txtCiudad.Enabled = True
        cmbEstado.Enabled = True
        txtCP.Enabled = True
        txtTelefono.Enabled = True
        txtMail.Enabled = True
        cmbEstatus.Enabled = True
        dtpIngreso.Enabled = True
        dtpSalida.Enabled = True
        btnPuesto.Enabled = True
        btnCarrera.Enabled = True
        btnEstructura.Enabled = True
    End Sub

    Public Sub Desactivar()
        txtNombre.Enabled = False
        txtPaterno.Enabled = False
        txtMaterno.Enabled = False
        dtpNacimiento.Enabled = False
        cmbtVialidad.Enabled = False
        txtnVialidad.Enabled = False
        txtColonia.Enabled = False
        txtCiudad.Enabled = False
        cmbEstado.Enabled = False
        txtCP.Enabled = False
        txtTelefono.Enabled = False
        txtMail.Enabled = False
        cmbEstatus.Enabled = False
        dtpIngreso.Enabled = False
        dtpSalida.Enabled = False
        btnPuesto.Enabled = False
        btnCarrera.Enabled = False
        btnEstructura.Enabled = False
    End Sub

    Public Sub Ocultar_Columnas()
        dgvEmpleado.Columns(1).Visible = False
        dgvEmpleado.Columns(5).Visible = False
        dgvEmpleado.Columns(6).Visible = False
        dgvEmpleado.Columns(7).Visible = False
        dgvEmpleado.Columns(8).Visible = False
        dgvEmpleado.Columns(9).Visible = False
        dgvEmpleado.Columns(10).Visible = False
        dgvEmpleado.Columns(11).Visible = False
        dgvEmpleado.Columns(12).Visible = False
        dgvEmpleado.Columns(13).Visible = False
        dgvEmpleado.Columns(14).Visible = False
        dgvEmpleado.Columns(15).Visible = False
        dgvEmpleado.Columns(16).Visible = False
        dgvEmpleado.Columns(17).Visible = False
        dgvEmpleado.Columns(18).Visible = False
        dgvEmpleado.Columns(20).Visible = False
    End Sub

    Public Sub Mostrar()
        Try
            Dim funcion As New fEmpleado
            dt = funcion.Mostrar_Empleado
            dgvEmpleado.Columns.Item("Eliminar").Visible = False

            If dt.Rows.Count <> 0 Then
                dgvEmpleado.DataSource = dt
                txtBuscado.Enabled = True
                dgvEmpleado.ColumnHeadersVisible = True
                llbInexistente.Visible = True
            Else
                dgvEmpleado.DataSource = Nothing
                txtBuscado.Enabled = False
                dgvEmpleado.ColumnHeadersVisible = False
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
                dgvEmpleado.DataSource = dv
                Ocultar_Columnas()
            Else
                llbInexistente.Visible = True
                dgvEmpleado.DataSource = Nothing
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub dgvEmpleado_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvEmpleado.CellDoubleClick
        If txtFlag.Text = "1" Then
            frmCapacitacionEmpleado.txtIdEmpleado.Text = dgvEmpleado.SelectedCells.Item(1).Value
            frmCapacitacionEmpleado.txtEmpleado.Text = dgvEmpleado.SelectedCells.Item(3).Value
            Me.Close()
        ElseIf txtFlag.Text = "2" Then
            frmDesempeño.txtIdEmpleado.Text = dgvEmpleado.SelectedCells.Item(1).Value
            frmDesempeño.txtEmpleado.Text = dgvEmpleado.SelectedCells.Item(3).Value
            Me.Close()
        ElseIf txtFlag.Text = "3" Then
            frmHistorialSueldos.txtIdEmpleado.Text = dgvEmpleado.SelectedCells.Item(1).Value
            frmHistorialSueldos.txtCEmpleado.Text = dgvEmpleado.SelectedCells.Item(2).Value
            frmHistorialSueldos.txtNEmpleado.Text = dgvEmpleado.SelectedCells.Item(3).Value
            frmHistorialSueldos.txtPEmpleado.Text = dgvEmpleado.SelectedCells.Item(4).Value
            frmHistorialSueldos.txtMEmpleado.Text = dgvEmpleado.SelectedCells.Item(5).Value
            Me.Close()
        ElseIf txtFlag.Text = "4" Then
            frmIncidencia.txtIdEmpleado.Text = dgvEmpleado.SelectedCells.Item(1).Value
            frmIncidencia.txtEmpleado.Text = dgvEmpleado.SelectedCells.Item(3).Value
            Me.Close()
        ElseIf txtFlag.Text = "6" Then
            frmReconocimiento.txtIdEmpleado.Text = dgvEmpleado.SelectedCells.Item(1).Value
            frmReconocimiento.txtEmpleado.Text = dgvEmpleado.SelectedCells.Item(3).Value
            Me.Close()
        ElseIf txtFlag.Text = "7" Then
            frmUsuario.txtIdEmpleado.Text = dgvEmpleado.SelectedCells.Item(1).Value
            frmUsuario.txtNEmpleado.Text = dgvEmpleado.SelectedCells.Item(3).Value
            frmUsuario.txtPEmpleado.Text = dgvEmpleado.SelectedCells.Item(4).Value
            frmUsuario.txtMEmpleado.Text = dgvEmpleado.SelectedCells.Item(5).Value
            Me.Close()
        ElseIf txtFlag.Text = "8" Then
            frmVenta.txtIdEmpleado.Text = dgvEmpleado.SelectedCells.Item(1).Value
            frmVenta.txtEmpleado.Text = dgvEmpleado.SelectedCells.Item(3).Value
            Me.Close()
        End If
    End Sub

    Private Sub btnEstructura_Click(sender As Object, e As EventArgs) Handles btnEstructura.Click
        Dim telefonoinicial() As Char = txtTelefono.Text.ToArray

        If IsNumeric(txtTelefono.Text) Then
            If telefonoinicial.Length < 10 Then
                MessageBox.Show("El número debe tener 10 dígitos", "Error en teléfono", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtTelefono.Text = ""
                txtTelefono.Focus()
            Else
                Dim telefonofinal = "(" + telefonoinicial(0) + telefonoinicial(1) + telefonoinicial(2) + ")" + "-" + telefonoinicial(3) + telefonoinicial(4) + telefonoinicial(5) + "-" + telefonoinicial(6) + telefonoinicial(7) + telefonoinicial(8) + telefonoinicial(9)
                txtTelefono.Text = telefonofinal
                txtMail.Focus()
            End If
        Else
            MessageBox.Show("Debe ingresar solo numeros", "Error en teléfono", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtTelefono.Text = ""
            txtTelefono.Focus()
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
        codigo = Format(func.Generar_Empleado, "0000")
        txtIdEmpleado.Text = Format(func.Generar_Empleado)
        txtCodigo.Text = "CRONOSEMP" + codigo
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Mostrar()
    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        Dim result As DialogResult
        result = MessageBox.Show("¿Realmente quiere modificar el registro?", "Modificando Registro", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)

        If result = DialogResult.OK Then
            If Me.ValidateChildren = True And txtIdEmpleado.Text <> 0 And txtCodigo.Text <> "" And txtNombre.Text <> "" And txtPaterno.Text <> "" And txtMaterno.Text <> "" And dtpNacimiento.Value <> Nothing And cmbtVialidad.Text <> "" And txtnVialidad.Text <> "" And txtColonia.Text <> "" And txtCiudad.Text <> "" And cmbEstado.Text <> "" And txtCP.Text <> "" And txtTelefono.Text <> "" And txtMail.Text <> "" And cmbEstatus.Text <> "" And dtpIngreso.Value <> Nothing And dtpSalida.Value <> Nothing And txtIdPuesto.Text <> "" And txtIdCarrera.Text <> "" Then
                Try
                    Dim dts As New CEmpleado
                    Dim func As New fEmpleado

                    dts._idEmpleado = txtIdEmpleado.Text
                    dts._codigo = txtCodigo.Text
                    dts._nombre = txtNombre.Text
                    dts._paterno = txtPaterno.Text
                    dts._materno = txtMaterno.Text
                    dts._fNacimiento = dtpNacimiento.Value
                    dts._tVialidad = cmbtVialidad.Text
                    dts._nVialidad = txtnVialidad.Text
                    dts._colonia = txtColonia.Text
                    dts._ciudad = txtCiudad.Text
                    dts._estado = cmbEstado.Text
                    dts._cp = txtCP.Text
                    dts._telefono = txtTelefono.Text
                    dts._mail = txtMail.Text
                    dts._estatus = cmbEstatus.Text
                    dts._fIngreso = dtpIngreso.Value
                    dts._fSalida = dtpSalida.Value
                    dts._idPuesto = txtIdPuesto.Text
                    dts._idCarrera = txtIdCarrera.Text

                    If func.Modificar_Empleado(dts) Then
                        MessageBox.Show("Empleado modificado correctamente", "Modificando Registro", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Mostrar()
                        Limpiar()
                    Else
                        MessageBox.Show("Empleado no modificado, intente de nuevo", "Modificando Registro", MessageBoxButtons.OK, MessageBoxIcon.Information)
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
        If Me.ValidateChildren = True And txtCodigo.Text <> "" And txtNombre.Text <> "" And txtPaterno.Text <> "" And txtMaterno.Text <> "" And dtpNacimiento.Value <> Nothing And cmbtVialidad.Text <> "" And txtnVialidad.Text <> "" And txtColonia.Text <> "" And txtCiudad.Text <> "" And cmbEstado.Text <> "" And txtCP.Text <> "" And txtTelefono.Text <> "" And txtMail.Text <> "" And cmbEstatus.Text <> "" And dtpIngreso.Value <> Nothing And dtpSalida.Value <> Nothing And txtIdPuesto.Text <> "" And txtIdCarrera.Text <> "" Then
            Try
                Dim dts As New CEmpleado
                Dim func As New fEmpleado

                dts._codigo = txtCodigo.Text
                dts._nombre = txtNombre.Text
                dts._paterno = txtPaterno.Text
                dts._materno = txtMaterno.Text
                dts._fNacimiento = dtpNacimiento.Value
                dts._tVialidad = cmbtVialidad.Text
                dts._nVialidad = txtnVialidad.Text
                dts._colonia = txtColonia.Text
                dts._ciudad = txtCiudad.Text
                dts._estado = cmbEstado.Text
                dts._cp = txtCP.Text
                dts._telefono = txtTelefono.Text
                dts._mail = txtMail.Text
                dts._estatus = cmbEstatus.Text
                dts._fIngreso = dtpIngreso.Value
                dts._fSalida = dtpSalida.Value
                dts._idPuesto = txtIdPuesto.Text
                dts._idCarrera = txtIdCarrera.Text

                If func.Insertar_Empleado(dts) Then
                    MessageBox.Show("Empleado registrado correctamente", "Guardando Registro", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Mostrar()
                    Limpiar()
                Else
                    MessageBox.Show("Empleado no registrado, intente de nuevo", "Guardando Registro", MessageBoxButtons.OK, MessageBoxIcon.Information)
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

    Private Sub frmEmpleado_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
            Me.erpErrorIcono.SetError(sender, "Ingresa el Código del Empleado, Dato Obligatorio")
        End If
    End Sub

    Private Sub txtNombre_Validating(sender As Object, e As CancelEventArgs) Handles txtNombre.Validating
        If DirectCast(sender, TextBox).Text.Length > 0 Then
            Me.erpErrorIcono.SetError(sender, "")
        Else
            Me.erpErrorIcono.SetError(sender, "Ingresa el Nombre del Empleado, Dato Obligatorio")
        End If
    End Sub

    Private Sub txtPaterno_Validating(sender As Object, e As CancelEventArgs) Handles txtPaterno.Validating
        If DirectCast(sender, TextBox).Text.Length > 0 Then
            Me.erpErrorIcono.SetError(sender, "")
        Else
            Me.erpErrorIcono.SetError(sender, "Ingresa el Apellido Paterno del Empleado, Dato Obligatorio")
        End If
    End Sub

    Private Sub txtMaterno_Validating(sender As Object, e As CancelEventArgs) Handles txtMaterno.Validating
        If DirectCast(sender, TextBox).Text.Length > 0 Then
            Me.erpErrorIcono.SetError(sender, "")
        Else
            Me.erpErrorIcono.SetError(sender, "Ingresa el Apellido Materno del Empleado, Dato Obligatorio")
        End If
    End Sub

    Private Sub dtpNacimiento_Validating(sender As Object, e As CancelEventArgs) Handles dtpNacimiento.Validating
        If DirectCast(sender, DateTimePicker).Value <> Nothing Then
            Me.erpErrorIcono.SetError(sender, "")
        Else
            Me.erpErrorIcono.SetError(sender, "Selecciona la Fecha de Nacimiento del Empleado, Dato Obligatorio")
        End If
    End Sub

    Private Sub cmbtVialidad_Validating(sender As Object, e As CancelEventArgs)
        If DirectCast(sender, ComboBox).Text.Length > 0 Then
            Me.erpErrorIcono.SetError(sender, "")
        Else
            Me.erpErrorIcono.SetError(sender, "Seleccione el Tipo de Vialidad del Empleado, Dato Obligatorio")
        End If
    End Sub

    Private Sub txtnVialidad_Validating(sender As Object, e As CancelEventArgs)
        If DirectCast(sender, TextBox).Text.Length > 0 Then
            Me.erpErrorIcono.SetError(sender, "")
        Else
            Me.erpErrorIcono.SetError(sender, "Ingresa el Nombre de la Vialidad del Empleado, Dato Obligatorio")
        End If
    End Sub

    Private Sub txtColonia_Validating(sender As Object, e As CancelEventArgs)
        If DirectCast(sender, TextBox).Text.Length > 0 Then
            Me.erpErrorIcono.SetError(sender, "")
        Else
            Me.erpErrorIcono.SetError(sender, "Ingresa La Colonia del Empleado, Dato Obligatorio")
        End If
    End Sub

    Private Sub txtCiudad_Validating(sender As Object, e As CancelEventArgs)
        If DirectCast(sender, TextBox).Text.Length > 0 Then
            Me.erpErrorIcono.SetError(sender, "")
        Else
            Me.erpErrorIcono.SetError(sender, "Ingresa la Ciudad del Empleado, Dato Obligatorio")
        End If
    End Sub

    Private Sub cmbEstado_Validating(sender As Object, e As CancelEventArgs)
        If DirectCast(sender, ComboBox).Text.Length > 0 Then
            Me.erpErrorIcono.SetError(sender, "")
        Else
            Me.erpErrorIcono.SetError(sender, "Selecciona el Estado del Empleado, Dato Obligatorio")
        End If
    End Sub

    Private Sub txtCP_Validating(sender As Object, e As CancelEventArgs)
        If DirectCast(sender, TextBox).Text.Length > 0 Then
            Me.erpErrorIcono.SetError(sender, "")
        Else
            Me.erpErrorIcono.SetError(sender, "Ingresa el Código Postal del Empleado, Dato Obligatorio")
        End If
    End Sub

    Private Sub txtTelefono_Validating(sender As Object, e As CancelEventArgs) Handles txtTelefono.Validating
        If DirectCast(sender, TextBox).Text.Length > 0 Then
            Me.erpErrorIcono.SetError(sender, "")
        Else
            Me.erpErrorIcono.SetError(sender, "Ingresa el Teléfono del Empleado, Dato Obligatorio")
        End If
    End Sub

    Private Sub txtMail_Validating(sender As Object, e As CancelEventArgs) Handles txtMail.Validating
        If DirectCast(sender, TextBox).Text.Length > 0 Then
            Me.erpErrorIcono.SetError(sender, "")
        Else
            Me.erpErrorIcono.SetError(sender, "Ingresa el E-mail del Empleado, Dato Obligatorio")
        End If
    End Sub

    Private Sub dtpIngreso_Validating(sender As Object, e As CancelEventArgs) Handles dtpIngreso.Validating
        If DirectCast(sender, DateTimePicker).Value <> Nothing Then
            Me.erpErrorIcono.SetError(sender, "")
        Else
            Me.erpErrorIcono.SetError(sender, "Selecciona la Fecha de Ingreso del Empleado, Dato Obligatorio")
        End If
    End Sub

    Private Sub dtpSalida_Validating(sender As Object, e As CancelEventArgs) Handles dtpSalida.Validating
        If DirectCast(sender, DateTimePicker).Value <> Nothing Then
            Me.erpErrorIcono.SetError(sender, "")
        Else
            Me.erpErrorIcono.SetError(sender, "Selecciona la Fecha de Salida del Empleado, Dato Obligatorio")
        End If
    End Sub

    Private Sub txtIdPuesto_Validating(sender As Object, e As CancelEventArgs) Handles txtIdPuesto.Validating
        If DirectCast(sender, TextBox).Text.Length > 0 Then
            Me.erpErrorIcono.SetError(sender, "")
        Else
            Me.erpErrorIcono.SetError(sender, "Ingresa el ID del Puesto del Empleado, Dato Obligatorio")
        End If
    End Sub

    Private Sub txtIdCarrera_Validating(sender As Object, e As CancelEventArgs) Handles txtIdCarrera.Validating
        If DirectCast(sender, TextBox).Text.Length > 0 Then
            Me.erpErrorIcono.SetError(sender, "")
        Else
            Me.erpErrorIcono.SetError(sender, "Ingresa el ID de la Carrera del Empleado, Dato Obligatorio")
        End If
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Dim result As DialogResult
        result = MessageBox.Show("Realmente desea eliminar la información seleccionada", "Eliminación de Registro", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)

        If result = DialogResult.OK Then
            Try
                For Each row As DataGridViewRow In dgvEmpleado.Rows
                    Dim marcado As Boolean = Convert.ToBoolean(row.Cells("Eliminar").Value)

                    If marcado Then
                        Dim onekey As Integer = Convert.ToInt32(row.Cells("ID_Empleado").Value)
                        Dim vdb As New CEmpleado
                        Dim func As New fEmpleado
                        vdb._idEmpleado = onekey

                        If func.Eliminar_Empleado(vdb) Then
                        Else
                            MessageBox.Show("Empleado no eliminado", "Eliminación de Registro", MessageBoxButtons.OK, MessageBoxIcon.Information)
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
            dgvEmpleado.Columns.Item("Eliminar").Visible = True
            btnEliminar.Visible = True
        Else
            dgvEmpleado.Columns.Item("Eliminar").Visible = False
            btnEliminar.Visible = False
        End If
    End Sub

    Private Sub dgvEmpleado_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvEmpleado.CellContentClick
        If e.ColumnIndex = Me.dgvEmpleado.Columns.Item("Eliminar").Index Then
            Dim chkcell As DataGridViewCheckBoxCell = Me.dgvEmpleado.Rows(e.RowIndex).Cells("Eliminar")
            chkcell.Value = Not chkcell.Value
        End If
    End Sub

    Private Sub dgvEmpleado_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvEmpleado.CellClick
        txtIdEmpleado.Text = dgvEmpleado.SelectedCells.Item(1).Value
        txtCodigo.Text = dgvEmpleado.SelectedCells.Item(2).Value
        txtNombre.Text = dgvEmpleado.SelectedCells.Item(3).Value
        txtPaterno.Text = dgvEmpleado.SelectedCells.Item(4).Value
        txtMaterno.Text = dgvEmpleado.SelectedCells.Item(5).Value
        dtpNacimiento.Value = dgvEmpleado.SelectedCells.Item(6).Value
        cmbtVialidad.Text = dgvEmpleado.SelectedCells.Item(7).Value
        txtnVialidad.Text = dgvEmpleado.SelectedCells.Item(8).Value
        txtColonia.Text = dgvEmpleado.SelectedCells.Item(9).Value
        txtCiudad.Text = dgvEmpleado.SelectedCells.Item(10).Value
        cmbEstado.Text = dgvEmpleado.SelectedCells.Item(11).Value
        txtCP.Text = dgvEmpleado.SelectedCells.Item(12).Value
        txtTelefono.Text = dgvEmpleado.SelectedCells.Item(13).Value
        txtMail.Text = dgvEmpleado.SelectedCells.Item(14).Value
        cmbEstatus.Text = dgvEmpleado.SelectedCells.Item(15).Value
        dtpIngreso.Value = dgvEmpleado.SelectedCells.Item(16).Value
        dtpSalida.Value = dgvEmpleado.SelectedCells.Item(17).Value
        txtIdPuesto.Text = dgvEmpleado.SelectedCells.Item(18).Value
        txtPuesto.Text = dgvEmpleado.SelectedCells.Item(19).Value
        txtIdCarrera.Text = dgvEmpleado.SelectedCells.Item(20).Value
        txtCarrera.Text = dgvEmpleado.SelectedCells.Item(21).Value
        Activar()
        btnModificar.Enabled = True
        btnGuardar.Enabled = False
        btnCancelar.Enabled = True
        btnNuevo.Enabled = False
    End Sub

    Private Sub btnPuesto_Click(sender As Object, e As EventArgs) Handles btnPuesto.Click
        frmPuesto.txtFlag.Text = "1"
        frmPuesto.MdiParent = Crónos
        frmPuesto.Show()
    End Sub

    Private Sub btnCarrera_Click(sender As Object, e As EventArgs) Handles btnCarrera.Click
        frmCarrera.txtFlag.Text = "1"
        frmCarrera.MdiParent = Crónos
        frmCarrera.Show()
    End Sub

    Private Sub cmbEstatus_Validating(sender As Object, e As CancelEventArgs) Handles cmbEstatus.Validating
        If DirectCast(sender, ComboBox).Text.Length > 0 Then
            Me.erpErrorIcono.SetError(sender, "")
        Else
            Me.erpErrorIcono.SetError(sender, "Selecciona el Estatus del Empleado, Dato Obligatorio")
        End If
    End Sub

End Class