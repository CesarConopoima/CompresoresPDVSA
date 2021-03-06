SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Usuario]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Usuario](
	[ID_usuario] [int] NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[descripcion] [varchar](200) NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[ID_usuario] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [unique_nombre] UNIQUE NONCLUSTERED 
(
	[nombre] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Caso_estudio]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Caso_estudio](
	[ID_caso_estudio] [int] NOT NULL,
	[fecha] [datetime] NULL,
	[nombre] [varchar](50) NULL,
	[ID_usuario] [int] NULL,
 CONSTRAINT [PK_Caso_estudio] PRIMARY KEY CLUSTERED 
(
	[ID_caso_estudio] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Planta]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Planta](
	[ID_planta] [int] NOT NULL,
	[nombre_planta] [varchar](50) NULL,
	[descripcion] [text] NULL,
	[ID_caso_estudio] [int] NULL,
 CONSTRAINT [PK_Planta] PRIMARY KEY CLUSTERED 
(
	[ID_planta] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Sistema_bombeo]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Sistema_bombeo](
	[ID_sistema_bombeo] [int] NOT NULL,
	[nombre] [varchar](50) NULL,
	[ID_planta] [int] NULL,
 CONSTRAINT [PK_Sistema_bombeo] PRIMARY KEY CLUSTERED 
(
	[ID_sistema_bombeo] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Sistema_compresion]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Sistema_compresion](
	[ID_sistema_compresion] [int] NOT NULL,
	[nombre] [varchar](50) NULL,
	[ID_planta] [int] NULL,
 CONSTRAINT [PK_Sistema_compresion] PRIMARY KEY CLUSTERED 
(
	[ID_sistema_compresion] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Tanque_reservorio]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Tanque_reservorio](
	[ID_taque_reservorio] [int] NOT NULL,
	[diametro] [decimal](18, 0) NULL,
	[capacidad] [decimal](18, 0) NULL,
	[tipo] [varchar](50) NULL,
	[altura] [decimal](18, 0) NULL,
	[contenido] [varchar](50) NULL,
	[nombre] [varchar](50) NULL,
 CONSTRAINT [PK_Tanque_reservorio] PRIMARY KEY CLUSTERED 
(
	[ID_taque_reservorio] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Tuberia]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Tuberia](
	[ID_tuberia] [int] NOT NULL,
	[diametro] [decimal](18, 0) NULL,
	[longitud] [decimal](18, 0) NULL,
	[rugosidad] [decimal](18, 0) NULL,
	[longevidad] [decimal](18, 0) NULL,
	[tipo] [varchar](50) NULL,
	[ID_sistema_compresion] [int] NULL,
	[ID_sistema_bombeo] [int] NULL,
 CONSTRAINT [PK_Tuberia] PRIMARY KEY CLUSTERED 
(
	[ID_tuberia] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Codo]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Codo](
	[ID_codo] [int] NOT NULL,
	[longitud_equivalente] [decimal](18, 0) NULL,
	[diametro] [decimal](18, 0) NULL,
	[grado] [int] NULL,
	[nombre] [varchar](50) NULL,
	[ID_accesorio] [int] NULL,
 CONSTRAINT [PK_Codo] PRIMARY KEY CLUSTERED 
(
	[ID_codo] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Valvula_filtro]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Valvula_filtro](
	[ID_valvula_filtro] [int] NOT NULL,
	[perdida] [decimal](18, 0) NULL,
	[tipo] [varchar](50) NULL,
	[diametro] [decimal](18, 0) NULL,
	[apertura] [bit] NULL,
	[ID_accesorio] [int] NULL,
 CONSTRAINT [PK_Valvula_filtro] PRIMARY KEY CLUSTERED 
(
	[ID_valvula_filtro] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Nominal_bomba]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Nominal_bomba](
	[ID_nominal_bomba] [int] NOT NULL,
	[tipo] [varchar](50) NULL,
	[rpm] [int] NULL,
	[consumo_potencia] [decimal](18, 0) NULL,
	[factor_seguridad] [decimal](18, 0) NULL,
	[relacion_compresion] [decimal](18, 0) NULL,
	[eficiencia_global] [decimal](18, 0) NULL,
	[eficiencia_hidraulica] [decimal](18, 0) NULL,
	[eficiencia_volumetrica] [decimal](18, 0) NULL,
	[eficiencia_mecanica] [decimal](18, 0) NULL,
	[temperatura_succion] [decimal](18, 0) NULL,
	[altura_succion] [decimal](18, 0) NULL,
	[presion_succion] [decimal](18, 0) NULL,
	[presion_descarga] [decimal](18, 0) NULL,
	[flujo_masico] [decimal](18, 0) NULL,
	[flujo_volumetrico] [decimal](18, 0) NULL,
	[NPSH_requerido] [decimal](18, 0) NULL,
	[NPSH_disponible] [decimal](18, 0) NULL,
	[ID_bomba] [int] NULL,
 CONSTRAINT [PK_Nominal_bomba] PRIMARY KEY CLUSTERED 
(
	[ID_nominal_bomba] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Nominal_compresor]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Nominal_compresor](
	[ID_nominal_compresor] [int] NOT NULL,
	[tipo] [varchar](50) NULL,
	[rpm] [int] NULL,
	[consumo_potencia] [decimal](18, 0) NULL,
	[eficiencia_politropica] [decimal](18, 0) NULL,
	[relacion_compresion] [decimal](18, 0) NULL,
	[eficiencia_global] [decimal](18, 0) NULL,
	[eficiencia_hidraulica] [decimal](18, 0) NULL,
	[flujo_masico] [decimal](18, 0) NULL,
	[flujo_volumetrico] [decimal](18, 0) NULL,
	[eficiencia_volumetrica] [decimal](18, 0) NULL,
	[eficiencia_mecanica] [decimal](18, 0) NULL,
	[temperatura_succion] [decimal](18, 0) NULL,
	[temperatura_descarga] [decimal](18, 0) NULL,
	[presion_succion] [decimal](18, 0) NULL,
	[presion_descarga] [decimal](18, 0) NULL,
	[ID_compresor] [int] NULL,
 CONSTRAINT [PK_Nominal_compresor] PRIMARY KEY CLUSTERED 
(
	[ID_nominal_compresor] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Composicion_diseno]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Composicion_diseno](
	[ID_composicion_diseno] [int] NULL,
	[presion_ambiental] [decimal](18, 0) NULL,
	[temperatura_ambiental] [decimal](18, 0) NULL,
	[humedad_relativa] [decimal](18, 0) NULL,
	[elementos_proporciones] [varchar](200) NULL,
	[sub_prop1] [decimal](18, 0) NULL,
	[sub_prop2] [decimal](18, 0) NULL,
	[sub_prop3] [decimal](18, 0) NULL,
	[prop1] [decimal](18, 0) NULL,
	[prop2] [decimal](18, 0) NULL,
	[prop3] [decimal](18, 0) NULL,
	[prop4] [decimal](18, 0) NULL,
	[prop5] [decimal](18, 0) NULL,
	[prop6] [decimal](18, 0) NULL,
	[prop7] [decimal](18, 0) NULL,
	[ID_nominal_compresor] [int] NULL,
	[ID_nominal_bomba] [int] NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Accesorio]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Accesorio](
	[ID_accesorio] [int] NOT NULL,
	[tipo] [varchar](50) NULL,
	[ID_tuberia] [int] NULL,
	[ID_sistema_compresion] [int] NULL,
	[ID_sistema_bombeo] [int] NULL,
 CONSTRAINT [PK_Accesorio] PRIMARY KEY CLUSTERED 
(
	[ID_accesorio] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Fluido]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Fluido](
	[ID_fluido] [int] NULL,
	[temperatura_ambiental] [decimal](18, 0) NULL,
	[presion_ambiental] [decimal](18, 0) NULL,
	[humedad_relativa] [decimal](18, 0) NULL,
	[ID_sistema_compresion] [int] NULL,
	[ID_sistema_bombeo] [int] NULL,
	[ID_tanque_reservorio] [int] NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Bomba]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Bomba](
	[ID_bomba] [int] NOT NULL,
	[tipo] [varchar](50) NULL,
	[rpm] [int] NULL,
	[consumo_potencia] [decimal](18, 0) NULL,
	[factor_seguridad] [decimal](18, 0) NULL,
	[relacion_compresion] [decimal](18, 0) NULL,
	[eficiencia_global] [decimal](18, 0) NULL,
	[eficiencia_hidraulica] [decimal](18, 0) NULL,
	[eficiencia_volumetrica] [decimal](18, 0) NULL,
	[eficiencia_mecanica] [decimal](18, 0) NULL,
	[temperatura_succion] [decimal](18, 0) NULL,
	[altura_succion] [decimal](18, 0) NULL,
	[presion_succion] [decimal](18, 0) NULL,
	[presion_descarga] [decimal](18, 0) NULL,
	[flujo_masico] [decimal](18, 0) NULL,
	[flujo_volumetrico] [decimal](18, 0) NULL,
	[NPSH_requerido] [decimal](18, 0) NULL,
	[NPSH_disponible] [decimal](18, 0) NULL,
	[ID_sistema_bombeo] [int] NULL,
 CONSTRAINT [PK_Bomba] PRIMARY KEY CLUSTERED 
(
	[ID_bomba] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Compresor]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Compresor](
	[ID_compresor] [int] NOT NULL,
	[tipo] [varchar](50) NULL,
	[rpm] [int] NULL,
	[consumo_potencia] [decimal](18, 0) NULL,
	[eficiencia_politropica] [decimal](18, 0) NULL,
	[relacion_compresion] [decimal](18, 0) NULL,
	[eficiencia_global] [decimal](18, 0) NULL,
	[eficiencia_hidraulica] [decimal](18, 0) NULL,
	[eficiencia_volumetrica] [decimal](18, 0) NULL,
	[eficiencia_mecanica] [decimal](18, 0) NULL,
	[temperatura_succion] [decimal](18, 0) NULL,
	[temperatura_descarga] [decimal](18, 0) NULL,
	[presion_succion] [decimal](18, 0) NULL,
	[presion_descarga] [decimal](18, 0) NULL,
	[flujo_masico] [decimal](18, 0) NULL,
	[flujo_volumetrico] [decimal](18, 0) NULL,
	[ID_sistema_compresion] [int] NULL,
 CONSTRAINT [PK_Compresor] PRIMARY KEY CLUSTERED 
(
	[ID_compresor] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Codo_Accesorio]') AND parent_object_id = OBJECT_ID(N'[dbo].[Codo]'))
ALTER TABLE [dbo].[Codo]  WITH CHECK ADD  CONSTRAINT [FK_Codo_Accesorio] FOREIGN KEY([ID_accesorio])
REFERENCES [dbo].[Accesorio] ([ID_accesorio])
GO
ALTER TABLE [dbo].[Codo] CHECK CONSTRAINT [FK_Codo_Accesorio]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Valvula_filtro_Accesorio]') AND parent_object_id = OBJECT_ID(N'[dbo].[Valvula_filtro]'))
ALTER TABLE [dbo].[Valvula_filtro]  WITH CHECK ADD  CONSTRAINT [FK_Valvula_filtro_Accesorio] FOREIGN KEY([ID_accesorio])
REFERENCES [dbo].[Accesorio] ([ID_accesorio])
GO
ALTER TABLE [dbo].[Valvula_filtro] CHECK CONSTRAINT [FK_Valvula_filtro_Accesorio]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Nominal_bomba_Bomba]') AND parent_object_id = OBJECT_ID(N'[dbo].[Nominal_bomba]'))
ALTER TABLE [dbo].[Nominal_bomba]  WITH CHECK ADD  CONSTRAINT [FK_Nominal_bomba_Bomba] FOREIGN KEY([ID_bomba])
REFERENCES [dbo].[Bomba] ([ID_bomba])
GO
ALTER TABLE [dbo].[Nominal_bomba] CHECK CONSTRAINT [FK_Nominal_bomba_Bomba]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Nominal_compresor_Compresor]') AND parent_object_id = OBJECT_ID(N'[dbo].[Nominal_compresor]'))
ALTER TABLE [dbo].[Nominal_compresor]  WITH CHECK ADD  CONSTRAINT [FK_Nominal_compresor_Compresor] FOREIGN KEY([ID_compresor])
REFERENCES [dbo].[Compresor] ([ID_compresor])
GO
ALTER TABLE [dbo].[Nominal_compresor] CHECK CONSTRAINT [FK_Nominal_compresor_Compresor]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Nominal_compresor_Nominal_compresor]') AND parent_object_id = OBJECT_ID(N'[dbo].[Nominal_compresor]'))
ALTER TABLE [dbo].[Nominal_compresor]  WITH CHECK ADD  CONSTRAINT [FK_Nominal_compresor_Nominal_compresor] FOREIGN KEY([ID_nominal_compresor])
REFERENCES [dbo].[Nominal_compresor] ([ID_nominal_compresor])
GO
ALTER TABLE [dbo].[Nominal_compresor] CHECK CONSTRAINT [FK_Nominal_compresor_Nominal_compresor]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Composicion_diseno_Nominal_bomba]') AND parent_object_id = OBJECT_ID(N'[dbo].[Composicion_diseno]'))
ALTER TABLE [dbo].[Composicion_diseno]  WITH CHECK ADD  CONSTRAINT [FK_Composicion_diseno_Nominal_bomba] FOREIGN KEY([ID_nominal_bomba])
REFERENCES [dbo].[Nominal_bomba] ([ID_nominal_bomba])
GO
ALTER TABLE [dbo].[Composicion_diseno] CHECK CONSTRAINT [FK_Composicion_diseno_Nominal_bomba]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Composicion_diseno_Nominal_Compresor]') AND parent_object_id = OBJECT_ID(N'[dbo].[Composicion_diseno]'))
ALTER TABLE [dbo].[Composicion_diseno]  WITH CHECK ADD  CONSTRAINT [FK_Composicion_diseno_Nominal_Compresor] FOREIGN KEY([ID_nominal_compresor])
REFERENCES [dbo].[Nominal_compresor] ([ID_nominal_compresor])
GO
ALTER TABLE [dbo].[Composicion_diseno] CHECK CONSTRAINT [FK_Composicion_diseno_Nominal_Compresor]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Accesorio_Sistema_Bombeo]') AND parent_object_id = OBJECT_ID(N'[dbo].[Accesorio]'))
ALTER TABLE [dbo].[Accesorio]  WITH CHECK ADD  CONSTRAINT [FK_Accesorio_Sistema_Bombeo] FOREIGN KEY([ID_sistema_bombeo])
REFERENCES [dbo].[Sistema_bombeo] ([ID_sistema_bombeo])
GO
ALTER TABLE [dbo].[Accesorio] CHECK CONSTRAINT [FK_Accesorio_Sistema_Bombeo]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Accesorio_Sistema_Compresion]') AND parent_object_id = OBJECT_ID(N'[dbo].[Accesorio]'))
ALTER TABLE [dbo].[Accesorio]  WITH CHECK ADD  CONSTRAINT [FK_Accesorio_Sistema_Compresion] FOREIGN KEY([ID_sistema_compresion])
REFERENCES [dbo].[Sistema_compresion] ([ID_sistema_compresion])
GO
ALTER TABLE [dbo].[Accesorio] CHECK CONSTRAINT [FK_Accesorio_Sistema_Compresion]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Accesorio_Tuberia]') AND parent_object_id = OBJECT_ID(N'[dbo].[Accesorio]'))
ALTER TABLE [dbo].[Accesorio]  WITH CHECK ADD  CONSTRAINT [FK_Accesorio_Tuberia] FOREIGN KEY([ID_tuberia])
REFERENCES [dbo].[Tuberia] ([ID_tuberia])
GO
ALTER TABLE [dbo].[Accesorio] CHECK CONSTRAINT [FK_Accesorio_Tuberia]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Fluido_Sistema_bombeo]') AND parent_object_id = OBJECT_ID(N'[dbo].[Fluido]'))
ALTER TABLE [dbo].[Fluido]  WITH CHECK ADD  CONSTRAINT [FK_Fluido_Sistema_bombeo] FOREIGN KEY([ID_sistema_bombeo])
REFERENCES [dbo].[Sistema_bombeo] ([ID_sistema_bombeo])
GO
ALTER TABLE [dbo].[Fluido] CHECK CONSTRAINT [FK_Fluido_Sistema_bombeo]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Fluido_Sistema_compresion]') AND parent_object_id = OBJECT_ID(N'[dbo].[Fluido]'))
ALTER TABLE [dbo].[Fluido]  WITH CHECK ADD  CONSTRAINT [FK_Fluido_Sistema_compresion] FOREIGN KEY([ID_sistema_compresion])
REFERENCES [dbo].[Sistema_compresion] ([ID_sistema_compresion])
GO
ALTER TABLE [dbo].[Fluido] CHECK CONSTRAINT [FK_Fluido_Sistema_compresion]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Fluido_Tanque_reservorio]') AND parent_object_id = OBJECT_ID(N'[dbo].[Fluido]'))
ALTER TABLE [dbo].[Fluido]  WITH CHECK ADD  CONSTRAINT [FK_Fluido_Tanque_reservorio] FOREIGN KEY([ID_tanque_reservorio])
REFERENCES [dbo].[Tanque_reservorio] ([ID_taque_reservorio])
GO
ALTER TABLE [dbo].[Fluido] CHECK CONSTRAINT [FK_Fluido_Tanque_reservorio]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Bomba_Sistema_bombeo]') AND parent_object_id = OBJECT_ID(N'[dbo].[Bomba]'))
ALTER TABLE [dbo].[Bomba]  WITH CHECK ADD  CONSTRAINT [FK_Bomba_Sistema_bombeo] FOREIGN KEY([ID_sistema_bombeo])
REFERENCES [dbo].[Sistema_bombeo] ([ID_sistema_bombeo])
GO
ALTER TABLE [dbo].[Bomba] CHECK CONSTRAINT [FK_Bomba_Sistema_bombeo]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Compresor_Sistema_compresion]') AND parent_object_id = OBJECT_ID(N'[dbo].[Compresor]'))
ALTER TABLE [dbo].[Compresor]  WITH CHECK ADD  CONSTRAINT [FK_Compresor_Sistema_compresion] FOREIGN KEY([ID_sistema_compresion])
REFERENCES [dbo].[Sistema_compresion] ([ID_sistema_compresion])
GO
ALTER TABLE [dbo].[Compresor] CHECK CONSTRAINT [FK_Compresor_Sistema_compresion]
