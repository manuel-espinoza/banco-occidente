USE [bancooccidentedb]
GO
SET IDENTITY_INSERT [dbo].[clientes] ON 
GO
INSERT [dbo].[clientes] ([id], [nombre], [documento], [email], [telefono], [fecha_creacion], [status]) VALUES (1, N'Juan Perez', N'1234567890', N'juan.perez@example.com', N'555-1234', CAST(N'2025-03-22T21:35:07.737' AS DateTime), 1)
GO
INSERT [dbo].[clientes] ([id], [nombre], [documento], [email], [telefono], [fecha_creacion], [status]) VALUES (2, N'Maria Gomez', N'0987654321', N'maria.gomez@example.com', N'555-5678', CAST(N'2025-03-22T21:35:07.737' AS DateTime), 1)
GO
INSERT [dbo].[clientes] ([id], [nombre], [documento], [email], [telefono], [fecha_creacion], [status]) VALUES (3, N'Carlos Ruiz', N'1122334455', N'carlos.ruiz@example.com', N'555-9101', CAST(N'2025-03-22T21:35:07.737' AS DateTime), 1)
GO
SET IDENTITY_INSERT [dbo].[clientes] OFF
GO
SET IDENTITY_INSERT [dbo].[tarjetas_credito] ON 
GO
INSERT [dbo].[tarjetas_credito] ([id], [cliente_id], [numero_tarjeta], [fecha_expiracion], [cvv], [limite_credito], [saldo_utilizado], [saldo_minimo_pct], [interes_bonificable_pct], [estado]) VALUES (1, 1, N'4111111111111111', CAST(N'2025-12-31' AS Date), N'123', CAST(10000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.0500 AS Decimal(18, 4)), CAST(0.2500 AS Decimal(18, 4)), N'activa')
GO
INSERT [dbo].[tarjetas_credito] ([id], [cliente_id], [numero_tarjeta], [fecha_expiracion], [cvv], [limite_credito], [saldo_utilizado], [saldo_minimo_pct], [interes_bonificable_pct], [estado]) VALUES (2, 2, N'4222222222222222', CAST(N'2025-11-30' AS Date), N'456', CAST(15000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.0500 AS Decimal(18, 4)), CAST(0.2500 AS Decimal(18, 4)), N'activa')
GO
INSERT [dbo].[tarjetas_credito] ([id], [cliente_id], [numero_tarjeta], [fecha_expiracion], [cvv], [limite_credito], [saldo_utilizado], [saldo_minimo_pct], [interes_bonificable_pct], [estado]) VALUES (3, 3, N'4333333333333333', CAST(N'2025-10-31' AS Date), N'789', CAST(20000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.0500 AS Decimal(18, 4)), CAST(0.2500 AS Decimal(18, 4)), N'activa')
GO
SET IDENTITY_INSERT [dbo].[tarjetas_credito] OFF
GO
SET IDENTITY_INSERT [dbo].[movimientos] ON 
GO
INSERT [dbo].[movimientos] ([id], [tarjeta_credito_id], [fecha], [descripcion], [monto], [tipo_movimiento]) VALUES (1, 1, CAST(N'2025-02-22T00:00:00.000' AS DateTime), N'Compra en supermercado', CAST(150.00 AS Decimal(18, 2)), N'cargo')
GO
INSERT [dbo].[movimientos] ([id], [tarjeta_credito_id], [fecha], [descripcion], [monto], [tipo_movimiento]) VALUES (2, 1, CAST(N'2025-02-22T00:00:00.000' AS DateTime), N'Pago de factura', CAST(200.00 AS Decimal(18, 2)), N'abono')
GO
INSERT [dbo].[movimientos] ([id], [tarjeta_credito_id], [fecha], [descripcion], [monto], [tipo_movimiento]) VALUES (3, 1, CAST(N'2025-03-22T00:00:00.000' AS DateTime), N'Compra en tienda de ropa', CAST(300.00 AS Decimal(18, 2)), N'cargo')
GO
INSERT [dbo].[movimientos] ([id], [tarjeta_credito_id], [fecha], [descripcion], [monto], [tipo_movimiento]) VALUES (4, 1, CAST(N'2025-03-22T00:00:00.000' AS DateTime), N'Pago de factura', CAST(100.00 AS Decimal(18, 2)), N'abono')
GO
INSERT [dbo].[movimientos] ([id], [tarjeta_credito_id], [fecha], [descripcion], [monto], [tipo_movimiento]) VALUES (5, 2, CAST(N'2025-02-22T00:00:00.000' AS DateTime), N'Compra en restaurante', CAST(250.00 AS Decimal(18, 2)), N'cargo')
GO
INSERT [dbo].[movimientos] ([id], [tarjeta_credito_id], [fecha], [descripcion], [monto], [tipo_movimiento]) VALUES (6, 2, CAST(N'2025-02-22T00:00:00.000' AS DateTime), N'Pago de factura', CAST(300.00 AS Decimal(18, 2)), N'abono')
GO
INSERT [dbo].[movimientos] ([id], [tarjeta_credito_id], [fecha], [descripcion], [monto], [tipo_movimiento]) VALUES (7, 2, CAST(N'2025-03-22T00:00:00.000' AS DateTime), N'Compra en gasolinera', CAST(100.00 AS Decimal(18, 2)), N'cargo')
GO
INSERT [dbo].[movimientos] ([id], [tarjeta_credito_id], [fecha], [descripcion], [monto], [tipo_movimiento]) VALUES (8, 2, CAST(N'2025-03-22T00:00:00.000' AS DateTime), N'Pago de factura', CAST(150.00 AS Decimal(18, 2)), N'abono')
GO
INSERT [dbo].[movimientos] ([id], [tarjeta_credito_id], [fecha], [descripcion], [monto], [tipo_movimiento]) VALUES (9, 3, CAST(N'2025-02-22T00:00:00.000' AS DateTime), N'Compra en tienda de electrónica', CAST(500.00 AS Decimal(18, 2)), N'cargo')
GO
INSERT [dbo].[movimientos] ([id], [tarjeta_credito_id], [fecha], [descripcion], [monto], [tipo_movimiento]) VALUES (10, 3, CAST(N'2025-02-22T00:00:00.000' AS DateTime), N'Pago de factura', CAST(400.00 AS Decimal(18, 2)), N'abono')
GO
INSERT [dbo].[movimientos] ([id], [tarjeta_credito_id], [fecha], [descripcion], [monto], [tipo_movimiento]) VALUES (11, 3, CAST(N'2025-03-22T00:00:00.000' AS DateTime), N'Compra en línea', CAST(200.00 AS Decimal(18, 2)), N'cargo')
GO
INSERT [dbo].[movimientos] ([id], [tarjeta_credito_id], [fecha], [descripcion], [monto], [tipo_movimiento]) VALUES (12, 3, CAST(N'2025-03-22T00:00:00.000' AS DateTime), N'Pago de factura', CAST(250.00 AS Decimal(18, 2)), N'abono')
GO
INSERT [dbo].[movimientos] ([id], [tarjeta_credito_id], [fecha], [descripcion], [monto], [tipo_movimiento]) VALUES (13, 1, CAST(N'2025-03-23T00:00:00.000' AS DateTime), N'Compra de lentes en CV +', CAST(250.00 AS Decimal(18, 2)), N'cargo')
GO
INSERT [dbo].[movimientos] ([id], [tarjeta_credito_id], [fecha], [descripcion], [monto], [tipo_movimiento]) VALUES (14, 1, CAST(N'2025-03-24T02:56:40.427' AS DateTime), N'Abono a tarjeta', CAST(100.00 AS Decimal(18, 2)), N'abono')
GO
INSERT [dbo].[movimientos] ([id], [tarjeta_credito_id], [fecha], [descripcion], [monto], [tipo_movimiento]) VALUES (15, 1, CAST(N'2025-03-24T02:57:34.893' AS DateTime), N'Compra de comida en restaurante', CAST(50.00 AS Decimal(18, 2)), N'cargo')
GO
SET IDENTITY_INSERT [dbo].[movimientos] OFF
GO
