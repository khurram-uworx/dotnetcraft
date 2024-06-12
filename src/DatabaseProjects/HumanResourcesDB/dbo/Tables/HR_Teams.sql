CREATE TABLE [dbo].[HR_Teams] (
    [TeamIndex]            INT           IDENTITY (1, 1) NOT NULL,
    [ManagerEmployeeIndex] INT           NOT NULL,
    [TeamName]             NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_HR_Teams] PRIMARY KEY CLUSTERED ([TeamIndex] ASC),
    CONSTRAINT [FK_HR_Teams_HR_Employees] FOREIGN KEY ([ManagerEmployeeIndex]) REFERENCES [dbo].[HR_Employees] ([EmployeeIndex])
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_HR_Teams]
    ON [dbo].[HR_Teams]([TeamName] ASC);

