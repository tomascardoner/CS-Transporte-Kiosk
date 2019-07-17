USE CSTransporte_DelSurBus
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Tomás A. Cardoner
-- Create date: 2019-07-14
-- Description:	Devuelve la duración del viaje desde el inicio de la ruta hasta el lugar indicado
-- =============================================
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'dbo.udf_DuracionDeRutasAUnLugar') AND type = N'FN')
	DROP FUNCTION dbo.udf_DuracionDeRutasAUnLugar
GO

CREATE FUNCTION udf_DuracionDeRutasAUnLugar
(	
	@IDLugar int
) RETURNS TABLE
AS
RETURN
SELECT rd.IDRuta, SUM(rd.Duracion) AS Duracion
	FROM RutaDetalle AS rd
	INNER JOIN (SELECT IDRuta, Indice FROM RutaDetalle WHERE IDLugar = @IDLugar) AS subrd ON rd.IDRuta = subrd.IDRuta
	WHERE rd.Indice <= subrd.Indice
	GROUP BY rd.IDRuta
	HAVING SUM(rd.Duracion) IS NOT NULL

GO