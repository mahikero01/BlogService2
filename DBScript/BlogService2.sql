USE [dbbtCARSAp1]
GO
/****** Object:  Table [dbo].[BS_Persons]    Script Date: 1/18/2017 11:58:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BS_Persons](
	[Id] [uniqueidentifier] NOT NULL CONSTRAINT [DF_BS_Persons_Id]  DEFAULT (newid()),
	[Name] [nvarchar](max) NOT NULL,
	[Gender] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.BS_Persons] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[BS_Posts]    Script Date: 1/18/2017 11:58:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BS_Posts](
	[Id] [uniqueidentifier] NOT NULL CONSTRAINT [DF_BS_Posts_Id]  DEFAULT (newid()),
	[Title] [nvarchar](max) NOT NULL,
	[Comment] [nvarchar](max) NULL,
	[PersonId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_dbo.BS_Posts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
INSERT [dbo].[BS_Persons] ([Id], [Name], [Gender]) VALUES (N'b17977e6-6559-402a-909c-21856748165f', N'rico', N'm')
INSERT [dbo].[BS_Persons] ([Id], [Name], [Gender]) VALUES (N'c1124c86-cb1c-45a1-b1e3-7c6ce0b84128', N'grace', N'f')
INSERT [dbo].[BS_Persons] ([Id], [Name], [Gender]) VALUES (N'19a864a5-a8b0-402f-bea3-c53b40df12f0', N'rico', N'F')
INSERT [dbo].[BS_Posts] ([Id], [Title], [Comment], [PersonId]) VALUES (N'c2bb2574-9060-47d7-b86e-79281030c8bd', N'marvel', N'good', N'b17977e6-6559-402a-909c-21856748165f')
INSERT [dbo].[BS_Posts] ([Id], [Title], [Comment], [PersonId]) VALUES (N'cd0e60ee-3bf9-4ce9-8cef-a94ee3268339', N'dc', N'bad', N'c1124c86-cb1c-45a1-b1e3-7c6ce0b84128')
ALTER TABLE [dbo].[BS_Posts]  WITH CHECK ADD  CONSTRAINT [FK_dbo.BS_Posts_dbo.BS_Persons_PersonId] FOREIGN KEY([PersonId])
REFERENCES [dbo].[BS_Persons] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[BS_Posts] CHECK CONSTRAINT [FK_dbo.BS_Posts_dbo.BS_Persons_PersonId]
GO
