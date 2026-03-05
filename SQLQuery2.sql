-- 1. Nuke the existing broken table
DROP TABLE IF EXISTS [dbo].[PopulationStats];
GO

-- 2. Build the exact table your C# code needs
CREATE TABLE [dbo].[PopulationStats] (
    [Id]      INT NOT NULL PRIMARY KEY DEFAULT 1,
    [Males]   INT DEFAULT 0,
    [Females] INT DEFAULT 0,
    [Minors]  INT DEFAULT 0,
    [Adults]  INT DEFAULT 0,
    [Seniors] INT DEFAULT 0
);
GO

-- 3. Inject the blank starting row so the "Update" button works
INSERT INTO [dbo].[PopulationStats] (Id, Males, Females, Minors, Adults, Seniors) 
VALUES (1, 0, 0, 0, 0, 0);
GO