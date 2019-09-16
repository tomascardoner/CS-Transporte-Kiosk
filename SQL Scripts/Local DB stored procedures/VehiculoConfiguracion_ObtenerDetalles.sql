USE CSTransporte
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Tomás A. Cardoner
-- Create date: 2019-09-16
-- Description:	Obtiene los Detalles de Configuración de Vehículo
-- =============================================
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'usp_VehiculoConfiguracion_ObtenerDetalles') AND type in (N'P', N'PC'))
	 DROP PROCEDURE usp_VehiculoConfiguracion_ObtenerDetalles
GO

CREATE PROCEDURE usp_VehiculoConfiguracion_ObtenerDetalles
	@IDVehiculoConfiguracion tinyint
	AS

	BEGIN
		-- SET NOCOUNT ON added to prevent extra result sets from interfering with SELECT statements.
		SET NOCOUNT ON;

		SELECT vcd.IDVehiculoConfiguracion, vcd.IDDetalle, vcd.Tipo, vcd.AsientoIdentificacion
			FROM VehiculoConfiguracionDetalle AS vcd
			WHERE vcd.IDVehiculoConfiguracion = @IDVehiculoConfiguracion
			ORDER BY vcd.IDDetalle
	END
GO

GRANT EXECUTE ON dbo.usp_VehiculoConfiguracion_ObtenerDetalles TO cstransporte
GO