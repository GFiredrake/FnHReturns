GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "C:\DEV\FNHRETURNS\FOOLS AND HEROES RETURNS\FOOLS AND HEROES RETURNS\APP_DATA\PLAYERDATABASE.MDF"
:setvar DefaultFilePrefix "C_\DEV\FNHRETURNS\FOOLS AND HEROES RETURNS\FOOLS AND HEROES RETURNS\APP_DATA\PLAYERDATABASE.MDF_"
:setvar DefaultDataPath "C:\Users\Seraphym\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\v11.0\"
:setvar DefaultLogPath "C:\Users\Seraphym\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\v11.0\"

GO
:on error exit
GO
/*
Detect SQLCMD mode and disable script execution if SQLCMD mode is not supported.
To re-enable the script after enabling SQLCMD mode, execute the following:
SET NOEXEC OFF; 
*/
:setvar __IsSqlCmdEnabled "True"
GO
IF N'$(__IsSqlCmdEnabled)' NOT LIKE N'True'
    BEGIN
        PRINT N'SQLCMD mode must be enabled to successfully execute this script.';
        SET NOEXEC ON;
    END


GO
USE [$(DatabaseName)];


GO
PRINT N'Rename refactoring operation with key  is skipped, element [dbo].[Members].[Surname] (SqlSimpleColumn) will not be renamed to SurName';


GO

IF (SELECT OBJECT_ID('tempdb..#tmpErrors')) IS NOT NULL DROP TABLE #tmpErrors
GO
CREATE TABLE #tmpErrors (Error int)
GO
SET XACT_ABORT ON
GO
SET TRANSACTION ISOLATION LEVEL READ COMMITTED
GO
BEGIN TRANSACTION
GO
PRINT N'Creating [dbo].[Members]...';


GO
CREATE TABLE [dbo].[Members] (
    [Id]        INT           NOT NULL,
    [UserName]  NVARCHAR (50) NOT NULL,
    [Password]  NVARCHAR (50) NOT NULL,
    [Branch]    INT           NULL,
    [FirstName] NVARCHAR (50) NOT NULL,
    [SurName]   NVARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
IF @@ERROR <> 0
   AND @@TRANCOUNT > 0
    BEGIN
        ROLLBACK;
    END

IF @@TRANCOUNT = 0
    BEGIN
        INSERT  INTO #tmpErrors (Error)
        VALUES                 (1);
        BEGIN TRANSACTION;
    END


GO

IF EXISTS (SELECT * FROM #tmpErrors) ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT>0 BEGIN
PRINT N'The transacted portion of the database update succeeded.'
COMMIT TRANSACTION
END
ELSE PRINT N'The transacted portion of the database update failed.'
GO
DROP TABLE #tmpErrors
GO
PRINT N'Update complete.';


GO
