<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Intro
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Intro))
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.IntroImagen = New System.Windows.Forms.PictureBox()
        CType(Me.IntroImagen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 20
        '
        'IntroImagen
        '
        Me.IntroImagen.Dock = System.Windows.Forms.DockStyle.Fill
        Me.IntroImagen.Image = CType(resources.GetObject("IntroImagen.Image"), System.Drawing.Image)
        Me.IntroImagen.Location = New System.Drawing.Point(0, 0)
        Me.IntroImagen.Name = "IntroImagen"
        Me.IntroImagen.Size = New System.Drawing.Size(1126, 532)
        Me.IntroImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.IntroImagen.TabIndex = 0
        Me.IntroImagen.TabStop = False
        '
        'Intro
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1126, 532)
        Me.Controls.Add(Me.IntroImagen)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Intro"
        Me.Text = "Form2"
        CType(Me.IntroImagen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents IntroImagen As System.Windows.Forms.PictureBox
End Class
