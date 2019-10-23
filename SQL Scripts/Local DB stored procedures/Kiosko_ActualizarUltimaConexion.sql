USE CSTransporte
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Tomás A. Cardoner
-- Create date: 2019-10-22
-- Description:	Actualiza la última conexión
-- =============================================
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'usp_Kiosko_ActualizarUltimaConexion') AND type in (N'P', N'PC'))
	 DROP PROCEDURE usp_Kiosko_ActualizarUltimaConexion
GO

CREATE PROCEDURE usp_Kiosko_ActualizarUltimaConexion
	@IDKiosko tinyint
	AS

	BEGIN
		UPDATE Kiosko
			SET UltimaConexion = GETDATE()
			WHERE IDKiosko = @IDKiosko
	END
GO

GRANT EXECUTE ON dbo.usp_Kiosko_ActualizarUltimaConexion TO cstransporte
GO