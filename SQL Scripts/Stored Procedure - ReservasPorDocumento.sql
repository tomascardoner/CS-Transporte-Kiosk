USE CSTransporte_DelSurBus
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Tom�s A. Cardoner
-- Create date: 2019-07-13
-- Description:	Busca todas las personas asociadas a una reserva,
--              dentro de los pr�ximos (x) minutos, a partir del DNI de una de ellas
-- =============================================
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'usp_ReservasPorDocumento') AND type in (N'P', N'PC'))
	 DROP PROCEDURE usp_ReservasPorDocumento
GO

CREATE PROCEDURE usp_ReservasPorDocumento
	@IDLugar int,
	@LugarDuracionPreviaMaxima smallint,
    @LugarDuracionPreviaMinima smallint,
    @DocumentoNumero varchar(15)
	AS

	BEGIN
		-- SET NOCOUNT ON added to prevent extra result sets from interfering with SELECT statements.
		SET NOCOUNT ON;

		SELECT p.IDPersona, p.Apellido, p.Nombre, dt.Nombre AS DocumentoTipoNombre, p.DocumentoNumero, v.FechaHora, RTRIM(v.IDRuta) AS Ruta
            FROM (((Persona AS p INNER JOIN DocumentoTipo AS dt ON p.IDDocumentoTipo = dt.IDDocumentoTipo)
				INNER JOIN ViajeDetalle AS vd ON p.IDPersona = vd.IDPersona)
				INNER JOIN Viaje AS v ON vd.FechaHora = v.FechaHora AND vd.IDRuta = v.IDRuta)
				INNER JOIN dbo.udf_DuracionDeRutasAUnLugar(@IDLugar) AS fdr ON v.IDRuta = fdr.IDRuta
			WHERE DATEADD(minute, fdr.Duracion, v.FechaHora) BETWEEN DATEADD(minute, -@LugarDuracionPreviaMaxima, GETDATE()) AND DATEADD(minute, -@LugarDuracionPreviaMinima, GETDATE())
				AND p.DocumentoNumero = @DocumentoNumero
	END