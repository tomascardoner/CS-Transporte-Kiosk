USE CSTransporte_Kiosko
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
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'usp_TicketPlantilla_ObtenerPorID') AND type in (N'P', N'PC'))
	 DROP PROCEDURE usp_TicketPlantilla_ObtenerPorID
GO

CREATE PROCEDURE usp_TicketPlantilla_ObtenerPorID
	@IDTicketPlantilla tinyint
	AS

	BEGIN
		-- SET NOCOUNT ON added to prevent extra result sets from interfering with SELECT statements.
		SET NOCOUNT ON;

		SELECT tp.IDTicketPlantilla, tp.Nombre, tp.Activo
			FROM TicketPlantilla AS tp
			WHERE tp.IDTicketPlantilla = @IDTicketPlantilla
	END
GO

GRANT EXECUTE ON dbo.usp_TicketPlantilla_ObtenerPorID TO cstransportekiosko
GO