CREATE TABLE [dbo].[Attendees] (
    [Id]           INT            IDENTITY (1, 1) NOT NULL,
    [UserId]       NVARCHAR (128) NULL,
    [FirstName]    NVARCHAR (50)  NOT NULL,
    [LastName]     NVARCHAR (50)  NOT NULL,
    [Email]        NVARCHAR (256) NOT NULL,
    [IsRegistered] BIT            DEFAULT ((1)) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Attendees_ToUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([Id])
);

