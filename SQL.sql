-- 1. Create the Database
CREATE DATABASE BrgyDB;
GO

USE BrgyDB;
GO

-- 2. Create the Accounts table with columns matching your AuthService
CREATE TABLE Accounts (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Username NVARCHAR(50) NOT NULL UNIQUE,
    Password NVARCHAR(50) NOT NULL,
    FullName NVARCHAR(100) NOT NULL,
    CODE NVARCHAR(50) -- This stores the 'Honey123' key
);

-- 3. Create the Residents table (for your dashboard list)
CREATE TABLE Residents (
    Id INT PRIMARY KEY IDENTITY(1,1),
    FullName NVARCHAR(100),
    Age INT,
    Address NVARCHAR(MAX)
);

-- 4. Add your starting accounts
-- Admin Account (CODE matches "Honey123")
INSERT INTO Accounts (Username, Password, FullName, CODE) 
VALUES ('admin', 'admin123', 'Head Official', 'Honey123');

-- Resident Account (CODE is empty or different)
INSERT INTO Accounts (Username, Password, FullName, CODE) 
VALUES ('resident', 'user123', 'Juan Dela Cruz', 'NONE');
GO