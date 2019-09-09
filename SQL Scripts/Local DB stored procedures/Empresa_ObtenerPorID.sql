USE CSTransporte
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Tomás A. Cardoner
-- Description:	Obtiene los datos de un Kiosko
-- History:
--         - 2019-08-20: creation
-- =============================================
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'usp_Empresa_ObtenerPorID') AND type in (N'P', N'PC'))
	 DROP PROCEDURE usp_Empresa_ObtenerPorID
GO

CREATE PROCEDURE usp_Empresa_ObtenerPorID
	@IDEmpresa tinyint
	AS

	BEGIN
		-- SET NOCOUNT ON added to prevent extra result sets from interfering with SELECT statements.
		SET NOCOUNT ON;

		SELECT e.IDEmpresa, e.Codigo, e.Nombre, e.DatabaseName, e.Activo
			FROM Empresa AS e
			WHERE e.IDEmpresa = @IDEmpresa
	END
GO

GRANT EXECUTE ON dbo.usp_Empresa_ObtenerPorID TO cstransporte
GO