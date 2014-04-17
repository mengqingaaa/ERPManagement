USE ERPManagement
GO

INSERT INTO CustomerSet (Code, Name, [Version], SIerManaged, DBServerName, DBLoginName, DBLoginPassword, DBBizName, DBSysname)
	VALUES 
		('rgi', 'aaa', '4.0007', 0, '(localdb)\v11.0', 'LoginName1', 'Passwd1', 'BizName1', 'SysName1'),
		('mms', 'bbb', '4.0003', 0, '(localdb)\v11.0', 'LoginName2', 'Passwd2', 'BizName2', 'SysName2'),
		('krs', 'ccc', '4.0005', 0, '(localdb)\v11.0', 'LoginName3', 'Passwd3', 'BizName3', 'SysName3'),
		('xxx', 'ddd', '4.0001', 1, '(localdb)\v11.0', 'UserTest1', 'ZAQ!2wsx', 'BizTest1', 'SysTest1'),
		('zzz', 'eee', '4.0007', 1, '(localdb)\v11.0', 'UserTest2', 'ZAQ!2wsx', 'BizTest2', 'SysTest2')