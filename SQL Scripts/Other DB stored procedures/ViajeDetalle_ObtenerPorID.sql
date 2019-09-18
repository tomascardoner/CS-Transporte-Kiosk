SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Tomás A. Cardoner
-- Description:	Obtiene los datos del Detalle del Viaje
-- History:
--         - 2019-09-17: Creación
-- =============================================
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'usp_ViajeDetalle_ObtenerPorID') AND type in (N'P', N'PC'))
	 DROP PROCEDURE usp_ViajeDetalle_ObtenerPorID
GO

CREATE PROCEDURE usp_ViajeDetalle_ObtenerPorID
	@IDViajeDetalle int
	AS

	BEGIN
		-- SET NOCOUNT ON added to prevent extra result sets from interfering with SELECT statements.
		SET NOCOUNT ON;

		SELECT vd.IDViajeDetalle, vd.IDViaje, vd.FechaHora, vd.IDRuta, vd.Indice, vd.IDPersona, vd.AsientoIdentificacion
			FROM ViajeDetalle AS vd
			WHERE vd.IDViajeDetalle = @IDViajeDetalle
	END
GO

GRANT EXECUTE ON dbo.usp_ViajeDetalle_ObtenerPorID TO cstransporte
GO