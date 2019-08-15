USE CSTransporte_Kiosko
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Tomás A. Cardoner
-- Create date: 2019-08-15
-- Description:	Obtiene los datos de una Imagen
-- =============================================
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'usp_Imagen_ObtenerPorID') AND type in (N'P', N'PC'))
	 DROP PROCEDURE usp_Imagen_ObtenerPorID
GO

CREATE PROCEDURE usp_Imagen_ObtenerPorID
	@IDImagen smallint
	AS

	BEGIN
		-- SET NOCOUNT ON added to prevent extra result sets from interfering with SELECT statements.
		SET NOCOUNT ON;

		SELECT i.IDImagen, i.Nombre, i.ImagenData
			FROM Imagen AS i
			WHERE i.IDImagen = @IDImagen
	END
GO

GRANT EXECUTE ON dbo.usp_Imagen_ObtenerPorID TO cstransportekiosko
GO