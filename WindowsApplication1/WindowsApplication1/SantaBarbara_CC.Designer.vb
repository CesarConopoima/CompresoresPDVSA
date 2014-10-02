<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SantaBarbara_CC
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SantaBarbara_CC))
        Dim ChartArea3 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend3 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series3 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim ChartArea4 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend4 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series4 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Compresor1 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.TurboExpansor = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.CalculateCaudal = New System.Windows.Forms.Button()
        Me.DischargePresionUnits = New System.Windows.Forms.ComboBox()
        Me.PresionDescarga = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.CoefPolitroSuccion = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.PMSuccion = New System.Windows.Forms.TextBox()
        Me.RPMUnits = New System.Windows.Forms.ComboBox()
        Me.TempUnits = New System.Windows.Forms.ComboBox()
        Me.PresionUnits = New System.Windows.Forms.ComboBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.RPMValor = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.T1succion = New System.Windows.Forms.TextBox()
        Me.P1succion = New System.Windows.Forms.TextBox()
        Me.FlagForSimilitud = New System.Windows.Forms.Label()
        Me.Coefdiseno = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Zdiseno = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.RPMdiseno = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.PMdiseno = New System.Windows.Forms.TextBox()
        Me.T1diseno = New System.Windows.Forms.TextBox()
        Me.P1diseno = New System.Windows.Forms.TextBox()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Chart1 = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.Chart2 = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.Chart2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.GroupBox3)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Location = New System.Drawing.Point(2, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1170, 261)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "GroupBox1"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Compresor1)
        Me.GroupBox3.Controls.Add(Me.Label19)
        Me.GroupBox3.Controls.Add(Me.TurboExpansor)
        Me.GroupBox3.Controls.Add(Me.PictureBox1)
        Me.GroupBox3.Location = New System.Drawing.Point(239, 0)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(911, 255)
        Me.GroupBox3.TabIndex = 1
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Tren de compresión B"
        '
        'Compresor1
        '
        Me.Compresor1.AutoSize = True
        Me.Compresor1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Compresor1.Location = New System.Drawing.Point(235, 105)
        Me.Compresor1.Name = "Compresor1"
        Me.Compresor1.Size = New System.Drawing.Size(104, 13)
        Me.Compresor1.TabIndex = 3
        Me.Compresor1.Text = "Compresor_1_TrenB"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Label19.Location = New System.Drawing.Point(236, 176)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(104, 13)
        Me.Label19.TabIndex = 2
        Me.Label19.Text = "Compresor_2_TrenB"
        '
        'TurboExpansor
        '
        Me.TurboExpansor.AutoSize = True
        Me.TurboExpansor.Cursor = System.Windows.Forms.Cursors.Hand
        Me.TurboExpansor.Location = New System.Drawing.Point(566, 198)
        Me.TurboExpansor.Name = "TurboExpansor"
        Me.TurboExpansor.Size = New System.Drawing.Size(85, 13)
        Me.TurboExpansor.TabIndex = 1
        Me.TurboExpansor.Text = "Turbo_Expansor"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(84, 19)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(718, 237)
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label15)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Location = New System.Drawing.Point(10, 30)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(223, 118)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "GroupBox2"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(6, 84)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(103, 13)
        Me.Label15.TabIndex = 2
        Me.Label15.Text = "Nombre de la Planta"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(19, 57)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(103, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Nombre de la Planta"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(54, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "ID_Planta"
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.CalculateCaudal)
        Me.GroupBox5.Controls.Add(Me.DischargePresionUnits)
        Me.GroupBox5.Controls.Add(Me.PresionDescarga)
        Me.GroupBox5.Controls.Add(Me.Label11)
        Me.GroupBox5.Controls.Add(Me.CoefPolitroSuccion)
        Me.GroupBox5.Controls.Add(Me.Label14)
        Me.GroupBox5.Controls.Add(Me.Label13)
        Me.GroupBox5.Controls.Add(Me.PMSuccion)
        Me.GroupBox5.Controls.Add(Me.RPMUnits)
        Me.GroupBox5.Controls.Add(Me.TempUnits)
        Me.GroupBox5.Controls.Add(Me.PresionUnits)
        Me.GroupBox5.Controls.Add(Me.Button2)
        Me.GroupBox5.Controls.Add(Me.Button1)
        Me.GroupBox5.Controls.Add(Me.RPMValor)
        Me.GroupBox5.Controls.Add(Me.Label16)
        Me.GroupBox5.Controls.Add(Me.Label17)
        Me.GroupBox5.Controls.Add(Me.Label18)
        Me.GroupBox5.Controls.Add(Me.T1succion)
        Me.GroupBox5.Controls.Add(Me.P1succion)
        Me.GroupBox5.Controls.Add(Me.FlagForSimilitud)
        Me.GroupBox5.Controls.Add(Me.Coefdiseno)
        Me.GroupBox5.Controls.Add(Me.Label10)
        Me.GroupBox5.Controls.Add(Me.Zdiseno)
        Me.GroupBox5.Controls.Add(Me.Label9)
        Me.GroupBox5.Controls.Add(Me.RPMdiseno)
        Me.GroupBox5.Controls.Add(Me.Label8)
        Me.GroupBox5.Controls.Add(Me.Label7)
        Me.GroupBox5.Controls.Add(Me.Label6)
        Me.GroupBox5.Controls.Add(Me.Label5)
        Me.GroupBox5.Controls.Add(Me.Label4)
        Me.GroupBox5.Controls.Add(Me.Label3)
        Me.GroupBox5.Controls.Add(Me.PMdiseno)
        Me.GroupBox5.Controls.Add(Me.T1diseno)
        Me.GroupBox5.Controls.Add(Me.P1diseno)
        Me.GroupBox5.Location = New System.Drawing.Point(617, 270)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(555, 330)
        Me.GroupBox5.TabIndex = 2
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "GroupBox5"
        '
        'CalculateCaudal
        '
        Me.CalculateCaudal.Location = New System.Drawing.Point(371, 163)
        Me.CalculateCaudal.Name = "CalculateCaudal"
        Me.CalculateCaudal.Size = New System.Drawing.Size(138, 43)
        Me.CalculateCaudal.TabIndex = 32
        Me.CalculateCaudal.Text = "Determine la Producción"
        Me.CalculateCaudal.UseVisualStyleBackColor = True
        '
        'DischargePresionUnits
        '
        Me.DischargePresionUnits.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.DischargePresionUnits.FormattingEnabled = True
        Me.DischargePresionUnits.Items.AddRange(New Object() {"[psi]", "[Pa]", "[KPa]", "[MPa]", "[bar]", "[m]", "[mmHg]"})
        Me.DischargePresionUnits.Location = New System.Drawing.Point(446, 280)
        Me.DischargePresionUnits.Name = "DischargePresionUnits"
        Me.DischargePresionUnits.Size = New System.Drawing.Size(45, 21)
        Me.DischargePresionUnits.TabIndex = 31
        '
        'PresionDescarga
        '
        Me.PresionDescarga.Location = New System.Drawing.Point(497, 280)
        Me.PresionDescarga.Name = "PresionDescarga"
        Me.PresionDescarga.Size = New System.Drawing.Size(52, 20)
        Me.PresionDescarga.TabIndex = 30
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(286, 283)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(115, 13)
        Me.Label11.TabIndex = 29
        Me.Label11.Text = "Presión en la descarga"
        '
        'CoefPolitroSuccion
        '
        Me.CoefPolitroSuccion.Location = New System.Drawing.Point(474, 254)
        Me.CoefPolitroSuccion.Name = "CoefPolitroSuccion"
        Me.CoefPolitroSuccion.Size = New System.Drawing.Size(44, 20)
        Me.CoefPolitroSuccion.TabIndex = 28
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(286, 258)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(154, 13)
        Me.Label14.TabIndex = 27
        Me.Label14.Text = "Coéficiente politrópico [J/Kg*K]"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(286, 234)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(166, 13)
        Me.Label13.TabIndex = 26
        Me.Label13.Text = "Peso molecular del gas [Kg/Kmol]"
        '
        'PMSuccion
        '
        Me.PMSuccion.Location = New System.Drawing.Point(474, 228)
        Me.PMSuccion.Name = "PMSuccion"
        Me.PMSuccion.Size = New System.Drawing.Size(44, 20)
        Me.PMSuccion.TabIndex = 25
        '
        'RPMUnits
        '
        Me.RPMUnits.FormattingEnabled = True
        Me.RPMUnits.Items.AddRange(New Object() {"[RPM]", "[Hz]"})
        Me.RPMUnits.Location = New System.Drawing.Point(142, 280)
        Me.RPMUnits.Name = "RPMUnits"
        Me.RPMUnits.Size = New System.Drawing.Size(55, 21)
        Me.RPMUnits.TabIndex = 24
        '
        'TempUnits
        '
        Me.TempUnits.FormattingEnabled = True
        Me.TempUnits.Items.AddRange(New Object() {"[°C]", "[K]", "[F]", "[R]"})
        Me.TempUnits.Location = New System.Drawing.Point(142, 255)
        Me.TempUnits.Name = "TempUnits"
        Me.TempUnits.Size = New System.Drawing.Size(55, 21)
        Me.TempUnits.TabIndex = 23
        '
        'PresionUnits
        '
        Me.PresionUnits.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.PresionUnits.FormattingEnabled = True
        Me.PresionUnits.Items.AddRange(New Object() {"[psi]", "[Pa]", "[KPa]", "[MPa]", "[bar]", "[m]", "[mmHg]"})
        Me.PresionUnits.Location = New System.Drawing.Point(142, 231)
        Me.PresionUnits.Name = "PresionUnits"
        Me.PresionUnits.Size = New System.Drawing.Size(55, 21)
        Me.PresionUnits.TabIndex = 22
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(371, 112)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(138, 43)
        Me.Button2.TabIndex = 21
        Me.Button2.Text = "Hacer similitud"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(371, 60)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(138, 43)
        Me.Button1.TabIndex = 4
        Me.Button1.Text = "Cambio de composición"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'RPMValor
        '
        Me.RPMValor.Location = New System.Drawing.Point(210, 280)
        Me.RPMValor.Name = "RPMValor"
        Me.RPMValor.Size = New System.Drawing.Size(70, 20)
        Me.RPMValor.TabIndex = 20
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(11, 283)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(89, 13)
        Me.Label16.TabIndex = 19
        Me.Label16.Text = "Velocidad de giro"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(10, 257)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(122, 13)
        Me.Label17.TabIndex = 18
        Me.Label17.Text = "Temperatura de succión"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(10, 234)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(97, 13)
        Me.Label18.TabIndex = 17
        Me.Label18.Text = "Presión de succión"
        '
        'T1succion
        '
        Me.T1succion.Location = New System.Drawing.Point(210, 255)
        Me.T1succion.Name = "T1succion"
        Me.T1succion.Size = New System.Drawing.Size(70, 20)
        Me.T1succion.TabIndex = 16
        '
        'P1succion
        '
        Me.P1succion.Location = New System.Drawing.Point(210, 231)
        Me.P1succion.Name = "P1succion"
        Me.P1succion.Size = New System.Drawing.Size(70, 20)
        Me.P1succion.TabIndex = 15
        '
        'FlagForSimilitud
        '
        Me.FlagForSimilitud.AutoSize = True
        Me.FlagForSimilitud.ForeColor = System.Drawing.Color.Black
        Me.FlagForSimilitud.Location = New System.Drawing.Point(207, 205)
        Me.FlagForSimilitud.Name = "FlagForSimilitud"
        Me.FlagForSimilitud.Size = New System.Drawing.Size(122, 13)
        Me.FlagForSimilitud.TabIndex = 14
        Me.FlagForSimilitud.Text = "Condiciones cambiantes"
        '
        'Coefdiseno
        '
        Me.Coefdiseno.Location = New System.Drawing.Point(179, 175)
        Me.Coefdiseno.Name = "Coefdiseno"
        Me.Coefdiseno.Size = New System.Drawing.Size(70, 20)
        Me.Coefdiseno.TabIndex = 13
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(7, 178)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(154, 13)
        Me.Label10.TabIndex = 12
        Me.Label10.Text = "Coéficiente politrópico [J/Kg*K]"
        '
        'Zdiseno
        '
        Me.Zdiseno.Location = New System.Drawing.Point(179, 149)
        Me.Zdiseno.Name = "Zdiseno"
        Me.Zdiseno.Size = New System.Drawing.Size(70, 20)
        Me.Zdiseno.TabIndex = 11
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(7, 152)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(127, 13)
        Me.Label9.TabIndex = 10
        Me.Label9.Text = "Factor de compresibilidad"
        '
        'RPMdiseno
        '
        Me.RPMdiseno.Location = New System.Drawing.Point(179, 98)
        Me.RPMdiseno.Name = "RPMdiseno"
        Me.RPMdiseno.Size = New System.Drawing.Size(70, 20)
        Me.RPMdiseno.TabIndex = 9
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(7, 127)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(166, 13)
        Me.Label8.TabIndex = 8
        Me.Label8.Text = "Peso molecular del gas [Kg/Kmol]"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(7, 101)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(122, 13)
        Me.Label7.TabIndex = 7
        Me.Label7.Text = "Velocidad de giro [RPM]"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(6, 75)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(138, 13)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "Temperatura de succión [K]"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 52)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(123, 13)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Presión de succión [PSI]"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(27, 25)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(166, 13)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Condiciones de diseño del equipo"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(385, 25)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(106, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Composición del Gas"
        '
        'PMdiseno
        '
        Me.PMdiseno.Location = New System.Drawing.Point(179, 123)
        Me.PMdiseno.Name = "PMdiseno"
        Me.PMdiseno.Size = New System.Drawing.Size(70, 20)
        Me.PMdiseno.TabIndex = 2
        '
        'T1diseno
        '
        Me.T1diseno.Location = New System.Drawing.Point(179, 73)
        Me.T1diseno.Name = "T1diseno"
        Me.T1diseno.Size = New System.Drawing.Size(70, 20)
        Me.T1diseno.TabIndex = 1
        '
        'P1diseno
        '
        Me.P1diseno.Location = New System.Drawing.Point(179, 49)
        Me.P1diseno.Name = "P1diseno"
        Me.P1diseno.Size = New System.Drawing.Size(70, 20)
        Me.P1diseno.TabIndex = 0
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(166, 270)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(445, 330)
        Me.TabControl1.TabIndex = 3
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Chart1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(437, 304)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Curva Compresor"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'Chart1
        '
        ChartArea3.Name = "ChartArea1"
        Me.Chart1.ChartAreas.Add(ChartArea3)
        Legend3.Name = "Legend1"
        Me.Chart1.Legends.Add(Legend3)
        Me.Chart1.Location = New System.Drawing.Point(6, 3)
        Me.Chart1.Name = "Chart1"
        Series3.ChartArea = "ChartArea1"
        Series3.Legend = "Legend1"
        Series3.Name = "Series1"
        Me.Chart1.Series.Add(Series3)
        Me.Chart1.Size = New System.Drawing.Size(428, 295)
        Me.Chart1.TabIndex = 0
        Me.Chart1.Text = "Chart1"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.Chart2)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(437, 304)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Mapa Operación del Compresor"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'Chart2
        '
        ChartArea4.Name = "ChartArea1"
        Me.Chart2.ChartAreas.Add(ChartArea4)
        Legend4.Name = "Legend1"
        Me.Chart2.Legends.Add(Legend4)
        Me.Chart2.Location = New System.Drawing.Point(3, 3)
        Me.Chart2.Name = "Chart2"
        Series4.ChartArea = "ChartArea1"
        Series4.Legend = "Legend1"
        Series4.Name = "Series1"
        Me.Chart2.Series.Add(Series4)
        Me.Chart2.Size = New System.Drawing.Size(431, 295)
        Me.Chart2.TabIndex = 0
        Me.Chart2.Text = "Chart2"
        '
        'SantaBarbara_CC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1184, 612)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "SantaBarbara_CC"
        Me.Text = "Jusepin_1"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        CType(Me.Chart2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents Chart1 As System.Windows.Forms.DataVisualization.Charting.Chart
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents Chart2 As System.Windows.Forms.DataVisualization.Charting.Chart
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents T1diseno As System.Windows.Forms.TextBox
    Friend WithEvents P1diseno As System.Windows.Forms.TextBox
    Friend WithEvents PMdiseno As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents RPMdiseno As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Zdiseno As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Coefdiseno As System.Windows.Forms.TextBox
    Friend WithEvents FlagForSimilitud As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents RPMValor As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents T1succion As System.Windows.Forms.TextBox
    Friend WithEvents P1succion As System.Windows.Forms.TextBox
    Friend WithEvents RPMUnits As System.Windows.Forms.ComboBox
    Friend WithEvents TempUnits As System.Windows.Forms.ComboBox
    Friend WithEvents PresionUnits As System.Windows.Forms.ComboBox
    Friend WithEvents TurboExpansor As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents PMSuccion As System.Windows.Forms.TextBox
    Friend WithEvents CoefPolitroSuccion As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Compresor1 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents DischargePresionUnits As System.Windows.Forms.ComboBox
    Friend WithEvents PresionDescarga As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents CalculateCaudal As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
End Class
