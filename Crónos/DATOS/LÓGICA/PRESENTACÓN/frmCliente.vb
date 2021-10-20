Imports System.ComponentModel

Public Class frmCliente
    Private dt As New DataTable
    Dim func As New fCliente

    Private Sub Limpiar()
        txtIdCliente.Text = ""
        txtCodigo.Text = ""
        txtNombre.Text = ""
        txtPaterno.Text = ""
        txtMaterno.Text = ""
        cmbtVialidad.Text = ""
        txtnVialidad.Text = ""
        txtColonia.Text = ""
        txtCiudad.Text = ""
        cmbEstado.Text = ""
        txtCP.Text = ""
        txtTelefono.Text = ""
        txtMail.Text = ""
    End Sub

    Private Sub Activar()
        txtNombre.Enabled = True
        txtPaterno.Enabled = True
        txtMaterno.Enabled = True
        cmbtVialidad.Enabled = True
        txtnVialidad.Enabled = True
        txtColonia.Enabled = True
        txtCiudad.Enabled = True
        cmbEstado.Enabled = True
        txtCP.Enabled = True
        txtTelefono.Enabled = True
        txtMail.Enabled = True
    End Sub

    Private Sub Desactivar()
        txtNombre.Enabled = False
        txtPaterno.Enabled = False
        txtMaterno.Enabled = False
        cmbtVialidad.Enabled = False
        txtnVialidad.Enabled = False
        txtColonia.Enabled = False
        txtCiudad.Enabled = False
        cmbEstado.Enabled = False
        txtCP.Enabled = False
        txtTelefono.Enabled = False
        txtMail.Enabled = False
    End Sub

    Private Sub Ocultar_Columnas()
        dgvCliente.Columns(1).Visible = False
        dgvCliente.Columns(6).Visible = False
        dgvCliente.Columns(7).Visible = False
        dgvCliente.Columns(8).Visible = False
        dgvCliente.Columns(9).Visible = False
        dgvCliente.Columns(10).Visible = False
        dgvCliente.Columns(11).Visible = False
        dgvCliente.Columns(12).Visible = False
        dgvCliente.Columns(13).Visible = False
    End Sub
    Private Sub Mostrar()
        Try
            Dim funcion As New fCliente
            dt = funcion.Mostrar_Cliente
            dgvCliente.Columns.Item("Eliminar").Visible = False

            If dt.Rows.Count <> 0 Then
                dgvCliente.DataSource = dt
                txtBuscado.Enabled = True
                dgvCliente.ColumnHeadersVisible = True
                llbInexistente.Visible = True
            Else
                dgvCliente.DataSource = Nothing
                txtBuscado.Enabled = False
                dgvCliente.ColumnHeadersVisible = False
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
                dgvCliente.DataSource = dv
                Ocultar_Columnas()
            Else
                llbInexistente.Visible = True
                dgvCliente.DataSource = Nothing
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
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
        codigo = Format(func.Generar_Cliente, "0000")
        txtIdCliente.Text = Format(func.Generar_Cliente)
        txtCodigo.Text = "CRONOSCLI" + codigo
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Mostrar()
    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        Dim result As DialogResult
        result = MessageBox.Show("¿Realmente quiere modificar el registro?", "Modificando Registro", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)

        If result = DialogResult.OK Then
            If Me.ValidateChildren = True And txtIdCliente.Text <> 0 And txtCodigo.Text <> "" And txtNombre.Text <> "" And txtPaterno.Text <> "" And txtMaterno.Text <> "" And cmbtVialidad.Text <> "" And txtnVialidad.Text <> "" And txtColonia.Text <> "" And txtCiudad.Text <> "" And cmbEstado.Text <> "" And txtCP.Text <> "" And txtTelefono.Text <> "" And txtMail.Text <> "" Then
                Try
                    Dim dts As New CCliente
                    Dim func As New fCliente

                    dts._idCliente = txtIdCliente.Text
                    dts._codigo = txtCodigo.Text
                    dts._nombre = txtNombre.Text
                    dts._paterno = txtPaterno.Text
                    dts._materno = txtMaterno.Text
                    dts._tVialidad = cmbtVialidad.Text
                    dts._nVialidad = txtnVialidad.Text
                    dts._colonia = txtColonia.Text
                    dts._ciudad = txtCiudad.Text
                    dts._estado = cmbEstado.Text
                    dts._cp = txtCP.Text
                    dts._telefono = txtTelefono.Text
                    dts._mail = txtMail.Text

                    If func.Modificar_Cliente(dts) Then
                        MessageBox.Show("Cliente modificado correctamente", "Modificando Registro", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Mostrar()
                        Limpiar()
                    Else
                        MessageBox.Show("Cliente no modificado, intente de nuevo", "Modificando Registro", MessageBoxButtons.OK, MessageBoxIcon.Information)
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
        If Me.ValidateChildren = True And txtCodigo.Text <> "" And txtNombre.Text <> "" And txtPaterno.Text <> "" And txtMaterno.Text <> "" And cmbtVialidad.Text <> "" And txtnVialidad.Text <> "" And txtColonia.Text <> "" And txtCiudad.Text <> "" And cmbEstado.Text <> "" And txtCP.Text <> "" And txtTelefono.Text <> "" And txtMail.Text <> "" Then
            Try
                Dim dts As New CCliente
                Dim func As New fCliente

                dts._codigo = txtCodigo.Text
                dts._nombre = txtNombre.Text
                dts._paterno = txtPaterno.Text
                dts._materno = txtMaterno.Text
                dts._tVialidad = cmbtVialidad.Text
                dts._nVialidad = txtnVialidad.Text
                dts._colonia = txtColonia.Text
                dts._ciudad = txtCiudad.Text
                dts._estado = cmbEstado.Text
                dts._cp = txtCP.Text
                dts._telefono = txtTelefono.Text
                dts._mail = txtMail.Text

                If func.Insertar_Cliente(dts) Then
                    MessageBox.Show("Cliente registrado correctamente", "Guardando Registro", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Mostrar()
                    Limpiar()
                Else
                    MessageBox.Show("Cliente no registrado, intente de nuevo", "Guardando Registro", MessageBoxButtons.OK, MessageBoxIcon.Information)
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

    Private Sub frmCliente_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
            Me.erpErrorIcono.SetError(sender, "Ingresa el Código del Cliente, Dato Obligatorio")
        End If
    End Sub

    Private Sub txtNombre_Validating(sender As Object, e As CancelEventArgs) Handles txtNombre.Validating
        If DirectCast(sender, TextBox).Text.Length > 0 Then
            Me.erpErrorIcono.SetError(sender, "")
        Else
            Me.erpErrorIcono.SetError(sender, "Ingresa el Nombre del Cliente, Dato Obligatorio")
        End If
    End Sub

    Private Sub txtPaterno_Validating(sender As Object, e As CancelEventArgs) Handles txtPaterno.Validating
        If DirectCast(sender, TextBox).Text.Length > 0 Then
            Me.erpErrorIcono.SetError(sender, "")
        Else
            Me.erpErrorIcono.SetError(sender, "Ingresa el Apellido Paterno del Cliente, Dato Obligatorio")
        End If
    End Sub

    Private Sub txtMaterno_Validating(sender As Object, e As CancelEventArgs) Handles txtMaterno.Validating
        If DirectCast(sender, TextBox).Text.Length > 0 Then
            Me.erpErrorIcono.SetError(sender, "")
        Else
            Me.erpErrorIcono.SetError(sender, "Ingresa el Apellido Materno del Cliente, Dato Obligatorio")
        End If
    End Sub

    Private Sub cmbtVialidad_Validating(sender As Object, e As CancelEventArgs)
        If DirectCast(sender, ComboBox).Text.Length > 0 Then
            Me.erpErrorIcono.SetError(sender, "")
        Else
            Me.erpErrorIcono.SetError(sender, "Selecciona el Tipo de Vialidad del Cliente, Dato Obligatorio")
        End If
    End Sub

    Private Sub txtnVialidad_Validating(sender As Object, e As CancelEventArgs)
        If DirectCast(sender, TextBox).Text.Length > 0 Then
            Me.erpErrorIcono.SetError(sender, "")
        Else
            Me.erpErrorIcono.SetError(sender, "Ingresa el Nombre de la Vialidad del Cliente, Dato Obligatorio")
        End If
    End Sub

    Private Sub txtColonia_Validating(sender As Object, e As CancelEventArgs)
        If DirectCast(sender, TextBox).Text.Length > 0 Then
            Me.erpErrorIcono.SetError(sender, "")
        Else
            Me.erpErrorIcono.SetError(sender, "Ingresa la Colonia del Cliente, Dato Obligatorio")
        End If
    End Sub

    Private Sub txtCiudad_Validating(sender As Object, e As CancelEventArgs)
        If DirectCast(sender, TextBox).Text.Length > 0 Then
            Me.erpErrorIcono.SetError(sender, "")
        Else
            Me.erpErrorIcono.SetError(sender, "Ingresa la Ciudad del Cliente, Dato Obligatorio")
        End If
    End Sub

    Private Sub cmbEstado_Validating(sender As Object, e As CancelEventArgs)
        If DirectCast(sender, ComboBox).Text.Length > 0 Then
            Me.erpErrorIcono.SetError(sender, "")
        Else
            Me.erpErrorIcono.SetError(sender, "Selecciona el Estado del Cliente, Dato Obligatorio")
        End If
    End Sub

    Private Sub txtCP_Validating(sender As Object, e As CancelEventArgs)
        If DirectCast(sender, TextBox).Text.Length > 0 Then
            Me.erpErrorIcono.SetError(sender, "")
        Else
            Me.erpErrorIcono.SetError(sender, "Ingresa el Código Postal del Cliente, Dato Obligatorio")
        End If
    End Sub

    Private Sub txtTelefono_Validating(sender As Object, e As CancelEventArgs) Handles txtTelefono.Validating
        If DirectCast(sender, TextBox).Text.Length > 0 Then
            Me.erpErrorIcono.SetError(sender, "")
        Else
            Me.erpErrorIcono.SetError(sender, "Ingresa el Teléfono del Cliente, Dato Obligatorio")
        End If
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Dim result As DialogResult
        result = MessageBox.Show("Realmente desea eliminar la información seleccionada", "Eliminación de Registro", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)

        If result = DialogResult.OK Then
            Try
                For Each row As DataGridViewRow In dgvCliente.Rows
                    Dim marcado As Boolean = Convert.ToBoolean(row.Cells("Eliminar").Value)

                    If marcado Then
                        Dim onekey As Integer = Convert.ToInt32(row.Cells("ID_Cliente").Value)
                        Dim vdb As New CCliente
                        Dim func As New fCliente
                        vdb._idCliente = onekey

                        If func.Eliminar_Cliente(vdb) Then
                        Else
                            MessageBox.Show("Cliente no eliminado", "Eliminación de Registro", MessageBoxButtons.OK, MessageBoxIcon.Information)
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
            dgvCliente.Columns.Item("Eliminar").Visible = True
            btnEliminar.Visible = True
        Else
            dgvCliente.Columns.Item("Eliminar").Visible = False
            btnEliminar.Visible = False
        End If
    End Sub

    Private Sub dgvCliente_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCliente.CellContentClick
        If e.ColumnIndex = Me.dgvCliente.Columns.Item("Eliminar").Index Then
            Dim chkcell As DataGridViewCheckBoxCell = Me.dgvCliente.Rows(e.RowIndex).Cells("Eliminar")
            chkcell.Value = Not chkcell.Value
        End If
    End Sub

    Private Sub dgvCliente_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCliente.CellClick
        txtIdCliente.Text = dgvCliente.SelectedCells.Item(1).Value
        txtCodigo.Text = dgvCliente.SelectedCells.Item(2).Value
        txtNombre.Text = dgvCliente.SelectedCells.Item(3).Value
        txtPaterno.Text = dgvCliente.SelectedCells.Item(4).Value
        txtMaterno.Text = dgvCliente.SelectedCells.Item(5).Value
        cmbtVialidad.Text = dgvCliente.SelectedCells.Item(6).Value
        txtnVialidad.Text = dgvCliente.SelectedCells.Item(7).Value
        txtColonia.Text = dgvCliente.SelectedCells.Item(8).Value
        txtCiudad.Text = dgvCliente.SelectedCells.Item(9).Value
        cmbEstado.Text = dgvCliente.SelectedCells.Item(10).Value
        txtCP.Text = dgvCliente.SelectedCells.Item(11).Value
        txtTelefono.Text = dgvCliente.SelectedCells.Item(12).Value
        txtMail.Text = dgvCliente.SelectedCells.Item(13).Value
        Activar()
        btnModificar.Enabled = True
        btnGuardar.Enabled = False
        btnCancelar.Enabled = True
        btnNuevo.Enabled = False
    End Sub

    Private Sub dgvCliente_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCliente.CellDoubleClick
        If txtFlag.Text = "1" Then
            frmVenta.txtIdCliente.Text = dgvCliente.SelectedCells.Item(1).Value
            frmVenta.txtCliente.Text = dgvCliente.SelectedCells.Item(3).Value
            Me.Close()
        End If
    End Sub
End Class