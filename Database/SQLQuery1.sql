USE master;
GO
-- Check if the database exists
IF EXISTS(SELECT * FROM sys.databases WHERE name = 'SE18_PRN232_SE1731_G2_MaToe')
BEGIN
    -- If the database exists, drop it
    ALTER DATABASE SE18_PRN232_SE1731_G2_MaToe SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE SE18_PRN232_SE1731_G2_MaToe;
END
GO
-- Create the new database
CREATE DATABASE SE18_PRN232_SE1731_G2_MaToe;
GO
-- Switch context to the new database
USE SE18_PRN232_SE1731_G2_MaToe;
GO
-- ===== USER & ROLE MANAGEMENT =====
CREATE TABLE Role (
    RoleId INT PRIMARY KEY IDENTITY,
    RoleName NVARCHAR(50) NOT NULL UNIQUE
);

CREATE TABLE [User] (
    UserId INT PRIMARY KEY IDENTITY,
    FullName NVARCHAR(100),
    Email NVARCHAR(100) UNIQUE,
    PasswordHash NVARCHAR(255),
    DateOfBirth DATE,
    Gender NVARCHAR(10),
    RoleId INT FOREIGN KEY REFERENCES Role(RoleId),
    CreatedAt DATETIME DEFAULT GETDATE()
);

-- ===== BLOG & ARTICLES =====
CREATE TABLE Blog (
    BlogId INT PRIMARY KEY IDENTITY,
    Title NVARCHAR(200),
    Content NVARCHAR(MAX),
    AuthorId INT FOREIGN KEY REFERENCES [User](UserId),
    CreatedAt DATETIME DEFAULT GETDATE()
);

-- ===== ONLINE COURSES =====
CREATE TABLE Course (
    CourseId INT PRIMARY KEY IDENTITY,
    Title NVARCHAR(200),
    Description NVARCHAR(MAX),
    TargetGroup NVARCHAR(100), -- học sinh, sinh viên, phụ huynh, giáo viên, etc.
    IsActive BIT DEFAULT 1
);

CREATE TABLE CourseEnrollment (
    EnrollmentId INT PRIMARY KEY IDENTITY,
    UserId INT FOREIGN KEY REFERENCES [User](UserId),
    CourseId INT FOREIGN KEY REFERENCES Course(CourseId),
    EnrolledAt DATETIME DEFAULT GETDATE(),
    Progress INT DEFAULT 0 -- percentage
);

-- ===== SURVEY / SCREENING TESTS =====
CREATE TABLE Survey (
    SurveyId INT PRIMARY KEY IDENTITY,
    Name NVARCHAR(100), -- e.g., ASSIST, CRAFFT
    Description NVARCHAR(MAX)
);

CREATE TABLE SurveyQuestion (
    QuestionId INT PRIMARY KEY IDENTITY,
    SurveyId INT FOREIGN KEY REFERENCES Survey(SurveyId),
    QuestionText NVARCHAR(MAX),
    QuestionType NVARCHAR(20) -- e.g., single_choice, multiple_choice, text
);

CREATE TABLE SurveyOption (
    OptionId INT PRIMARY KEY IDENTITY,
    QuestionId INT FOREIGN KEY REFERENCES SurveyQuestion(QuestionId),
    OptionText NVARCHAR(255),
    Score INT
);

CREATE TABLE SurveyResult (
    ResultId INT PRIMARY KEY IDENTITY,
    UserId INT FOREIGN KEY REFERENCES [User](UserId),
    SurveyId INT FOREIGN KEY REFERENCES Survey(SurveyId),
    TotalScore INT,
    TakenAt DATETIME DEFAULT GETDATE(),
    Recommendation NVARCHAR(MAX)
);

CREATE TABLE SurveyAnswer (
    AnswerId INT PRIMARY KEY IDENTITY,
    ResultId INT FOREIGN KEY REFERENCES SurveyResult(ResultId),
    QuestionId INT FOREIGN KEY REFERENCES SurveyQuestion(QuestionId),
    OptionId INT NULL FOREIGN KEY REFERENCES SurveyOption(OptionId), -- optional for text questions
    AnswerText NVARCHAR(MAX) NULL
);

-- ===== CONSULTANT MANAGEMENT & APPOINTMENTS =====
CREATE TABLE Consultant (
    ConsultantId INT PRIMARY KEY IDENTITY,
    UserId INT UNIQUE FOREIGN KEY REFERENCES [User](UserId),
    Specialization NVARCHAR(255),
    Qualifications NVARCHAR(MAX),
    Bio NVARCHAR(MAX)
);

CREATE TABLE ConsultantAvailability (
    AvailabilityId INT PRIMARY KEY IDENTITY,
    ConsultantId INT FOREIGN KEY REFERENCES Consultant(ConsultantId),
    AvailableDate DATE,
    StartTime TIME,
    EndTime TIME
);

CREATE TABLE Appointment (
    AppointmentId INT PRIMARY KEY IDENTITY,
    UserId INT FOREIGN KEY REFERENCES [User](UserId),
    ConsultantId INT FOREIGN KEY REFERENCES Consultant(ConsultantId),
    ScheduledDate DATE,
    StartTime TIME,
    EndTime TIME,
    Status NVARCHAR(50) DEFAULT 'Pending', -- e.g., Pending, Confirmed, Completed
    Notes NVARCHAR(MAX)
);

-- ===== COMMUNITY PROGRAMS =====
CREATE TABLE CommunityProgram (
    ProgramId INT PRIMARY KEY IDENTITY,
    Title NVARCHAR(200),
    Description NVARCHAR(MAX),
    StartDate DATE,
    EndDate DATE,
    TargetGroup NVARCHAR(100)
);

CREATE TABLE ProgramParticipant (
    ProgramParticipantId INT PRIMARY KEY IDENTITY,
    ProgramId INT FOREIGN KEY REFERENCES CommunityProgram(ProgramId),
    UserId INT FOREIGN KEY REFERENCES [User](UserId),
    JoinedAt DATETIME DEFAULT GETDATE()
);

CREATE TABLE ProgramSurvey (
    ProgramSurveyId INT PRIMARY KEY IDENTITY,
    ProgramId INT FOREIGN KEY REFERENCES CommunityProgram(ProgramId),
    SurveyId INT FOREIGN KEY REFERENCES Survey(SurveyId),
    Type NVARCHAR(50) -- Pre or Post
);

-- ===== INITIAL SEEDING (Optional) =====
INSERT INTO Role (RoleName) VALUES
('Guest'), ('Member'), ('Staff'), ('Consultant'), ('Manager'), ('Admin');
