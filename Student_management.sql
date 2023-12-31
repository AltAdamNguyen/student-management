USE [Student_Management]
GO
/****** Object:  Table [dbo].[Admin]    Script Date: 8/31/2023 12:56:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Admin](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[email] [nvarchar](50) NOT NULL,
	[password] [nvarchar](max) NOT NULL,
	[name] [nvarchar](max) NOT NULL,
	[active] [bit] NOT NULL,
 CONSTRAINT [PK_Admin] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Attendance]    Script Date: 8/31/2023 12:56:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Attendance](
	[id] [nvarchar](100) NOT NULL,
	[schedule_id] [nvarchar](50) NOT NULL,
	[student_code] [nvarchar](50) NOT NULL,
	[attended] [int] NOT NULL,
 CONSTRAINT [PK_Attendance] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Building]    Script Date: 8/31/2023 12:56:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Building](
	[id] [nvarchar](50) NOT NULL,
	[name] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Building_1] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Class]    Script Date: 8/31/2023 12:56:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Class](
	[id] [nvarchar](50) NOT NULL,
	[name] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Class] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Class_Student]    Script Date: 8/31/2023 12:56:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Class_Student](
	[id] [nvarchar](50) NOT NULL,
	[class_id] [nvarchar](50) NOT NULL,
	[student_code] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Class_Student] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Class_Teacher]    Script Date: 8/31/2023 12:56:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Class_Teacher](
	[class_id] [nvarchar](50) NOT NULL,
	[teacher_code] [nvarchar](50) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Classroom]    Script Date: 8/31/2023 12:56:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Classroom](
	[id] [nvarchar](50) NOT NULL,
	[name] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Classroom_1] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Location]    Script Date: 8/31/2023 12:56:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Location](
	[id] [nvarchar](50) NOT NULL,
	[building_id] [nvarchar](50) NOT NULL,
	[classroom_id] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Location] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Schedule]    Script Date: 8/31/2023 12:56:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Schedule](
	[id] [nvarchar](50) NOT NULL,
	[class_id] [nvarchar](50) NOT NULL,
	[teacher_code] [nvarchar](50) NOT NULL,
	[subject_code] [nvarchar](50) NOT NULL,
	[date_time] [date] NOT NULL,
	[slot] [int] NOT NULL,
	[location_id] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Schedule] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Student]    Script Date: 8/31/2023 12:56:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Student](
	[code] [nvarchar](50) NOT NULL,
	[email] [nvarchar](50) NOT NULL,
	[password] [nvarchar](max) NOT NULL,
	[name] [nvarchar](max) NOT NULL,
	[gender] [bit] NOT NULL,
	[active] [bit] NOT NULL,
	[account] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Student_1] PRIMARY KEY CLUSTERED 
(
	[code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Subject]    Script Date: 8/31/2023 12:56:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Subject](
	[code] [nvarchar](50) NOT NULL,
	[name] [nvarchar](max) NOT NULL,
	[descript] [nvarchar](max) NULL,
	[duration] [int] NOT NULL,
	[weekly_session] [int] NOT NULL,
 CONSTRAINT [PK_Subject_1] PRIMARY KEY CLUSTERED 
(
	[code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Teacher]    Script Date: 8/31/2023 12:56:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Teacher](
	[code] [nvarchar](50) NOT NULL,
	[email] [nvarchar](50) NOT NULL,
	[account] [nvarchar](50) NOT NULL,
	[password] [nvarchar](50) NOT NULL,
	[name] [nvarchar](max) NOT NULL,
	[gender] [bit] NOT NULL,
	[active] [bit] NOT NULL,
 CONSTRAINT [PK_Teacher_1] PRIMARY KEY CLUSTERED 
(
	[code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[Attendance] ([id], [schedule_id], [student_code], [attended]) VALUES (N'01/11/2023_2_HE111111', N'01/11/2023_2', N'HE111111', -1)
INSERT [dbo].[Attendance] ([id], [schedule_id], [student_code], [attended]) VALUES (N'01/11/2023_2_HE123445', N'01/11/2023_2', N'HE123445', -1)
INSERT [dbo].[Attendance] ([id], [schedule_id], [student_code], [attended]) VALUES (N'02/10/2023_2_HE111111', N'02/10/2023_2', N'HE111111', -1)
INSERT [dbo].[Attendance] ([id], [schedule_id], [student_code], [attended]) VALUES (N'02/10/2023_2_HE123445', N'02/10/2023_2', N'HE123445', -1)
INSERT [dbo].[Attendance] ([id], [schedule_id], [student_code], [attended]) VALUES (N'04/09/2023_2_HE111111', N'04/09/2023_2', N'HE111111', 1)
INSERT [dbo].[Attendance] ([id], [schedule_id], [student_code], [attended]) VALUES (N'04/09/2023_2_HE123445', N'04/09/2023_2', N'HE123445', 1)
INSERT [dbo].[Attendance] ([id], [schedule_id], [student_code], [attended]) VALUES (N'04/10/2023_2_HE111111', N'04/10/2023_2', N'HE111111', -1)
INSERT [dbo].[Attendance] ([id], [schedule_id], [student_code], [attended]) VALUES (N'04/10/2023_2_HE123445', N'04/10/2023_2', N'HE123445', -1)
INSERT [dbo].[Attendance] ([id], [schedule_id], [student_code], [attended]) VALUES (N'06/09/2023_2_HE111111', N'06/09/2023_2', N'HE111111', -1)
INSERT [dbo].[Attendance] ([id], [schedule_id], [student_code], [attended]) VALUES (N'06/09/2023_2_HE123445', N'06/09/2023_2', N'HE123445', -1)
INSERT [dbo].[Attendance] ([id], [schedule_id], [student_code], [attended]) VALUES (N'06/11/2023_2_HE111111', N'06/11/2023_2', N'HE111111', -1)
INSERT [dbo].[Attendance] ([id], [schedule_id], [student_code], [attended]) VALUES (N'06/11/2023_2_HE123445', N'06/11/2023_2', N'HE123445', -1)
INSERT [dbo].[Attendance] ([id], [schedule_id], [student_code], [attended]) VALUES (N'08/11/2023_2_HE111111', N'08/11/2023_2', N'HE111111', -1)
INSERT [dbo].[Attendance] ([id], [schedule_id], [student_code], [attended]) VALUES (N'08/11/2023_2_HE123445', N'08/11/2023_2', N'HE123445', -1)
INSERT [dbo].[Attendance] ([id], [schedule_id], [student_code], [attended]) VALUES (N'09/10/2023_2_HE111111', N'09/10/2023_2', N'HE111111', -1)
INSERT [dbo].[Attendance] ([id], [schedule_id], [student_code], [attended]) VALUES (N'09/10/2023_2_HE123445', N'09/10/2023_2', N'HE123445', -1)
INSERT [dbo].[Attendance] ([id], [schedule_id], [student_code], [attended]) VALUES (N'11/09/2023_2_HE111111', N'11/09/2023_2', N'HE111111', -1)
INSERT [dbo].[Attendance] ([id], [schedule_id], [student_code], [attended]) VALUES (N'11/09/2023_2_HE123445', N'11/09/2023_2', N'HE123445', -1)
INSERT [dbo].[Attendance] ([id], [schedule_id], [student_code], [attended]) VALUES (N'11/10/2023_2_HE111111', N'11/10/2023_2', N'HE111111', -1)
INSERT [dbo].[Attendance] ([id], [schedule_id], [student_code], [attended]) VALUES (N'11/10/2023_2_HE123445', N'11/10/2023_2', N'HE123445', -1)
INSERT [dbo].[Attendance] ([id], [schedule_id], [student_code], [attended]) VALUES (N'13/09/2023_2_HE111111', N'13/09/2023_2', N'HE111111', -1)
INSERT [dbo].[Attendance] ([id], [schedule_id], [student_code], [attended]) VALUES (N'13/09/2023_2_HE123445', N'13/09/2023_2', N'HE123445', -1)
INSERT [dbo].[Attendance] ([id], [schedule_id], [student_code], [attended]) VALUES (N'16/10/2023_2_HE111111', N'16/10/2023_2', N'HE111111', -1)
INSERT [dbo].[Attendance] ([id], [schedule_id], [student_code], [attended]) VALUES (N'16/10/2023_2_HE123445', N'16/10/2023_2', N'HE123445', -1)
INSERT [dbo].[Attendance] ([id], [schedule_id], [student_code], [attended]) VALUES (N'18/09/2023_2_HE111111', N'18/09/2023_2', N'HE111111', -1)
INSERT [dbo].[Attendance] ([id], [schedule_id], [student_code], [attended]) VALUES (N'18/09/2023_2_HE123445', N'18/09/2023_2', N'HE123445', -1)
INSERT [dbo].[Attendance] ([id], [schedule_id], [student_code], [attended]) VALUES (N'18/10/2023_2_HE111111', N'18/10/2023_2', N'HE111111', -1)
INSERT [dbo].[Attendance] ([id], [schedule_id], [student_code], [attended]) VALUES (N'18/10/2023_2_HE123445', N'18/10/2023_2', N'HE123445', -1)
INSERT [dbo].[Attendance] ([id], [schedule_id], [student_code], [attended]) VALUES (N'20/09/2023_2_HE111111', N'20/09/2023_2', N'HE111111', -1)
INSERT [dbo].[Attendance] ([id], [schedule_id], [student_code], [attended]) VALUES (N'20/09/2023_2_HE123445', N'20/09/2023_2', N'HE123445', -1)
INSERT [dbo].[Attendance] ([id], [schedule_id], [student_code], [attended]) VALUES (N'23/10/2023_2_HE111111', N'23/10/2023_2', N'HE111111', -1)
INSERT [dbo].[Attendance] ([id], [schedule_id], [student_code], [attended]) VALUES (N'23/10/2023_2_HE123445', N'23/10/2023_2', N'HE123445', -1)
INSERT [dbo].[Attendance] ([id], [schedule_id], [student_code], [attended]) VALUES (N'25/09/2023_2_HE111111', N'25/09/2023_2', N'HE111111', -1)
INSERT [dbo].[Attendance] ([id], [schedule_id], [student_code], [attended]) VALUES (N'25/09/2023_2_HE123445', N'25/09/2023_2', N'HE123445', -1)
INSERT [dbo].[Attendance] ([id], [schedule_id], [student_code], [attended]) VALUES (N'25/10/2023_2_HE111111', N'25/10/2023_2', N'HE111111', -1)
INSERT [dbo].[Attendance] ([id], [schedule_id], [student_code], [attended]) VALUES (N'25/10/2023_2_HE123445', N'25/10/2023_2', N'HE123445', -1)
INSERT [dbo].[Attendance] ([id], [schedule_id], [student_code], [attended]) VALUES (N'27/09/2023_2_HE111111', N'27/09/2023_2', N'HE111111', -1)
INSERT [dbo].[Attendance] ([id], [schedule_id], [student_code], [attended]) VALUES (N'27/09/2023_2_HE123445', N'27/09/2023_2', N'HE123445', -1)
INSERT [dbo].[Attendance] ([id], [schedule_id], [student_code], [attended]) VALUES (N'30/10/2023_2_HE111111', N'30/10/2023_2', N'HE111111', -1)
INSERT [dbo].[Attendance] ([id], [schedule_id], [student_code], [attended]) VALUES (N'30/10/2023_2_HE123445', N'30/10/2023_2', N'HE123445', -1)
GO
INSERT [dbo].[Building] ([id], [name]) VALUES (N'AL', N'Alpha')
INSERT [dbo].[Building] ([id], [name]) VALUES (N'BT', N'Beta')
GO
INSERT [dbo].[Class] ([id], [name]) VALUES (N'a', N'abc')
GO
INSERT [dbo].[Class_Student] ([id], [class_id], [student_code]) VALUES (N'a_HE111111', N'a', N'HE111111')
INSERT [dbo].[Class_Student] ([id], [class_id], [student_code]) VALUES (N'a_HE123445', N'a', N'HE123445')
GO
INSERT [dbo].[Classroom] ([id], [name]) VALUES (N'AL_L201', N'201(abc)')
INSERT [dbo].[Classroom] ([id], [name]) VALUES (N'AL_R201', N'201')
INSERT [dbo].[Classroom] ([id], [name]) VALUES (N'BT_201', N'201')
GO
INSERT [dbo].[Location] ([id], [building_id], [classroom_id]) VALUES (N'AL_L201', N'AL', N'AL_L201')
INSERT [dbo].[Location] ([id], [building_id], [classroom_id]) VALUES (N'AL_R201', N'AL', N'AL_R201')
INSERT [dbo].[Location] ([id], [building_id], [classroom_id]) VALUES (N'BT_201', N'BT', N'BT_201')
GO
INSERT [dbo].[Schedule] ([id], [class_id], [teacher_code], [subject_code], [date_time], [slot], [location_id]) VALUES (N'01/11/2023_2', N'a', N'GV12345', N'SWE', CAST(N'2023-11-01' AS Date), 2, N'AL_L201')
INSERT [dbo].[Schedule] ([id], [class_id], [teacher_code], [subject_code], [date_time], [slot], [location_id]) VALUES (N'02/10/2023_2', N'a', N'GV12345', N'SWE', CAST(N'2023-10-02' AS Date), 2, N'AL_L201')
INSERT [dbo].[Schedule] ([id], [class_id], [teacher_code], [subject_code], [date_time], [slot], [location_id]) VALUES (N'04/09/2023_2', N'a', N'GV12345', N'SWE', CAST(N'2023-09-04' AS Date), 2, N'AL_L201')
INSERT [dbo].[Schedule] ([id], [class_id], [teacher_code], [subject_code], [date_time], [slot], [location_id]) VALUES (N'04/10/2023_2', N'a', N'GV12345', N'SWE', CAST(N'2023-10-04' AS Date), 2, N'AL_L201')
INSERT [dbo].[Schedule] ([id], [class_id], [teacher_code], [subject_code], [date_time], [slot], [location_id]) VALUES (N'06/09/2023_2', N'a', N'GV12345', N'SWE', CAST(N'2023-09-06' AS Date), 2, N'AL_L201')
INSERT [dbo].[Schedule] ([id], [class_id], [teacher_code], [subject_code], [date_time], [slot], [location_id]) VALUES (N'06/11/2023_2', N'a', N'GV12345', N'SWE', CAST(N'2023-11-06' AS Date), 2, N'AL_L201')
INSERT [dbo].[Schedule] ([id], [class_id], [teacher_code], [subject_code], [date_time], [slot], [location_id]) VALUES (N'08/11/2023_2', N'a', N'GV12345', N'SWE', CAST(N'2023-11-08' AS Date), 2, N'AL_L201')
INSERT [dbo].[Schedule] ([id], [class_id], [teacher_code], [subject_code], [date_time], [slot], [location_id]) VALUES (N'09/10/2023_2', N'a', N'GV12345', N'SWE', CAST(N'2023-10-09' AS Date), 2, N'AL_L201')
INSERT [dbo].[Schedule] ([id], [class_id], [teacher_code], [subject_code], [date_time], [slot], [location_id]) VALUES (N'11/09/2023_2', N'a', N'GV12345', N'SWE', CAST(N'2023-09-11' AS Date), 2, N'AL_L201')
INSERT [dbo].[Schedule] ([id], [class_id], [teacher_code], [subject_code], [date_time], [slot], [location_id]) VALUES (N'11/10/2023_2', N'a', N'GV12345', N'SWE', CAST(N'2023-10-11' AS Date), 2, N'AL_L201')
INSERT [dbo].[Schedule] ([id], [class_id], [teacher_code], [subject_code], [date_time], [slot], [location_id]) VALUES (N'13/09/2023_2', N'a', N'GV12345', N'SWE', CAST(N'2023-09-13' AS Date), 2, N'AL_L201')
INSERT [dbo].[Schedule] ([id], [class_id], [teacher_code], [subject_code], [date_time], [slot], [location_id]) VALUES (N'16/10/2023_2', N'a', N'GV12345', N'SWE', CAST(N'2023-10-16' AS Date), 2, N'AL_L201')
INSERT [dbo].[Schedule] ([id], [class_id], [teacher_code], [subject_code], [date_time], [slot], [location_id]) VALUES (N'18/09/2023_2', N'a', N'GV12345', N'SWE', CAST(N'2023-09-18' AS Date), 2, N'AL_L201')
INSERT [dbo].[Schedule] ([id], [class_id], [teacher_code], [subject_code], [date_time], [slot], [location_id]) VALUES (N'18/10/2023_2', N'a', N'GV12345', N'SWE', CAST(N'2023-10-18' AS Date), 2, N'AL_L201')
INSERT [dbo].[Schedule] ([id], [class_id], [teacher_code], [subject_code], [date_time], [slot], [location_id]) VALUES (N'20/09/2023_2', N'a', N'GV12345', N'SWE', CAST(N'2023-09-20' AS Date), 2, N'AL_L201')
INSERT [dbo].[Schedule] ([id], [class_id], [teacher_code], [subject_code], [date_time], [slot], [location_id]) VALUES (N'23/10/2023_2', N'a', N'GV12345', N'SWE', CAST(N'2023-10-23' AS Date), 2, N'AL_L201')
INSERT [dbo].[Schedule] ([id], [class_id], [teacher_code], [subject_code], [date_time], [slot], [location_id]) VALUES (N'25/09/2023_2', N'a', N'GV12345', N'SWE', CAST(N'2023-09-25' AS Date), 2, N'AL_L201')
INSERT [dbo].[Schedule] ([id], [class_id], [teacher_code], [subject_code], [date_time], [slot], [location_id]) VALUES (N'25/10/2023_2', N'a', N'GV12345', N'SWE', CAST(N'2023-10-25' AS Date), 2, N'AL_L201')
INSERT [dbo].[Schedule] ([id], [class_id], [teacher_code], [subject_code], [date_time], [slot], [location_id]) VALUES (N'27/09/2023_2', N'a', N'GV12345', N'SWE', CAST(N'2023-09-27' AS Date), 2, N'AL_L201')
INSERT [dbo].[Schedule] ([id], [class_id], [teacher_code], [subject_code], [date_time], [slot], [location_id]) VALUES (N'30/10/2023_2', N'a', N'GV12345', N'SWE', CAST(N'2023-10-30' AS Date), 2, N'AL_L201')
GO
INSERT [dbo].[Student] ([code], [email], [password], [name], [gender], [active], [account]) VALUES (N'HE111111', N'thaitnhe111111@email.com', N'123456aA@', N'Trịnh Ngọc Thái', 1, 1, N'ThaiTNHE111111')
INSERT [dbo].[Student] ([code], [email], [password], [name], [gender], [active], [account]) VALUES (N'HE123445', N'tungnmhe123445@email.com', N'123456aA@', N'Nguyễn Mạnh Tùng', 0, 1, N'TungNMHE123445')
INSERT [dbo].[Student] ([code], [email], [password], [name], [gender], [active], [account]) VALUES (N'HE141111', N'anhnthe141111@email.com', N'123456aA@', N'Ngô Tuấn Anh', 1, 1, N'AnhNTHE141111')
INSERT [dbo].[Student] ([code], [email], [password], [name], [gender], [active], [account]) VALUES (N'HE141233', N'trungdvhhe141233@email.com', N'123456aA@', N'Đặng Vũ Hoàng Trung', 1, 1, N'TrungDVHHE141233')
INSERT [dbo].[Student] ([code], [email], [password], [name], [gender], [active], [account]) VALUES (N'HE141236', N'anhnche141236@email.com', N'123456aA@', N'Nguyễn Công Anh', 1, 1, N'AnhNCHE141236')
GO
INSERT [dbo].[Subject] ([code], [name], [descript], [duration], [weekly_session]) VALUES (N'SWE', N'Software Engineering', N'Học làm người', 10, 2)
INSERT [dbo].[Subject] ([code], [name], [descript], [duration], [weekly_session]) VALUES (N'SWR', N'Software Requirement', N'Học chống mù', 10, 2)
GO
INSERT [dbo].[Teacher] ([code], [email], [account], [password], [name], [gender], [active]) VALUES (N'GV12345', N'anhncgv12345@email.com', N'AnhNCGV12345', N'123456aA@', N'Nguyễn Công Anh', 1, 1)
INSERT [dbo].[Teacher] ([code], [email], [account], [password], [name], [gender], [active]) VALUES (N'GV12435', N'thaitngv12435@email.com', N'ThaiTNGV12435', N'123456aA@', N'Trịnh Ngọc Thái', 1, 1)
GO
ALTER TABLE [dbo].[Attendance]  WITH CHECK ADD  CONSTRAINT [FK_Attendance_Schedule] FOREIGN KEY([schedule_id])
REFERENCES [dbo].[Schedule] ([id])
GO
ALTER TABLE [dbo].[Attendance] CHECK CONSTRAINT [FK_Attendance_Schedule]
GO
ALTER TABLE [dbo].[Attendance]  WITH CHECK ADD  CONSTRAINT [FK_Attendance_Student] FOREIGN KEY([student_code])
REFERENCES [dbo].[Student] ([code])
GO
ALTER TABLE [dbo].[Attendance] CHECK CONSTRAINT [FK_Attendance_Student]
GO
ALTER TABLE [dbo].[Class_Student]  WITH CHECK ADD  CONSTRAINT [FK_Class_Student_Class] FOREIGN KEY([class_id])
REFERENCES [dbo].[Class] ([id])
GO
ALTER TABLE [dbo].[Class_Student] CHECK CONSTRAINT [FK_Class_Student_Class]
GO
ALTER TABLE [dbo].[Class_Student]  WITH CHECK ADD  CONSTRAINT [FK_Class_Student_Student] FOREIGN KEY([student_code])
REFERENCES [dbo].[Student] ([code])
GO
ALTER TABLE [dbo].[Class_Student] CHECK CONSTRAINT [FK_Class_Student_Student]
GO
ALTER TABLE [dbo].[Class_Teacher]  WITH CHECK ADD  CONSTRAINT [FK_Class_Teacher_Class] FOREIGN KEY([class_id])
REFERENCES [dbo].[Class] ([id])
GO
ALTER TABLE [dbo].[Class_Teacher] CHECK CONSTRAINT [FK_Class_Teacher_Class]
GO
ALTER TABLE [dbo].[Class_Teacher]  WITH CHECK ADD  CONSTRAINT [FK_Class_Teacher_Teacher] FOREIGN KEY([teacher_code])
REFERENCES [dbo].[Teacher] ([code])
GO
ALTER TABLE [dbo].[Class_Teacher] CHECK CONSTRAINT [FK_Class_Teacher_Teacher]
GO
ALTER TABLE [dbo].[Location]  WITH CHECK ADD  CONSTRAINT [FK_Location_Building1] FOREIGN KEY([building_id])
REFERENCES [dbo].[Building] ([id])
GO
ALTER TABLE [dbo].[Location] CHECK CONSTRAINT [FK_Location_Building1]
GO
ALTER TABLE [dbo].[Location]  WITH CHECK ADD  CONSTRAINT [FK_Location_Classroom1] FOREIGN KEY([classroom_id])
REFERENCES [dbo].[Classroom] ([id])
GO
ALTER TABLE [dbo].[Location] CHECK CONSTRAINT [FK_Location_Classroom1]
GO
ALTER TABLE [dbo].[Schedule]  WITH CHECK ADD  CONSTRAINT [FK_Schedule_Class] FOREIGN KEY([class_id])
REFERENCES [dbo].[Class] ([id])
GO
ALTER TABLE [dbo].[Schedule] CHECK CONSTRAINT [FK_Schedule_Class]
GO
ALTER TABLE [dbo].[Schedule]  WITH CHECK ADD  CONSTRAINT [FK_Schedule_Location1] FOREIGN KEY([location_id])
REFERENCES [dbo].[Location] ([id])
GO
ALTER TABLE [dbo].[Schedule] CHECK CONSTRAINT [FK_Schedule_Location1]
GO
ALTER TABLE [dbo].[Schedule]  WITH CHECK ADD  CONSTRAINT [FK_Schedule_Subject] FOREIGN KEY([subject_code])
REFERENCES [dbo].[Subject] ([code])
GO
ALTER TABLE [dbo].[Schedule] CHECK CONSTRAINT [FK_Schedule_Subject]
GO
ALTER TABLE [dbo].[Schedule]  WITH CHECK ADD  CONSTRAINT [FK_Schedule_Teacher] FOREIGN KEY([teacher_code])
REFERENCES [dbo].[Teacher] ([code])
GO
ALTER TABLE [dbo].[Schedule] CHECK CONSTRAINT [FK_Schedule_Teacher]
GO
