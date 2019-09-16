USE CSTransporte
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Tomás A. Cardoner
-- Create date: 2019-09-16
-- Description:	Obtiene los datos de una Configuración de Vehículo
-- =============================================
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'usp_VehiculoConfiguracion_ObtenerPorID') AND type in (N'P', N'PC'))
	 DROP PROCEDURE usp_VehiculoConfiguracion_ObtenerPorID
GO

CREATE PROCEDURE usp_VehiculoConfiguracion_ObtenerPorID
	@IDVehiculoConfiguracion tinyint
	AS

	BEGIN
		-- SET NOCOUNT ON added to prevent extra result sets from interfering with SELECT statements.
		SET NOCOUNT ON;

		SELECT vc.IDVehiculoConfiguracion, vc.Nombre, vc.UnidadAncho, vc.Activo
			FROM VehiculoConfiguracion AS vc
			WHERE vc.IDVehiculoConfiguracion = @IDVehiculoConfiguracion
	END
GO

GRANT EXECUTE ON dbo.usp_VehiculoConfiguracion_ObtenerPorID TO cstransporte
GO