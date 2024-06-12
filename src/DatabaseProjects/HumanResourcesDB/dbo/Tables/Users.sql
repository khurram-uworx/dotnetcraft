CREATE TABLE [dbo].[Users] (
    [UserIndex]    INT           IDENTITY (1, 1) NOT NULL,
    [UserEmail]    NVARCHAR (50) NOT NULL,
    [UserPassword] NVARCHAR (50) NOT NULL,
    [FirstName]    NVARCHAR (50) NOT NULL,
    [LastName]     NVARCHAR (50) NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED ([UserIndex] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_Users]
    ON [dbo].[Users]([UserEmail] ASC);

