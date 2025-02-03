Imports ClosedXML.Excel

Public Class FormCaja

    ' Lista para almacenar los productos en la venta actual
    Private ventaActual As New List(Of String)
    Private totalVenta As Decimal = 0

    Private Sub FormCaja_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarProductosDesdeExcel()
    End Sub

    ' Método para cargar los productos desde el archivo productos.xlsx
    Private Sub CargarProductosDesdeExcel()
        Dim rutaArchivo As String = "productos.xlsx"

        If Not System.IO.File.Exists(rutaArchivo) Then
            MessageBox.Show("El archivo de productos no existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ListBoxProductos.Items.Clear()

        Using workbook As New XLWorkbook(rutaArchivo)
            Dim hoja As IXLWorksheet = workbook.Worksheet(1)

            For Each fila As IXLRow In hoja.RowsUsed().Skip(1)
                Dim nombre As String = fila.Cell(1).Value.ToString()
                Dim precio As Decimal = Decimal.Parse(fila.Cell(2).Value.ToString())
                Dim stock As Integer = Integer.Parse(fila.Cell(3).Value.ToString())
                ListBoxProductos.Items.Add($"{nombre} - {precio}$ - {stock}")
            Next
        End Using
    End Sub

    ' Método para agregar un producto a la venta actual
    Private Sub Button_Agregar_Click(sender As Object, e As EventArgs) Handles Button_Agregar.Click
        If ListBoxProductos.SelectedIndex = -1 Then
            MessageBox.Show("Selecciona un producto para agregar a la venta.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim productoSeleccionado As String = ListBoxProductos.SelectedItem.ToString().Split(" - ")(0)
        Dim cantidad As Integer

        If Integer.TryParse(txtCantidad.Text, cantidad) AndAlso cantidad > 0 Then
            Dim rutaArchivo As String = "productos.xlsx"

            Using workbook As New XLWorkbook(rutaArchivo)
                Dim hoja As IXLWorksheet = workbook.Worksheet(1)

                For Each filaProducto As IXLRow In hoja.RowsUsed().Skip(1)
                    If filaProducto.Cell(1).Value.ToString() = productoSeleccionado Then
                        Dim precio As Decimal = Decimal.Parse(filaProducto.Cell(2).Value.ToString())
                        Dim stock As Integer = Integer.Parse(filaProducto.Cell(3).Value.ToString())

                        If stock >= cantidad Then
                            ventaActual.Add($"{productoSeleccionado} - {cantidad}")
                            ListBoxVenta.Items.Add($"{productoSeleccionado} x {cantidad} - ${precio * cantidad}")
                            totalVenta += precio * cantidad
                            Label_Total.Text = totalVenta.ToString("C")
                        Else
                            MessageBox.Show("No hay suficiente stock.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                        Exit For
                    End If
                Next
            End Using
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

        Dim rutaArchivo As String = "productos.xlsx"

        ' Actualizar stock en productos.xlsx
        Using workbook As New XLWorkbook(rutaArchivo)
            Dim hoja As IXLWorksheet = workbook.Worksheet(1)

            For Each item In ventaActual
                Dim partes As String() = item.Split(" - ")
                Dim nombreProducto As String = partes(0)
                Dim cantidadVendida As Integer = Integer.Parse(partes(1))

                For Each filaProducto As IXLRow In hoja.RowsUsed().Skip(1)
                    If filaProducto.Cell(1).Value.ToString() = nombreProducto Then
                        Dim stockActual As Integer = Integer.Parse(filaProducto.Cell(3).Value.ToString())
                        filaProducto.Cell(3).Value = stockActual - cantidadVendida
                        Exit For
                    End If
                Next
            Next

            workbook.Save()
        End Using

        Dim rutaVentas As String = "ventas.xlsx"
        Dim workbookVentas As XLWorkbook
        Dim hojaVentas As IXLWorksheet

        If System.IO.File.Exists(rutaVentas) Then
            workbookVentas = New XLWorkbook(rutaVentas)
            hojaVentas = workbookVentas.Worksheet(1)
        Else
            workbookVentas = New XLWorkbook()
            hojaVentas = workbookVentas.Worksheets.Add("Ventas")
            hojaVentas.Cell(1, 1).Value = "Producto"
            hojaVentas.Cell(1, 2).Value = "Cantidad"
            hojaVentas.Cell(1, 3).Value = "Total"
        End If

        ' Evitar error si el archivo está vacío
        Dim fila As Integer
        If hojaVentas.LastRowUsed() IsNot Nothing Then
            fila = hojaVentas.LastRowUsed().RowNumber() + 1
        Else
            fila = 2
            hojaVentas.Cell(1, 1).Value = "Producto"
            hojaVentas.Cell(1, 2).Value = "Cantidad"
            hojaVentas.Cell(1, 3).Value = "Total"
        End If

        For Each item In ventaActual
            Dim partes As String() = item.Split(" - ")
            hojaVentas.Cell(fila, 1).Value = partes(0)
            hojaVentas.Cell(fila, 2).Value = partes(1)
            fila += 1
        Next

        workbookVentas.SaveAs(rutaVentas)
        workbookVentas.Dispose()

        ventaActual.Clear()
        ListBoxVenta.Items.Clear()
        totalVenta = 0
        Label_Total.Text = "$0.00"

        MessageBox.Show("Venta finalizada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
        CargarProductosDesdeExcel()
    End Sub

    ' Método para regresar al menú principal
    Private Sub Button_Regresar_Click(sender As Object, e As EventArgs) Handles Button_Regresar.Click
        Me.Close()
        Form1.Show()
    End Sub

End Class