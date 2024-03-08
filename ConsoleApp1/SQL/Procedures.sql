DROP PROCEDURE generateTables;
GO
CREATE PROCEDURE generateTables
AS
BEGIN
	CREATE TABLE Class (
		class_id INT IDENTITY,
		name NVARCHAR(256),
		description NVARCHAR(256),
		PRIMARY KEY (class_id),
	);

	CREATE TABLE StudentMng (
		student_id INT IDENTITY,
		class_id INT NULL,
		name NVARCHAR(256),
		dob DATETIME,
		code NVARCHAR(6),
		math INT NULL,
		phys INT NULL,

		PRIMARY KEY (student_id),
		FOREIGN KEY (class_id) REFERENCES Class(class_id) ON DELETE CASCADE,
	);
END;
GO

DROP PROCEDURE dropTables;
GO
CREATE PROCEDURE dropTables
AS
BEGIN
	DROP TABLE StudentMng;
	DROP TABLE Class;
END;
GO


DROP PROCEDURE generateData;
GO
CREATE PROCEDURE generateData
AS
BEGIN
	DECLARE @i int = 0
	
	SET IDENTITY_INSERT Class ON;
	WHILE @i < 20
	BEGIN
		INSERT INTO Class (class_id, name, description) values (@i, 'subject' + CAST(@i as varchar(2)), 'dsdafahgjkh');
		SET @i = @i + 1
	END;
	SET IDENTITY_INSERT Class OFF;


	SET @i = 0
	SET IDENTITY_INSERT StudentMng ON;
	WHILE @i < 20
	BEGIN
		INSERT INTO StudentMng (student_id, class_id, name, dob, code, math, phys) values (
			@i, 
			FLOOR(RAND()*20), 
			'Ayagama Lalalala', 
			CURRENT_TIMESTAMP, 
			'SV' + RIGHT('0000' + CONVERT(NVARCHAR(4), @i), 4),
			FLOOR(RAND() * 11),
			FLOOR(RAND() * 11));
		SET @i = @i + 1
	END
	SET IDENTITY_INSERT StudentMng OFF;
END;
GO

DROP PROCEDURE deleteAllData;
GO
CREATE PROCEDURE deleteAllData
AS
BEGIN
	DELETE FROM Class WHERE 1 = 1;
END;
GO