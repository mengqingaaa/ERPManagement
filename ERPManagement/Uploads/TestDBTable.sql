USE BizTest1
GO

IF OBJECT_ID('dbo.tableTest1') IS NOT NULL DROP TABLE dbo.tableTest1

CREATE TABLE dbo.tableTest1
(
	[Id] INT IDENTITY PRIMARY KEY,
	[data] varchar(100) NOT NULL,
	[timeStamp] DATETIME
)

USE BizTest2
GO

IF OBJECT_ID('dbo.tableTest2') IS NOT NULL DROP TABLE dbo.tableTest2

CREATE TABLE dbo.tableTest2
(
	[Id] INT IDENTITY PRIMARY KEY,
	[data] VARCHAR(100) NOT NULL,
	[timeStamp] DATETIME
)

USE BizTest1
GO

INSERT INTO dbo.tableTest1 (data)
	VALUES
		('DATA1'),
		('DATA2'),
		('DATA3'),
		('DATA4');

USE BizTest2
GO

INSERT INTO dbo.tableTest2 (data)
	VALUES
		('DATA1'),
		('DATA2'),
		('DATA3'),
		('DATA4'),
		('DATA5');