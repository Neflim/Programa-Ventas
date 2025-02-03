<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        button_almacen = New Button()
        button_caja = New Button()
        Button_exit = New Button()
        SuspendLayout()
        ' 
        ' button_almacen
        ' 
        button_almacen.Location = New Point(349, 109)
        button_almacen.Name = "button_almacen"
        button_almacen.Size = New Size(75, 23)
        button_almacen.TabIndex = 0
        button_almacen.Text = "Almacen"
        button_almacen.UseVisualStyleBackColor = True
        ' 
        ' button_caja
        ' 
        button_caja.Location = New Point(349, 205)
        button_caja.Name = "button_caja"
        button_caja.Size = New Size(75, 23)
        button_caja.TabIndex = 1
        button_caja.Text = "Caja"
        button_caja.UseVisualStyleBackColor = True
        ' 
        ' Button_exit
        ' 
        Button_exit.Location = New Point(713, 415)
        Button_exit.Name = "Button_exit"
        Button_exit.Size = New Size(75, 23)
        Button_exit.TabIndex = 2
        Button_exit.Text = "Salir"
        Button_exit.UseVisualStyleBackColor = True
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(Button_exit)
        Controls.Add(button_caja)
        Controls.Add(button_almacen)
        Name = "Form1"
        Text = "Form1"
        ResumeLayout(False)
    End Sub

    Friend WithEvents button_almacen As Button
    Friend WithEvents button_caja As Button
    Friend WithEvents Button_exit As Button

End Class
