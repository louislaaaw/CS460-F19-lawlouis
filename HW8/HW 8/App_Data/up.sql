CREATE TABLE [dbo].[Coaches](
	[CoachID] INT IDENTITY (1,1) NOT NULL,
	[CoachName] VARCHAR(64) NOT NULL,
	CONSTRAINT [PK_dbo.Coaches] PRIMARY KEY CLUSTERED ([CoachID] ASC)
);

CREATE TABLE [dbo].[Teams](
	[TeamID] INT IDENTITY (1,1) NOT NULL,
	[TeamName] VARCHAR(64) NOT NULL,
	[CoachID] INT NOT NULL,
	CONSTRAINT [PK_dbo.Teams] PRIMARY KEY CLUSTERED ([TeamID] ASC),
	CONSTRAINT [FK_dbo.Teams_dbo.Coaches_ID] FOREIGN KEY ([CoachID]) REFERENCES [dbo].[Coaches] ([CoachID])
);

CREATE TABLE [dbo].[Athletes](
	[AthleteID]	INT IDENTITY (1,1) NOT NULL,
	[AthleteName] VARCHAR(64) NOT NULL,
	[Gender] VARCHAR(8) NOT NULL,
	[TeamID] INT NOT NULL,
	CONSTRAINT [PK_dbo.Athletes] PRIMARY KEY CLUSTERED ([AthleteID] ASC),
	CONSTRAINT [FK_dbo.Athletes_dbo.Teams_ID] FOREIGN KEY ([TeamID]) REFERENCES [dbo].[Teams] ([TeamID])
);

CREATE TABLE [dbo].[Events](
	[EventID] INT IDENTITY (1,1) NOT NULL,
	[Location] VARCHAR(64),
	[Date] DATE ,
	[Distance] INT ,
	CONSTRAINT [PK_dbo.Events] PRIMARY KEY CLUSTERED ([EventID] ASC)
);

CREATE TABLE [dbo].[Results](
	[ResultID] INT IDENTITY (1,1) NOT NULL,
	[AthleteID] INT NOT NULL,
	[EventID] INT NOT NULL,
	[Time] REAL ,
	CONSTRAINT [PK_dbo.Results] PRIMARY KEY CLUSTERED ([ResultID] ASC),
	CONSTRAINT [FK_dbo.Results_dbo.Athletes_ID] FOREIGN KEY ([AthleteID]) REFERENCES [dbo].[Athletes] ([AthleteID]),
	CONSTRAINT [FK_dbo.Results_dbo.Events_ID] FOREIGN KEY ([EventID]) REFERENCES [dbo].[Events] ([EventID])
);