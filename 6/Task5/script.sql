USE [Batsh3]
GO
/****** Object:  Table [dbo].[Book]    Script Date: 29/07/2021 10:04:25 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Book](
	[BookId] [int] IDENTITY(1,1) NOT NULL,
	[BookName] [varchar](50) NULL,
	[CourseId] [int] NULL,
 CONSTRAINT [PK_Book] PRIMARY KEY CLUSTERED 
(
	[BookId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 29/07/2021 10:04:25 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[CategoryId] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [varchar](50) NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Course]    Script Date: 29/07/2021 10:04:25 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Course](
	[CourseId] [int] IDENTITY(1,1) NOT NULL,
	[CourseName] [varchar](50) NULL,
	[CreateDate] [datetime] NULL,
	[CategoryId] [int] NULL,
 CONSTRAINT [PK_Course] PRIMARY KEY CLUSTERED 
(
	[CourseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Marks]    Script Date: 29/07/2021 10:04:25 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Marks](
	[MarkId] [int] IDENTITY(1,1) NOT NULL,
	[MarkValue] [float] NULL,
	[TraineeId] [int] NULL,
 CONSTRAINT [PK_Marks] PRIMARY KEY CLUSTERED 
(
	[MarkId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 29/07/2021 10:04:25 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Teacher]    Script Date: 29/07/2021 10:04:25 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Teacher](
	[TeacherId] [int] IDENTITY(1,1) NOT NULL,
	[TeacherName] [varchar](50) NULL,
	[UserId] [int] NOT NULL,
 CONSTRAINT [PK_Teacher] PRIMARY KEY CLUSTERED 
(
	[TeacherId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TeacherCourse]    Script Date: 29/07/2021 10:04:25 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TeacherCourse](
	[IdTeacherCourse] [int] IDENTITY(1,1) NOT NULL,
	[TeacherId] [int] NULL,
	[CourseId] [int] NULL,
 CONSTRAINT [PK_TeacherCourse] PRIMARY KEY CLUSTERED 
(
	[IdTeacherCourse] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Trainee]    Script Date: 29/07/2021 10:04:25 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Trainee](
	[TraineeId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[UserId] [int] NULL,
 CONSTRAINT [PK_Trainee] PRIMARY KEY CLUSTERED 
(
	[TraineeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 29/07/2021 10:04:25 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](50) NULL,
	[Password] [varchar](50) NULL,
	[RoleId] [int] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Book]  WITH CHECK ADD  CONSTRAINT [FK_Book_Course] FOREIGN KEY([CourseId])
REFERENCES [dbo].[Course] ([CourseId])
GO
ALTER TABLE [dbo].[Book] CHECK CONSTRAINT [FK_Book_Course]
GO
ALTER TABLE [dbo].[Course]  WITH CHECK ADD  CONSTRAINT [FK_Course_Category] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Category] ([CategoryId])
GO
ALTER TABLE [dbo].[Course] CHECK CONSTRAINT [FK_Course_Category]
GO
ALTER TABLE [dbo].[Marks]  WITH CHECK ADD  CONSTRAINT [FK_Marks_Trainee] FOREIGN KEY([TraineeId])
REFERENCES [dbo].[Trainee] ([TraineeId])
GO
ALTER TABLE [dbo].[Marks] CHECK CONSTRAINT [FK_Marks_Trainee]
GO
ALTER TABLE [dbo].[Teacher]  WITH CHECK ADD  CONSTRAINT [FK_Teacher_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[Teacher] CHECK CONSTRAINT [FK_Teacher_User]
GO
ALTER TABLE [dbo].[TeacherCourse]  WITH CHECK ADD  CONSTRAINT [FK_TeacherCourse_Course] FOREIGN KEY([CourseId])
REFERENCES [dbo].[Course] ([CourseId])
GO
ALTER TABLE [dbo].[TeacherCourse] CHECK CONSTRAINT [FK_TeacherCourse_Course]
GO
ALTER TABLE [dbo].[TeacherCourse]  WITH CHECK ADD  CONSTRAINT [FK_TeacherCourse_Teacher] FOREIGN KEY([TeacherId])
REFERENCES [dbo].[Teacher] ([TeacherId])
GO
ALTER TABLE [dbo].[TeacherCourse] CHECK CONSTRAINT [FK_TeacherCourse_Teacher]
GO
ALTER TABLE [dbo].[Trainee]  WITH CHECK ADD  CONSTRAINT [FK_Trainee_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[Trainee] CHECK CONSTRAINT [FK_Trainee_User]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_Role] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Role] ([Id])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_Role]
GO
/****** Object:  StoredProcedure [dbo].[AddBook]    Script Date: 29/07/2021 10:04:25 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[AddBook]
@BookId as int,
@BookName as varchar(50),
@CourseId as int
as
insert into Book Values(@BookId,@BookName,@CourseId)
GO
/****** Object:  StoredProcedure [dbo].[AddCourse]    Script Date: 29/07/2021 10:04:25 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[AddCourse]
@Id as int,
@Name as varchar(50)
as
insert into Course Values(@Id,@Name)
GO
/****** Object:  StoredProcedure [dbo].[createTest]    Script Date: 29/07/2021 10:04:25 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[createTest] 
@Id as int ,
@Date as Datetime,
@String as varchar(50)
as
insert into Test Values(@Id,@Date,@String)
GO
/****** Object:  StoredProcedure [dbo].[DeleteBook]    Script Date: 29/07/2021 10:04:25 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[DeleteBook]
@Id as int
as
delete from Book where Id = @Id
GO
/****** Object:  StoredProcedure [dbo].[DeleteCourse]    Script Date: 29/07/2021 10:04:25 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[DeleteCourse]
@Id as int
as
delete from Course where Id = @Id
GO
/****** Object:  StoredProcedure [dbo].[DeleteTest]    Script Date: 29/07/2021 10:04:25 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[DeleteTest]
@Id as int
as 
delete from Test where Id = @Id
GO
/****** Object:  StoredProcedure [dbo].[GetAllBook]    Script Date: 29/07/2021 10:04:25 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[GetAllBook]
as 
select * from Book
GO
/****** Object:  StoredProcedure [dbo].[GetAllCourse]    Script Date: 29/07/2021 10:04:25 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[GetAllCourse]
as 
select * from Course
GO
/****** Object:  StoredProcedure [dbo].[GetAllCourseBook]    Script Date: 29/07/2021 10:04:25 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[GetAllCourseBook]
as
select * from Course as C 
inner join Book as B on C.CourseId = B.CourseId
GO
/****** Object:  StoredProcedure [dbo].[GetAllMarks]    Script Date: 29/07/2021 10:04:25 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[GetAllMarks]
@Id as int
as
select m.MarkId,m.MarkValue,t.Name from Marks as m join Trainee as t on m.TraineeId = t.TraineeId
where m.TraineeId = @Id
GO
/****** Object:  StoredProcedure [dbo].[GetAVGMark]    Script Date: 29/07/2021 10:04:25 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[GetAVGMark]
as
select avg(MarkValue) from Marks
GO
/****** Object:  StoredProcedure [dbo].[GetDetails]    Script Date: 29/07/2021 10:04:25 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[GetDetails]
@Id as int 
as 
select * from Test where Id = @Id
GO
/****** Object:  StoredProcedure [dbo].[GetMaxMark]    Script Date: 29/07/2021 10:04:25 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[GetMaxMark]
as 
select max(MarkValue) from Marks
GO
/****** Object:  StoredProcedure [dbo].[GetMinMark]    Script Date: 29/07/2021 10:04:25 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[GetMinMark]
as 
select min(MarkValue) from Marks
GO
/****** Object:  StoredProcedure [dbo].[GetSUMMark]    Script Date: 29/07/2021 10:04:25 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[GetSUMMark]
as 
select sum(MarkValue) from Marks
GO
/****** Object:  StoredProcedure [dbo].[GetTeacherUserById]    Script Date: 29/07/2021 10:04:25 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[GetTeacherUserById]
@Id as int
as
select U.UserName,U.Id,R.Name as RoleName,T.TeacherName as TeacherName from [User] as U join Role as R 
on U.RoleId = R.Id 
join Teacher as T on U.Id = T.UserId 
where U.Id = @Id
GO
/****** Object:  StoredProcedure [dbo].[GetTraineeUserById]    Script Date: 29/07/2021 10:04:25 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[GetTraineeUserById]
@Id as int
as
select U.UserName,U.Id,R.Name as RoleName,T.Name as TraineeName from [User] as U join Role as R 
on U.RoleId = R.Id 
join Trainee as T on U.Id = T.UserId 
where U.Id = @Id
GO
/****** Object:  StoredProcedure [dbo].[GetUser]    Script Date: 29/07/2021 10:04:25 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[GetUser]
@UserName as varchar(50),
@Password as varchar(50)
as
select U.UserName,U.Id,R.Name as RoleName from [User] as U join Role as R 
on U.RoleId = R.Id
where UserName = @UserName and @Password = Password
GO
/****** Object:  StoredProcedure [dbo].[Search]    Script Date: 29/07/2021 10:04:25 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Search]
@CourseName VARCHAR(50) NULL,
@CategoryName VARCHAR(50) NULL,
@DateFrom DateTime NULL,
@DateTo DateTime NULL
AS
BEGIN
SELECT C.CourseId, C.CourseName, CA.CategoryName
FROM Course AS C
INNER JOIN Category AS CA ON C.CategoryId = CA.CategoryId
WHERE (@CourseName IS NULL OR C.CourseName LIKE '%' + @CourseName + '%')
AND (@CategoryName IS NULL OR CA.CategoryName LIKE '%' + @CategoryName + '%')
AND (@DateFrom IS NULL OR @DateTo IS NULL OR C.CreateDate BETWEEN @DateFrom AND @DateTo)
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateBook]    Script Date: 29/07/2021 10:04:25 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[UpdateBook]
@Id as int,
@Name as varchar(50),
@CourseId as int
as 
Update Book set Name = @Name , CourseId = @CourseId where Id = @Id
GO
/****** Object:  StoredProcedure [dbo].[UpdateCourse]    Script Date: 29/07/2021 10:04:25 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[UpdateCourse]
@Id as int ,
@Name as varchar(50)
as 
Update Course set Name = @Name where Id = @Id
GO
/****** Object:  StoredProcedure [dbo].[UpdateTest]    Script Date: 29/07/2021 10:04:25 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[UpdateTest] 
@Id as int ,
@Date as Datetime,
@String as varchar(50)
as
UPDATE Test
SET Date = @Date, String = @String
WHERE Id = @Id;
GO
