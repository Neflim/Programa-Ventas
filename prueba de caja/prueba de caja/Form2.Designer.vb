<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form2
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
        Button_Exit = New Button()
        ListBoxProducto = New ListBox()
        Button_Mostrar = New Button()
        Button_Agregar = New Button()
        txtNuevoProducto = New TextBox()
        Button_Borrar = New Button()
        SuspendLayout()
        ' 
        ' Button_Exit
        ' 
        Button_Exit.Location = New Point(690, 415)
        Button_Exit.Name = "Button_Exit"
        Button_Exit.Size = New Size(75, 23)
        Button_Exit.TabIndex = 1
        Button_Exit.Text = "Volver"
        Button_Exit.UseVisualStyleBackColor = True
        ' 
        ' ListBoxProducto
        ' 
        ListBoxProducto.FormattingEnabled = True
        ListBoxProducto.ItemHeight = 15
        ListBoxProducto.Location = New Point(293, 29)
        ListBoxProducto.Name = "ListBoxProducto"
        ListBoxProducto.Size = New Size(473, 304)
        ListBoxProducto.TabIndex = 2
        ' 
        ' Button_Mostrar
        ' 
        Button_Mostrar.Location = New Point(37, 39)
        Button_Mostrar.Name = "Button_Mostrar"
        Button_Mostrar.Size = New Size(158, 38)
        Button_Mostrar.TabIndex = 3
        Button_Mostrar.Text = "Mostrar"
        Button_Mostrar.UseVisualStyleBackColor = True
        ' 
        ' Button_Agregar
        ' 
        Button_Agregar.Location = New Point(37, 98)
        Button_Agregar.Name = "Button_Agregar"
        Button_Agregar.Size = New Size(158, 39)
        Button_Agregar.TabIndex = 4
        Button_Agregar.Text = "Agregar"
        Button_Agregar.UseVisualStyleBackColor = True
        ' 
        ' txtNuevoProducto
        ' 
        txtNuevoProducto.Location = New Point(37, 174)
        txtNuevoProducto.Name = "txtNuevoProducto"
        txtNuevoProducto.Size = New Size(158, 23)
        txtNuevoProducto.TabIndex = 5
        ' 
        ' Button_Borrar
        ' 
        Button_Borrar.Location = New Point(37, 218)
        Button_Borrar.Name = "Button_Borrar"
        Button_Borrar.Size = New Size(158, 38)
        Button_Borrar.TabIndex = 6
        Button_Borrar.Text = "Borrar"
        Button_Borrar.UseVisualStyleBackColor = True
        ' 
        ' Form2
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(Button_Borrar)
        Controls.Add(txtNuevoProducto)
        Controls.Add(Button_Agregar)
        Controls.Add(Button_Mostrar)
        Controls.Add(ListBoxProducto)
        Controls.Add(Button_Exit)
        Name = "Form2"
        Text = "Form2"
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents Button_Exit As Button
    Friend WithEvents ListBoxProducto As ListBox
    Friend WithEvents Button_Mostrar As Button
    Friend WithEvents Button_Agregar As Button
    Friend WithEvents txtNuevoProducto As TextBox
    Friend WithEvents Button_Borrar As Button
End Class
