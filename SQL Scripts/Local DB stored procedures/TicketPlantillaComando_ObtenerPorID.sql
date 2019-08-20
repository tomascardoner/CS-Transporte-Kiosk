USE CSTransporte_Kiosko
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Tomás A. Cardoner
-- Create date: 2019-08-16
-- Description:	Obtiene los datos de los comandos de la plantilla de ticket
-- =============================================
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'usp_TicketPlantillaComando_ObtenerPorID') AND type in (N'P', N'PC'))
	 DROP PROCEDURE usp_TicketPlantillaComando_ObtenerPorID
GO

CREATE PROCEDURE usp_TicketPlantillaComando_ObtenerPorID
	@IDTicketPlantilla tinyint
	AS

	BEGIN
		-- SET NOCOUNT ON added to prevent extra result sets from interfering with SELECT statements.
		SET NOCOUNT ON;

		SELECT tpc.IDTicketPlantilla, tpc.IDComando, tpc.Texto, tpc.IDImagen, i.ImagenData, tpc.ImagenAncho, tpc.ImagenPosicion
			FROM TicketPlantillaComando AS tpc LEFT JOIN Imagen AS i ON tpc.IDImagen = i.IDImagen
			WHERE tpc.IDTicketPlantilla = @IDTicketPlantilla
			ORDER BY tpc.IDComando
	END
GO

GRANT EXECUTE ON dbo.usp_TicketPlantillaComando_ObtenerPorID TO cstransportekiosko
GO