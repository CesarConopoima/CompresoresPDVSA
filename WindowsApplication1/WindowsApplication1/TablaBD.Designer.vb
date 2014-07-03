<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TablaBD
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TablaBD))
        Dim ID_compresorLabel As System.Windows.Forms.Label
        Dim TipoLabel As System.Windows.Forms.Label
        Dim RpmLabel As System.Windows.Forms.Label
        Dim Consumo_potenciaLabel As System.Windows.Forms.Label
        Dim Eficiencia_politropicaLabel As System.Windows.Forms.Label
        Dim Relacion_compresionLabel As System.Windows.Forms.Label
        Dim Eficiencia_globalLabel As System.Windows.Forms.Label
        Dim Eficiencia_hidraulicaLabel As System.Windows.Forms.Label
        Dim Eficiencia_volumetricaLabel As System.Windows.Forms.Label
        Dim Eficiencia_mecanicaLabel As System.Windows.Forms.Label
        Dim Temperatura_succionLabel As System.Windows.Forms.Label
        Dim Temperatura_descargaLabel As System.Windows.Forms.Label
        Dim Presion_succionLabel As System.Windows.Forms.Label
        Dim Presion_descargaLabel As System.Windows.Forms.Label
        Dim Flujo_masicoLabel As System.Windows.Forms.Label
        Dim Flujo_volumetricoLabel As System.Windows.Forms.Label
        Dim ID_sistema_compresionLabel As System.Windows.Forms.Label
        Me.CompresoresDataSet1 = New WindowsApplication1.CompresoresDataSet1()
        Me.CompresorBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.CompresorTableAdapter = New WindowsApplication1.CompresoresDataSet1TableAdapters.CompresorTableAdapter()
        Me.TableAdapterManager = New WindowsApplication1.CompresoresDataSet1TableAdapters.TableAdapterManager()
        Me.CompresorBindingNavigator = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.BindingNavigatorMoveFirstItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMovePreviousItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorPositionItem = New System.Windows.Forms.ToolStripTextBox()
        Me.BindingNavigatorCountItem = New System.Windows.Forms.ToolStripLabel()
        Me.BindingNavigatorSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorMoveNextItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMoveLastItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorAddNewItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorDeleteItem = New System.Windows.Forms.ToolStripButton()
        Me.CompresorBindingNavigatorSaveItem = New System.Windows.Forms.ToolStripButton()
        Me.ID_compresorTextBox = New System.Windows.Forms.TextBox()
        Me.TipoTextBox = New System.Windows.Forms.TextBox()
        Me.RpmTextBox = New System.Windows.Forms.TextBox()
        Me.Consumo_potenciaTextBox = New System.Windows.Forms.TextBox()
        Me.Eficiencia_politropicaTextBox = New System.Windows.Forms.TextBox()
        Me.Relacion_compresionTextBox = New System.Windows.Forms.TextBox()
        Me.Eficiencia_globalTextBox = New System.Windows.Forms.TextBox()
        Me.Eficiencia_hidraulicaTextBox = New System.Windows.Forms.TextBox()
        Me.Eficiencia_volumetricaTextBox = New System.Windows.Forms.TextBox()
        Me.Eficiencia_mecanicaTextBox = New System.Windows.Forms.TextBox()
        Me.Temperatura_succionTextBox = New System.Windows.Forms.TextBox()
        Me.Temperatura_descargaTextBox = New System.Windows.Forms.TextBox()
        Me.Presion_succionTextBox = New System.Windows.Forms.TextBox()
        Me.Presion_descargaTextBox = New System.Windows.Forms.TextBox()
        Me.Flujo_masicoTextBox = New System.Windows.Forms.TextBox()
        Me.Flujo_volumetricoTextBox = New System.Windows.Forms.TextBox()
        Me.ID_sistema_compresionTextBox = New System.Windows.Forms.TextBox()
        Me.CompresorDataGridView = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn12 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn13 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn14 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn15 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn16 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn17 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        ID_compresorLabel = New System.Windows.Forms.Label()
        TipoLabel = New System.Windows.Forms.Label()
        RpmLabel = New System.Windows.Forms.Label()
        Consumo_potenciaLabel = New System.Windows.Forms.Label()
        Eficiencia_politropicaLabel = New System.Windows.Forms.Label()
        Relacion_compresionLabel = New System.Windows.Forms.Label()
        Eficiencia_globalLabel = New System.Windows.Forms.Label()
        Eficiencia_hidraulicaLabel = New System.Windows.Forms.Label()
        Eficiencia_volumetricaLabel = New System.Windows.Forms.Label()
        Eficiencia_mecanicaLabel = New System.Windows.Forms.Label()
        Temperatura_succionLabel = New System.Windows.Forms.Label()
        Temperatura_descargaLabel = New System.Windows.Forms.Label()
        Presion_succionLabel = New System.Windows.Forms.Label()
        Presion_descargaLabel = New System.Windows.Forms.Label()
        Flujo_masicoLabel = New System.Windows.Forms.Label()
        Flujo_volumetricoLabel = New System.Windows.Forms.Label()
        ID_sistema_compresionLabel = New System.Windows.Forms.Label()
        CType(Me.CompresoresDataSet1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CompresorBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CompresorBindingNavigator, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.CompresorBindingNavigator.SuspendLayout()
        CType(Me.CompresorDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CompresoresDataSet1
        '
        Me.CompresoresDataSet1.DataSetName = "CompresoresDataSet1"
        Me.CompresoresDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'CompresorBindingSource
        '
        Me.CompresorBindingSource.DataMember = "Compresor"
        Me.CompresorBindingSource.DataSource = Me.CompresoresDataSet1
        '
        'CompresorTableAdapter
        '
        Me.CompresorTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.AccesorioTableAdapter = Nothing
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.BombaTableAdapter = Nothing
        Me.TableAdapterManager.Caso_estudioTableAdapter = Nothing
        Me.TableAdapterManager.CodoTableAdapter = Nothing
        Me.TableAdapterManager.Composicion_disenoTableAdapter = Nothing
        Me.TableAdapterManager.CompresorTableAdapter = Me.CompresorTableAdapter
        Me.TableAdapterManager.FluidoTableAdapter = Nothing
        Me.TableAdapterManager.Nominal_bombaTableAdapter = Nothing
        Me.TableAdapterManager.Nominal_compresorTableAdapter = Nothing
        Me.TableAdapterManager.Sistema_bombeoTableAdapter = Nothing
        Me.TableAdapterManager.Sistema_compresionTableAdapter = Nothing
        Me.TableAdapterManager.Tanque_reservorioTableAdapter = Nothing
        Me.TableAdapterManager.TuberiaTableAdapter = Nothing
        Me.TableAdapterManager.UpdateOrder = WindowsApplication1.CompresoresDataSet1TableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        Me.TableAdapterManager.UsuarioTableAdapter = Nothing
        Me.TableAdapterManager.Valvula_filtroTableAdapter = Nothing
        '
        'CompresorBindingNavigator
        '
        Me.CompresorBindingNavigator.AddNewItem = Me.BindingNavigatorAddNewItem
        Me.CompresorBindingNavigator.BindingSource = Me.CompresorBindingSource
        Me.CompresorBindingNavigator.CountItem = Me.BindingNavigatorCountItem
        Me.CompresorBindingNavigator.DeleteItem = Me.BindingNavigatorDeleteItem
        Me.CompresorBindingNavigator.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.BindingNavigatorSeparator2, Me.BindingNavigatorAddNewItem, Me.BindingNavigatorDeleteItem, Me.CompresorBindingNavigatorSaveItem})
        Me.CompresorBindingNavigator.Location = New System.Drawing.Point(0, 0)
        Me.CompresorBindingNavigator.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
        Me.CompresorBindingNavigator.MoveLastItem = Me.BindingNavigatorMoveLastItem
        Me.CompresorBindingNavigator.MoveNextItem = Me.BindingNavigatorMoveNextItem
        Me.CompresorBindingNavigator.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
        Me.CompresorBindingNavigator.Name = "CompresorBindingNavigator"
        Me.CompresorBindingNavigator.PositionItem = Me.BindingNavigatorPositionItem
        Me.CompresorBindingNavigator.Size = New System.Drawing.Size(640, 25)
        Me.CompresorBindingNavigator.TabIndex = 0
        Me.CompresorBindingNavigator.Text = "BindingNavigator1"
        '
        'BindingNavigatorMoveFirstItem
        '
        Me.BindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveFirstItem.Image = CType(resources.GetObject("BindingNavigatorMoveFirstItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveFirstItem.Name = "BindingNavigatorMoveFirstItem"
        Me.BindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveFirstItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveFirstItem.Text = "Move first"
        '
        'BindingNavigatorMovePreviousItem
        '
        Me.BindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMovePreviousItem.Image = CType(resources.GetObject("BindingNavigatorMovePreviousItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMovePreviousItem.Name = "BindingNavigatorMovePreviousItem"
        Me.BindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMovePreviousItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMovePreviousItem.Text = "Move previous"
        '
        'BindingNavigatorSeparator
        '
        Me.BindingNavigatorSeparator.Name = "BindingNavigatorSeparator"
        Me.BindingNavigatorSeparator.Size = New System.Drawing.Size(6, 25)
        '
        'BindingNavigatorPositionItem
        '
        Me.BindingNavigatorPositionItem.AccessibleName = "Position"
        Me.BindingNavigatorPositionItem.AutoSize = False
        Me.BindingNavigatorPositionItem.Name = "BindingNavigatorPositionItem"
        Me.BindingNavigatorPositionItem.Size = New System.Drawing.Size(50, 23)
        Me.BindingNavigatorPositionItem.Text = "0"
        Me.BindingNavigatorPositionItem.ToolTipText = "Current position"
        '
        'BindingNavigatorCountItem
        '
        Me.BindingNavigatorCountItem.Name = "BindingNavigatorCountItem"
        Me.BindingNavigatorCountItem.Size = New System.Drawing.Size(35, 15)
        Me.BindingNavigatorCountItem.Text = "of {0}"
        Me.BindingNavigatorCountItem.ToolTipText = "Total number of items"
        '
        'BindingNavigatorSeparator1
        '
        Me.BindingNavigatorSeparator1.Name = "BindingNavigatorSeparator"
        Me.BindingNavigatorSeparator1.Size = New System.Drawing.Size(6, 6)
        '
        'BindingNavigatorMoveNextItem
        '
        Me.BindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveNextItem.Image = CType(resources.GetObject("BindingNavigatorMoveNextItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveNextItem.Name = "BindingNavigatorMoveNextItem"
        Me.BindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveNextItem.Size = New System.Drawing.Size(23, 20)
        Me.BindingNavigatorMoveNextItem.Text = "Move next"
        '
        'BindingNavigatorMoveLastItem
        '
        Me.BindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveLastItem.Image = CType(resources.GetObject("BindingNavigatorMoveLastItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveLastItem.Name = "BindingNavigatorMoveLastItem"
        Me.BindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveLastItem.Size = New System.Drawing.Size(23, 20)
        Me.BindingNavigatorMoveLastItem.Text = "Move last"
        '
        'BindingNavigatorSeparator2
        '
        Me.BindingNavigatorSeparator2.Name = "BindingNavigatorSeparator"
        Me.BindingNavigatorSeparator2.Size = New System.Drawing.Size(6, 6)
        '
        'BindingNavigatorAddNewItem
        '
        Me.BindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorAddNewItem.Image = CType(resources.GetObject("BindingNavigatorAddNewItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorAddNewItem.Name = "BindingNavigatorAddNewItem"
        Me.BindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorAddNewItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorAddNewItem.Text = "Add new"
        '
        'BindingNavigatorDeleteItem
        '
        Me.BindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorDeleteItem.Image = CType(resources.GetObject("BindingNavigatorDeleteItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorDeleteItem.Name = "BindingNavigatorDeleteItem"
        Me.BindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorDeleteItem.Size = New System.Drawing.Size(23, 20)
        Me.BindingNavigatorDeleteItem.Text = "Delete"
        '
        'CompresorBindingNavigatorSaveItem
        '
        Me.CompresorBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.CompresorBindingNavigatorSaveItem.Image = CType(resources.GetObject("CompresorBindingNavigatorSaveItem.Image"), System.Drawing.Image)
        Me.CompresorBindingNavigatorSaveItem.Name = "CompresorBindingNavigatorSaveItem"
        Me.CompresorBindingNavigatorSaveItem.Size = New System.Drawing.Size(23, 23)
        Me.CompresorBindingNavigatorSaveItem.Text = "Save Data"
        '
        'ID_compresorLabel
        '
        ID_compresorLabel.AutoSize = True
        ID_compresorLabel.Location = New System.Drawing.Point(28, 45)
        ID_compresorLabel.Name = "ID_compresorLabel"
        ID_compresorLabel.Size = New System.Drawing.Size(73, 13)
        ID_compresorLabel.TabIndex = 1
        ID_compresorLabel.Text = "ID compresor:"
        '
        'ID_compresorTextBox
        '
        Me.ID_compresorTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CompresorBindingSource, "ID_compresor", True))
        Me.ID_compresorTextBox.Location = New System.Drawing.Point(150, 42)
        Me.ID_compresorTextBox.Name = "ID_compresorTextBox"
        Me.ID_compresorTextBox.Size = New System.Drawing.Size(100, 20)
        Me.ID_compresorTextBox.TabIndex = 2
        '
        'TipoLabel
        '
        TipoLabel.AutoSize = True
        TipoLabel.Location = New System.Drawing.Point(28, 71)
        TipoLabel.Name = "TipoLabel"
        TipoLabel.Size = New System.Drawing.Size(27, 13)
        TipoLabel.TabIndex = 3
        TipoLabel.Text = "tipo:"
        '
        'TipoTextBox
        '
        Me.TipoTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CompresorBindingSource, "tipo", True))
        Me.TipoTextBox.Location = New System.Drawing.Point(150, 68)
        Me.TipoTextBox.Name = "TipoTextBox"
        Me.TipoTextBox.Size = New System.Drawing.Size(100, 20)
        Me.TipoTextBox.TabIndex = 4
        '
        'RpmLabel
        '
        RpmLabel.AutoSize = True
        RpmLabel.Location = New System.Drawing.Point(28, 97)
        RpmLabel.Name = "RpmLabel"
        RpmLabel.Size = New System.Drawing.Size(27, 13)
        RpmLabel.TabIndex = 5
        RpmLabel.Text = "rpm:"
        '
        'RpmTextBox
        '
        Me.RpmTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CompresorBindingSource, "rpm", True))
        Me.RpmTextBox.Location = New System.Drawing.Point(150, 94)
        Me.RpmTextBox.Name = "RpmTextBox"
        Me.RpmTextBox.Size = New System.Drawing.Size(100, 20)
        Me.RpmTextBox.TabIndex = 6
        '
        'Consumo_potenciaLabel
        '
        Consumo_potenciaLabel.AutoSize = True
        Consumo_potenciaLabel.Location = New System.Drawing.Point(28, 123)
        Consumo_potenciaLabel.Name = "Consumo_potenciaLabel"
        Consumo_potenciaLabel.Size = New System.Drawing.Size(97, 13)
        Consumo_potenciaLabel.TabIndex = 7
        Consumo_potenciaLabel.Text = "consumo potencia:"
        '
        'Consumo_potenciaTextBox
        '
        Me.Consumo_potenciaTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CompresorBindingSource, "consumo_potencia", True))
        Me.Consumo_potenciaTextBox.Location = New System.Drawing.Point(150, 120)
        Me.Consumo_potenciaTextBox.Name = "Consumo_potenciaTextBox"
        Me.Consumo_potenciaTextBox.Size = New System.Drawing.Size(100, 20)
        Me.Consumo_potenciaTextBox.TabIndex = 8
        '
        'Eficiencia_politropicaLabel
        '
        Eficiencia_politropicaLabel.AutoSize = True
        Eficiencia_politropicaLabel.Location = New System.Drawing.Point(28, 149)
        Eficiencia_politropicaLabel.Name = "Eficiencia_politropicaLabel"
        Eficiencia_politropicaLabel.Size = New System.Drawing.Size(106, 13)
        Eficiencia_politropicaLabel.TabIndex = 9
        Eficiencia_politropicaLabel.Text = "eficiencia politropica:"
        '
        'Eficiencia_politropicaTextBox
        '
        Me.Eficiencia_politropicaTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CompresorBindingSource, "eficiencia_politropica", True))
        Me.Eficiencia_politropicaTextBox.Location = New System.Drawing.Point(150, 146)
        Me.Eficiencia_politropicaTextBox.Name = "Eficiencia_politropicaTextBox"
        Me.Eficiencia_politropicaTextBox.Size = New System.Drawing.Size(100, 20)
        Me.Eficiencia_politropicaTextBox.TabIndex = 10
        '
        'Relacion_compresionLabel
        '
        Relacion_compresionLabel.AutoSize = True
        Relacion_compresionLabel.Location = New System.Drawing.Point(28, 175)
        Relacion_compresionLabel.Name = "Relacion_compresionLabel"
        Relacion_compresionLabel.Size = New System.Drawing.Size(104, 13)
        Relacion_compresionLabel.TabIndex = 11
        Relacion_compresionLabel.Text = "relacion compresion:"
        '
        'Relacion_compresionTextBox
        '
        Me.Relacion_compresionTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CompresorBindingSource, "relacion_compresion", True))
        Me.Relacion_compresionTextBox.Location = New System.Drawing.Point(150, 172)
        Me.Relacion_compresionTextBox.Name = "Relacion_compresionTextBox"
        Me.Relacion_compresionTextBox.Size = New System.Drawing.Size(100, 20)
        Me.Relacion_compresionTextBox.TabIndex = 12
        '
        'Eficiencia_globalLabel
        '
        Eficiencia_globalLabel.AutoSize = True
        Eficiencia_globalLabel.Location = New System.Drawing.Point(28, 201)
        Eficiencia_globalLabel.Name = "Eficiencia_globalLabel"
        Eficiencia_globalLabel.Size = New System.Drawing.Size(86, 13)
        Eficiencia_globalLabel.TabIndex = 13
        Eficiencia_globalLabel.Text = "eficiencia global:"
        '
        'Eficiencia_globalTextBox
        '
        Me.Eficiencia_globalTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CompresorBindingSource, "eficiencia_global", True))
        Me.Eficiencia_globalTextBox.Location = New System.Drawing.Point(150, 198)
        Me.Eficiencia_globalTextBox.Name = "Eficiencia_globalTextBox"
        Me.Eficiencia_globalTextBox.Size = New System.Drawing.Size(100, 20)
        Me.Eficiencia_globalTextBox.TabIndex = 14
        '
        'Eficiencia_hidraulicaLabel
        '
        Eficiencia_hidraulicaLabel.AutoSize = True
        Eficiencia_hidraulicaLabel.Location = New System.Drawing.Point(28, 227)
        Eficiencia_hidraulicaLabel.Name = "Eficiencia_hidraulicaLabel"
        Eficiencia_hidraulicaLabel.Size = New System.Drawing.Size(103, 13)
        Eficiencia_hidraulicaLabel.TabIndex = 15
        Eficiencia_hidraulicaLabel.Text = "eficiencia hidraulica:"
        '
        'Eficiencia_hidraulicaTextBox
        '
        Me.Eficiencia_hidraulicaTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CompresorBindingSource, "eficiencia_hidraulica", True))
        Me.Eficiencia_hidraulicaTextBox.Location = New System.Drawing.Point(150, 224)
        Me.Eficiencia_hidraulicaTextBox.Name = "Eficiencia_hidraulicaTextBox"
        Me.Eficiencia_hidraulicaTextBox.Size = New System.Drawing.Size(100, 20)
        Me.Eficiencia_hidraulicaTextBox.TabIndex = 16
        '
        'Eficiencia_volumetricaLabel
        '
        Eficiencia_volumetricaLabel.AutoSize = True
        Eficiencia_volumetricaLabel.Location = New System.Drawing.Point(28, 253)
        Eficiencia_volumetricaLabel.Name = "Eficiencia_volumetricaLabel"
        Eficiencia_volumetricaLabel.Size = New System.Drawing.Size(112, 13)
        Eficiencia_volumetricaLabel.TabIndex = 17
        Eficiencia_volumetricaLabel.Text = "eficiencia volumetrica:"
        '
        'Eficiencia_volumetricaTextBox
        '
        Me.Eficiencia_volumetricaTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CompresorBindingSource, "eficiencia_volumetrica", True))
        Me.Eficiencia_volumetricaTextBox.Location = New System.Drawing.Point(150, 250)
        Me.Eficiencia_volumetricaTextBox.Name = "Eficiencia_volumetricaTextBox"
        Me.Eficiencia_volumetricaTextBox.Size = New System.Drawing.Size(100, 20)
        Me.Eficiencia_volumetricaTextBox.TabIndex = 18
        '
        'Eficiencia_mecanicaLabel
        '
        Eficiencia_mecanicaLabel.AutoSize = True
        Eficiencia_mecanicaLabel.Location = New System.Drawing.Point(28, 279)
        Eficiencia_mecanicaLabel.Name = "Eficiencia_mecanicaLabel"
        Eficiencia_mecanicaLabel.Size = New System.Drawing.Size(104, 13)
        Eficiencia_mecanicaLabel.TabIndex = 19
        Eficiencia_mecanicaLabel.Text = "eficiencia mecanica:"
        '
        'Eficiencia_mecanicaTextBox
        '
        Me.Eficiencia_mecanicaTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CompresorBindingSource, "eficiencia_mecanica", True))
        Me.Eficiencia_mecanicaTextBox.Location = New System.Drawing.Point(150, 276)
        Me.Eficiencia_mecanicaTextBox.Name = "Eficiencia_mecanicaTextBox"
        Me.Eficiencia_mecanicaTextBox.Size = New System.Drawing.Size(100, 20)
        Me.Eficiencia_mecanicaTextBox.TabIndex = 20
        '
        'Temperatura_succionLabel
        '
        Temperatura_succionLabel.AutoSize = True
        Temperatura_succionLabel.Location = New System.Drawing.Point(28, 305)
        Temperatura_succionLabel.Name = "Temperatura_succionLabel"
        Temperatura_succionLabel.Size = New System.Drawing.Size(106, 13)
        Temperatura_succionLabel.TabIndex = 21
        Temperatura_succionLabel.Text = "temperatura succion:"
        '
        'Temperatura_succionTextBox
        '
        Me.Temperatura_succionTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CompresorBindingSource, "temperatura_succion", True))
        Me.Temperatura_succionTextBox.Location = New System.Drawing.Point(150, 302)
        Me.Temperatura_succionTextBox.Name = "Temperatura_succionTextBox"
        Me.Temperatura_succionTextBox.Size = New System.Drawing.Size(100, 20)
        Me.Temperatura_succionTextBox.TabIndex = 22
        '
        'Temperatura_descargaLabel
        '
        Temperatura_descargaLabel.AutoSize = True
        Temperatura_descargaLabel.Location = New System.Drawing.Point(28, 331)
        Temperatura_descargaLabel.Name = "Temperatura_descargaLabel"
        Temperatura_descargaLabel.Size = New System.Drawing.Size(113, 13)
        Temperatura_descargaLabel.TabIndex = 23
        Temperatura_descargaLabel.Text = "temperatura descarga:"
        '
        'Temperatura_descargaTextBox
        '
        Me.Temperatura_descargaTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CompresorBindingSource, "temperatura_descarga", True))
        Me.Temperatura_descargaTextBox.Location = New System.Drawing.Point(150, 328)
        Me.Temperatura_descargaTextBox.Name = "Temperatura_descargaTextBox"
        Me.Temperatura_descargaTextBox.Size = New System.Drawing.Size(100, 20)
        Me.Temperatura_descargaTextBox.TabIndex = 24
        '
        'Presion_succionLabel
        '
        Presion_succionLabel.AutoSize = True
        Presion_succionLabel.Location = New System.Drawing.Point(28, 357)
        Presion_succionLabel.Name = "Presion_succionLabel"
        Presion_succionLabel.Size = New System.Drawing.Size(84, 13)
        Presion_succionLabel.TabIndex = 25
        Presion_succionLabel.Text = "presion succion:"
        '
        'Presion_succionTextBox
        '
        Me.Presion_succionTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CompresorBindingSource, "presion_succion", True))
        Me.Presion_succionTextBox.Location = New System.Drawing.Point(150, 354)
        Me.Presion_succionTextBox.Name = "Presion_succionTextBox"
        Me.Presion_succionTextBox.Size = New System.Drawing.Size(100, 20)
        Me.Presion_succionTextBox.TabIndex = 26
        '
        'Presion_descargaLabel
        '
        Presion_descargaLabel.AutoSize = True
        Presion_descargaLabel.Location = New System.Drawing.Point(28, 383)
        Presion_descargaLabel.Name = "Presion_descargaLabel"
        Presion_descargaLabel.Size = New System.Drawing.Size(91, 13)
        Presion_descargaLabel.TabIndex = 27
        Presion_descargaLabel.Text = "presion descarga:"
        '
        'Presion_descargaTextBox
        '
        Me.Presion_descargaTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CompresorBindingSource, "presion_descarga", True))
        Me.Presion_descargaTextBox.Location = New System.Drawing.Point(150, 380)
        Me.Presion_descargaTextBox.Name = "Presion_descargaTextBox"
        Me.Presion_descargaTextBox.Size = New System.Drawing.Size(100, 20)
        Me.Presion_descargaTextBox.TabIndex = 28
        '
        'Flujo_masicoLabel
        '
        Flujo_masicoLabel.AutoSize = True
        Flujo_masicoLabel.Location = New System.Drawing.Point(28, 409)
        Flujo_masicoLabel.Name = "Flujo_masicoLabel"
        Flujo_masicoLabel.Size = New System.Drawing.Size(65, 13)
        Flujo_masicoLabel.TabIndex = 29
        Flujo_masicoLabel.Text = "flujo masico:"
        '
        'Flujo_masicoTextBox
        '
        Me.Flujo_masicoTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CompresorBindingSource, "flujo_masico", True))
        Me.Flujo_masicoTextBox.Location = New System.Drawing.Point(150, 406)
        Me.Flujo_masicoTextBox.Name = "Flujo_masicoTextBox"
        Me.Flujo_masicoTextBox.Size = New System.Drawing.Size(100, 20)
        Me.Flujo_masicoTextBox.TabIndex = 30
        '
        'Flujo_volumetricoLabel
        '
        Flujo_volumetricoLabel.AutoSize = True
        Flujo_volumetricoLabel.Location = New System.Drawing.Point(28, 435)
        Flujo_volumetricoLabel.Name = "Flujo_volumetricoLabel"
        Flujo_volumetricoLabel.Size = New System.Drawing.Size(86, 13)
        Flujo_volumetricoLabel.TabIndex = 31
        Flujo_volumetricoLabel.Text = "flujo volumetrico:"
        '
        'Flujo_volumetricoTextBox
        '
        Me.Flujo_volumetricoTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CompresorBindingSource, "flujo_volumetrico", True))
        Me.Flujo_volumetricoTextBox.Location = New System.Drawing.Point(150, 432)
        Me.Flujo_volumetricoTextBox.Name = "Flujo_volumetricoTextBox"
        Me.Flujo_volumetricoTextBox.Size = New System.Drawing.Size(100, 20)
        Me.Flujo_volumetricoTextBox.TabIndex = 32
        '
        'ID_sistema_compresionLabel
        '
        ID_sistema_compresionLabel.AutoSize = True
        ID_sistema_compresionLabel.Location = New System.Drawing.Point(28, 461)
        ID_sistema_compresionLabel.Name = "ID_sistema_compresionLabel"
        ID_sistema_compresionLabel.Size = New System.Drawing.Size(116, 13)
        ID_sistema_compresionLabel.TabIndex = 33
        ID_sistema_compresionLabel.Text = "ID sistema compresion:"
        '
        'ID_sistema_compresionTextBox
        '
        Me.ID_sistema_compresionTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CompresorBindingSource, "ID_sistema_compresion", True))
        Me.ID_sistema_compresionTextBox.Location = New System.Drawing.Point(150, 458)
        Me.ID_sistema_compresionTextBox.Name = "ID_sistema_compresionTextBox"
        Me.ID_sistema_compresionTextBox.Size = New System.Drawing.Size(100, 20)
        Me.ID_sistema_compresionTextBox.TabIndex = 34
        '
        'CompresorDataGridView
        '
        Me.CompresorDataGridView.AutoGenerateColumns = False
        Me.CompresorDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.CompresorDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4, Me.DataGridViewTextBoxColumn5, Me.DataGridViewTextBoxColumn6, Me.DataGridViewTextBoxColumn7, Me.DataGridViewTextBoxColumn8, Me.DataGridViewTextBoxColumn9, Me.DataGridViewTextBoxColumn10, Me.DataGridViewTextBoxColumn11, Me.DataGridViewTextBoxColumn12, Me.DataGridViewTextBoxColumn13, Me.DataGridViewTextBoxColumn14, Me.DataGridViewTextBoxColumn15, Me.DataGridViewTextBoxColumn16, Me.DataGridViewTextBoxColumn17})
        Me.CompresorDataGridView.DataSource = Me.CompresorBindingSource
        Me.CompresorDataGridView.Location = New System.Drawing.Point(10, 501)
        Me.CompresorDataGridView.Name = "CompresorDataGridView"
        Me.CompresorDataGridView.Size = New System.Drawing.Size(618, 71)
        Me.CompresorDataGridView.TabIndex = 35
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "ID_compresor"
        Me.DataGridViewTextBoxColumn1.HeaderText = "ID_compresor"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "tipo"
        Me.DataGridViewTextBoxColumn2.HeaderText = "tipo"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "rpm"
        Me.DataGridViewTextBoxColumn3.HeaderText = "rpm"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "consumo_potencia"
        Me.DataGridViewTextBoxColumn4.HeaderText = "consumo_potencia"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "eficiencia_politropica"
        Me.DataGridViewTextBoxColumn5.HeaderText = "eficiencia_politropica"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "relacion_compresion"
        Me.DataGridViewTextBoxColumn6.HeaderText = "relacion_compresion"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "eficiencia_global"
        Me.DataGridViewTextBoxColumn7.HeaderText = "eficiencia_global"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.DataPropertyName = "eficiencia_hidraulica"
        Me.DataGridViewTextBoxColumn8.HeaderText = "eficiencia_hidraulica"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.DataPropertyName = "eficiencia_volumetrica"
        Me.DataGridViewTextBoxColumn9.HeaderText = "eficiencia_volumetrica"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.DataPropertyName = "eficiencia_mecanica"
        Me.DataGridViewTextBoxColumn10.HeaderText = "eficiencia_mecanica"
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        '
        'DataGridViewTextBoxColumn11
        '
        Me.DataGridViewTextBoxColumn11.DataPropertyName = "temperatura_succion"
        Me.DataGridViewTextBoxColumn11.HeaderText = "temperatura_succion"
        Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
        '
        'DataGridViewTextBoxColumn12
        '
        Me.DataGridViewTextBoxColumn12.DataPropertyName = "temperatura_descarga"
        Me.DataGridViewTextBoxColumn12.HeaderText = "temperatura_descarga"
        Me.DataGridViewTextBoxColumn12.Name = "DataGridViewTextBoxColumn12"
        '
        'DataGridViewTextBoxColumn13
        '
        Me.DataGridViewTextBoxColumn13.DataPropertyName = "presion_succion"
        Me.DataGridViewTextBoxColumn13.HeaderText = "presion_succion"
        Me.DataGridViewTextBoxColumn13.Name = "DataGridViewTextBoxColumn13"
        '
        'DataGridViewTextBoxColumn14
        '
        Me.DataGridViewTextBoxColumn14.DataPropertyName = "presion_descarga"
        Me.DataGridViewTextBoxColumn14.HeaderText = "presion_descarga"
        Me.DataGridViewTextBoxColumn14.Name = "DataGridViewTextBoxColumn14"
        '
        'DataGridViewTextBoxColumn15
        '
        Me.DataGridViewTextBoxColumn15.DataPropertyName = "flujo_masico"
        Me.DataGridViewTextBoxColumn15.HeaderText = "flujo_masico"
        Me.DataGridViewTextBoxColumn15.Name = "DataGridViewTextBoxColumn15"
        '
        'DataGridViewTextBoxColumn16
        '
        Me.DataGridViewTextBoxColumn16.DataPropertyName = "flujo_volumetrico"
        Me.DataGridViewTextBoxColumn16.HeaderText = "flujo_volumetrico"
        Me.DataGridViewTextBoxColumn16.Name = "DataGridViewTextBoxColumn16"
        '
        'DataGridViewTextBoxColumn17
        '
        Me.DataGridViewTextBoxColumn17.DataPropertyName = "ID_sistema_compresion"
        Me.DataGridViewTextBoxColumn17.HeaderText = "ID_sistema_compresion"
        Me.DataGridViewTextBoxColumn17.Name = "DataGridViewTextBoxColumn17"
        '
        'TablaBD
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(640, 746)
        Me.Controls.Add(Me.CompresorDataGridView)
        Me.Controls.Add(ID_compresorLabel)
        Me.Controls.Add(Me.ID_compresorTextBox)
        Me.Controls.Add(TipoLabel)
        Me.Controls.Add(Me.TipoTextBox)
        Me.Controls.Add(RpmLabel)
        Me.Controls.Add(Me.RpmTextBox)
        Me.Controls.Add(Consumo_potenciaLabel)
        Me.Controls.Add(Me.Consumo_potenciaTextBox)
        Me.Controls.Add(Eficiencia_politropicaLabel)
        Me.Controls.Add(Me.Eficiencia_politropicaTextBox)
        Me.Controls.Add(Relacion_compresionLabel)
        Me.Controls.Add(Me.Relacion_compresionTextBox)
        Me.Controls.Add(Eficiencia_globalLabel)
        Me.Controls.Add(Me.Eficiencia_globalTextBox)
        Me.Controls.Add(Eficiencia_hidraulicaLabel)
        Me.Controls.Add(Me.Eficiencia_hidraulicaTextBox)
        Me.Controls.Add(Eficiencia_volumetricaLabel)
        Me.Controls.Add(Me.Eficiencia_volumetricaTextBox)
        Me.Controls.Add(Eficiencia_mecanicaLabel)
        Me.Controls.Add(Me.Eficiencia_mecanicaTextBox)
        Me.Controls.Add(Temperatura_succionLabel)
        Me.Controls.Add(Me.Temperatura_succionTextBox)
        Me.Controls.Add(Temperatura_descargaLabel)
        Me.Controls.Add(Me.Temperatura_descargaTextBox)
        Me.Controls.Add(Presion_succionLabel)
        Me.Controls.Add(Me.Presion_succionTextBox)
        Me.Controls.Add(Presion_descargaLabel)
        Me.Controls.Add(Me.Presion_descargaTextBox)
        Me.Controls.Add(Flujo_masicoLabel)
        Me.Controls.Add(Me.Flujo_masicoTextBox)
        Me.Controls.Add(Flujo_volumetricoLabel)
        Me.Controls.Add(Me.Flujo_volumetricoTextBox)
        Me.Controls.Add(ID_sistema_compresionLabel)
        Me.Controls.Add(Me.ID_sistema_compresionTextBox)
        Me.Controls.Add(Me.CompresorBindingNavigator)
        Me.Name = "TablaBD"
        Me.Text = "TablaBD"
        CType(Me.CompresoresDataSet1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CompresorBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CompresorBindingNavigator, System.ComponentModel.ISupportInitialize).EndInit()
        Me.CompresorBindingNavigator.ResumeLayout(False)
        Me.CompresorBindingNavigator.PerformLayout()
        CType(Me.CompresorDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CompresoresDataSet1 As WindowsApplication1.CompresoresDataSet1
    Friend WithEvents CompresorBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CompresorTableAdapter As WindowsApplication1.CompresoresDataSet1TableAdapters.CompresorTableAdapter
    Friend WithEvents TableAdapterManager As WindowsApplication1.CompresoresDataSet1TableAdapters.TableAdapterManager
    Friend WithEvents CompresorBindingNavigator As System.Windows.Forms.BindingNavigator
    Friend WithEvents BindingNavigatorAddNewItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorCountItem As System.Windows.Forms.ToolStripLabel
    Friend WithEvents BindingNavigatorDeleteItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMoveFirstItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMovePreviousItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorPositionItem As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents BindingNavigatorSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorMoveNextItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMoveLastItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents CompresorBindingNavigatorSaveItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents ID_compresorTextBox As System.Windows.Forms.TextBox
    Friend WithEvents TipoTextBox As System.Windows.Forms.TextBox
    Friend WithEvents RpmTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Consumo_potenciaTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Eficiencia_politropicaTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Relacion_compresionTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Eficiencia_globalTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Eficiencia_hidraulicaTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Eficiencia_volumetricaTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Eficiencia_mecanicaTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Temperatura_succionTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Temperatura_descargaTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Presion_succionTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Presion_descargaTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Flujo_masicoTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Flujo_volumetricoTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ID_sistema_compresionTextBox As System.Windows.Forms.TextBox
    Friend WithEvents CompresorDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn12 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn13 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn14 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn15 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn16 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn17 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
