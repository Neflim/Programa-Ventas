Imports ClosedXML.Excel

Public Class Form2
    Private rutaArchivoExcel As String = "productos.xlsx"

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarProductosDesdeExcel()
    End Sub

    ' Cargar productos desde el archivo Excel
    Private Sub CargarProductosDesdeExcel()
        If Not System.IO.File.Exists(rutaArchivoExcel) Then
            MessageBox.Show("El archivo de productos no existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ListBoxProducto.Items.Clear()

        Using workbook As New XLWorkbook(rutaArchivoExcel)
            Dim ws As IXLWorksheet = workbook.Worksheet(1)

            For Each row In ws.RowsUsed().Skip(1) ' Saltamos la primera fila (encabezado)
                Dim nombreProducto As String = row.Cell(1).Value.ToString()
                ListBoxProducto.Items.Add(nombreProducto)
            Next
        End Using
    End Sub

    ' Botón para cerrar el formulario y volver al Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button_Exit.Click
        Me.Close()
        Form1.Show()
    End Sub

    ' Botón para mostrar los productos desde el Excel
    Private Sub Button_Mostrar_Click(sender As Object, e As EventArgs) Handles Button_Mostrar.Click
        CargarProductosDesdeExcel()
    End Sub

    ' Botón para agregar un producto al Excel
    Private Sub Button_Agregar_Click(sender As Object, e As EventArgs) Handles Button_Agregar.Click
        Dim nuevoProducto As String = txtNuevoProducto.Text.Trim()
        Dim precioTexto As String = txtPrecio.Text.Trim()
        Dim stockTexto As String = txtStock.Text.Trim()

        ' Validaciones
        If nuevoProducto = "" OrElse precioTexto = "" OrElse stockTexto = "" Then
            MessageBox.Show("Ingrese todos los datos del producto (Nombre, Precio y Stock).", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim precio As Decimal
        Dim stock As Integer

        ' Validar que el precio sea un número decimal y el stock un entero
        If Not Decimal.TryParse(precioTexto, precio) OrElse precio <= 0 Then
            MessageBox.Show("Ingrese un precio válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        If Not Integer.TryParse(stockTexto, stock) OrElse stock < 0 Then
            MessageBox.Show("Ingrese un stock válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Verificar si el archivo existe
        If Not System.IO.File.Exists(rutaArchivoExcel) Then
            MessageBox.Show("El archivo de productos no existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Abrir y escribir en el Excel
        Using workbook As New XLWorkbook(rutaArchivoExcel)
            Dim ws As IXLWorksheet = workbook.Worksheet(1)

            ' Verificar si hay filas usadas
            Dim ultimaFila As Integer
            If ws.LastRowUsed() Is Nothing Then
                ultimaFila = 2 ' Empezamos en la fila 2 (fila 1 es encabezado)
                ws.Cell(1, 1).Value = "Producto"
                ws.Cell(1, 2).Value = "Precio"
                ws.Cell(1, 3).Value = "Stock"
            Else
                ultimaFila = ws.LastRowUsed().RowNumber() + 1
            End If

            ' Insertar el nuevo producto
            ws.Cell(ultimaFila, 1).Value = nuevoProducto
            ws.Cell(ultimaFila, 2).Value = precio
            ws.Cell(ultimaFila, 3).Value = stock

            workbook.Save()
        End Using

        ' Agregarlo al ListBox con todos los datos
        ListBoxProducto.Items.Add($"{nuevoProducto} - {precio}$ - {stock} unidades")
        txtNuevoProducto.Clear()
        txtPrecio.Clear()
        txtStock.Clear()

        MessageBox.Show("Producto agregado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    ' Botón para borrar un producto del Excel
    Private Sub Button_Borrar_Click(sender As Object, e As EventArgs) Handles Button_Borrar.Click
        If ListBoxProducto.SelectedIndex = -1 Then
            MessageBox.Show("Selecciona un producto para eliminar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim productoAEliminar As String = ListBoxProducto.SelectedItem.ToString()

        If Not System.IO.File.Exists(rutaArchivoExcel) Then
            MessageBox.Show("El archivo de productos no existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Using workbook As New XLWorkbook(rutaArchivoExcel)
            Dim ws As IXLWorksheet = workbook.Worksheet(1)
            Dim filaAEliminar As Integer = -1

            ' Buscar la fila del producto a eliminar
            For Each row In ws.RowsUsed().Skip(1)
                If row.Cell(1).Value.ToString() = productoAEliminar Then
                    filaAEliminar = row.RowNumber()
                    Exit For
                End If
            Next

            ' Eliminar la fila si se encontró
            If filaAEliminar <> -1 Then
                ws.Row(filaAEliminar).Delete()
                workbook.Save()
                ListBoxProducto.Items.Remove(productoAEliminar)
                MessageBox.Show("Producto eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("El producto no se encontró en el archivo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Using
    End Sub
End Class