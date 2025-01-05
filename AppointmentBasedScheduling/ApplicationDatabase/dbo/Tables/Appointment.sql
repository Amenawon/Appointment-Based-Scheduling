CREATE TABLE [dbo].[Appointment]
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
    CONSTRAINT [FK_Appointment_ToUser] FOREIGN KEY (Organiser) REFERENCES [User](Id), 
    CONSTRAINT [FK_Appointment_ToAttendee] FOREIGN KEY (Attendees) REFERENCES Attendee(Id)

)
