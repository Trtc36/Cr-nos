Imports System.ComponentModel
Public Class frmProveedor
    Private dt As New DataTable
    Dim func As New fProveedor

    Private Sub Limpiar()
        txtIdProveedor.Text = ""
        txtCodigo.Text = ""
        cmbTipo.Text = ""
        cmbPersonalidad.Text = ""
        txtRazonSocial.Text = ""
        txtNombre.Text = ""
        txtPaterno.Text = ""
        txtMaterno.Text = ""
        txtRFC.Text = ""
        cmbTVialidad.Text = ""
        txtNVialidad.Text = ""
        txtColonia.Text = ""
        txtCiudad.Text = ""
        cmbEstado.Text = ""
        txtCP.Text = ""
        txtTelefono.Text = ""
        txtMail.Text = ""
    End Sub

    Private Sub Activar()
        cmbTipo.Enabled = True
        cmbPersonalidad.Enabled = True
        txtRazonSocial.Enabled = True
        txtNombre.Enabled = True
        txtPaterno.Enabled = True
        txtMaterno.Enabled = True
        txtRFC.Enabled = True
        cmbTVialidad.Enabled = True
        txtNVialidad.Enabled = True
        txtColonia.Enabled = True
        txtCiudad.Enabled = True
        cmbEstado.Enabled = True
        txtCP.Enabled = True
        txtTelefono.Enabled = True
        btnEstructura.Enabled = True
        txtMail.Enabled = True
    End Sub

    Private Sub Desactivar()
        cmbTipo.Enabled = False
        cmbPersonalidad.Enabled = False
        txtRazonSocial.Enabled = False
        txtNombre.Enabled = False
        txtPaterno.Enabled = False
        txtMaterno.Enabled = False
        txtRFC.Enabled = False
        cmbTVialidad.Enabled = False
        txtNVialidad.Enabled = False
        txtColonia.Enabled = False
        txtCiudad.Enabled = False
        cmbEstado.Enabled = False
        txtCP.Enabled = False
        txtTelefono.Enabled = False
        btnEstructura.Enabled = False
        txtMail.Enabled = False
    End Sub

    Private Sub Ocultar_Columnas()
        dgvProveedor.Columns(1).Visible = False
        dgvProveedor.Columns(8).Visible = False
        dgvProveedor.Columns(10).Visible = False
        dgvProveedor.Columns(11).Visible = False
        dgvProveedor.Columns(12).Visible = False
        dgvProveedor.Columns(13).Visible = False
        dgvProveedor.Columns(14).Visible = False
        dgvProveedor.Columns(15).Visible = False
        dgvProveedor.Columns(16).Visible = False
        dgvProveedor.Columns(17).Visible = False
    End Sub

    Private Sub Mostrar()
        Try
            Dim funcion As New fProveedor
            dt = funcion.Mostrar_Proveedor
            dgvProveedor.Columns.Item("Eliminar").Visible = False

            If dt.Rows.Count <> 0 Then
                dgvProveedor.DataSource = dt
                txtBuscado.Enabled = True
                dgvProveedor.ColumnHeadersVisible = True
                llbInexistente.Visible = True
            Else
                dgvProveedor.DataSource = Nothing
                txtBuscado.Enabled = False
                dgvProveedor.ColumnHeadersVisible = False
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
                dgvProveedor.DataSource = dv
                Ocultar_Columnas()
            Else
                llbInexistente.Visible = True
                dgvProveedor.DataSource = Nothing
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub dgvProveedor_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvProveedor.CellDoubleClick
        If txtFlag.Text = "1" Then
            frmAgente.txtIdProveedor.Text = dgvProveedor.SelectedCells.Item(1).Value
            frmAgente.txtProveedor.Text = dgvProveedor.SelectedCells.Item(9).Value
            Me.Close()
        ElseIf txtFlag.Text = "2" Then
            frmProducto.txtIdProveedor.Text = dgvProveedor.SelectedCells.Item(1).Value
            frmProducto.txtProveedor.Text = dgvProveedor.SelectedCells.Item(2).Value
            Me.Close()
        ElseIf txtFlag.Text = "3" Then
            frmCompra.txtIdProveedor.Text = dgvProveedor.SelectedCells.Item(1).Value
            frmCompra.txtProveedor.Text = dgvProveedor.SelectedCells.Item(2).Value
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
        codigo = Format(func.Generar_Proveedor, "0000")
        txtIdProveedor.Text = Format(func.Generar_Proveedor)
        txtCodigo.Text = "CRONOSPROV" + codigo
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Mostrar()
    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        Dim result As DialogResult
        result = MessageBox.Show("¿Realmente quiere modificar el registro?", "Modificando Registro", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)

        If result = DialogResult.OK Then
            If Me.ValidateChildren = True And txtIdProveedor.Text <> 0 And txtCodigo.Text <> "" And cmbPersonalidad.Text <> "" And cmbTipo.Text <> "" And cmbTVialidad.Text <> "" And txtNVialidad.Text <> "" And txtColonia.Text <> "" And txtCiudad.Text <> "" And cmbEstado.Text <> "" And txtCP.Text <> "" And txtTelefono.Text <> "" And txtMail.Text <> "" Then
                Try
                    Dim dts As New CProveedor
                    Dim func As New fProveedor

                    dts._idProveedor = txtIdProveedor.Text
                    dts._codigo = txtCodigo.Text
                    dts._tProveedor = cmbTipo.Text
                    dts._personalidad = cmbPersonalidad.Text
                    dts._rSocial = txtRazonSocial.Text
                    dts._nombre = txtNombre.Text
                    dts._paterno = txtPaterno.Text
                    dts._materno = txtMaterno.Text
                    dts._RFC = txtRFC.Text
                    dts._tVialidad = cmbTVialidad.Text
                    dts._nVialidad = txtNVialidad.Text
                    dts._colonia = txtColonia.Text
                    dts._ciudad = txtCiudad.Text
                    dts._estado = cmbEstado.Text
                    dts._cp = txtCP.Text
                    dts._telefono = txtTelefono.Text
                    dts._mail = txtMail.Text


                    If func.Modificar_Proveedor(dts) Then
                        MessageBox.Show("Proveedor modificado correctamente", "Modificando Registro", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Mostrar()
                        Limpiar()
                    Else
                        MessageBox.Show("Proveedor no modificado, intente de nuevo", "Modificando Registro", MessageBoxButtons.OK, MessageBoxIcon.Information)
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
        If Me.ValidateChildren = True And txtCodigo.Text <> "" And cmbPersonalidad.Text <> "" And cmbTipo.Text <> "" And cmbTVialidad.Text <> "" And txtNVialidad.Text <> "" And txtColonia.Text <> "" And txtCiudad.Text <> "" And cmbEstado.Text <> "" And txtCP.Text <> "" And txtTelefono.Text <> "" And txtMail.Text <> "" Then
            Try
                Dim dts As New CProveedor
                Dim func As New fProveedor

                dts._codigo = txtCodigo.Text
                dts._tProveedor = cmbTipo.Text
                dts._personalidad = cmbPersonalidad.Text
                dts._rSocial = txtRazonSocial.Text
                dts._nombre = txtNombre.Text
                dts._paterno = txtPaterno.Text
                dts._materno = txtMaterno.Text
                dts._RFC = txtRFC.Text
                dts._tVialidad = cmbTVialidad.Text
                dts._nVialidad = txtNVialidad.Text
                dts._colonia = txtColonia.Text
                dts._ciudad = txtCiudad.Text
                dts._estado = cmbEstado.Text
                dts._cp = txtCP.Text
                dts._telefono = txtTelefono.Text
                dts._mail = txtMail.Text

                If func.Insertar_Proveedor(dts) Then
                    MessageBox.Show("Proveedor registrado correctamente", "Guardando Registro", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Mostrar()
                    Limpiar()
                Else
                    MessageBox.Show("Proveedor no registrado, intente de nuevo", "Guardando Registro", MessageBoxButtons.OK, MessageBoxIcon.Information)
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

    Private Sub frmProveedor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
            Me.erpErrorIcono.SetError(sender, "Ingresa el Código del Proveedor, Dato Obligatorio")
        End If
    End Sub

    Private Sub cmbTipo_Validating(sender As Object, e As CancelEventArgs) Handles cmbTipo.Validating
        If DirectCast(sender, ComboBox).Text.Length > 0 Then
            Me.erpErrorIcono.SetError(sender, "")
        Else
            Me.erpErrorIcono.SetError(sender, "Selecciona el Tipo del Proveedor, Dato Obligatorio")
        End If
    End Sub

    Private Sub cmbPersonalidad_Validating(sender As Object, e As CancelEventArgs) Handles cmbPersonalidad.Validating
        If DirectCast(sender, ComboBox).Text.Length > 0 Then
            Me.erpErrorIcono.SetError(sender, "")
        Else
            Me.erpErrorIcono.SetError(sender, "Selecciona la Personalidad del Proveedor, Dato Obligatorio")
        End If
    End Sub

    Private Sub txtRazonSocial_Validating(sender As Object, e As CancelEventArgs) Handles txtRazonSocial.Validating
        If cmbPersonalidad.Text = "Moral" Then
            If DirectCast(sender, TextBox).Text.Length > 0 Then
                Me.erpErrorIcono.SetError(sender, "")
            Else
                Me.erpErrorIcono.SetError(sender, "Ingresa la Razón Social del Proveedor, Dato Obligatorio")
            End If
        End If
    End Sub

    Private Sub txtNombre_Validating(sender As Object, e As CancelEventArgs) Handles txtNombre.Validating
        If cmbPersonalidad.Text = "Física" Then
            If DirectCast(sender, TextBox).Text.Length > 0 Then
                Me.erpErrorIcono.SetError(sender, "")
            Else
                Me.erpErrorIcono.SetError(sender, "Ingresa el Nombre del Proveedor, Dato Obligatorio")
            End If
        End If
    End Sub

    Private Sub txtPaterno_Validating(sender As Object, e As CancelEventArgs) Handles txtPaterno.Validating
        If cmbPersonalidad.Text = "Física" Then
            If DirectCast(sender, TextBox).Text.Length > 0 Then
                Me.erpErrorIcono.SetError(sender, "")
            Else
                Me.erpErrorIcono.SetError(sender, "Ingresa el Apellido Paterno del Proveedor, Dato Obligatorio")
            End If
        End If
    End Sub

    Private Sub txtMaterno_Validating(sender As Object, e As CancelEventArgs) Handles txtMaterno.Validating
        If cmbPersonalidad.Text = "Física" Then
            If DirectCast(sender, TextBox).Text.Length > 0 Then
                Me.erpErrorIcono.SetError(sender, "")
            Else
                Me.erpErrorIcono.SetError(sender, "Ingresa el Apellido Materno del Proveedor, Dato Obligatorio")
            End If
        End If
    End Sub

    Private Sub txtRFC_Validating(sender As Object, e As CancelEventArgs) Handles txtRFC.Validating
        If DirectCast(sender, TextBox).Text.Length > 0 Then
            Me.erpErrorIcono.SetError(sender, "")
        Else
            Me.erpErrorIcono.SetError(sender, "Ingresa el RFC del Proveedor, Dato Obligatorio")
        End If
    End Sub

    Private Sub cmbTVialidad_Validating(sender As Object, e As CancelEventArgs)
        If DirectCast(sender, ComboBox).Text.Length > 0 Then
            Me.erpErrorIcono.SetError(sender, "")
        Else
            Me.erpErrorIcono.SetError(sender, "Selecciona el Tipo de Vialidad del Proveedor, Dato Obligatorio")
        End If
    End Sub

    Private Sub txtNVialidad_Validating(sender As Object, e As CancelEventArgs)
        If DirectCast(sender, TextBox).Text.Length > 0 Then
            Me.erpErrorIcono.SetError(sender, "")
        Else
            Me.erpErrorIcono.SetError(sender, "Ingresa el Nombre de la Vialidad del Proveedor, Dato Obligatorio")
        End If
    End Sub

    Private Sub txtColonia_Validating(sender As Object, e As CancelEventArgs)
        If DirectCast(sender, TextBox).Text.Length > 0 Then
            Me.erpErrorIcono.SetError(sender, "")
        Else
            Me.erpErrorIcono.SetError(sender, "Ingresa la Colonia del Proveedor, Dato Obligatorio")
        End If
    End Sub

    Private Sub txtCiudad_Validating(sender As Object, e As CancelEventArgs)
        If DirectCast(sender, TextBox).Text.Length > 0 Then
            Me.erpErrorIcono.SetError(sender, "")
        Else
            Me.erpErrorIcono.SetError(sender, "Ingresa la Ciudad del Proveedor, Dato Obligatorio")
        End If
    End Sub

    Private Sub cmbEstado_Validating(sender As Object, e As CancelEventArgs)
        If DirectCast(sender, ComboBox).Text.Length > 0 Then
            Me.erpErrorIcono.SetError(sender, "")
        Else
            Me.erpErrorIcono.SetError(sender, "Selecciona el Estado del Proveedor, Dato Obligatorio")
        End If
    End Sub

    Private Sub txtCP_Validating(sender As Object, e As CancelEventArgs)
        If DirectCast(sender, TextBox).Text.Length > 0 Then
            Me.erpErrorIcono.SetError(sender, "")
        Else
            Me.erpErrorIcono.SetError(sender, "Ingresa Código Postal del Proveedor, Dato Obligatorio")
        End If
    End Sub

    Private Sub txtTelefono_Validating(sender As Object, e As CancelEventArgs) Handles txtTelefono.Validating
        If DirectCast(sender, TextBox).Text.Length > 0 Then
            Me.erpErrorIcono.SetError(sender, "")
        Else
            Me.erpErrorIcono.SetError(sender, "Ingresa el Télefono del Proveedor, Dato Obligatorio")
        End If
    End Sub

    Private Sub txtMail_Validating(sender As Object, e As CancelEventArgs) Handles txtMail.Validating
        If DirectCast(sender, TextBox).Text.Length > 0 Then
            Me.erpErrorIcono.SetError(sender, "")
        Else
            Me.erpErrorIcono.SetError(sender, "Ingresa el E-mail del Proveedor, Dato Obligatorio")
        End If
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Dim result As DialogResult
        result = MessageBox.Show("Realmente desea eliminar la información seleccionada", "Eliminación de Registro", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)

        If result = DialogResult.OK Then
            Try
                For Each row As DataGridViewRow In dgvProveedor.Rows
                    Dim marcado As Boolean = Convert.ToBoolean(row.Cells("Eliminar").Value)

                    If marcado Then
                        Dim onekey As Integer = Convert.ToInt32(row.Cells("ID_Proveedor").Value)
                        Dim vdb As New CProveedor
                        Dim func As New fProveedor
                        vdb._idProveedor = onekey

                        If func.Eliminar_Proveedor(vdb) Then
                        Else
                            MessageBox.Show("Proveedor no eliminado", "Eliminación de Registro", MessageBoxButtons.OK, MessageBoxIcon.Information)
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
            dgvProveedor.Columns.Item("Eliminar").Visible = True
            btnEliminar.Visible = True
        Else
            dgvProveedor.Columns.Item("Eliminar").Visible = False
            btnEliminar.Visible = False
        End If
    End Sub

    Private Sub dgvProveedor_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvProveedor.CellContentClick
        If e.ColumnIndex = Me.dgvProveedor.Columns.Item("Eliminar").Index Then
            Dim chkcell As DataGridViewCheckBoxCell = Me.dgvProveedor.Rows(e.RowIndex).Cells("Eliminar")
            chkcell.Value = Not chkcell.Value
        End If
    End Sub

    Private Sub dgvProveedor_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvProveedor.CellClick
        txtIdProveedor.Text = dgvProveedor.SelectedCells.Item(1).Value
        txtCodigo.Text = dgvProveedor.SelectedCells.Item(2).Value
        cmbTipo.Text = dgvProveedor.SelectedCells.Item(3).Value
        cmbPersonalidad.Text = dgvProveedor.SelectedCells.Item(4).Value
        txtRazonSocial.Text = dgvProveedor.SelectedCells.Item(5).Value
        txtNombre.Text = dgvProveedor.SelectedCells.Item(6).Value
        txtPaterno.Text = dgvProveedor.SelectedCells.Item(7).Value
        txtMaterno.Text = dgvProveedor.SelectedCells.Item(8).Value
        txtRFC.Text = dgvProveedor.SelectedCells.Item(9).Value
        cmbTVialidad.Text = dgvProveedor.SelectedCells.Item(10).Value
        txtNVialidad.Text = dgvProveedor.SelectedCells.Item(11).Value
        txtColonia.Text = dgvProveedor.SelectedCells.Item(12).Value
        txtCiudad.Text = dgvProveedor.SelectedCells.Item(13).Value
        cmbEstado.Text = dgvProveedor.SelectedCells.Item(14).Value
        txtCP.Text = dgvProveedor.SelectedCells.Item(15).Value
        txtTelefono.Text = dgvProveedor.SelectedCells.Item(16).Value
        txtMail.Text = dgvProveedor.SelectedCells.Item(17).Value
        Activar()
        btnModificar.Enabled = True
        btnGuardar.Enabled = False
        btnCancelar.Enabled = True
        btnNuevo.Enabled = False
    End Sub

    Private Sub cmbPersonalidad_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPersonalidad.SelectedIndexChanged
        If cmbPersonalidad.Text = "FÍSICA" Then
            txtRazonSocial.Enabled = False
            txtNombre.Enabled = True
            txtPaterno.Enabled = True
            txtMaterno.Enabled = True
        ElseIf cmbPersonalidad.Text = "MORAL" Then
            txtRazonSocial.Enabled = True
            txtNombre.Enabled = False
            txtPaterno.Enabled = False
            txtMaterno.Enabled = False
        End If
    End Sub
End Class