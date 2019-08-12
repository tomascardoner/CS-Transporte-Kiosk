USE CSTransporte_Kiosk
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Tomás A. Cardoner
-- Create date: 2019-08-11
-- Description:	Obtiene los datos de una plantilla de ticket
-- =============================================
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'usp_TicketPlantilla_Obtener') AND type in (N'P', N'PC'))
	 DROP PROCEDURE usp_TicketPlantilla_Obtener
GO

CREATE PROCEDURE usp_TicketPlantilla_Obtener
	@IDTicketPlantilla tinyint
	AS

	BEGIN
		-- SET NOCOUNT ON added to prevent extra result sets from interfering with SELECT statements.
		SET NOCOUNT ON;

		SELECT tpc.Texto, i.Imagen, tpc.ImagenAncho, tpc.ImagenPosicion
			FROM (TicketPlantilla AS tp
				INNER JOIN TicketPlantillaComando AS tpc ON tp.IDTicketPlantilla = tpc.IDTicketPlantilla)
				LEFT JOIN Imagen AS i ON tpc.IDImagen = i.IDImagen
			WHERE tp.IDTicketPlantilla = @IDTicketPlantilla
			ORDER BY tpc.IDComando
	END
GO

GRANT EXECUTE ON dbo.usp_TicketPlantilla_Obtener TO cstransportekiosk
GO