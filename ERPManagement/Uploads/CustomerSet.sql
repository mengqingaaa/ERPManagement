USE ERPManagement
GO

INSERT INTO CustomerSet (Code, Name, [Version], DBLoginName, DBLoginPassword, DBBizName, DBSysname)
	VALUES 
		('rgi', 'aaa', '4.0007', 'LoginName1', 'Passwd1', 'BizName1', 'SysName1'),
		('mms', 'bbb', '4.0003', 'LoginName2', 'Passwd2', 'BizName2', 'SysName2'),
		('krs', 'ccc', '4.0005', 'LoginName3', 'Passwd3', 'BizName3', 'SysName3'),
		('xxx', 'ddd', '4.0001', 'LoginName4', 'Passwd4', 'BizName4', 'SysName4');