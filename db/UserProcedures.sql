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
		INSERT INTO Users(Email)
			VALUES(@email, );
		SET @userID = SCOPE_IDENTITY();
		--Entry UserCredentials
		INSERT INTO UserCredentials(UserID, PasswordHash, PasswordSalt)
			VALUES(@userID, @passwordHash, @passwordSalt);
	
	SELECT @userID AS [UserID], @phone AS [Phone], @name AS [Name], @surname AS [Surname], 
		   @imagePath AS [ImagePath]

	END


	COMMIT TRANSACTION UserRegister
END TRY
BEGIN CATCH
	ROLLBACK TRANSACTION UserRegister
	INSERT INTO dbo.LogDBErrors(Username, ErrorNumber, ErrorState, ErrorSeverity, ErrorLine, ErrorProcedure, ErrorMessage, ErrorDatetime)
		VALUES (SUSER_SNAME(), ERROR_NUMBER(), ERROR_STATE(), ERROR_SEVERITY(), ERROR_LINE(), ERROR_PROCEDURE(), ERROR_MESSAGE(), GETDATE());
END CATCH