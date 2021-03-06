USE [ASPCRUD]
GO
/****** Object:  Table [dbo].[Contact]    Script Date: 9/15/2018 3:41:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING OFF
GO
CREATE TABLE [dbo].[Contact](
	[ContactID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Mobile] [varchar](50) NOT NULL,
	[Address] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Contact] PRIMARY KEY CLUSTERED 
(
	[ContactID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Contact] ON 

INSERT [dbo].[Contact] ([ContactID], [Name], [Mobile], [Address]) VALUES (6, N'moony parvez', N'1725649852', N'Dhaka1')
INSERT [dbo].[Contact] ([ContactID], [Name], [Mobile], [Address]) VALUES (7, N'moony parvez', N'1725649852', N'Dhaka')
SET IDENTITY_INSERT [dbo].[Contact] OFF
