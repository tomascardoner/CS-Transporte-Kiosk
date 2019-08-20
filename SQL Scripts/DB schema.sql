USE [master]
GO
/****** Object:  Database [CSTransporte_Kiosko]    Script Date: 19/08/2019 22:16:01 ******/
CREATE DATABASE [CSTransporte_Kiosko]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CSTransporte_Kiosk', FILENAME = N'C:\Data\Cardoner Sistemas\Development\CS-Transporte\Database\Kiosko\CSTransporte_Kiosko.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'CSTransporte_Kiosk_log', FILENAME = N'C:\Data\Cardoner Sistemas\Development\CS-Transporte\Database\Kiosko\CSTransporte_Kiosko_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [CSTransporte_Kiosko] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CSTransporte_Kiosko].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CSTransporte_Kiosko] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CSTransporte_Kiosko] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CSTransporte_Kiosko] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CSTransporte_Kiosko] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CSTransporte_Kiosko] SET ARITHABORT OFF 
GO
ALTER DATABASE [CSTransporte_Kiosko] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CSTransporte_Kiosko] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [CSTransporte_Kiosko] SET AUTO_SHRINK ON 
GO
ALTER DATABASE [CSTransporte_Kiosko] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CSTransporte_Kiosko] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CSTransporte_Kiosko] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CSTransporte_Kiosko] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CSTransporte_Kiosko] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CSTransporte_Kiosko] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CSTransporte_Kiosko] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CSTransporte_Kiosko] SET  DISABLE_BROKER 
GO
ALTER DATABASE [CSTransporte_Kiosko] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CSTransporte_Kiosko] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CSTransporte_Kiosko] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CSTransporte_Kiosko] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CSTransporte_Kiosko] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CSTransporte_Kiosko] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CSTransporte_Kiosko] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CSTransporte_Kiosko] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [CSTransporte_Kiosko] SET  MULTI_USER 
GO
ALTER DATABASE [CSTransporte_Kiosko] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CSTransporte_Kiosko] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CSTransporte_Kiosko] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CSTransporte_Kiosko] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'CSTransporte_Kiosko', N'ON'
GO
USE [CSTransporte_Kiosko]
GO
/****** Object:  User [cstransportekiosko]    Script Date: 19/08/2019 22:16:02 ******/
CREATE USER [cstransportekiosko] FOR LOGIN [cstransportekiosko] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  StoredProcedure [dbo].[usp_EventLog_Agregar]    Script Date: 19/08/2019 22:16:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[usp_EventLog_Agregar]
	@Tipo char(1),
	@IDKiosko tinyint,
	@Mensaje varchar(100),
	@Notas varchar(8000)
	AS

	BEGIN
		-- SET NOCOUNT ON added to prevent extra result sets from interfering with SELECT statements.
		SET NOCOUNT ON;

		IF @Tipo IN ('I', 'A', 'E', 'S', 'F')			
			INSERT INTO EventLog
				(FechaHora, Tipo, IDKiosko, Mensaje, Notas)
				VALUES (GETDATE(), @Tipo, @IDKiosko, @Mensaje, @Notas)
	END

GO
/****** Object:  StoredProcedure [dbo].[usp_Imagen_ObtenerPorID]    Script Date: 19/08/2019 22:16:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[usp_Imagen_ObtenerPorID]
	@IDImagen smallint
	AS

	BEGIN
		-- SET NOCOUNT ON added to prevent extra result sets from interfering with SELECT statements.
		SET NOCOUNT ON;

		SELECT i.IDImagen, i.Nombre, i.ImagenData
			FROM Imagen AS i
			WHERE i.IDImagen = @IDImagen
	END

GO
/****** Object:  StoredProcedure [dbo].[usp_Kiosko_ObtenerPorID]    Script Date: 19/08/2019 22:16:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[usp_Kiosko_ObtenerPorID]
	@IDKiosko tinyint
	AS

	BEGIN
		-- SET NOCOUNT ON added to prevent extra result sets from interfering with SELECT statements.
		SET NOCOUNT ON;

		SELECT k.IDKiosko, k.Nombre, k.MACAddress, k.IDEmpresa, k.IDLugar, k.IDKioskoConfiguracion, k.IDTicketPlantilla, k.Activo, k.UltimaConexion, k.UltimaOperacion
			FROM Kiosko AS k
			WHERE k.IDKiosko = @IDKiosko
	END

GO
/****** Object:  StoredProcedure [dbo].[usp_Kiosko_ObtenerPorMAC]    Script Date: 19/08/2019 22:16:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[usp_Kiosko_ObtenerPorMAC]
	@MACAddress char(12)
	AS

	BEGIN
		-- SET NOCOUNT ON added to prevent extra result sets from interfering with SELECT statements.
		SET NOCOUNT ON;

		SELECT k.IDKiosko, k.Nombre, k.MACAddress, k.IDEmpresa, k.IDLugar, k.IDKioskoConfiguracion, k.IDTicketPlantilla, k.Activo, k.UltimaConexion, k.UltimaOperacion
			FROM Kiosko AS k
			WHERE k.MACAddress = @MACAddress
	END

GO
/****** Object:  StoredProcedure [dbo].[usp_KioskoConfiguracion_ObtenerPorID]    Script Date: 19/08/2019 22:16:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[usp_KioskoConfiguracion_ObtenerPorID]
	@IDKioskoConfiguracion tinyint
	AS

	BEGIN
		-- SET NOCOUNT ON added to prevent extra result sets from interfering with SELECT statements.
		SET NOCOUNT ON;

		SELECT kc.IDKioskoConfiguracion, kc.Nombre
			FROM KioskoConfiguracion AS kc
			WHERE kc.IDKioskoConfiguracion = @IDKioskoConfiguracion
	END

GO
/****** Object:  StoredProcedure [dbo].[usp_KioskoConfiguracion_ObtenerValores]    Script Date: 19/08/2019 22:16:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[usp_KioskoConfiguracion_ObtenerValores]
	@IDKioskoConfiguracion tinyint
	AS

	BEGIN
		-- SET NOCOUNT ON added to prevent extra result sets from interfering with SELECT statements.
		SET NOCOUNT ON;

		SELECT kcv.IDKioskoConfiguracion, kcv.IDValor, kcv.ValorTexto, kcv.ValorNumeroEntero, kcv.ValorNumeroDecimal, kcv.ValorFechaHora, kcv.ValorSiNo, kcv.ValorIDImagen, i.ImagenData AS ValorImagenData
			FROM KioskoConfiguracionValor AS kcv LEFT JOIN Imagen AS i ON kcv.ValorIDImagen = i.IDImagen
			WHERE kcv.IDKioskoConfiguracion = @IDKioskoConfiguracion
			ORDER BY kcv.IDValor
	END

GO
/****** Object:  StoredProcedure [dbo].[usp_KioskoConfiguracionValor_ObtenerPorID]    Script Date: 19/08/2019 22:16:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[usp_KioskoConfiguracionValor_ObtenerPorID]
	@IDKioskoConfiguracion tinyint,
	@IDValor char(100)
	AS

	BEGIN
		-- SET NOCOUNT ON added to prevent extra result sets from interfering with SELECT statements.
		SET NOCOUNT ON;

		SELECT kcv.IDKioskoConfiguracion, kcv.IDValor, kcv.ValorTexto, kcv.ValorNumeroEntero, kcv.ValorNumeroDecimal, kcv.ValorFechaHora, kcv.ValorSiNo, kcv.ValorIDImagen, i.ImagenData AS ValorImagenData
			FROM KioskoConfiguracionValor AS kcv LEFT JOIN Imagen AS i ON kcv.ValorIDImagen = i.IDImagen
			WHERE kcv.IDKioskoConfiguracion = @IDKioskoConfiguracion AND kcv.IDValor = @IDValor
	END

GO
/****** Object:  StoredProcedure [dbo].[usp_PersonasPorReserva]    Script Date: 19/08/2019 22:16:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[usp_PersonasPorReserva]
	@IDEmpresa tinyint,
	@IDViaje int,
	@IDViajeDetalle int,
	@ReservaCodigo char(8),
	@GrupoNumero tinyint
	AS

	BEGIN
		-- SET NOCOUNT ON added to prevent extra result sets from interfering with SELECT statements.
		SET NOCOUNT ON;

		IF @IDEmpresa = 2
			SELECT p.IDPersona, p.Apellido, p.Nombre, dt.Nombre AS DocumentoTipo, p.DocumentoNumero, lo.Nombre AS LugarOrigen, lgo.Nombre AS LugarGrupoOrigen, DATEADD(minute, rdo.Duracion, v.FechaHora) AS FechaHoraOrigen, ld.Nombre AS LugarDestino, lgd.Nombre AS LugarGrupoDestino, DATEADD(minute, rdd.Duracion, v.FechaHora) AS FechaHoraDestino, v.FechaHora, vh.Nombre AS Vehiculo, vd.Realizado
				FROM (((((((((CSTransporte_DelSurBus..Persona AS p
					LEFT JOIN CSTransporte_DelSurBus..DocumentoTipo AS dt ON p.IDDocumentoTipo = dt.IDDocumentoTipo)
					INNER JOIN CSTransporte_DelSurBus..ViajeDetalle AS vd ON p.IDPersona = vd.IDPersona)
					INNER JOIN CSTransporte_DelSurBus..Viaje AS v ON vd.IDViaje = v.IDViaje)
					INNER JOIN CSTransporte_DelSurBus..RutaDetalle AS rdo ON vd.IDRuta = rdo.IDRuta AND vd.IDOrigen = rdo.IDLugar)
					INNER JOIN CSTransporte_DelSurBus..Lugar AS lo ON vd.IDOrigen = lo.IDLugar)
					INNER JOIN CSTransporte_DelSurBus..LugarGrupo AS lgo ON rdo.IDLugarGrupo = lgo.IDLugarGrupo)
					INNER JOIN CSTransporte_DelSurBus..RutaDetalle AS rdd ON vd.IDRuta = rdd.IDRuta AND vd.IDDestino = rdd.IDLugar)
					INNER JOIN CSTransporte_DelSurBus..Lugar AS ld ON vd.IDDestino = ld.IDLugar)
					INNER JOIN CSTransporte_DelSurBus..LugarGrupo AS lgd ON rdd.IDLugarGrupo = lgd.IDLugarGrupo)
					LEFT JOIN CSTransporte_DelSurBus..Vehiculo AS vh ON v.IDVehiculo = vh.IDVehiculo
				WHERE vd.IDViaje = @IDViaje
					AND ((@ReservaCodigo IS NOT NULL AND vd.ReservaCodigo = @ReservaCodigo)
							OR (@ReservaCodigo IS NULL AND ISNULL(@GrupoNumero, 0) > 0 AND vd.GrupoNumero = @GrupoNumero)
							OR (@ReservaCodigo IS NULL AND ISNULL(@GrupoNumero, 0) = 0 AND vd.IDViajeDetalle = @IDViajeDetalle))
	END

GO
/****** Object:  StoredProcedure [dbo].[usp_ReservasPorDocumento]    Script Date: 19/08/2019 22:16:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[usp_ReservasPorDocumento]
	@IDEmpresa tinyint,
	@IDLugar int,
	@LugarDuracionPreviaMaxima smallint,
    @LugarDuracionPreviaMinima smallint,
    @DocumentoNumero varchar(15)
	AS

	BEGIN
		-- SET NOCOUNT ON added to prevent extra result sets from interfering with SELECT statements.
		SET NOCOUNT ON;

		IF @IDEmpresa = 2
			SELECT v.IDViaje, vd.IDViajeDetalle, vd.ReservaCodigo, vd.GrupoNumero
				FROM ((CSTransporte_DelSurBus..Persona AS p
					INNER JOIN CSTransporte_DelSurBus..ViajeDetalle AS vd ON p.IDPersona = vd.IDPersona)
					INNER JOIN CSTransporte_DelSurBus..Viaje AS v ON vd.FechaHora = v.FechaHora AND vd.IDRuta = v.IDRuta)
					INNER JOIN CSTransporte_DelSurBus..RutaDetalle AS rd ON v.IDRuta = rd.IDRuta AND rd.IDLugar = @IDLugar
				WHERE DATEADD(minute, rd.Duracion, v.FechaHora) BETWEEN DATEADD(minute, -@LugarDuracionPreviaMaxima, GETDATE()) AND DATEADD(minute, -@LugarDuracionPreviaMinima, GETDATE())
					AND p.DocumentoNumero = @DocumentoNumero
	END

GO
/****** Object:  StoredProcedure [dbo].[usp_TicketPlantilla_ObtenerComandos]    Script Date: 19/08/2019 22:16:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[usp_TicketPlantilla_ObtenerComandos]
	@IDTicketPlantilla tinyint
	AS

	BEGIN
		-- SET NOCOUNT ON added to prevent extra result sets from interfering with SELECT statements.
		SET NOCOUNT ON;

		SELECT tpc.IDTicketPlantilla, tpc.IDComando, tpc.Texto, tpc.IDImagen, i.ImagenData, tpc.ImagenAncho, tpc.ImagenPosicion
			FROM TicketPlantillaComando AS tpc LEFT JOIN Imagen AS i ON tpc.IDImagen = i.IDImagen
			WHERE tpc.IDTicketPlantilla = @IDTicketPlantilla
			ORDER BY tpc.IDComando
	END

GO
/****** Object:  StoredProcedure [dbo].[usp_TicketPlantilla_ObtenerPorID]    Script Date: 19/08/2019 22:16:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[usp_TicketPlantilla_ObtenerPorID]
	@IDTicketPlantilla tinyint
	AS

	BEGIN
		-- SET NOCOUNT ON added to prevent extra result sets from interfering with SELECT statements.
		SET NOCOUNT ON;

		SELECT tp.IDTicketPlantilla, tp.Nombre, tp.Activo
			FROM TicketPlantilla AS tp
			WHERE tp.IDTicketPlantilla = @IDTicketPlantilla
	END

GO
/****** Object:  StoredProcedure [dbo].[usp_TicketPlantillaComando_ObtenerPorID]    Script Date: 19/08/2019 22:16:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[usp_TicketPlantillaComando_ObtenerPorID]
	@IDTicketPlantilla tinyint
	AS

	BEGIN
		-- SET NOCOUNT ON added to prevent extra result sets from interfering with SELECT statements.
		SET NOCOUNT ON;

		SELECT tpc.IDTicketPlantilla, tpc.IDComando, tpc.Texto, tpc.IDImagen, i.ImagenData, tpc.ImagenAncho, tpc.ImagenPosicion
			FROM TicketPlantillaComando AS tpc LEFT JOIN Imagen AS i ON tpc.IDImagen = i.IDImagen
			WHERE tpc.IDTicketPlantilla = @IDTicketPlantilla
			ORDER BY tpc.IDComando
	END

GO
/****** Object:  StoredProcedure [dbo].[usp_ViajeDetalle_RealizarCheckIn]    Script Date: 19/08/2019 22:16:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[usp_ViajeDetalle_RealizarCheckIn]
	@IDEmpresa tinyint,
	@IDViajeDetalle int
	AS

	BEGIN
		-- SET NOCOUNT ON added to prevent extra result sets from interfering with SELECT statements.
		SET NOCOUNT ON;

		IF @IDEmpresa = 2
			UPDATE CSTransporte_DelSurBus..ViajeDetalle
				SET Realizado = 1, FechaHoraModificacion = GETDATE()
				WHERE IDViajeDetalle = @IDViajeDetalle
	END

GO
/****** Object:  Table [dbo].[Empresa]    Script Date: 19/08/2019 22:16:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Empresa](
	[IDEmpresa] [tinyint] NOT NULL,
	[Codigo] [char](2) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[DatabaseName] [varchar](128) NULL,
	[Activo] [bit] NOT NULL,
 CONSTRAINT [PK__Empresa] PRIMARY KEY CLUSTERED 
(
	[IDEmpresa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 10) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[EventLog]    Script Date: 19/08/2019 22:16:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[EventLog](
	[IDEventLog] [int] IDENTITY(1,1) NOT NULL,
	[FechaHora] [smalldatetime] NOT NULL,
	[Tipo] [char](1) NOT NULL,
	[IDKiosko] [tinyint] NULL,
	[Mensaje] [varchar](100) NOT NULL,
	[Notas] [varchar](8000) NULL,
 CONSTRAINT [PK__EventLog] PRIMARY KEY CLUSTERED 
(
	[IDEventLog] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Imagen]    Script Date: 19/08/2019 22:16:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Imagen](
	[IDImagen] [smallint] NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[ImagenData] [varbinary](max) NOT NULL,
 CONSTRAINT [PK__Imagen] PRIMARY KEY CLUSTERED 
(
	[IDImagen] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Kiosko]    Script Date: 19/08/2019 22:16:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Kiosko](
	[IDKiosko] [tinyint] NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[MACAddress] [char](12) NULL,
	[IDEmpresa] [tinyint] NOT NULL,
	[IDLugar] [int] NOT NULL,
	[IDKioskoConfiguracion] [tinyint] NOT NULL,
	[IDTicketPlantilla] [tinyint] NULL,
	[Activo] [bit] NOT NULL,
	[UltimaConexion] [smalldatetime] NULL,
	[UltimaOperacion] [smalldatetime] NULL,
 CONSTRAINT [PK__Kiosko] PRIMARY KEY CLUSTERED 
(
	[IDKiosko] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[KioskoConfiguracion]    Script Date: 19/08/2019 22:16:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[KioskoConfiguracion](
	[IDKioskoConfiguracion] [tinyint] NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
 CONSTRAINT [PK__KioskoConfiguracion] PRIMARY KEY CLUSTERED 
(
	[IDKioskoConfiguracion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[KioskoConfiguracionValor]    Script Date: 19/08/2019 22:16:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[KioskoConfiguracionValor](
	[IDKioskoConfiguracion] [tinyint] NOT NULL,
	[IDValor] [char](100) NOT NULL,
	[ValorTexto] [nvarchar](max) NULL,
	[ValorNumeroEntero] [int] NULL,
	[ValorNumeroDecimal] [decimal](12, 4) NULL,
	[ValorFechaHora] [datetime] NULL,
	[ValorSiNo] [bit] NULL,
	[ValorIDImagen] [smallint] NULL,
 CONSTRAINT [PK__KioskoConfiguracionValor] PRIMARY KEY CLUSTERED 
(
	[IDKioskoConfiguracion] ASC,
	[IDValor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TicketPlantilla]    Script Date: 19/08/2019 22:16:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TicketPlantilla](
	[IDTicketPlantilla] [tinyint] NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Activo] [bit] NOT NULL,
 CONSTRAINT [PK__TicketPlantilla] PRIMARY KEY CLUSTERED 
(
	[IDTicketPlantilla] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TicketPlantillaComando]    Script Date: 19/08/2019 22:16:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TicketPlantillaComando](
	[IDTicketPlantilla] [tinyint] NOT NULL,
	[IDComando] [tinyint] NOT NULL,
	[Texto] [nvarchar](max) NULL,
	[IDImagen] [smallint] NULL,
	[ImagenAncho] [smallint] NULL,
	[ImagenPosicion] [smallint] NULL,
 CONSTRAINT [PK__TicketPlantillaComando] PRIMARY KEY CLUSTERED 
(
	[IDTicketPlantilla] ASC,
	[IDComando] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [AK__Imagen__Nombre]    Script Date: 19/08/2019 22:16:02 ******/
CREATE UNIQUE NONCLUSTERED INDEX [AK__Imagen__Nombre] ON [dbo].[Imagen]
(
	[Nombre] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [AK__Kiosko__MACAddress]    Script Date: 19/08/2019 22:16:02 ******/
CREATE UNIQUE NONCLUSTERED INDEX [AK__Kiosko__MACAddress] ON [dbo].[Kiosko]
(
	[MACAddress] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [AK__Kiosko__Nombre]    Script Date: 19/08/2019 22:16:02 ******/
CREATE UNIQUE NONCLUSTERED INDEX [AK__Kiosko__Nombre] ON [dbo].[Kiosko]
(
	[Nombre] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [AK__KioskoConfiguracion__Nombre]    Script Date: 19/08/2019 22:16:02 ******/
CREATE UNIQUE NONCLUSTERED INDEX [AK__KioskoConfiguracion__Nombre] ON [dbo].[KioskoConfiguracion]
(
	[Nombre] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [PK__KioskoConfiguracionValor__Nombre]    Script Date: 19/08/2019 22:16:02 ******/
CREATE UNIQUE NONCLUSTERED INDEX [PK__KioskoConfiguracionValor__Nombre] ON [dbo].[KioskoConfiguracionValor]
(
	[IDValor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [AK__TicketPlantilla__Nombre]    Script Date: 19/08/2019 22:16:02 ******/
CREATE UNIQUE NONCLUSTERED INDEX [AK__TicketPlantilla__Nombre] ON [dbo].[TicketPlantilla]
(
	[Nombre] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[EventLog]  WITH CHECK ADD  CONSTRAINT [FK__Kiosko__EventLog] FOREIGN KEY([IDKiosko])
REFERENCES [dbo].[Kiosko] ([IDKiosko])
GO
ALTER TABLE [dbo].[EventLog] CHECK CONSTRAINT [FK__Kiosko__EventLog]
GO
ALTER TABLE [dbo].[Kiosko]  WITH CHECK ADD  CONSTRAINT [FK__Empresa__Kiosko] FOREIGN KEY([IDEmpresa])
REFERENCES [dbo].[Empresa] ([IDEmpresa])
GO
ALTER TABLE [dbo].[Kiosko] CHECK CONSTRAINT [FK__Empresa__Kiosko]
GO
ALTER TABLE [dbo].[Kiosko]  WITH CHECK ADD  CONSTRAINT [FK__KioskoConfiguracion__Kiosko] FOREIGN KEY([IDKioskoConfiguracion])
REFERENCES [dbo].[KioskoConfiguracion] ([IDKioskoConfiguracion])
GO
ALTER TABLE [dbo].[Kiosko] CHECK CONSTRAINT [FK__KioskoConfiguracion__Kiosko]
GO
ALTER TABLE [dbo].[Kiosko]  WITH CHECK ADD  CONSTRAINT [FK__TicketPlantilla__Kiosko] FOREIGN KEY([IDTicketPlantilla])
REFERENCES [dbo].[TicketPlantilla] ([IDTicketPlantilla])
GO
ALTER TABLE [dbo].[Kiosko] CHECK CONSTRAINT [FK__TicketPlantilla__Kiosko]
GO
ALTER TABLE [dbo].[KioskoConfiguracionValor]  WITH CHECK ADD  CONSTRAINT [FK__Imagen__KioskoConfiguracionValor] FOREIGN KEY([ValorIDImagen])
REFERENCES [dbo].[Imagen] ([IDImagen])
GO
ALTER TABLE [dbo].[KioskoConfiguracionValor] CHECK CONSTRAINT [FK__Imagen__KioskoConfiguracionValor]
GO
ALTER TABLE [dbo].[KioskoConfiguracionValor]  WITH CHECK ADD  CONSTRAINT [FK__KioskoConfiguracion__KioskoConfiguracionValor] FOREIGN KEY([IDKioskoConfiguracion])
REFERENCES [dbo].[KioskoConfiguracion] ([IDKioskoConfiguracion])
GO
ALTER TABLE [dbo].[KioskoConfiguracionValor] CHECK CONSTRAINT [FK__KioskoConfiguracion__KioskoConfiguracionValor]
GO
ALTER TABLE [dbo].[TicketPlantillaComando]  WITH CHECK ADD  CONSTRAINT [FK__Imagen__TicketPlantillaComando] FOREIGN KEY([IDImagen])
REFERENCES [dbo].[Imagen] ([IDImagen])
GO
ALTER TABLE [dbo].[TicketPlantillaComando] CHECK CONSTRAINT [FK__Imagen__TicketPlantillaComando]
GO
ALTER TABLE [dbo].[TicketPlantillaComando]  WITH CHECK ADD  CONSTRAINT [FK__TicketPlantilla__TicketPlantillaComando] FOREIGN KEY([IDTicketPlantilla])
REFERENCES [dbo].[TicketPlantilla] ([IDTicketPlantilla])
GO
ALTER TABLE [dbo].[TicketPlantillaComando] CHECK CONSTRAINT [FK__TicketPlantilla__TicketPlantillaComando]
GO
USE [master]
GO
ALTER DATABASE [CSTransporte_Kiosko] SET  READ_WRITE 
GO
