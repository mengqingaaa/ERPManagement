USE ERPManagement
GO

INSERT INTO dbo.FuncMenuSet ( Name, UrlSection, ParentId, [Order])
	VALUES
		('RDLC', 'RDLC', 0, 1),
		('Application', 'Apply', 0, 2),
		('Admin', 'Admin', 0, 3),
		('SQL Execution', 'SqlExec', 0, 1);