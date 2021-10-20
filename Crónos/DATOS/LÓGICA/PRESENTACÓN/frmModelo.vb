Imports System.ComponentModel
Public Class frmModelo
    Private dt As New DataTable
    Dim func As New fModelo

    Private Sub Limpiar()
        txtIdModelo.Text = ""
        txtCodigo.Text = ""
        txtModelo.Text = ""
        txtDescripcion.Text = ""
        txtIdMarca.Text = ""
        txtMarca.Text = ""
    End Sub

    Private Sub Activar()
        txtModelo.Enabled = True
        txtDescripcion.Enabled = True
    End Sub

    Private Sub Desactivar()
        txtModelo.Enabled = False
        txtDescripcion.Enabled = False
    End Sub

    Private Sub Ocultar_Columnas()
        dgvModelo.Columns(1).Visible = False
        dgvModelo.Columns(4).Visible = False
        dgvModelo.Columns(5).Visible = False
    End Sub

    Private Sub Mostrar()
        Try
            Dim funcion As New fModelo
            dt = funcion.Mostrar_Modelo
            dgvModelo.Columns.Item("Eliminar").Visible = False

            If dt.Rows.Count <> 0 Then
                dgvModelo.DataSource = dt
                txtBuscado.Enabled = True
                dgvModelo.ColumnHeadersVisible = True
                llbInexistente.Visible = True
            Else
                dgvModelo.DataSource = Nothing
                txtBuscado.Enabled = False
                dgvModelo.ColumnHeadersVisible = False
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
                dgvModelo.DataSource = dv
                Ocultar_Columnas()
            Else
                llbInexistente.Visible = True
                dgvModelo.DataSource = Nothing
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
        codigo = Format(func.Generar_Modelo, "0000")
        txtIdModelo.Text = Format(func.Generar_Modelo)
        txtCodigo.Text = "CRONOSMOD" + codigo
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Mostrar()
    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        Dim result As DialogResult
        result = MessageBox.Show("¿Realmente quiere modificar el registro?", "Modificando Registro", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)

        If result = DialogResult.OK Then
            If Me.ValidateChildren = True And txtIdModelo.Text <> 0 And txtCodigo.Text <> "" And txtModelo.Text <> "" And txtDescripcion.Text <> "" And txtIdMarca.Text <> "" Then
                Try
                    Dim dts As New CModelo
                    Dim func As New fModelo

                    dts._idModelo = txtIdModelo.Text
                    dts._codigo = txtCodigo.Text
                    dts._modelo = txtModelo.Text
                    dts._descripcion = txtDescripcion.Text
                    dts._idMarca = txtIdMarca.Text

                    If func.Modificar_Modelo(dts) Then
                        MessageBox.Show("Modelo modificado correctamente", "Modificando Registro", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Mostrar()
                        Limpiar()
                    Else
                        MessageBox.Show("Modelo no modificado, intente de nuevo", "Modificando Registro", MessageBoxButtons.OK, MessageBoxIcon.Information)
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
        If Me.ValidateChildren = True And txtCodigo.Text <> "" And txtModelo.Text <> "" And txtDescripcion.Text <> "" And txtIdMarca.Text <> "" Then
            Try
                Dim dts As New CModelo
                Dim func As New fModelo

                dts._codigo = txtCodigo.Text
                dts._modelo = txtModelo.Text
                dts._descripcion = txtDescripcion.Text
                dts._idMarca = txtIdMarca.Text

                If func.Insertar_Modelo(dts) Then
                    MessageBox.Show("Modelo registrado correctamente", "Guardando Registro", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Mostrar()
                    Limpiar()
                Else
                    MessageBox.Show("Modelo no registrado, intente de nuevo", "Guardando Registro", MessageBoxButtons.OK, MessageBoxIcon.Information)
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

    Private Sub frmModelo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
            Me.erpErrorIcono.SetError(sender, "Ingresa el Código del Modelo, Dato Obligatorio")
        End If
    End Sub

    Private Sub txtModelo_Validating(sender As Object, e As CancelEventArgs) Handles txtModelo.Validating
        If DirectCast(sender, TextBox).Text.Length > 0 Then
            Me.erpErrorIcono.SetError(sender, "")
        Else
            Me.erpErrorIcono.SetError(sender, "Ingresa el Nombre del Modelo, Dato Obligatorio")
        End If
    End Sub

    Private Sub txtDescripcion_Validating(sender As Object, e As CancelEventArgs) Handles txtDescripcion.Validating
        If DirectCast(sender, TextBox).Text.Length > 0 Then
            Me.erpErrorIcono.SetError(sender, "")
        Else
            Me.erpErrorIcono.SetError(sender, "Ingresa la Descripción del Modelo, Dato Obligatorio")
        End If
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Dim result As DialogResult
        result = MessageBox.Show("Realmente desea eliminar la información seleccionada", "Eliminación de Registro", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)

        If result = DialogResult.OK Then
            Try
                For Each row As DataGridViewRow In dgvModelo.Rows
                    Dim marcado As Boolean = Convert.ToBoolean(row.Cells("Eliminar").Value)

                    If marcado Then
                        Dim onekey As Integer = Convert.ToInt32(row.Cells("ID_Modelo").Value)
                        Dim vdb As New CModelo
                        Dim func As New fModelo
                        vdb._idModelo = onekey

                        If func.Eliminar_Modelo(vdb) Then
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
            dgvModelo.Columns.Item("Eliminar").Visible = True
            btnEliminar.Visible = True
        Else
            dgvModelo.Columns.Item("Eliminar").Visible = False
            btnEliminar.Visible = False
        End If
    End Sub

    Private Sub dgvModelo_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvModelo.CellContentClick
        If e.ColumnIndex = Me.dgvModelo.Columns.Item("Eliminar").Index Then
            Dim chkcell As DataGridViewCheckBoxCell = Me.dgvModelo.Rows(e.RowIndex).Cells("Eliminar")
            chkcell.Value = Not chkcell.Value
        End If
    End Sub

    Private Sub dgvModelo_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvModelo.CellClick
        txtIdModelo.Text = dgvModelo.SelectedCells.Item(1).Value
        txtCodigo.Text = dgvModelo.SelectedCells.Item(2).Value
        txtModelo.Text = dgvModelo.SelectedCells.Item(3).Value
        txtDescripcion.Text = dgvModelo.SelectedCells.Item(5).Value
        txtIdMarca.Text = dgvModelo.SelectedCells.Item(4).Value
        txtMarca.Text = dgvModelo.SelectedCells.Item(6).Value
        Activar()
        btnModificar.Enabled = True
        btnGuardar.Enabled = False
        btnCancelar.Enabled = True
        btnNuevo.Enabled = False
    End Sub

    Private Sub btnMarca_Click(sender As Object, e As EventArgs) Handles btnMarca.Click
        frmMarca.txtFlag.Text = "1"
        frmMarca.MdiParent = Crónos
        frmMarca.Show()
    End Sub

    Private Sub dgvModelo_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvModelo.CellDoubleClick
        If txtFlag.Text = "1" Then
            frmProducto.txtIdModelo.Text = dgvModelo.SelectedCells.Item(1).Value
            frmProducto.txtModelo.Text = dgvModelo.SelectedCells.Item(3).Value
            Me.Close()
        End If
    End Sub

End Class