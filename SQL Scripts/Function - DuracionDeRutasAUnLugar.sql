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
) RETURNS varchar(2) AS
BEGIN
	DECLARE @Result table(IDRuta char(20), Duracion smallint)

SELECT rd.IDRuta, SUM(rd.Duracion) AS Duracion
	FROM RutaDetalle AS rd
	INNER JOIN (SELECT IDRuta, Indice FROM RutaDetalle WHERE IDLugar = @IDLugar) AS subrd ON rd.IDRuta = subrd.IDRuta
	WHERE rd.Indice <= subrd.Indice
	GROUP BY rd.IDRuta
	HAVING SUM(rd.Duracion) IS NOT NULL

	RETURN (CASE 
				WHEN @CalificacionAnual < 4 THEN 'D'
				WHEN @CalificacionAnual >= 4 AND @CalificacionAnual < 6 THEN 'R'
				WHEN @CalificacionAnual >= 6 AND @CalificacionAnual < 7 THEN 'B'
				WHEN @CalificacionAnual >= 7 AND @CalificacionAnual < 9 THEN 'MB'
				WHEN @CalificacionAnual >= 9 THEN 'E'
			END)
END
GO