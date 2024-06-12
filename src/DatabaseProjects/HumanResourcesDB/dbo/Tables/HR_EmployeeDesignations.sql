CREATE TABLE [dbo].[HR_EmployeeDesignations] (
    [EmployeeIndex]    INT      NOT NULL,
    [DesignationIndex] INT      NOT NULL,
    [StartDate]        DATETIME CONSTRAINT [DF_HR_EmployeeDesignations_StartDate] DEFAULT (getdate()) NOT NULL,
    [EndDate]          DATETIME NULL,
    CONSTRAINT [PK_HR_EmployeeDesignations] PRIMARY KEY CLUSTERED ([EmployeeIndex] ASC, [DesignationIndex] ASC),
    CONSTRAINT [FK_HR_EmployeeDesignations_HR_Designations] FOREIGN KEY ([DesignationIndex]) REFERENCES [dbo].[HR_Designations] ([DesignationIndex]),
    CONSTRAINT [FK_HR_EmployeeDesignations_HR_Employees] FOREIGN KEY ([EmployeeIndex]) REFERENCES [dbo].[HR_Employees] ([EmployeeIndex])
);

