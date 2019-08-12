USE CSTransporte_Kiosk
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Tomás A. Cardoner
-- Create date: 2019-08-11
-- Description:	Obtiene el IDKiosko a partir de la MAC address
--              y genera un registro en la tabla EventLog
-- =============================================
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'usp_Kiosko_ObtenerID') AND type in (N'P', N'PC'))
	 DROP PROCEDURE usp_Kiosko_ObtenerID
GO

CREATE PROCEDURE usp_Kiosko_ObtenerID
	@MACAddress char(12)
	AS

	BEGIN
		-- SET NOCOUNT ON added to prevent extra result sets from interfering with SELECT statements.
		SET NOCOUNT ON;

		DECLARE @IDKiosko tinyint

		SELECT @IDKiosko = IDKiosko FROM Kiosko WHERE MACAddress = @MACAddress

		IF @IDKiosko IS NULL
	END
GO

GRANT EXECUTE ON dbo.usp_TicketPlantilla_Obtener TO cstransportekiosk
GO