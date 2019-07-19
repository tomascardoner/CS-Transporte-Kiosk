USE CSTransporte_DelSurBus
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Tomás A. Cardoner
-- Create date: 2019-07-18
-- Description:	Busca todas las personas asociadas a una reserva
-- =============================================
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'usp_PersonasPorReserva') AND type in (N'P', N'PC'))
	 DROP PROCEDURE usp_PersonasPorReserva
GO

CREATE PROCEDURE usp_PersonasPorReserva
	@IDViaje int,
	@IDViajeDetalle int,
	@ReservaCodigo char(8),
	@GrupoNumero tinyint
	AS

	BEGIN
		-- SET NOCOUNT ON added to prevent extra result sets from interfering with SELECT statements.
		SET NOCOUNT ON;

		SELECT p.IDPersona, p.Apellido, p.Nombre, dt.Nombre AS DocumentoTipoNombre, p.DocumentoNumero
            FROM (Persona AS p INNER JOIN DocumentoTipo AS dt ON p.IDDocumentoTipo = dt.IDDocumentoTipo)
				INNER JOIN ViajeDetalle AS vd ON p.IDPersona = vd.IDPersona
			WHERE vd.IDViaje = @IDViaje
				AND ((@ReservaCodigo IS NOT NULL AND vd.ReservaCodigo = @ReservaCodigo)
						OR (@ReservaCodigo IS NULL AND @GrupoNumero IS NOT NULL AND vd.GrupoNumero = @GrupoNumero)
						OR (@ReservaCodigo IS NULL AND @GrupoNumero IS NULL AND vd.IDViajeDetalle = @IDViajeDetalle))
	END
GO

GRANT EXECUTE ON dbo.usp_PersonasPorReserva TO cstransportekiosk
GO