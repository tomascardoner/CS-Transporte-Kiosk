SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Tomás A. Cardoner
-- Description:	Obtiene los datos del Viaje
-- History:
--         - 2019-09-17: Creación
-- =============================================
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'usp_Viaje_ObtenerPorID') AND type in (N'P', N'PC'))
	 DROP PROCEDURE usp_Viaje_ObtenerPorID
GO

CREATE PROCEDURE usp_Viaje_ObtenerPorID
	@IDViaje int
	AS

	BEGIN
		-- SET NOCOUNT ON added to prevent extra result sets from interfering with SELECT statements.
		SET NOCOUNT ON;

		SELECT v.IDViaje, v.FechaHora, v.IDRuta
			FROM Viaje AS v
			WHERE v.IDViaje = @IDViaje
	END
GO

GRANT EXECUTE ON dbo.usp_Viaje_ObtenerPorID TO cstransporte
GO