USE CSTransporte_Kiosko
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Tomás A. Cardoner
-- Description:	Busca todas las personas asociadas a una reserva
-- History:
--         - 2019-07-18: Creation
--         - 2019-08-18: Modificado para usarse desde la base de datos CSTransport_Kiosko
-- =============================================
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'usp_PersonasPorReserva') AND type in (N'P', N'PC'))
	 DROP PROCEDURE usp_PersonasPorReserva
GO

CREATE PROCEDURE usp_PersonasPorReserva
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

GRANT EXECUTE ON dbo.usp_PersonasPorReserva TO cstransportekiosko
GO