USE [qlsv]
GO
/****** Object:  Table [dbo].[tbl_lophoc]    Script Date: 5/27/2026 3:28:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_lophoc](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[malop] [varchar](20) NULL,
	[tenlop] [nvarchar](100) NULL,
	[ghichu] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_sinhviens]    Script Date: 5/27/2026 3:28:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_sinhviens](
	[id] [int] NOT NULL,
	[hoten] [nvarchar](100) NULL,
	[gioitinh] [nvarchar](10) NULL,
	[ngaysinh] [date] NULL,
	[malop] [varchar](20) NULL,
 CONSTRAINT [PK__tbl_sinh__3213E83F2A508AF7] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[tbl_lophoc] ON 

INSERT [dbo].[tbl_lophoc] ([id], [malop], [tenlop], [ghichu]) 
VALUES (1, N'CNTT03', N'Công nghệ thông tin 3', N'Lớp lập trình web')

INSERT [dbo].[tbl_lophoc] ([id], [malop], [tenlop], [ghichu]) 
VALUES (2, N'CNTT04', N'Công nghệ thông tin 4', N'Lớp phát triển phần mềm')

INSERT [dbo].[tbl_lophoc] ([id], [malop], [tenlop], [ghichu]) 
VALUES (3, N'MKT01', N'Marketing 1', N'Lớp marketing căn bản')

INSERT [dbo].[tbl_lophoc] ([id], [malop], [tenlop], [ghichu]) 
VALUES (4, N'TCNH01', N'Tài chính ngân hàng 1', N'Lớp tài chính')

INSERT [dbo].[tbl_lophoc] ([id], [malop], [tenlop], [ghichu]) 
VALUES (5, N'NN01', N'Ngôn ngữ Anh 1', N'Lớp tiếng Anh thương mại')

SET IDENTITY_INSERT [dbo].[tbl_lophoc] OFF
GO

INSERT [dbo].[tbl_sinhviens] ([id], [hoten], [gioitinh], [ngaysinh], [malop]) 
VALUES (1, N'Đỗ Minh Quân', N'Nam', CAST(N'2004-02-18' AS Date), N'CNTT03')

INSERT [dbo].[tbl_sinhviens] ([id], [hoten], [gioitinh], [ngaysinh], [malop]) 
VALUES (2, N'Nguyễn Thu Hà', N'Nữ', CAST(N'2005-06-25' AS Date), N'CNTT04')

INSERT [dbo].[tbl_sinhviens] ([id], [hoten], [gioitinh], [ngaysinh], [malop]) 
VALUES (3, N'Phan Quốc Khánh', N'Nam', CAST(N'2004-08-11' AS Date), N'MKT01')

INSERT [dbo].[tbl_sinhviens] ([id], [hoten], [gioitinh], [ngaysinh], [malop]) 
VALUES (4, N'Bùi Thảo My', N'Nữ', CAST(N'2005-12-03' AS Date), N'TCNH01')

INSERT [dbo].[tbl_sinhviens] ([id], [hoten], [gioitinh], [ngaysinh], [malop]) 
VALUES (5, N'Trịnh Gia Huy', N'Nam', CAST(N'2004-10-09' AS Date), N'NN01')

INSERT [dbo].[tbl_sinhviens] ([id], [hoten], [gioitinh], [ngaysinh], [malop]) 
VALUES (6, N'Lý Thanh Tùng', N'Nam', CAST(N'2005-04-14' AS Date), N'CNTT03')

INSERT [dbo].[tbl_sinhviens] ([id], [hoten], [gioitinh], [ngaysinh], [malop]) 
VALUES (7, N'Võ Ngọc Ánh', N'Nữ', CAST(N'2005-01-30' AS Date), N'CNTT04')
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__tbl_loph__15F456FC6051030B]    Script Date: 5/27/2026 3:28:12 PM ******/
ALTER TABLE [dbo].[tbl_lophoc] ADD UNIQUE NONCLUSTERED 
(
	[malop] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[tbl_sinhviens]  WITH CHECK ADD  CONSTRAINT [FK_SinhVien_LopHoc] FOREIGN KEY([malop])
REFERENCES [dbo].[tbl_lophoc] ([malop])
GO
ALTER TABLE [dbo].[tbl_sinhviens] CHECK CONSTRAINT [FK_SinhVien_LopHoc]
GO
