SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
USE VETERINARIA
GO
--DROP PROCEDURE SCH_SEGURIDAD.SP_Consulta_Usuario_Contrasenna 
CREATE PROCEDURE SCH_SEGURIDAD.SP_Consulta_Usuario_Contrasenna 
	@@NOMBREUSUARIO VARCHAR (20),
	@@CONTRASENNA VARCHAR (20)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    IF EXISTS (SELECT 1 FROM SCH_SEGURIDAD.tbl_UsuariosSeguridad 
			   WHERE NombreUsuario = @@NOMBREUSUARIO
			   AND Contrasenna = @@CONTRASENNA)
	BEGIN

		SELECT IdUsuarioSeguridad 
		FROM SCH_SEGURIDAD.tbl_UsuariosSeguridad 
		WHERE NombreUsuario = @@NOMBREUSUARIO
			  AND Contrasenna = @@CONTRASENNA

	END
	ELSE
	BEGIN

		RAISERROR('Las credenciales son incorrectas',12,1)

	END
END
GO
