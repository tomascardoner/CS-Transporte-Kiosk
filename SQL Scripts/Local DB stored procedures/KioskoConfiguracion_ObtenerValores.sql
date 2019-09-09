USE CSTransporte
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Tomás A. Cardoner
-- Create date: 2019-08-14
-- Description:	Obtiene los valores de una configuración de Kiosko
-- =============================================
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'usp_KioskoConfiguracion_ObtenerValores') AND type in (N'P', N'PC'))
	 DROP PROCEDURE usp_KioskoConfiguracion_ObtenerValores
GO

CREATE PROCEDURE usp_KioskoConfiguracion_ObtenerValores
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

GRANT EXECUTE ON dbo.usp_KioskoConfiguracion_ObtenerValores TO cstransporte
GO