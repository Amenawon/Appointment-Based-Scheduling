CREATE TABLE [dbo].[Appointments]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[Title] NVARCHAR(100) NOT NULL,
	[Description] NVARCHAR(MAX) NOT NULL,
	[Date] DATETIME2 NOT NULL DEFAULT getutcdate(),
	[Duration] INT NOT NULL,
	[Location] NVARCHAR(100) NOT NULL,
	[Status] NVARCHAR(50) NOT NULL,
	[Attendees] INT NOT NULL,
	[Organiser] NVARCHAR(128) NOT NULL,
	[CreateDate] DATETIME2 NOT NULL DEFAULT getutcdate(), 
    CONSTRAINT [FK_Appointments_ToUsers] FOREIGN KEY (Organiser) REFERENCES Users(Id), 
    CONSTRAINT [FK_Appointments_ToAttendees] FOREIGN KEY (Attendees) REFERENCES Attendees(Id)

)
