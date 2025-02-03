Public Class Form2


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button_Exit.Click
        Close()
        Form1.Show()
    End Sub

    Private Sub Button_Mostrar_Click(sender As Object, e As EventArgs) Handles Button_Mostrar.Click
        Dim rutaArchivo As String = "productos.txt"

        If System.IO.File.Exists(rutaArchivo) Then
            Dim productos As String() = System.IO.File.ReadAllLines(rutaArchivo)
            ListBoxProducto.Items.Clear() ' Limpia la lista antes de agregar nuevos elementos
            ListBoxProducto.Items.AddRange(productos)
        Else
            MessageBox.Show("El archivo de productos no existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub Button_Agregar_Click(sender As Object, e As EventArgs) Handles Button_Agregar.Click
        Dim nuevoProducto As String = txtNuevoProducto.Text.Trim()
        Dim rutaArchivo As String = "productos.txt"

        If nuevoProducto <> "" Then
            System.IO.File.AppendAllText(rutaArchivo, nuevoProducto & Environment.NewLine)
            ListBoxProducto.Items.Add(nuevoProducto) ' Agrega el producto a la lista visualmente
            txtNuevoProducto.Clear()
        Else
            MessageBox.Show("Ingrese un nombre de producto válido.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub Button_Borrar_Click(sender As Object, e As EventArgs) Handles Button_Borrar.Click
        Dim rutaArchivo As String = "productos.txt"

        ' Verificar que el archivo exista
        If Not System.IO.File.Exists(rutaArchivo) Then
            MessageBox.Show("El archivo no existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Obtener el producto seleccionado
        If ListBoxProducto.SelectedIndex = -1 Then
            MessageBox.Show("Selecciona un producto para eliminar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim productoAEliminar As String = ListBoxProducto.SelectedItem.ToString()

        ' Leer todas las líneas del archivo
        Dim productos As List(Of String) = System.IO.File.ReadAllLines(rutaArchivo).ToList()

        ' Eliminar el producto de la lista
        productos.Remove(productoAEliminar)

        ' Guardar la lista actualizada en el archivo
        System.IO.File.WriteAllLines(rutaArchivo, productos)

        ' Actualizar la ListBox
        ListBoxProducto.Items.Remove(productoAEliminar)

        MessageBox.Show("Producto eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
End Class