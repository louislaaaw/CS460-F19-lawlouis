CREATE TABLE [dbo].[Homeworks]
(
	[ID]		INT IDENTITY (1,1)	NOT NULL,
	[Priority]  INT				NOT NULL,
	[DueDate]	DATE		NOT NULL,
	[DueTime]	TIME		NOT NULL,
	[Department] NVARCHAR(32)	NOT NULL,
	[Course]	INT				NOT NULL,
	[HomeworkTitle] NVARCHAR(64)	NOT NULL,
	[Note] NVARCHAR(256),
	CONSTRAINT [PK_dbo.Homeworks] PRIMARY KEY CLUSTERED ([ID] ASC)
);

INSERT INTO [dbo].[Homeworks] (Priority, DueDate, DueTime, Department, Course, HomeworkTitle, Note) VALUES
	(1, '2019-11-02', '23:59:59', 'CS', 460, 'Lab5', NULL),
	(2, '2019-12-02', '23:59:59', 'MTH', 354, 'HW10', 'Show all the formulas'),
	(5, '2020-11-02', '23:59:59', 'CS', 363, 'Lab1', NULL),
	(3, '2020-01-02', '23:59:59', 'MTH', 344, 'Lab5', 'Proof by induction'),
	(2, '2019-11-25', '23:59:59', 'IS', 355, 'HW7', 'Cannot use internet')
GO
