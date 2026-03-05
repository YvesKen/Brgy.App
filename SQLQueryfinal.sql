-- 1. Create the Database container
CREATE DATABASE BrgyDB;
GO

USE BrgyDB;
GO

-- 2. Create Accounts table (Matches your AuthService SELECT & INSERT)
CREATE TABLE Accounts (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Username NVARCHAR(50) NOT NULL UNIQUE,
    Password NVARCHAR(50) NOT NULL,
    FullName NVARCHAR(100) NOT NULL, -- Required for your AuthService.cs
    CODE NVARCHAR(50) NOT NULL       -- Used for the 'Honey123' IsOfficial check
);

-- 3. Create Residents table (Matches your ResidentService & Resident Domain)
CREATE TABLE Residents (
    ResidentId INT PRIMARY KEY IDENTITY(1,1), -- Matches Resident.cs property
    FirstName NVARCHAR(50) NOT NULL,
    LastName NVARCHAR(50) NOT NULL,
    Age INT NOT NULL,
    Gender NVARCHAR(10),
    Address NVARCHAR(MAX),
    Status NVARCHAR(20) DEFAULT 'Active'      -- Matches Resident.Status
);

-- 4. Add initial login data so you can test immediately
INSERT INTO Accounts (Username, Password, FullName, CODE) 
VALUES ('admin', 'admin123', 'Brgy Administrator', 'Honey123');

-- 5. Add a test resident for your Dashboard
INSERT INTO Residents (FirstName, LastName, Age, Gender, Address, Status)
VALUES ('Juan', 'Dela Cruz', 30, 'Male', 'Poblacion District', 'Active');
GO