<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormCaja
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        ListBoxProductos = New ListBox()
        txtCantidad = New TextBox()
        Button_Agregar = New Button()
        ListBoxVenta = New ListBox()
        Button_FinalizarVenta = New Button()
        Button_Regresar = New Button()
        Label_Total = New Label()
        SuspendLayout()
        ' 
        ' ListBoxProductos
        ' 
        ListBoxProductos.FormattingEnabled = True
        ListBoxProductos.ItemHeight = 15
        ListBoxProductos.Location = New Point(351, 12)
        ListBoxProductos.Name = "ListBoxProductos"
        ListBoxProductos.Size = New Size(397, 139)
        ListBoxProductos.TabIndex = 0
        ' 
        ' txtCantidad
        ' 
        txtCantidad.Location = New Point(145, 23)
        txtCantidad.Name = "txtCantidad"
        txtCantidad.Size = New Size(100, 23)
        txtCantidad.TabIndex = 1
        ' 
        ' Button_Agregar
        ' 
        Button_Agregar.Location = New Point(12, 12)
        Button_Agregar.Name = "Button_Agregar"
        Button_Agregar.Size = New Size(108, 43)
        Button_Agregar.TabIndex = 2
        Button_Agregar.Text = "Agregar"
        Button_Agregar.UseVisualStyleBackColor = True
        ' 
        ' ListBoxVenta
        ' 
        ListBoxVenta.FormattingEnabled = True
        ListBoxVenta.ItemHeight = 15
        ListBoxVenta.Location = New Point(351, 224)
        ListBoxVenta.Name = "ListBoxVenta"
        ListBoxVenta.Size = New Size(397, 139)
        ListBoxVenta.TabIndex = 3
        ' 
        ' Button_FinalizarVenta
        ' 
        Button_FinalizarVenta.Location = New Point(12, 322)
        Button_FinalizarVenta.Name = "Button_FinalizarVenta"
        Button_FinalizarVenta.Size = New Size(108, 41)
        Button_FinalizarVenta.TabIndex = 4
        Button_FinalizarVenta.Text = "Finalizar Compra"
        Button_FinalizarVenta.UseVisualStyleBackColor = True
        ' 
        ' Button_Regresar
        ' 
        Button_Regresar.Location = New Point(652, 403)
        Button_Regresar.Name = "Button_Regresar"
        Button_Regresar.Size = New Size(122, 35)
        Button_Regresar.TabIndex = 5
        Button_Regresar.Text = "Volver"
        Button_Regresar.UseVisualStyleBackColor = True
        ' 
        ' Label_Total
        ' 
        Label_Total.Font = New Font("Segoe UI", 15F)
        Label_Total.Location = New Point(12, 248)
        Label_Total.Name = "Label_Total"
        Label_Total.Size = New Size(108, 34)
        Label_Total.TabIndex = 6
        Label_Total.Text = "Total Venta"
        ' 
        ' FormCaja
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(Label_Total)
        Controls.Add(Button_Regresar)
        Controls.Add(Button_FinalizarVenta)
        Controls.Add(ListBoxVenta)
        Controls.Add(Button_Agregar)
        Controls.Add(txtCantidad)
        Controls.Add(ListBoxProductos)
        Name = "FormCaja"
        Text = "Form3"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents ListBoxProductos As ListBox
    Friend WithEvents txtCantidad As TextBox
    Friend WithEvents Button_Agregar As Button
    Friend WithEvents ListBoxVenta As ListBox
    Friend WithEvents Button_FinalizarVenta As Button
    Friend WithEvents Button_Regresar As Button
    Friend WithEvents Label_Total As Label
End Class
