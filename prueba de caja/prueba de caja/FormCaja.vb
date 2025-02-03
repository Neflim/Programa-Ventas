Public Class FormCaja
    ' Lista para almacenar los productos en la venta actual
    Private ventaActual As New List(Of String)
    Private totalVenta As Decimal = 0

    Private Sub FormCaja_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarProductos()
    End Sub

    ' Método para cargar los productos desde el archivo productos.txt
    Private Sub CargarProductos()
        Dim rutaArchivo As String = "productos.txt"

        If System.IO.File.Exists(rutaArchivo) Then
            Dim productos As String() = System.IO.File.ReadAllLines(rutaArchivo)
            ListBoxProductos.Items.Clear()

            For Each producto As String In productos
                Dim partes As String() = producto.Split(New String() {" - "}, StringSplitOptions.None)
                Dim nombreProducto As String = partes(0)
                ListBoxProductos.Items.Add(nombreProducto)
            Next
        Else
            MessageBox.Show("El archivo de productos no existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    ' Método para agregar un producto a la venta actual
    Private Sub Button_Agregar_Click(sender As Object, e As EventArgs) Handles Button_Agregar.Click
        If ListBoxProductos.SelectedIndex = -1 Then
            MessageBox.Show("Selecciona un producto para agregar a la venta.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim productoSeleccionado As String = ListBoxProductos.SelectedItem.ToString()
        Dim cantidad As Integer

        ' Validar que la cantidad sea un número válido
        If Integer.TryParse(txtCantidad.Text, cantidad) AndAlso cantidad > 0 Then
            ' Obtener el precio y el stock del producto seleccionado
            Dim rutaArchivo As String = "productos.txt"
            Dim productos As String() = System.IO.File.ReadAllLines(rutaArchivo)

            For Each producto As String In productos
                Dim partes As String() = producto.Split(New String() {" - "}, StringSplitOptions.None)
                If partes(0) = productoSeleccionado Then
                    Dim precio As Decimal = Decimal.Parse(partes(1).TrimEnd("$"c))
                    Dim stock As Integer = Integer.Parse(partes(2))

                    ' Verificar que haya suficiente stock
                    If stock >= cantidad Then
                        ' Agregar el producto a la venta actual
                        ventaActual.Add($"{productoSeleccionado} - {cantidad}")
                        ListBoxVenta.Items.Add($"{productoSeleccionado} x {cantidad} - ${precio * cantidad}")

                        ' Actualizar el total de la venta
                        totalVenta += precio * cantidad
                        ListBoxVenta.Text = totalVenta.ToString("C")

                        ' Limpiar el TextBox de cantidad
                        txtCantidad.Clear()
                    Else
                        MessageBox.Show("No hay suficiente stock para este producto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                    Exit For
                End If
            Next
        Else
            MessageBox.Show("Ingresa una cantidad válida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    ' Método para finalizar la venta y actualizar el stock
    Private Sub Button_FinalizarVenta_Click(sender As Object, e As EventArgs) Handles Button_FinalizarVenta.Click
        If ventaActual.Count = 0 Then
            MessageBox.Show("No hay productos en la venta.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Actualizar el archivo productos.txt
        Dim rutaArchivo As String = "productos.txt"
        Dim productos As List(Of String) = System.IO.File.ReadAllLines(rutaArchivo).ToList()

        For Each item In ventaActual
            Dim partes As String() = item.Split(New String() {" - "}, StringSplitOptions.None)
            Dim producto As String = partes(0)
            Dim cantidad As Integer = Integer.Parse(partes(1))

            ' Buscar el producto en la lista y actualizar el stock
            For i As Integer = 0 To productos.Count - 1
                Dim partesProducto As String() = productos(i).Split(New String() {" - "}, StringSplitOptions.None)
                If partesProducto(0) = producto Then
                    Dim stockActual As Integer = Integer.Parse(partesProducto(2))
                    productos(i) = $"{producto} - {partesProducto(1)} - {stockActual - cantidad}"
                    Exit For
                End If
            Next
        Next

        ' Guardar los cambios en el archivo
        System.IO.File.WriteAllLines(rutaArchivo, productos)

        ' Limpiar la venta actual
        ventaActual.Clear()
        ListBoxVenta.Items.Clear()
        totalVenta = 0
        ListBoxVenta.Text = "$0.00"

        MessageBox.Show("Venta finalizada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    ' Método para regresar al menú principal
    Private Sub Button_Regresar_Click(sender As Object, e As EventArgs) Handles Button_Regresar.Click
        Me.Close()
        Form1.Show()
    End Sub
End Class