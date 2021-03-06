USE [Employee]
GO
/****** Object:  Table [dbo].[CANDIDATE]    Script Date: 6/7/2018 17:46:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CANDIDATE](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Fullname] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[Phone] [varchar](50) NULL,
	[Status] [nvarchar](50) NULL,
 CONSTRAINT [PK_CANDIDATE] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[HumanResource]    Script Date: 6/7/2018 17:46:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[HumanResource](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Fullname] [nvarchar](50) NULL,
	[Email] [varchar](50) NULL,
	[Phone] [varchar](50) NULL,
	[Status] [nvarchar](50) NULL,
 CONSTRAINT [PK_HumanResource] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[CANDIDATE] ON 

INSERT [dbo].[CANDIDATE] ([Id], [Fullname], [Email], [Phone], [Status]) VALUES (1, N'Nguyễn Minh Nhân', N'nguyenminhnhan@gmail.com', N'0987676754', N'Chưa duyệt')
INSERT [dbo].[CANDIDATE] ([Id], [Fullname], [Email], [Phone], [Status]) VALUES (2, N'Nguyễn Minh Thảo', N'minhthao@gmail.com', N'0987654434', N'Chưa duyệt')
INSERT [dbo].[CANDIDATE] ([Id], [Fullname], [Email], [Phone], [Status]) VALUES (3, N'Nguyễn Minh Nghĩa', N'nghia@gmail.com', N'0989876656', N'Chưa duyệt')
SET IDENTITY_INSERT [dbo].[CANDIDATE] OFF
SET IDENTITY_INSERT [dbo].[HumanResource] ON 

INSERT [dbo].[HumanResource] ([Id], [Fullname], [Email], [Phone], [Status]) VALUES (1, N'Ninh', N'Nguyentan@gmail', N'01245', N'Nhân Viên')
INSERT [dbo].[HumanResource] ([Id], [Fullname], [Email], [Phone], [Status]) VALUES (2, N'Nguyễn', N'Tanninh@gmail.com', N'012544', N'Nhân Viên')
SET IDENTITY_INSERT [dbo].[HumanResource] OFF
