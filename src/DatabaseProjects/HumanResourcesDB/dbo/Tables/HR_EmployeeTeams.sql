CREATE TABLE [dbo].[HR_EmployeeTeams] (
    [EmployeeIndex] INT NOT NULL,
    [TeamIndex]     INT NOT NULL,
    CONSTRAINT [PK_HR_EmployeeTeams] PRIMARY KEY CLUSTERED ([EmployeeIndex] ASC, [TeamIndex] ASC),
    CONSTRAINT [FK_HR_EmployeeTeams_HR_Employees] FOREIGN KEY ([EmployeeIndex]) REFERENCES [dbo].[HR_Employees] ([EmployeeIndex]),
    CONSTRAINT [FK_HR_EmployeeTeams_HR_Teams] FOREIGN KEY ([TeamIndex]) REFERENCES [dbo].[HR_Teams] ([TeamIndex])
);

