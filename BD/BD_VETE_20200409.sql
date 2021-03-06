USE [master]
GO
/****** Object:  Database [VETERINARIA]    Script Date: 09/04/2020 3:55:57 ******/

---SCRIP GENERADO POR GEINER MORA MORA---

CREATE DATABASE [VETERINARIA]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'VETERINARIA', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\VETERINARIA.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'VETERINARIA_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\VETERINARIA_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [VETERINARIA] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [VETERINARIA].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [VETERINARIA] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [VETERINARIA] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [VETERINARIA] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [VETERINARIA] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [VETERINARIA] SET ARITHABORT OFF 
GO
ALTER DATABASE [VETERINARIA] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [VETERINARIA] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [VETERINARIA] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [VETERINARIA] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [VETERINARIA] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [VETERINARIA] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [VETERINARIA] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [VETERINARIA] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [VETERINARIA] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [VETERINARIA] SET  DISABLE_BROKER 
GO
ALTER DATABASE [VETERINARIA] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [VETERINARIA] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [VETERINARIA] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [VETERINARIA] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [VETERINARIA] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [VETERINARIA] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [VETERINARIA] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [VETERINARIA] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [VETERINARIA] SET  MULTI_USER 
GO
ALTER DATABASE [VETERINARIA] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [VETERINARIA] SET DB_CHAINING OFF 
GO
ALTER DATABASE [VETERINARIA] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [VETERINARIA] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [VETERINARIA] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [VETERINARIA] SET QUERY_STORE = OFF
GO
USE [VETERINARIA]
GO
/****** Object:  Schema [SCH_INVENTARIO]    Script Date: 09/04/2020 3:55:57 ******/
CREATE SCHEMA [SCH_INVENTARIO]
GO
/****** Object:  Schema [SCH_MANTENIMIENTO]    Script Date: 09/04/2020 3:55:57 ******/
CREATE SCHEMA [SCH_MANTENIMIENTO]
GO
/****** Object:  Schema [SCH_NOMINA]    Script Date: 09/04/2020 3:55:57 ******/
CREATE SCHEMA [SCH_NOMINA]
GO
/****** Object:  Schema [SCH_SEGURIDAD]    Script Date: 09/04/2020 3:55:57 ******/
CREATE SCHEMA [SCH_SEGURIDAD]
GO
/****** Object:  Schema [SCH_VENTAS]    Script Date: 09/04/2020 3:55:57 ******/
CREATE SCHEMA [SCH_VENTAS]
GO
/****** Object:  Table [SCH_INVENTARIO].[tbl_Articulos]    Script Date: 09/04/2020 3:55:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [SCH_INVENTARIO].[tbl_Articulos](
	[IdArticulo] [int] IDENTITY(1,1) NOT NULL,
	[NombreArticulo] [nvarchar](100) NULL,
	[Descripcion] [nvarchar](100) NULL,
	[Servicio] [bit] NULL,
	[CantidadStock] [int] NULL,
	[CantidadMax] [int] NULL,
	[CantidadMin] [int] NULL,
	[IdEstado] [int] NULL,
	[Precio] [decimal](18, 0) NULL,
 CONSTRAINT [PK_IdArticulo] PRIMARY KEY CLUSTERED 
(
	[IdArticulo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [SCH_INVENTARIO].[tbl_Motivo]    Script Date: 09/04/2020 3:55:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [SCH_INVENTARIO].[tbl_Motivo](
	[IdMotivo] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](200) NULL,
	[IdEstado] [int] NULL,
 CONSTRAINT [PK_IdMotivo] PRIMARY KEY CLUSTERED 
(
	[IdMotivo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [SCH_INVENTARIO].[tbl_MovimientoDetalle]    Script Date: 09/04/2020 3:55:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [SCH_INVENTARIO].[tbl_MovimientoDetalle](
	[IDDetalle] [int] IDENTITY(1,1) NOT NULL,
	[IDMovimiento] [int] NULL,
	[IDArticulo] [int] NULL,
	[IDPedido] [int] NULL,
	[Cantidad] [int] NULL,
	[MontoTotal] [decimal](18, 0) NULL,
	[PorcentajeImpuesto] [decimal](18, 0) NULL,
	[PorcentajeDescuento] [decimal](18, 0) NULL,
	[CantidadBackorder] [int] NULL,
	[IdEstado] [int] NULL,
 CONSTRAINT [PK_IDDetalle] PRIMARY KEY CLUSTERED 
(
	[IDDetalle] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [SCH_INVENTARIO].[tbl_MovimientoInventario]    Script Date: 09/04/2020 3:55:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [SCH_INVENTARIO].[tbl_MovimientoInventario](
	[IDMovimiento] [int] IDENTITY(1,1) NOT NULL,
	[IDProveedor] [int] NULL,
	[IDCliente] [int] NULL,
	[IDSucursalEntrada] [int] NULL,
	[IDSucursalSalida] [int] NULL,
	[IDUsuarioAutorizaEntrada] [int] NULL,
	[IDUsuarioAutorizaSalida] [int] NULL,
	[IDTipo] [int] NULL,
	[IDMotivo] [int] NULL,
	[IDCaja] [int] NULL,
	[IdEstado] [int] NULL,
 CONSTRAINT [PK_IDMovimiento] PRIMARY KEY CLUSTERED 
(
	[IDMovimiento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [SCH_INVENTARIO].[tbl_proveedor]    Script Date: 09/04/2020 3:55:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [SCH_INVENTARIO].[tbl_proveedor](
	[IdProveedor] [int] IDENTITY(1,1) NOT NULL,
	[Identificacion] [nvarchar](100) NULL,
	[IdTipoIdentificacion] [int] NULL,
	[Nombre] [nvarchar](50) NULL,
	[Apellido] [nvarchar](50) NULL,
	[Apellido2] [nvarchar](50) NULL,
	[RazonSocial] [nvarchar](100) NULL,
	[Email] [nvarchar](50) NULL,
	[Telefono1] [int] NULL,
	[Telefono2] [int] NULL,
	[IdEstado] [int] NULL,
 CONSTRAINT [PK_Idproveedor] PRIMARY KEY CLUSTERED 
(
	[IdProveedor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [SCH_INVENTARIO].[tbl_TipoMovimiento]    Script Date: 09/04/2020 3:55:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [SCH_INVENTARIO].[tbl_TipoMovimiento](
	[IdTipo] [int] IDENTITY(1,1) NOT NULL,
	[NombreTipo] [nvarchar](100) NULL,
	[IdEstado] [int] NULL,
 CONSTRAINT [PK_IdTipo] PRIMARY KEY CLUSTERED 
(
	[IdTipo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [SCH_MANTENIMIENTO].[tbl_Cajas]    Script Date: 09/04/2020 3:55:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [SCH_MANTENIMIENTO].[tbl_Cajas](
	[IdCaja] [int] IDENTITY(1,1) NOT NULL,
	[desCaja] [nvarchar](100) NULL,
	[IdSucursal] [int] NULL,
	[IdEstado] [int] NULL,
 CONSTRAINT [PK_IdCaja] PRIMARY KEY CLUSTERED 
(
	[IdCaja] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [SCH_MANTENIMIENTO].[tbl_DiaSemana]    Script Date: 09/04/2020 3:55:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [SCH_MANTENIMIENTO].[tbl_DiaSemana](
	[IdDia] [int] IDENTITY(1,1) NOT NULL,
	[Dia] [nvarchar](10) NULL,
 CONSTRAINT [PK_IdDia] PRIMARY KEY CLUSTERED 
(
	[IdDia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [SCH_MANTENIMIENTO].[tbl_Empresa]    Script Date: 09/04/2020 3:55:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [SCH_MANTENIMIENTO].[tbl_Empresa](
	[IdEmpresa] [int] IDENTITY(1,1) NOT NULL,
	[desEmpresa] [nvarchar](100) NULL,
	[CedulaJuridica] [nvarchar](100) NULL,
	[IdTipoIdentificacion] [int] NULL,
	[IdEstado] [int] NULL,
 CONSTRAINT [PK_IdEmpresa] PRIMARY KEY CLUSTERED 
(
	[IdEmpresa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [SCH_MANTENIMIENTO].[tbl_Especialidad]    Script Date: 09/04/2020 3:55:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [SCH_MANTENIMIENTO].[tbl_Especialidad](
	[IdEspecialidad] [int] IDENTITY(1,1) NOT NULL,
	[desEspecialidad] [nvarchar](100) NULL,
	[AgendaCita] [bit] NULL,
	[IdEstado] [int] NULL,
 CONSTRAINT [PK_IdEspecialidad] PRIMARY KEY CLUSTERED 
(
	[IdEspecialidad] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [SCH_MANTENIMIENTO].[tbl_EspecialidadUsuario]    Script Date: 09/04/2020 3:55:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [SCH_MANTENIMIENTO].[tbl_EspecialidadUsuario](
	[IdEspecialidadUsuario] [int] IDENTITY(1,1) NOT NULL,
	[desEspecialidadUsuario] [nvarchar](100) NULL,
	[IdEspecialidad] [int] NULL,
	[IdSucursal] [int] NULL,
	[IdEstado] [int] NULL,
 CONSTRAINT [PK_IdEspecialidadUsuario] PRIMARY KEY CLUSTERED 
(
	[IdEspecialidadUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [SCH_MANTENIMIENTO].[tbl_Estado]    Script Date: 09/04/2020 3:55:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [SCH_MANTENIMIENTO].[tbl_Estado](
	[IdEstado] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [nvarchar](10) NULL,
 CONSTRAINT [PK_IdEstado] PRIMARY KEY CLUSTERED 
(
	[IdEstado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [SCH_MANTENIMIENTO].[tbl_Sucursales]    Script Date: 09/04/2020 3:55:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [SCH_MANTENIMIENTO].[tbl_Sucursales](
	[IdSucursal] [int] IDENTITY(1,1) NOT NULL,
	[desSucursal] [nvarchar](100) NULL,
	[IdEmpresa] [int] NULL,
	[IdEstado] [int] NULL,
	[NombreSucursal] [nvarchar](100) NULL,
 CONSTRAINT [PK_IdSucursal] PRIMARY KEY CLUSTERED 
(
	[IdSucursal] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [SCH_MANTENIMIENTO].[tbl_TipoIdentificacion]    Script Date: 09/04/2020 3:55:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [SCH_MANTENIMIENTO].[tbl_TipoIdentificacion](
	[IdTipoIdentificacion] [int] IDENTITY(1,1) NOT NULL,
	[TipoIdentificación] [nvarchar](50) NULL,
	[CodigoTipoIdentificacion] [nvarchar](5) NULL,
	[IdEstado] [int] NULL,
 CONSTRAINT [PK_IdTipoIdentificacion] PRIMARY KEY CLUSTERED 
(
	[IdTipoIdentificacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [SCH_NOMINA].[tbl_DiasLibres]    Script Date: 09/04/2020 3:55:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [SCH_NOMINA].[tbl_DiasLibres](
	[IdDiaLibre] [int] NOT NULL,
	[IdHorario] [int] NULL,
	[IdDia] [int] NULL,
	[IdEstado] [int] NULL,
 CONSTRAINT [PK_tbl_DiasLibres] PRIMARY KEY CLUSTERED 
(
	[IdDiaLibre] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [SCH_NOMINA].[tbl_Horarios]    Script Date: 09/04/2020 3:55:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [SCH_NOMINA].[tbl_Horarios](
	[IdHorario] [int] NOT NULL,
	[IdUsuario] [int] NOT NULL,
	[HoraEntrada] [time](7) NOT NULL,
	[HoraSalida] [time](7) NOT NULL,
	[IdEstado] [int] NOT NULL,
 CONSTRAINT [PK_tbl_Horarios] PRIMARY KEY CLUSTERED 
(
	[IdHorario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [SCH_NOMINA].[tbl_Marcas]    Script Date: 09/04/2020 3:55:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [SCH_NOMINA].[tbl_Marcas](
	[IdMarca] [int] NOT NULL,
	[IdUsuario] [int] NOT NULL,
	[Registro] [datetime] NOT NULL,
	[IdTipoMarca] [int] NOT NULL,
	[IdEstado] [int] NULL,
 CONSTRAINT [PK_tbl_Marcas] PRIMARY KEY CLUSTERED 
(
	[IdMarca] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [SCH_NOMINA].[tbl_Permisos]    Script Date: 09/04/2020 3:55:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [SCH_NOMINA].[tbl_Permisos](
	[IdPermiso] [int] NOT NULL,
	[IdUsuario] [int] NOT NULL,
	[IdTipoPermiso] [int] NOT NULL,
	[Inicio] [datetime] NOT NULL,
	[Fin] [datetime] NOT NULL,
	[Observacion] [nvarchar](500) NULL,
	[IdEstado] [int] NULL,
 CONSTRAINT [PK_tbl_Permisos] PRIMARY KEY CLUSTERED 
(
	[IdPermiso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [SCH_NOMINA].[tbl_TiposMarca]    Script Date: 09/04/2020 3:55:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [SCH_NOMINA].[tbl_TiposMarca](
	[IdTipoMarca] [int] NOT NULL,
	[TipoMarca] [nvarchar](50) NULL,
	[Estado] [int] NULL,
 CONSTRAINT [PK_tbl_TiposMarca] PRIMARY KEY CLUSTERED 
(
	[IdTipoMarca] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [SCH_NOMINA].[tbl_TiposPermiso]    Script Date: 09/04/2020 3:55:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [SCH_NOMINA].[tbl_TiposPermiso](
	[IdTipoPermiso] [int] NOT NULL,
	[TipoPermiso] [nvarchar](50) NOT NULL,
	[IdEstado] [int] NOT NULL,
 CONSTRAINT [PK_tbl_TiposPermiso] PRIMARY KEY CLUSTERED 
(
	[IdTipoPermiso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [SCH_NOMINA].[tbl_Usuarios]    Script Date: 09/04/2020 3:55:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [SCH_NOMINA].[tbl_Usuarios](
	[Id_Usuario] [int] NOT NULL,
	[Identificacion] [nvarchar](50) NULL,
	[Nombre] [nvarchar](50) NULL,
	[PrimerApellido] [nvarchar](50) NULL,
	[SegundoApellido] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[Telefono1] [nvarchar](20) NULL,
	[Telefono2] [nvarchar](20) NULL,
	[IdSucursal] [int] NULL,
	[IdEstado] [int] NULL,
 CONSTRAINT [PK_SCH_NOMINA]].[tbl_Usuarios] PRIMARY KEY CLUSTERED 
(
	[Id_Usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [SCH_SEGURIDAD].[tbl_Modulos]    Script Date: 09/04/2020 3:55:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [SCH_SEGURIDAD].[tbl_Modulos](
	[IdModulo] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](50) NULL,
	[IdEstado] [int] NULL,
 CONSTRAINT [PK_IdModulo] PRIMARY KEY CLUSTERED 
(
	[IdModulo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [SCH_SEGURIDAD].[tbl_PermisosSeguridad]    Script Date: 09/04/2020 3:55:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [SCH_SEGURIDAD].[tbl_PermisosSeguridad](
	[IdPermisoSeguridad] [int] IDENTITY(1,1) NOT NULL,
	[IdTipoPerfil] [int] NOT NULL,
	[IdSubModulo] [int] NULL,
	[Insertar] [bit] NULL,
	[Modificar] [bit] NULL,
	[Eliminar] [bit] NULL,
	[IdEstado] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdPermisoSeguridad] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [SCH_SEGURIDAD].[tbl_SubModulos]    Script Date: 09/04/2020 3:55:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [SCH_SEGURIDAD].[tbl_SubModulos](
	[IdSubModulo] [int] IDENTITY(1,1) NOT NULL,
	[IdTipoPerfil] [int] NULL,
	[IdModulos] [int] NULL,
	[Nombre] [nvarchar](50) NULL,
	[IdEstado] [int] NULL,
 CONSTRAINT [PK_IdSubModulo] PRIMARY KEY CLUSTERED 
(
	[IdSubModulo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [SCH_SEGURIDAD].[tbl_TiposPerfil]    Script Date: 09/04/2020 3:55:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [SCH_SEGURIDAD].[tbl_TiposPerfil](
	[IdTipoPerfil] [int] IDENTITY(1,1) NOT NULL,
	[TipoPerfil] [nvarchar](50) NULL,
	[IdSucursal] [int] NULL,
	[IdEspecialidad] [int] NULL,
	[IdEstado] [int] NULL,
 CONSTRAINT [PK_IdTipoPerfil] PRIMARY KEY CLUSTERED 
(
	[IdTipoPerfil] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [SCH_SEGURIDAD].[tbl_UsuariosSeguridad]    Script Date: 09/04/2020 3:55:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [SCH_SEGURIDAD].[tbl_UsuariosSeguridad](
	[IdUsuarioSeguridad] [int] IDENTITY(1,1) NOT NULL,
	[NombreUsuario] [nvarchar](20) NULL,
	[Contrasenna] [nvarchar](20) NULL,
	[IdEstado] [int] NULL,
	[IdTipoPerfil] [int] NULL,
 CONSTRAINT [PK_IdUsuarioSeguridad] PRIMARY KEY CLUSTERED 
(
	[IdUsuarioSeguridad] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [SCH_VENTAS].[tbl_Citas]    Script Date: 09/04/2020 3:55:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [SCH_VENTAS].[tbl_Citas](
	[IdCita] [int] IDENTITY(1,1) NOT NULL,
	[IdMascota] [int] NULL,
	[desEspecie] [nvarchar](500) NULL,
	[FechaCita] [datetime] NULL,
	[Ingreso] [datetime] NULL,
	[Salida] [datetime] NULL,
	[IdEstado] [int] NULL,
	[Peso] [float] NULL,
	[Altura] [float] NULL,
	[Largo] [float] NULL,
 CONSTRAINT [PK_IdCita] PRIMARY KEY CLUSTERED 
(
	[IdCita] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [SCH_VENTAS].[tbl_Clientes]    Script Date: 09/04/2020 3:55:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [SCH_VENTAS].[tbl_Clientes](
	[IdCliente] [int] IDENTITY(1,1) NOT NULL,
	[Identificacion] [nvarchar](50) NULL,
	[IdTipoIdentificacion] [int] NULL,
	[Nombre] [nvarchar](50) NULL,
	[PrimerApellido] [nvarchar](50) NULL,
	[SegundoApellido] [nvarchar](50) NULL,
	[email] [nvarchar](100) NULL,
	[Telefono1] [nvarchar](50) NULL,
	[Telefono2] [nvarchar](50) NULL,
	[IdEstado] [int] NULL,
 CONSTRAINT [PK_IdCliente] PRIMARY KEY CLUSTERED 
(
	[IdCliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [SCH_VENTAS].[tbl_Especie]    Script Date: 09/04/2020 3:55:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [SCH_VENTAS].[tbl_Especie](
	[IdEspecie] [int] IDENTITY(1,1) NOT NULL,
	[desEspecie] [nvarchar](500) NULL,
	[IdEstado] [int] NULL,
 CONSTRAINT [PK_IdEspecie] PRIMARY KEY CLUSTERED 
(
	[IdEspecie] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [SCH_VENTAS].[tbl_Mascotas]    Script Date: 09/04/2020 3:55:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [SCH_VENTAS].[tbl_Mascotas](
	[IdMascota] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](50) NULL,
	[Observacion] [nvarchar](500) NULL,
	[IdRaza] [int] NULL,
	[IdCliente] [int] NULL,
	[IdEstado] [int] NULL,
 CONSTRAINT [PK_IdMascota] PRIMARY KEY CLUSTERED 
(
	[IdMascota] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [SCH_VENTAS].[tbl_Razas]    Script Date: 09/04/2020 3:55:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [SCH_VENTAS].[tbl_Razas](
	[IdRaza] [int] IDENTITY(1,1) NOT NULL,
	[desRaza] [nvarchar](500) NULL,
	[IdEspecie] [int] NULL,
	[IdEstado] [int] NULL,
 CONSTRAINT [PK_IdRaza] PRIMARY KEY CLUSTERED 
(
	[IdRaza] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [SCH_INVENTARIO].[tbl_Articulos] ADD  DEFAULT ((0)) FOR [Servicio]
GO
ALTER TABLE [SCH_INVENTARIO].[tbl_Articulos]  WITH NOCHECK ADD  CONSTRAINT [FK_IDEstado_Estado_Articulos] FOREIGN KEY([IdEstado])
REFERENCES [SCH_MANTENIMIENTO].[tbl_Estado] ([IdEstado])
GO
ALTER TABLE [SCH_INVENTARIO].[tbl_Articulos] CHECK CONSTRAINT [FK_IDEstado_Estado_Articulos]
GO
ALTER TABLE [SCH_INVENTARIO].[tbl_Motivo]  WITH NOCHECK ADD  CONSTRAINT [FK_IDEstado_Estado_Motivo] FOREIGN KEY([IdEstado])
REFERENCES [SCH_MANTENIMIENTO].[tbl_Estado] ([IdEstado])
GO
ALTER TABLE [SCH_INVENTARIO].[tbl_Motivo] CHECK CONSTRAINT [FK_IDEstado_Estado_Motivo]
GO
ALTER TABLE [SCH_INVENTARIO].[tbl_MovimientoDetalle]  WITH NOCHECK ADD  CONSTRAINT [FK_IdArticulo_Articulos_MovimientoDetalle] FOREIGN KEY([IDArticulo])
REFERENCES [SCH_INVENTARIO].[tbl_Articulos] ([IdArticulo])
GO
ALTER TABLE [SCH_INVENTARIO].[tbl_MovimientoDetalle] CHECK CONSTRAINT [FK_IdArticulo_Articulos_MovimientoDetalle]
GO
ALTER TABLE [SCH_INVENTARIO].[tbl_MovimientoDetalle]  WITH NOCHECK ADD  CONSTRAINT [FK_IDEstado_Estado_MovimientoDetalle] FOREIGN KEY([IdEstado])
REFERENCES [SCH_MANTENIMIENTO].[tbl_Estado] ([IdEstado])
GO
ALTER TABLE [SCH_INVENTARIO].[tbl_MovimientoDetalle] CHECK CONSTRAINT [FK_IDEstado_Estado_MovimientoDetalle]
GO
ALTER TABLE [SCH_INVENTARIO].[tbl_MovimientoDetalle]  WITH NOCHECK ADD  CONSTRAINT [FK_IDMovimiento_MovimientoInventario_MovimientoDetalle] FOREIGN KEY([IDMovimiento])
REFERENCES [SCH_INVENTARIO].[tbl_MovimientoInventario] ([IDMovimiento])
GO
ALTER TABLE [SCH_INVENTARIO].[tbl_MovimientoDetalle] CHECK CONSTRAINT [FK_IDMovimiento_MovimientoInventario_MovimientoDetalle]
GO
ALTER TABLE [SCH_INVENTARIO].[tbl_MovimientoInventario]  WITH NOCHECK ADD  CONSTRAINT [FK_IdCaja_MovInventario_Caja] FOREIGN KEY([IDCaja])
REFERENCES [SCH_MANTENIMIENTO].[tbl_Cajas] ([IdCaja])
GO
ALTER TABLE [SCH_INVENTARIO].[tbl_MovimientoInventario] CHECK CONSTRAINT [FK_IdCaja_MovInventario_Caja]
GO
ALTER TABLE [SCH_INVENTARIO].[tbl_MovimientoInventario]  WITH NOCHECK ADD  CONSTRAINT [FK_IDCliente_Clientes_MovimientoInventario] FOREIGN KEY([IDCliente])
REFERENCES [SCH_VENTAS].[tbl_Clientes] ([IdCliente])
GO
ALTER TABLE [SCH_INVENTARIO].[tbl_MovimientoInventario] CHECK CONSTRAINT [FK_IDCliente_Clientes_MovimientoInventario]
GO
ALTER TABLE [SCH_INVENTARIO].[tbl_MovimientoInventario]  WITH NOCHECK ADD  CONSTRAINT [FK_IDEstado_Estado_MovimientoInventario] FOREIGN KEY([IdEstado])
REFERENCES [SCH_MANTENIMIENTO].[tbl_Estado] ([IdEstado])
GO
ALTER TABLE [SCH_INVENTARIO].[tbl_MovimientoInventario] CHECK CONSTRAINT [FK_IDEstado_Estado_MovimientoInventario]
GO
ALTER TABLE [SCH_INVENTARIO].[tbl_MovimientoInventario]  WITH NOCHECK ADD  CONSTRAINT [FK_IDMotivo_Motivo_MovimientoInventario] FOREIGN KEY([IDMotivo])
REFERENCES [SCH_INVENTARIO].[tbl_Motivo] ([IdMotivo])
GO
ALTER TABLE [SCH_INVENTARIO].[tbl_MovimientoInventario] CHECK CONSTRAINT [FK_IDMotivo_Motivo_MovimientoInventario]
GO
ALTER TABLE [SCH_INVENTARIO].[tbl_MovimientoInventario]  WITH NOCHECK ADD  CONSTRAINT [FK_IdProveedor_Proveedor_MovimientoInventario] FOREIGN KEY([IDProveedor])
REFERENCES [SCH_INVENTARIO].[tbl_proveedor] ([IdProveedor])
GO
ALTER TABLE [SCH_INVENTARIO].[tbl_MovimientoInventario] CHECK CONSTRAINT [FK_IdProveedor_Proveedor_MovimientoInventario]
GO
ALTER TABLE [SCH_INVENTARIO].[tbl_MovimientoInventario]  WITH NOCHECK ADD  CONSTRAINT [FK_IDTipo_TipoMovimiento_MovimientoInventario] FOREIGN KEY([IDTipo])
REFERENCES [SCH_INVENTARIO].[tbl_TipoMovimiento] ([IdTipo])
GO
ALTER TABLE [SCH_INVENTARIO].[tbl_MovimientoInventario] CHECK CONSTRAINT [FK_IDTipo_TipoMovimiento_MovimientoInventario]
GO
ALTER TABLE [SCH_INVENTARIO].[tbl_MovimientoInventario]  WITH NOCHECK ADD  CONSTRAINT [FK_IDUsuarioAutorizaEntrada_UsuariosSeguridad_MovimientoInventario] FOREIGN KEY([IDUsuarioAutorizaEntrada])
REFERENCES [SCH_SEGURIDAD].[tbl_UsuariosSeguridad] ([IdUsuarioSeguridad])
GO
ALTER TABLE [SCH_INVENTARIO].[tbl_MovimientoInventario] CHECK CONSTRAINT [FK_IDUsuarioAutorizaEntrada_UsuariosSeguridad_MovimientoInventario]
GO
ALTER TABLE [SCH_INVENTARIO].[tbl_MovimientoInventario]  WITH NOCHECK ADD  CONSTRAINT [FK_IDUsuarioAutorizaSalida_UsuariosSeguridad_MovimientoInventario] FOREIGN KEY([IDUsuarioAutorizaSalida])
REFERENCES [SCH_SEGURIDAD].[tbl_UsuariosSeguridad] ([IdUsuarioSeguridad])
GO
ALTER TABLE [SCH_INVENTARIO].[tbl_MovimientoInventario] CHECK CONSTRAINT [FK_IDUsuarioAutorizaSalida_UsuariosSeguridad_MovimientoInventario]
GO
ALTER TABLE [SCH_INVENTARIO].[tbl_MovimientoInventario]  WITH CHECK ADD  CONSTRAINT [FK_tbl_MovimientoInventario_tbl_Sucursales] FOREIGN KEY([IDSucursalEntrada])
REFERENCES [SCH_MANTENIMIENTO].[tbl_Sucursales] ([IdSucursal])
GO
ALTER TABLE [SCH_INVENTARIO].[tbl_MovimientoInventario] CHECK CONSTRAINT [FK_tbl_MovimientoInventario_tbl_Sucursales]
GO
ALTER TABLE [SCH_INVENTARIO].[tbl_MovimientoInventario]  WITH CHECK ADD  CONSTRAINT [FK_tbl_MovimientoInventario_tbl_Sucursales1] FOREIGN KEY([IDSucursalSalida])
REFERENCES [SCH_MANTENIMIENTO].[tbl_Sucursales] ([IdSucursal])
GO
ALTER TABLE [SCH_INVENTARIO].[tbl_MovimientoInventario] CHECK CONSTRAINT [FK_tbl_MovimientoInventario_tbl_Sucursales1]
GO
ALTER TABLE [SCH_INVENTARIO].[tbl_proveedor]  WITH NOCHECK ADD  CONSTRAINT [FK_IDEstado_Estado_Proveedor] FOREIGN KEY([IdEstado])
REFERENCES [SCH_MANTENIMIENTO].[tbl_Estado] ([IdEstado])
GO
ALTER TABLE [SCH_INVENTARIO].[tbl_proveedor] CHECK CONSTRAINT [FK_IDEstado_Estado_Proveedor]
GO
ALTER TABLE [SCH_INVENTARIO].[tbl_proveedor]  WITH NOCHECK ADD  CONSTRAINT [FK_IDTipoIdentificacion_Proveedores_TipoIdentificacion] FOREIGN KEY([IdTipoIdentificacion])
REFERENCES [SCH_MANTENIMIENTO].[tbl_TipoIdentificacion] ([IdTipoIdentificacion])
GO
ALTER TABLE [SCH_INVENTARIO].[tbl_proveedor] CHECK CONSTRAINT [FK_IDTipoIdentificacion_Proveedores_TipoIdentificacion]
GO
ALTER TABLE [SCH_INVENTARIO].[tbl_TipoMovimiento]  WITH NOCHECK ADD  CONSTRAINT [FK_IDEstado_Estado_TipoMovimiento] FOREIGN KEY([IdEstado])
REFERENCES [SCH_MANTENIMIENTO].[tbl_Estado] ([IdEstado])
GO
ALTER TABLE [SCH_INVENTARIO].[tbl_TipoMovimiento] CHECK CONSTRAINT [FK_IDEstado_Estado_TipoMovimiento]
GO
ALTER TABLE [SCH_MANTENIMIENTO].[tbl_Cajas]  WITH NOCHECK ADD  CONSTRAINT [FK_IdSucursal_Caja_Sucursales] FOREIGN KEY([IdSucursal])
REFERENCES [SCH_MANTENIMIENTO].[tbl_Sucursales] ([IdSucursal])
GO
ALTER TABLE [SCH_MANTENIMIENTO].[tbl_Cajas] CHECK CONSTRAINT [FK_IdSucursal_Caja_Sucursales]
GO
ALTER TABLE [SCH_MANTENIMIENTO].[tbl_EspecialidadUsuario]  WITH NOCHECK ADD  CONSTRAINT [FK_IdEspecialidad_EspecialidadUsuario_Especialidad] FOREIGN KEY([IdEspecialidad])
REFERENCES [SCH_MANTENIMIENTO].[tbl_Especialidad] ([IdEspecialidad])
GO
ALTER TABLE [SCH_MANTENIMIENTO].[tbl_EspecialidadUsuario] CHECK CONSTRAINT [FK_IdEspecialidad_EspecialidadUsuario_Especialidad]
GO
ALTER TABLE [SCH_MANTENIMIENTO].[tbl_EspecialidadUsuario]  WITH NOCHECK ADD  CONSTRAINT [FK_IdSucursal_Especialidad_Sucursales] FOREIGN KEY([IdSucursal])
REFERENCES [SCH_MANTENIMIENTO].[tbl_Sucursales] ([IdSucursal])
GO
ALTER TABLE [SCH_MANTENIMIENTO].[tbl_EspecialidadUsuario] CHECK CONSTRAINT [FK_IdSucursal_Especialidad_Sucursales]
GO
ALTER TABLE [SCH_MANTENIMIENTO].[tbl_Sucursales]  WITH NOCHECK ADD  CONSTRAINT [FK_IdEmpresa_Empresa_Sucursales] FOREIGN KEY([IdEmpresa])
REFERENCES [SCH_MANTENIMIENTO].[tbl_Empresa] ([IdEmpresa])
GO
ALTER TABLE [SCH_MANTENIMIENTO].[tbl_Sucursales] CHECK CONSTRAINT [FK_IdEmpresa_Empresa_Sucursales]
GO
ALTER TABLE [SCH_MANTENIMIENTO].[tbl_Sucursales]  WITH CHECK ADD  CONSTRAINT [FK_tbl_Sucursales_tbl_Estado] FOREIGN KEY([IdEstado])
REFERENCES [SCH_MANTENIMIENTO].[tbl_Estado] ([IdEstado])
GO
ALTER TABLE [SCH_MANTENIMIENTO].[tbl_Sucursales] CHECK CONSTRAINT [FK_tbl_Sucursales_tbl_Estado]
GO
ALTER TABLE [SCH_MANTENIMIENTO].[tbl_TipoIdentificacion]  WITH NOCHECK ADD  CONSTRAINT [FK_IdEstado_TipoIdentificacion_Estado] FOREIGN KEY([IdEstado])
REFERENCES [SCH_MANTENIMIENTO].[tbl_Estado] ([IdEstado])
GO
ALTER TABLE [SCH_MANTENIMIENTO].[tbl_TipoIdentificacion] CHECK CONSTRAINT [FK_IdEstado_TipoIdentificacion_Estado]
GO
ALTER TABLE [SCH_NOMINA].[tbl_DiasLibres]  WITH NOCHECK ADD  CONSTRAINT [FK_IdDia_DiasLibRes_DiasSemana] FOREIGN KEY([IdDia])
REFERENCES [SCH_MANTENIMIENTO].[tbl_DiaSemana] ([IdDia])
GO
ALTER TABLE [SCH_NOMINA].[tbl_DiasLibres] CHECK CONSTRAINT [FK_IdDia_DiasLibRes_DiasSemana]
GO
ALTER TABLE [SCH_NOMINA].[tbl_DiasLibres]  WITH CHECK ADD  CONSTRAINT [FK_tbl_DiasLibres_tbl_Horarios] FOREIGN KEY([IdHorario])
REFERENCES [SCH_NOMINA].[tbl_Horarios] ([IdHorario])
GO
ALTER TABLE [SCH_NOMINA].[tbl_DiasLibres] CHECK CONSTRAINT [FK_tbl_DiasLibres_tbl_Horarios]
GO
ALTER TABLE [SCH_NOMINA].[tbl_Horarios]  WITH CHECK ADD  CONSTRAINT [FK_tbl_Horarios_tbl_Usuarios] FOREIGN KEY([IdUsuario])
REFERENCES [SCH_NOMINA].[tbl_Usuarios] ([Id_Usuario])
GO
ALTER TABLE [SCH_NOMINA].[tbl_Horarios] CHECK CONSTRAINT [FK_tbl_Horarios_tbl_Usuarios]
GO
ALTER TABLE [SCH_NOMINA].[tbl_Marcas]  WITH CHECK ADD  CONSTRAINT [FK_tbl_Marcas_tbl_TiposMarca] FOREIGN KEY([IdTipoMarca])
REFERENCES [SCH_NOMINA].[tbl_TiposMarca] ([IdTipoMarca])
GO
ALTER TABLE [SCH_NOMINA].[tbl_Marcas] CHECK CONSTRAINT [FK_tbl_Marcas_tbl_TiposMarca]
GO
ALTER TABLE [SCH_NOMINA].[tbl_Marcas]  WITH CHECK ADD  CONSTRAINT [FK_tbl_Marcas_tbl_Usuarios] FOREIGN KEY([IdUsuario])
REFERENCES [SCH_NOMINA].[tbl_Usuarios] ([Id_Usuario])
GO
ALTER TABLE [SCH_NOMINA].[tbl_Marcas] CHECK CONSTRAINT [FK_tbl_Marcas_tbl_Usuarios]
GO
ALTER TABLE [SCH_NOMINA].[tbl_Permisos]  WITH CHECK ADD  CONSTRAINT [FK_tbl_Permisos_tbl_TiposPermiso] FOREIGN KEY([IdTipoPermiso])
REFERENCES [SCH_NOMINA].[tbl_TiposPermiso] ([IdTipoPermiso])
GO
ALTER TABLE [SCH_NOMINA].[tbl_Permisos] CHECK CONSTRAINT [FK_tbl_Permisos_tbl_TiposPermiso]
GO
ALTER TABLE [SCH_NOMINA].[tbl_Permisos]  WITH CHECK ADD  CONSTRAINT [FK_tbl_Permisos_tbl_Usuarios] FOREIGN KEY([IdUsuario])
REFERENCES [SCH_NOMINA].[tbl_Usuarios] ([Id_Usuario])
GO
ALTER TABLE [SCH_NOMINA].[tbl_Permisos] CHECK CONSTRAINT [FK_tbl_Permisos_tbl_Usuarios]
GO
ALTER TABLE [SCH_NOMINA].[tbl_Usuarios]  WITH NOCHECK ADD  CONSTRAINT [FK_IdUsuario_EspecialidadUsuario_Usuarios] FOREIGN KEY([Id_Usuario])
REFERENCES [SCH_SEGURIDAD].[tbl_UsuariosSeguridad] ([IdUsuarioSeguridad])
GO
ALTER TABLE [SCH_NOMINA].[tbl_Usuarios] CHECK CONSTRAINT [FK_IdUsuario_EspecialidadUsuario_Usuarios]
GO
ALTER TABLE [SCH_NOMINA].[tbl_Usuarios]  WITH NOCHECK ADD  CONSTRAINT [FK_IdUsuario_Usuarios_UsuariosSeguridad] FOREIGN KEY([Id_Usuario])
REFERENCES [SCH_SEGURIDAD].[tbl_UsuariosSeguridad] ([IdUsuarioSeguridad])
GO
ALTER TABLE [SCH_NOMINA].[tbl_Usuarios] CHECK CONSTRAINT [FK_IdUsuario_Usuarios_UsuariosSeguridad]
GO
ALTER TABLE [SCH_SEGURIDAD].[tbl_PermisosSeguridad]  WITH NOCHECK ADD  CONSTRAINT [FK_IdEstado_PermisoSeguridad_Estado] FOREIGN KEY([IdEstado])
REFERENCES [SCH_MANTENIMIENTO].[tbl_Estado] ([IdEstado])
GO
ALTER TABLE [SCH_SEGURIDAD].[tbl_PermisosSeguridad] CHECK CONSTRAINT [FK_IdEstado_PermisoSeguridad_Estado]
GO
ALTER TABLE [SCH_SEGURIDAD].[tbl_PermisosSeguridad]  WITH NOCHECK ADD  CONSTRAINT [FK_IdSubModulo_PermisoSeguridad_SubModulo] FOREIGN KEY([IdSubModulo])
REFERENCES [SCH_SEGURIDAD].[tbl_SubModulos] ([IdSubModulo])
GO
ALTER TABLE [SCH_SEGURIDAD].[tbl_PermisosSeguridad] CHECK CONSTRAINT [FK_IdSubModulo_PermisoSeguridad_SubModulo]
GO
ALTER TABLE [SCH_SEGURIDAD].[tbl_PermisosSeguridad]  WITH NOCHECK ADD  CONSTRAINT [FK_IdTipoPerfil_PermisoSeguridad_TiposPerfi] FOREIGN KEY([IdTipoPerfil])
REFERENCES [SCH_SEGURIDAD].[tbl_TiposPerfil] ([IdTipoPerfil])
GO
ALTER TABLE [SCH_SEGURIDAD].[tbl_PermisosSeguridad] CHECK CONSTRAINT [FK_IdTipoPerfil_PermisoSeguridad_TiposPerfi]
GO
ALTER TABLE [SCH_SEGURIDAD].[tbl_SubModulos]  WITH NOCHECK ADD  CONSTRAINT [FK_IdSubModulos_SubModulos_Modulos] FOREIGN KEY([IdModulos])
REFERENCES [SCH_SEGURIDAD].[tbl_Modulos] ([IdModulo])
GO
ALTER TABLE [SCH_SEGURIDAD].[tbl_SubModulos] CHECK CONSTRAINT [FK_IdSubModulos_SubModulos_Modulos]
GO
ALTER TABLE [SCH_SEGURIDAD].[tbl_SubModulos]  WITH NOCHECK ADD  CONSTRAINT [FK_IdTipoPerfil_SubModulos_TiposPerfi] FOREIGN KEY([IdTipoPerfil])
REFERENCES [SCH_SEGURIDAD].[tbl_TiposPerfil] ([IdTipoPerfil])
GO
ALTER TABLE [SCH_SEGURIDAD].[tbl_SubModulos] CHECK CONSTRAINT [FK_IdTipoPerfil_SubModulos_TiposPerfi]
GO
ALTER TABLE [SCH_SEGURIDAD].[tbl_TiposPerfil]  WITH NOCHECK ADD  CONSTRAINT [FK_IdEspecialidad_TipoPerfil_Especialidad] FOREIGN KEY([IdEspecialidad])
REFERENCES [SCH_MANTENIMIENTO].[tbl_Especialidad] ([IdEspecialidad])
GO
ALTER TABLE [SCH_SEGURIDAD].[tbl_TiposPerfil] CHECK CONSTRAINT [FK_IdEspecialidad_TipoPerfil_Especialidad]
GO
ALTER TABLE [SCH_SEGURIDAD].[tbl_TiposPerfil]  WITH NOCHECK ADD  CONSTRAINT [FK_IdSucursal_TipoPerfil_Sucursal] FOREIGN KEY([IdSucursal])
REFERENCES [SCH_MANTENIMIENTO].[tbl_Sucursales] ([IdSucursal])
GO
ALTER TABLE [SCH_SEGURIDAD].[tbl_TiposPerfil] CHECK CONSTRAINT [FK_IdSucursal_TipoPerfil_Sucursal]
GO
ALTER TABLE [SCH_SEGURIDAD].[tbl_UsuariosSeguridad]  WITH NOCHECK ADD  CONSTRAINT [FK_IdTipoPerfil_UsuarioSeguridad_TiposPerfi] FOREIGN KEY([IdUsuarioSeguridad])
REFERENCES [SCH_SEGURIDAD].[tbl_TiposPerfil] ([IdTipoPerfil])
GO
ALTER TABLE [SCH_SEGURIDAD].[tbl_UsuariosSeguridad] CHECK CONSTRAINT [FK_IdTipoPerfil_UsuarioSeguridad_TiposPerfi]
GO
ALTER TABLE [SCH_SEGURIDAD].[tbl_UsuariosSeguridad]  WITH NOCHECK ADD  CONSTRAINT [FK_IdUsuario_UsuarioSeguridad_TiposPerfi] FOREIGN KEY([IdUsuarioSeguridad])
REFERENCES [SCH_SEGURIDAD].[tbl_UsuariosSeguridad] ([IdUsuarioSeguridad])
GO
ALTER TABLE [SCH_SEGURIDAD].[tbl_UsuariosSeguridad] CHECK CONSTRAINT [FK_IdUsuario_UsuarioSeguridad_TiposPerfi]
GO
ALTER TABLE [SCH_SEGURIDAD].[tbl_UsuariosSeguridad]  WITH NOCHECK ADD  CONSTRAINT [FK_IdUsuarioPerfil_UsuarioSeguridad_TiposPerfi] FOREIGN KEY([IdTipoPerfil])
REFERENCES [SCH_SEGURIDAD].[tbl_TiposPerfil] ([IdTipoPerfil])
GO
ALTER TABLE [SCH_SEGURIDAD].[tbl_UsuariosSeguridad] CHECK CONSTRAINT [FK_IdUsuarioPerfil_UsuarioSeguridad_TiposPerfi]
GO
ALTER TABLE [SCH_VENTAS].[tbl_Citas]  WITH NOCHECK ADD  CONSTRAINT [FK_Mascota_Mascotas_Cita] FOREIGN KEY([IdMascota])
REFERENCES [SCH_VENTAS].[tbl_Mascotas] ([IdMascota])
GO
ALTER TABLE [SCH_VENTAS].[tbl_Citas] CHECK CONSTRAINT [FK_Mascota_Mascotas_Cita]
GO
ALTER TABLE [SCH_VENTAS].[tbl_Clientes]  WITH NOCHECK ADD  CONSTRAINT [FK_IDTipoIdentificacion_Clientes_TipoIdentificacion] FOREIGN KEY([IdTipoIdentificacion])
REFERENCES [SCH_MANTENIMIENTO].[tbl_TipoIdentificacion] ([IdTipoIdentificacion])
GO
ALTER TABLE [SCH_VENTAS].[tbl_Clientes] CHECK CONSTRAINT [FK_IDTipoIdentificacion_Clientes_TipoIdentificacion]
GO
ALTER TABLE [SCH_VENTAS].[tbl_Mascotas]  WITH NOCHECK ADD  CONSTRAINT [FK_IdCliente_Cliente_Mascotas] FOREIGN KEY([IdCliente])
REFERENCES [SCH_VENTAS].[tbl_Clientes] ([IdCliente])
GO
ALTER TABLE [SCH_VENTAS].[tbl_Mascotas] CHECK CONSTRAINT [FK_IdCliente_Cliente_Mascotas]
GO
ALTER TABLE [SCH_VENTAS].[tbl_Mascotas]  WITH NOCHECK ADD  CONSTRAINT [FK_Raza_Mascota_Raza] FOREIGN KEY([IdRaza])
REFERENCES [SCH_VENTAS].[tbl_Razas] ([IdRaza])
GO
ALTER TABLE [SCH_VENTAS].[tbl_Mascotas] CHECK CONSTRAINT [FK_Raza_Mascota_Raza]
GO
ALTER TABLE [SCH_VENTAS].[tbl_Razas]  WITH NOCHECK ADD  CONSTRAINT [FK_Especie_Raza_Especie] FOREIGN KEY([IdEspecie])
REFERENCES [SCH_VENTAS].[tbl_Especie] ([IdEspecie])
GO
ALTER TABLE [SCH_VENTAS].[tbl_Razas] CHECK CONSTRAINT [FK_Especie_Raza_Especie]
GO
/****** Object:  StoredProcedure [SCH_INVENTARIO].[SP_Inserta_Articulo]    Script Date: 09/04/2020 3:55:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Josue Azofeifa
-- Create date: 05/04/2020
-- Description:	
-- =============================================
/*
EXEC [SCH_INVENTARIO].[SP_Modifica_Articulo] 
*/
CREATE PROCEDURE [SCH_INVENTARIO].[SP_Inserta_Articulo]

	@@NOMBRE_ARTICULO VARCHAR(100),
	@@DESCRIPCION VARCHAR (100),
	@@SERVICIO BIT,
	@@PRECIO MONEY,
	@@CANTIDAD_STOCK INT,
	@@CANTIDAD_MAX INT,
	@@CANTIDAD_MIN INT,
	@@ID_ESTADO INT

	AS
BEGIN
			DECLARE @NOMBREARTICULO VARCHAR(100)
			DECLARE @DESCRIPCION VARCHAR (100)
			DECLARE @SERVICIO BIT
			DECLARE @PRECIO MONEY
			DECLARE @CANTIDADSTOCK INT
			DECLARE @CANTIDADMAX INT
			DECLARE @CANTIDADMIN INT
			DECLARE @IDESTADO INT


			SET @NOMBREARTICULO = @@NOMBRE_ARTICULO
			SET @DESCRIPCION = @@DESCRIPCION
			SET @SERVICIO = @@SERVICIO
			SET @PRECIO = @@PRECIO
			SET @CANTIDADSTOCK = @@CANTIDAD_STOCK
			SET @CANTIDADMAX = @@CANTIDAD_MAX
			SET @CANTIDADMIN = @@CANTIDAD_MIN
			SET @IDESTADO = @@ID_ESTADO


		Insert into SCH_INVENTARIO.tbl_Articulos 
		values ( @NOMBREARTICULO , @DESCRIPCION , @SERVICIO , @PRECIO , @CANTIDADSTOCK , @CANTIDADMAX , @CANTIDADMIN , @IDESTADO )
		END
GO
/****** Object:  StoredProcedure [SCH_INVENTARIO].[SP_Inserta_Motivo]    Script Date: 09/04/2020 3:55:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Josue Azofeifa
-- Create date: 05/04/2020
-- Description:	Inserta Motivos
-- =============================================
/*
EXEC [SCH_INVENTARIO].[SP_Inserta_Articulo] 
*/

CREATE PROCEDURE [SCH_INVENTARIO].[SP_Inserta_Motivo]

	@@DESCRIPCION VARCHAR (200),
	@@ID_ESTADO INT

	AS
BEGIN
			DECLARE @DESCRIPCION VARCHAR (100)
			DECLARE @IDESTADO INT


			SET @DESCRIPCION = @@DESCRIPCION
			SET @IDESTADO = @@ID_ESTADO


		Insert into SCH_INVENTARIO.tbl_Motivo
		values (  @DESCRIPCION , @IDESTADO )
		END
GO
/****** Object:  StoredProcedure [SCH_INVENTARIO].[SP_Inserta_Movimiento_Detalle]    Script Date: 09/04/2020 3:55:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Josue Azofeifa
-- Create date: 05/04/2020
-- Description:	
-- =============================================
/*
EXEC [SCH_INVENTARIO].[SP_Inserta_Movimiento_Detalle] 
*/

CREATE PROCEDURE [SCH_INVENTARIO].[SP_Inserta_Movimiento_Detalle]

	@@IDMOVIMIENTO INT,
	@@IDARTICULO INT,
	@@IDPEDIDO INT,
	@@CANTIDAD INT,
	@@MONTOTOTAL MONEY,
	@@PORCENTAJEIMPUESTO INT,
	@@PORCENTJEDESCUENTO INT,
	@@CANTIDADBACKORDER INT,
	@@IDESTADO INT

	AS
BEGIN
			DECLARE @IDMOVIMIENTO INT
			DECLARE @IDARTICULO INT
			DECLARE @IDPEDIDO INT
			DECLARE @CANTIDAD INT
			DECLARE @MONTOTOTAL MONEY
			DECLARE @PORCENTAJEIMPUESTO INT
			DECLARE @PORCENTJEDESCUENTO INT
			DECLARE @CANTIDADBACKORDER INT
			DECLARE @IDESTADO INT


			SET @IDMOVIMIENTO =@@IDMOVIMIENTO
			SET @IDARTICULO = @@IDARTICULO
			SET @IDPEDIDO = @@IDPEDIDO
			SET @CANTIDAD = @@CANTIDAD
			SET @MONTOTOTAL = @@MONTOTOTAL
			SET @PORCENTAJEIMPUESTO = @@PORCENTAJEIMPUESTO
			SET @PORCENTJEDESCUENTO = @@PORCENTJEDESCUENTO
			SET @CANTIDADBACKORDER = @@CANTIDADBACKORDER
			SET @IDESTADO = @@IDESTADO


		Insert into SCH_INVENTARIO.tbl_MovimientoDetalle
		values ( @IDMOVIMIENTO , @IDARTICULO , @IDPEDIDO , @CANTIDAD , @MONTOTOTAL , @PORCENTAJEIMPUESTO , @PORCENTJEDESCUENTO , @CANTIDADBACKORDER ,  @IDESTADO )
		END
GO
/****** Object:  StoredProcedure [SCH_INVENTARIO].[SP_Inserta_Movimiento_Inventario]    Script Date: 09/04/2020 3:55:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Josue Azofeifa
-- Create date: 05/04/2020
-- Description:	
-- =============================================
/*
EXEC [SCH_INVENTARIO].[SP_Inserta_Movimiento_INVENTARIO] 
*/

CREATE PROCEDURE [SCH_INVENTARIO].[SP_Inserta_Movimiento_Inventario]

	@@IDPROVEEDOR INT,
	@@IDCLIENTE INT,
	@@IDSUCURSALENTRADA INT,
	@@IDSUCURSALSALIDA INT,
	@@IDAUTORIZAENTRADA INT,
	@@IDAUTORIZASALIDA INT,
	@@IDTIPO INT,
	@@IDMOTIVO INT,
	@@IDCaja int,
	@@IDESTADO INT

	AS
BEGIN
			DECLARE @IDPROVEEDOR INT
			DECLARE @IDCLIENTE INT
			DECLARE @IDSUCURSALENTRADA INT
			DECLARE @IDSUCURSALSALIDA INT
			DECLARE @IDAUTORIZAENTRADA INT
			DECLARE @IDAUTORIZASALIDA INT
			DECLARE @IDTIPO INT
			DECLARE @IDMOTIVO INT
			DECLARE @IDCAJA INT
			DECLARE @IDESTADO INT


			SET @IDPROVEEDOR = @@IDPROVEEDOR
			SET @IDCLIENTE = @@IDCLIENTE
			SET @IDSUCURSALENTRADA = @@IDSUCURSALENTRADA
			SET @IDSUCURSALSALIDA = @@IDSUCURSALSALIDA
			SET @IDAUTORIZAENTRADA = @@IDAUTORIZAENTRADA
			SET @IDAUTORIZASALIDA = @@IDAUTORIZASALIDA
			SET @IDTIPO = @@IDTIPO
			SET @IDMOTIVO = @@IDMOTIVO
			SET @IDCAJA = @@IDCaja
			SET @IDESTADO = @@IDESTADO


		Insert into SCH_INVENTARIO.tbl_MovimientoInventario
		values ( @IDPROVEEDOR , @IDCLIENTE , @IDSUCURSALENTRADA , @IDSUCURSALSALIDA , @IDAUTORIZAENTRADA , @IDAUTORIZASALIDA , @IDTIPO , @IDMOTIVO , @IDCAJA, @IDESTADO )
		END
GO
/****** Object:  StoredProcedure [SCH_INVENTARIO].[SP_Inserta_Proveedor]    Script Date: 09/04/2020 3:55:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Josue Azofeifa
-- Create date: 05/04/2020
-- Description:	
-- =============================================
/*
EXEC [SCH_INVENTARIO].[SP_Inserta_Proveedor] 
*/

CREATE PROCEDURE [SCH_INVENTARIO].[SP_Inserta_Proveedor]
	@@TIPODENTIFICACION INT,
	@@IDentificacion VARCHAR (100),
	@@NOMBRE VARCHAR (50),
	@@APELLIDO VARCHAR (50),
	@@APELLIDO2 VARCHAR (50),
	@@RAZONSOCIAL VARCHAR (100),
	@@EMAIL VARCHAR (50),
	@@TELEFONO1 INT,
	@@TELEFONO2 INT,
	@@IDESTADO INT

	AS
BEGIN
			DECLARE @TIPODENTIFICACION INT
			DECLARE @IDentificacion VARCHAR (100)
			DECLARE @NOMBRE VARCHAR (50)
			DECLARE @APELLIDO VARCHAR (50)
			DECLARE @APELLIDO2 VARCHAR (50)
			DECLARE @RAZONSOCIAL VARCHAR (100)
			DECLARE @EMAIL VARCHAR (50)
			DECLARE @TELEFONO1 INT
			DECLARE @TELEFONO2 INT
			DECLARE @IDESTADO INT

			
			SET @TIPODENTIFICACION = @@TIPODENTIFICACION
			SET @IDentificacion = @@IDentificacion
			SET @NOMBRE = @@NOMBRE
			SET @APELLIDO = @@APELLIDO
			SET @APELLIDO2 = @@APELLIDO2
			SET @RAZONSOCIAL = @@RAZONSOCIAL
			SET @EMAIL = @@EMAIL
			SET @TELEFONO1 = @@TELEFONO1
			SET @TELEFONO2 = @@TELEFONO2
			SET @IDESTADO = @@IDESTADO


		Insert into SCH_INVENTARIO.tbl_proveedor
		values (@TIPODENTIFICACION , @IDentificacion , @NOMBRE , @APELLIDO , @APELLIDO2 , @RAZONSOCIAL , @EMAIL , @TELEFONO1 , @TELEFONO2 ,  @IDESTADO )
		END
GO
/****** Object:  StoredProcedure [SCH_INVENTARIO].[SP_Inserta_Tipo_Movimiento]    Script Date: 09/04/2020 3:55:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Josue Azofeifa
-- Create date: 05/04/2020
-- Description:	
-- =============================================
/*
EXEC [SCH_INVENTARIO].[SP_Inserta_Tipo_Movimiento] 
*/

CREATE PROCEDURE [SCH_INVENTARIO].[SP_Inserta_Tipo_Movimiento]

	@@NOMBRETIPO VARCHAR(100),
	@@ID_ESTADO INT

	AS
BEGIN
			DECLARE @NOMBRETIPO VARCHAR(100)
			DECLARE @IDESTADO INT


			SET @NOMBRETIPO = @@NOMBRETIPO
			SET @IDESTADO = @@ID_ESTADO


		Insert into SCH_INVENTARIO.tbl_TipoMovimiento
		values ( @NOMBRETIPO , @IDESTADO )
		END
GO
/****** Object:  StoredProcedure [SCH_INVENTARIO].[SP_MODIFICA_Articulo]    Script Date: 09/04/2020 3:55:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Josue Azofeifa
-- Create date: 05/04/2020
-- Description:	
-- =============================================
/*
EXEC [SCH_INVENTARIO].[SP_Modifica_Articulo] 
*/

CREATE PROCEDURE [SCH_INVENTARIO].[SP_MODIFICA_Articulo]
	@@IDARTICULO INT,
	@@NOMBRE_ARTICULO VARCHAR(100),
	@@DESCRIPCION VARCHAR (100),
	@@SERVICIO BIT,
	@@PRECIO MONEY,
	@@CANTIDAD_STOCK INT,
	@@CANTIDAD_MAX INT,
	@@CANTIDAD_MIN INT,
	@@ID_ESTADO INT

	AS
BEGIN
			DECLARE @IDARTICULO INT
			DECLARE @NOMBREARTICULO VARCHAR(100)
			DECLARE @DESCRIPCION VARCHAR (100)
			DECLARE @SERVICIO BIT
			DECLARE @PRECIO MONEY
			DECLARE @CANTIDADSTOCK INT
			DECLARE @CANTIDADMAX INT
			DECLARE @CANTIDADMIN INT
			DECLARE @IDESTADO INT

			SET @IDARTICULO = @@IDARTICULO
			SET @NOMBREARTICULO = @@NOMBRE_ARTICULO
			SET @DESCRIPCION = @@DESCRIPCION
			SET @SERVICIO = @@SERVICIO
			SET @PRECIO = @@PRECIO
			SET @CANTIDADSTOCK = @@CANTIDAD_STOCK
			SET @CANTIDADMAX = @@CANTIDAD_MAX
			SET @CANTIDADMIN = @@CANTIDAD_MIN
			SET @IDESTADO = @@ID_ESTADO


	UPDATE SCH_INVENTARIO.tbl_Articulos 
		SET
			NombreArticulo = @NOMBREARTICULO  , 
			Descripcion = @DESCRIPCION ,
			Servicio = @SERVICIO ,
			Precio = @PRECIO ,
			CantidadStock = @CANTIDADSTOCK ,
			CantidadMax= @CANTIDADMAX ,
			CantidadMin= @CANTIDADMIN ,
			IdEstado = @IDESTADO 
		
	WHERE
			IdArticulo = @IDARTICULO 

	END
GO
/****** Object:  StoredProcedure [SCH_INVENTARIO].[SP_Modifica_Motivo]    Script Date: 09/04/2020 3:55:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Josue Azofeifa
-- Create date: 05/04/2020
-- Description:	MODIFICA Motivos
-- =============================================
/*
EXEC [SCH_INVENTARIO].[SP_Modifica_Articulo] 
*/

CREATE PROCEDURE [SCH_INVENTARIO].[SP_Modifica_Motivo]
	@@IDMOTIVO INT,
	@@DESCRIPCION VARCHAR (200),
	@@ID_ESTADO INT

	AS
BEGIN
			DECLARE @IDMOTIVO INT
			DECLARE @DESCRIPCION VARCHAR (100)
			DECLARE @IDESTADO INT

			SET @IDMOTIVO = @@IDMOTIVO
			SET @DESCRIPCION = @@DESCRIPCION
			SET @IDESTADO = @@ID_ESTADO


		UPDATE SCH_INVENTARIO.tbl_Motivo
			SET  Descripcion = @DESCRIPCION,
				 IdEstado = @IDESTADO 

		WHERE IdMotivo = @IDMOTIVO

		END
GO
/****** Object:  StoredProcedure [SCH_INVENTARIO].[SP_Modifica_Movimiento_Detalle]    Script Date: 09/04/2020 3:55:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Josue Azofeifa
-- Create date: 05/04/2020
-- Description:	
-- =============================================
/*
EXEC [SCH_INVENTARIO].[SP_Modifica_Movimiento_Detalle] 
*/

CREATE PROCEDURE [SCH_INVENTARIO].[SP_Modifica_Movimiento_Detalle]
	@@IDDETALLE INT,
	@@IDMOVIMIENTO INT,
	@@IDARTICULO INT,
	@@IDPEDIDO INT,
	@@CANTIDAD INT,
	@@MONTOTOTAL MONEY,
	@@PORCENTAJEIMPUESTO INT,
	@@PORCENTJEDESCUENTO INT,
	@@CANTIDADBACKORDER INT,
	@@IDESTADO INT

	AS
BEGIN
			DECLARE @IDDETALLE INT
			DECLARE @IDMOVIMIENTO INT
			DECLARE @IDARTICULO INT
			DECLARE @IDPEDIDO INT
			DECLARE @CANTIDAD INT
			DECLARE @MONTOTOTAL MONEY
			DECLARE @PORCENTAJEIMPUESTO INT
			DECLARE @PORCENTJEDESCUENTO INT
			DECLARE @CANTIDADBACKORDER INT
			DECLARE @IDESTADO INT

			SET @IDDETALLE = @@IDDETALLE
			SET @IDMOVIMIENTO =@@IDMOVIMIENTO
			SET @IDARTICULO = @@IDARTICULO
			SET @IDPEDIDO = @@IDPEDIDO
			SET @CANTIDAD = @@CANTIDAD
			SET @MONTOTOTAL = @@MONTOTOTAL
			SET @PORCENTAJEIMPUESTO = @@PORCENTAJEIMPUESTO
			SET @PORCENTJEDESCUENTO = @@PORCENTJEDESCUENTO
			SET @CANTIDADBACKORDER = @@CANTIDADBACKORDER
			SET @IDESTADO = @@IDESTADO


				UPDATE SCH_INVENTARIO.tbl_MovimientoDetalle
						SET		
								IDMovimiento = @IDMOVIMIENTO, 
								IDARTICULO = @IDARTICULO,  
								IDPedido = @IDPEDIDO, 
								Cantidad = @CANTIDAD, 
								MontoTotal = @MONTOTOTAL,
								PorcentajeImpuesto = @PORCENTAJEIMPUESTO, 
								PorcentajeDescuento = @PORCENTJEDESCUENTO, 
								CantidadBackorder = @CANTIDADBACKORDER,  
								IdEstado = @IDESTADO 

						WHERE
								IDDetalle = IDDetalle
							
							END
GO
/****** Object:  StoredProcedure [SCH_INVENTARIO].[SP_Modifica_Movimiento_Inventario]    Script Date: 09/04/2020 3:55:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Josue Azofeifa
-- Create date: 05/04/2020
-- Description:	
-- =============================================
/*
EXEC [SCH_INVENTARIO].[SP_Modifica_Movimiento_INVENTARIO] 
*/

CREATE PROCEDURE [SCH_INVENTARIO].[SP_Modifica_Movimiento_Inventario]
	@@IDMOVIMIENTO INT,
	@@IDPROVEEDOR INT,
	@@IDCLIENTE INT,
	@@IDSUCURSALENTRADA INT,
	@@IDSUCURSALSALIDA INT,
	@@IDAUTORIZAENTRADA INT,
	@@IDAUTORIZASALIDA INT,
	@@IDTIPO INT,
	@@IDMOTIVO INT,
	@@IDESTADO INT

	AS
BEGIN
			DECLARE @IDMOVIMIENTO INT
			DECLARE @IDPROVEEDOR INT
			DECLARE @IDCLIENTE INT
			DECLARE @IDSUCURSALENTRADA INT
			DECLARE @IDSUCURSALSALIDA INT
			DECLARE @IDAUTORIZAENTRADA INT
			DECLARE @IDAUTORIZASALIDA INT
			DECLARE @IDTIPO INT
			DECLARE @IDMOTIVO INT
			DECLARE @IDESTADO INT


			SET @IDMOVIMIENTO = @@IDMOVIMIENTO
			SET @IDPROVEEDOR = @@IDPROVEEDOR
			SET @IDCLIENTE = @@IDCLIENTE
			SET @IDSUCURSALENTRADA = @@IDSUCURSALENTRADA
			SET @IDSUCURSALSALIDA = @@IDSUCURSALSALIDA
			SET @IDAUTORIZAENTRADA = @@IDAUTORIZAENTRADA
			SET @IDAUTORIZASALIDA = @@IDAUTORIZASALIDA
			SET @IDTIPO = @@IDTIPO
			SET @IDMOTIVO = @@IDMOTIVO
			SET @IDESTADO = @@IDESTADO


		UPDATE SCH_INVENTARIO.tbl_MovimientoInventario

			SET
			 IDProveedor = @IDPROVEEDOR , 
			 IDCliente = @IDCLIENTE , 
			 IDSucursalEntrada = @IDSUCURSALENTRADA , 
			 IDSucursalSalida = @IDSUCURSALSALIDA , 
			 IDUsuarioAutorizaEntrada = @IDAUTORIZAENTRADA , 
			 IDUsuarioAutorizaSalida = @IDAUTORIZASALIDA , 
			 IDTipo = @IDTIPO , 
			 IDMotivo = @IDMOTIVO ,  
			 IdEstado = @IDESTADO 

				WHERE 
					IDMovimiento = @IDMOVIMIENTO
		
		END
GO
/****** Object:  StoredProcedure [SCH_INVENTARIO].[SP_Modifica_Proveedor]    Script Date: 09/04/2020 3:55:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Josue Azofeifa
-- Create date: 05/04/2020
-- Description:	
-- =============================================
/*
EXEC [SCH_INVENTARIO].[SP_Modifica_Proveedor] 
*/

CREATE PROCEDURE [SCH_INVENTARIO].[SP_Modifica_Proveedor]
	@@IDPROVEEDOR INT,
	@@TIPODENTIFICACION INT,
	@@IDentificacion VARCHAR (100),
	@@NOMBRE VARCHAR (50),
	@@APELLIDO VARCHAR (50),
	@@APELLIDO2 VARCHAR (50),
	@@RAZONSOCIAL VARCHAR (100),
	@@EMAIL VARCHAR (50),
	@@TELEFONO1 INT,
	@@TELEFONO2 INT,
	@@IDESTADO INT

	AS
BEGIN
			DECLARE @IDPROVEEDOR INT
			DECLARE @TIPODENTIFICACION INT
			DECLARE @IDentificacion VARCHAR (100)
			DECLARE @NOMBRE VARCHAR (50)
			DECLARE @APELLIDO VARCHAR (50)
			DECLARE @APELLIDO2 VARCHAR (50)
			DECLARE @RAZONSOCIAL VARCHAR (100)
			DECLARE @EMAIL VARCHAR (50)
			DECLARE @TELEFONO1 INT
			DECLARE @TELEFONO2 INT
			DECLARE @IDESTADO INT


			SET @IDPROVEEDOR = @@IDPROVEEDOR
			SET @TIPODENTIFICACION = @@TIPODENTIFICACION
			SET @IDentificacion = @@IDentificacion
			SET @NOMBRE = @@NOMBRE
			SET @APELLIDO = @@APELLIDO
			SET @APELLIDO2 = @@APELLIDO2
			SET @RAZONSOCIAL = @@RAZONSOCIAL
			SET @EMAIL = @@EMAIL
			SET @TELEFONO1 = @@TELEFONO1
			SET @TELEFONO2 = @@TELEFONO2
			SET @IDESTADO = @@IDESTADO


		UPDATE SCH_INVENTARIO.tbl_proveedor
			SET 
				IDTIPOIDENTIFICACION = @TIPODENTIFICACION,
				Identificacion = @IDentificacion , 
				Nombre = @NOMBRE , 
				Apellido = @APELLIDO , 
				Apellido2 = @APELLIDO2 , 
				RazonSocial =  @RAZONSOCIAL , 
				Email = @EMAIL , 
				Telefono1 = @TELEFONO1 , 
				Telefono2 = @TELEFONO2 ,  
				IdEstado = @IDESTADO 

				WHERE
					IdProveedor = @IDPROVEEDOR
	END
GO
/****** Object:  StoredProcedure [SCH_INVENTARIO].[SP_Modifica_Tipo_Movimiento]    Script Date: 09/04/2020 3:55:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Josue Azofeifa
-- Create date: 05/04/2020
-- Description:	
-- =============================================
/*
EXEC [SCH_INVENTARIO].[SP_Modifica_Tipo_Movimiento] 
*/

CREATE PROCEDURE [SCH_INVENTARIO].[SP_Modifica_Tipo_Movimiento]
	@@IDTIPO INT,
	@@NOMBRETIPO VARCHAR(100),
	@@ID_ESTADO INT

	AS
BEGIN
			DECLARE @IDTIPO INT
			DECLARE @NOMBRETIPO VARCHAR(100)
			DECLARE @IDESTADO INT

			SET @IDTIPO = @@IDTIPO
			SET @NOMBRETIPO = @@NOMBRETIPO
			SET @IDESTADO = @@ID_ESTADO


		UPDATE SCH_INVENTARIO.tbl_TipoMovimiento
			SET  
				NombreTipo = @NOMBRETIPO , 
				IdEstado = @IDESTADO

			WHERE 
				IdTipo = @IDTIPO
		END
GO
/****** Object:  StoredProcedure [SCH_INVENTARIO].[SP_SELECT_Articulo]    Script Date: 09/04/2020 3:55:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Josue Azofeifa
-- Create date: 05/04/2020
-- Description:	
-- =============================================
/*
EXEC [SCH_INVENTARIO].[SP_SELECT_Articulo] 
*/

CREATE PROCEDURE [SCH_INVENTARIO].[SP_SELECT_Articulo]
	@@IDARTICULO INT


	AS
BEGIN
			DECLARE @IDARTICULO INT


			SET @IDARTICULO = @@IDARTICULO



	SELECT
			NombreArticulo ,
			Descripcion ,
			Servicio ,
			Precio ,
			CantidadStock, 
			CantidadMax,
			CantidadMin,
			IdEstado   
		FROM SCH_INVENTARIO.tbl_Articulos 
	
			
		
			WHERE

				IdArticulo = @IDARTICULO 
	
	END
GO
/****** Object:  StoredProcedure [SCH_INVENTARIO].[SP_SELECT_Motivo]    Script Date: 09/04/2020 3:55:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Josue Azofeifa
-- Create date: 05/04/2020
-- Description:	SELECT Motivos
-- =============================================
/*
EXEC [SCH_INVENTARIO].[SP_SELECT_Motivo] 
*/

CREATE PROCEDURE [SCH_INVENTARIO].[SP_SELECT_Motivo]
	@@IDMOTIVO INT

	AS
BEGIN
			DECLARE @IDMOTIVO INT

			SET @IDMOTIVO = @@IDMOTIVO

		SELECT Descripcion, IdEstado 
			FROM SCH_INVENTARIO.tbl_Motivo
				WHERE IdMotivo = @IDMOTIVO

		END
GO
/****** Object:  StoredProcedure [SCH_INVENTARIO].[SP_SELECT_Movimiento_Detalle]    Script Date: 09/04/2020 3:55:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Josue Azofeifa
-- Create date: 05/04/2020
-- Description:	
-- =============================================
/*
EXEC [SCH_INVENTARIO].[SP_SELECT_Movimiento_Detalle] 
*/

CREATE PROCEDURE [SCH_INVENTARIO].[SP_SELECT_Movimiento_Detalle]
	@@IDDETALLE INT

	AS
BEGIN
			DECLARE @IDDETALLE INT
		
			SET @IDDETALLE = @@IDDETALLE
			


					SELECT 
							IDMovimiento,
							IDARTICULO ,
							IDPedido ,
							Cantidad ,
							MontoTotal ,
							PorcentajeImpuesto ,
							PorcentajeDescuento ,
							CantidadBackorder , 
							IdEstado   
									FROM 
										SCH_INVENTARIO.tbl_MovimientoDetalle
							
								

					WHERE
								IDDetalle = IDDetalle
							
	END
GO
/****** Object:  StoredProcedure [SCH_INVENTARIO].[SP_SELECT_Movimiento_Inventario]    Script Date: 09/04/2020 3:55:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Josue Azofeifa
-- Create date: 05/04/2020
-- Description:	
-- =============================================
/*
EXEC [SCH_INVENTARIO].[SP_SELECT_Movimiento_INVENTARIO] 
*/

CREATE PROCEDURE [SCH_INVENTARIO].[SP_SELECT_Movimiento_Inventario]
	@@IDMOVIMIENTO INT


	AS
BEGIN
			DECLARE @IDMOVIMIENTO INT



			SET @IDMOVIMIENTO = @@IDMOVIMIENTO



	SELECT 			 
			IDProveedor  , 
			IDCliente  , 
			IDSucursalEntrada  , 
			IDSucursalSalida , 
			IDUsuarioAutorizaEntrada  , 
			IDUsuarioAutorizaSalida  , 
			IDTipo  , 
			IDMotivo  ,  
			IdEstado  
				FROM SCH_INVENTARIO.tbl_MovimientoInventario

	

					WHERE 
						IDMovimiento = @IDMOVIMIENTO
		
	END
GO
/****** Object:  StoredProcedure [SCH_INVENTARIO].[SP_SELECT_Proveedor]    Script Date: 09/04/2020 3:55:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Josue Azofeifa
-- Create date: 05/04/2020
-- Description:	
-- =============================================
/*
EXEC [SCH_INVENTARIO].[SP_SELECT_Proveedor] 
*/

CREATE PROCEDURE [SCH_INVENTARIO].[SP_SELECT_Proveedor]
	@@IDPROVEEDOR INT
	
	AS
BEGIN
			DECLARE @IDPROVEEDOR INT



			SET @IDPROVEEDOR = @@IDPROVEEDOR


		SELECT 	IDTIPOIDENTIFICACION ,
				Identificacion  , 
				Nombre  , 
				Apellido  , 
				Apellido2  , 
				RazonSocial  , 
				Email  , 
				Telefono1  , 
				Telefono2  ,  
				IdEstado  
				FROM SCH_INVENTARIO.tbl_proveedor
	
			

				WHERE
					IdProveedor = @IDPROVEEDOR
	END
GO
/****** Object:  StoredProcedure [SCH_MANTENIMIENTO].[sp_ConsultarCajas]    Script Date: 09/04/2020 3:55:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [SCH_MANTENIMIENTO].[sp_ConsultarCajas]

@IdCaja int

AS
BEGIN

SELECT IdCaja,desCaja,IdSucursal,IdEstado
FROM SCH_MANTENIMIENTO.tbl_Cajas
END
GO
/****** Object:  StoredProcedure [SCH_MANTENIMIENTO].[sp_ConsultarDiaSemana]    Script Date: 09/04/2020 3:55:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 CREATE PROCEDURE [SCH_MANTENIMIENTO].[sp_ConsultarDiaSemana]

@IdDia int

AS
BEGIN

SELECT IdDia,Dia 
FROM SCH_MANTENIMIENTO.tbl_DiaSemana
END
GO
/****** Object:  StoredProcedure [SCH_MANTENIMIENTO].[sp_ConsultarEmpresa]    Script Date: 09/04/2020 3:55:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [SCH_MANTENIMIENTO].[sp_ConsultarEmpresa]

@IdEmpresa int

AS
BEGIN

SELECT IdEmpresa,desEmpresa,CedulaJuridica,IdTipoIdentificacion,IdEstado
FROM SCH_MANTENIMIENTO.tbl_Empresa
END
GO
/****** Object:  StoredProcedure [SCH_MANTENIMIENTO].[sp_ConsultarEspecialidad]    Script Date: 09/04/2020 3:55:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [SCH_MANTENIMIENTO].[sp_ConsultarEspecialidad]

@IdEspecialidad int

AS
BEGIN

SELECT IdEspecialidad,desEspecialidad,AgendaCita,IdEstado
FROM SCH_MANTENIMIENTO.tbl_Especialidad
END
GO
/****** Object:  StoredProcedure [SCH_MANTENIMIENTO].[sp_ConsultarEspecialidadUsuario]    Script Date: 09/04/2020 3:55:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [SCH_MANTENIMIENTO].[sp_ConsultarEspecialidadUsuario]

@IdEspecialidadUsuario int

AS
BEGIN

SELECT IdEspecialidadUsuario,desEspecialidadUsuario,IdEspecialidad,IdSucursal,IdEstado 
FROM SCH_MANTENIMIENTO.tbl_EspecialidadUsuario
END
GO
/****** Object:  StoredProcedure [SCH_MANTENIMIENTO].[sp_ConsultarEstado]    Script Date: 09/04/2020 3:55:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [SCH_MANTENIMIENTO].[sp_ConsultarEstado]

@IdEstado int

AS
BEGIN

SELECT [IdEstado],[Descripcion] 
FROM SCH_MANTENIMIENTO.tbl_Estado
END
GO
/****** Object:  StoredProcedure [SCH_MANTENIMIENTO].[sp_ConsultarSucursal]    Script Date: 09/04/2020 3:55:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [SCH_MANTENIMIENTO].[sp_ConsultarSucursal]

@IdSucursal int

AS
BEGIN

SELECT IdSucursal,desSucursal,IdEmpresa,IdEstado,NombreSucursal
FROM SCH_MANTENIMIENTO.tbl_Sucursales
END
GO
/****** Object:  StoredProcedure [SCH_MANTENIMIENTO].[sp_ConsultarTipoIdentificacion]    Script Date: 09/04/2020 3:55:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [SCH_MANTENIMIENTO].[sp_ConsultarTipoIdentificacion]

@TipoIdentificacion int

AS
BEGIN

SELECT IdTipoIdentificacion,TipoIdentificación,CodigoTipoIdentificacion,IdEstado
FROM SCH_MANTENIMIENTO.tbl_TipoIdentificacion
END
GO
/****** Object:  StoredProcedure [SCH_MANTENIMIENTO].[sp_InsertarCajas]    Script Date: 09/04/2020 3:55:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
---CREACION DEL CRUD PARA TBL_CAJAS--------------

CREATE PROCEDURE [SCH_MANTENIMIENTO].[sp_InsertarCajas]

	@@desCaja NVARCHAR(100),
	@@Id_Sucursal INT,
	@@IdEstado INT

	AS
BEGIN
	DECLARE @DESCAJA NVARCHAR(100)
	DECLARE @IDSUCURSAL INT
	DECLARE @IDESTADO INT 

	SET @DESCAJA = @@desCaja
	SET @IDSUCURSAL = @@Id_Sucursal
	SET @IDESTADO= @@IdEstado

INSERT INTO SCH_MANTENIMIENTO.tbl_Cajas 
VALUES( @DESCAJA , @IDSUCURSAL, @IDESTADO )
END
GO
/****** Object:  StoredProcedure [SCH_MANTENIMIENTO].[sp_InsertarDiaSemana]    Script Date: 09/04/2020 3:55:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

---CREACION DEL CRUD PARA TBL_DiaSemana--------------

CREATE PROCEDURE [SCH_MANTENIMIENTO].[sp_InsertarDiaSemana]

 @@Dia NVARCHAR(10)
 AS
 BEGIN 
 
 DECLARE @DIA NVARCHAR(10)
 
 SET @DIA = @@Dia

 INSERT INTO SCH_MANTENIMIENTO.tbl_DiaSemana
 VALUES (@DIA)
 END
GO
/****** Object:  StoredProcedure [SCH_MANTENIMIENTO].[sp_InsertarEmpresa]    Script Date: 09/04/2020 3:55:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [SCH_MANTENIMIENTO].[sp_InsertarEmpresa]

	@@desEmpresa NVARCHAR(100),
	@@CedulaJuridica INT,
	@@IdTipoIdentificacion INT,
	@@IdEstado INT

	AS
BEGIN
	DECLARE @DESEMPRESA NVARCHAR(100)
	DECLARE @CEDULAJURIDICA INT
	DECLARE @IDTIPOIDENTIFICACION INT
	DECLARE @IDESTADO INT 

	SET @DESEMPRESA = @@desEmpresa
	SET @CEDULAJURIDICA = @@CedulaJuridica
	SET @IDTIPOIDENTIFICACION = @@IdTipoIdentificacion
	SET @IDESTADO= @@IdEstado

INSERT INTO SCH_MANTENIMIENTO.tbl_Empresa
VALUES( @DESEMPRESA , @CEDULAJURIDICA , @IDTIPOIDENTIFICACION, @IDESTADO )
END
GO
/****** Object:  StoredProcedure [SCH_MANTENIMIENTO].[sp_InsertarEspecialidad]    Script Date: 09/04/2020 3:55:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

---CREACION DEL CRUD PARA TBL_ESPECIALIDAD-------------
CREATE PROCEDURE [SCH_MANTENIMIENTO].[sp_InsertarEspecialidad]

	@@DesEspecialidad NVARCHAR (100),
	@@AgendaCita BIT,
	@@IdEstado INT
AS
	BEGIN
		DECLARE @DesEspecialidad NVARCHAR (100)
		DECLARE @AgendaCita bit
		DECLARE @IdEstado INT
	
	SET @DesEspecialidad = @@DesEspecialidad
	SET @AgendaCita = @@AgendaCita
	SET @IdEstado = @@IdEstado 

INSERT INTO SCH_MANTENIMIENTO.tbl_Especialidad
VALUES (@DesEspecialidad,@AgendaCita,@IdEstado)
END 
GO
/****** Object:  StoredProcedure [SCH_MANTENIMIENTO].[sp_InsertarEspecialidadUsuario]    Script Date: 09/04/2020 3:55:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

---CREACION DEL CRUD PARA TBL_ESPECIALIDADUSUARIO-------------

CREATE PROCEDURE [SCH_MANTENIMIENTO].[sp_InsertarEspecialidadUsuario]
	@@DesEspecialidad NVARCHAR (100),
	@@IdEspecialidad INT,
	@@IdSucursal INT,
	@@IdEstado INT
AS
	BEGIN
		DECLARE @DesEspecialidad NVARCHAR (100)
		DECLARE @IdEspecialidad INT
		DECLARE @IdSucursal INT
		DECLARE @IdEstado INT

		SET @DesEspecialidad = @@DesEspecialidad
		SET @IdEspecialidad = @@IdEspecialidad
		SET @IdSucursal =@@IdSucursal
		SET @IdEstado =@@IdEstado

INSERT INTO [SCH_MANTENIMIENTO].[tbl_EspecialidadUsuario]
VALUES (@DesEspecialidad,@IdEspecialidad,@IdSucursal,@IdEstado)
END
GO
/****** Object:  StoredProcedure [SCH_MANTENIMIENTO].[sp_InsertarEstados]    Script Date: 09/04/2020 3:55:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
---CREACION DEL CRUD PARA TBL_ESTADOS--------------
CREATE PROCEDURE [SCH_MANTENIMIENTO].[sp_InsertarEstados]

	@@descripcion NVARCHAR(10)
	AS
BEGIN
	DECLARE @DESCRIPCION NVARCHAR(10)

	SET @DESCRIPCION = @@descripcion

INSERT INTO [SCH_MANTENIMIENTO].[tbl_Estado] 
VALUES( @DESCRIPCION )
END

GO
/****** Object:  StoredProcedure [SCH_MANTENIMIENTO].[sp_InsertarSucursales]    Script Date: 09/04/2020 3:55:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

---CREACION DEL CRUD PARA TBL_SUCURSALES-------------
CREATE PROCEDURE [SCH_MANTENIMIENTO].[sp_InsertarSucursales]
	@@desSucursal NVARCHAR (100),
	@@IdEmpresa INT,
	@@IdEstado INT,
	@@NombreSucursal nvarchar (100)

AS
	BEGIN
		DECLARE @desSucursal NVARCHAR (100)
		DECLARE @IdEmpresa INT
		DECLARE @IdEstado INT
		DECLARE @NombreSucursal nvarchar (100)

		SET @desSucursal = @@desSucursal
		SET @IdEmpresa = @@IdEmpresa
		SET @IdEstado = @@IdEstado
		SET @NombreSucursal = @@NombreSucursal

INSERT INTO [SCH_MANTENIMIENTO].[tbl_Sucursales]
VALUES (@desSucursal, @IdEmpresa,@NombreSucursal,@IdEstado)
END
GO
/****** Object:  StoredProcedure [SCH_MANTENIMIENTO].[sp_insertarTipoIdentificacion]    Script Date: 09/04/2020 3:55:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-------------SP  TABLA TIPOIDENTIFICACION--- 

CREATE PROCEDURE [SCH_MANTENIMIENTO].[sp_insertarTipoIdentificacion]
	@@TipoIdentificacion NVARCHAR(100),
	@@CodigoTipoIdentificacion NVARCHAR (5),
	@@IdEstado INT
AS
	BEGIN
		DECLARE @TipoIdentificacion NVARCHAR(100)
		DECLARE @CodigoIdentificacion NVARCHAR (5)
		DECLARE @IdEstado INT

		SET @TipoIdentificacion = @@TipoIdentificacion
		SET @CodigoIdentificacion= @@CodigoTipoIdentificacion
		SET @IdEstado = @@IdEstado

INSERT INTO [SCH_MANTENIMIENTO].[tbl_TipoIdentificacion]
VALUES (@TipoIdentificacion,@CodigoIdentificacion,@IdEstado)
END
GO
/****** Object:  StoredProcedure [SCH_MANTENIMIENTO].[sp_ModificaEstados]    Script Date: 09/04/2020 3:55:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [SCH_MANTENIMIENTO].[sp_ModificaEstados]

	@@IdEstado int,
	@@descripcion NVARCHAR(10)

AS
BEGIN
	Update SCH_MANTENIMIENTO.tbl_Estado
	Set 
		Descripcion = @@descripcion
	Where 
		 IdEstado = @@IdEstado  	 
end
GO
/****** Object:  StoredProcedure [SCH_MANTENIMIENTO].[sp_ModificarCajas]    Script Date: 09/04/2020 3:55:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [SCH_MANTENIMIENTO].[sp_ModificarCajas]

	@@IdCaja int,
	@@desCaja NVARCHAR(100),
	@@IdSucursal int,
	@@IdEstado int

AS
BEGIN
	Update SCH_MANTENIMIENTO.tbl_Cajas
	Set 
		desCaja = @@desCaja,
		IdSucursal = @@IdSucursal,
		IdEstado = @@IdEstado

	Where 
		 IdCaja = @@IdCaja  	 
end
GO
/****** Object:  StoredProcedure [SCH_MANTENIMIENTO].[sp_ModificarDiaSemana]    Script Date: 09/04/2020 3:55:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [SCH_MANTENIMIENTO].[sp_ModificarDiaSemana]

	@@IdDia int,
	@@Dia NVARCHAR(10)


AS
BEGIN
	Update SCH_MANTENIMIENTO.tbl_DiaSemana
	Set 
		
		Dia = @@Dia


	Where 
		 IdDia = IdDia  	 
end
GO
/****** Object:  StoredProcedure [SCH_MANTENIMIENTO].[sp_ModificarEmpresa]    Script Date: 09/04/2020 3:55:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [SCH_MANTENIMIENTO].[sp_ModificarEmpresa]

	@@IdEmpresa int,
	@@desEmpresa NVARCHAR(100),
	@@CedulaJuridica NVARCHAR (100),
	@@IdTipoIdentificacion int,
	@@IdEstado int

AS
BEGIN
	Update SCH_MANTENIMIENTO.tbl_Empresa
	Set 
		desEmpresa = @@desEmpresa,
		CedulaJuridica = @@CedulaJuridica,
		IdTipoIdentificacion = @@IdTipoIdentificacion,
		IdEstado = @@IdEstado

	Where 
		 IdEmpresa = @@IdEmpresa  	 
end
GO
/****** Object:  StoredProcedure [SCH_MANTENIMIENTO].[sp_ModificarEspecialidad]    Script Date: 09/04/2020 3:55:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [SCH_MANTENIMIENTO].[sp_ModificarEspecialidad]

	@@IdEspecialidad int,
	@@desEspecialidad NVARCHAR(100),
	@@AgendaCita Bit,
	@@IdEstado int

AS
BEGIN
	Update SCH_MANTENIMIENTO.tbl_Especialidad
	Set 
		desEspecialidad = @@desEspecialidad,
		AgendaCita = @@AgendaCita,
		IdEstado = @@IdEstado

	Where 
		 IdEspecialidad = @@IdEspecialidad  	 
end
GO
/****** Object:  StoredProcedure [SCH_MANTENIMIENTO].[sp_ModificarEspecialidadUsuario]    Script Date: 09/04/2020 3:55:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [SCH_MANTENIMIENTO].[sp_ModificarEspecialidadUsuario]

	@@IdEspecialidadUsuario int,
	@@desEspecialidadUsuario NVARCHAR(100),
	@@IdEspecialidad int,
	@@IdSucursal int,
	@@IdEstado int

AS
BEGIN
	Update SCH_MANTENIMIENTO.tbl_EspecialidadUsuario
	Set 
		desEspecialidadUsuario = @@desEspecialidadUsuario,
		IdEspecialidad = @@IdEspecialidad,
		IdSucursal = @@IdSucursal,
		IdEstado = @@IdEstado

	Where 
		 IdEspecialidadUsuario = @@IdEspecialidadUsuario 	 
end
GO
/****** Object:  StoredProcedure [SCH_MANTENIMIENTO].[sp_ModificarEstados]    Script Date: 09/04/2020 3:55:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [SCH_MANTENIMIENTO].[sp_ModificarEstados]

	@@IdEstado int,
	@@descripcion NVARCHAR(10)

AS
BEGIN
	Update SCH_MANTENIMIENTO.tbl_Estado
	Set 
		Descripcion = @@descripcion
	Where 
		 IdEstado = @@IdEstado  	 
end
GO
/****** Object:  StoredProcedure [SCH_MANTENIMIENTO].[sp_ModificarSucursal]    Script Date: 09/04/2020 3:55:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [SCH_MANTENIMIENTO].[sp_ModificarSucursal]

	@@IdSucursal int,
	@@desSucursal NVARCHAR(100),
	@@IdEmpresa int,
	@@IdEstado int,
	@@NombreSucursal nvarchar (100)

AS
BEGIN
	Update SCH_MANTENIMIENTO.tbl_Sucursales
	Set 
		desSucursal = @@desSucursal,
		IdEmpresa = @@IdEmpresa,
		IdEstado = @@IdEstado,
		NombreSucursal = @@NombreSucursal

	Where 
		 IdSucursal = @@IdSucursal  	 
end
GO
/****** Object:  StoredProcedure [SCH_MANTENIMIENTO].[sp_ModificarTipoIdentificacion]    Script Date: 09/04/2020 3:55:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [SCH_MANTENIMIENTO].[sp_ModificarTipoIdentificacion]

	@@IdTipoIdentificacion int,
	@@TipoIdentificacion NVARCHAR(50),
	@@CodigoTipoIdentificacion nvarchar (5),
	@@IdEstado int


AS
BEGIN
	Update SCH_MANTENIMIENTO.tbl_TipoIdentificacion
	Set 
		TipoIdentificación = @@TipoIdentificacion,
		CodigoTipoIdentificacion = @@CodigoTipoIdentificacion,
		IdEstado = @@IdEstado

	Where 
		 IdTipoIdentificacion = @@IdTipoIdentificacion  	 
end
GO
/****** Object:  StoredProcedure [SCH_NOMINA].[sp_ConsultarDiaLibre]    Script Date: 09/04/2020 3:55:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [SCH_NOMINA].[sp_ConsultarDiaLibre]
(
	@IdDiaLibre int
)
as
begin

	Select IdDiaLibre,IdHorario,IdDia,IdEstado
	From SCH_NOMINA.tbl_DiasLibres
	ORDER BY IdDiaLibre
end 
GO
/****** Object:  StoredProcedure [SCH_NOMINA].[sp_ConsultarHorario]    Script Date: 09/04/2020 3:55:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [SCH_NOMINA].[sp_ConsultarHorario]
(
	@IdHorario int
)
as
begin

	Select IdHorario,IdUsuario,HoraEntrada,HoraSalida,IdEstado
	From SCH_NOMINA.tbl_Horarios
	ORDER BY IdUsuario
end 
GO
/****** Object:  StoredProcedure [SCH_NOMINA].[sp_ConsultarMarca]    Script Date: 09/04/2020 3:55:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [SCH_NOMINA].[sp_ConsultarMarca]
(
	@IdMarca int
)
as
begin

	Select IdMarca,IdUsuario,Registro,IdTipoMarca,IdEstado
	From SCH_NOMINA.tbl_Marcas
	ORDER BY IdUsuario
end 
GO
/****** Object:  StoredProcedure [SCH_NOMINA].[sp_ConsultarPermiso]    Script Date: 09/04/2020 3:55:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [SCH_NOMINA].[sp_ConsultarPermiso]
(
	@IdPermiso int
)
as
begin

	Select IdPermiso,IdUsuario,IdTipoPermiso,Inicio,Fin,Observacion,IdEstado
	From SCH_NOMINA.tbl_Permisos
	ORDER BY IdPermiso
end 
GO
/****** Object:  StoredProcedure [SCH_NOMINA].[sp_ConsultarTipoMarca]    Script Date: 09/04/2020 3:55:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [SCH_NOMINA].[sp_ConsultarTipoMarca]
(
	@IdTipoMarca int
)
as
begin

	Select IdTipoMarca,TipoMarca,Estado
	From SCH_NOMINA.tbl_TiposMarca
	ORDER BY IdTipoMarca
end 
GO
/****** Object:  StoredProcedure [SCH_NOMINA].[sp_ConsultarTipoPermiso]    Script Date: 09/04/2020 3:55:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [SCH_NOMINA].[sp_ConsultarTipoPermiso]
(
	@IdTipoPermiso int
)
as
begin

	Select IdTipoPermiso,TipoPermiso,IdEstado
	From SCH_NOMINA.tbl_TiposPermiso
	ORDER BY IdTipoPermiso
end 
GO
/****** Object:  StoredProcedure [SCH_NOMINA].[sp_ConsultarUsuario]    Script Date: 09/04/2020 3:55:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [SCH_NOMINA].[sp_ConsultarUsuario]
(
	@Id_Usuario int
)
as
begin

	Select Id_Usuario,Identificacion,Nombre,PrimerApellido,SegundoApellido,Email,IdSucursal,IdEstado
	From SCH_NOMINA.tbl_Usuarios
	ORDER BY Id_Usuario
end 
GO
/****** Object:  StoredProcedure [SCH_NOMINA].[sp_InsertarDiasLibre]    Script Date: 09/04/2020 3:55:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [SCH_NOMINA].[sp_InsertarDiasLibre]
@IdDiaLibre int,
@IdHorario int, 
@IdDia int,
@IdEstado int

as
Begin
		Declare @V_IdDiaLibre int 
		Declare @V_IdHorario int 
		Declare @V_IdDia int 
		Declare @V_IdEstado int

		set @V_IdDiaLibre = @IdDiaLibre
		set @V_IdHorario = @IdHorario
		set @V_IdDia = @IdDia
		set @V_IdEstado = @IdEstado

	insert into SCH_NOMINA.tbl_DiasLibres
	values (@V_IdDiaLibre,@V_IdHorario,@V_IdDia,@V_IdEstado)
End
GO
/****** Object:  StoredProcedure [SCH_NOMINA].[sp_InsertarHorarios]    Script Date: 09/04/2020 3:55:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [SCH_NOMINA].[sp_InsertarHorarios]
@IdHorario int,
@IdUsuario int,
@HoraEntrada time,
@HoraSalida time,
@IdEstado int
as
Begin
		Declare @V_IdHorario int
		Declare @V_IdUsuario int
		Declare @V_HoraEntrada time
		Declare @V_HoraSalida time
		Declare @V_IdEstado int 

		set @V_IdHorario = @IdHorario
		set @V_IdUsuario = @IdUsuario
		set @V_HoraEntrada = @HoraEntrada
		set @V_HoraSalida = @HoraSalida
		set @V_IdEstado = @IdEstado


	insert into SCH_NOMINA.tbl_Horarios
	values (@V_IdHorario,@V_IdUsuario,@V_HoraEntrada,@V_HoraSalida,@V_IdEstado)
End
GO
/****** Object:  StoredProcedure [SCH_NOMINA].[sp_InsertarMarca]    Script Date: 09/04/2020 3:55:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [SCH_NOMINA].[sp_InsertarMarca]
@IdMarca int,
@IdUsuario int,
@Registro datetime,
@IdTipoMarca int,
@IdEstado int
as
Begin
		Declare @V_IdMarca int
		Declare @V_IdUsuario int
		Declare @V_Registro datetime
		Declare @V_IdTipoMarca int
		Declare @V_IdEstado int

		set @V_IdMarca = @IdMarca
		set @V_IdUsuario = @IdUsuario
		set @V_Registro = @Registro
		set @V_IdTipoMarca = @IdTipoMarca
		set @V_IdEstado = @IdEstado

	insert into SCH_NOMINA.tbl_Marcas
	values (@V_IdMarca,@V_IdUsuario,@V_Registro,@V_IdTipoMarca,@V_IdEstado)
End
GO
/****** Object:  StoredProcedure [SCH_NOMINA].[sp_InsertarPermiso]    Script Date: 09/04/2020 3:55:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [SCH_NOMINA].[sp_InsertarPermiso]
@IdPermiso int,
@IdUsuario int,
@IdTipoPermiso int,
@Inicio datetime,
@Fin datetime,
@Observacion nvarchar (500),
@IdEstado int
as
Begin
		Declare @V_IdPermiso int = @IdPermiso
		Declare @V_IdUsuario int = @IdUsuario
		Declare @V_IdTipoPermiso int = @IdTipoPermiso
		Declare @V_Inicio datetime = @Inicio
		Declare @V_Fin datetime = @Fin
		Declare @V_Observacion nvarchar(500) = @Observacion
		Declare @V_IdEstado int = @IdEstado

	insert into SCH_NOMINA.tbl_Permisos
	values (@V_IdPermiso,@V_IdUsuario,@V_IdTipoPermiso,@V_Inicio,@V_Fin,@V_Observacion,@V_IdEstado)
End
GO
/****** Object:  StoredProcedure [SCH_NOMINA].[sp_InsertarTipoMarca]    Script Date: 09/04/2020 3:55:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [SCH_NOMINA].[sp_InsertarTipoMarca]
@IdTipoMarca int, 
@TipoMarca nvarchar (50),
@IdEstado int
as
Begin
		Declare @V_IdTipoMarca int = @IdTipoMarca
		Declare @V_TipoMarca nvarchar(50) = @TipoMarca
		Declare @V_IdEstado int = @IdEstado

	insert into SCH_NOMINA.tbl_TiposMarca
	values (@V_IdTipoMarca,@V_TipoMarca,@V_IdEstado)
End
GO
/****** Object:  StoredProcedure [SCH_NOMINA].[sp_InsertarTipoPermiso]    Script Date: 09/04/2020 3:55:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [SCH_NOMINA].[sp_InsertarTipoPermiso]
@IdTipoPermiso int, 
@TipoPermiso nvarchar (50),
@IdEstado int
as
Begin
		Declare @V_IdTipoPermiso int = @IdTipoPermiso
		Declare @V_TipoPermiso nvarchar(50) = @TipoPermiso
		Declare @V_IdEstado int = @IdEstado

	insert into SCH_NOMINA.tbl_TiposPermiso
	values (@V_IdTipoPermiso,@V_TipoPermiso,@V_IdEstado)
End
GO
/****** Object:  StoredProcedure [SCH_NOMINA].[sp_InsertarUsuario]    Script Date: 09/04/2020 3:55:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [SCH_NOMINA].[sp_InsertarUsuario]
@Id_Usuario int, 
@Identificacion nvarchar(50),
@Nombre nvarchar(50),
@PrimerApellido nvarchar (50),
@SegundoApellido nvarchar (50),
@email nvarchar(100),
@Telefono1 nvarchar (20),
@Telefono2 nvarchar (20),
@IdSucursal int,
@IdEstado int
as
Begin
		Declare @V_Id_Usuario int = @Id_Usuario
		Declare @V_Identificacion nvarchar (50) = @Identificacion
		Declare @V_Nombre nvarchar(50) = @Nombre
		Declare @V_PrimerApellido nvarchar (50) = @PrimerApellido
		Declare @V_SegundoApellido nvarchar (50) = @SegundoApellido
		Declare @V_Email nvarchar (100) = @email
		Declare @V_Telefono1 nvarchar (20) = @Telefono1
		Declare @V_Telefono2 nvarchar (20) = @Telefono2
		Declare @V_IdSucursal int = @IdSucursal
		Declare @V_IdEstado int = @IdEstado

	insert into SCH_NOMINA.tbl_Usuarios
	values (@V_Id_Usuario,@V_Identificacion,@V_Nombre,@V_PrimerApellido,@V_SegundoApellido,@V_email,@V_Telefono1,@V_Telefono2,@V_IdSucursal,@V_IdEstado)
End
GO
/****** Object:  StoredProcedure [SCH_NOMINA].[sp_ModificarDiaLibre]    Script Date: 09/04/2020 3:55:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [SCH_NOMINA].[sp_ModificarDiaLibre]

@IdDiaLibre int,
@IdHorario int,
@IdDia int,
@IdEstado int
as
begin
	Update SCH_NOMINA.tbl_DiasLibres
	Set 
		IdDiaLibre   = @IdHorario,
		IdDia		 = @IdDia,
		IdEstado     = @IdEstado
	Where 
		 IdDiaLibre = @IdDiaLibre  	 
end
GO
/****** Object:  StoredProcedure [SCH_NOMINA].[sp_ModificarHorario]    Script Date: 09/04/2020 3:55:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [SCH_NOMINA].[sp_ModificarHorario]
@IdHorario int,
@IdUsuario int,
@HoraEntrada time,
@HoraSalida time,
@IdEstado int

as
begin
	Update SCH_NOMINA.tbl_Horarios
	Set 
		HoraEntrada   = @HoraEntrada,
		HoraSalida	= @HoraSalida,
		IdEstado    = @IdEstado
	Where 
		 IdHorario = @IdHorario  	 
end
GO
/****** Object:  StoredProcedure [SCH_NOMINA].[sp_ModificarMarca]    Script Date: 09/04/2020 3:55:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [SCH_NOMINA].[sp_ModificarMarca]
@IdMarca int,
@IdUsuario int,
@Registro datetime,
@IdTipoMarca int,
@IdEstado int
as
begin
	Update SCH_NOMINA.tbl_Marcas
	Set 
		IdMarca   = @IdMarca,
		IdUsuario = @IdUsuario,
		Registro  = @Registro,
		IdTipoMarca = @IdTipoMarca,
		IdEstado = IdEstado
	Where 
		 IdMarca = @IdMarca  	 
end
GO
/****** Object:  StoredProcedure [SCH_NOMINA].[sp_ModificarPermiso]    Script Date: 09/04/2020 3:55:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [SCH_NOMINA].[sp_ModificarPermiso]
@IdPermiso int,
@IdUsuario int,
@IdTipoPermiso int,
@Inicio datetime,
@Fin datetime,
@Observacion nvarchar(500),
@IdEstado int
as
begin
	Update SCH_NOMINA.tbl_Permisos
	Set 
		IdUsuario = @IdUsuario,
		IdTipoPermiso = @IdTipoPermiso,
		Inicio   = @Inicio, 
		Fin  = @Fin,
		Observacion   = @Observacion,
		IdEstado    = @IdEstado
	Where 
		 IdPermiso = @IdPermiso  	 
end
GO
/****** Object:  StoredProcedure [SCH_NOMINA].[sp_ModificarTipoMarca]    Script Date: 09/04/2020 3:55:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [SCH_NOMINA].[sp_ModificarTipoMarca]
@IdTipoMarca int,
@TipoMarca nvarchar(50),
@Estado int
as
begin
	Update SCH_NOMINA.tbl_TiposMarca
	Set 
		TipoMarca   = @TipoMarca, 
		Estado    = @Estado
	Where 
		 IdTipoMarca = @IdTipoMarca 
end
GO
/****** Object:  StoredProcedure [SCH_NOMINA].[sp_ModificarTipoPermiso]    Script Date: 09/04/2020 3:55:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [SCH_NOMINA].[sp_ModificarTipoPermiso]
@IdTipoPermiso int,
@TipoPermiso nvarchar(50),
@IdEstado int
as
begin
	Update SCH_NOMINA.tbl_TiposPermiso
	Set 
		TipoPermiso   = @TipoPermiso, 
		IdEstado    = @IdEstado
	Where 
		 IdTipoPermiso = @IdTipoPermiso 
end
GO
/****** Object:  StoredProcedure [SCH_NOMINA].[sp_ModificarUsuario]    Script Date: 09/04/2020 3:55:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [SCH_NOMINA].[sp_ModificarUsuario]
@Id_Usuario int, 
@Identificacion nvarchar(50),
@Nombre nvarchar(50),
@PrimerApellido nvarchar (50),
@SegundoApellido nvarchar (50),
@email nvarchar(100),
@Telefono1 nvarchar (20),
@Telefono2 nvarchar (20),
@IdSucursal int,
@IdEstado int
as
begin
	Update SCH_NOMINA.tbl_Usuarios
	Set 
		Identificacion   = @Identificacion, 
		Nombre  = @Nombre,
		PrimerApellido   = @PrimerApellido,
		SegundoApellido  = @SegundoApellido,
		Email   = @Email,
		Telefono1  = @Telefono1,
		Telefono2   = @Telefono2,
		IdSucursal  = @IdSucursal,
		IdEstado    = @IdEstado
	Where 
		 Id_Usuario = @Id_Usuario  	 
end
GO
/****** Object:  StoredProcedure [SCH_SEGURIDAD].[SP_Inserta_MODULOS]    Script Date: 09/04/2020 3:55:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Josue Azofeifa
-- Create date: 05/04/2020
-- Description:	INSERTA MODULOS
-- =============================================
/*
EXEC[SCH_SEGURIDAD].[SP_Inserta_MODULOS] 
*/

CREATE PROCEDURE [SCH_SEGURIDAD].[SP_Inserta_MODULOS]

	@@NOMBRE VARCHAR(50),
	@@ID_ESTADO INT

	AS
BEGIN
			DECLARE @NOMBRE VARCHAR(50)
			DECLARE @IDESTADO INT


			SET @NOMBRE = @@NOMBRE
			SET @IDESTADO = @@ID_ESTADO


		Insert into SCH_SEGURIDAD.tbl_Modulos 
		values ( @NOMBRE , @IDESTADO )
		END
GO
/****** Object:  StoredProcedure [SCH_SEGURIDAD].[SP_Inserta_PERMISOSSEGURIDAD]    Script Date: 09/04/2020 3:55:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Josue Azofeifa
-- Create date: 07/04/2020
-- Description:	INSERTA PERMISOSSEGURIDAD
-- =============================================
/*
EXEC[SCH_SEGURIDAD].[SP_Inserta_PERMISOSSEGURIDAD]
*/

CREATE PROCEDURE [SCH_SEGURIDAD].[SP_Inserta_PERMISOSSEGURIDAD]

	@@IDTIPOPERFIL INT,
	@@IDSUBMODULO INT,
	@@INSERTAR BIT,
	@@MODIFICAR BIT,
	@@ELIMINAR BIT,
	@@ID_ESTADO INT

	AS
BEGIN
			DECLARE @IDTIPOPERFIL INT
			DECLARE @IDSUBMODULO INT
			DECLARE @INSERTAR BIT
			DECLARE @MODIFICAR BIT
			DECLARE @ELIMINAR BIT
			DECLARE @IDESTADO INT


			SET @IDTIPOPERFIL = @@IDTIPOPERFIL
			SET @IDSUBMODULO = @@IDSUBMODULO
			SET @INSERTAR = @@INSERTAR
			SET @MODIFICAR = @@MODIFICAR
			SET @ELIMINAR = @@ELIMINAR
			SET @IDESTADO = @@ID_ESTADO


		Insert into SCH_SEGURIDAD.tbl_PERMISOSSEGURIDAD
		values ( @IDTIPOPERFIL , @IDSUBMODULO , @INSERTAR , @MODIFICAR , @ELIMINAR , @IDESTADO )
		END
GO
/****** Object:  StoredProcedure [SCH_SEGURIDAD].[SP_Inserta_SUBMODULOS]    Script Date: 09/04/2020 3:55:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Josue Azofeifa
-- Create date: 07/04/2020
-- Description:	INSERTA SUBMODULOS
-- =============================================
/*
EXEC[SCH_SEGURIDAD].[SP_Inserta_SUBMODULOS] 
*/

CREATE PROCEDURE [SCH_SEGURIDAD].[SP_Inserta_SUBMODULOS]

	@@IDTIPOPERFIL INT,
	@@IDMODULOS INT,
	@@NOMBRE VARCHAR(50),
	@@ID_ESTADO INT

	AS
BEGIN
			DECLARE @IDTIPOPERFIL INT
			DECLARE  @IDMODULOS INT
			DECLARE @NOMBRE VARCHAR(50)
			DECLARE @IDESTADO INT


			SET @IDTIPOPERFIL = @@IDTIPOPERFIL
			SET @IDMODULOS = @@IDMODULOS
			SET @NOMBRE = @@NOMBRE
			SET @IDESTADO = @@ID_ESTADO


		Insert into SCH_SEGURIDAD.tbl_SubModulos 
		values ( @IDTIPOPERFIL , @IDMODULOS , @NOMBRE , @IDESTADO )
		END
GO
/****** Object:  StoredProcedure [SCH_SEGURIDAD].[SP_Inserta_TIPOSPERFIL]    Script Date: 09/04/2020 3:55:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [SCH_SEGURIDAD].[SP_Inserta_TIPOSPERFIL]

	@@TIPOPERFIL VARCHAR(50),
	@@IDSUCURSAL INT,
	@@IDESPECIALIDAD INT,
	@@ID_ESTADO INT

	AS
BEGIN
			DECLARE @TIPOPERFIL VARCHAR(50)
			DECLARE @IDSUCURSAL INT
			DECLARE @IDESPECIALIDAD INT
			DECLARE @IDESTADO INT


			SET @TIPOPERFIL = @@TIPOPERFIL
			SET @IDSUCURSAL = @@IDSUCURSAL
			SET @IDESPECIALIDAD = @@IDESPECIALIDAD
			SET @IDESTADO = @@ID_ESTADO


		Insert into SCH_SEGURIDAD.tbl_TiposPerfil 
		values ( @TIPOPERFIL , @IDSUCURSAL , @IDESPECIALIDAD , @IDESTADO )
		END
GO
/****** Object:  StoredProcedure [SCH_SEGURIDAD].[SP_Inserta_USUARIOSSEGURIDAD]    Script Date: 09/04/2020 3:55:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Josue Azofeifa
-- Create date: 07/04/2020
-- Description:	INSERTA USUARIOSSEGURIDAD
-- =============================================
/*
EXEC[SCH_SEGURIDAD].[SP_Inserta_USUARIOSSEGURIDAD]
*/

CREATE PROCEDURE [SCH_SEGURIDAD].[SP_Inserta_USUARIOSSEGURIDAD]

	@@IDTIPOPERFIL INT,
	@@NOMBREUSUARIO VARCHAR (20),
	@@CONTRASENNA VARCHAR (20),
	@@ID_ESTADO INT

	AS
BEGIN
			DECLARE @IDTIPOPERFIL INT
			DECLARE @NOMBREUSUARIO VARCHAR (20)
			DECLARE @CONTRASENNA VARCHAR (20)
			DECLARE @IDESTADO INT


			SET @IDTIPOPERFIL = @@IDTIPOPERFIL
			SET @NOMBREUSUARIO = @@NOMBREUSUARIO
			SET @CONTRASENNA = @@CONTRASENNA
			SET @IDESTADO = @@ID_ESTADO


		Insert into SCH_SEGURIDAD.tbl_UsuariosSeguridad
		values ( @IDTIPOPERFIL , @NOMBREUSUARIO , @CONTRASENNA , @IDESTADO )
		END
GO
/****** Object:  StoredProcedure [SCH_SEGURIDAD].[SP_Modifica_MODULOS]    Script Date: 09/04/2020 3:55:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Josue Azofeifa
-- Create date: 05/04/2020
-- Description:	UPDATE MODULOS
-- =============================================
/*
EXEC[SCH_SEGURIDAD].[SP_MODIFICA_MODULOS] 
*/

CREATE PROCEDURE [SCH_SEGURIDAD].[SP_Modifica_MODULOS]
	@@IDMODULO INT,
	@@NOMBRE VARCHAR(50),
	@@ID_ESTADO INT

	AS
BEGIN
			DECLARE @IDMODULO INT
			DECLARE @NOMBRE VARCHAR(50)
			DECLARE @IDESTADO INT


			SET @IDMODULO = @@IDMODULO
			SET @NOMBRE = @@NOMBRE
			SET @IDESTADO = @@ID_ESTADO


		UPDATE SCH_SEGURIDAD.tbl_Modulos 
			SET 
				Nombre = @NOMBRE , 
				IdEstado = @IDESTADO 

			WHERE 
				IdModulo = @IDMODULO
		END
GO
/****** Object:  StoredProcedure [SCH_SEGURIDAD].[SP_Modifica_PERMISOSSEGURIDAD]    Script Date: 09/04/2020 3:55:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Josue Azofeifa
-- Create date: 07/04/2020
-- Description:	MODIFICA PERMISOSSEGURIDAD
-- =============================================
/*
EXEC[SCH_SEGURIDAD].[SP_Modifica_PERMISOSSEGURIDAD]
*/

CREATE PROCEDURE [SCH_SEGURIDAD].[SP_Modifica_PERMISOSSEGURIDAD]
	@@IDPERMISOSEGURIDAD INT,
	@@IDTIPOPERFIL INT,
	@@IDSUBMODULO INT,
	@@INSERTAR BIT,
	@@MODIFICAR BIT,
	@@ELIMINAR BIT,
	@@ID_ESTADO INT

	AS
BEGIN
			DECLARE @IDPERMISOSEGURIDAD INT
			DECLARE @IDTIPOPERFIL INT
			DECLARE @IDSUBMODULO INT
			DECLARE @INSERTAR BIT
			DECLARE @MODIFICAR BIT
			DECLARE @ELIMINAR BIT
			DECLARE @IDESTADO INT


			SET @IDPERMISOSEGURIDAD = @@IDPERMISOSEGURIDAD
			SET @IDTIPOPERFIL = @@IDTIPOPERFIL
			SET @IDSUBMODULO = @@IDSUBMODULO
			SET @INSERTAR = @@INSERTAR
			SET @MODIFICAR = @@MODIFICAR
			SET @ELIMINAR = @@ELIMINAR
			SET @IDESTADO = @@ID_ESTADO


		UPDATE SCH_SEGURIDAD.tbl_PERMISOSSEGURIDAD
		SET		
				IdTipoPerfil = @IDTIPOPERFIL , 
				IdSubModulo = @IDSUBMODULO ,
				Insertar = @INSERTAR , 
				Modificar = @MODIFICAR , 
				Eliminar = @ELIMINAR , 
				IdEstado = @IDESTADO 

		WHERE 
				IdPermisoSeguridad = @IDPERMISOSEGURIDAD

		END
GO
/****** Object:  StoredProcedure [SCH_SEGURIDAD].[SP_MODIFICA_SUBMODULOS]    Script Date: 09/04/2020 3:55:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Josue Azofeifa
-- Create date: 07/04/2020
-- Description:	MODIFICA SUBMODULOS
-- =============================================
/*
EXEC[SCH_SEGURIDAD].[SP_MODIFICA_SUBMODULOS] 
*/

CREATE PROCEDURE [SCH_SEGURIDAD].[SP_MODIFICA_SUBMODULOS]
	@@IDSUBMODULO INT,
	@@IDTIPOPERFIL INT,
	@@IDMODULOS INT,
	@@NOMBRE VARCHAR(50),
	@@ID_ESTADO INT

	AS
BEGIN
			DECLARE @IDSUBMODULO INT
			DECLARE @IDTIPOPERFIL INT
			DECLARE  @IDMODULOS INT
			DECLARE @NOMBRE VARCHAR(50)
			DECLARE @IDESTADO INT

			
			SET @IDSUBMODULO = @@IDSUBMODULO
			SET @IDTIPOPERFIL = @@IDTIPOPERFIL
			SET @IDMODULOS = @@IDMODULOS
			SET @NOMBRE = @@NOMBRE
			SET @IDESTADO = @@ID_ESTADO


		UPDATE SCH_SEGURIDAD.tbl_SubModulos 
		SET  
		IdTipoPerfil = @IDTIPOPERFIL , 
		IdModulos = @IDMODULOS , 
		Nombre = @NOMBRE , 
		IdEstado = @IDESTADO 
		WHERE 
		IdSubModulo = @IDSUBMODULO
		END
GO
/****** Object:  StoredProcedure [SCH_SEGURIDAD].[SP_MODIFICA_TIPOSPERFIL]    Script Date: 09/04/2020 3:55:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Josue Azofeifa
-- Create date: 07/04/2020
-- Description:	mODIFICA TIPOSPERFIL
-- =============================================
/*
EXEC[SCH_SEGURIDAD].[SP_Inserta_TIPOSPERFIL] 
*/

CREATE PROCEDURE [SCH_SEGURIDAD].[SP_MODIFICA_TIPOSPERFIL]
	@@IDTIPOPERFIL INT,
	@@TIPOPERFIL VARCHAR(50),
	@@IDSUCURSAL INT,
	@@IDESPECIALIDAD INT,
	@@ID_ESTADO INT

	AS
BEGIN
			DECLARE @IDTIPOPERFIL INT
			DECLARE @TIPOPERFIL VARCHAR(50)
			DECLARE @IDSUCURSAL INT
			DECLARE @IDESPECIALIDAD INT
			DECLARE @IDESTADO INT


			SET @IDTIPOPERFIL = @@IDTIPOPERFIL
			SET @TIPOPERFIL = @@TIPOPERFIL
			SET @IDSUCURSAL = @@IDSUCURSAL
			SET @IDESPECIALIDAD = @@IDESPECIALIDAD
			SET @IDESTADO = @@ID_ESTADO


	UPDATE SCH_SEGURIDAD.tbl_TiposPerfil 
		SET  
			TipoPerfil = @TIPOPERFIL , 
			IdSucursal = @IDSUCURSAL , 
			IdEspecialidad = @IDESPECIALIDAD , 
			IdEstado = @IDESTADO 

				WHERE

				IdTipoPerfil = @IDTIPOPERFIL

END
GO
/****** Object:  StoredProcedure [SCH_SEGURIDAD].[SP_MODIFICA_USUARIOSSEGURIDAD]    Script Date: 09/04/2020 3:55:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Josue Azofeifa
-- Create date: 07/04/2020
-- Description:	MODIFICA USUARIOSSEGURIDAD
-- =============================================
/*
EXEC[SCH_SEGURIDAD].[SP_MODIFICA_USUARIOSSEGURIDAD]
*/

CREATE PROCEDURE [SCH_SEGURIDAD].[SP_MODIFICA_USUARIOSSEGURIDAD]
	@@IDUSUARIOSEGURIDAD INT,
	@@IDTIPOPERFIL INT,
	@@NOMBREUSUARIO VARCHAR (20),
	@@CONTRASENNA VARCHAR (20),
	@@ID_ESTADO INT

	AS
BEGIN
			DECLARE @IDUSUARIOSEGURIDAD INT
			DECLARE @IDTIPOPERFIL INT
			DECLARE @NOMBREUSUARIO VARCHAR (20)
			DECLARE @CONTRASENNA VARCHAR (20)
			DECLARE @IDESTADO INT


			SET @IDUSUARIOSEGURIDAD = @@IDUSUARIOSEGURIDAD
			SET @IDTIPOPERFIL = @@IDTIPOPERFIL
			SET @NOMBREUSUARIO = @@NOMBREUSUARIO
			SET @CONTRASENNA = @@CONTRASENNA
			SET @IDESTADO = @@ID_ESTADO


		UPDATE SCH_SEGURIDAD.tbl_UsuariosSeguridad
		SET 
		 IdTipoPerfil = @IDTIPOPERFIL , 
		 NombreUsuario = @NOMBREUSUARIO , 
		 Contrasenna = @CONTRASENNA , 
		 IdEstado = @IDESTADO 

		 WHERE 

		 IdUsuarioSeguridad = @IDUSUARIOSEGURIDAD

		END
GO
/****** Object:  StoredProcedure [SCH_SEGURIDAD].[SP_Select_MODULOS]    Script Date: 09/04/2020 3:55:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Josue Azofeifa
-- Create date: 05/04/2020
-- Description:	SELECT MODULOS
-- =============================================
/*
EXEC[SCH_SEGURIDAD].[SP_MODIFICA_MODULOS] 
*/

CREATE PROCEDURE [SCH_SEGURIDAD].[SP_Select_MODULOS]
	@@IDMODULO INT

	AS
BEGIN
			DECLARE @IDMODULO INT


			SET @IDMODULO = @@IDMODULO

		SELECT IDMODULO, NOMBRE, IDESTADO FROM [SCH_SEGURIDAD].[tbl_Modulos]
		WHERE IdModulo = @IDMODULO
		END
GO
/****** Object:  StoredProcedure [SCH_SEGURIDAD].[SP_SELECT_PERMISOSSEGURIDAD]    Script Date: 09/04/2020 3:55:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Josue Azofeifa
-- Create date: 07/04/2020
-- Description:	SELECT PERMISOSSEGURIDAD
-- =============================================
/*
EXEC[SCH_SEGURIDAD].[SP_SELECT_PERMISOSSEGURIDAD]
*/

CREATE PROCEDURE [SCH_SEGURIDAD].[SP_SELECT_PERMISOSSEGURIDAD]
	@@IDPERMISOSEGURIDAD INT

	AS
BEGIN
			DECLARE @IDPERMISOSEGURIDAD INT

			SET @IDPERMISOSEGURIDAD = @@IDPERMISOSEGURIDAD


		SELECT IdTipoPerfil, IdSubModulo, Insertar, Modificar, Eliminar, IdEstado  FROM SCH_SEGURIDAD.tbl_PERMISOSSEGURIDAD	
		
		WHERE 
				IdPermisoSeguridad = @IDPERMISOSEGURIDAD

		END
GO
/****** Object:  StoredProcedure [SCH_SEGURIDAD].[SP_SELECT_SUBMODULOS]    Script Date: 09/04/2020 3:55:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Josue Azofeifa
-- Create date: 07/04/2020
-- Description:	SELECT SUBMODULOS
-- =============================================
/*
EXEC[SCH_SEGURIDAD].[SP_SELECT_SUBMODULOS] 
*/

CREATE PROCEDURE [SCH_SEGURIDAD].[SP_SELECT_SUBMODULOS]
	@@IDSUBMODULO INT

	AS
BEGIN
			DECLARE @IDSUBMODULO INT


			
			SET @IDSUBMODULO = @@IDSUBMODULO



		SELECT IdTipoPerfil,IdModulos,Nombre,IdEstado FROM  SCH_SEGURIDAD.tbl_SubModulos 

		WHERE 
		IdSubModulo = @IDSUBMODULO
		END
GO
/****** Object:  StoredProcedure [SCH_SEGURIDAD].[SP_SELECT_TIPOSPERFIL]    Script Date: 09/04/2020 3:55:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Josue Azofeifa
-- Create date: 07/04/2020
-- Description:	SELECT TIPOSPERFIL
-- =============================================
/*
EXEC[SCH_SEGURIDAD].[SP_SELECT_TIPOSPERFIL] 
*/

CREATE PROCEDURE [SCH_SEGURIDAD].[SP_SELECT_TIPOSPERFIL]
	@@IDTIPOPERFIL INT

	AS
BEGIN
			DECLARE @IDTIPOPERFIL INT



			SET @IDTIPOPERFIL = @@IDTIPOPERFIL


SELECT TipoPerfil, IdSucursal, IdEspecialidad, IdEstado 
	FROM  SCH_SEGURIDAD.tbl_TiposPerfil 


		WHERE

			IdTipoPerfil = @IDTIPOPERFIL

END
GO
/****** Object:  StoredProcedure [SCH_SEGURIDAD].[SP_SELECT_USUARIOSSEGURIDAD]    Script Date: 09/04/2020 3:55:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Josue Azofeifa
-- Create date: 07/04/2020
-- Description:	SELECT USUARIOSSEGURIDAD
-- =============================================
/*
EXEC[SCH_SEGURIDAD].[SP_SELECT_USUARIOSSEGURIDAD]
*/

CREATE PROCEDURE [SCH_SEGURIDAD].[SP_SELECT_USUARIOSSEGURIDAD]
	
	@@IDUSUARIOSEGURIDAD INT

	AS
BEGIN
			DECLARE @IDUSUARIOSEGURIDAD INT

			SET @IDUSUARIOSEGURIDAD = @@IDUSUARIOSEGURIDAD




		SELECT IdTipoPerfil ,NombreUsuario, Contrasenna, IdEstado  
		
		FROM SCH_SEGURIDAD.tbl_UsuariosSeguridad

		 WHERE 

		 IdUsuarioSeguridad = @IDUSUARIOSEGURIDAD

	END
GO
/****** Object:  StoredProcedure [SCH_VENTAS].[sp_ConsultarCita]    Script Date: 09/04/2020 3:55:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [SCH_VENTAS].[sp_ConsultarCita]
(
	@IdCita int
)
as
begin

	Select IdCita,IdMascota,FechaCita,Ingreso,Salida,Peso,Altura,Largo,IdEstado
	From SCH_VENTAS.tbl_Citas
	ORDER BY IdCita
end 
GO
/****** Object:  StoredProcedure [SCH_VENTAS].[sp_ConsultarCliente]    Script Date: 09/04/2020 3:55:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [SCH_VENTAS].[sp_ConsultarCliente]
(
	@IdCliente int
)
as
begin

	Select IdCliente,Identificacion,IdTipoIdentificacion,Nombre,PrimerApellido,SegundoApellido,email,Telefono1,Telefono2,IdEstado
	From SCH_VENTAS.tbl_Clientes
	ORDER BY IdCliente
end 
GO
/****** Object:  StoredProcedure [SCH_VENTAS].[sp_ConsultarEspecies]    Script Date: 09/04/2020 3:55:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [SCH_VENTAS].[sp_ConsultarEspecies]
(
	@IdEspecie int
)
as
begin

	Select IdEspecie,desEspecie,IdEstado
	From SCH_VENTAS.tbl_Especie
	ORDER BY IdEspecie
end 
GO
/****** Object:  StoredProcedure [SCH_VENTAS].[sp_ConsultarMascota]    Script Date: 09/04/2020 3:55:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [SCH_VENTAS].[sp_ConsultarMascota]
(
	@IdMascota int
)
as
begin

	Select idMascota,Nombre,Observacion,IdRaza,IdCliente,IdEstado
	From SCH_VENTAS.tbl_Mascotas
	ORDER BY IdMascota
end 
GO
/****** Object:  StoredProcedure [SCH_VENTAS].[sp_ConsultarRaza]    Script Date: 09/04/2020 3:55:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [SCH_VENTAS].[sp_ConsultarRaza]
(
	@IdRaza int
)
as
begin

	Select IdRaza,desRaza,IdEspecie,IdEstado
	From SCH_VENTAS.tbl_Razas
	ORDER BY IdRaza
end 
GO
/****** Object:  StoredProcedure [SCH_VENTAS].[sp_InsertarCita]    Script Date: 09/04/2020 3:55:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [SCH_VENTAS].[sp_InsertarCita]

@idMascota int,
@desEspecie nvarchar(500),
@FechaCita datetime,
@Ingreso datetime,
@Salida datetime,
@Peso float,
@Altura float,
@Largo float,
@IdEstado int
as
Begin
	
		Declare @V_idMascota int 
		Declare @V_desEspecie nvarchar(500) 
		Declare @V_FechaCita datetime 
		Declare @V_Ingreso datetime 
		Declare @V_Salida datetime
		Declare @V_Peso float 
		Declare @V_Altura float
		Declare @V_Largo float
		Declare @V_IdEstado int 

		
		set @V_idMascota = @idMascota
		set @V_desEspecie = @desEspecie
		set @V_FechaCita = @FechaCita
		set @V_Ingreso = @Ingreso
		set @V_Salida = @Salida
		set @V_Peso = @Peso
		set @V_Altura = @Altura
		set @V_Largo = @Largo
		set @IdEstado = @IdEstado


	insert into SCH_VENTAS.tbl_Citas
	values (@V_idMascota,@V_desEspecie,@V_FechaCita,@V_Ingreso,@V_Salida,@Peso,@Altura,@Largo,@V_IdEstado)
End
GO
/****** Object:  StoredProcedure [SCH_VENTAS].[sp_InsertarCliente]    Script Date: 09/04/2020 3:55:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [SCH_VENTAS].[sp_InsertarCliente]

@Identificacion nvarchar(50),
@IdTipoIdentificacion int,
@Nombre nvarchar(50),
@PrimerApellido nvarchar (50),
@SegundoApellido nvarchar (50),
@email nvarchar(100),
@Telefono1 nvarchar (50),
@Telefono2 nvarchar (50),
@IdEstado int
as
Begin
		
		Declare @V_Identificacion nvarchar (50) = @Identificacion
		Declare @V_IdTipoIdentificacion int = @IdTipoIdentificacion
		Declare @V_Nombre nvarchar(50) = @Nombre
		Declare @V_PrimerApellido nvarchar (50) = @PrimerApellido
		Declare @V_SegundoApellido nvarchar (50) = @SegundoApellido
		Declare @V_email nvarchar (100) = @email
		Declare @V_Telefono1 nvarchar (50) = @Telefono1
		Declare @V_Telefono2 nvarchar (50) = @Telefono2
		Declare @V_IdEstado int = @IdEstado

	insert into SCH_VENTAS.tbl_Clientes
	values (@V_Identificacion,@V_IdTipoIdentificacion,@V_Nombre,@V_PrimerApellido,@V_SegundoApellido,@V_email,@V_Telefono1,@V_Telefono2,@V_IdEstado)
End
GO
/****** Object:  StoredProcedure [SCH_VENTAS].[sp_InsertarEspecies]    Script Date: 09/04/2020 3:55:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [SCH_VENTAS].[sp_InsertarEspecies]

@desEspecie nvarchar(500),
@IdEstado int
as
Begin
		
		Declare @V_desEspecie nvarchar(500) = @desEspecie
		Declare @V_IdEstado int = @IdEstado

	insert into SCH_VENTAS.tbl_Especie
	values (@V_desEspecie,@V_IdEstado)
End
GO
/****** Object:  StoredProcedure [SCH_VENTAS].[sp_InsertarMascota]    Script Date: 09/04/2020 3:55:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [SCH_VENTAS].[sp_InsertarMascota]

@Nombre nvarchar(50),
@Observacion nvarchar (500),
@IdRaza int,
@IdCliente int,
@IdEstado int
as
Begin
		
		Declare @V_Nombre nvarchar(50) = @Nombre
		Declare @V_Observacion nvarchar(200) = @Observacion
		Declare @V_IdRaza int = @IdRaza
		Declare @V_IdCliente int = @IdCliente
		Declare @V_IdEstado int = @IdEstado

	insert into SCH_VENTAS.tbl_Mascotas
	values (@V_Nombre,@V_Observacion,@V_IdRaza,@V_IdCliente,@V_IdEstado)
End
GO
/****** Object:  StoredProcedure [SCH_VENTAS].[sp_InsertarRaza]    Script Date: 09/04/2020 3:55:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure  [SCH_VENTAS].[sp_InsertarRaza]

@desRaza nvarchar(50),
@IdEspecie int,
@IdEstado int
as
Begin
		
		Declare @V_desRaza nvarchar(50) = @desRaza
		Declare @V_IdEspecie int = @IdEspecie
		Declare @V_IdEstado int = @IdEstado

	insert into SCH_VENTAS.tbl_Razas
	values (@V_desRaza,@V_IdEspecie,@V_IdEstado)
End
GO
/****** Object:  StoredProcedure [SCH_VENTAS].[sp_ModificarCEspecie]    Script Date: 09/04/2020 3:55:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [SCH_VENTAS].[sp_ModificarCEspecie]
@IdEspecie int,
@DesEspecie nvarchar(500),
@IdEstado int
as
begin
	Update SCH_VENTAS.tbl_Especie
	Set  
		DesEspecie  = @DesEspecie,
		IdEstado    = @IdEstado
	Where 
		 IdEspecie = @IdEspecie  	 
end
GO
/****** Object:  StoredProcedure [SCH_VENTAS].[sp_ModificarCiente]    Script Date: 09/04/2020 3:55:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [SCH_VENTAS].[sp_ModificarCiente]
@IdCliente int,
@Identificacion nvarchar(50),
@IdTipoIdentificacion int,
@Nombre nvarchar (50),
@PrimerApellido nvarchar (50),
@SegundoApellido nvarchar (50),
@Telefono1 nvarchar (50),
@Telefono2 nvarchar (50),
@IdEstado int
as
begin
	Update SCH_VENTAS.tbl_Clientes
	Set 
		Identificacion   = @Identificacion, 
		Nombre  = @Nombre,
		IdTipoIdentificacion = @IdTipoIdentificacion,
		PrimerApellido   = @PrimerApellido,
		SegundoApellido = @SegundoApellido,
		Telefono1 = @Telefono1,
		Telefono2 = @Telefono2,
		IdEstado = @IdEstado
	Where 
		 IdCliente = @IdCliente  	 
end
GO
/****** Object:  StoredProcedure [SCH_VENTAS].[sp_ModificarCita]    Script Date: 09/04/2020 3:55:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [SCH_VENTAS].[sp_ModificarCita]
@IdCita int,
@IdMascota int,
@DesEspecie nvarchar(500),
@FechaCita datetime,
@Ingreso datetime,
@Salida datetime,
@Peso float,
@Altura float,
@Largo float,
@IdEstado int
as
begin
	Update SCH_VENTAS.tbl_Citas
	Set 
		IdMascota   = @IdMascota, 
		DesEspecie  = @DesEspecie,
		FechaCita   = @FechaCita,
		Ingreso		= @Ingreso,
		Salida		= @Salida,
		Peso		= @Peso,
		Altura		= @Altura,
		Largo		= @Largo,
		IdEstado    = @IdEstado
	Where 
		 IdCita = @IdCita  	 
end
GO
/****** Object:  StoredProcedure [SCH_VENTAS].[sp_ModificarMascota]    Script Date: 09/04/2020 3:55:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [SCH_VENTAS].[sp_ModificarMascota]
@IdMascota int,
@Nombre nvarchar(50),
@Observacion nvarchar (200),
@IdRaza int,
@IdCliente int,
@IdEstado int
as
begin
	Update SCH_VENTAS.tbl_Mascotas
	Set 
		 
		Nombre  = @Nombre,
		Observacion   = @Observacion,
		IdRaza	= @IdRaza,
		idCliente = @IdCliente,
		IdEstado    = @IdEstado
	Where 
		 IdMascota = @IdMascota  	 
end
GO
/****** Object:  StoredProcedure [SCH_VENTAS].[sp_ModificarRaza]    Script Date: 09/04/2020 3:55:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [SCH_VENTAS].[sp_ModificarRaza]
@IdRaza int,
@DesRaza nvarchar(50),
@IdEspecie int,
@IdEstado int
as
begin
	Update SCH_VENTAS.tbl_Razas
	Set 
		 
		DesRaza  = @DesRaza,
		IdEspecie = @IdEspecie,
		IdEstado    = @IdEstado
	Where 
		 IdRaza = @IdRaza  	 
end
GO
USE [master]
GO
ALTER DATABASE [VETERINARIA] SET  READ_WRITE 
GO
