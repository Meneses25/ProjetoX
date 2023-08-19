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

IF OBJECT_ID('[dbo].[tbFornecedor]', 'U') IS NOT NULL
DROP TABLE [dbo].[tbFornecedor] 
GO

CREATE TABLE [dbo].[tbFornecedor] 
(
    [FOR_CODIGO] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    [FOR_NOME] NVARCHAR(100) NOT NULL,
    [FOR_TELEFONE] NVARCHAR(100) NOT NULL,
	[FOR_CNPJ] NVARCHAR(100) NOT NULL,
	[FOR_ENDERECO] NVARCHAR(100) NOT NULL,
);
GO

INSERT INTO [dbo].[tbFornecedor] ([FOR_NOME], [FOR_TELEFONE], [FOR_CNPJ], [FOR_ENDERECO])
VALUES 
    ('JO�O', 'ATENDENTE', 'TESTEJOAO', 'JOAO123'),
    ('MARIA', 'VENDEDOR', 'TESTEMARIA', 'MARIA123'),
	('CARLOS', 'GERENTE', 'TESTEMCARLOS', 'CARLOS123')
GO

SELECT * FROM [dbo].[tbFornecedor]
GO

----------------------------------------------------------

IF EXISTS (
SELECT *
    FROM INFORMATION_SCHEMA.ROUTINES
WHERE SPECIFIC_SCHEMA = N'dbo'
    AND SPECIFIC_NAME = N'InsereFornecedor'
    AND ROUTINE_TYPE = N'PROCEDURE'
)
DROP PROCEDURE dbo.InsereFornecedor
GO

CREATE PROCEDURE dbo.InsereFornecedor
    @codigo INT OUTPUT,
    @nome NVARCHAR(100),
    @telefone NVARCHAR(100),
	@cnpj NVARCHAR(100),
	@endereco NVARCHAR(100)
AS
    INSERT INTO [dbo].[tbFornecedor]
    ( [FOR_NOME], [FOR_TELEFONE], [FOR_CNPJ], [FOR_ENDERECO] )
    VALUES
    ( @nome, @telefone, @cnpj, @endereco )
    SET @codigo = (SELECT @@IDENTITY)
GO

----------------------------------------------------------

----------------------------------------------------------

IF EXISTS (
SELECT *
    FROM INFORMATION_SCHEMA.ROUTINES
WHERE SPECIFIC_SCHEMA = N'dbo'
    AND SPECIFIC_NAME = N'AlteraFornecedor'
    AND ROUTINE_TYPE = N'PROCEDURE'
)
DROP PROCEDURE dbo.AlteraFornecedor
GO
CREATE PROCEDURE dbo.AlteraFornecedor
    @codigo INT,
    @nome NVARCHAR(100),
    @telefone NVARCHAR(100),
	@cnpj NVARCHAR(100),
	@endereco NVARCHAR(100)
AS
    UPDATE [dbo].[tbFornecedor]
    SET
        [FOR_NOME] = @nome,
        [FOR_TELEFONE] = @telefone,
		[FOR_CNPJ] = @cnpj,
		[FOR_ENDERECO] = @endereco

    WHERE FOR_CODIGO = @codigo
GO

----------------------------------------------------------
----------------------------------------------------------

IF EXISTS (
SELECT *
    FROM INFORMATION_SCHEMA.ROUTINES
WHERE SPECIFIC_SCHEMA = N'dbo'
    AND SPECIFIC_NAME = N'ExcluiFornecedor'
    AND ROUTINE_TYPE = N'PROCEDURE'
)
DROP PROCEDURE dbo.ExcluiFornecedor
GO
CREATE PROCEDURE dbo.ExcluiFornecedor
    @codigo int
AS
    DELETE FROM [dbo].[tbFornecedor]
    WHERE FOR_CODIGO = @codigo
GO

-------------------------------------------------------------------------

IF EXISTS (
SELECT *
    FROM INFORMATION_SCHEMA.ROUTINES
WHERE SPECIFIC_SCHEMA = N'dbo'
    AND SPECIFIC_NAME = N'SelecionaFornecedor'
    AND ROUTINE_TYPE = N'PROCEDURE'
)
DROP PROCEDURE dbo.SelecionaFornecedor
GO
CREATE PROCEDURE dbo.SelecionaFornecedor
    @filtro NVARCHAR(100) = NULL
AS
    BEGIN
        IF @filtro IS NULL
            SELECT FOR_CODIGO, FOR_NOME, FOR_TELEFONE, FOR_CNPJ, FOR_ENDERECO FROM tbFornecedor
        ELSE
            SELECT FOR_CODIGO, FOR_NOME, FOR_TELEFONE, FOR_CNPJ, FOR_ENDERECO FROM tbFornecedor
            WHERE FOR_CODIGO, LIKE '%' + @filtro + '%'
			OR FOR_NOME, LIKE '%' + @filtro + '%'
            OR FOR_TELEFONE, LIKE '%' + @filtro + '%'
			OR FOR_CNPJ, LIKE '%' + @filtro + '%'
			OR FOR_ENDERECO LIKE '%' + @filtro + '%'
    END    
GO