
UPDATE dbo.test1
	SET data = 'NewData3'
	WHERE Id = '3';

INSERT INTO dbo.test1 (id, data)
	VALUES ('5', 'Newdata5');