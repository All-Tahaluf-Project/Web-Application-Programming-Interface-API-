create proc GetAllA
as 
select * from A;
exec GetAllA;

go

create proc InsertA
@Name as varchar(Max)
as 
insert into A Values(@Name)
exec InsertA 'A';

go

create proc UpdateA
@Id as int,
@Name as varchar(Max)
as 
Update A set Name = @Name where Id = @Id
exec UpdateA 1 ,'B';

go

create proc DeleteA
@Id as int 
as
Delete from A where Id = @Id
exec DeleteA 1;















create proc GetAllB
as 
select 
B.Id,B.Name,A.Id,A.Name
from B as B join A as A on B.AId = A.Id;
exec GetAllB;
drop proc GetAllB

go

create proc InsertB
@IdA as int ,
@Name as varchar(Max)
as 
insert into B Values(@Name,@IdA)
exec InsertB 2,'B';

go

create proc UpdateB
@Id as int,
@IdA as int,
@Name as varchar(Max)
as 
Update B set Name = @Name,AId = @IdA where Id = @Id
exec UpdateB 2,3,'C';

go

create proc DeleteB
@Id as int 
as
Delete from B where Id = @Id
exec DeleteB 2;

go

















create proc GetAllD
as 
select * from D;
exec GetAllD;

go

create proc InsertD
@Name as varchar(Max)
as 
insert into D Values(@Name)
exec InsertD 'A';

go

create proc UpdateD
@Id as int,
@Name as varchar(Max)
as 
Update D set Name = @Name where Id = @Id
exec UpdateD 1 ,'B';

go

create proc DeleteD
@Id as int 
as
Delete from D where Id = @Id
exec DeleteD 1;

go
























create proc GetAllC
as 
select 
C.Id,C.AId ,A.Name as AName,C.DId,D.Name as DName
from C as C 
join A as A on C.AId = A.Id 
join D as D on C.DId = D.Id;
drop proc GetAllC
exec GetAllC;

go

create proc InsertC
@AId as int,
@DId as int
as 
insert into C Values(@AId,@DId)
exec InsertC 2,2;
drop proc InsertC

go

create proc UpdateC
@Id as int,
@AId as int,
@DId as int
as 
Update C set AId = @AId,DId=@DId where Id = @Id
exec UpdateC  1,3,3;
drop proc UpdateC

go

create proc DeleteC
@Id as int 
as
Delete from C where Id = @Id
exec DeleteC 2;

