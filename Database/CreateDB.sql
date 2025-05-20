USE master;
GO
-- Drop database if exists
IF EXISTS (SELECT * FROM sys.databases WHERE name = 'SE18_PRN232_SE1731_G2_MaToe')
BEGIN
    ALTER DATABASE SE18_PRN232_SE1731_G2_MaToe SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE SE18_PRN232_SE1731_G2_MaToe;
END
GO

-- Create the database
CREATE DATABASE SE18_PRN232_SE1731_G2_MaToe;
GO

-- Switch context
USE SE18_PRN232_SE1731_G2_MaToe;
GO

-- ===== USER & ROLE MANAGEMENT =====

CREATE TABLE Role (
    RoleId   INT PRIMARY KEY IDENTITY,
    RoleName NVARCHAR(50) NOT NULL UNIQUE
);
GO


CREATE TABLE [User] (
    UserId     INT PRIMARY KEY IDENTITY,
    FullName   NVARCHAR(100),
    Email      NVARCHAR(100) UNIQUE,
    [Password] NVARCHAR(255),
    DateOfBirth DATE,
    Gender     NVARCHAR(10),
    RoleId     INT FOREIGN KEY REFERENCES Role(RoleId),
    CreatedAt  DATETIME DEFAULT GETDATE()
);
GO

-- ===== BLOG & ARTICLES =====

-- (Dropped the original Blog table as requested)

CREATE TABLE BlogMinhLH (
    BlogMinhLHId INT PRIMARY KEY IDENTITY,
    Title         NVARCHAR(200),
    Summary       NVARCHAR(500),
    Content       NVARCHAR(MAX),
    AuthorId      INT FOREIGN KEY REFERENCES [User](UserId),
    CreatedAt     DATETIME DEFAULT GETDATE(),
    UpdatedAt     DATETIME NULL,
    Status        NVARCHAR(50) DEFAULT 'Draft',
    Views         INT DEFAULT 0,
    Tags          NVARCHAR(200) NULL
);
GO

-- Child table for comments on BlogMinhLH
CREATE TABLE BlogMinhLHComment (
    CommentId    INT PRIMARY KEY IDENTITY,
    BlogMinhLHId INT NOT NULL,
    AuthorId     INT NULL,              -- nếu muốn lưu tác giả bình luận
    CommentText  NVARCHAR(MAX) NOT NULL,
    CreatedAt    DATETIME NOT NULL DEFAULT GETDATE(),
    CONSTRAINT FK_BlogMinhLHComment_BlogMinhLH
        FOREIGN KEY (BlogMinhLHId)
        REFERENCES BlogMinhLH(BlogMinhLHId)
        ON DELETE CASCADE
);
GO

-- ===== ONLINE COURSES =====

CREATE TABLE Course (
    CourseId    INT PRIMARY KEY IDENTITY,
    Title       NVARCHAR(200),
    Description NVARCHAR(MAX),
    TargetGroup NVARCHAR(100),
    IsActive    BIT DEFAULT 1
);
GO

CREATE TABLE CourseEnrollmentDuyenCTT (
    EnrollmentDuyenCTTId INT PRIMARY KEY IDENTITY,
    UserId               INT FOREIGN KEY REFERENCES [User](UserId),
    CourseId             INT FOREIGN KEY REFERENCES Course(CourseId),
    EnrolledAt           DATETIME DEFAULT GETDATE(),
    Progress             INT DEFAULT 0,
    CompletedAt          DATETIME NULL,
    Score                DECIMAL(5,2) NULL,
    CertificateUrl       NVARCHAR(500) NULL,
    IsCertified          BIT DEFAULT 0,
    EnrollmentSource     NVARCHAR(100) NULL
);
GO

-- ===== SURVEY / SCREENING TESTS =====

CREATE TABLE dbo.SurveyDuongND (
    SurveyDuongNDID               INT PRIMARY KEY IDENTITY,
    SurveyGUID                    UNIQUEIDENTIFIER DEFAULT NEWID(),
    Name                          NVARCHAR(255) NOT NULL,
    Title                         NVARCHAR(500),
    Description                   NVARCHAR(MAX),
    Purpose                       NVARCHAR(1000),
    Status                        NVARCHAR(50) DEFAULT 'Draft'
                                      CHECK (Status IN ('Draft','PendingReviewP1','PendingReviewP2','Active','Inactive','Archived')),
    Version                       INT DEFAULT 1,
    CreatedByUserId               INT FOREIGN KEY REFERENCES dbo.[User](UserId),
    LastModifiedByUserId          INT FOREIGN KEY REFERENCES dbo.[User](UserId),
    CreatedAt                     DATETIME DEFAULT GETDATE(),
    LastModifiedAt                DATETIME DEFAULT GETDATE(),
    TargetAudienceDescription     NVARCHAR(MAX),
    EstimatedCompletionTimeMinutes INT,
    AnonymityLevel                NVARCHAR(50)
                                      CHECK (AnonymityLevel IN ('FullyAnonymous','Identifiable','Pseudonymous')),
    WelcomeMessage                NVARCHAR(MAX),
    ThankYouMessage               NVARCHAR(MAX),
    ParentSurveyId                INT NULL
                                      FOREIGN KEY REFERENCES dbo.SurveyDuongND(SurveyDuongNDID)
);
GO

CREATE TABLE dbo.SurveyAssignment (
    SurveyAssignmentId INT PRIMARY KEY IDENTITY,
    SurveyId           INT NOT NULL
                         FOREIGN KEY REFERENCES dbo.SurveyDuongND(SurveyDuongNDID) ON DELETE CASCADE,
    UserId             INT NOT NULL FOREIGN KEY REFERENCES dbo.[User](UserId) ON DELETE CASCADE,
    RoleInSurvey       NVARCHAR(100) NOT NULL
                         CHECK (RoleInSurvey IN ('PrimaryOwner_P1','PrimaryOwner_P2','Contributor','Reviewer','Approver')),
    AssignmentDate     DATETIME DEFAULT GETDATE(),
    TaskDescription    NVARCHAR(MAX),
    IsActiveAssignment BIT DEFAULT 1,
    DueDate            DATE NULL,
    CONSTRAINT UQ_SurveyAssignment_SurveyUserRole UNIQUE (SurveyId, UserId, RoleInSurvey)
);
GO

CREATE TABLE dbo.QuestionBank (
    BankQuestionId   INT PRIMARY KEY IDENTITY,
    QuestionText     NVARCHAR(MAX) NOT NULL,
    QuestionType     NVARCHAR(50) NOT NULL
                      CHECK (QuestionType IN ('MultipleChoice','SingleChoice','Text','RatingScale','Matrix','Boolean','Date','Number')),
    Category         NVARCHAR(100),
    SubCategory      NVARCHAR(100) NULL,
    SuggestedOptionsJSON NVARCHAR(MAX) NULL,
    CreatedByUserId  INT FOREIGN KEY REFERENCES dbo.[User](UserId) ON DELETE SET NULL,
    CreatedAt        DATETIME DEFAULT GETDATE(),
    LastModifiedAt   DATETIME DEFAULT GETDATE(),
    Version          INT DEFAULT 1,
    Tags             NVARCHAR(255) NULL,
    IsArchived       BIT DEFAULT 0,
    LanguageCode     NVARCHAR(10) DEFAULT 'en-US'
);
GO

CREATE TABLE dbo.SurveyQuestionManhPT (
    QuestionId      INT PRIMARY KEY IDENTITY,
    SurveyId        INT NOT NULL FOREIGN KEY REFERENCES dbo.SurveyDuongND(SurveyDuongNDID) ON DELETE CASCADE,
    BankQuestionId  INT NULL FOREIGN KEY REFERENCES dbo.QuestionBank(BankQuestionId) ON DELETE SET NULL,
    QuestionText    NVARCHAR(MAX) NOT NULL,
    QuestionType    NVARCHAR(50) NOT NULL
                     CHECK (QuestionType IN ('MultipleChoice','SingleChoice','Text','RatingScale','Matrix','Boolean','Date','Number')),
    DisplayOrder    INT,
    IsMandatory     BIT DEFAULT 0,
    PointsPossible  DECIMAL(5,2) NULL,
    HintText        NVARCHAR(500) NULL,
    PageNumber      INT DEFAULT 1,
    SectionTitle    NVARCHAR(255) NULL,
    ParentQuestionId INT NULL
                     FOREIGN KEY REFERENCES dbo.SurveyQuestionManhPT(QuestionId),
    ConditionsJSON  NVARCHAR(MAX) NULL
);
GO

CREATE TABLE dbo.SurveyOptionManhPT (
    OptionId      INT PRIMARY KEY IDENTITY,
    QuestionId    INT NOT NULL FOREIGN KEY REFERENCES dbo.SurveyQuestionManhPT(QuestionId) ON DELETE CASCADE,
    OptionText    NVARCHAR(MAX) NOT NULL,
    Score         DECIMAL(5,2) NULL,
    DisplayOrder  INT,
    IsCorrectAnswer BIT NULL,
    FeedbackIfSelected NVARCHAR(MAX) NULL,
    ImageUrl      NVARCHAR(1024) NULL
);
GO

CREATE TABLE dbo.SurveyResultDuongND (
    ResultDuongNDID INT PRIMARY KEY IDENTITY,
    SurveyId        INT NOT NULL FOREIGN KEY REFERENCES dbo.SurveyDuongND(SurveyDuongNDID),
    UserId          INT NOT NULL FOREIGN KEY REFERENCES dbo.[User](UserId),
    TakenAt         DATETIME DEFAULT GETDATE(),
    CompletedAt     DATETIME NULL,
    Status          NVARCHAR(50) DEFAULT 'InProgress'
                    CHECK (Status IN ('InProgress','Completed','Abandoned','Partial')),
    TotalScore      DECIMAL(10,2) NULL,
    Recommendation  NVARCHAR(MAX) NULL,
    IPAddress       NVARCHAR(45) NULL,
    UserAgent       NVARCHAR(255) NULL,
    DurationSeconds AS DATEDIFF(SECOND, TakenAt, CompletedAt) PERSISTED,
    ReviewStatus    NVARCHAR(50) NULL
                    CHECK (ReviewStatus IN ('Pending','Reviewed','FlaggedForFollowUp','Actioned')),
    ReviewedByUserId INT NULL FOREIGN KEY REFERENCES dbo.[User](UserId) ON DELETE SET NULL,
    ReviewComments  NVARCHAR(MAX) NULL
);
GO

CREATE TABLE dbo.SurveyAnswerDuongND (
    AnswerDuongNDID INT PRIMARY KEY IDENTITY,
    ResultId        INT NOT NULL FOREIGN KEY REFERENCES dbo.SurveyResultDuongND(ResultDuongNDID) ON DELETE CASCADE,
    QuestionId      INT NOT NULL FOREIGN KEY REFERENCES dbo.SurveyQuestionManhPT(QuestionId),
    OptionId        INT NULL FOREIGN KEY REFERENCES dbo.SurveyOptionManhPT(OptionId),
    AnswerText      NVARCHAR(MAX) NULL,
    AnswerScore     DECIMAL(5,2) NULL,
    AnsweredAt      DATETIME DEFAULT GETDATE(),
    TimeSpentOnQuestionSeconds INT NULL
);
GO

-- ===== CONSULTANT MANAGEMENT & APPOINTMENTS =====

CREATE TABLE ConsultantMinhPP (
    ConsultantMinhPPId INT PRIMARY KEY IDENTITY,
    UserId             INT UNIQUE FOREIGN KEY REFERENCES [User](UserId),
    Specialization     NVARCHAR(255),
    Qualifications     NVARCHAR(MAX),
    Bio                NVARCHAR(MAX)
);
GO

CREATE TABLE ConsultantAvailability (
    AvailabilityId INT PRIMARY KEY IDENTITY,
    ConsultantId   INT FOREIGN KEY REFERENCES ConsultantMinhPP(ConsultantMinhPPId),
    AvailableDate  DATE,
    StartTime      TIME,
    EndTime        TIME
);
GO

CREATE TABLE AppointmentMinhPP (
    AppointmentMinhPPId INT PRIMARY KEY IDENTITY,
    UserId              INT FOREIGN KEY REFERENCES [User](UserId),
    ConsultantId        INT FOREIGN KEY REFERENCES ConsultantMinhPP(ConsultantMinhPPId),
    ScheduledDate       DATE,
    StartTime           TIME,
    EndTime             TIME,
    CreatedAt           DATETIME,
    UpdatedAt           DATETIME,
    Notes               NVARCHAR(MAX),
    [Status]            NVARCHAR(50) DEFAULT 'Pending'
);
GO

-- ===== COMMUNITY PROGRAMS =====

CREATE TABLE dbo.CommunityProgramKhoaNDD (
    CommunityProgramKhoaNDDId INT PRIMARY KEY IDENTITY,
    Title                     NVARCHAR(200),
    Description               NVARCHAR(MAX),
    StartDate                 DATE,
    EndDate                   DATE,
    TargetGroup               NVARCHAR(100),
    CreatedDate               DATETIME DEFAULT GETDATE(),
    LastEditedDate            DATETIME DEFAULT GETDATE(),
    CreatedBy                 INT FOREIGN KEY REFERENCES [User](UserId),
    EditedBy                  INT FOREIGN KEY REFERENCES [User](UserId)
);
GO

CREATE TABLE dbo.ProgramParticipantKhoaNDD (
    ProgramParticipantKhoaNDDId INT PRIMARY KEY IDENTITY,
    ProgramId                   INT FOREIGN KEY REFERENCES dbo.CommunityProgramKhoaNDD(CommunityProgramKhoaNDDId) ON DELETE CASCADE,
    UserId                      INT FOREIGN KEY REFERENCES dbo.[User](UserId) ON DELETE CASCADE,
    JoinedAt                    DATETIME DEFAULT GETDATE()
);
GO

CREATE TABLE ProgramSurvey (
    ProgramSurveyId INT PRIMARY KEY IDENTITY,
    ProgramId       INT FOREIGN KEY REFERENCES CommunityProgramKhoaNDD(CommunityProgramKhoaNDDId),
    SurveyId        INT FOREIGN KEY REFERENCES SurveyDuongND(SurveyDuongNDID),
    Type            NVARCHAR(50)  -- 'Pre' or 'Post'
);
GO
