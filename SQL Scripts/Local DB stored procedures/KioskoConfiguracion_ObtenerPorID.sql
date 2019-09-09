USE CSTransporte
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Tomás A. Cardoner
-- Create date: 2019-08-14
-- Description:	Obtiene los datos de una configuración de Kiosko
-- =============================================
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'usp_KioskoConfiguracion_ObtenerPorID') AND type in (N'P', N'PC'))
	 DROP PROCEDURE usp_KioskoConfiguracion_ObtenerPorID
GO

CREATE PROCEDURE usp_KioskoConfiguracion_ObtenerPorID
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

GRANT EXECUTE ON dbo.usp_KioskoConfiguracion_ObtenerPorID TO cstransporte
GO