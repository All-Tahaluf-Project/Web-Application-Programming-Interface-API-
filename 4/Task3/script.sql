USE [Tahaluf.Task3OnionArchitectoure]
GO
/****** Object:  Table [dbo].[Book]    Script Date: 19/07/2021 06:32:53 ص ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Book](
	[BookId] [int] IDENTITY(1,1) NOT NULL,
	[BookName] [varchar](max) NULL,
	[CourseId] [int] NOT NULL,
 CONSTRAINT [PK_Book] PRIMARY KEY CLUSTERED 
(
	[BookId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Course]    Script Date: 19/07/2021 06:32:53 ص ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Course](
	[CourseId] [int] IDENTITY(1,1) NOT NULL,
	[CourseName] [varchar](max) NULL,
 CONSTRAINT [PK_Course] PRIMARY KEY CLUSTERED 
(
	[CourseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Teacher]    Script Date: 19/07/2021 06:32:53 ص ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Teacher](
	[TeacherId] [int] IDENTITY(1,1) NOT NULL,
	[TeacherName] [varchar](max) NULL,
 CONSTRAINT [PK_Teacher] PRIMARY KEY CLUSTERED 
(
	[TeacherId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TeacherCourse]    Script Date: 19/07/2021 06:32:53 ص ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TeacherCourse](
	[TeacherCourseId] [int] IDENTITY(1,1) NOT NULL,
	[CourseId] [int] NULL,
	[TeacherId] [int] NULL,
 CONSTRAINT [PK_TeacherCourse] PRIMARY KEY CLUSTERED 
(
	[TeacherCourseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Book]  WITH CHECK ADD  CONSTRAINT [FK_Book_Course] FOREIGN KEY([CourseId])
REFERENCES [dbo].[Course] ([CourseId])
GO
ALTER TABLE [dbo].[Book] CHECK CONSTRAINT [FK_Book_Course]
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
/****** Object:  StoredProcedure [dbo].[CheckBook]    Script Date: 19/07/2021 06:32:53 ص ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[CheckBook]
@Id as int
as 
select BookId from Book where BookId = @Id;
GO
/****** Object:  StoredProcedure [dbo].[CheckCourse]    Script Date: 19/07/2021 06:32:53 ص ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[CheckCourse]
@Id as int
as 
select CourseId from Course where CourseId = @Id;
GO
/****** Object:  StoredProcedure [dbo].[CheckTeacher]    Script Date: 19/07/2021 06:32:53 ص ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[CheckTeacher]
@Id as int
as 
select TeacherId from Teacher where TeacherId = @Id;
GO
/****** Object:  StoredProcedure [dbo].[CheckTeacherCourse]    Script Date: 19/07/2021 06:32:53 ص ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[CheckTeacherCourse]
@Id as int
as 
select TeacherCourseId from TeacherCourse where TeacherCourseId = @Id;
GO
/****** Object:  StoredProcedure [dbo].[DeleteBook]    Script Date: 19/07/2021 06:32:53 ص ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[DeleteBook]
@BookId as int 
as
Delete from Book where BookId = @BookId
GO
/****** Object:  StoredProcedure [dbo].[DeleteCourse]    Script Date: 19/07/2021 06:32:53 ص ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[DeleteCourse]
@CourseId as int 
as
Delete from Course where CourseId = @CourseId;
GO
/****** Object:  StoredProcedure [dbo].[DeleteTeacher]    Script Date: 19/07/2021 06:32:53 ص ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[DeleteTeacher]
@TeacherId as int 
as
Delete from Teacher where TeacherId = @TeacherId;
GO
/****** Object:  StoredProcedure [dbo].[DeleteTeacherCourse]    Script Date: 19/07/2021 06:32:53 ص ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[DeleteTeacherCourse]
@TeacherCourseId as int 
as
Delete from TeacherCourse where TeacherCourseId = @TeacherCourseId;
GO
/****** Object:  StoredProcedure [dbo].[DetailsBook]    Script Date: 19/07/2021 06:32:53 ص ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[DetailsBook]
@BookId as int
as
select 
B.BookId,B.BookName,C.CourseId,C.CourseName
from Book as B join Course as C on B.CourseId = C.CourseId where BookId = @BookId
GO
/****** Object:  StoredProcedure [dbo].[DetailsCourse]    Script Date: 19/07/2021 06:32:53 ص ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[DetailsCourse]
@CourseId as int
as
select * from Course where CourseId = @CourseId
GO
/****** Object:  StoredProcedure [dbo].[DetailsTeacher]    Script Date: 19/07/2021 06:32:53 ص ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[DetailsTeacher]
@TeacherId as int
as
select * from Teacher where TeacherId = @TeacherId
GO
/****** Object:  StoredProcedure [dbo].[DetailsTeacherCourse]    Script Date: 19/07/2021 06:32:53 ص ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[DetailsTeacherCourse]
@TeacherCourseId as int
as
select 
TC.TeacherCourseId, T.TeacherId,T.TeacherName,C.CourseId,C.CourseName
from 
TeacherCourse as TC join Course as C on TC.CourseId = C.CourseId 
join Teacher as T on TC.TeacherId = T.TeacherId 
where TeacherCourseId = @TeacherCourseId;
GO
/****** Object:  StoredProcedure [dbo].[DetailsTeacherCourseForCourse]    Script Date: 19/07/2021 06:32:53 ص ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[DetailsTeacherCourseForCourse]
@CourseId as int
as
select 
TC.TeacherCourseId,T.TeacherId,T.TeacherName
from 
TeacherCourse as TC join Teacher as T on TC.TeacherId = T.TeacherId 
where TC.CourseId = @CourseId;
GO
/****** Object:  StoredProcedure [dbo].[DetailsTeacherCourseForTeacher]    Script Date: 19/07/2021 06:32:53 ص ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[DetailsTeacherCourseForTeacher]
@TeacherId as int
as
select 
TC.TeacherCourseId,C.CourseId,C.CourseName
from 
TeacherCourse as TC join Course as C on TC.CourseId = C.CourseId 
where TC.TeacherId = @TeacherId;
GO
/****** Object:  StoredProcedure [dbo].[GetAllBook]    Script Date: 19/07/2021 06:32:53 ص ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[GetAllBook]
as 
select * from Book;
GO
/****** Object:  StoredProcedure [dbo].[GetAllBookForCourse]    Script Date: 19/07/2021 06:32:53 ص ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[GetAllBookForCourse]
@CourseId as int
as 
select BookId,BookName from Book where CourseId = @CourseId;
GO
/****** Object:  StoredProcedure [dbo].[GetAllCourse]    Script Date: 19/07/2021 06:32:53 ص ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[GetAllCourse]
as 
select * from Course ;
GO
/****** Object:  StoredProcedure [dbo].[GetAllTeacher]    Script Date: 19/07/2021 06:32:53 ص ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[GetAllTeacher]
as 
select * from Teacher;
GO
/****** Object:  StoredProcedure [dbo].[GetAllTeacherCourse]    Script Date: 19/07/2021 06:32:53 ص ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[GetAllTeacherCourse]
as 
select 
TC.TeacherCourseId,C.CourseId,C.CourseName,T.TeacherId,T.TeacherName
from TeacherCourse as TC 
join Course as C on TC.CourseId = C.CourseId
join Teacher as T on TC.TeacherId = T.TeacherId;
GO
/****** Object:  StoredProcedure [dbo].[InsertBook]    Script Date: 19/07/2021 06:32:53 ص ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[InsertBook]
@BookName as varchar(Max),
@CourseId as int
as
insert into Book Values(@BookName,@CourseId)
GO
/****** Object:  StoredProcedure [dbo].[InsertCourse]    Script Date: 19/07/2021 06:32:53 ص ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[InsertCourse]
@CourseName as varchar(Max)
as
insert into Course Values(@CourseName)
GO
/****** Object:  StoredProcedure [dbo].[InsertTeacher]    Script Date: 19/07/2021 06:32:53 ص ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[InsertTeacher]
@TeacherName as varchar(Max)
as
insert into Teacher Values(@TeacherName);
GO
/****** Object:  StoredProcedure [dbo].[InsertTeacherCourse]    Script Date: 19/07/2021 06:32:53 ص ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[InsertTeacherCourse]
@CourseId as int,
@TeacherId as int
as
insert into TeacherCourse Values(@CourseId,@TeacherId);
GO
/****** Object:  StoredProcedure [dbo].[SearchTeacherCourseFromCourse]    Script Date: 19/07/2021 06:32:53 ص ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[SearchTeacherCourseFromCourse]
@CourseName as varchar(Max)
as
select 
TC.TeacherCourseId, T.TeacherId,T.TeacherName,C.CourseId,C.CourseName
from 
TeacherCourse as TC join Course as C on TC.CourseId = C.CourseId 
join Teacher as T on TC.TeacherId = T.TeacherId 
where C.CourseName like '%'+@CourseName+'%';
GO
/****** Object:  StoredProcedure [dbo].[SearchTeacherCourseFromTeacher]    Script Date: 19/07/2021 06:32:53 ص ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[SearchTeacherCourseFromTeacher]
@TeacherName as varchar(Max)
as
select 
TC.TeacherCourseId, T.TeacherId,T.TeacherName,C.CourseId,C.CourseName
from 
TeacherCourse as TC join Course as C on TC.CourseId = C.CourseId 
join Teacher as T on TC.TeacherId = T.TeacherId 
where T.TeacherName like '%'+@TeacherName+'%';
GO
/****** Object:  StoredProcedure [dbo].[UpdateBook]    Script Date: 19/07/2021 06:32:53 ص ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[UpdateBook]
@BookId as int,
@BookName as varchar(Max),
@CourseId as int
as
Update Book set BookName = @BookName ,CourseId = @CourseId where BookId = @BookId
GO
/****** Object:  StoredProcedure [dbo].[UpdateCourse]    Script Date: 19/07/2021 06:32:53 ص ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[UpdateCourse]
@CourseId as int,
@CourseName as varchar(Max)
as
Update Course set CourseName = @CourseName where CourseId = @CourseId;
GO
/****** Object:  StoredProcedure [dbo].[UpdateTeacher]    Script Date: 19/07/2021 06:32:53 ص ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[UpdateTeacher]
@TeacherId as int,
@TeacherName as varchar(Max)
as
Update Teacher set TeacherName = @TeacherName where TeacherId = @TeacherId;
GO
/****** Object:  StoredProcedure [dbo].[UpdateTeacherCourse]    Script Date: 19/07/2021 06:32:53 ص ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[UpdateTeacherCourse]
@TeacherCourseId as int,
@CourseId as int,
@TeacherId as int
as
Update TeacherCourse set CourseId = @CourseId , TeacherId = @TeacherId where TeacherCourseId = @TeacherCourseId;
GO
