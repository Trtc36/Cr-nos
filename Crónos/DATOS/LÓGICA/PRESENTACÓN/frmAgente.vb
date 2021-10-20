Imports System.ComponentModel

Public Class frmAgente
    Private dt As New DataTable
    Dim func As New fAgente

    Public Sub Limpiar()
        txtIdAgente.Text = ""
        txtCodigo.Text = ""
        txtNombre.Text = ""
        txtPaterno.Text = ""
        txtMaterno.Text = ""
        txtTelefono.Text = ""
        txtMail.Text = ""
        txtIdProveedor.Text = ""
        txtProveedor.Text = ""
    End Sub

    Public Sub Activar()
        txtNombre.Enabled = True
        txtPaterno.Enabled = True
        txtMaterno.Enabled = True
        txtTelefono.Enabled = True
        txtMail.Enabled = True
        btnProveedor.Enabled = True
    End Sub

    Public Sub Desactivar()
        txtNombre.Enabled = False
        txtPaterno.Enabled = False
        txtMaterno.Enabled = False
        txtTelefono.Enabled = False
        txtMail.Enabled = False
        btnProveedor.Enabled = False
    End Sub

    Public Sub Ocultar_Columnas()
        dgvAgente.Columns(1).Visible = False
        dgvAgente.Columns(6).Visible = False
        dgvAgente.Columns(7).Visible = False
        dgvAgente.Columns(8).Visible = False
    End Sub

    Public Sub Mostrar()
        Try
            Dim funcion As New fAgente
            dt = funcion.Mostrar_Agente
            dgvAgente.Columns.Item("Eliminar").Visible = False

            If dt.Rows.Count <> 0 Then
                dgvAgente.DataSource = dt
                txtBuscado.Enabled = True
                dgvAgente.ColumnHeadersVisible = True
                llbInexistente.Visible = True
            Else
                dgvAgente.DataSource = Nothing
                txtBuscado.Enabled = False
                dgvAgente.ColumnHeadersVisible = False
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
                dgvAgente.DataSource = dv
                Ocultar_Columnas()
            Else
                llbInexistente.Visible = True
                dgvAgente.DataSource = Nothing
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
        codigo = Format(func.Generar_Agente, "0000")
        txtIdAgente.Text = Format(func.Generar_Agente)
        txtCodigo.Text = "CRONOSAGE" + codigo
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Mostrar()
    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        Dim result As DialogResult
        result = MessageBox.Show("¿Realmente quiere modificar el registro?", "Modificando Registro", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)

        If result = DialogResult.OK Then
            If Me.ValidateChildren = True And txtIdAgente.Text <> 0 And txtCodigo.Text <> "" And txtNombre.Text <> "" And txtPaterno.Text <> "" And txtMaterno.Text <> "" And txtTelefono.Text <> "" And txtMail.Text <> "" And txtIdProveedor.Text <> "" Then
                Try
                    Dim dts As New CAgente
                    Dim func As New fAgente

                    dts._idAgente = txtIdAgente.Text
                    dts._codigo = txtCodigo.Text
                    dts._nombre = txtNombre.Text
                    dts._paterno = txtPaterno.Text
                    dts._materno = txtMaterno.Text
                    dts._telefono = txtTelefono.Text
                    dts._mail = txtMail.Text
                    dts._idProveedor = txtIdProveedor.Text

                    If func.Modificar_Agente(dts) Then
                        MessageBox.Show("Agente modificado correctamente", "Modificando Registro", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Mostrar()
                        Limpiar()
                    Else
                        MessageBox.Show("Agente no modificado, intente de nuevo", "Modificando Registro", MessageBoxButtons.OK, MessageBoxIcon.Information)
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
        If Me.ValidateChildren = True And txtCodigo.Text <> "" And txtNombre.Text <> "" And txtPaterno.Text <> "" And txtMaterno.Text <> "" And txtTelefono.Text <> "" And txtMail.Text <> "" And txtIdProveedor.Text <> "" Then
            Try
                Dim dts As New CAgente
                Dim func As New fAgente

                dts._codigo = txtCodigo.Text
                dts._nombre = txtNombre.Text
                dts._paterno = txtPaterno.Text
                dts._materno = txtMaterno.Text
                dts._telefono = txtTelefono.Text
                dts._mail = txtMail.Text
                dts._idProveedor = txtIdProveedor.Text

                If func.Insertar_Agente(dts) Then
                    MessageBox.Show("Agente registrado correctamente", "Guardando Registro", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Mostrar()
                    Limpiar()
                Else
                    MessageBox.Show("Agente no registrado, intente de nuevo", "Guardando Registro", MessageBoxButtons.OK, MessageBoxIcon.Information)
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

    Private Sub frmAgente_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
            Me.erpErrorIcono.SetError(sender, "Ingresa el Nombre del Agente, Dato Obligatorio")
        End If
    End Sub

    Private Sub txtPaterno_Validating(sender As Object, e As CancelEventArgs) Handles txtPaterno.Validating
        If DirectCast(sender, TextBox).Text.Length > 0 Then
            Me.erpErrorIcono.SetError(sender, "")
        Else
            Me.erpErrorIcono.SetError(sender, "Ingresa el Apellido Paterno del Agente, Dato Obligatorio")
        End If
    End Sub

    Private Sub txtMaterno_Validating(sender As Object, e As CancelEventArgs) Handles txtMaterno.Validating
        If DirectCast(sender, TextBox).Text.Length > 0 Then
            Me.erpErrorIcono.SetError(sender, "")
        Else
            Me.erpErrorIcono.SetError(sender, "Ingresa el Apellido Materno del Agente, Dato Obligatorio")
        End If
    End Sub

    Private Sub txtTelefono_Validating(sender As Object, e As CancelEventArgs) Handles txtTelefono.Validating
        If DirectCast(sender, TextBox).Text.Length > 0 Then
            Me.erpErrorIcono.SetError(sender, "")
        Else
            Me.erpErrorIcono.SetError(sender, "Ingresa el Teléfono del Agente, Dato Obligatorio")
        End If
    End Sub

    Private Sub txtMail_Validating(sender As Object, e As CancelEventArgs) Handles txtMail.Validating
        If DirectCast(sender, TextBox).Text.Length > 0 Then
            Me.erpErrorIcono.SetError(sender, "")
        Else
            Me.erpErrorIcono.SetError(sender, "Ingresa el E-mail del Agente, Dato Obligatorio")
        End If
    End Sub

    Private Sub txtIdProveedor_Validating(sender As Object, e As CancelEventArgs) Handles txtIdProveedor.Validating
        If DirectCast(sender, TextBox).Text.Length > 0 Then
            Me.erpErrorIcono.SetError(sender, "")
        Else
            Me.erpErrorIcono.SetError(sender, "Ingresa el Proveedor del Agente, Dato Obligatorio")
        End If
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Dim result As DialogResult
        result = MessageBox.Show("Realmente desea eliminar la información seleccionada", "Eliminación de Registro", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)

        If result = DialogResult.OK Then
            Try
                For Each row As DataGridViewRow In dgvAgente.Rows
                    Dim marcado As Boolean = Convert.ToBoolean(row.Cells("Eliminar").Value)

                    If marcado Then
                        Dim onekey As Integer = Convert.ToInt32(row.Cells("ID_Agente").Value)
                        Dim vdb As New CAgente
                        Dim func As New fAgente
                        vdb._idAgente = onekey

                        If func.Eliminar_Agente(vdb) Then
                        Else
                            MessageBox.Show("Agente no eliminado", "Eliminación de Registro", MessageBoxButtons.OK, MessageBoxIcon.Information)
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
            dgvAgente.Columns.Item("Eliminar").Visible = True
            btnEliminar.Visible = True
        Else
            dgvAgente.Columns.Item("Eliminar").Visible = False
            btnEliminar.Visible = False
        End If
    End Sub

    Private Sub dgvAgente_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvAgente.CellClick
        txtIdAgente.Text = dgvAgente.SelectedCells.Item(1).Value
        txtCodigo.Text = dgvAgente.SelectedCells.Item(2).Value
        txtNombre.Text = dgvAgente.SelectedCells.Item(3).Value
        txtPaterno.Text = dgvAgente.SelectedCells.Item(4).Value
        txtMaterno.Text = dgvAgente.SelectedCells.Item(5).Value
        txtTelefono.Text = dgvAgente.SelectedCells.Item(6).Value
        txtMail.Text = dgvAgente.SelectedCells.Item(7).Value
        txtIdProveedor.Text = dgvAgente.SelectedCells.Item(8).Value
        txtProveedor.Text = dgvAgente.SelectedCells.Item(9).Value
        Activar()
        btnModificar.Enabled = True
        btnGuardar.Enabled = False
        btnCancelar.Enabled = True
        btnNuevo.Enabled = False
    End Sub

    Private Sub dgvAgente_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvAgente.CellContentClick
        If e.ColumnIndex = Me.dgvAgente.Columns.Item("Eliminar").Index Then
            Dim chkcell As DataGridViewCheckBoxCell = Me.dgvAgente.Rows(e.RowIndex).Cells("Eliminar")
            chkcell.Value = Not chkcell.Value
        End If
    End Sub

    Private Sub btnProveedor_Click(sender As Object, e As EventArgs) Handles btnProveedor.Click
        frmProveedor.txtFlag.Text = "1"
        frmProveedor.MdiParent = Crónos
        frmProveedor.Show()
    End Sub

    Private Sub dgvAgente_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvAgente.CellDoubleClick
        If txtFlag.Text = "1" Then
            frmCompra.txtIdAgente.Text = dgvAgente.SelectedCells.Item(1).Value
            frmCompra.txtAgente.Text = dgvAgente.SelectedCells.Item(3).Value
            Me.Close()
        End If
    End Sub

End Class
