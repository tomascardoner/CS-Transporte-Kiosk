SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Tomás A. Cardoner
-- Description:	Lista los Detalles del Viaje
-- History:
--         - 2019-09-16: Creación
--		   - 2019-09-17: Renombrado y completado
-- =============================================
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'usp_Viaje_ObtenerDetalles') AND type in (N'P', N'PC'))
	 DROP PROCEDURE usp_Viaje_ObtenerDetalles
GO

CREATE PROCEDURE usp_Viaje_ObtenerDetalles
	@IDViaje int
	AS

	BEGIN
		-- SET NOCOUNT ON added to prevent extra result sets from interfering with SELECT statements.
		SET NOCOUNT ON;

		SELECT vd.IDViajeDetalle, vd.IDViaje, vd.FechaHora, vd.IDRuta, vd.Indice, vd.IDPersona, vd.AsientoIdentificacion
			FROM ViajeDetalle AS vd
			WHERE vd.IDViaje = @IDViaje
			ORDER BY vd.Indice
	END
GO

GRANT EXECUTE ON dbo.usp_Viaje_ObtenerDetalles TO cstransporte
GO