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
	Authority		VARCHAR(16)		NOT NULL	DEFAULT('USER'),	--Kullan�c� ADMIN, USER, MANAGER olabilir.
	IsApproved		BIT,						--Onay s�reci olabilir.
	IsBanned		BIT				NOT NULL	DEFAULT (0),
	CreationDate	DATETIME		NOT NULL	DEFAULT (GETDATE()),
	UpdateDate		DATETIME		NOT NULL	DEFAULT (GETDATE()),
	LoginDate		DATETIME
	--FA2 yap�s� (2 a�amal� kontrol) kullan�labilir ancak tam anlam�yla hakim de�ilim. Sadece nas�l �al��t���n� biliyorum.


	CONSTRAINT		PK_Users_UserID		PRIMARY KEY (UserID),
	CONSTRAINT		UX_Users_Email		UNIQUE(Email),
	INDEX			IX_Users_Email		NONCLUSTERED(Email ASC),
	INDEX			IX_Users_IsApproved	NONCLUSTERED(IsApproved	DESC)	-- Onay s�reci varsa en son onaylanan ba�ta g�r�nt�lenmek istenebilir.
	);
GO

CREATE TABLE UserCredentials(
	UserID			INT				NOT NULL,
	PasswordHash	CHAR(88)		NOT NULL,
	PasswordSalt	CHAR(88)		NOT NULL,
	UpdateDate		DATETIME		NOT NULL		DEFAULT(GETDATE()), --�ifre g�ncellenmek istenebilir.

	CONSTRAINT		PK_UserCredentials_UserID	PRIMARY KEY (UserID),
	CONSTRAINT		FK_UserCredentials_UserID	FOREIGN KEY (UserID)	REFERENCES Users(UserID)
);
GO

CREATE TABLE Meetings(
	
);
GO