USE CSTransporte
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Tomás A. Cardoner
-- Create date: 2019-08-11
-- Description:	Obtiene los datos de un Kiosko
-- =============================================
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'usp_Kiosko_ObtenerPorID') AND type in (N'P', N'PC'))
	 DROP PROCEDURE usp_Kiosko_ObtenerPorID
GO

CREATE PROCEDURE usp_Kiosko_ObtenerPorID
	@IDKiosko tinyint
	AS

	BEGIN
		-- SET NOCOUNT ON added to prevent extra result sets from interfering with SELECT statements.
		SET NOCOUNT ON;

		SELECT k.IDKiosko, k.Nombre, k.MACAddress, k.IDEmpresa, k.IDLugar, k.IDKioskoConfiguracion, k.IDTicketPlantilla, k.Activo, k.UltimaConexion, k.UltimaOperacion
			FROM Kiosko AS k
			WHERE k.IDKiosko = @IDKiosko
	END
GO

GRANT EXECUTE ON dbo.usp_Kiosko_ObtenerPorID TO cstransporte
GO