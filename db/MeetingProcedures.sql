USE [MeetingHUB]
GO

CREATE PROC SetMeeting(
@userID INT, @meetingName NVARCHAR(255),@startDate DATETIME, @endDate DATETIME,
@desc NVARCHAR(MAX) NULL, @docPath NVARCHAR(MAX) NULL)
AS
BEGIN TRY
	BEGIN TRANSACTION SetMeeting
	DECLARE @validID INT;

	SELECT	@validID = m.MeetingID
		FROM Meetings AS m 
			WHERE m.MeetingName = @meetingName AND m.UserID = @userID;
	
	IF(@validID IS NULL)
	BEGIN
		INSERT INTO Meetings(UserID,MeetingName,StartDate,EndDate,[Description],DocPath)
			VALUES (@userID,@meetingName,@startDate,@endDate,@desc,@docPath);

		SELECT CAST(1 AS BIT) AS [Success], @meetingName AS [MeetingName], @startDate AS [StartDate],
				@endDate AS [EndDate], @desc AS [Description], @docPath AS [DocPath];
	END

	ELSE
	BEGIN
		SELECT CAST(0 AS BIT) AS [Success], NULL AS [MeetingName], NULL AS [StartDate],
				NULL AS [EndDate], NULL AS [Description], NULL AS [DocPath];
	END
	COMMIT TRANSACTION SetMeeting
END TRY
BEGIN CATCH
	INSERT INTO dbo.LogDBErrors(Username, ErrorNumber, ErrorState, ErrorSeverity, ErrorLine, ErrorProcedure, ErrorMessage, ErrorDatetime)
		VALUES (SUSER_SNAME(), ERROR_NUMBER(), ERROR_STATE(), ERROR_SEVERITY(), ERROR_LINE(), ERROR_PROCEDURE(), ERROR_MESSAGE(), GETDATE());
	ROLLBACK TRANSACTION SetMeeting
END CATCH
GO


CREATE PROC GetAllMeetings @userID INT
AS
BEGIN	
	SELECT m.MeetingName, m.StartDate, m.EndDate, m.[Description], m.DocPath, m.CreationDate
		FROM Meetings AS m
		WHERE m.UserID = @userID;	
END
GO


CREATE PROC DeleteMeeting @userID INT, @meetingID INT
AS
BEGIN
	IF EXISTS (SELECT 1 FROM Meetings WHERE MeetingID = @meetingID AND UserID = @userID)
    BEGIN        
		SELECT CAST(1 AS BIT) AS [Success], @meetingID AS [MeetingID];

        DELETE FROM Meetings
        WHERE MeetingID = @meetingID;		
    END
    ELSE
    BEGIN
        SELECT CAST(0 AS BIT) AS [Success], NULL AS [MeetingID];
    END
END
