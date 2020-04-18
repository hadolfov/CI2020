USE [VETERINARIA]
GO
SET IDENTITY_INSERT [SCH_SEGURIDAD].[tbl_Modulos] ON 
GO
INSERT [SCH_SEGURIDAD].[tbl_Modulos] ([IdModulo], [Nombre], [IdEstado]) VALUES (1, N'Inventario', 1)
GO
INSERT [SCH_SEGURIDAD].[tbl_Modulos] ([IdModulo], [Nombre], [IdEstado]) VALUES (2, N'Nómina', 1)
GO
INSERT [SCH_SEGURIDAD].[tbl_Modulos] ([IdModulo], [Nombre], [IdEstado]) VALUES (3, N'Seguridad', 1)
GO
INSERT [SCH_SEGURIDAD].[tbl_Modulos] ([IdModulo], [Nombre], [IdEstado]) VALUES (4, N'Ventas', 1)
GO
SET IDENTITY_INSERT [SCH_SEGURIDAD].[tbl_Modulos] OFF
GO
SET IDENTITY_INSERT [SCH_SEGURIDAD].[tbl_SubModulos] ON 
GO
INSERT [SCH_SEGURIDAD].[tbl_SubModulos] ([IdSubModulo], [IdModulo], [Nombre], [IdEstado]) VALUES (1, 1, N'Productos', 1)
GO
INSERT [SCH_SEGURIDAD].[tbl_SubModulos] ([IdSubModulo], [IdModulo], [Nombre], [IdEstado]) VALUES (2, 1, N'Motivos Movimientos', 1)
GO
INSERT [SCH_SEGURIDAD].[tbl_SubModulos] ([IdSubModulo], [IdModulo], [Nombre], [IdEstado]) VALUES (3, 1, N'Proveedores', 1)
GO
INSERT [SCH_SEGURIDAD].[tbl_SubModulos] ([IdSubModulo], [IdModulo], [Nombre], [IdEstado]) VALUES (4, 1, N'Tipos de Movimientos', 1)
GO
INSERT [SCH_SEGURIDAD].[tbl_SubModulos] ([IdSubModulo], [IdModulo], [Nombre], [IdEstado]) VALUES (5, 1, N'Ingreso y Listado', 1)
GO
INSERT [SCH_SEGURIDAD].[tbl_SubModulos] ([IdSubModulo], [IdModulo], [Nombre], [IdEstado]) VALUES (6, 1, N'Descontinuar Productos', 1)
GO
INSERT [SCH_SEGURIDAD].[tbl_SubModulos] ([IdSubModulo], [IdModulo], [Nombre], [IdEstado]) VALUES (7, 1, N'Control de Inventario', 1)
GO
INSERT [SCH_SEGURIDAD].[tbl_SubModulos] ([IdSubModulo], [IdModulo], [Nombre], [IdEstado]) VALUES (8, 2, N'Planilla ', 1)
GO
INSERT [SCH_SEGURIDAD].[tbl_SubModulos] ([IdSubModulo], [IdModulo], [Nombre], [IdEstado]) VALUES (9, 2, N'Marcas', 1)
GO
INSERT [SCH_SEGURIDAD].[tbl_SubModulos] ([IdSubModulo], [IdModulo], [Nombre], [IdEstado]) VALUES (10, 2, N'Permisos', 1)
GO
INSERT [SCH_SEGURIDAD].[tbl_SubModulos] ([IdSubModulo], [IdModulo], [Nombre], [IdEstado]) VALUES (11, 2, N'Tipos de Marcas', 1)
GO
INSERT [SCH_SEGURIDAD].[tbl_SubModulos] ([IdSubModulo], [IdModulo], [Nombre], [IdEstado]) VALUES (12, 2, N'Tipos de Permisos', 1)
GO
INSERT [SCH_SEGURIDAD].[tbl_SubModulos] ([IdSubModulo], [IdModulo], [Nombre], [IdEstado]) VALUES (13, 2, N'Tipos de Identificación', 1)
GO
INSERT [SCH_SEGURIDAD].[tbl_SubModulos] ([IdSubModulo], [IdModulo], [Nombre], [IdEstado]) VALUES (14, 3, N'Tipos de Perfil', 1)
GO
INSERT [SCH_SEGURIDAD].[tbl_SubModulos] ([IdSubModulo], [IdModulo], [Nombre], [IdEstado]) VALUES (15, 3, N'Recuperación de Contraseña', 1)
GO
INSERT [SCH_SEGURIDAD].[tbl_SubModulos] ([IdSubModulo], [IdModulo], [Nombre], [IdEstado]) VALUES (16, 3, N'Permisos de Seguridad', 1)
GO
INSERT [SCH_SEGURIDAD].[tbl_SubModulos] ([IdSubModulo], [IdModulo], [Nombre], [IdEstado]) VALUES (17, 3, N'Usuarios de Seguridad', 1)
GO
INSERT [SCH_SEGURIDAD].[tbl_SubModulos] ([IdSubModulo], [IdModulo], [Nombre], [IdEstado]) VALUES (18, 4, N'Empresa', 1)
GO
INSERT [SCH_SEGURIDAD].[tbl_SubModulos] ([IdSubModulo], [IdModulo], [Nombre], [IdEstado]) VALUES (19, 4, N'Sucursales y Cajas', 1)
GO
INSERT [SCH_SEGURIDAD].[tbl_SubModulos] ([IdSubModulo], [IdModulo], [Nombre], [IdEstado]) VALUES (20, 4, N'Especialidades', 1)
GO
INSERT [SCH_SEGURIDAD].[tbl_SubModulos] ([IdSubModulo], [IdModulo], [Nombre], [IdEstado]) VALUES (21, 4, N'Citas', 1)
GO
INSERT [SCH_SEGURIDAD].[tbl_SubModulos] ([IdSubModulo], [IdModulo], [Nombre], [IdEstado]) VALUES (22, 4, N'Ventas', 1)
GO
INSERT [SCH_SEGURIDAD].[tbl_SubModulos] ([IdSubModulo], [IdModulo], [Nombre], [IdEstado]) VALUES (23, 4, N'Clientes y Mascotas', 1)
GO
INSERT [SCH_SEGURIDAD].[tbl_SubModulos] ([IdSubModulo], [IdModulo], [Nombre], [IdEstado]) VALUES (24, 4, N'Especie y Razas', 1)
GO
SET IDENTITY_INSERT [SCH_SEGURIDAD].[tbl_SubModulos] OFF
GO
SET IDENTITY_INSERT [SCH_SEGURIDAD].[tbl_PermisosSeguridad] ON 
GO
INSERT [SCH_SEGURIDAD].[tbl_PermisosSeguridad] ([IdPermisoSeguridad], [IdTipoPerfil], [IdSubModulo], [Insertar], [Modificar], [Eliminar], [IdEstado]) VALUES (1, 1, 1, 1, 1, 1, 1)
GO
INSERT [SCH_SEGURIDAD].[tbl_PermisosSeguridad] ([IdPermisoSeguridad], [IdTipoPerfil], [IdSubModulo], [Insertar], [Modificar], [Eliminar], [IdEstado]) VALUES (2, 1, 2, 1, 1, 1, 1)
GO
INSERT [SCH_SEGURIDAD].[tbl_PermisosSeguridad] ([IdPermisoSeguridad], [IdTipoPerfil], [IdSubModulo], [Insertar], [Modificar], [Eliminar], [IdEstado]) VALUES (3, 1, 3, 1, 1, 1, 1)
GO
INSERT [SCH_SEGURIDAD].[tbl_PermisosSeguridad] ([IdPermisoSeguridad], [IdTipoPerfil], [IdSubModulo], [Insertar], [Modificar], [Eliminar], [IdEstado]) VALUES (4, 1, 4, 1, 1, 1, 1)
GO
INSERT [SCH_SEGURIDAD].[tbl_PermisosSeguridad] ([IdPermisoSeguridad], [IdTipoPerfil], [IdSubModulo], [Insertar], [Modificar], [Eliminar], [IdEstado]) VALUES (5, 1, 5, 1, 1, 1, 1)
GO
INSERT [SCH_SEGURIDAD].[tbl_PermisosSeguridad] ([IdPermisoSeguridad], [IdTipoPerfil], [IdSubModulo], [Insertar], [Modificar], [Eliminar], [IdEstado]) VALUES (6, 1, 6, 1, 1, 1, 1)
GO
INSERT [SCH_SEGURIDAD].[tbl_PermisosSeguridad] ([IdPermisoSeguridad], [IdTipoPerfil], [IdSubModulo], [Insertar], [Modificar], [Eliminar], [IdEstado]) VALUES (7, 1, 7, 1, 1, 1, 1)
GO
INSERT [SCH_SEGURIDAD].[tbl_PermisosSeguridad] ([IdPermisoSeguridad], [IdTipoPerfil], [IdSubModulo], [Insertar], [Modificar], [Eliminar], [IdEstado]) VALUES (8, 1, 8, 1, 1, 1, 1)
GO
INSERT [SCH_SEGURIDAD].[tbl_PermisosSeguridad] ([IdPermisoSeguridad], [IdTipoPerfil], [IdSubModulo], [Insertar], [Modificar], [Eliminar], [IdEstado]) VALUES (9, 1, 9, 1, 1, 1, 1)
GO
INSERT [SCH_SEGURIDAD].[tbl_PermisosSeguridad] ([IdPermisoSeguridad], [IdTipoPerfil], [IdSubModulo], [Insertar], [Modificar], [Eliminar], [IdEstado]) VALUES (10, 1, 10, 1, 1, 1, 1)
GO
INSERT [SCH_SEGURIDAD].[tbl_PermisosSeguridad] ([IdPermisoSeguridad], [IdTipoPerfil], [IdSubModulo], [Insertar], [Modificar], [Eliminar], [IdEstado]) VALUES (11, 1, 11, 1, 1, 1, 1)
GO
INSERT [SCH_SEGURIDAD].[tbl_PermisosSeguridad] ([IdPermisoSeguridad], [IdTipoPerfil], [IdSubModulo], [Insertar], [Modificar], [Eliminar], [IdEstado]) VALUES (12, 1, 12, 1, 1, 1, 1)
GO
INSERT [SCH_SEGURIDAD].[tbl_PermisosSeguridad] ([IdPermisoSeguridad], [IdTipoPerfil], [IdSubModulo], [Insertar], [Modificar], [Eliminar], [IdEstado]) VALUES (13, 1, 13, 1, 1, 1, 1)
GO
INSERT [SCH_SEGURIDAD].[tbl_PermisosSeguridad] ([IdPermisoSeguridad], [IdTipoPerfil], [IdSubModulo], [Insertar], [Modificar], [Eliminar], [IdEstado]) VALUES (14, 1, 14, 1, 1, 1, 1)
GO
INSERT [SCH_SEGURIDAD].[tbl_PermisosSeguridad] ([IdPermisoSeguridad], [IdTipoPerfil], [IdSubModulo], [Insertar], [Modificar], [Eliminar], [IdEstado]) VALUES (15, 1, 15, 1, 1, 1, 1)
GO
INSERT [SCH_SEGURIDAD].[tbl_PermisosSeguridad] ([IdPermisoSeguridad], [IdTipoPerfil], [IdSubModulo], [Insertar], [Modificar], [Eliminar], [IdEstado]) VALUES (16, 1, 16, 1, 1, 1, 1)
GO
INSERT [SCH_SEGURIDAD].[tbl_PermisosSeguridad] ([IdPermisoSeguridad], [IdTipoPerfil], [IdSubModulo], [Insertar], [Modificar], [Eliminar], [IdEstado]) VALUES (17, 1, 17, 1, 1, 1, 1)
GO
INSERT [SCH_SEGURIDAD].[tbl_PermisosSeguridad] ([IdPermisoSeguridad], [IdTipoPerfil], [IdSubModulo], [Insertar], [Modificar], [Eliminar], [IdEstado]) VALUES (18, 1, 18, 1, 1, 1, 1)
GO
INSERT [SCH_SEGURIDAD].[tbl_PermisosSeguridad] ([IdPermisoSeguridad], [IdTipoPerfil], [IdSubModulo], [Insertar], [Modificar], [Eliminar], [IdEstado]) VALUES (19, 1, 19, 1, 1, 1, 1)
GO
INSERT [SCH_SEGURIDAD].[tbl_PermisosSeguridad] ([IdPermisoSeguridad], [IdTipoPerfil], [IdSubModulo], [Insertar], [Modificar], [Eliminar], [IdEstado]) VALUES (20, 1, 20, 1, 1, 1, 1)
GO
INSERT [SCH_SEGURIDAD].[tbl_PermisosSeguridad] ([IdPermisoSeguridad], [IdTipoPerfil], [IdSubModulo], [Insertar], [Modificar], [Eliminar], [IdEstado]) VALUES (21, 1, 21, 1, 1, 1, 1)
GO
INSERT [SCH_SEGURIDAD].[tbl_PermisosSeguridad] ([IdPermisoSeguridad], [IdTipoPerfil], [IdSubModulo], [Insertar], [Modificar], [Eliminar], [IdEstado]) VALUES (22, 1, 22, 1, 1, 1, 1)
GO
INSERT [SCH_SEGURIDAD].[tbl_PermisosSeguridad] ([IdPermisoSeguridad], [IdTipoPerfil], [IdSubModulo], [Insertar], [Modificar], [Eliminar], [IdEstado]) VALUES (23, 1, 23, 1, 1, 1, 1)
GO
INSERT [SCH_SEGURIDAD].[tbl_PermisosSeguridad] ([IdPermisoSeguridad], [IdTipoPerfil], [IdSubModulo], [Insertar], [Modificar], [Eliminar], [IdEstado]) VALUES (24, 1, 24, 1, 1, 1, 1)
GO
SET IDENTITY_INSERT [SCH_SEGURIDAD].[tbl_PermisosSeguridad] OFF
GO
