USE master
GO
IF NOT EXISTS (
    SELECT [name]
        FROM sys.databases
        WHERE [name] = N'dbProjetoX'
)
CREATE DATABASE dbProjetoX
GO

----------------------------------------------------------

USE dbProjetoX
GO

----------------------------------------------------------

IF OBJECT_ID('[dbo].[tbTeste]', 'U') IS NOT NULL
DROP TABLE [dbo].[tbTeste]
GO

CREATE TABLE [dbo].[tbTeste]
(
    [TST_CODIGO] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    [TST_NOME] NVARCHAR(100) NOT NULL,
    [TST_DESCRICAO] NVARCHAR(100) NOT NULL,
);
GO

INSERT INTO [dbo].[tbTeste] ([TST_NOME], [TST_DESCRICAO])
VALUES 
    ('Administrador', 'Admin'),
    ('Helder Junior', 'Usuario')
GO

SELECT * FROM [dbo].[tbTeste]
GO

----------------------------------------------------------

IF EXISTS (
SELECT *
    FROM INFORMATION_SCHEMA.ROUTINES
WHERE SPECIFIC_SCHEMA = N'dbo'
    AND SPECIFIC_NAME = N'InsereTeste'
    AND ROUTINE_TYPE = N'PROCEDURE'
)
DROP PROCEDURE dbo.InsereTeste
GO

CREATE PROCEDURE dbo.InsereTeste
    @codigo INT OUTPUT,
    @nome NVARCHAR(100),
    @descricao NVARCHAR(100)
AS
    INSERT INTO [dbo].[tbTeste]
    ( [TST_NOME], [TST_DESCRICAO] )
    VALUES
    ( @nome, @descricao )
    SET @codigo = (SELECT @@IDENTITY)
GO

----------------------------------------------------------

IF EXISTS (
SELECT *
    FROM INFORMATION_SCHEMA.ROUTINES
WHERE SPECIFIC_SCHEMA = N'dbo'
    AND SPECIFIC_NAME = N'AlteraTeste'
    AND ROUTINE_TYPE = N'PROCEDURE'
)
DROP PROCEDURE dbo.AlteraTeste
GO
CREATE PROCEDURE dbo.AlteraTeste
    @codigo INT,
    @nome NVARCHAR(100),
    @descricao NVARCHAR(100)
AS
    UPDATE [dbo].[tbTeste]
    SET
        [TST_NOME] = @nome,
        [TST_DESCRICAO] = @descricao

    WHERE TST_CODIGO = @codigo
GO

----------------------------------------------------------

IF EXISTS (
SELECT *
    FROM INFORMATION_SCHEMA.ROUTINES
WHERE SPECIFIC_SCHEMA = N'dbo'
    AND SPECIFIC_NAME = N'ExcluiTeste'
    AND ROUTINE_TYPE = N'PROCEDURE'
)
DROP PROCEDURE dbo.ExcluiTeste
GO
CREATE PROCEDURE dbo.ExcluiTeste
    @codigo int
AS
    DELETE FROM [dbo].[tbTeste]
    WHERE TST_CODIGO = @codigo
GO

-------------------------------------------------------------------------

IF EXISTS (
SELECT *
    FROM INFORMATION_SCHEMA.ROUTINES
WHERE SPECIFIC_SCHEMA = N'dbo'
    AND SPECIFIC_NAME = N'SelecionaTeste'
    AND ROUTINE_TYPE = N'PROCEDURE'
)
DROP PROCEDURE dbo.SelecionaTeste
GO
CREATE PROCEDURE dbo.SelecionaTeste
    @filtro NVARCHAR(100) = NULL
AS
    BEGIN
        IF @filtro IS NULL
            SELECT * FROM tbTeste
        ELSE
            SELECT * FROM tbTeste
            WHERE TST_NOME LIKE '%' + @filtro + '%'
            OR TST_DESCRICAO LIKE '%' + @filtro + '%'
    END    
GO