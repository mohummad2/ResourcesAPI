
CREATE DATABASE [Resources]

GO

USE [Resources]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[WageType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](30) NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_WageType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


CREATE TABLE [dbo].[Designation](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](30) NOT NULL,
	[WageTypeId] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Designation] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Designation]  WITH CHECK ADD  CONSTRAINT [FK_Designation_WageType] FOREIGN KEY([WageTypeId])
REFERENCES [dbo].[WageType] ([Id])
GO

ALTER TABLE [dbo].[Designation] CHECK CONSTRAINT [FK_Designation_WageType]
GO

CREATE TABLE [dbo].[Worker](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](30) NOT NULL,
	[LastName] [varchar](50) NOT NULL,
	[Address1] [varchar](100) NOT NULL,
	[DesignationId] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[DateModified] [datetime] NOT NULL,
 CONSTRAINT [PK_Worker] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Worker]  WITH CHECK ADD  CONSTRAINT [FK_Worker_Designation] FOREIGN KEY([DesignationId])
REFERENCES [dbo].[Designation] ([Id])
GO

ALTER TABLE [dbo].[Worker] CHECK CONSTRAINT [FK_Worker_Designation]
GO

CREATE TABLE [dbo].[Compensation](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[WorkerId] [int] NOT NULL,
	[Amount] [decimal](10, 2) NOT NULL,
	[MaxExpenseAllowed] [decimal](10, 2) NOT NULL,
 CONSTRAINT [PK_Compensation] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Compensation]  WITH CHECK ADD  CONSTRAINT [FK_Compensation_Worker] FOREIGN KEY([WorkerId])
REFERENCES [dbo].[Worker] ([Id])
GO

ALTER TABLE [dbo].[Compensation] CHECK CONSTRAINT [FK_Compensation_Worker]
GO


SET IDENTITY_INSERT WageType ON
Insert INTO WageType(Id,Name,IsActive)
Values(1, 'Hourly', 1), (2, 'Annual', 1)
SET IDENTITY_INSERT WageType OFF

Insert INTO Designation(Name,WageTypeId, IsActive)
Values('Employee', 1, 1), ('Supervisor', 2, 1), ('Manager', 2, 1)

GO