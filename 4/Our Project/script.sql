USE [OurProject]
GO
/****** Object:  Table [dbo].[A]    Script Date: 19/07/2021 12:49:35 ص ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[A](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](max) NULL,
 CONSTRAINT [PK_A] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[B]    Script Date: 19/07/2021 12:49:35 ص ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[B](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](max) NULL,
	[AId] [int] NULL,
 CONSTRAINT [PK_B] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[C]    Script Date: 19/07/2021 12:49:35 ص ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[C](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AId] [int] NULL,
	[DId] [int] NULL,
 CONSTRAINT [PK_C] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[D]    Script Date: 19/07/2021 12:49:35 ص ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[D](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](max) NULL,
 CONSTRAINT [PK_D] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[B]  WITH CHECK ADD  CONSTRAINT [FK_B_A] FOREIGN KEY([AId])
REFERENCES [dbo].[A] ([Id])
GO
ALTER TABLE [dbo].[B] CHECK CONSTRAINT [FK_B_A]
GO
ALTER TABLE [dbo].[C]  WITH CHECK ADD  CONSTRAINT [FK_C_A] FOREIGN KEY([AId])
REFERENCES [dbo].[A] ([Id])
GO
ALTER TABLE [dbo].[C] CHECK CONSTRAINT [FK_C_A]
GO
ALTER TABLE [dbo].[C]  WITH CHECK ADD  CONSTRAINT [FK_C_D] FOREIGN KEY([DId])
REFERENCES [dbo].[D] ([Id])
GO
ALTER TABLE [dbo].[C] CHECK CONSTRAINT [FK_C_D]
GO
/****** Object:  StoredProcedure [dbo].[DeleteA]    Script Date: 19/07/2021 12:49:35 ص ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[DeleteA]
@Id as int 
as
Delete from A where Id = @Id
GO
/****** Object:  StoredProcedure [dbo].[DeleteB]    Script Date: 19/07/2021 12:49:35 ص ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[DeleteB]
@Id as int 
as
Delete from B where Id = @Id
GO
/****** Object:  StoredProcedure [dbo].[DeleteC]    Script Date: 19/07/2021 12:49:35 ص ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[DeleteC]
@Id as int 
as
Delete from C where Id = @Id
GO
/****** Object:  StoredProcedure [dbo].[DeleteD]    Script Date: 19/07/2021 12:49:35 ص ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[DeleteD]
@Id as int 
as
Delete from D where Id = @Id
GO
/****** Object:  StoredProcedure [dbo].[GetAllA]    Script Date: 19/07/2021 12:49:35 ص ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[GetAllA]
as 
select * from A;
GO
/****** Object:  StoredProcedure [dbo].[GetAllB]    Script Date: 19/07/2021 12:49:35 ص ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[GetAllB]
as 
select 
B.Id,B.Name,A.Id,A.Name
from B as B join A as A on B.AId = A.Id;
GO
/****** Object:  StoredProcedure [dbo].[GetAllC]    Script Date: 19/07/2021 12:49:35 ص ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[GetAllC]
as 
select 
C.Id,C.AId ,A.Name as AName,C.DId,D.Name as DName
from C as C 
join A as A on C.AId = A.Id 
join D as D on C.DId = D.Id;
GO
/****** Object:  StoredProcedure [dbo].[GetAllD]    Script Date: 19/07/2021 12:49:35 ص ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[GetAllD]
as 
select * from D;
GO
/****** Object:  StoredProcedure [dbo].[InsertA]    Script Date: 19/07/2021 12:49:35 ص ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[InsertA]
@Name as varchar(Max)
as 
insert into A Values(@Name)
GO
/****** Object:  StoredProcedure [dbo].[InsertB]    Script Date: 19/07/2021 12:49:35 ص ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[InsertB]
@IdA as int ,
@Name as varchar(Max)
as 
insert into B Values(@Name,@IdA)
GO
/****** Object:  StoredProcedure [dbo].[InsertC]    Script Date: 19/07/2021 12:49:35 ص ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[InsertC]
@AId as int,
@DId as int
as 
insert into C Values(@AId,@DId)
GO
/****** Object:  StoredProcedure [dbo].[InsertD]    Script Date: 19/07/2021 12:49:35 ص ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[InsertD]
@Name as varchar(Max)
as 
insert into D Values(@Name)
GO
/****** Object:  StoredProcedure [dbo].[UpdateA]    Script Date: 19/07/2021 12:49:35 ص ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[UpdateA]
@Id as int,
@Name as varchar(Max)
as 
Update A set Name = @Name where Id = @Id
GO
/****** Object:  StoredProcedure [dbo].[UpdateB]    Script Date: 19/07/2021 12:49:35 ص ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[UpdateB]
@Id as int,
@IdA as int,
@Name as varchar(Max)
as 
Update B set Name = @Name,AId = @IdA where Id = @Id
GO
/****** Object:  StoredProcedure [dbo].[UpdateC]    Script Date: 19/07/2021 12:49:35 ص ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[UpdateC]
@Id as int,
@AId as int,
@DId as int
as 
Update C set AId = @AId,DId=@DId where Id = @Id
GO
/****** Object:  StoredProcedure [dbo].[UpdateD]    Script Date: 19/07/2021 12:49:35 ص ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[UpdateD]
@Id as int,
@Name as varchar(Max)
as 
Update D set Name = @Name where Id = @Id
GO
