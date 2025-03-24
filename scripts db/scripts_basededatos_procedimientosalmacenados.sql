USE [bancooccidentedb]
GO
/****** Object:  Table [dbo].[clientes]    Script Date: 23/3/2025 21:08:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[clientes](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](250) NOT NULL,
	[documento] [varchar](20) NOT NULL,
	[email] [varchar](100) NOT NULL,
	[telefono] [varchar](20) NULL,
	[fecha_creacion] [datetime] NULL,
	[status] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[documento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[estados_cuenta]    Script Date: 23/3/2025 21:08:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[estados_cuenta](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[tarjeta_credito_id] [int] NOT NULL,
	[fecha_corte] [date] NOT NULL,
	[saldo_anterior] [decimal](18, 2) NOT NULL,
	[total_cargos] [decimal](18, 2) NOT NULL,
	[total_abonos] [decimal](18, 2) NOT NULL,
	[saldo] [decimal](18, 2) NOT NULL,
	[cuota_minima] [decimal](18, 2) NOT NULL,
	[pago_contado] [decimal](18, 2) NOT NULL,
	[interes_bonificable] [decimal](18, 2) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[movimientos]    Script Date: 23/3/2025 21:08:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[movimientos](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[tarjeta_credito_id] [int] NOT NULL,
	[fecha] [datetime] NULL,
	[descripcion] [varchar](255) NOT NULL,
	[monto] [decimal](18, 2) NOT NULL,
	[tipo_movimiento] [varchar](10) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tarjetas_credito]    Script Date: 23/3/2025 21:08:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tarjetas_credito](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[cliente_id] [int] NOT NULL,
	[numero_tarjeta] [varchar](16) NOT NULL,
	[fecha_expiracion] [date] NOT NULL,
	[cvv] [varchar](4) NOT NULL,
	[limite_credito] [decimal](18, 2) NOT NULL,
	[saldo_utilizado] [decimal](18, 2) NULL,
	[saldo_minimo_pct] [decimal](18, 4) NULL,
	[interes_bonificable_pct] [decimal](18, 4) NULL,
	[estado] [varchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[numero_tarjeta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[clientes] ADD  DEFAULT (getdate()) FOR [fecha_creacion]
GO
ALTER TABLE [dbo].[clientes] ADD  DEFAULT ((1)) FOR [status]
GO
ALTER TABLE [dbo].[movimientos] ADD  DEFAULT (getdate()) FOR [fecha]
GO
ALTER TABLE [dbo].[tarjetas_credito] ADD  DEFAULT ((0)) FOR [saldo_utilizado]
GO
ALTER TABLE [dbo].[tarjetas_credito] ADD  DEFAULT ('activa') FOR [estado]
GO
ALTER TABLE [dbo].[estados_cuenta]  WITH CHECK ADD FOREIGN KEY([tarjeta_credito_id])
REFERENCES [dbo].[tarjetas_credito] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[movimientos]  WITH CHECK ADD FOREIGN KEY([tarjeta_credito_id])
REFERENCES [dbo].[tarjetas_credito] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tarjetas_credito]  WITH CHECK ADD FOREIGN KEY([cliente_id])
REFERENCES [dbo].[clientes] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[movimientos]  WITH CHECK ADD CHECK  (([tipo_movimiento]='abono' OR [tipo_movimiento]='cargo'))
GO
ALTER TABLE [dbo].[tarjetas_credito]  WITH CHECK ADD CHECK  (([Estado]='vencida' OR [Estado]='bloqueada' OR [Estado]='activa'))
GO
/****** Object:  StoredProcedure [dbo].[EstadoCuentaCabeceraCliente]    Script Date: 23/3/2025 21:08:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EstadoCuentaCabeceraCliente]
    @id_cliente INT
AS
BEGIN

    DECLARE @fecha_actual DATE = GETDATE();
    DECLARE @fecha_inicio_actual DATE = DATEFROMPARTS(YEAR(@fecha_actual), MONTH(@fecha_actual), 1);

    DECLARE @fecha_inicio_mes_anterior DATE = DATEFROMPARTS(YEAR(DATEADD(MONTH, -1, @fecha_actual)), MONTH(DATEADD(MONTH, -1, @fecha_actual)), 1);
    DECLARE @fecha_fin_mes_anterior DATE = EOMONTH(DATEADD(MONTH, -1, @fecha_actual));

    WITH total_movimientos AS (
        SELECT 
            m.tarjeta_credito_id,
            SUM(CASE 
                    WHEN m.tipo_movimiento = 'cargo' AND m.fecha >= @fecha_inicio_actual THEN m.monto 
                    ELSE 0 
                END) AS total_compras_mes_actual,
            SUM(CASE 
                    WHEN m.tipo_movimiento = 'cargo' AND m.fecha >= @fecha_inicio_mes_anterior AND m.fecha < @fecha_inicio_actual THEN m.monto 
                    ELSE 0 
                END) AS total_compras_mes_anterior,
            SUM(CASE 
                    WHEN m.tipo_movimiento = 'abono' AND m.fecha >= @fecha_inicio_actual THEN m.monto 
                    ELSE 0 
                END) AS total_abonos_mes_actual,
            SUM(CASE 
                    WHEN m.tipo_movimiento = 'abono' AND m.fecha >= @fecha_inicio_mes_anterior AND m.fecha < @fecha_inicio_actual THEN m.monto 
                    ELSE 0 
                END) AS total_abonos_mes_anterior
        FROM 
            movimientos m
        GROUP BY 
            m.tarjeta_credito_id
    )
    SELECT 
        c.nombre AS nombre_cliente,
        tc.numero_tarjeta AS numero_tarjeta_credito,
        tc.limite_credito AS limite_credito,
        ISNULL(mc.total_compras_mes_actual, 0) + ISNULL(mc.total_compras_mes_anterior, 0) AS total_compras,
        ISNULL(mc.total_abonos_mes_actual, 0) + ISNULL(mc.total_abonos_mes_anterior, 0) AS total_abonos,
        tc.saldo_minimo_pct AS porcentaje_saldo_minimo,
        tc.interes_bonificable_pct AS porcentaje_interes_bonificable
    FROM 
        clientes c
    INNER JOIN 
        tarjetas_credito tc ON c.id = tc.cliente_id
    LEFT JOIN 
        total_movimientos mc ON tc.id = mc.tarjeta_credito_id
    WHERE 
        c.id = @id_cliente;
END;
GO
/****** Object:  StoredProcedure [dbo].[EstadoCuentaComprasMesCliente]    Script Date: 23/3/2025 21:08:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EstadoCuentaComprasMesCliente]
    @mes int,
    @id_cliente INT
AS
BEGIN
    SELECT 
        m.fecha,
        m.descripcion,
        m.monto
    FROM 
        movimientos m
    INNER JOIN 
        tarjetas_credito tc ON m.tarjeta_credito_id = tc.id
    INNER JOIN 
        clientes c ON tc.cliente_id = c.id
    WHERE 
        m.tipo_movimiento = 'cargo'
        AND (MONTH(m.fecha) = @mes)
        AND (c.id = @id_cliente)

    ORDER BY
        m.fecha
END;
GO
