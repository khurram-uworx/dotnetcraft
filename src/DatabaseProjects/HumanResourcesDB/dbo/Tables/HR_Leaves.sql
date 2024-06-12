CREATE TABLE [dbo].[HR_Leaves] (
    [LeaveTypeIndex] INT           IDENTITY (1, 1) NOT NULL,
    [LeaveType]      NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_HR_Leaves] PRIMARY KEY CLUSTERED ([LeaveTypeIndex] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_HR_Leaves]
    ON [dbo].[HR_Leaves]([LeaveType] ASC);

