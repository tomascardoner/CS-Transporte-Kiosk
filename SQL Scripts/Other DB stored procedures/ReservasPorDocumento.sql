USE CSTransporte_DelSurBus
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Tom�s A. Cardoner
-- Description:	Busca las reservas de la persona
--              dentro de los pr�ximos (x) minutos,
--              a partir del N� de Documento
-- History:
--         - 2019-07-13: Creation
--         - 2019-08-18: Modificado para usarse desde la base de datos CSTransport_Kiosko
--                       y usar los tiempos de paradas absolutos
--         - 2019-08-20: Modificado nuevamente para ser usado desde la base de datos de la empresa
-- =============================================
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'usp_ReservasPorDocumento') AND type in (N'P', N'PC'))
	 DROP PROCEDURE usp_ReservasPorDocumento
GO

CREATE PROCEDURE usp_ReservasPorDocumento
	@IDLugar int,
	@LugarDuracionPreviaMaxima smallint,
    @LugarDuracionPreviaMinima smallint,
    @DocumentoNumero varchar(15)
	AS

	BEGIN
		-- SET NOCOUNT ON added to prevent extra result sets from interfering with SELECT statements.
		SET NOCOUNT ON;

		SELECT v.IDViaje, vd.IDViajeDetalle, vd.ReservaCodigo, vd.GrupoNumero
			FROM ((Persona AS p
				INNER JOIN ViajeDetalle AS vd ON p.IDPersona = vd.IDPersona)
				INNER JOIN Viaje AS v ON vd.FechaHora = v.FechaHora AND vd.IDRuta = v.IDRuta)
				INNER JOIN RutaDetalle AS rd ON v.IDRuta = rd.IDRuta AND rd.IDLugar = @IDLugar
			WHERE DATEADD(minute, rd.Duracion, v.FechaHora) BETWEEN DATEADD(minute, -@LugarDuracionPreviaMaxima, GETDATE()) AND DATEADD(minute, -@LugarDuracionPreviaMinima, GETDATE())
				AND p.DocumentoNumero = @DocumentoNumero
	END
GO

GRANT EXECUTE ON dbo.usp_ReservasPorDocumento TO cstransporte
GO