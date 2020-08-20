ALTER TABLE [dbo].[Teams] DROP CONSTRAINT [FK_dbo.Teams_dbo.Coaches_ID];

ALTER TABLE [dbo].[Athletes] DROP CONSTRAINT [FK_dbo.Athletes_dbo.Teams_ID];

ALTER TABLE [dbo].[Results] DROP CONSTRAINT [FK_dbo.Results_dbo.Athletes_ID];

ALTER TABLE [dbo].[Results] DROP CONSTRAINT [FK_dbo.Results_dbo.Events_ID];

DROP TABLE [dbo].[Results];

DROP TABLE [dbo].[Events];

DROP TABLE [dbo].[Athletes];

DROP TABLE [dbo].[Coaches];

DROP TABLE [dbo].[Teams];
