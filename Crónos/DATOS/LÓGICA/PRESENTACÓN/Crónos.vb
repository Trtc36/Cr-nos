Imports System.Windows.Forms

Public Class Crónos

    Private Sub ShowNewForm(ByVal sender As Object, ByVal e As EventArgs) Handles NewWindowToolStripMenuItem.Click
        ' Cree una nueva instancia del formulario secundario.
        Dim ChildForm As New System.Windows.Forms.Form
        ' Conviértalo en un elemento secundario de este formulario MDI antes de mostrarlo.
        ChildForm.MdiParent = Me

        m_ChildFormNumber += 1
        ChildForm.Text = "Ventana " & m_ChildFormNumber

        ChildForm.Show()
    End Sub

    Private Sub OpenFile(ByVal sender As Object, ByVal e As EventArgs)
        Dim OpenFileDialog As New OpenFileDialog
        OpenFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        OpenFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*"
        If (OpenFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
            Dim FileName As String = OpenFileDialog.FileName
            ' TODO: agregue código aquí para abrir el archivo.
        End If
    End Sub

    Private Sub SaveAsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim SaveFileDialog As New SaveFileDialog
        SaveFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        SaveFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*"

        If (SaveFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
            Dim FileName As String = SaveFileDialog.FileName
            ' TODO: agregue código aquí para guardar el contenido actual del formulario en un archivo.
        End If
    End Sub


    Private Sub ExitToolsStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.Close()
    End Sub

    Private Sub CutToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Utilice My.Computer.Clipboard para insertar el texto o las imágenes seleccionadas en el Portapapeles
    End Sub

    Private Sub CopyToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Utilice My.Computer.Clipboard para insertar el texto o las imágenes seleccionadas en el Portapapeles
    End Sub

    Private Sub PasteToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        'Utilice My.Computer.Clipboard.GetText() o My.Computer.Clipboard.GetData para recuperar la información del Portapapeles.
    End Sub

    Private Sub CascadeToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CascadeToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.Cascade)
    End Sub

    Private Sub TileVerticalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles TileVerticalToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.TileVertical)
    End Sub

    Private Sub TileHorizontalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles TileHorizontalToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.TileHorizontal)
    End Sub

    Private Sub ArrangeIconsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ArrangeIconsToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.ArrangeIcons)
    End Sub

    Private Sub CloseAllToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CloseAllToolStripMenuItem.Click
        ' Cierre todos los formularios secundarios del principal.
        For Each ChildForm As Form In Me.MdiChildren
            ChildForm.Close()
        Next
    End Sub

    Private m_ChildFormNumber As Integer

    Private Sub ProveedorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ProveedorToolStripMenuItem.Click
        frmProveedor.MdiParent = Me
        frmProveedor.Show()
    End Sub

    Private Sub AgenteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AgenteToolStripMenuItem.Click
        frmAgente.MdiParent = Me
        frmAgente.Show()
    End Sub

    Private Sub CapacitaciónToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles CapacitaciónToolStripMenuItem1.Click
        frmCapacitacion.MdiParent = Me
        frmCapacitacion.Show()
    End Sub

    Private Sub AsignarCapacitaciónToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AsignarCapacitaciónToolStripMenuItem.Click
        frmCapacitacionEmpleado.MdiParent = Me
        frmCapacitacionEmpleado.Show()
    End Sub

    Private Sub CarreraToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CarreraToolStripMenuItem.Click
        frmCarrera.MdiParent = Me
        frmCarrera.Show()
    End Sub

    Private Sub ClienteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClienteToolStripMenuItem.Click
        frmCliente.MdiParent = Me
        frmCliente.Show()
    End Sub

    Private Sub NuevaCompraToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles NuevaCompraToolStripMenuItem1.Click
        frmCompra.MdiParent = Me
        frmCompra.Show()
    End Sub

    Private Sub NuevaVentaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NuevaVentaToolStripMenuItem.Click
        frmVenta.MdiParent = Me
        frmVenta.Show()
    End Sub

    Private Sub NuevoEmpleadoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NuevoEmpleadoToolStripMenuItem.Click
        frmEmpleado.MdiParent = Me
        frmEmpleado.Show()
    End Sub

    Private Sub EvaluaciónToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EvaluaciónToolStripMenuItem.Click
        frmDesempeño.MdiParent = Me
        frmDesempeño.Show()
    End Sub

    Private Sub IncidenciaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles IncidenciaToolStripMenuItem.Click
        frmIncidencia.MdiParent = Me
        frmIncidencia.Show()
    End Sub

    Private Sub ReconocimientoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReconocimientoToolStripMenuItem.Click
        frmReconocimiento.MdiParent = Me
        frmReconocimiento.Show()
    End Sub


    Private Sub UsuarioToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UsuarioToolStripMenuItem.Click
        frmUsuario.MdiParent = Me
        frmUsuario.Show()
    End Sub

    Private Sub PermisoToolStripMenuItem1_Click(sender As Object, e As EventArgs)
        frmPermiso.MdiParent = Me
        frmPermiso.Show()
    End Sub

    Private Sub PermisoToolStripMenuItem1_Click_1(sender As Object, e As EventArgs) Handles PermisoToolStripMenuItem1.Click
        frmPermiso.MdiParent = Me
        frmPermiso.Show()
    End Sub

    Private Sub AsignarSueldoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AsignarSueldoToolStripMenuItem.Click
        frmHistorialSueldos.MdiParent = Me
        frmHistorialSueldos.Show()
    End Sub

    Private Sub PuestoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PuestoToolStripMenuItem.Click
        frmPuesto.MdiParent = Me
        frmPuesto.Show()
    End Sub

    Private Sub ProductoToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles ProductoToolStripMenuItem.Click
        frmProducto.MdiParent = Me
        frmProducto.Show()
    End Sub

    Private Sub CategoríaToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles CategoríaToolStripMenuItem.Click
        frmCategoria.MdiParent = Me
        frmCategoria.Show()
    End Sub

    Private Sub MarcaToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles MarcaToolStripMenuItem.Click
        frmMarca.MdiParent = Me
        frmMarca.Show()
    End Sub

    Private Sub ModeloToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ModeloToolStripMenuItem1.Click
        frmModelo.MdiParent = Me
        frmModelo.Show()
    End Sub
End Class
