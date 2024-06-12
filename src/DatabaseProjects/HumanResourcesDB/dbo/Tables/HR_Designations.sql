CREATE TABLE [dbo].[HR_Designations] (
    [DesignationIndex] INT           IDENTITY (1, 1) NOT NULL,
    [DesignationName]  NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_HR_Designations] PRIMARY KEY CLUSTERED ([DesignationIndex] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_HR_Designations]
    ON [dbo].[HR_Designations]([DesignationName] ASC);

