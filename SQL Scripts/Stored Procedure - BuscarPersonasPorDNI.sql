USE CSTransporte_DelSurBus
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Tomás A. Cardoner
-- Create date: 2019-07-13
-- Description:	Busca todas las personas asociadas a una reserva,
--              dentro de los próximos (x) minutos, a partir del DNI de una de ellas
-- =============================================
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'usp_BuscarPersonasPorDNI') AND type in (N'P', N'PC'))
	 DROP PROCEDURE usp_BuscarPersonasPorDNI
GO

CREATE PROCEDURE usp_BuscarPersonasPorDNI
	@IDLugar int,
	@LugarDuracionPreviaMaxima smallint,
    @LugarDuracionPreviaMinima smallint,
    @DocumentoNumero varchar(15)
	AS

	BEGIN
		-- SET NOCOUNT ON added to prevent extra result sets from interfering with SELECT statements.
		SET NOCOUNT ON;

		SELECT p.IDPersona, p.Apellido, p.Nombre, dt.Nombre AS DocumentoTipoNombre, p.DocumentoNumero
            FROM (((Persona AS p INNER JOIN DocumentoTipo AS dt ON p.IDDocumentoTipo = dt.IDDocumentoTipo) INNER JOIN ViajeDetalle AS vd ON p.IDPersona = vd.IDPersona) INNER JOIN Viaje AS v ON vd.FechaHora = v.FechaHora AND vd.IDRuta = v.IDRuta) INNER JOIN RutaDetalle AS rd ON v.IDRuta = rd.IDRuta AND rd.IDLugar = @IDLugar
			WHERE v.FechaHora BETWEEN 
	END