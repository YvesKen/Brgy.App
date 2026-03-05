CREATE DATABASE BrgyDB;
GO
USE BrgyDB;
GO

-- This table MUST have FullName and CODE to match your AuthService.cs
CREATE TABLE Accounts (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Username NVARCHAR(50) NOT NULL,
    Password NVARCHAR(50) NOT NULL,
    FullName NVARCHAR(100) NOT NULL, -- Fixed: Matches your 'FullName' error
    CODE NVARCHAR(50) NOT NULL       -- Fixed: Matches your 'CODE' error
);

CREATE TABLE Residents (
    ResidentId INT PRIMARY KEY IDENTITY(1,1),
    FirstName NVARCHAR(50),
    LastName NVARCHAR(50),
    Age INT,
    Gender NVARCHAR(10),
    Address NVARCHAR(MAX),
    Status NVARCHAR(50)
);
GO