﻿CREATE TABLE [dbo].[Users]
(
	[Id] NVARCHAR(128) NOT NULL PRIMARY KEY,
	[FirstName] NVARCHAR(50) NOT NULL,
	[LastName] NVARCHAR(50) NOT NULL,
	[Email] NVARCHAR(256) NOT NULL,
	[Organisation] NVARCHAR(80),
	[CreateDate] DATETIME2 NOT NULL DEFAULT getutcdate()
)
