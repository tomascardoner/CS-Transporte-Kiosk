USE CSTransporte_Kiosko
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Tomás A. Cardoner
-- Description:	Busca las reservas de la persona
--              dentro de los próximos (x) minutos,
--              a partir del Nº de Documento
-- History:
--         - 2019-07-13: Creation
--         - 2019-08-18: Modificado para usarse desde la base de datos CSTransport_Kiosko
--                       y usar los tiempos de paradas absolutos
-- =============================================
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'usp_ReservasPorDocumento') AND type in (N'P', N'PC'))
	 DROP PROCEDURE usp_ReservasPorDocumento
GO

CREATE PROCEDURE usp_ReservasPorDocumento
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

GRANT EXECUTE ON dbo.usp_ReservasPorDocumento TO cstransportekiosko
GO