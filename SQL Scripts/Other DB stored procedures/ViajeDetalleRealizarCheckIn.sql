SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Tomás A. Cardoner
-- Description:	Actualiza el campo Realizado en la reserva
-- History:
--         - 2019-08-19: Creation
--         - 2019-08-20: Modificado para ser usado desde la base de datos de la empresa
-- =============================================
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'usp_ViajeDetalle_RealizarCheckIn') AND type in (N'P', N'PC'))
	 DROP PROCEDURE usp_ViajeDetalle_RealizarCheckIn
GO

CREATE PROCEDURE usp_ViajeDetalle_RealizarCheckIn
	@IDViajeDetalle int
	AS

	BEGIN
		-- SET NOCOUNT ON added to prevent extra result sets from interfering with SELECT statements.
		SET NOCOUNT ON;

		UPDATE ViajeDetalle
			SET Realizado = 1, FechaHoraModificacion = GETDATE()
			WHERE IDViajeDetalle = @IDViajeDetalle
	END
GO

GRANT EXECUTE ON usp_ViajeDetalle_RealizarCheckIn TO cstransporte
GO