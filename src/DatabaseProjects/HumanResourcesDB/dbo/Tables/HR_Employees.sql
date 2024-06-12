CREATE TABLE [dbo].[HR_Employees] (
    [EmployeeIndex]        INT           IDENTITY (1, 1) NOT NULL,
    [DepartmentIndex]      INT           NOT NULL,
    [DesignationIndex]     INT           NOT NULL,
    [ManagerEmployeeIndex] INT           NOT NULL,
    [FirstName]            NVARCHAR (50) NOT NULL,
    [MiddleName]           NVARCHAR (50) NULL,
    [LastName]             NVARCHAR (50) NULL,
    [CreatedDate]          DATETIME      CONSTRAINT [DF_HR_Employees_CreatedDate] DEFAULT (getdate()) NOT NULL,
    [ModifiedDate]         DATETIME      NULL,
    CONSTRAINT [PK_HR_Employees] PRIMARY KEY CLUSTERED ([EmployeeIndex] ASC),
    CONSTRAINT [FK_HR_Employees_HR_Departments] FOREIGN KEY ([DepartmentIndex]) REFERENCES [dbo].[HR_Departments] ([DepartmentIndex]),
    CONSTRAINT [FK_HR_Employees_HR_Designations] FOREIGN KEY ([DesignationIndex]) REFERENCES [dbo].[HR_Designations] ([DesignationIndex]),
    CONSTRAINT [FK_HR_Employees_HR_Employees] FOREIGN KEY ([ManagerEmployeeIndex]) REFERENCES [dbo].[HR_Employees] ([EmployeeIndex])
);

