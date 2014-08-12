<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SolucionHardyCross
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SolucionHardyCross))
        Dim ChartArea2 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend2 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series2 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Me.Chart1 = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Tub0 = New System.Windows.Forms.Label()
        Me.Tub1 = New System.Windows.Forms.Label()
        Me.Tub2 = New System.Windows.Forms.Label()
        Me.Tub3 = New System.Windows.Forms.Label()
        Me.Tub4 = New System.Windows.Forms.Label()
        Me.Tub5 = New System.Windows.Forms.Label()
        Me.Tub6 = New System.Windows.Forms.Label()
        Me.Tub7 = New System.Windows.Forms.Label()
        Me.Tub8 = New System.Windows.Forms.Label()
        Me.Tanque0 = New System.Windows.Forms.TextBox()
        Me.Tanque1 = New System.Windows.Forms.TextBox()
        Me.Tanque2 = New System.Windows.Forms.TextBox()
        Me.Tanque3 = New System.Windows.Forms.TextBox()
        Me.Tanque4 = New System.Windows.Forms.TextBox()
        Me.Tanque5 = New System.Windows.Forms.TextBox()
        Me.Valv1 = New System.Windows.Forms.HScrollBar()
        Me.Valv2 = New System.Windows.Forms.HScrollBar()
        Me.NumBomba1480 = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.NumBombas0690 = New System.Windows.Forms.ComboBox()
        Me.Chart2 = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.Compo1 = New System.Windows.Forms.Label()
        Me.Compo2 = New System.Windows.Forms.Label()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Chart2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Chart1
        '
        ChartArea1.Name = "ChartArea1"
        Me.Chart1.ChartAreas.Add(ChartArea1)
        Legend1.Name = "Legend1"
        Me.Chart1.Legends.Add(Legend1)
        Me.Chart1.Location = New System.Drawing.Point(586, 194)
        Me.Chart1.Name = "Chart1"
        Series1.ChartArea = "ChartArea1"
        Series1.Legend = "Legend1"
        Series1.Name = "Series1"
        Me.Chart1.Series.Add(Series1)
        Me.Chart1.Size = New System.Drawing.Size(375, 193)
        Me.Chart1.TabIndex = 1
        Me.Chart1.Text = "Chart1"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(14, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(740, 570)
        Me.PictureBox1.TabIndex = 2
        Me.PictureBox1.TabStop = False
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(804, 44)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(111, 27)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "Calcular"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Tub0
        '
        Me.Tub0.AutoSize = True
        Me.Tub0.Location = New System.Drawing.Point(337, 499)
        Me.Tub0.Name = "Tub0"
        Me.Tub0.Size = New System.Drawing.Size(39, 13)
        Me.Tub0.TabIndex = 4
        Me.Tub0.Text = "Label1"
        '
        'Tub1
        '
        Me.Tub1.AutoSize = True
        Me.Tub1.Location = New System.Drawing.Point(337, 329)
        Me.Tub1.Name = "Tub1"
        Me.Tub1.Size = New System.Drawing.Size(39, 13)
        Me.Tub1.TabIndex = 5
        Me.Tub1.Text = "Label2"
        '
        'Tub2
        '
        Me.Tub2.AutoSize = True
        Me.Tub2.Location = New System.Drawing.Point(493, 253)
        Me.Tub2.Name = "Tub2"
        Me.Tub2.Size = New System.Drawing.Size(39, 13)
        Me.Tub2.TabIndex = 6
        Me.Tub2.Text = "Label3"
        '
        'Tub3
        '
        Me.Tub3.AutoSize = True
        Me.Tub3.Location = New System.Drawing.Point(562, 129)
        Me.Tub3.Name = "Tub3"
        Me.Tub3.Size = New System.Drawing.Size(39, 13)
        Me.Tub3.TabIndex = 7
        Me.Tub3.Text = "Label4"
        '
        'Tub4
        '
        Me.Tub4.AutoSize = True
        Me.Tub4.Location = New System.Drawing.Point(493, 157)
        Me.Tub4.Name = "Tub4"
        Me.Tub4.Size = New System.Drawing.Size(39, 13)
        Me.Tub4.TabIndex = 8
        Me.Tub4.Text = "Label5"
        '
        'Tub5
        '
        Me.Tub5.AutoSize = True
        Me.Tub5.Location = New System.Drawing.Point(289, 22)
        Me.Tub5.Name = "Tub5"
        Me.Tub5.Size = New System.Drawing.Size(39, 13)
        Me.Tub5.TabIndex = 9
        Me.Tub5.Text = "Label6"
        '
        'Tub6
        '
        Me.Tub6.AutoSize = True
        Me.Tub6.Location = New System.Drawing.Point(374, 148)
        Me.Tub6.Name = "Tub6"
        Me.Tub6.Size = New System.Drawing.Size(39, 13)
        Me.Tub6.TabIndex = 10
        Me.Tub6.Text = "Label7"
        '
        'Tub7
        '
        Me.Tub7.AutoSize = True
        Me.Tub7.Location = New System.Drawing.Point(289, 116)
        Me.Tub7.Name = "Tub7"
        Me.Tub7.Size = New System.Drawing.Size(39, 13)
        Me.Tub7.TabIndex = 11
        Me.Tub7.Text = "Label8"
        '
        'Tub8
        '
        Me.Tub8.AutoSize = True
        Me.Tub8.Location = New System.Drawing.Point(289, 181)
        Me.Tub8.Name = "Tub8"
        Me.Tub8.Size = New System.Drawing.Size(39, 13)
        Me.Tub8.TabIndex = 12
        Me.Tub8.Text = "Label9"
        '
        'Tanque0
        '
        Me.Tanque0.Location = New System.Drawing.Point(340, 530)
        Me.Tanque0.Name = "Tanque0"
        Me.Tanque0.Size = New System.Drawing.Size(51, 20)
        Me.Tanque0.TabIndex = 13
        '
        'Tanque1
        '
        Me.Tanque1.Location = New System.Drawing.Point(84, 246)
        Me.Tanque1.Name = "Tanque1"
        Me.Tanque1.Size = New System.Drawing.Size(51, 20)
        Me.Tanque1.TabIndex = 14
        '
        'Tanque2
        '
        Me.Tanque2.Location = New System.Drawing.Point(165, 181)
        Me.Tanque2.Name = "Tanque2"
        Me.Tanque2.Size = New System.Drawing.Size(51, 20)
        Me.Tanque2.TabIndex = 15
        '
        'Tanque3
        '
        Me.Tanque3.Location = New System.Drawing.Point(165, 122)
        Me.Tanque3.Name = "Tanque3"
        Me.Tanque3.Size = New System.Drawing.Size(51, 20)
        Me.Tanque3.TabIndex = 16
        '
        'Tanque4
        '
        Me.Tanque4.Location = New System.Drawing.Point(644, 72)
        Me.Tanque4.Name = "Tanque4"
        Me.Tanque4.Size = New System.Drawing.Size(51, 20)
        Me.Tanque4.TabIndex = 17
        '
        'Tanque5
        '
        Me.Tanque5.Location = New System.Drawing.Point(83, 19)
        Me.Tanque5.Name = "Tanque5"
        Me.Tanque5.Size = New System.Drawing.Size(51, 20)
        Me.Tanque5.TabIndex = 18
        '
        'Valv1
        '
        Me.Valv1.Location = New System.Drawing.Point(398, 313)
        Me.Valv1.Name = "Valv1"
        Me.Valv1.Size = New System.Drawing.Size(79, 13)
        Me.Valv1.TabIndex = 19
        '
        'Valv2
        '
        Me.Valv2.Location = New System.Drawing.Point(398, 44)
        Me.Valv2.Name = "Valv2"
        Me.Valv2.Size = New System.Drawing.Size(79, 13)
        Me.Valv2.TabIndex = 20
        '
        'NumBomba1480
        '
        Me.NumBomba1480.FormattingEnabled = True
        Me.NumBomba1480.Items.AddRange(New Object() {"1", "2", "3"})
        Me.NumBomba1480.Location = New System.Drawing.Point(426, 467)
        Me.NumBomba1480.Name = "NumBomba1480"
        Me.NumBomba1480.Size = New System.Drawing.Size(35, 21)
        Me.NumBomba1480.TabIndex = 21
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(395, 438)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(97, 26)
        Me.Label1.TabIndex = 22
        Me.Label1.Text = "      Seleccione el" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "número de bombas"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(406, 93)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(97, 26)
        Me.Label2.TabIndex = 23
        Me.Label2.Text = "      Seleccione el" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "número de bombas"
        '
        'NumBombas0690
        '
        Me.NumBombas0690.FormattingEnabled = True
        Me.NumBombas0690.Items.AddRange(New Object() {"1", "2", "3"})
        Me.NumBombas0690.Location = New System.Drawing.Point(442, 122)
        Me.NumBombas0690.Name = "NumBombas0690"
        Me.NumBombas0690.Size = New System.Drawing.Size(35, 21)
        Me.NumBombas0690.TabIndex = 24
        '
        'Chart2
        '
        ChartArea2.Name = "ChartArea1"
        Me.Chart2.ChartAreas.Add(ChartArea2)
        Legend2.Name = "Legend1"
        Me.Chart2.Legends.Add(Legend2)
        Me.Chart2.Location = New System.Drawing.Point(586, 393)
        Me.Chart2.Name = "Chart2"
        Series2.ChartArea = "ChartArea1"
        Series2.Legend = "Legend1"
        Series2.Name = "Series1"
        Me.Chart2.Series.Add(Series2)
        Me.Chart2.Size = New System.Drawing.Size(375, 193)
        Me.Chart2.TabIndex = 25
        Me.Chart2.Text = "Chart2"
        '
        'Compo1
        '
        Me.Compo1.AutoSize = True
        Me.Compo1.Location = New System.Drawing.Point(191, 80)
        Me.Compo1.Name = "Compo1"
        Me.Compo1.Size = New System.Drawing.Size(108, 13)
        Me.Compo1.TabIndex = 26
        Me.Compo1.Text = "Cambiar Composición"
        '
        'Compo2
        '
        Me.Compo2.AutoSize = True
        Me.Compo2.Location = New System.Drawing.Point(54, 393)
        Me.Compo2.Name = "Compo2"
        Me.Compo2.Size = New System.Drawing.Size(108, 13)
        Me.Compo2.TabIndex = 27
        Me.Compo2.Text = "Cambiar Composición"
        '
        'SolucionHardyCross
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(971, 595)
        Me.Controls.Add(Me.Compo2)
        Me.Controls.Add(Me.Compo1)
        Me.Controls.Add(Me.Chart2)
        Me.Controls.Add(Me.NumBombas0690)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.NumBomba1480)
        Me.Controls.Add(Me.Valv2)
        Me.Controls.Add(Me.Valv1)
        Me.Controls.Add(Me.Tanque5)
        Me.Controls.Add(Me.Tanque4)
        Me.Controls.Add(Me.Tanque3)
        Me.Controls.Add(Me.Tanque2)
        Me.Controls.Add(Me.Tanque1)
        Me.Controls.Add(Me.Tanque0)
        Me.Controls.Add(Me.Tub8)
        Me.Controls.Add(Me.Tub7)
        Me.Controls.Add(Me.Tub6)
        Me.Controls.Add(Me.Tub5)
        Me.Controls.Add(Me.Tub4)
        Me.Controls.Add(Me.Tub3)
        Me.Controls.Add(Me.Tub2)
        Me.Controls.Add(Me.Tub1)
        Me.Controls.Add(Me.Tub0)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Chart1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Name = "SolucionHardyCross"
        Me.Text = "SolucionHardyCross"
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Chart2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Chart1 As System.Windows.Forms.DataVisualization.Charting.Chart
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Tub0 As System.Windows.Forms.Label
    Friend WithEvents Tub1 As System.Windows.Forms.Label
    Friend WithEvents Tub2 As System.Windows.Forms.Label
    Friend WithEvents Tub3 As System.Windows.Forms.Label
    Friend WithEvents Tub4 As System.Windows.Forms.Label
    Friend WithEvents Tub5 As System.Windows.Forms.Label
    Friend WithEvents Tub6 As System.Windows.Forms.Label
    Friend WithEvents Tub7 As System.Windows.Forms.Label
    Friend WithEvents Tub8 As System.Windows.Forms.Label
    Friend WithEvents Tanque0 As System.Windows.Forms.TextBox
    Friend WithEvents Tanque1 As System.Windows.Forms.TextBox
    Friend WithEvents Tanque2 As System.Windows.Forms.TextBox
    Friend WithEvents Tanque3 As System.Windows.Forms.TextBox
    Friend WithEvents Tanque4 As System.Windows.Forms.TextBox
    Friend WithEvents Tanque5 As System.Windows.Forms.TextBox
    Friend WithEvents Valv1 As System.Windows.Forms.HScrollBar
    Friend WithEvents Valv2 As System.Windows.Forms.HScrollBar
    Friend WithEvents NumBomba1480 As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents NumBombas0690 As System.Windows.Forms.ComboBox
    Friend WithEvents Chart2 As System.Windows.Forms.DataVisualization.Charting.Chart
    Friend WithEvents Compo1 As System.Windows.Forms.Label
    Friend WithEvents Compo2 As System.Windows.Forms.Label
End Class
