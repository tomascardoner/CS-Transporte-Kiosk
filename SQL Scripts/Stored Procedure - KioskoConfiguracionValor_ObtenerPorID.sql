USE CSTransporte_Kiosko
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
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'usp_KioskoConfiguracionValor_ObtenerPorID') AND type in (N'P', N'PC'))
	 DROP PROCEDURE usp_KioskoConfiguracionValor_ObtenerPorID
GO

CREATE PROCEDURE usp_KioskoConfiguracionValor_ObtenerPorID
	@IDKioskoConfiguracion tinyint,
	@IDValor char(100)
	AS

	BEGIN
		-- SET NOCOUNT ON added to prevent extra result sets from interfering with SELECT statements.
		SET NOCOUNT ON;

		SELECT kcv.IDKioskoConfiguracion, kcv.IDValor, kcv.ValorTexto, kcv.ValorNumeroEntero, kcv.ValorNumeroDecimal, kcv.ValorFechaHora, kcv.ValorSiNo
			FROM KioskoConfiguracionValor AS kcv
			WHERE kcv.IDKioskoConfiguracion = @IDKioskoConfiguracion AND kcv.IDValor = @IDValor
	END
GO

GRANT EXECUTE ON dbo.usp_KioskoConfiguracionValor_ObtenerPorID TO cstransportekiosko
GO