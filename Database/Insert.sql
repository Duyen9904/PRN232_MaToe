use SE18_PRN232_SE1731_G2_MaToe
GO
-- Role table already has data, but let's ensure correct data is there
INSERT INTO Role (RoleName) VALUES
('Guest'), ('Member'), ('Staff'), ('Consultant'), ('Manager'), ('Admin');

-- User table data
INSERT INTO [User] (FullName, Email, [Password], DateOfBirth, Gender, RoleId, CreatedAt) VALUES
('John Smith', 'john.smith@example.com', HASHBYTES('SHA2_256', 'password123'), '1990-05-15', 'Male', 2, '2024-01-10'),
('Mary Johnson', 'mary.johnson@example.com', HASHBYTES('SHA2_256', 'securepass456'), '1985-11-20', 'Female', 2, '2024-01-12'),
('Robert Wilson', 'robert.wilson@example.com', HASHBYTES('SHA2_256', 'wilson789'), '1992-03-25', 'Male', 3, '2024-01-15'),
('Sarah Davis', 'sarah.davis@example.com', HASHBYTES('SHA2_256', 'davis2023'), '1988-07-08', 'Female', 4, '2024-01-18'),
('Michael Brown', 'michael.brown@example.com', HASHBYTES('SHA2_256', 'brown456'), '1979-09-17', 'Male', 5, '2024-01-20'),
('Jennifer Lee', 'jennifer.lee@example.com', HASHBYTES('SHA2_256', 'jlee789'), '1995-02-28', 'Female', 3, '2024-01-22'),
('David Miller', 'david.miller@example.com', HASHBYTES('SHA2_256', 'millerd123'), '1983-12-05', 'Male', 4, '2024-01-25'),
('Lisa Anderson', 'lisa.anderson@example.com', HASHBYTES('SHA2_256', 'anderson456'), '1991-06-14', 'Female', 2, '2024-01-28'),
('James Wilson', 'james.wilson@example.com', HASHBYTES('SHA2_256', 'wilson123'), '1987-04-23', 'Male', 6, '2024-01-30'),
('Karen Taylor', 'karen.taylor@example.com', HASHBYTES('SHA2_256', 'taylor789'), '1993-08-11', 'Female', 1, '2024-02-01');

-- System.UserAccount table data
INSERT INTO [dbo].[System.UserAccount] (UserName, [Password], FullName, Email, Phone, EmployeeCode, RoleId, CreatedDate, ApplicationCode, CreatedBy, ModifiedDate, ModifiedBy, IsActive) VALUES
('jsmith', HASHBYTES('SHA2_256', 'password123'), 'John Smith', 'john.smith@example.com', '123-456-7890', 'EMP001', 2, '2024-01-10', 'APP001', 'System', '2024-01-10', 'System', 1),
('mjohnson', HASHBYTES('SHA2_256', 'securepass456'), 'Mary Johnson', 'mary.johnson@example.com', '234-567-8901', 'EMP002', 2, '2024-01-12', 'APP001', 'System', '2024-01-12', 'System', 1),
('rwilson', HASHBYTES('SHA2_256', 'wilson789'), 'Robert Wilson', 'robert.wilson@example.com', '345-678-9012', 'EMP003', 3, '2024-01-15', 'APP001', 'System', '2024-01-15', 'System', 1),
('sdavis', HASHBYTES('SHA2_256', 'davis2023'), 'Sarah Davis', 'sarah.davis@example.com', '456-789-0123', 'EMP004', 4, '2024-01-18', 'APP001', 'System', '2024-01-18', 'System', 1),
('mbrown', HASHBYTES('SHA2_256', 'brown456'), 'Michael Brown', 'michael.brown@example.com', '567-890-1234', 'EMP005', 5, '2024-01-20', 'APP001', 'System', '2024-01-20', 'System', 1),
('jlee', HASHBYTES('SHA2_256', 'jlee789'), 'Jennifer Lee', 'jennifer.lee@example.com', '678-901-2345', 'EMP006', 3, '2024-01-22', 'APP001', 'System', '2024-01-22', 'System', 1),
('dmiller', HASHBYTES('SHA2_256', 'millerd123'), 'David Miller', 'david.miller@example.com', '789-012-3456', 'EMP007', 4, '2024-01-25', 'APP001', 'System', '2024-01-25', 'System', 1),
('landerson', HASHBYTES('SHA2_256', 'anderson456'), 'Lisa Anderson', 'lisa.anderson@example.com', '890-123-4567', 'EMP008', 2, '2024-01-28', 'APP001', 'System', '2024-01-28', 'System', 1),
('jwilson', HASHBYTES('SHA2_256', 'wilson123'), 'James Wilson', 'james.wilson@example.com', '901-234-5678', 'EMP009', 6, '2024-01-30', 'APP001', 'System', '2024-01-30', 'System', 1),
('ktaylor', HASHBYTES('SHA2_256', 'taylor789'), 'Karen Taylor', 'karen.taylor@example.com', '012-345-6789', 'EMP010', 1, '2024-02-01', 'APP001', 'System', '2024-02-01', 'System', 1);

-- Blog table data
INSERT INTO BlogMinhLH (Title, Summary, Content, AuthorId, CreatedAt, UpdatedAt, Status, Views, Tags) VALUES
('Early Childhood Education Trends', 'Exploring latest developments in early childhood education methodologies', 'This comprehensive article examines current trends in early childhood education, including play-based learning, outdoor education, and technology integration...', 3, '2024-02-10', '2024-02-11', 'Published', 1250, 'education,childhood,trends'),
('Navigating Teen Social Media Use', 'Guidelines for parents on managing teen social media consumption', 'Social media platforms present unique challenges for parents of teenagers. This article provides practical advice on setting boundaries, monitoring usage, and having productive conversations...', 4, '2024-02-15', '2024-02-16', 'Published', 982, 'teenagers,social media,parenting'),
('Supporting Children with Learning Differences', 'Resources and strategies for parents of children with learning disabilities', 'Every child learns differently, and some face unique challenges. This guide helps parents understand various learning disabilities and provides actionable strategies to support their children...', 5, '2024-02-20', NULL, 'Published', 763, 'learning disabilities,education,support'),
('Family Mindfulness Practices', 'Incorporating mindfulness into daily family routines', 'Mindfulness offers numerous benefits for both children and adults. This article presents simple techniques families can practice together to reduce stress and improve well-being...', 6, '2024-02-25', '2024-02-26', 'Published', 541, 'mindfulness,mental health,family'),
('Effective Co-Parenting After Divorce', 'Strategies for successful co-parenting arrangements', 'Co-parenting after separation presents unique challenges. This guide offers practical advice for maintaining healthy communication and consistent parenting approaches...', 3, '2024-03-01', NULL, 'Published', 892, 'divorce,co-parenting,relationships'),
('Helping Children Process Grief', 'Age-appropriate approaches to helping children cope with loss', 'When children experience loss, they need special support. This article provides guidance on discussing death and supporting emotional processing at different developmental stages...', 4, '2024-03-05', '2024-03-06', 'Published', 678, 'grief,loss,emotional support'),
('Building Resilience in Children', 'Strategies to help children develop emotional strength', 'Resilience is crucial for navigating life''s challenges. Learn how to foster this important trait in children through specific parenting approaches and activities...', 5, '2024-03-10', NULL, 'Draft', 0, 'resilience,emotional health,development'),
('Digital Literacy for Kids', 'Teaching children to be responsible digital citizens', 'As technology becomes increasingly integrated into children''s lives, digital literacy skills are essential. This guide helps parents teach safe and responsible technology use...', 6, '2024-03-15', '2024-03-16', 'Published', 432, 'technology,digital literacy,safety'),
('Healthy Sleep Habits for Growing Children', 'The importance of quality sleep for child development', 'Sleep plays a crucial role in physical and cognitive development. This article explains age-appropriate sleep requirements and strategies for establishing healthy sleep routines...', 3, '2024-03-20', NULL, 'Published', 765, 'sleep,health,development'),
('Encouraging a Growth Mindset', 'How to foster a love of learning and resilience in children', 'A growth mindset helps children approach challenges with confidence. This piece explores practical ways parents can encourage this mindset through everyday interactions...', 4, '2024-03-25', '2024-03-26', 'Published', 521, 'growth mindset,education,psychology');

-- Course table data
INSERT INTO Course (Title, Description, TargetGroup, IsActive) VALUES
('Positive Parenting Fundamentals', 'A comprehensive course on positive discipline techniques for parents of children aged 2-10', 'Phụ huynh', 1),
('Adolescent Psychology', 'Understanding teenage brain development and behavior', 'Phụ huynh, Giáo viên', 1),
('Early Childhood Development', 'Key milestones and support strategies for children aged 0-5', 'Phụ huynh, Giáo viên', 1),
('Effective Communication with Teens', 'Building open and trusting relationships with adolescents', 'Phụ huynh, Giáo viên', 1),
('Teaching Social-Emotional Skills', 'Helping children develop emotional intelligence and social competence', 'Giáo viên', 1),
('Supporting Children with Special Needs', 'Strategies for inclusive education and parenting', 'Phụ huynh, Giáo viên', 1),
('Digital Parenting', 'Managing screen time and online safety for children', 'Phụ huynh', 1),
('School Readiness', 'Preparing preschoolers for kindergarten success', 'Phụ huynh, Giáo viên', 1),
('Building Resilient Children', 'Fostering emotional strength and healthy coping mechanisms', 'Phụ huynh, Giáo viên', 1),
('Navigating Peer Pressure', 'Helping teenagers make healthy choices amidst social influences', 'Sinh viên, Phụ huynh', 1);

-- CourseEnrollmentDuyenCTT table data
INSERT INTO CourseEnrollmentDuyenCTT (UserId, CourseId, EnrolledAt, Progress, CompletedAt, Score, CertificateUrl, IsCertified, EnrollmentSource) VALUES
(1, 1, '2024-02-05', 100, '2024-03-10', 92.5, 'https://certificates.matoe.edu/cert12345', 1, 'Website'),
(2, 3, '2024-02-10', 75, NULL, NULL, NULL, 0, 'Mobile App'),
(3, 2, '2024-02-15', 100, '2024-03-20', 88.0, 'https://certificates.matoe.edu/cert23456', 1, 'Website'),
(4, 4, '2024-02-20', 60, NULL, NULL, NULL, 0, 'Partner Referral'),
(5, 5, '2024-02-25', 100, '2024-03-30', 95.5, 'https://certificates.matoe.edu/cert34567', 1, 'Website'),
(6, 6, '2024-03-01', 40, NULL, NULL, NULL, 0, 'Website'),
(7, 7, '2024-03-05', 100, '2024-04-10', 91.0, 'https://certificates.matoe.edu/cert45678', 1, 'Social Media'),
(8, 8, '2024-03-10', 85, NULL, NULL, NULL, 0, 'Email Campaign'),
(9, 9, '2024-03-15', 100, '2024-04-20', 89.5, 'https://certificates.matoe.edu/cert56789', 1, 'Website'),
(10, 10, '2024-03-20', 30, NULL, NULL, NULL, 0, 'Partner Referral');

-- SurveyDuongND table data
INSERT INTO dbo.SurveyDuongND (Name, Title, Description, Purpose, Status, CreatedByUserId, LastModifiedByUserId, CreatedAt, LastModifiedAt, TargetAudienceDescription, EstimatedCompletionTimeMinutes, AnonymityLevel, WelcomeMessage, ThankYouMessage) VALUES
('ParentingNeeds2024', 'Parenting Support Needs Assessment', 'Survey to understand the challenges parents face and identify needed resources', 'Needs Assessment', 'Active', 5, 5, '2024-01-15', '2024-01-20', 'Parents of children aged 0-18', 15, 'Pseudonymous', 'Welcome to our parenting needs survey! Your feedback will help us develop better resources.', 'Thank you for sharing your experiences! Your input will help us improve our parenting support services.'),
('TeacherSatisfaction2024', 'Teacher Satisfaction Survey', 'Annual survey to assess teacher satisfaction and identify areas for improvement', 'Program Evaluation', 'Active', 6, 6, '2024-01-20', '2024-01-25', 'K-12 Educators', 20, 'Pseudonymous', 'Welcome to our annual teacher satisfaction survey. Your honest feedback helps us improve.', 'Thank you for your valuable input! We appreciate your dedication to education.'),
('AdolescentMentalHealth', 'Teen Mental Health Screening', 'Screening tool for identifying potential mental health concerns in teenagers', 'Screening', 'Active', 3, 3, '2024-01-25', '2024-01-30', 'Adolescents aged 13-18', 10, 'FullyAnonymous', 'This survey helps identify potential mental health concerns. Your answers are completely anonymous.', 'Thank you for completing this screening. Remember that seeking help is a sign of strength.'),
('EarlyChildhoodDevelopment', 'Early Childhood Development Tracker', 'Tool for monitoring developmental milestones in young children', 'Assessment', 'Active', 4, 4, '2024-02-01', '2024-02-05', 'Parents of children aged 0-5', 15, 'Identifiable', 'This tool helps track your childs developmental progress. Please answer based on your observations.', 'Thank you for completing this assessment. Regular monitoring helps ensure optimal development.'),
('DigitalLiteracy', 'Digital Literacy Assessment', 'Survey to evaluate digital literacy skills and identify training needs', 'Needs Assessment', 'Active', 5, 5, '2024-02-05', '2024-02-10', 'Parents and educators', 15, 'Pseudonymous', 'This survey assesses your comfort with digital tools and technologies. There are no right or wrong answers.', 'Thank you for completing this assessment. Understanding digital literacy helps us develop better resources.'),
('ParentingStressIndex', 'Parenting Stress Inventory', 'Tool for measuring parental stress levels and identifying support needs', 'Assessment', 'Draft', 6, 6, '2024-02-10', '2024-02-15', 'Parents and caregivers', 10, 'FullyAnonymous', 'This inventory helps identify stress levels related to parenting. Your honest responses help us provide better support.', 'Thank you for completing this inventory. Remember that seeking support is a sign of strength.'),
('SchoolReadiness', 'Kindergarten Readiness Assessment', 'Tool for evaluating a childs readiness for kindergarten', 'Assessment', 'Active', 3, 3, '2024-02-15', '2024-02-20', 'Parents of children aged 4-6', 20, 'Identifiable', 'This assessment helps determine your childs readiness for kindergarten across multiple domains.', 'Thank you for completing this assessment. The results will help prepare your child for a successful start to school.'),
('TeacherTrainingNeeds', 'Professional Development Needs Survey', 'Survey to identify teacher training and professional development needs', 'Needs Assessment', 'Active', 4, 4, '2024-02-20', '2024-02-25', 'K-12 Educators', 15, 'Pseudonymous', 'This survey helps us understand your professional development needs and preferences.', 'Thank you for your input. We are committed to supporting your growth as an educator.'),
('FamilyTechnologyUse', 'Family Technology Habits Survey', 'Survey to understand technology use patterns within families', 'Research', 'Active', 5, 5, '2024-02-25', '2024-03-01', 'Families with children aged 5-18', 15, 'FullyAnonymous', 'This survey explores technology use patterns within your family. Your honest responses help us understand trends.', 'Thank you for sharing your familys technology habits. This information helps us develop better guidance.'),
('SocialEmotionalScreening', 'Social-Emotional Development Screening', 'Tool for assessing social-emotional development in children', 'Screening', 'Active', 6, 6, '2024-03-01', '2024-03-05', 'Parents of children aged 3-10', 15, 'Identifiable', 'This screening tool helps identify areas of strength and potential concern in your child\s social-emotional development.', 'Thank you for completing this screening. Social-emotional skills are crucial for childrens wellbeing and success.');

-- SurveyAssignment table data
INSERT INTO dbo.SurveyAssignment (SurveyId, UserId, RoleInSurvey, AssignmentDate, TaskDescription, IsActiveAssignment, DueDate) VALUES
(1, 5, 'PrimaryOwner_P1', '2024-01-15', 'Lead the development and implementation of the Parenting Needs Assessment', 1, '2024-01-30'),
(1, 6, 'PrimaryOwner_P2', '2024-01-15', 'Co-lead the implementation and analysis of the Parenting Needs Assessment', 1, '2024-01-30'),
(2, 6, 'PrimaryOwner_P1', '2024-01-20', 'Lead the development and implementation of the Teacher Satisfaction Survey', 1, '2024-02-05'),
(2, 3, 'Reviewer', '2024-01-20', 'Review and provide feedback on the Teacher Satisfaction Survey', 1, '2024-01-28'),
(3, 3, 'PrimaryOwner_P1', '2024-01-25', 'Lead the development and implementation of the Teen Mental Health Screening', 1, '2024-02-10'),
(3, 4, 'Reviewer', '2024-01-25', 'Review and provide feedback on the Teen Mental Health Screening', 1, '2024-02-02'),
(4, 4, 'PrimaryOwner_P1', '2024-02-01', 'Lead the development and implementation of the Early Childhood Development Tracker', 1, '2024-02-15'),
(4, 5, 'Approver', '2024-02-01', 'Approve the Early Childhood Development Tracker before launch', 1, '2024-02-10'),
(5, 5, 'PrimaryOwner_P1', '2024-02-05', 'Lead the development and implementation of the Digital Literacy Assessment', 1, '2024-02-20'),
(5, 6, 'Contributor', '2024-02-05', 'Contribute to the development of the Digital Literacy Assessment', 1, '2024-02-15');

-- QuestionBank table data
INSERT INTO dbo.QuestionBank (QuestionText, QuestionType, Category, SubCategory, SuggestedOptionsJSON, CreatedByUserId, CreatedAt, LastModifiedAt, Tags, IsArchived, LanguageCode) VALUES
('How often do you feel overwhelmed by parenting responsibilities?', 'SingleChoice', 'Parenting Stress', 'Emotional Well-being', '["Never", "Rarely", "Sometimes", "Often", "Almost Always"]', 5, '2024-01-10', '2024-01-10', 'stress,parenting,wellbeing', 0, 'en-US'),
('Rate your confidence in handling the following parenting situations:', 'Matrix', 'Parenting Skills', 'Self-Efficacy', '{"rows": ["Managing tantrums", "Setting boundaries", "Disciplining effectively", "Supporting emotional development"], "columns": ["Not at all confident", "Slightly confident", "Moderately confident", "Very confident", "Extremely confident"]}', 6, '2024-01-12', '2024-01-12', 'skills,confidence,parenting', 0, 'en-US'),
('What resources would be most helpful for you as a parent?', 'MultipleChoice', 'Support Needs', 'Resources', '["Parenting classes", "One-on-one consultations", "Online resources", "Support groups", "Books/literature", "Other (please specify)"]', 3, '2024-01-15', '2024-01-15', 'resources,support,needs', 0, 'en-US'),
('How often does your child exhibit the following behaviors?', 'Matrix', 'Child Behavior', 'Behavioral Assessment', '{"rows": ["Difficulty following directions", "Aggressive behavior", "Anxiety or worries", "Trouble concentrating"], "columns": ["Never", "Rarely", "Sometimes", "Often", "Very Often"]}', 4, '2024-01-18', '2024-01-18', 'behavior,assessment,child development', 0, 'en-US'),
('What is your childs approximate screen time per day?', 'SingleChoice', 'Technology Use', 'Screen Time', '["Less than 1 hour", "1-2 hours", "2-3 hours", "3-4 hours", "More than 4 hours"]', 5, '2024-01-20', '2024-01-20', 'technology,screen time,digital', 0, 'en-US'),
('Please rate your satisfaction with the following aspects of your teaching experience:', 'Matrix', 'Teacher Satisfaction', 'Work Environment', '{"rows": ["Administrative support", "Available resources", "Workload", "Professional development opportunities", "Work-life balance"], "columns": ["Very dissatisfied", "Dissatisfied", "Neutral", "Satisfied", "Very satisfied"]}', 6, '2024-01-22', '2024-01-22', 'teacher,satisfaction,workplace', 0, 'en-US'),
('How would you describe your childs social interactions with peers?', 'Text', 'Social Development', 'Peer Relationships', NULL, 3, '2024-01-25', '2024-01-25', 'social,development,relationships', 0, 'en-US'),
('Is your child able to recognize and name basic emotions (happy, sad, angry, scared)?', 'Boolean', 'Emotional Development', 'Emotional Literacy', '["Yes", "No"]', 4, '2024-01-28', '2024-01-28', 'emotional,development,literacy', 0, 'en-US'),
('What areas of professional development would be most valuable to you?', 'MultipleChoice', 'Teacher Development', 'Training Needs', '["Classroom management", "Technology integration", "Differentiated instruction", "Social-emotional learning", "Special education strategies", "Other (please specify)"]', 5, '2024-01-30', '2024-01-30', 'professional development,training,education', 0, 'en-US'),
('How often do you feel sad or down?', 'SingleChoice', 'Mental Health', 'Mood Assessment', '["Never", "Rarely", "Sometimes", "Often", "Almost Always"]', 6, '2024-02-01', '2024-02-01', 'mental health,mood,assessment', 0, 'en-US');

-- SurveyQuestionManhPT table data
INSERT INTO dbo.SurveyQuestionManhPT (SurveyId, BankQuestionId, QuestionText, QuestionType, DisplayOrder, IsMandatory, PointsPossible, HintText, PageNumber, SectionTitle) VALUES
(1, 1, 'How often do you feel overwhelmed by parenting responsibilities?', 'SingleChoice', 1, 1, NULL, 'Please select the option that best describes your experience', 1, 'Parenting Stress'),
(1, 3, 'What resources would be most helpful for you as a parent?', 'MultipleChoice', 2, 1, NULL, 'Select all that apply', 1, 'Support Needs'),
(1, NULL, 'What is your biggest parenting challenge currently?', 'Text', 3, 0, NULL, 'Please describe in a few sentences', 2, 'Challenges'),
(2, 6, 'Please rate your satisfaction with the following aspects of your teaching experience:', 'Matrix', 1, 1, NULL, 'Please rate each item honestly', 1, 'Job Satisfaction'),
(2, 9, 'What areas of professional development would be most valuable to you?', 'MultipleChoice', 2, 1, NULL, 'Select all that apply', 2, 'Professional Development'),
(3, 10, 'How often do you feel sad or down?', 'SingleChoice', 1, 1, NULL, 'Please select the option that best describes your experience', 1, 'Mood Assessment'),
(3, NULL, 'How often do you have trouble sleeping?', 'SingleChoice', 2, 1, NULL, 'Consider your experience over the past month', 1, 'Sleep Patterns'),
(4, 4, 'How often does your child exhibit the following behaviors?', 'Matrix', 1, 1, NULL, 'Please rate based on your observations over the past month', 1, 'Behavioral Assessment'),
(4, 8, 'Is your child able to recognize and name basic emotions (happy, sad, angry, scared)?', 'Boolean', 2, 1, NULL, NULL, 2, 'Emotional Development'),
(5, 5, 'What is your childs approximate screen time per day?', 'SingleChoice', 1, 1, NULL, 'Consider all devices including TV, tablets, phones, etc.', 1, 'Technology Use');

-- SurveyOptionManhPT table data
INSERT INTO dbo.SurveyOptionManhPT (QuestionId, OptionText, Score, DisplayOrder, IsCorrectAnswer) VALUES
(1, 'Never', 5, 1, NULL),
(1, 'Rarely', 4, 2, NULL),
(1, 'Sometimes', 3, 3, NULL),
(1, 'Often', 2, 4, NULL),
(1, 'Almost Always', 1, 5, NULL),
(2, 'Parenting classes', NULL, 1, NULL),
(2, 'One-on-one consultations', NULL, 2, NULL),
(2, 'Online resources', NULL, 3, NULL),
(2, 'Support groups', NULL, 4, NULL),
(2, 'Books/literature', NULL, 5, NULL);

-- SurveyResultDuongND table data
INSERT INTO dbo.SurveyResultDuongND (SurveyId, UserId, TakenAt, CompletedAt, Status, TotalScore, Recommendation, IPAddress, UserAgent, ReviewStatus) VALUES
(1, 1, '2024-02-05 10:00:00', '2024-02-05 10:15:00', 'Completed', NULL, 'Recommended for parenting support group', '192.168.1.101', 'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36', 'Reviewed'),
(1, 2, '2024-02-06 14:30:00', '2024-02-06 14:45:00', 'Completed', NULL, 'Recommended for individual consultation', '192.168.1.102', 'Mozilla/5.0 (Macintosh; Intel Mac OS X 10_15_7)', 'Reviewed'),
(2, 3, '2024-02-07 09:15:00', '2024-02-07 09:35:00', 'Completed', NULL, NULL, '192.168.1.103', 'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36', 'Pending'),
(2, 6, '2024-02-08 11:20:00', '2024-02-08 11:40:00', 'Completed', NULL, NULL, '192.168.1.104', 'Mozilla/5.0 (iPhone; CPU iPhone OS 16_5 like Mac OS X)', 'Pending'),
(3, 7, '2024-02-09 13:45:00', '2024-02-09 13:55:00', 'Completed', 75.5, 'Recommended for follow-up assessment', '192.168.1.105', 'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36', 'FlaggedForFollowUp'),
(3, 8, '2024-02-10 15:30:00', '2024-02-10 15:40:00', 'Completed', 82.0, NULL, '192.168.1.106', 'Mozilla/5.0 (iPad; CPU OS 16_5 like Mac OS X)', 'Pending'),
(4, 1, '2024-02-11 10:15:00', '2024-02-11 10:35:00', 'Completed', NULL, 'Age-appropriate development observed', '192.168.1.107', 'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36', 'Reviewed'),
(4, 2, '2024-02-12 11:45:00', '2024-02-12 12:05:00', 'Completed', NULL, 'Recommended for additional developmental assessment', '192.168.1.108', 'Mozilla/5.0 (Macintosh; Intel Mac OS X 10_15_7)', 'Reviewed'),
(5, 3, '2024-02-13 09:00:00', NULL, 'Abandoned', NULL, NULL, '192.168.1.109', 'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36', NULL),
(5, 4, '2024-02-14 14:20:00', '2024-02-14 14:35:00', 'Completed', NULL, NULL, '192.168.1.110', 'Mozilla/5.0 (iPhone; CPU iPhone OS 16_5 like Mac OS X)', 'Pending');

INSERT INTO dbo.SurveyAnswerDuongND (ResultId, QuestionId, OptionId, AnswerText, AnswerScore, AnsweredAt, TimeSpentOnQuestionSeconds)
VALUES
(1, 1, 1, NULL, 0.00, '2025-05-15 10:00:00', 30), -- User 1: Never used (Q1: ASSIST frequency)
(1, 2, 2, NULL, 2.00, '2025-05-15 10:00:30', 25), -- User 1: Occasional use (Q2: ASSIST craving)
(1, 3, NULL, 'I feel pressured sometimes', 3.00, '2025-05-15 10:01:00', 40), -- User 1: Open-ended (Q3: Peer pressure)
(1, 4, 3, NULL, 1.00, '2025-05-15 10:01:30', 20), -- User 1: Rarely (Q4: CRAFFT car use)
(1, 5, 4, NULL, 4.00, '2025-05-15 10:02:00', 35), -- User 1: Often (Q5: CRAFFT forget)
(2, 1, 1, NULL, 0.00, '2025-05-16 14:00:00', 28), -- User 2: Never used
(2, 2, 1, NULL, 0.00, '2025-05-16 14:00:30', 22), -- User 2: No craving
(2, 3, NULL, 'No pressure from friends', 0.00, '2025-05-16 14:01:00', 45), -- User 2: Open-ended
(2, 4, 1, NULL, 0.00, '2025-05-16 14:01:30', 18), -- User 2: Never
(2, 5, 1, NULL, 0.00, '2025-05-16 14:02:00', 30); -- User 2: Never

INSERT INTO dbo.ConsultantMinhPP (UserId, Specialization, Qualifications, Bio)
VALUES
(1, 'Substance Abuse Counseling', 'MS in Psychology, CADC-II', 'Experienced in youth drug prevention programs.'),
(2, 'Family Therapy', 'PhD in Clinical Psychology', 'Specializes in supporting families affected by substance abuse.'),
(3, 'Adolescent Counseling', 'BS in Social Work, CADC-I', 'Works with teens on peer pressure and drug refusal skills.'),
(4, 'Addiction Recovery', 'MD, Addiction Psychiatry', 'Expert in medical and psychological recovery strategies.'),
(5, 'Community Outreach', 'MA in Public Health', 'Leads drug awareness campaigns for schools.'),
(6, 'School-Based Counseling', 'MEd in Counseling', 'Supports teachers and students in drug-free initiatives.'),
(7, 'Parental Guidance', 'MS in Family Counseling', 'Helps parents address teen substance use.'),
(8, 'Behavioral Therapy', 'PsyD in Behavioral Psychology', 'Uses CBT for addiction prevention.'),
(9, 'Youth Mentorship', 'BA in Sociology, CADC-I', 'Mentors at-risk youth to avoid drugs.'),
(10, 'Policy Advocacy', 'MPH, Addiction Studies', 'Advocates for community drug prevention policies.');

INSERT INTO dbo.ConsultantAvailability (ConsultantId, AvailableDate, StartTime, EndTime)
VALUES
(1, '2025-05-20', '09:00:00', '10:00:00'), -- Consultant 1, morning slot
(1, '2025-05-20', '14:00:00', '15:00:00'), -- Consultant 1, afternoon slot
(2, '2025-05-21', '10:00:00', '11:00:00'), -- Consultant 2, morning
(2, '2025-05-21', '15:00:00', '16:00:00'), -- Consultant 2, afternoon
(3, '2025-05-22', '08:00:00', '09:00:00'), -- Consultant 3, early
(3, '2025-05-22', '13:00:00', '14:00:00'), -- Consultant 3, afternoon
(1, '2025-05-23', '11:00:00', '12:00:00'), -- Consultant 1, late morning
(2, '2025-05-23', '16:00:00', '17:00:00'), -- Consultant 2, late afternoon
(3, '2025-05-24', '09:00:00', '10:00:00'), -- Consultant 3, morning
(1, '2025-05-24', '14:00:00', '15:00:00'); -- Consultant 1, afternoon

INSERT INTO dbo.AppointmentMinhPP (UserId, ConsultantId, ScheduledDate, StartTime, EndTime, CreatedAt, UpdatedAt, Notes, [Status])
VALUES
(1, 1, '2025-05-20', '09:00:00', '10:00:00', '2025-05-15 08:00:00', '2025-05-15 08:00:00', 'Discuss ASSIST results', 'Confirmed'),
(2, 2, '2025-05-21', '10:00:00', '11:00:00', '2025-05-16 09:00:00', '2025-05-16 09:00:00', 'Family concerns about teen', 'Pending'),
(3, 3, '2025-05-22', '08:00:00', '09:00:00', '2025-05-17 10:00:00', '2025-05-17 10:00:00', 'Peer pressure issues', 'Confirmed'),
(4, 1, '2025-05-20', '14:00:00', '15:00:00', '2025-05-15 11:00:00', '2025-05-15 11:00:00', 'CRAFFT follow-up', 'Completed'),
(5, 2, '2025-05-21', '15:00:00', '16:00:00', '2025-05-16 12:00:00', '2025-05-16 12:00:00', 'Student counseling', 'Pending'),
(1, 3, '2025-05-22', '13:00:00', '14:00:00', '2025-05-17 13:00:00', '2025-05-17 13:00:00', 'Follow-up session', 'Confirmed'),
(2, 1, '2025-05-23', '11:00:00', '12:00:00', '2025-05-18 09:00:00', '2025-05-18 09:00:00', 'Parent guidance', 'Pending'),
(3, 2, '2025-05-23', '16:00:00', '17:00:00', '2025-05-18 10:00:00', '2025-05-18 10:00:00', 'Behavioral concerns', 'Confirmed'),
(4, 3, '2025-05-24', '09:00:00', '10:00:00', '2025-05-18 11:00:00', '2025-05-18 11:00:00', 'Recovery plan', 'Pending'),
(5, 1, '2025-05-24', '14:00:00', '15:00:00', '2025-05-18 12:00:00', '2025-05-18 12:00:00', 'Risk assessment', 'Confirmed');

INSERT INTO dbo.CommunityProgramKhoaNDD (Title, Description, StartDate, EndDate, TargetGroup, CreatedDate, LastEditedDate, CreatedBy, EditedBy)
VALUES
('Youth Drug Awareness', 'Workshop on drug risks for teens.', '2025-06-01', '2025-06-01', 'High School Students', '2025-05-10 09:00:00', '2025-05-10 09:00:00', 1, 1),
('Parent Drug Education', 'Guide for parents to spot drug use.', '2025-06-05', '2025-06-05', 'Parents', '2025-05-11 10:00:00', '2025-05-11 10:00:00', 2, 1),
('Refusal Skills Training', 'Teaches students to say no to drugs.', '2025-06-10', '2025-06-10', 'Middle School Students', '2025-05-12 11:00:00', '2025-05-12 11:00:00', 3, 2),
('Teacher Drug Workshop', 'Training for educators on drug signs.', '2025-06-15', '2025-06-15', 'Teachers', '2025-05-13 12:00:00', '2025-05-13 12:00:00', 4, 3),
('College Drug Prevention', 'Seminar for college students.', '2025-06-20', '2025-06-20', 'College Students', '2025-05-14 13:00:00', '2025-05-14 13:00:00', 5, 4),
('Community Drug Forum', 'Open discussion on drug prevention.', '2025-06-25', '2025-06-25', 'General Public', '2025-05-15 14:00:00', '2025-05-15 14:00:00', 6, 4),
('Peer Pressure Workshop', 'Helps teens resist peer influence.', '2025-07-01', '2025-07-01', 'High School Students', '2025-05-16 15:00:00', '2025-05-16 15:00:00', 7, 5),
('Family Support Program', 'Supports families affected by drugs.', '2025-07-05', '2025-07-05', 'Families', '2025-05-17 16:00:00', '2025-05-17 16:00:00', 8, 4),
('Drug-Free Schools', 'Campaign for drug-free campuses.', '2025-07-10', '2025-07-10', 'Teachers', '2025-05-18 17:00:00', '2025-05-18 17:00:00', 9, 7),
('Youth Mentorship', 'Mentors guide teens to avoid drugs.', '2025-07-15', '2025-07-15', 'High School Students', '2025-05-18 18:00:00', '2025-05-18 18:00:00', 10, 8);

INSERT INTO dbo.ProgramParticipantKhoaNDD (ProgramId, UserId, JoinedAt)
VALUES
(1, 1, '2025-05-15 09:00:00'), -- User 1 joins Youth Drug Awareness
(1, 2, '2025-05-15 09:30:00'), -- User 2 joins same
(2, 3, '2025-05-16 10:00:00'), -- User 3 joins Parent Drug Education
(2, 4, '2025-05-16 10:30:00'), -- User 4 joins same
(3, 5, '2025-05-17 11:00:00'), -- User 5 joins Refusal Skills
(3, 1, '2025-05-17 11:30:00'), -- User 1 joins same
(4, 2, '2025-05-18 12:00:00'), -- User 2 joins Teacher Workshop
(4, 3, '2025-05-18 12:30:00'), -- User 3 joins same
(5, 4, '2025-05-18 13:00:00'), -- User 4 joins College Seminar
(5, 5, '2025-05-18 13:30:00'); -- User 5 joins same

INSERT INTO dbo.ProgramSurvey (ProgramId, SurveyId, Type)
VALUES
(1, 1, 'Pre'), -- Youth Drug Awareness: ASSIST pre-survey
(1, 1, 'Post'), -- Youth Drug Awareness: ASSIST post-survey
(2, 2, 'Pre'), -- Parent Drug Education: CRAFFT pre-survey
(2, 2, 'Post'), -- Parent Drug Education: CRAFFT post-survey
(3, 3, 'Pre'), -- Refusal Skills: Custom pre-survey
(3, 3, 'Post'), -- Refusal Skills: Custom post-survey
(4, 4, 'Pre'), -- Teacher Workshop: Custom pre-survey
(4, 4, 'Post'), -- Teacher Workshop: Custom post-survey
(5, 5, 'Pre'), -- College Seminar: Custom pre-survey
(5, 5, 'Post'); -- College Seminar: Custom post-survey

