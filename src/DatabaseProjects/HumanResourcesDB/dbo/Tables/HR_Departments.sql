CREATE TABLE [dbo].[HR_Departments] (
    [DepartmentIndex] INT           IDENTITY (1, 1) NOT NULL,
    [DepartmentName]  NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_HR_Departments] PRIMARY KEY CLUSTERED ([DepartmentIndex] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_HR_Departments]
    ON [dbo].[HR_Departments]([DepartmentName] ASC);

