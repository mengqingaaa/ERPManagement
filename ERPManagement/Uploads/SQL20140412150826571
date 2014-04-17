USE BizTest1
GO

UPDATE dbo.tableTest1
	SET data = 'DATATest', [timeStamp] = GETDATE()
	WHERE [Id] = 2;

INSERT INTO dbo.tableTest1 (data, [timeStamp])
	VALUES
		('DATANew', GETDATE());

DELETE dbo.tableTest1
	WHERE [Id] = 3;