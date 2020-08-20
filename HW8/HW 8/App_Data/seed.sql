
-- ################### SEED DATA ######################

-- Extract data from .csv file and load into our db

-- Create a staging table to hold all the seed data.  We'll query this 
-- table in order to extract what we need to then insert into our real
-- tables.
CREATE TABLE [dbo].[AllData]
(
	[Location] NVARCHAR(50),
	[MeetDate] DATETIME,
	[Team] NVARCHAR(50),
	[Coach] NVARCHAR(50),
	[Event] NVARCHAR(20),
	[Gender] NVARCHAR(20),
	[Athlete] NVARCHAR(50),
	[RaceTime] REAL
);

-- Hard code the full path to the csv file.  It'll be better this way 
-- when we run this in HW 9 to build an Azure db 
BULK INSERT [dbo].[AllData]
	FROM 'C:\Users\lawyu\Documents\WOU\Fall 2019\CS 460\racetimes.csv'
	WITH
	(
		FIELDTERMINATOR = ',',
		ROWTERMINATOR = '\n',
		FIRSTROW = 2
	);

-- Load coaches data, no foreign keys here to worry about so we can 
-- do a straight insert of just the distinct values
INSERT INTO [dbo].[Coaches] ([CoachName])
	SELECT DISTINCT Coach from [dbo].[AllData];

-- Load Team data, a team has a coach so we need to find the correct entry in the 
-- Coaches table so we can set the foreign key appropriately
INSERT INTO [dbo].[Teams]
	([TeamName],[CoachID])
	SELECT DISTINCT ad.Team,cs.CoachID
		FROM [dbo].[AllData] as ad, [dbo].[Coaches] as cs
		WHERE ad.Coach = cs.CoachName;

-- Load all the other tables in a similar fashion.  Race results is the hardest since
-- it has several FK's.  Think joins.
INSERT INTO [dbo].[Athletes] 
	([AthleteName],[Gender],[TeamID])
	SELECT DISTINCT ad.Athlete, ad.Gender, te.TeamID
		FROM [dbo].[AllData] as ad, [dbo].[Teams] as te
		WHERE ad.Team = te.TeamName;

INSERT INTO [dbo].[Events]
	([Location], [Date], [Distance])
	SELECT DISTINCT ad.Location, ad.MeetDate, ad.Event
		FROM [dbo].[AllData] as ad;

INSERT INTO [dbo].[Results]
	([AthleteID],[EventID],[Time])
	SELECT at.AthleteID, ev.EventID, ad.RaceTime
		FROM [dbo].[AllData] as ad, [dbo].[Athletes] as at, [dbo].[Events] as ev
		WHERE ad.Athlete = at.AthleteName AND ad.Location = ev.Location AND ad.MeetDate = ev.Date AND ad.Event = ev.Distance;

-- We don't need this staging table anymore so clear it away
DROP TABLE [dbo].[AllData];
