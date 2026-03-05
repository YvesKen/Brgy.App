CREATE TABLE OfficialAttendance (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    Position NVARCHAR(50) NOT NULL,
    CurrentStatus NVARCHAR(50) NOT NULL,
    Remarks NVARCHAR(255) NULL,
    TotalPresent INT DEFAULT 0,
    TotalAbsent INT DEFAULT 0,
    TotalLeave INT DEFAULT 0
);