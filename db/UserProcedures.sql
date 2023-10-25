USE [MeetingHUB]
GO

CREATE PROCEDURE [dbo].[InsertErrorLog]
AS
BEGIN
     INSERT INTO [LogDBErrors]  
         (
         UserName 
        ,ErrorNumber 
        ,ErrorState 
        ,ErrorSeverity 
        ,ErrorLine 
        ,ErrorProcedure
		,ErrorMessage
		,ErrorDateTime
       )
       VALUES
       (
		 SUSER_NAME()
        ,ERROR_NUMBER()
        ,ERROR_STATE()
        ,ERROR_SEVERITY()
        ,ERROR_LINE()
        ,ERROR_PROCEDURE()
        ,ERROR_MESSAGE()
        ,GETDATE()  
       );
END
GO



CREATE PROC UserRegister ( 
@email NVARCHAR(255), @passwordHash CHAR(88), @passwordSalt CHAR(88),
@phone VARCHAR(11), @imagePath NVARCHAR(MAX),
@name NVARCHAR (64), @surname NVARCHAR (128))
AS
BEGIN TRY
	BEGIN TRANSACTION UserRegister

	DECLARE @validEmail INT;
	SELECT @validEmail = u.UserID 
		FROM Users AS u WHERE u.Email = @email;

	IF(@validEmail IS NULL AND @email IS NOT NULL AND @phone IS NOT NULL AND @name IS NOT NULL AND @surname IS NOT NULL)
	BEGIN
		--Entry User
		DECLARE @userID INT;
		INSERT INTO Users(Email,UserName,UserSurname,Phone,ImagePath)
			VALUES(@email, @name,@surname,@phone,@imagePath);
		SET @userID = SCOPE_IDENTITY();
		--Entry UserCredentials
		INSERT INTO UserCredentials(UserID, PasswordHash, PasswordSalt)
			VALUES(@userID, @passwordHash, @passwordSalt);
	
	
	
	SELECT CAST(1 AS bit) AS [Success], @name AS [Name];
	END
	ELSE
	BEGIN
		SELECT CAST(0 AS bit) AS [Success], NULL AS [Name];
	END

	COMMIT TRANSACTION UserRegister
END TRY
BEGIN CATCH
	INSERT INTO dbo.LogDBErrors(Username, ErrorNumber, ErrorState, ErrorSeverity, ErrorLine, ErrorProcedure, ErrorMessage, ErrorDatetime)
		VALUES (SUSER_SNAME(), ERROR_NUMBER(), ERROR_STATE(), ERROR_SEVERITY(), ERROR_LINE(), ERROR_PROCEDURE(), ERROR_MESSAGE(), GETDATE());
	ROLLBACK TRANSACTION UserRegister
END CATCH
GO
--exec UserRegister @email = null ,@passwordHash='', @passwordSalt ='',
--@phone = null, @imagePath ='asdasdasdasdasdas',
--@name = 'Resul', @surname = 'KIZMAZ';

--select * from Users
--select * from UserCredentials
--select * from UserSessions

--select * from LogDBErrors

CREATE PROC LogInUser(@email NVARCHAR(255))
AS
BEGIN	
	
	DECLARE @validID INT;
	SELECT @validID = u.UserID 
		FROM Users AS u 
		INNER JOIN UserCredentials AS uc ON u.UserID = uc.UserID
			WHERE u.Email = @email;
	IF(@validID IS NOT NULL)
	BEGIN
		
		--RefreshToken döndürülebilir.

		SELECT CAST(1 AS bit) AS [Success], @email AS [Email], uc.PasswordHash AS [PasswordHash], uc.PasswordSalt AS [PasswordSalt],
				u.Phone AS [Phone],CONCAT(u.UserName,' ',u.UserSurname) AS [Name], u.ImagePath AS [ProfileImagePath]
				FROM Users AS u
				INNER JOIN UserCredentials AS uc ON uc.UserID = u.UserID
					WHERE u.Email = @email
	END
	ELSE
	BEGIN
		SELECT CAST(0 AS bit) AS [Success], NULL AS [Email], NULL AS [PasswordHash], NULL AS [PasswordSalt],
				NULL AS [Phone], NULL AS [Name], NULL AS [ProfileImagePath];
	END
END
GO
