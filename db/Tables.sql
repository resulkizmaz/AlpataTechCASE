CREATE DATABASE [MeetingHUB]
GO

USE [MeetingHUB]
GO

CREATE TABLE LogDBErrors(
	ErrorID				INT				IDENTITY(1, 1),
	UserName			NVARCHAR(160)	NOT NULL,
	ErrorNumber			INT				NOT NULL,
	ErrorState			INT				NOT NULL,
	ErrorSeverity		INT				NOT NULL,
	ErrorLine			INT				NOT NULL,
	ErrorProcedure		NVARCHAR(MAX)	NOT NULL,
	ErrorMessage		NVARCHAR(MAX)	NOT NULL,
	ErrorDateTime		DATETIME		NOT NULL,

	CONSTRAINT	PK_LogDBErrors_ErrorID	PRIMARY KEY(ErrorID),
	INDEX	IX_LogDBErrors_ErrorDateTime	NONCLUSTERED (ErrorDateTime DESC),
);
GO

CREATE TABLE Users(
	UserID			INT				IDENTITY(1,1),
	Email			NVARCHAR(255)	NOT NULL,
	UserName		NVARCHAR (64)	NOT NULL,
	UserSurname		NVARCHAR (128)	NOT NULL,
	Phone			VARCHAR(11)		NOT NULL,
	ImagePath		NVARCHAR(MAX),
	CreationDate	DATETIME		NOT NULL	DEFAULT (GETDATE()),
	UpdateDate		DATETIME		NOT NULL	DEFAULT (GETDATE()),
	LoginDate		DATETIME
	--FA2 yapýsý (2 aþamalý kontrol) kullanýlabilir ancak tam anlamýyla hakim deðilim. Sadece nasýl çalýþtýðýný biliyorum.


	CONSTRAINT		PK_Users_UserID		PRIMARY KEY (UserID),
	CONSTRAINT		UX_Users_Email		UNIQUE(Email),
	INDEX			IX_Users_Email		NONCLUSTERED(Email ASC),
	);
GO

CREATE TABLE UserCredentials(
	UserID			INT				NOT NULL,
	PasswordHash	CHAR(88)		NOT NULL,
	PasswordSalt	CHAR(88)		NOT NULL,
	UpdateDate		DATETIME		NOT NULL		DEFAULT(GETDATE()), --Þifre güncellenmek istenebilir.

	CONSTRAINT		PK_UserCredentials_UserID	PRIMARY KEY (UserID),
	CONSTRAINT		FK_UserCredentials_UserID	FOREIGN KEY (UserID)	REFERENCES Users(UserID)
);
GO

CREATE TABLE UserSessions(
	UserID			INT				NOT NULL,
	RefreshToken	CHAR(64),
	RefreshTokenExp	DATETIME,
	UpdateDate		DATETIME		NOT NULL	DEFAULT(GETDATE()),

	CONSTRAINT	PK_UserSessions_UserID	PRIMARY KEY(UserID),
	CONSTRAINT	FK_UserSessions_UserID	FOREIGN KEY(UserID)		REFERENCES Users(UserID),
);
GO



CREATE TABLE Meetings(
	[MeetingID]		INT				IDENTITY(1,1),
	[UserID]		INT				NOT NULL,
	[MeetingName]	NVARCHAR(255)	NOT NULL,
	[StartDate]		DATETIME		NOT NULL,
	[EndDate]		DATETIME		NOT NULL,
	[Description]	NVARCHAR(MAX),
	[DocPath]		NVARCHAR(MAX),
	[CreationDate]	DATETIME		NOT NULL		DEFAULT(GETDATE())

	CONSTRAINT		PK_Meetings_MeetingID		PRIMARY KEY(MeetingID),
	CONSTRAINT		FK_Meetings_UserID			FOREIGN KEY(UserID)		REFERENCES Users(UserID),
	INDEX			IX_Meetings_MeetingName		NONCLUSTERED (MeetingName	ASC),
	INDEX			IX_Meetings_StartDate		NONCLUSTERED (StartDate	ASC),
	INDEX			IX_Meetings_EndDate			NONCLUSTERED (EndDate	ASC)
);
GO