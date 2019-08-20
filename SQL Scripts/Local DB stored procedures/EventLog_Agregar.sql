USE CSTransporte_Kiosko
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Tomás A. Cardoner
-- Create date: 2019-08-11
-- Description:	Registra un evento en la tabla de logs (EventLog)
--              Tipo: I->Informacion, A->Aviso, E->Error, S->Login exitoso, F->Login fallido
-- =============================================
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'usp_EventLog_Agregar') AND type in (N'P', N'PC'))
	 DROP PROCEDURE usp_EventLog_Agregar
GO

CREATE PROCEDURE usp_EventLog_Agregar
	@Tipo char(1),
	@IDKiosko tinyint,
	@Mensaje varchar(100),
	@Notas varchar(8000)
	AS

	BEGIN
		-- SET NOCOUNT ON added to prevent extra result sets from interfering with SELECT statements.
		SET NOCOUNT ON;

		IF @Tipo IN ('I', 'A', 'E', 'S', 'F')			
			INSERT INTO EventLog
				(FechaHora, Tipo, IDKiosko, Mensaje, Notas)
				VALUES (GETDATE(), @Tipo, @IDKiosko, @Mensaje, @Notas)
	END
GO

GRANT EXECUTE ON dbo.usp_EventLog_Agregar TO cstransportekiosko
GO