USE [GreetingDatabase1]
GO
/****** Object:  Table [dbo].[Account]    Script Date: 7/14/2017 9:57:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Account](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[username] [varchar](50) NOT NULL,
	[password] [varchar](30) NULL,
	[question] [nvarchar](50) NULL,
	[answer] [nvarchar](80) NULL,
	[roldId] [int] NOT NULL,
	[facebook] [bit] NULL,
	[firstName] [nvarchar](50) NULL,
	[lastName] [nvarchar](50) NULL,
	[gender] [nvarchar](50) NULL,
	[address] [nvarchar](50) NULL,
	[country] [nvarchar](50) NULL,
	[mobile] [varchar](20) NULL,
 CONSTRAINT [PK_Account] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Category]    Script Date: 7/14/2017 9:57:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Category_Details]    Script Date: 7/14/2017 9:57:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Category_Details](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NULL,
	[categoryID] [int] NULL,
	[dateOfEvent] [datetime] NULL,
	[status] [varchar](5) NULL,
 CONSTRAINT [PK_Category_Details] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Greeting]    Script Date: 7/14/2017 9:57:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Greeting](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[photo] [varchar](250) NULL,
	[categoryDetailsID] [int] NULL,
	[video] [varchar](250) NULL,
	[url] [varchar](250) NULL,
 CONSTRAINT [PK_Greeting] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Payment]    Script Date: 7/14/2017 9:57:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Payment](
	[accountId] [int] NOT NULL,
	[serviceId] [int] NOT NULL,
	[amount] [money] NULL,
	[expiryDate] [date] NULL,
	[paymentNumber] [int] NULL,
	[Status] [bit] NULL,
 CONSTRAINT [PK_Payment] PRIMARY KEY CLUSTERED 
(
	[accountId] ASC,
	[serviceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Role]    Script Date: 7/14/2017 9:57:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NULL,
	[details] [nvarchar](250) NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Sending]    Script Date: 7/14/2017 9:57:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sending](
	[greetingId] [int] NOT NULL,
	[AccountId] [int] NOT NULL,
	[senderName] [nvarchar](50) NULL,
	[rersiveName] [nvarchar](50) NULL,
	[addressTo] [nvarchar](50) NULL,
	[customMessenger] [nvarchar](250) NULL,
	[id] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_Sending] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Service]    Script Date: 7/14/2017 9:57:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Service](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [int] NOT NULL,
	[price] [money] NULL,
 CONSTRAINT [PK_Service] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Account] ON 

INSERT [dbo].[Account] ([id], [username], [password], [question], [answer], [roldId], [facebook], [firstName], [lastName], [gender], [address], [country], [mobile]) VALUES (29, N'admmmm@hotmail.com', N'rCEEaRzEaM0wwFIiaXB7pQ==', N'What the fuck u thing?', N'abc', 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Account] ([id], [username], [password], [question], [answer], [roldId], [facebook], [firstName], [lastName], [gender], [address], [country], [mobile]) VALUES (30, N'cccccccccc', N'eo3qgL5x8wAuN67W/mV54A==', N'What r u looking for?', N'cccc', 3, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Account] ([id], [username], [password], [question], [answer], [roldId], [facebook], [firstName], [lastName], [gender], [address], [country], [mobile]) VALUES (31, N'cxxxxxxxxxxx', N'8L2NQragcu0+lUU/Cu7p6g==', N'What r u looking for?', N'xxx', 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Account] ([id], [username], [password], [question], [answer], [roldId], [facebook], [firstName], [lastName], [gender], [address], [country], [mobile]) VALUES (35, N'loginaccount', N'82EailCSQQcRcLDaAxjBGw==', N'What the fuck u thing?', N'123', 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Account] ([id], [username], [password], [question], [answer], [roldId], [facebook], [firstName], [lastName], [gender], [address], [country], [mobile]) VALUES (38, N'test@gmail.com', N'rCEEaRzEaM0wwFIiaXB7pQ==', N'What r u looking for?', N'no fucking', 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Account] ([id], [username], [password], [question], [answer], [roldId], [facebook], [firstName], [lastName], [gender], [address], [country], [mobile]) VALUES (42, N'zzzzzzzzzzzzzzzzzzzzzzz', N'0i7ZzCy4Oga8es60hGvgAA==', N'What the fuck u thing?', N'zzzzzzz', 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Account] ([id], [username], [password], [question], [answer], [roldId], [facebook], [firstName], [lastName], [gender], [address], [country], [mobile]) VALUES (43, N'accountcreate', N'rCEEaRzEaM1oaDT+7IP59g==', N'What the fuck u thing?', N'CAN''T THINK', 3, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Account] ([id], [username], [password], [question], [answer], [roldId], [facebook], [firstName], [lastName], [gender], [address], [country], [mobile]) VALUES (44, N'458234807861058', NULL, N'Not Question ', N'Not Answer', 1, 1, N'T.Trọng', N'Tb', N'male', NULL, NULL, NULL)
INSERT [dbo].[Account] ([id], [username], [password], [question], [answer], [roldId], [facebook], [firstName], [lastName], [gender], [address], [country], [mobile]) VALUES (45, N'trong123456@gmail.com', N'ky3f4HD8xucbdBhY4rWlCQ==', N'trong có đẹp trai khong ?', N'co', 1, NULL, N'to', N'trong', N'Male', N'Ho Chi Minh city', N'Quảng Nam', N'01283856093')
INSERT [dbo].[Account] ([id], [username], [password], [question], [answer], [roldId], [facebook], [firstName], [lastName], [gender], [address], [country], [mobile]) VALUES (46, N'Tien1995@gmail.com', N'82EailCSQQcRcLDaAxjBGw==', N'trong có đẹp trai khong ?', N'deo', 1, NULL, N'Nguyen', N'Tien', N'Other', N'nha tien', N'TP HCM', N'0905285394')
INSERT [dbo].[Account] ([id], [username], [password], [question], [answer], [roldId], [facebook], [firstName], [lastName], [gender], [address], [country], [mobile]) VALUES (47, N'aknj@gmail.com', N'82EailCSQQcRcLDaAxjBGw==', N'trong có đẹp trai khong ?', N'deo', 1, NULL, N'nguyen', N'tien', N'Female', N'cho o nha tao', N'An Giang', N'09182873869')
INSERT [dbo].[Account] ([id], [username], [password], [question], [answer], [roldId], [facebook], [firstName], [lastName], [gender], [address], [country], [mobile]) VALUES (48, N'tienhoang1@gmail.com', N'dT0DuFSAI06KxJ5XBn1MWQ==', N'trong có đẹp trai khong ?', N'co', 1, NULL, N'to', N'trong', N'Female', N'5/12 le van luong', N'An Giang', N'01283856093')
INSERT [dbo].[Account] ([id], [username], [password], [question], [answer], [roldId], [facebook], [firstName], [lastName], [gender], [address], [country], [mobile]) VALUES (49, N'973101926165978', NULL, N'Not Question ', N'Not Answer', 1, 1, N'Tien', N'Akasaka', N'male', NULL, NULL, NULL)
INSERT [dbo].[Account] ([id], [username], [password], [question], [answer], [roldId], [facebook], [firstName], [lastName], [gender], [address], [country], [mobile]) VALUES (50, N'470071696677369', NULL, N'Not Question ', N'Not Answer', 1, 1, N'T.Trọng', N'Tb', N'male', NULL, NULL, NULL)
INSERT [dbo].[Account] ([id], [username], [password], [question], [answer], [roldId], [facebook], [firstName], [lastName], [gender], [address], [country], [mobile]) VALUES (51, N'trong1234567@gmail.com', N'ky3f4HD8xucbdBhY4rWlCQ==', N'Where did you speed your childhood summers?', N'co', 1, NULL, N'to', N'trong', N'Male', N'5/12 le van luong', N'Bạc Liêu', N'01283856093')
INSERT [dbo].[Account] ([id], [username], [password], [question], [answer], [roldId], [facebook], [firstName], [lastName], [gender], [address], [country], [mobile]) VALUES (52, N'tienhoang@gmail.com', N'Jj25c3b71jhO7r/lGRDJ1w==', N'What was your favorite food as a child?', N'asddvd', 1, NULL, N'nguyen', N'tien', N'Male', N'Viet Name', N'An Giang', N'09384837483')
INSERT [dbo].[Account] ([id], [username], [password], [question], [answer], [roldId], [facebook], [firstName], [lastName], [gender], [address], [country], [mobile]) VALUES (53, N'testtien@gmail.com', N'Nvd6NmKlB/Y2f0tuAiI7rw==', N'What was the last name of your favorite teacher?', N'ksmkvn cdnkdj', 1, NULL, N'akasaka', N'tien', N'Male', N'Ho Chi Minh', N'An Giang', N'0934125533')
INSERT [dbo].[Account] ([id], [username], [password], [question], [answer], [roldId], [facebook], [firstName], [lastName], [gender], [address], [country], [mobile]) VALUES (54, N'tien1@gmail.com', N'82EailCSQQcRcLDaAxjBGw==', N'Where did you speed your childhood summers?', N'dva', 1, NULL, N'akasaka', N'tien', N'Female', N'ha nao', N'Bình Định', N'0937462823')
INSERT [dbo].[Account] ([id], [username], [password], [question], [answer], [roldId], [facebook], [firstName], [lastName], [gender], [address], [country], [mobile]) VALUES (55, N'tien2@gmail.com', N'82EailCSQQcRcLDaAxjBGw==', N'Where did you speed your childhood summers?', N'vfvfvf', 1, NULL, N'acvbb', N'mkmkf', N'Female', N'Ho Chi Minh', N'Đắk Nông', N'0977688773')
INSERT [dbo].[Account] ([id], [username], [password], [question], [answer], [roldId], [facebook], [firstName], [lastName], [gender], [address], [country], [mobile]) VALUES (56, N'tien3@gmail.com', N'82EailCSQQcRcLDaAxjBGw==', N'Where did you speed your childhood summers?', N'ggfv', 1, NULL, N'akasaka', N'tien', N'Other', N'Ho Chi Minh', N'An Giang', N'0973747843')
INSERT [dbo].[Account] ([id], [username], [password], [question], [answer], [roldId], [facebook], [firstName], [lastName], [gender], [address], [country], [mobile]) VALUES (57, N'tien4@gmail.com', N'82EailCSQQcRcLDaAxjBGw==', N'Where did you speed your childhood summers?', N'cho de', 1, NULL, N'nguyen ', N'akasaka', N'Male', N'Ho Chi Minh', N'An Giang', N'0983746475')
SET IDENTITY_INSERT [dbo].[Account] OFF
SET IDENTITY_INSERT [dbo].[Category] ON 

INSERT [dbo].[Category] ([id], [name]) VALUES (1, N'Holiday')
INSERT [dbo].[Category] ([id], [name]) VALUES (2, N'Festival')
INSERT [dbo].[Category] ([id], [name]) VALUES (3, N'Celebration')
INSERT [dbo].[Category] ([id], [name]) VALUES (8, N'Festival123')
SET IDENTITY_INSERT [dbo].[Category] OFF
SET IDENTITY_INSERT [dbo].[Category_Details] ON 

INSERT [dbo].[Category_Details] ([id], [name], [categoryID], [dateOfEvent], [status]) VALUES (1, N'New Year', 1, CAST(N'2017-01-01 00:00:00.000' AS DateTime), N'0')
INSERT [dbo].[Category_Details] ([id], [name], [categoryID], [dateOfEvent], [status]) VALUES (2, N'Father Day', 1, CAST(N'2017-06-18 00:00:00.000' AS DateTime), N'0')
INSERT [dbo].[Category_Details] ([id], [name], [categoryID], [dateOfEvent], [status]) VALUES (3, N'Mother Day', 1, CAST(N'2017-05-14 00:00:00.000' AS DateTime), N'0')
INSERT [dbo].[Category_Details] ([id], [name], [categoryID], [dateOfEvent], [status]) VALUES (4, N'Christmas', 2, CAST(N'2017-12-25 00:00:00.000' AS DateTime), N'1')
INSERT [dbo].[Category_Details] ([id], [name], [categoryID], [dateOfEvent], [status]) VALUES (5, N'Easter', 2, CAST(N'2017-04-16 00:00:00.000' AS DateTime), N'0')
INSERT [dbo].[Category_Details] ([id], [name], [categoryID], [dateOfEvent], [status]) VALUES (6, N'Birthday', 3, NULL, N'0')
INSERT [dbo].[Category_Details] ([id], [name], [categoryID], [dateOfEvent], [status]) VALUES (7, N'Wedding', 3, NULL, N'0')
INSERT [dbo].[Category_Details] ([id], [name], [categoryID], [dateOfEvent], [status]) VALUES (10, N'Login Greeting', 1, CAST(N'2017-07-12 00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Category_Details] ([id], [name], [categoryID], [dateOfEvent], [status]) VALUES (11, N'CategoryDetails', 8, CAST(N'2017-07-31 00:00:00.000' AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[Category_Details] OFF
SET IDENTITY_INSERT [dbo].[Greeting] ON 

INSERT [dbo].[Greeting] ([id], [photo], [categoryDetailsID], [video], [url]) VALUES (1, N'NW_20-06-2017_1.jpg', 1, NULL, NULL)
INSERT [dbo].[Greeting] ([id], [photo], [categoryDetailsID], [video], [url]) VALUES (2, N'NW_20-06-2017_2.png', 1, NULL, NULL)
INSERT [dbo].[Greeting] ([id], [photo], [categoryDetailsID], [video], [url]) VALUES (3, N'NW_20-06-2017_3.jpg', 1, NULL, NULL)
INSERT [dbo].[Greeting] ([id], [photo], [categoryDetailsID], [video], [url]) VALUES (4, N'NW_20-06-2017_4.jpg', 1, NULL, NULL)
INSERT [dbo].[Greeting] ([id], [photo], [categoryDetailsID], [video], [url]) VALUES (5, N'NW_20-06-2017_5.jpg', 1, NULL, NULL)
INSERT [dbo].[Greeting] ([id], [photo], [categoryDetailsID], [video], [url]) VALUES (6, N'NW_20-06-2017_6.jpg', 1, NULL, NULL)
INSERT [dbo].[Greeting] ([id], [photo], [categoryDetailsID], [video], [url]) VALUES (7, N'NW_20-06-2017_7.jpg', 1, NULL, NULL)
INSERT [dbo].[Greeting] ([id], [photo], [categoryDetailsID], [video], [url]) VALUES (8, N'NW_20-06-2017_8.jpg', 1, NULL, NULL)
INSERT [dbo].[Greeting] ([id], [photo], [categoryDetailsID], [video], [url]) VALUES (9, N'NW_20-06-2017_9.jpg', 1, NULL, NULL)
INSERT [dbo].[Greeting] ([id], [photo], [categoryDetailsID], [video], [url]) VALUES (10, N'NW_20-06-2017_10.jpg', 1, NULL, NULL)
INSERT [dbo].[Greeting] ([id], [photo], [categoryDetailsID], [video], [url]) VALUES (11, N'NW_20-06-2017_11.jpg', 1, NULL, NULL)
INSERT [dbo].[Greeting] ([id], [photo], [categoryDetailsID], [video], [url]) VALUES (12, N'NW_20-06-2017_12.jpg', 1, NULL, NULL)
INSERT [dbo].[Greeting] ([id], [photo], [categoryDetailsID], [video], [url]) VALUES (13, N'NW_20-06-2017_13.jpg', 1, NULL, NULL)
INSERT [dbo].[Greeting] ([id], [photo], [categoryDetailsID], [video], [url]) VALUES (14, N'Fday_20-06-2017_1.jpg', 2, NULL, NULL)
INSERT [dbo].[Greeting] ([id], [photo], [categoryDetailsID], [video], [url]) VALUES (15, N'Fday_20-06-2017_2.jpg', 2, NULL, NULL)
INSERT [dbo].[Greeting] ([id], [photo], [categoryDetailsID], [video], [url]) VALUES (16, N'Fday_20-06-2017_3.jpg', 2, NULL, NULL)
INSERT [dbo].[Greeting] ([id], [photo], [categoryDetailsID], [video], [url]) VALUES (17, N'Fday_20-06-2017_4.jpg', 2, NULL, NULL)
INSERT [dbo].[Greeting] ([id], [photo], [categoryDetailsID], [video], [url]) VALUES (18, N'Mday_20-06-2017_1.png', 3, NULL, NULL)
INSERT [dbo].[Greeting] ([id], [photo], [categoryDetailsID], [video], [url]) VALUES (19, N'Mday_20-06-2017_2.jpg', 3, NULL, NULL)
INSERT [dbo].[Greeting] ([id], [photo], [categoryDetailsID], [video], [url]) VALUES (20, N'Mday_20-06-2017_3.jpg', 3, NULL, NULL)
INSERT [dbo].[Greeting] ([id], [photo], [categoryDetailsID], [video], [url]) VALUES (21, N'Mday_20-06-2017_4.jpg', 3, NULL, NULL)
INSERT [dbo].[Greeting] ([id], [photo], [categoryDetailsID], [video], [url]) VALUES (22, N'Mday_20-06-2017_5.jpg', 3, NULL, NULL)
INSERT [dbo].[Greeting] ([id], [photo], [categoryDetailsID], [video], [url]) VALUES (23, N'Mday_20-06-2017_6.jpg', 3, NULL, NULL)
INSERT [dbo].[Greeting] ([id], [photo], [categoryDetailsID], [video], [url]) VALUES (24, N'Mday_20-06-2017_7.png', 3, NULL, NULL)
INSERT [dbo].[Greeting] ([id], [photo], [categoryDetailsID], [video], [url]) VALUES (25, N'Mday_20-06-2017_8.jpg', 3, NULL, NULL)
INSERT [dbo].[Greeting] ([id], [photo], [categoryDetailsID], [video], [url]) VALUES (26, N'Mday_20-06-2017_9.jpg', 3, NULL, NULL)
INSERT [dbo].[Greeting] ([id], [photo], [categoryDetailsID], [video], [url]) VALUES (27, N'Christ_20-06-2017_1.jpg', 4, NULL, NULL)
INSERT [dbo].[Greeting] ([id], [photo], [categoryDetailsID], [video], [url]) VALUES (28, N'Christ_20-06-2017_2.png', 4, NULL, NULL)
INSERT [dbo].[Greeting] ([id], [photo], [categoryDetailsID], [video], [url]) VALUES (29, N'Christ_20-06-2017_3.jpg', 4, NULL, NULL)
INSERT [dbo].[Greeting] ([id], [photo], [categoryDetailsID], [video], [url]) VALUES (30, N'Christ_20-06-2017_4.jpg', 4, NULL, NULL)
INSERT [dbo].[Greeting] ([id], [photo], [categoryDetailsID], [video], [url]) VALUES (31, N'Christ_20-06-2017_5.jpg', 4, NULL, NULL)
INSERT [dbo].[Greeting] ([id], [photo], [categoryDetailsID], [video], [url]) VALUES (32, N'Christ_20-06-2017_6.jpg', 4, NULL, NULL)
INSERT [dbo].[Greeting] ([id], [photo], [categoryDetailsID], [video], [url]) VALUES (33, N'Christ_20-06-2017_7.png', 4, NULL, NULL)
INSERT [dbo].[Greeting] ([id], [photo], [categoryDetailsID], [video], [url]) VALUES (34, N'Christ_20-06-2017_8.jpg', 4, NULL, NULL)
INSERT [dbo].[Greeting] ([id], [photo], [categoryDetailsID], [video], [url]) VALUES (35, N'Christ_20-06-2017_9.jpg', 4, NULL, NULL)
INSERT [dbo].[Greeting] ([id], [photo], [categoryDetailsID], [video], [url]) VALUES (36, N'Christ_20-06-2017_10.jpg', 4, NULL, NULL)
INSERT [dbo].[Greeting] ([id], [photo], [categoryDetailsID], [video], [url]) VALUES (37, N'Easter_20-06-2017_1.jpg', 5, NULL, NULL)
INSERT [dbo].[Greeting] ([id], [photo], [categoryDetailsID], [video], [url]) VALUES (38, N'Easter_20-06-2017_2.png', 5, NULL, NULL)
INSERT [dbo].[Greeting] ([id], [photo], [categoryDetailsID], [video], [url]) VALUES (39, N'Easter_20-06-2017_3.jpg', 5, NULL, NULL)
INSERT [dbo].[Greeting] ([id], [photo], [categoryDetailsID], [video], [url]) VALUES (40, N'Easter_20-06-2017_4.jpg', 5, NULL, NULL)
INSERT [dbo].[Greeting] ([id], [photo], [categoryDetailsID], [video], [url]) VALUES (41, N'Easter_20-06-2017_5.jpg', 5, NULL, NULL)
INSERT [dbo].[Greeting] ([id], [photo], [categoryDetailsID], [video], [url]) VALUES (42, N'Easter_20-06-2017_6.jpg', 5, NULL, NULL)
INSERT [dbo].[Greeting] ([id], [photo], [categoryDetailsID], [video], [url]) VALUES (43, N'Easter_20-06-2017_7.jpg', 5, NULL, NULL)
INSERT [dbo].[Greeting] ([id], [photo], [categoryDetailsID], [video], [url]) VALUES (44, N'Easter_20-06-2017_8.jpg', 5, NULL, NULL)
INSERT [dbo].[Greeting] ([id], [photo], [categoryDetailsID], [video], [url]) VALUES (45, N'B_20-06-2017_1.jpg', 6, NULL, NULL)
INSERT [dbo].[Greeting] ([id], [photo], [categoryDetailsID], [video], [url]) VALUES (46, N'B_20-06-2017_2.png', 6, NULL, NULL)
INSERT [dbo].[Greeting] ([id], [photo], [categoryDetailsID], [video], [url]) VALUES (47, N'B_20-06-2017_3.jpg', 6, NULL, NULL)
INSERT [dbo].[Greeting] ([id], [photo], [categoryDetailsID], [video], [url]) VALUES (48, N'B_20-06-2017_4.jpg', 6, NULL, NULL)
INSERT [dbo].[Greeting] ([id], [photo], [categoryDetailsID], [video], [url]) VALUES (49, N'B_20-06-2017_5.jpg', 6, NULL, NULL)
INSERT [dbo].[Greeting] ([id], [photo], [categoryDetailsID], [video], [url]) VALUES (81, N'VideoNW29-06-17_1.jpg', 1, N'VideoNW29-06-17_1.webm', N'https://www.youtube.com/embed/zML1b-072mU')
INSERT [dbo].[Greeting] ([id], [photo], [categoryDetailsID], [video], [url]) VALUES (82, N'VideoNW29-06-17_2.jpg', 1, N'VideoNW29-06-17_2.webm', N'https://www.youtube.com/embed/LwdMJDGexIo')
INSERT [dbo].[Greeting] ([id], [photo], [categoryDetailsID], [video], [url]) VALUES (83, N'VideoNW29-06-17_3.jpg', 1, N'VideoNW29-06-17_3.webm', N'https://www.youtube.com/embed/ttKIHXq9Edk')
INSERT [dbo].[Greeting] ([id], [photo], [categoryDetailsID], [video], [url]) VALUES (84, N'VideoNW29-06-17_4.jpg', 1, N'VideoNW29-06-17_4.webm', N'https://www.youtube.com/embed/FDP53pup9S4')
INSERT [dbo].[Greeting] ([id], [photo], [categoryDetailsID], [video], [url]) VALUES (85, N'VideoNW29-06-17_5.jpg', 1, N'VideoNW29-06-17_5.webm', N'https://www.youtube.com/embed/3PqKTgNIzf0')
INSERT [dbo].[Greeting] ([id], [photo], [categoryDetailsID], [video], [url]) VALUES (86, N'VideoNW29-06-17_6.jpg', 1, N'VideoNW29-06-17_6.webm', N'https://www.youtube.com/embed/kOzAQmEFgCI')
INSERT [dbo].[Greeting] ([id], [photo], [categoryDetailsID], [video], [url]) VALUES (87, N'VideoFday29-06-17_1.jpg', 2, N'VideoFday29-06-17_1.webm', N'https://www.youtube.com/embed/Es6BuX1VXts')
INSERT [dbo].[Greeting] ([id], [photo], [categoryDetailsID], [video], [url]) VALUES (88, N'VideoFday29-06-17_2.jpg', 2, N'VideoFday29-06-17_2.webm', N'https://www.youtube.com/embed/itxhfXSqZnY')
INSERT [dbo].[Greeting] ([id], [photo], [categoryDetailsID], [video], [url]) VALUES (89, N'VideoFday29-06-17_3.jpg', 2, N'VideoFday29-06-17_3.webm', N'https://www.youtube.com/embed/Jrr4ZGAewSk')
INSERT [dbo].[Greeting] ([id], [photo], [categoryDetailsID], [video], [url]) VALUES (90, N'VideoFday29-06-17_4.jpg', 2, N'VideoFday29-06-17_4.webm', N'https://www.youtube.com/embed/LrGSbG7mBJo')
INSERT [dbo].[Greeting] ([id], [photo], [categoryDetailsID], [video], [url]) VALUES (91, N'VideoFday29-06-17_5.jpg', 2, N'VideoFday29-06-17_5.webm', N'https://www.youtube.com/embed/5YuTiCYXJsk')
INSERT [dbo].[Greeting] ([id], [photo], [categoryDetailsID], [video], [url]) VALUES (92, N'VideoModay29-06-17_1.jpg', 3, N'VideoModay29-06-17_1.webm', N'https://www.youtube.com/embed/b5L8dMUNzL0')
INSERT [dbo].[Greeting] ([id], [photo], [categoryDetailsID], [video], [url]) VALUES (93, N'VideoModay29-06-17_2.jpg', 3, N'VideoModay29-06-17_2.webm', N'https://www.youtube.com/embed/qLXZa2nEf4g')
INSERT [dbo].[Greeting] ([id], [photo], [categoryDetailsID], [video], [url]) VALUES (94, N'VideoModay29-06-17_3.jpg', 3, N'VideoModay29-06-17_3.webm', N'https://www.youtube.com/embed/lEyOyusqtz4')
INSERT [dbo].[Greeting] ([id], [photo], [categoryDetailsID], [video], [url]) VALUES (95, N'VideoModay29-06-17_4.jpg', 3, N'VideoModay29-06-17_4.webm', N'https://www.youtube.com/embed/03G4kMYkSY4')
INSERT [dbo].[Greeting] ([id], [photo], [categoryDetailsID], [video], [url]) VALUES (96, N'VideoModay29-06-17_5.jpg', 3, N'VideoModay29-06-17_5.webm', N'https://www.youtube.com/embed/lyReN3lgYco')
INSERT [dbo].[Greeting] ([id], [photo], [categoryDetailsID], [video], [url]) VALUES (97, N'VideoChrisday29-06-17_1.jpg', 4, N'VideoChrisday29-06-17_1.webm', N'https://www.youtube.com/embed/1pXoqb82kfM')
INSERT [dbo].[Greeting] ([id], [photo], [categoryDetailsID], [video], [url]) VALUES (98, N'VideoChrisday29-06-17_2.jpg', 4, N'VideoChrisday29-06-17_2.webm', N'https://www.youtube.com/embed/mG0F_OowRz8')
INSERT [dbo].[Greeting] ([id], [photo], [categoryDetailsID], [video], [url]) VALUES (99, N'VideoChrisday29-06-17_3.jpg', 4, N'VideoChrisday29-06-17_3.webm', N'https://www.youtube.com/embed/gxVkkHHB8Hk')
INSERT [dbo].[Greeting] ([id], [photo], [categoryDetailsID], [video], [url]) VALUES (100, N'VideoChrisday29-06-17_4.jpg', 4, N'VideoChrisday29-06-17_4.webm', N'https://www.youtube.com/embed/2-KL0jsY8sA')
INSERT [dbo].[Greeting] ([id], [photo], [categoryDetailsID], [video], [url]) VALUES (101, N'VideoChrisday29-06-17_5.jpg', 4, N'VideoChrisday29-06-17_5.webm', N'https://www.youtube.com/embed/IsByIuQA0Ps')
INSERT [dbo].[Greeting] ([id], [photo], [categoryDetailsID], [video], [url]) VALUES (102, N'VideoEaster29-06-17_1.jpg', 5, N'VideoEaster29-06-17_1.webm', N'https://www.youtube.com/embed/H68KiLYrDRM')
INSERT [dbo].[Greeting] ([id], [photo], [categoryDetailsID], [video], [url]) VALUES (103, N'VideoEaster29-06-17_2.jpg', 5, N'VideoEaster29-06-17_2.webm', N'https://www.youtube.com/embed/neqwL0dwA3Q')
INSERT [dbo].[Greeting] ([id], [photo], [categoryDetailsID], [video], [url]) VALUES (104, N'VideoEaster29-06-17_3.jpg', 5, N'VideoEaster29-06-17_3.webm', N'https://www.youtube.com/embed/8wcq9XdG4QE')
INSERT [dbo].[Greeting] ([id], [photo], [categoryDetailsID], [video], [url]) VALUES (105, N'VideoEaster29-06-17_4.jpg', 5, N'VideoEaster29-06-17_4.webm', N'https://www.youtube.com/embed/qSq8SrA4dlc')
INSERT [dbo].[Greeting] ([id], [photo], [categoryDetailsID], [video], [url]) VALUES (106, N'VideoEaster29-06-17_5.jpg', 5, N'VideoEaster29-06-17_5.webm', N'https://www.youtube.com/embed/BG7swagLRfY')
INSERT [dbo].[Greeting] ([id], [photo], [categoryDetailsID], [video], [url]) VALUES (107, N'VideoBirthday29-06-17_1.jpg', 6, N'VideoBirthday29-06-17_1.webm', N'https://www.youtube.com/embed/1pXoqb82kfM')
INSERT [dbo].[Greeting] ([id], [photo], [categoryDetailsID], [video], [url]) VALUES (108, N'VideoBirthday29-06-17_2.jpg', 6, N'VideoBirthday29-06-17_2.webm', N'https://www.youtube.com/embed/iI1zh-dADg0')
INSERT [dbo].[Greeting] ([id], [photo], [categoryDetailsID], [video], [url]) VALUES (109, N'VideoBirthday29-06-17_3.jpg', 6, N'VideoBirthday29-06-17_3.webm', N'https://www.youtube.com/embed/4A1HwUo5mbA')
INSERT [dbo].[Greeting] ([id], [photo], [categoryDetailsID], [video], [url]) VALUES (110, N'VideoBirthday29-06-17_4.jpg', 6, N'VideoBirthday29-06-17_4.webm', N'https://www.youtube.com/embed/szWJ1oCVSZ0')
INSERT [dbo].[Greeting] ([id], [photo], [categoryDetailsID], [video], [url]) VALUES (111, N'VideoBirthday29-06-17_5.jpg', 6, N'VideoBirthday29-06-17_5.webm', N'https://www.youtube.com/embed/7AToWhE7v9M')
INSERT [dbo].[Greeting] ([id], [photo], [categoryDetailsID], [video], [url]) VALUES (112, N'B_20-06-2017_3.jpg', 11, NULL, NULL)
INSERT [dbo].[Greeting] ([id], [photo], [categoryDetailsID], [video], [url]) VALUES (113, N'VideoEaster29-06-17_2.jpg', 11, N'VideoEaster29-06-17_2.webm', NULL)
SET IDENTITY_INSERT [dbo].[Greeting] OFF
INSERT [dbo].[Payment] ([accountId], [serviceId], [amount], [expiryDate], [paymentNumber], [Status]) VALUES (44, 2, 80.0000, CAST(N'2018-01-03' AS Date), NULL, 1)
INSERT [dbo].[Payment] ([accountId], [serviceId], [amount], [expiryDate], [paymentNumber], [Status]) VALUES (45, 1, 60.0000, CAST(N'2018-06-06' AS Date), NULL, 1)
INSERT [dbo].[Payment] ([accountId], [serviceId], [amount], [expiryDate], [paymentNumber], [Status]) VALUES (51, 5, 800.0000, CAST(N'2019-07-07' AS Date), NULL, 1)
INSERT [dbo].[Payment] ([accountId], [serviceId], [amount], [expiryDate], [paymentNumber], [Status]) VALUES (53, 2, 60.0000, CAST(N'2018-01-11' AS Date), NULL, 1)
INSERT [dbo].[Payment] ([accountId], [serviceId], [amount], [expiryDate], [paymentNumber], [Status]) VALUES (54, 3, 120.0000, CAST(N'2018-07-11' AS Date), NULL, 1)
INSERT [dbo].[Payment] ([accountId], [serviceId], [amount], [expiryDate], [paymentNumber], [Status]) VALUES (55, 3, 120.0000, CAST(N'2018-07-11' AS Date), NULL, 1)
INSERT [dbo].[Payment] ([accountId], [serviceId], [amount], [expiryDate], [paymentNumber], [Status]) VALUES (56, 3, 120.0000, CAST(N'2018-07-11' AS Date), NULL, 1)
INSERT [dbo].[Payment] ([accountId], [serviceId], [amount], [expiryDate], [paymentNumber], [Status]) VALUES (57, 3, 120.0000, CAST(N'2018-07-11' AS Date), NULL, 1)
SET IDENTITY_INSERT [dbo].[Role] ON 

INSERT [dbo].[Role] ([id], [name], [details]) VALUES (1, N'superadmin', N'')
INSERT [dbo].[Role] ([id], [name], [details]) VALUES (2, N'admin', NULL)
INSERT [dbo].[Role] ([id], [name], [details]) VALUES (3, N'employee', NULL)
SET IDENTITY_INSERT [dbo].[Role] OFF
SET IDENTITY_INSERT [dbo].[Sending] ON 

INSERT [dbo].[Sending] ([greetingId], [AccountId], [senderName], [rersiveName], [addressTo], [customMessenger], [id]) VALUES (1, 45, N'Tien hoang', N'Loc cho', N'akasakatien1995@gmail.com', N'hahahaha', 3)
INSERT [dbo].[Sending] ([greetingId], [AccountId], [senderName], [rersiveName], [addressTo], [customMessenger], [id]) VALUES (1, 45, N'Tien hoang', N'Loc cho', N'akasakatien1995@gmail.com', N'hahahaha', 4)
INSERT [dbo].[Sending] ([greetingId], [AccountId], [senderName], [rersiveName], [addressTo], [customMessenger], [id]) VALUES (1, 45, N'Tien hoang', N'Loc cho', N'akasakatien1995@gmail.com', N'hahahaha', 5)
INSERT [dbo].[Sending] ([greetingId], [AccountId], [senderName], [rersiveName], [addressTo], [customMessenger], [id]) VALUES (1, 45, N'Tien hoang', N'Loc cho', N'akasakatien1995@gmail.com', N'hahahaha', 6)
INSERT [dbo].[Sending] ([greetingId], [AccountId], [senderName], [rersiveName], [addressTo], [customMessenger], [id]) VALUES (1, 45, N'Trong', N'Loc', N'akasakatien2@gmail.com', N'Con cho de chung may chet de', 7)
INSERT [dbo].[Sending] ([greetingId], [AccountId], [senderName], [rersiveName], [addressTo], [customMessenger], [id]) VALUES (1, 45, N'Trong', N'Loc', N'akasakatien2@gmail.com', N'Con cho de', 8)
INSERT [dbo].[Sending] ([greetingId], [AccountId], [senderName], [rersiveName], [addressTo], [customMessenger], [id]) VALUES (1, 45, NULL, NULL, NULL, NULL, 9)
INSERT [dbo].[Sending] ([greetingId], [AccountId], [senderName], [rersiveName], [addressTo], [customMessenger], [id]) VALUES (1, 45, N'Loc', N'Trong', N'akasakatien2@gmail.com', N'smldkmasmsnd', 10)
INSERT [dbo].[Sending] ([greetingId], [AccountId], [senderName], [rersiveName], [addressTo], [customMessenger], [id]) VALUES (1, 45, NULL, NULL, NULL, NULL, 11)
INSERT [dbo].[Sending] ([greetingId], [AccountId], [senderName], [rersiveName], [addressTo], [customMessenger], [id]) VALUES (1, 45, N'Tron', N'Loc', N'akasakatien2@gmail.com', N'klmknalsndk', 12)
INSERT [dbo].[Sending] ([greetingId], [AccountId], [senderName], [rersiveName], [addressTo], [customMessenger], [id]) VALUES (1, 45, NULL, NULL, NULL, NULL, 13)
INSERT [dbo].[Sending] ([greetingId], [AccountId], [senderName], [rersiveName], [addressTo], [customMessenger], [id]) VALUES (1, 45, N'toen', N'snks', N'akasakatien2@gmail.com', N'askmkmknskndkas', 14)
INSERT [dbo].[Sending] ([greetingId], [AccountId], [senderName], [rersiveName], [addressTo], [customMessenger], [id]) VALUES (1, 45, N'tin', N'tienasd', N'akasakatien2@gmail.com', N'lkjmlknn', 15)
INSERT [dbo].[Sending] ([greetingId], [AccountId], [senderName], [rersiveName], [addressTo], [customMessenger], [id]) VALUES (1, 45, N'tien', N'trong', N'akasakatien2@gmail.com', N'ggchgfjfgnfgnf', 16)
INSERT [dbo].[Sending] ([greetingId], [AccountId], [senderName], [rersiveName], [addressTo], [customMessenger], [id]) VALUES (2, 45, N'fgdfgfdg', N'tien', N'akasakatien2@gmail.com', N'ryshhsdf', 17)
INSERT [dbo].[Sending] ([greetingId], [AccountId], [senderName], [rersiveName], [addressTo], [customMessenger], [id]) VALUES (1, 45, N'ghdhd', N'tien', N'akasakatien2@gmail.com', N'fdsdhdghdg', 18)
INSERT [dbo].[Sending] ([greetingId], [AccountId], [senderName], [rersiveName], [addressTo], [customMessenger], [id]) VALUES (1, 45, N'fdhdh', N'tien', N'akasakatien2@gmail.com', N'hdhfdd', 19)
INSERT [dbo].[Sending] ([greetingId], [AccountId], [senderName], [rersiveName], [addressTo], [customMessenger], [id]) VALUES (1, 45, N'tien', N'tring', N'akasakatien2@gmail.com', N'asndjsakdhn', 20)
INSERT [dbo].[Sending] ([greetingId], [AccountId], [senderName], [rersiveName], [addressTo], [customMessenger], [id]) VALUES (46, 47, N'hahaha', N'cho chih dh', N'akasakatien2@gmail.com', N'lsshkjhksfhidhfkjhkkjg jagsihkfalkakjhlkfs skghfaholealohsgekhols sehsohlseloflofsilh', 113)
INSERT [dbo].[Sending] ([greetingId], [AccountId], [senderName], [rersiveName], [addressTo], [customMessenger], [id]) VALUES (6, 47, N'sk cho ', N'ajknhdnja', N'akasakatien2@gmail.com', N'oiih kaskhkjhk hklka bkaskgkjasglks llhl', 114)
INSERT [dbo].[Sending] ([greetingId], [AccountId], [senderName], [rersiveName], [addressTo], [customMessenger], [id]) VALUES (48, 47, N'alk', N'aslkj', N'akasakatien2@gmail.com', N'ajaas jkhflasklj', 115)
INSERT [dbo].[Sending] ([greetingId], [AccountId], [senderName], [rersiveName], [addressTo], [customMessenger], [id]) VALUES (47, 47, N'df', N'fd', N'akasakatien2@gmail.com', N'df', 116)
INSERT [dbo].[Sending] ([greetingId], [AccountId], [senderName], [rersiveName], [addressTo], [customMessenger], [id]) VALUES (49, 45, N'asllsk', N'aasl', N'akasakatien2@gmail.com', N'sdtjlajsfjk', 117)
INSERT [dbo].[Sending] ([greetingId], [AccountId], [senderName], [rersiveName], [addressTo], [customMessenger], [id]) VALUES (47, 45, N'AAAdad', N'zxvz', N'akasakatien2@gmail.com', N'RGWEGREG', 118)
INSERT [dbo].[Sending] ([greetingId], [AccountId], [senderName], [rersiveName], [addressTo], [customMessenger], [id]) VALUES (110, 45, N'admsab', N'wmnb', N'akasakatien2@gmail.com', N'akjgm', 119)
INSERT [dbo].[Sending] ([greetingId], [AccountId], [senderName], [rersiveName], [addressTo], [customMessenger], [id]) VALUES (109, 45, N'gf', N'gcb', N'akasakatien2@gmail.com', N'hhhh', 120)
INSERT [dbo].[Sending] ([greetingId], [AccountId], [senderName], [rersiveName], [addressTo], [customMessenger], [id]) VALUES (109, 44, N'a', N'a', N'akasakatien2@gmail.com', N'a', 121)
INSERT [dbo].[Sending] ([greetingId], [AccountId], [senderName], [rersiveName], [addressTo], [customMessenger], [id]) VALUES (109, 45, N'a', N'a', N'akasakatien2@gmail.com', N'a', 122)
INSERT [dbo].[Sending] ([greetingId], [AccountId], [senderName], [rersiveName], [addressTo], [customMessenger], [id]) VALUES (112, 45, N'sds', N'dsds', N'akasakatien2@gmail.com', N'trt', 123)
INSERT [dbo].[Sending] ([greetingId], [AccountId], [senderName], [rersiveName], [addressTo], [customMessenger], [id]) VALUES (111, 45, N'admsab', N'aaa', N'workout77.pk@gmail.com', N'a', 124)
INSERT [dbo].[Sending] ([greetingId], [AccountId], [senderName], [rersiveName], [addressTo], [customMessenger], [id]) VALUES (113, 52, N'Akasaka', N'Tien', N'akasakatien2@gmail.com', N'H a p p y  E a s t e r', 125)
INSERT [dbo].[Sending] ([greetingId], [AccountId], [senderName], [rersiveName], [addressTo], [customMessenger], [id]) VALUES (107, 52, N'akasaka', N'tien', N'akasakatien2@gmail.com', N'H a p p y  B i r t h d a y ', 126)
INSERT [dbo].[Sending] ([greetingId], [AccountId], [senderName], [rersiveName], [addressTo], [customMessenger], [id]) VALUES (112, 45, N'tom ', N'akasaka', N'akasakatien2@gmail.com', N'happy birth day to my friends', 127)
INSERT [dbo].[Sending] ([greetingId], [AccountId], [senderName], [rersiveName], [addressTo], [customMessenger], [id]) VALUES (112, 53, N'akasaka', N'tien', N'akasakatien2@gmail.com', N'me cha ni ra', 128)
INSERT [dbo].[Sending] ([greetingId], [AccountId], [senderName], [rersiveName], [addressTo], [customMessenger], [id]) VALUES (112, 45, N'dcdc', N'dcdc', N'akasakatien2@gmail.com', N'dcdc', 129)
SET IDENTITY_INSERT [dbo].[Sending] OFF
SET IDENTITY_INSERT [dbo].[Service] ON 

INSERT [dbo].[Service] ([id], [name], [price]) VALUES (1, 1, 10.0000)
INSERT [dbo].[Service] ([id], [name], [price]) VALUES (2, 6, 60.0000)
INSERT [dbo].[Service] ([id], [name], [price]) VALUES (3, 12, 120.0000)
INSERT [dbo].[Service] ([id], [name], [price]) VALUES (5, 24, 800.0000)
SET IDENTITY_INSERT [dbo].[Service] OFF
ALTER TABLE [dbo].[Account]  WITH CHECK ADD  CONSTRAINT [FK_Account_Role] FOREIGN KEY([roldId])
REFERENCES [dbo].[Role] ([id])
GO
ALTER TABLE [dbo].[Account] CHECK CONSTRAINT [FK_Account_Role]
GO
ALTER TABLE [dbo].[Category_Details]  WITH CHECK ADD  CONSTRAINT [FK_Category_Details_Category] FOREIGN KEY([categoryID])
REFERENCES [dbo].[Category] ([id])
GO
ALTER TABLE [dbo].[Category_Details] CHECK CONSTRAINT [FK_Category_Details_Category]
GO
ALTER TABLE [dbo].[Greeting]  WITH CHECK ADD  CONSTRAINT [FK_Greeting_Category_Details] FOREIGN KEY([categoryDetailsID])
REFERENCES [dbo].[Category_Details] ([id])
GO
ALTER TABLE [dbo].[Greeting] CHECK CONSTRAINT [FK_Greeting_Category_Details]
GO
ALTER TABLE [dbo].[Payment]  WITH CHECK ADD  CONSTRAINT [FK_Payment_Account] FOREIGN KEY([accountId])
REFERENCES [dbo].[Account] ([id])
GO
ALTER TABLE [dbo].[Payment] CHECK CONSTRAINT [FK_Payment_Account]
GO
ALTER TABLE [dbo].[Payment]  WITH CHECK ADD  CONSTRAINT [FK_Payment_Service] FOREIGN KEY([serviceId])
REFERENCES [dbo].[Service] ([id])
GO
ALTER TABLE [dbo].[Payment] CHECK CONSTRAINT [FK_Payment_Service]
GO
ALTER TABLE [dbo].[Sending]  WITH CHECK ADD  CONSTRAINT [FK_Sending_Account] FOREIGN KEY([AccountId])
REFERENCES [dbo].[Account] ([id])
GO
ALTER TABLE [dbo].[Sending] CHECK CONSTRAINT [FK_Sending_Account]
GO
ALTER TABLE [dbo].[Sending]  WITH CHECK ADD  CONSTRAINT [FK_Sending_Greeting] FOREIGN KEY([greetingId])
REFERENCES [dbo].[Greeting] ([id])
GO
ALTER TABLE [dbo].[Sending] CHECK CONSTRAINT [FK_Sending_Greeting]
GO
