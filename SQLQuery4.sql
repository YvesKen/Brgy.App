USE BrgyDB;
GO

CREATE TABLE PopulationStats (
    Category NVARCHAR(50) PRIMARY KEY, -- 'Male', 'Female', 'Minors', etc.
    TotalCount INT DEFAULT 0
);

-- Seed initial data
INSERT INTO PopulationStats (Category, TotalCount) VALUES 
('Male', 120), ('Female', 130), ('Minors', 45), 
('Adults', 180), ('Seniors', 25);
GO