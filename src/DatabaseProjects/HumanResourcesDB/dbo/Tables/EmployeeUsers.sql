CREATE TABLE [dbo].[EmployeeUsers] (
    [EmployeeIndex] INT NOT NULL,
    [UserIndex]     INT NOT NULL,
    CONSTRAINT [PK_EmployeeUsers] PRIMARY KEY CLUSTERED ([EmployeeIndex] ASC, [UserIndex] ASC)
);

