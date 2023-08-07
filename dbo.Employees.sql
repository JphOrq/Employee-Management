CREATE TABLE [dbo].[Employees] (
    [Id]         INT            IDENTITY (1, 1) NOT NULL,
    [FirstName]  NVARCHAR (50)  NOT NULL,
    [MiddleName] NVARCHAR (50)  NOT NULL,
    [LastName]   NVARCHAR (50)  NOT NULL,
    [Address]    NVARCHAR (MAX) NULL,
    [BirthDate]  DATETIME2 (7)  NOT NULL,
    [Email]      NVARCHAR (MAX) NOT NULL,
    [Department] INT            NOT NULL,
    [Salary]     INT            NOT NULL,
    CONSTRAINT [PK_Employees] PRIMARY KEY CLUSTERED ([Id] ASC)
);