CREATE TABLE [dbo].[HR_EmployeeLeaves] (
    [EmployeeIndex]  INT            NOT NULL,
    [LeaveTypeIndex] INT            NOT NULL,
    [LeaveDate]      DATETIME       NOT NULL,
    [LeaveCount]     DECIMAL (3, 1) NOT NULL,
    CONSTRAINT [PK_HR_EmployeeLeaves] PRIMARY KEY CLUSTERED ([EmployeeIndex] ASC, [LeaveDate] ASC),
    CONSTRAINT [FK_HR_EmployeeLeaves_HR_EmployeeLeaves] FOREIGN KEY ([LeaveTypeIndex]) REFERENCES [dbo].[HR_Leaves] ([LeaveTypeIndex]),
    CONSTRAINT [FK_HR_EmployeeLeaves_HR_Employees] FOREIGN KEY ([EmployeeIndex]) REFERENCES [dbo].[HR_Employees] ([EmployeeIndex])
);

