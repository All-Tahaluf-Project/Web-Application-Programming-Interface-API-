--Book
create proc GetAllBook
as 
select * from Book;
exec GetAllBook;

create proc InsertBook
@BookName as varchar(Max),
@CourseId as int
as
insert into Book Values(@BookName,@CourseId)
exec InsertBook 'Book2',1;

create proc UpdateBook
@BookId as int,
@BookName as varchar(Max),
@CourseId as int
as
Update Book set BookName = @BookName ,CourseId = @CourseId where BookId = @BookId
exec UpdateBook 1 ,'Book1',2;

create proc DeleteBook
@BookId as int 
as
Delete from Book where BookId = @BookId
exec DeleteBook 2;

create proc DetailsBook
@BookId as int
as
select 
B.BookId,B.BookName,C.CourseId,C.CourseName
from Book as B join Course as C on B.CourseId = C.CourseId where BookId = @BookId

exec DetailsBook 1;
drop proc DetailsBook;

create proc GetAllBookForCourse
@CourseId as int
as 
select BookId,BookName from Book where CourseId = @CourseId;
exec GetAllBookForCourse 2;
drop proc GetAllBookForCourse;




--Course
create proc GetAllCourse
as 
select * from Course ;
exec GetAllCourse;
drop proc GetAllCourse;

create proc InsertCourse
@CourseName as varchar(Max)
as
insert into Course Values(@CourseName)
exec InsertCourse 'Course2';

create proc UpdateCourse
@CourseId as int,
@CourseName as varchar(Max)
as
Update Course set CourseName = @CourseName where CourseId = @CourseId;
exec UpdateCourse 1 ,'Course1';

create proc DeleteCourse
@CourseId as int 
as
Delete from Course where CourseId = @CourseId;
exec DeleteCourse 1;

create proc DetailsCourse
@CourseId as int
as
select * from Course where CourseId = @CourseId

exec DetailsCourse 2;



--Teacher
create proc GetAllTeacher
as 
select * from Teacher;
exec GetAllTeacher;

create proc InsertTeacher
@TeacherName as varchar(Max)
as
insert into Teacher Values(@TeacherName);
exec InsertTeacher 'Teacher1';

create proc UpdateTeacher
@TeacherId as int,
@TeacherName as varchar(Max)
as
Update Teacher set TeacherName = @TeacherName where TeacherId = @TeacherId;
exec UpdateTeacher 1 ,'Teacher';

create proc DeleteTeacher
@TeacherId as int 
as
Delete from Teacher where TeacherId = @TeacherId;
exec DeleteTeacher 1;

create proc DetailsTeacher
@TeacherId as int
as
select * from Teacher where TeacherId = @TeacherId

exec DetailsTeacher 2;

--Solution 1
--create proc DetailsTeacher
--@TeacherId as int
--as
--select 
--T.TeacherId as TeacherId,
--T.TeacherName as TeacherName,
--TC.*
--from 
--Teacher as T join TeacherCourse as TC on T.TeacherId = TC.TeacherId 
--where T.TeacherId = @TeacherId

--exec DetailsTeacher 2;
--drop proc DetailsTeacher;




--TeacherCourse
create proc GetAllTeacherCourse
as 
select 
TC.TeacherCourseId,C.CourseId,C.CourseName,T.TeacherId,T.TeacherName
from TeacherCourse as TC 
join Course as C on TC.CourseId = C.CourseId
join Teacher as T on TC.TeacherId = T.TeacherId;
drop proc GetAllTeacherCourse;
exec GetAllTeacherCourse;

create proc InsertTeacherCourse
@CourseId as int,
@TeacherId as int
as
insert into TeacherCourse Values(@CourseId,@TeacherId);
exec InsertTeacherCourse 2,2;

create proc UpdateTeacherCourse
@TeacherCourseId as int,
@CourseId as int,
@TeacherId as int
as
Update TeacherCourse set CourseId = @CourseId , TeacherId = @TeacherId where TeacherCourseId = @TeacherCourseId;
exec UpdateTeacherCourse 1,3,3;

create proc DeleteTeacherCourse
@TeacherCourseId as int 
as
Delete from TeacherCourse where TeacherCourseId = @TeacherCourseId;
exec DeleteTeacherCourse 1;

create proc DetailsTeacherCourse
@TeacherCourseId as int
as
select 
TC.TeacherCourseId, T.TeacherId,T.TeacherName,C.CourseId,C.CourseName
from 
TeacherCourse as TC join Course as C on TC.CourseId = C.CourseId 
join Teacher as T on TC.TeacherId = T.TeacherId 
where TeacherCourseId = @TeacherCourseId;
exec DetailsTeacherCourse 2;

create proc DetailsTeacherCourseForCourse
@CourseId as int
as
select 
TC.TeacherCourseId,T.TeacherId,T.TeacherName
from 
TeacherCourse as TC join Teacher as T on TC.TeacherId = T.TeacherId 
where TC.CourseId = @CourseId;
exec DetailsTeacherCourseForCourse 2;
drop proc DetailsTeacherCourseForCourse

create proc DetailsTeacherCourseForTeacher
@TeacherId as int
as
select 
TC.TeacherCourseId,C.CourseId,C.CourseName
from 
TeacherCourse as TC join Course as C on TC.CourseId = C.CourseId 
where TC.TeacherId = @TeacherId;
exec DetailsTeacherCourseForTeacher 2;


create proc SearchTeacherCourseFromCourse
@CourseName as varchar(Max)
as
select 
TC.TeacherCourseId, T.TeacherId,T.TeacherName,C.CourseId,C.CourseName
from 
TeacherCourse as TC join Course as C on TC.CourseId = C.CourseId 
join Teacher as T on TC.TeacherId = T.TeacherId 
where C.CourseName like '%'+@CourseName+'%';
exec SearchTeacherCourseFromCourse 'Course2';

create proc SearchTeacherCourseFromTeacher
@TeacherName as varchar(Max)
as
select 
TC.TeacherCourseId, T.TeacherId,T.TeacherName,C.CourseId,C.CourseName
from 
TeacherCourse as TC join Course as C on TC.CourseId = C.CourseId 
join Teacher as T on TC.TeacherId = T.TeacherId 
where T.TeacherName like '%'+@TeacherName+'%';
exec SearchTeacherCourseFromTeacher 'Caa';





create proc CheckCourse
@Id as int
as 
select CourseId from Course where CourseId = @Id;
exec CheckCourse 2;

create proc CheckTeacher
@Id as int
as 
select TeacherId from Teacher where TeacherId = @Id;
exec CheckTeacher 2;

create proc CheckTeacherCourse
@Id as int
as 
select TeacherCourseId from TeacherCourse where TeacherCourseId = @Id;
exec CheckTeacherCourse 2;

create proc CheckBook
@Id as int
as 
select BookId from Book where BookId = @Id;
exec CheckBook 1;

