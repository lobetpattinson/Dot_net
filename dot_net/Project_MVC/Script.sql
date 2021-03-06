USE [Web_DenLed]
GO
/****** Object:  StoredProcedure [dbo].[ListProductByCat]    Script Date: 16/6/16 11:49:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[ListProductByCat]
@Cat int
As
begin



select * from tblProducts x,
(select ProductID, CategoryID from tblCategoryProducts where CategoryID=@Cat)c
where x.ProductID=c.ProductID
end


GO
/****** Object:  StoredProcedure [dbo].[Sp_Account_Login]    Script Date: 16/6/16 11:49:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[Sp_Account_Login]
@UserName varchar(50),
@Password varchar(50)
As
begin
	declare @count int
	declare @res bit
	select @count =count (*) from tblUsers where Account=@UserName and Password=@Password
	if @count>0 
	set @res=1
	else set @res=0
	select @res
end


GO
/****** Object:  StoredProcedure [dbo].[tblCategory_Insert]    Script Date: 16/6/16 11:49:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[tblCategory_Insert]
@MetaTitle nvarchar(250),
@Name nvarchar(250),
@Levels int,
@ParentID int,
@SEOTitle nvarchar(250),


@TypeID int
as
insert into tblCategories (MetaTitle,Name,Levels,ParentID,SEOTitle,TypeID)
values
(@MetaTitle,@Name,@Levels,@ParentID,@SEOTitle,@TypeID)


GO
/****** Object:  StoredProcedure [dbo].[tblCategory_List]    Script Date: 16/6/16 11:49:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[tblCategory_List]
as
select * from tblCategories
order by
CreateDate


GO
/****** Object:  StoredProcedure [dbo].[tblProducts_List]    Script Date: 16/6/16 11:49:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[tblProducts_List]
as select * from tblProducts


GO
/****** Object:  Table [dbo].[tblCategories]    Script Date: 16/6/16 11:49:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblCategories](
	[CategoryID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NULL,
	[Levels] [int] NULL,
	[Status] [bit] NULL,
	[CreateDate] [date] NULL,
	[TypeID] [int] NULL,
 CONSTRAINT [PK_tblDanhMuc] PRIMARY KEY CLUSTERED 
(
	[CategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblCategoryProducts]    Script Date: 16/6/16 11:49:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblCategoryProducts](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ProductID] [int] NULL,
	[CategoryID] [int] NULL,
 CONSTRAINT [PK_tblCategoryProducts] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblContact]    Script Date: 16/6/16 11:49:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblContact](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [ntext] NULL,
	[Email] [varchar](50) NULL,
	[Title] [nvarchar](200) NULL,
	[Content] [ntext] NULL,
	[DateSent] [date] NULL,
	[Status] [bit] NULL,
 CONSTRAINT [PK_tblContact] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblCustomer]    Script Date: 16/6/16 11:49:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblCustomer](
	[CustomerID] [int] IDENTITY(1,1) NOT NULL,
	[NameCus] [nvarchar](50) NULL,
	[Phone] [varchar](50) NULL,
	[Email] [varchar](100) NULL,
	[Adress] [ntext] NULL,
	[Sex] [nchar](10) NULL,
	[Birthday] [date] NULL,
	[CreateDate] [date] NULL,
	[Status] [bit] NULL,
	[Account] [nchar](40) NULL,
	[Password] [ntext] NULL,
 CONSTRAINT [PK_tblCustomer] PRIMARY KEY CLUSTERED 
(
	[CustomerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblManufactures]    Script Date: 16/6/16 11:49:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblManufactures](
	[ManufacturesID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Adress] [nvarchar](50) NULL,
	[Phone] [varchar](50) NULL,
 CONSTRAINT [PK_tblManufactures] PRIMARY KEY CLUSTERED 
(
	[ManufacturesID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblOrderDetail]    Script Date: 16/6/16 11:49:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblOrderDetail](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[OrderID] [int] NULL,
	[ProductID] [int] NULL,
	[Quantity] [int] NULL,
	[Price] [decimal](18, 0) NULL,
 CONSTRAINT [PK_tblOrderDetail] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblOrders]    Script Date: 16/6/16 11:49:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblOrders](
	[OrderID] [int] IDENTITY(1,1) NOT NULL,
	[CustomerID] [int] NULL,
	[DateSet] [date] NULL,
	[DeliveryDate] [date] NULL,
	[Status] [bit] NULL,
 CONSTRAINT [PK_tblOrders] PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblProduct_Images]    Script Date: 16/6/16 11:49:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblProduct_Images](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ProductID] [int] NULL,
	[Images] [varchar](100) NULL,
	[Images_Thum] [varchar](100) NULL,
 CONSTRAINT [PK_tblProduct_Images] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblProducts]    Script Date: 16/6/16 11:49:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblProducts](
	[ProductID] [int] IDENTITY(1,1) NOT NULL,
	[MetaTitle] [ntext] NULL,
	[NameProduct] [ntext] NULL,
	[Price] [decimal](18, 0) NULL,
	[PriceNews] [decimal](18, 0) NULL,
	[ManufacturesID] [int] NULL,
	[ImagesMain] [nvarchar](100) NULL,
	[DienAp] [nchar](10) NULL,
	[LedChip] [nvarchar](50) NULL,
	[Quantity] [int] NULL,
	[TuoiTho] [nvarchar](50) NULL,
	[QuangThong] [nchar](10) NULL,
	[HeSoCRI] [nchar](10) NULL,
	[NhietDoMau] [nchar](10) NULL,
	[GocMo] [nchar](10) NULL,
	[DoKin] [nchar](10) NULL,
	[NhietDoLamViec] [ntext] NULL,
	[HeSoCongSuat] [nchar](10) NULL,
	[VatLieu] [nchar](10) NULL,
	[Content] [ntext] NULL,
	[Warranty] [int] NULL,
	[UserID] [int] NULL,
	[CreateDate] [date] NULL,
	[Status] [bit] NULL,
 CONSTRAINT [PK_tblProducts] PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblRoles]    Script Date: 16/6/16 11:49:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblRoles](
	[RoleID] [int] IDENTITY(1,1) NOT NULL,
	[NameRole] [nvarchar](50) NULL,
 CONSTRAINT [PK_tblRoles] PRIMARY KEY CLUSTERED 
(
	[RoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblUsers]    Script Date: 16/6/16 11:49:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblUsers](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Account] [varchar](50) NULL,
	[Password] [varchar](50) NULL,
	[Status] [bit] NULL,
 CONSTRAINT [PK_tblUsers] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[tblCategories] ON 

INSERT [dbo].[tblCategories] ([CategoryID], [Name], [Levels], [Status], [CreateDate], [TypeID]) VALUES (1, N'Đèn Led Downlight', 1, 1, CAST(0x213B0B00 AS Date), NULL)
INSERT [dbo].[tblCategories] ([CategoryID], [Name], [Levels], [Status], [CreateDate], [TypeID]) VALUES (2, N'Đèn Led Xưởng', 2, 1, CAST(0x213B0B00 AS Date), NULL)
INSERT [dbo].[tblCategories] ([CategoryID], [Name], [Levels], [Status], [CreateDate], [TypeID]) VALUES (3, N'Đèn Led Pha', 3, 0, CAST(0x213B0B00 AS Date), NULL)
INSERT [dbo].[tblCategories] ([CategoryID], [Name], [Levels], [Status], [CreateDate], [TypeID]) VALUES (4, N'Đèn Led ngoài nhà', 4, 1, CAST(0x223B0B00 AS Date), 0)
INSERT [dbo].[tblCategories] ([CategoryID], [Name], [Levels], [Status], [CreateDate], [TypeID]) VALUES (5, N'Đèn Đèn Led', 5, 1, CAST(0x433B0B00 AS Date), NULL)
INSERT [dbo].[tblCategories] ([CategoryID], [Name], [Levels], [Status], [CreateDate], [TypeID]) VALUES (6, N'Đèn Led ốp trần', 6, 1, CAST(0x433B0B00 AS Date), NULL)
INSERT [dbo].[tblCategories] ([CategoryID], [Name], [Levels], [Status], [CreateDate], [TypeID]) VALUES (7, N'Đèn trang trí', 7, 1, CAST(0x433B0B00 AS Date), NULL)
INSERT [dbo].[tblCategories] ([CategoryID], [Name], [Levels], [Status], [CreateDate], [TypeID]) VALUES (9, N'Phụ kiện đèn led', 9, 1, CAST(0x433B0B00 AS Date), NULL)
INSERT [dbo].[tblCategories] ([CategoryID], [Name], [Levels], [Status], [CreateDate], [TypeID]) VALUES (10, N'Sản phẩm mới', 10, 1, CAST(0x433B0B00 AS Date), NULL)
INSERT [dbo].[tblCategories] ([CategoryID], [Name], [Levels], [Status], [CreateDate], [TypeID]) VALUES (11, N'Sản phẩm bán chạy', 11, 1, CAST(0x433B0B00 AS Date), NULL)
INSERT [dbo].[tblCategories] ([CategoryID], [Name], [Levels], [Status], [CreateDate], [TypeID]) VALUES (12, N'Touve', 12, 0, CAST(0x433B0B00 AS Date), NULL)
INSERT [dbo].[tblCategories] ([CategoryID], [Name], [Levels], [Status], [CreateDate], [TypeID]) VALUES (13, N'Bestlight-Epistar', 13, 1, CAST(0x433B0B00 AS Date), NULL)
INSERT [dbo].[tblCategories] ([CategoryID], [Name], [Levels], [Status], [CreateDate], [TypeID]) VALUES (14, N'Bestlight-Samsung', 14, 1, CAST(0x433B0B00 AS Date), NULL)
INSERT [dbo].[tblCategories] ([CategoryID], [Name], [Levels], [Status], [CreateDate], [TypeID]) VALUES (15, N'Bóng đèn Led', 15, 1, CAST(0x433B0B00 AS Date), NULL)
INSERT [dbo].[tblCategories] ([CategoryID], [Name], [Levels], [Status], [CreateDate], [TypeID]) VALUES (16, N'Led bóng quả nhót', 16, 1, CAST(0x433B0B00 AS Date), NULL)
SET IDENTITY_INSERT [dbo].[tblCategories] OFF
SET IDENTITY_INSERT [dbo].[tblCategoryProducts] ON 

INSERT [dbo].[tblCategoryProducts] ([ID], [ProductID], [CategoryID]) VALUES (1, 1, 12)
INSERT [dbo].[tblCategoryProducts] ([ID], [ProductID], [CategoryID]) VALUES (2, 2, 12)
INSERT [dbo].[tblCategoryProducts] ([ID], [ProductID], [CategoryID]) VALUES (3, 3, 12)
INSERT [dbo].[tblCategoryProducts] ([ID], [ProductID], [CategoryID]) VALUES (4, 4, 12)
INSERT [dbo].[tblCategoryProducts] ([ID], [ProductID], [CategoryID]) VALUES (5, 5, 12)
INSERT [dbo].[tblCategoryProducts] ([ID], [ProductID], [CategoryID]) VALUES (6, 6, 13)
INSERT [dbo].[tblCategoryProducts] ([ID], [ProductID], [CategoryID]) VALUES (7, 7, 13)
INSERT [dbo].[tblCategoryProducts] ([ID], [ProductID], [CategoryID]) VALUES (8, 8, 13)
INSERT [dbo].[tblCategoryProducts] ([ID], [ProductID], [CategoryID]) VALUES (9, 9, 13)
INSERT [dbo].[tblCategoryProducts] ([ID], [ProductID], [CategoryID]) VALUES (10, 10, 13)
INSERT [dbo].[tblCategoryProducts] ([ID], [ProductID], [CategoryID]) VALUES (11, 11, 13)
INSERT [dbo].[tblCategoryProducts] ([ID], [ProductID], [CategoryID]) VALUES (12, 12, 14)
INSERT [dbo].[tblCategoryProducts] ([ID], [ProductID], [CategoryID]) VALUES (13, 13, 14)
INSERT [dbo].[tblCategoryProducts] ([ID], [ProductID], [CategoryID]) VALUES (14, 14, 14)
INSERT [dbo].[tblCategoryProducts] ([ID], [ProductID], [CategoryID]) VALUES (15, 15, 14)
INSERT [dbo].[tblCategoryProducts] ([ID], [ProductID], [CategoryID]) VALUES (16, 16, 14)
INSERT [dbo].[tblCategoryProducts] ([ID], [ProductID], [CategoryID]) VALUES (17, 17, 2)
INSERT [dbo].[tblCategoryProducts] ([ID], [ProductID], [CategoryID]) VALUES (18, 18, 2)
INSERT [dbo].[tblCategoryProducts] ([ID], [ProductID], [CategoryID]) VALUES (19, 19, 2)
INSERT [dbo].[tblCategoryProducts] ([ID], [ProductID], [CategoryID]) VALUES (20, 20, 2)
INSERT [dbo].[tblCategoryProducts] ([ID], [ProductID], [CategoryID]) VALUES (21, 21, 2)
INSERT [dbo].[tblCategoryProducts] ([ID], [ProductID], [CategoryID]) VALUES (22, 22, 2)
INSERT [dbo].[tblCategoryProducts] ([ID], [ProductID], [CategoryID]) VALUES (23, 23, 2)
INSERT [dbo].[tblCategoryProducts] ([ID], [ProductID], [CategoryID]) VALUES (24, 24, 2)
INSERT [dbo].[tblCategoryProducts] ([ID], [ProductID], [CategoryID]) VALUES (25, 25, 15)
INSERT [dbo].[tblCategoryProducts] ([ID], [ProductID], [CategoryID]) VALUES (26, 26, 15)
INSERT [dbo].[tblCategoryProducts] ([ID], [ProductID], [CategoryID]) VALUES (27, 27, 15)
INSERT [dbo].[tblCategoryProducts] ([ID], [ProductID], [CategoryID]) VALUES (28, 28, 15)
INSERT [dbo].[tblCategoryProducts] ([ID], [ProductID], [CategoryID]) VALUES (29, 29, 15)
INSERT [dbo].[tblCategoryProducts] ([ID], [ProductID], [CategoryID]) VALUES (30, 30, 15)
INSERT [dbo].[tblCategoryProducts] ([ID], [ProductID], [CategoryID]) VALUES (31, 31, 15)
INSERT [dbo].[tblCategoryProducts] ([ID], [ProductID], [CategoryID]) VALUES (32, 32, 15)
INSERT [dbo].[tblCategoryProducts] ([ID], [ProductID], [CategoryID]) VALUES (33, 33, 16)
INSERT [dbo].[tblCategoryProducts] ([ID], [ProductID], [CategoryID]) VALUES (34, 34, 16)
INSERT [dbo].[tblCategoryProducts] ([ID], [ProductID], [CategoryID]) VALUES (35, 35, 16)
INSERT [dbo].[tblCategoryProducts] ([ID], [ProductID], [CategoryID]) VALUES (36, 36, 16)
INSERT [dbo].[tblCategoryProducts] ([ID], [ProductID], [CategoryID]) VALUES (37, 43, 15)
INSERT [dbo].[tblCategoryProducts] ([ID], [ProductID], [CategoryID]) VALUES (38, 37, 15)
INSERT [dbo].[tblCategoryProducts] ([ID], [ProductID], [CategoryID]) VALUES (39, 38, 15)
INSERT [dbo].[tblCategoryProducts] ([ID], [ProductID], [CategoryID]) VALUES (40, 39, 15)
INSERT [dbo].[tblCategoryProducts] ([ID], [ProductID], [CategoryID]) VALUES (41, 40, 15)
INSERT [dbo].[tblCategoryProducts] ([ID], [ProductID], [CategoryID]) VALUES (42, 42, 15)
INSERT [dbo].[tblCategoryProducts] ([ID], [ProductID], [CategoryID]) VALUES (43, 44, 1)
INSERT [dbo].[tblCategoryProducts] ([ID], [ProductID], [CategoryID]) VALUES (44, 45, 1)
INSERT [dbo].[tblCategoryProducts] ([ID], [ProductID], [CategoryID]) VALUES (45, 46, 1)
INSERT [dbo].[tblCategoryProducts] ([ID], [ProductID], [CategoryID]) VALUES (46, 47, 1)
INSERT [dbo].[tblCategoryProducts] ([ID], [ProductID], [CategoryID]) VALUES (47, 50, 1)
INSERT [dbo].[tblCategoryProducts] ([ID], [ProductID], [CategoryID]) VALUES (48, 51, 1)
INSERT [dbo].[tblCategoryProducts] ([ID], [ProductID], [CategoryID]) VALUES (49, 52, 1)
INSERT [dbo].[tblCategoryProducts] ([ID], [ProductID], [CategoryID]) VALUES (50, 53, 1)
INSERT [dbo].[tblCategoryProducts] ([ID], [ProductID], [CategoryID]) VALUES (51, 54, 1)
SET IDENTITY_INSERT [dbo].[tblCategoryProducts] OFF
SET IDENTITY_INSERT [dbo].[tblContact] ON 

INSERT [dbo].[tblContact] ([ID], [Name], [Email], [Title], [Content], [DateSent], [Status]) VALUES (3, N'1', N'2', N'3', N'4', CAST(0x4C3B0B00 AS Date), 0)
INSERT [dbo].[tblContact] ([ID], [Name], [Email], [Title], [Content], [DateSent], [Status]) VALUES (4, N'ngô trọng', N'trogngo1507@gmail.com', N'test', N'abc', CAST(0x4C3B0B00 AS Date), 0)
INSERT [dbo].[tblContact] ([ID], [Name], [Email], [Title], [Content], [DateSent], [Status]) VALUES (5, N'12', NULL, NULL, NULL, CAST(0x4C3B0B00 AS Date), 0)
INSERT [dbo].[tblContact] ([ID], [Name], [Email], [Title], [Content], [DateSent], [Status]) VALUES (6, N'12', NULL, N'3', N'4', CAST(0x4C3B0B00 AS Date), 0)
INSERT [dbo].[tblContact] ([ID], [Name], [Email], [Title], [Content], [DateSent], [Status]) VALUES (7, N'12', NULL, N'3', N'4', CAST(0x4C3B0B00 AS Date), 0)
INSERT [dbo].[tblContact] ([ID], [Name], [Email], [Title], [Content], [DateSent], [Status]) VALUES (8, N'12', NULL, N'3', N'4', CAST(0x4C3B0B00 AS Date), 0)
INSERT [dbo].[tblContact] ([ID], [Name], [Email], [Title], [Content], [DateSent], [Status]) VALUES (9, N'12', NULL, N'3', N'4', CAST(0x4C3B0B00 AS Date), 0)
INSERT [dbo].[tblContact] ([ID], [Name], [Email], [Title], [Content], [DateSent], [Status]) VALUES (10, N'12', NULL, N'3', N'4', CAST(0x4C3B0B00 AS Date), 0)
INSERT [dbo].[tblContact] ([ID], [Name], [Email], [Title], [Content], [DateSent], [Status]) VALUES (11, N'12', NULL, N'3', N'4', CAST(0x4C3B0B00 AS Date), 0)
INSERT [dbo].[tblContact] ([ID], [Name], [Email], [Title], [Content], [DateSent], [Status]) VALUES (12, N'trang', N'2', N'3', N'4', CAST(0x4C3B0B00 AS Date), 0)
INSERT [dbo].[tblContact] ([ID], [Name], [Email], [Title], [Content], [DateSent], [Status]) VALUES (13, N'trangtrong', N'1', N'1', N'1', CAST(0x4C3B0B00 AS Date), 0)
INSERT [dbo].[tblContact] ([ID], [Name], [Email], [Title], [Content], [DateSent], [Status]) VALUES (14, N'trangtrong', N'1', N'1', N'1', CAST(0x4C3B0B00 AS Date), 0)
INSERT [dbo].[tblContact] ([ID], [Name], [Email], [Title], [Content], [DateSent], [Status]) VALUES (15, N'tr', N'trogngo1507@gmail.com', N'1', N'1', CAST(0x4C3B0B00 AS Date), 0)
INSERT [dbo].[tblContact] ([ID], [Name], [Email], [Title], [Content], [DateSent], [Status]) VALUES (16, N'a', N'a', N'a', N'a', CAST(0x4C3B0B00 AS Date), 0)
INSERT [dbo].[tblContact] ([ID], [Name], [Email], [Title], [Content], [DateSent], [Status]) VALUES (17, N'4444', N'444', N'444', N'444', CAST(0x4C3B0B00 AS Date), 0)
INSERT [dbo].[tblContact] ([ID], [Name], [Email], [Title], [Content], [DateSent], [Status]) VALUES (18, N'123', N'123', N'12', N'12', CAST(0x823B0B00 AS Date), 0)
SET IDENTITY_INSERT [dbo].[tblContact] OFF
SET IDENTITY_INSERT [dbo].[tblCustomer] ON 

INSERT [dbo].[tblCustomer] ([CustomerID], [NameCus], [Phone], [Email], [Adress], [Sex], [Birthday], [CreateDate], [Status], [Account], [Password]) VALUES (1, N'Trong', N'1', N'1', N'1', N'Nam       ', CAST(0x6E3B0B00 AS Date), CAST(0x6E3B0B00 AS Date), 1, N'trong                                   ', N'21232f297a57a5a743894a0e4a801fc3')
INSERT [dbo].[tblCustomer] ([CustomerID], [NameCus], [Phone], [Email], [Adress], [Sex], [Birthday], [CreateDate], [Status], [Account], [Password]) VALUES (2, N'Trang', N'1', N'@abc', N'1', N'Nu        ', CAST(0x6E3B0B00 AS Date), CAST(0x6E3B0B00 AS Date), 1, N'b                                       ', N'21232f297a57a5a743894a0e4a801fc3')
INSERT [dbo].[tblCustomer] ([CustomerID], [NameCus], [Phone], [Email], [Adress], [Sex], [Birthday], [CreateDate], [Status], [Account], [Password]) VALUES (3, NULL, N'123123123', N'avc@ag', N'112', NULL, NULL, NULL, NULL, N'trangtrong                              ', N'96e79218965eb72c92a549dd5a330112        ')
SET IDENTITY_INSERT [dbo].[tblCustomer] OFF
SET IDENTITY_INSERT [dbo].[tblManufactures] ON 

INSERT [dbo].[tblManufactures] ([ManufacturesID], [Name], [Adress], [Phone]) VALUES (1, N'SamSung', N'A', N'A')
INSERT [dbo].[tblManufactures] ([ManufacturesID], [Name], [Adress], [Phone]) VALUES (2, N'Apple', N'B', N'B')
INSERT [dbo].[tblManufactures] ([ManufacturesID], [Name], [Adress], [Phone]) VALUES (3, N'Lenovo', N'C', N'C')
SET IDENTITY_INSERT [dbo].[tblManufactures] OFF
SET IDENTITY_INSERT [dbo].[tblOrderDetail] ON 

INSERT [dbo].[tblOrderDetail] ([ID], [OrderID], [ProductID], [Quantity], [Price]) VALUES (0, 5, 45, 1, CAST(12124 AS Decimal(18, 0)))
INSERT [dbo].[tblOrderDetail] ([ID], [OrderID], [ProductID], [Quantity], [Price]) VALUES (1, 5, 45, 1, CAST(12 AS Decimal(18, 0)))
INSERT [dbo].[tblOrderDetail] ([ID], [OrderID], [ProductID], [Quantity], [Price]) VALUES (2, 5, 45, 1, CAST(12 AS Decimal(18, 0)))
INSERT [dbo].[tblOrderDetail] ([ID], [OrderID], [ProductID], [Quantity], [Price]) VALUES (3, 14, 10, 7, CAST(50000 AS Decimal(18, 0)))
INSERT [dbo].[tblOrderDetail] ([ID], [OrderID], [ProductID], [Quantity], [Price]) VALUES (4, 15, 5, 5, CAST(30000 AS Decimal(18, 0)))
INSERT [dbo].[tblOrderDetail] ([ID], [OrderID], [ProductID], [Quantity], [Price]) VALUES (5, 16, 10, 7, CAST(50000 AS Decimal(18, 0)))
INSERT [dbo].[tblOrderDetail] ([ID], [OrderID], [ProductID], [Quantity], [Price]) VALUES (6, 16, 5, 5, CAST(30000 AS Decimal(18, 0)))
INSERT [dbo].[tblOrderDetail] ([ID], [OrderID], [ProductID], [Quantity], [Price]) VALUES (1002, 1016, 45, 1, CAST(30000 AS Decimal(18, 0)))
INSERT [dbo].[tblOrderDetail] ([ID], [OrderID], [ProductID], [Quantity], [Price]) VALUES (1003, 1017, 46, 1, CAST(4 AS Decimal(18, 0)))
INSERT [dbo].[tblOrderDetail] ([ID], [OrderID], [ProductID], [Quantity], [Price]) VALUES (1004, 1017, 45, 1, CAST(30000 AS Decimal(18, 0)))
INSERT [dbo].[tblOrderDetail] ([ID], [OrderID], [ProductID], [Quantity], [Price]) VALUES (1005, 1018, 46, 1, CAST(4 AS Decimal(18, 0)))
INSERT [dbo].[tblOrderDetail] ([ID], [OrderID], [ProductID], [Quantity], [Price]) VALUES (1006, 1018, 45, 1, CAST(30000 AS Decimal(18, 0)))
INSERT [dbo].[tblOrderDetail] ([ID], [OrderID], [ProductID], [Quantity], [Price]) VALUES (1007, 1021, 9, 1, CAST(50000 AS Decimal(18, 0)))
INSERT [dbo].[tblOrderDetail] ([ID], [OrderID], [ProductID], [Quantity], [Price]) VALUES (1008, 1022, 9, 1, CAST(50000 AS Decimal(18, 0)))
INSERT [dbo].[tblOrderDetail] ([ID], [OrderID], [ProductID], [Quantity], [Price]) VALUES (1009, 1023, 9, 1, CAST(50000 AS Decimal(18, 0)))
INSERT [dbo].[tblOrderDetail] ([ID], [OrderID], [ProductID], [Quantity], [Price]) VALUES (1010, 1024, 9, 1, CAST(50000 AS Decimal(18, 0)))
INSERT [dbo].[tblOrderDetail] ([ID], [OrderID], [ProductID], [Quantity], [Price]) VALUES (1011, 1025, 9, 1, CAST(50000 AS Decimal(18, 0)))
INSERT [dbo].[tblOrderDetail] ([ID], [OrderID], [ProductID], [Quantity], [Price]) VALUES (1012, 1025, 46, 1, CAST(4 AS Decimal(18, 0)))
SET IDENTITY_INSERT [dbo].[tblOrderDetail] OFF
SET IDENTITY_INSERT [dbo].[tblOrders] ON 

INSERT [dbo].[tblOrders] ([OrderID], [CustomerID], [DateSet], [DeliveryDate], [Status]) VALUES (4, 1, CAST(0x6E3B0B00 AS Date), CAST(0x6E3B0B00 AS Date), 1)
INSERT [dbo].[tblOrders] ([OrderID], [CustomerID], [DateSet], [DeliveryDate], [Status]) VALUES (5, 1, CAST(0x6F3B0B00 AS Date), CAST(0x6F3B0B00 AS Date), 1)
INSERT [dbo].[tblOrders] ([OrderID], [CustomerID], [DateSet], [DeliveryDate], [Status]) VALUES (6, 1, CAST(0x6F3B0B00 AS Date), CAST(0x6F3B0B00 AS Date), 1)
INSERT [dbo].[tblOrders] ([OrderID], [CustomerID], [DateSet], [DeliveryDate], [Status]) VALUES (8, 1, CAST(0x6F3B0B00 AS Date), CAST(0x6F3B0B00 AS Date), 1)
INSERT [dbo].[tblOrders] ([OrderID], [CustomerID], [DateSet], [DeliveryDate], [Status]) VALUES (9, 1, CAST(0x6F3B0B00 AS Date), CAST(0x6F3B0B00 AS Date), 1)
INSERT [dbo].[tblOrders] ([OrderID], [CustomerID], [DateSet], [DeliveryDate], [Status]) VALUES (10, 1, CAST(0x6F3B0B00 AS Date), CAST(0x6F3B0B00 AS Date), 1)
INSERT [dbo].[tblOrders] ([OrderID], [CustomerID], [DateSet], [DeliveryDate], [Status]) VALUES (14, 1, CAST(0x6F3B0B00 AS Date), CAST(0x6F3B0B00 AS Date), 1)
INSERT [dbo].[tblOrders] ([OrderID], [CustomerID], [DateSet], [DeliveryDate], [Status]) VALUES (15, 1, CAST(0x6F3B0B00 AS Date), CAST(0x6F3B0B00 AS Date), 1)
INSERT [dbo].[tblOrders] ([OrderID], [CustomerID], [DateSet], [DeliveryDate], [Status]) VALUES (16, 1, CAST(0x6F3B0B00 AS Date), CAST(0x6F3B0B00 AS Date), 1)
INSERT [dbo].[tblOrders] ([OrderID], [CustomerID], [DateSet], [DeliveryDate], [Status]) VALUES (1016, 1, CAST(0x823B0B00 AS Date), CAST(0x823B0B00 AS Date), 1)
INSERT [dbo].[tblOrders] ([OrderID], [CustomerID], [DateSet], [DeliveryDate], [Status]) VALUES (1017, 1, CAST(0x823B0B00 AS Date), CAST(0x823B0B00 AS Date), 1)
INSERT [dbo].[tblOrders] ([OrderID], [CustomerID], [DateSet], [DeliveryDate], [Status]) VALUES (1018, 1, CAST(0x823B0B00 AS Date), CAST(0x823B0B00 AS Date), 1)
INSERT [dbo].[tblOrders] ([OrderID], [CustomerID], [DateSet], [DeliveryDate], [Status]) VALUES (1021, 1, CAST(0x823B0B00 AS Date), CAST(0x823B0B00 AS Date), 1)
INSERT [dbo].[tblOrders] ([OrderID], [CustomerID], [DateSet], [DeliveryDate], [Status]) VALUES (1022, 1, CAST(0x823B0B00 AS Date), CAST(0x823B0B00 AS Date), 1)
INSERT [dbo].[tblOrders] ([OrderID], [CustomerID], [DateSet], [DeliveryDate], [Status]) VALUES (1023, 1, CAST(0x823B0B00 AS Date), CAST(0x823B0B00 AS Date), 1)
INSERT [dbo].[tblOrders] ([OrderID], [CustomerID], [DateSet], [DeliveryDate], [Status]) VALUES (1024, 1, CAST(0x823B0B00 AS Date), CAST(0x823B0B00 AS Date), 1)
INSERT [dbo].[tblOrders] ([OrderID], [CustomerID], [DateSet], [DeliveryDate], [Status]) VALUES (1025, 1, CAST(0x823B0B00 AS Date), CAST(0x823B0B00 AS Date), 1)
SET IDENTITY_INSERT [dbo].[tblOrders] OFF
SET IDENTITY_INSERT [dbo].[tblProducts] ON 

INSERT [dbo].[tblProducts] ([ProductID], [MetaTitle], [NameProduct], [Price], [PriceNews], [ManufacturesID], [ImagesMain], [DienAp], [LedChip], [Quantity], [TuoiTho], [QuangThong], [HeSoCRI], [NhietDoMau], [GocMo], [DoKin], [NhietDoLamViec], [HeSoCongSuat], [VatLieu], [Content], [Warranty], [UserID], [CreateDate], [Status]) VALUES (3, N'', N'Touve 300', CAST(12124 AS Decimal(18, 0)), CAST(30000 AS Decimal(18, 0)), 3, N'2015_12_28_12_19_18_21_smallSize.jpg', N'640-80 VAC', N'SMD 285 Taiwan', 100, N'40.000-50.000 giờ', N'>9000 LM  ', N'>80       ', N'3000 -6500', N'          ', N'IP54      ', N'-20 den 45', N'>=0.9     ', N'Nhôm      ', N'', 12, 1, CAST(0x73350B00 AS Date), 0)
INSERT [dbo].[tblProducts] ([ProductID], [MetaTitle], [NameProduct], [Price], [PriceNews], [ManufacturesID], [ImagesMain], [DienAp], [LedChip], [Quantity], [TuoiTho], [QuangThong], [HeSoCRI], [NhietDoMau], [GocMo], [DoKin], [NhietDoLamViec], [HeSoCongSuat], [VatLieu], [Content], [Warranty], [UserID], [CreateDate], [Status]) VALUES (4, NULL, N'Touve 4', CAST(0 AS Decimal(18, 0)), CAST(40000 AS Decimal(18, 0)), 1, N'2016_01_05_17_14_00_68_smallSize.jpg', NULL, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, CAST(0xBA390B00 AS Date), 1)
INSERT [dbo].[tblProducts] ([ProductID], [MetaTitle], [NameProduct], [Price], [PriceNews], [ManufacturesID], [ImagesMain], [DienAp], [LedChip], [Quantity], [TuoiTho], [QuangThong], [HeSoCRI], [NhietDoMau], [GocMo], [DoKin], [NhietDoLamViec], [HeSoCongSuat], [VatLieu], [Content], [Warranty], [UserID], [CreateDate], [Status]) VALUES (5, NULL, N'Touve 5', CAST(0 AS Decimal(18, 0)), CAST(30000 AS Decimal(18, 0)), 1, N'2016_01_05_16_59_26_54_smallSize.jpg', NULL, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, CAST(0x283B0B00 AS Date), 1)
INSERT [dbo].[tblProducts] ([ProductID], [MetaTitle], [NameProduct], [Price], [PriceNews], [ManufacturesID], [ImagesMain], [DienAp], [LedChip], [Quantity], [TuoiTho], [QuangThong], [HeSoCRI], [NhietDoMau], [GocMo], [DoKin], [NhietDoLamViec], [HeSoCongSuat], [VatLieu], [Content], [Warranty], [UserID], [CreateDate], [Status]) VALUES (6, NULL, N'Bestlight-Epistar 1', CAST(0 AS Decimal(18, 0)), CAST(40000 AS Decimal(18, 0)), 1, N'2015_12_28_12_19_18_21_smallSize.jpg', NULL, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, CAST(0xBA390B00 AS Date), 1)
INSERT [dbo].[tblProducts] ([ProductID], [MetaTitle], [NameProduct], [Price], [PriceNews], [ManufacturesID], [ImagesMain], [DienAp], [LedChip], [Quantity], [TuoiTho], [QuangThong], [HeSoCRI], [NhietDoMau], [GocMo], [DoKin], [NhietDoLamViec], [HeSoCongSuat], [VatLieu], [Content], [Warranty], [UserID], [CreateDate], [Status]) VALUES (7, NULL, N'Bestlight-Epistar 2', CAST(0 AS Decimal(18, 0)), CAST(50000 AS Decimal(18, 0)), 1, N'2016_01_05_17_14_00_68_smallSize.jpg', NULL, NULL, 1, NULL, N'>80       ', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, CAST(0x283B0B00 AS Date), 1)
INSERT [dbo].[tblProducts] ([ProductID], [MetaTitle], [NameProduct], [Price], [PriceNews], [ManufacturesID], [ImagesMain], [DienAp], [LedChip], [Quantity], [TuoiTho], [QuangThong], [HeSoCRI], [NhietDoMau], [GocMo], [DoKin], [NhietDoLamViec], [HeSoCongSuat], [VatLieu], [Content], [Warranty], [UserID], [CreateDate], [Status]) VALUES (9, NULL, N'Bestlight-Epistar 3', CAST(0 AS Decimal(18, 0)), CAST(50000 AS Decimal(18, 0)), 1, N'2015_12_28_12_19_18_21_smallSize.jpg', NULL, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, CAST(0x05340B00 AS Date), 1)
INSERT [dbo].[tblProducts] ([ProductID], [MetaTitle], [NameProduct], [Price], [PriceNews], [ManufacturesID], [ImagesMain], [DienAp], [LedChip], [Quantity], [TuoiTho], [QuangThong], [HeSoCRI], [NhietDoMau], [GocMo], [DoKin], [NhietDoLamViec], [HeSoCongSuat], [VatLieu], [Content], [Warranty], [UserID], [CreateDate], [Status]) VALUES (10, NULL, N'Bestlight-Epistar 4', CAST(0 AS Decimal(18, 0)), CAST(50000 AS Decimal(18, 0)), 1, N'2016_01_05_17_14_00_68_smallSize.jpg', NULL, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, CAST(0x283B0B00 AS Date), 1)
INSERT [dbo].[tblProducts] ([ProductID], [MetaTitle], [NameProduct], [Price], [PriceNews], [ManufacturesID], [ImagesMain], [DienAp], [LedChip], [Quantity], [TuoiTho], [QuangThong], [HeSoCRI], [NhietDoMau], [GocMo], [DoKin], [NhietDoLamViec], [HeSoCongSuat], [VatLieu], [Content], [Warranty], [UserID], [CreateDate], [Status]) VALUES (11, NULL, N'Bestlight-Epistar 5', CAST(0 AS Decimal(18, 0)), CAST(40000 AS Decimal(18, 0)), 1, N'2016_01_05_16_59_26_54_smallSize.jpg', NULL, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, CAST(0x283B0B00 AS Date), 1)
INSERT [dbo].[tblProducts] ([ProductID], [MetaTitle], [NameProduct], [Price], [PriceNews], [ManufacturesID], [ImagesMain], [DienAp], [LedChip], [Quantity], [TuoiTho], [QuangThong], [HeSoCRI], [NhietDoMau], [GocMo], [DoKin], [NhietDoLamViec], [HeSoCongSuat], [VatLieu], [Content], [Warranty], [UserID], [CreateDate], [Status]) VALUES (13, NULL, N'Bestlight-Samsung 2', CAST(0 AS Decimal(18, 0)), CAST(50000 AS Decimal(18, 0)), 1, N'2015_12_28_12_19_18_21_smallSize.jpg', NULL, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, CAST(0x283B0B00 AS Date), 1)
INSERT [dbo].[tblProducts] ([ProductID], [MetaTitle], [NameProduct], [Price], [PriceNews], [ManufacturesID], [ImagesMain], [DienAp], [LedChip], [Quantity], [TuoiTho], [QuangThong], [HeSoCRI], [NhietDoMau], [GocMo], [DoKin], [NhietDoLamViec], [HeSoCongSuat], [VatLieu], [Content], [Warranty], [UserID], [CreateDate], [Status]) VALUES (14, NULL, N'Bestlight-Samsung 3', CAST(0 AS Decimal(18, 0)), CAST(50000 AS Decimal(18, 0)), 1, N'2015_12_28_12_19_18_21_smallSize.jpg', NULL, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, CAST(0x283B0B00 AS Date), 1)
INSERT [dbo].[tblProducts] ([ProductID], [MetaTitle], [NameProduct], [Price], [PriceNews], [ManufacturesID], [ImagesMain], [DienAp], [LedChip], [Quantity], [TuoiTho], [QuangThong], [HeSoCRI], [NhietDoMau], [GocMo], [DoKin], [NhietDoLamViec], [HeSoCongSuat], [VatLieu], [Content], [Warranty], [UserID], [CreateDate], [Status]) VALUES (15, NULL, N'Bestlight-Samsung 4', CAST(0 AS Decimal(18, 0)), CAST(50000 AS Decimal(18, 0)), 1, N'2015_12_28_12_19_18_21_smallSize.jpg', NULL, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, CAST(0x283B0B00 AS Date), 1)
INSERT [dbo].[tblProducts] ([ProductID], [MetaTitle], [NameProduct], [Price], [PriceNews], [ManufacturesID], [ImagesMain], [DienAp], [LedChip], [Quantity], [TuoiTho], [QuangThong], [HeSoCRI], [NhietDoMau], [GocMo], [DoKin], [NhietDoLamViec], [HeSoCongSuat], [VatLieu], [Content], [Warranty], [UserID], [CreateDate], [Status]) VALUES (16, NULL, N'Bestlight-Samsung 5', CAST(0 AS Decimal(18, 0)), CAST(50000 AS Decimal(18, 0)), 1, N'2015_12_28_12_19_18_21_smallSize.jpg', NULL, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, CAST(0x283B0B00 AS Date), 1)
INSERT [dbo].[tblProducts] ([ProductID], [MetaTitle], [NameProduct], [Price], [PriceNews], [ManufacturesID], [ImagesMain], [DienAp], [LedChip], [Quantity], [TuoiTho], [QuangThong], [HeSoCRI], [NhietDoMau], [GocMo], [DoKin], [NhietDoLamViec], [HeSoCongSuat], [VatLieu], [Content], [Warranty], [UserID], [CreateDate], [Status]) VALUES (17, NULL, N'Đèn Led Xưởng 1', CAST(0 AS Decimal(18, 0)), CAST(50000 AS Decimal(18, 0)), 1, N'2015_12_28_12_19_18_21_smallSize.jpg', NULL, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, CAST(0x283B0B00 AS Date), 1)
INSERT [dbo].[tblProducts] ([ProductID], [MetaTitle], [NameProduct], [Price], [PriceNews], [ManufacturesID], [ImagesMain], [DienAp], [LedChip], [Quantity], [TuoiTho], [QuangThong], [HeSoCRI], [NhietDoMau], [GocMo], [DoKin], [NhietDoLamViec], [HeSoCongSuat], [VatLieu], [Content], [Warranty], [UserID], [CreateDate], [Status]) VALUES (18, NULL, N'Đèn Led Xưởng 2', CAST(0 AS Decimal(18, 0)), CAST(50000 AS Decimal(18, 0)), 1, N'2015_12_28_12_19_18_21_smallSize.jpg', NULL, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, CAST(0x283B0B00 AS Date), 1)
INSERT [dbo].[tblProducts] ([ProductID], [MetaTitle], [NameProduct], [Price], [PriceNews], [ManufacturesID], [ImagesMain], [DienAp], [LedChip], [Quantity], [TuoiTho], [QuangThong], [HeSoCRI], [NhietDoMau], [GocMo], [DoKin], [NhietDoLamViec], [HeSoCongSuat], [VatLieu], [Content], [Warranty], [UserID], [CreateDate], [Status]) VALUES (19, NULL, N'Đèn Led Xưởng 3', CAST(0 AS Decimal(18, 0)), CAST(50000 AS Decimal(18, 0)), 1, N'2015_12_28_12_19_18_21_smallSize.jpg', NULL, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, CAST(0x283B0B00 AS Date), 1)
INSERT [dbo].[tblProducts] ([ProductID], [MetaTitle], [NameProduct], [Price], [PriceNews], [ManufacturesID], [ImagesMain], [DienAp], [LedChip], [Quantity], [TuoiTho], [QuangThong], [HeSoCRI], [NhietDoMau], [GocMo], [DoKin], [NhietDoLamViec], [HeSoCongSuat], [VatLieu], [Content], [Warranty], [UserID], [CreateDate], [Status]) VALUES (20, NULL, N'Đèn Led Xưởng 4', CAST(0 AS Decimal(18, 0)), CAST(50000 AS Decimal(18, 0)), 1, N'2015_12_28_12_19_18_21_smallSize.jpg', NULL, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, CAST(0x283B0B00 AS Date), 1)
INSERT [dbo].[tblProducts] ([ProductID], [MetaTitle], [NameProduct], [Price], [PriceNews], [ManufacturesID], [ImagesMain], [DienAp], [LedChip], [Quantity], [TuoiTho], [QuangThong], [HeSoCRI], [NhietDoMau], [GocMo], [DoKin], [NhietDoLamViec], [HeSoCongSuat], [VatLieu], [Content], [Warranty], [UserID], [CreateDate], [Status]) VALUES (21, NULL, N'Đèn Led Xưởng 5', CAST(0 AS Decimal(18, 0)), CAST(50000 AS Decimal(18, 0)), 1, N'2015_12_28_12_19_18_21_smallSize.jpg', NULL, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, CAST(0x283B0B00 AS Date), 1)
INSERT [dbo].[tblProducts] ([ProductID], [MetaTitle], [NameProduct], [Price], [PriceNews], [ManufacturesID], [ImagesMain], [DienAp], [LedChip], [Quantity], [TuoiTho], [QuangThong], [HeSoCRI], [NhietDoMau], [GocMo], [DoKin], [NhietDoLamViec], [HeSoCongSuat], [VatLieu], [Content], [Warranty], [UserID], [CreateDate], [Status]) VALUES (22, NULL, N'Đèn Led Xưởng 6', CAST(0 AS Decimal(18, 0)), CAST(50000 AS Decimal(18, 0)), 1, N'2015_12_28_12_19_18_21_smallSize.jpg', NULL, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, CAST(0x283B0B00 AS Date), 1)
INSERT [dbo].[tblProducts] ([ProductID], [MetaTitle], [NameProduct], [Price], [PriceNews], [ManufacturesID], [ImagesMain], [DienAp], [LedChip], [Quantity], [TuoiTho], [QuangThong], [HeSoCRI], [NhietDoMau], [GocMo], [DoKin], [NhietDoLamViec], [HeSoCongSuat], [VatLieu], [Content], [Warranty], [UserID], [CreateDate], [Status]) VALUES (25, NULL, N'Bóng đèn Led', CAST(0 AS Decimal(18, 0)), CAST(50000 AS Decimal(18, 0)), 1, N'2016_01_05_17_14_00_68_smallSize.jpg', NULL, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, CAST(0x283B0B00 AS Date), 1)
INSERT [dbo].[tblProducts] ([ProductID], [MetaTitle], [NameProduct], [Price], [PriceNews], [ManufacturesID], [ImagesMain], [DienAp], [LedChip], [Quantity], [TuoiTho], [QuangThong], [HeSoCRI], [NhietDoMau], [GocMo], [DoKin], [NhietDoLamViec], [HeSoCongSuat], [VatLieu], [Content], [Warranty], [UserID], [CreateDate], [Status]) VALUES (26, NULL, N'Bóng đèn Led 1', CAST(0 AS Decimal(18, 0)), CAST(50000 AS Decimal(18, 0)), 1, N'2016_01_05_16_59_26_54_smallSize.jpg', NULL, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, CAST(0x283B0B00 AS Date), 1)
INSERT [dbo].[tblProducts] ([ProductID], [MetaTitle], [NameProduct], [Price], [PriceNews], [ManufacturesID], [ImagesMain], [DienAp], [LedChip], [Quantity], [TuoiTho], [QuangThong], [HeSoCRI], [NhietDoMau], [GocMo], [DoKin], [NhietDoLamViec], [HeSoCongSuat], [VatLieu], [Content], [Warranty], [UserID], [CreateDate], [Status]) VALUES (27, NULL, N'Bóng đèn Led 2', CAST(0 AS Decimal(18, 0)), CAST(50000 AS Decimal(18, 0)), 1, N'2015_12_28_12_19_18_21_smallSize.jpg', NULL, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, CAST(0x05340B00 AS Date), 1)
INSERT [dbo].[tblProducts] ([ProductID], [MetaTitle], [NameProduct], [Price], [PriceNews], [ManufacturesID], [ImagesMain], [DienAp], [LedChip], [Quantity], [TuoiTho], [QuangThong], [HeSoCRI], [NhietDoMau], [GocMo], [DoKin], [NhietDoLamViec], [HeSoCongSuat], [VatLieu], [Content], [Warranty], [UserID], [CreateDate], [Status]) VALUES (28, NULL, N'Bóng đèn Led 3', CAST(0 AS Decimal(18, 0)), CAST(50000 AS Decimal(18, 0)), 1, N'2016_01_05_17_14_00_68_smallSize.jpg', NULL, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, CAST(0x283B0B00 AS Date), 1)
INSERT [dbo].[tblProducts] ([ProductID], [MetaTitle], [NameProduct], [Price], [PriceNews], [ManufacturesID], [ImagesMain], [DienAp], [LedChip], [Quantity], [TuoiTho], [QuangThong], [HeSoCRI], [NhietDoMau], [GocMo], [DoKin], [NhietDoLamViec], [HeSoCongSuat], [VatLieu], [Content], [Warranty], [UserID], [CreateDate], [Status]) VALUES (29, NULL, N'Bóng đèn Led 4', CAST(0 AS Decimal(18, 0)), CAST(40000 AS Decimal(18, 0)), 1, N'2016_01_05_16_59_26_54_smallSize.jpg', NULL, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, CAST(0x283B0B00 AS Date), 1)
INSERT [dbo].[tblProducts] ([ProductID], [MetaTitle], [NameProduct], [Price], [PriceNews], [ManufacturesID], [ImagesMain], [DienAp], [LedChip], [Quantity], [TuoiTho], [QuangThong], [HeSoCRI], [NhietDoMau], [GocMo], [DoKin], [NhietDoLamViec], [HeSoCongSuat], [VatLieu], [Content], [Warranty], [UserID], [CreateDate], [Status]) VALUES (30, NULL, N'Bóng đèn Led 5', CAST(0 AS Decimal(18, 0)), CAST(50000 AS Decimal(18, 0)), 1, N'2015_12_28_12_19_18_21_smallSize.jpg', NULL, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, CAST(0x283B0B00 AS Date), 1)
INSERT [dbo].[tblProducts] ([ProductID], [MetaTitle], [NameProduct], [Price], [PriceNews], [ManufacturesID], [ImagesMain], [DienAp], [LedChip], [Quantity], [TuoiTho], [QuangThong], [HeSoCRI], [NhietDoMau], [GocMo], [DoKin], [NhietDoLamViec], [HeSoCongSuat], [VatLieu], [Content], [Warranty], [UserID], [CreateDate], [Status]) VALUES (31, NULL, N' Bóng đèn Led 6', CAST(0 AS Decimal(18, 0)), CAST(40000 AS Decimal(18, 0)), 1, N'2015_12_28_12_19_18_21_smallSize.jpg', NULL, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, CAST(0xBA390B00 AS Date), 1)
INSERT [dbo].[tblProducts] ([ProductID], [MetaTitle], [NameProduct], [Price], [PriceNews], [ManufacturesID], [ImagesMain], [DienAp], [LedChip], [Quantity], [TuoiTho], [QuangThong], [HeSoCRI], [NhietDoMau], [GocMo], [DoKin], [NhietDoLamViec], [HeSoCongSuat], [VatLieu], [Content], [Warranty], [UserID], [CreateDate], [Status]) VALUES (33, NULL, N'Led bóng quả nhót 1', CAST(0 AS Decimal(18, 0)), CAST(50000 AS Decimal(18, 0)), 1, N'2016_01_05_16_59_26_54_smallSize.jpg', NULL, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, CAST(0x283B0B00 AS Date), 1)
INSERT [dbo].[tblProducts] ([ProductID], [MetaTitle], [NameProduct], [Price], [PriceNews], [ManufacturesID], [ImagesMain], [DienAp], [LedChip], [Quantity], [TuoiTho], [QuangThong], [HeSoCRI], [NhietDoMau], [GocMo], [DoKin], [NhietDoLamViec], [HeSoCongSuat], [VatLieu], [Content], [Warranty], [UserID], [CreateDate], [Status]) VALUES (34, NULL, N'Led bóng quả nhót 2', CAST(0 AS Decimal(18, 0)), CAST(50000 AS Decimal(18, 0)), 1, N'2015_12_28_12_19_18_21_smallSize.jpg', NULL, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, CAST(0x05340B00 AS Date), 1)
INSERT [dbo].[tblProducts] ([ProductID], [MetaTitle], [NameProduct], [Price], [PriceNews], [ManufacturesID], [ImagesMain], [DienAp], [LedChip], [Quantity], [TuoiTho], [QuangThong], [HeSoCRI], [NhietDoMau], [GocMo], [DoKin], [NhietDoLamViec], [HeSoCongSuat], [VatLieu], [Content], [Warranty], [UserID], [CreateDate], [Status]) VALUES (35, NULL, N'Led bóng quả nhót 3', CAST(0 AS Decimal(18, 0)), CAST(50000 AS Decimal(18, 0)), 1, N'2016_01_05_17_14_00_68_smallSize.jpg', NULL, NULL, 11, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, CAST(0x283B0B00 AS Date), 1)
INSERT [dbo].[tblProducts] ([ProductID], [MetaTitle], [NameProduct], [Price], [PriceNews], [ManufacturesID], [ImagesMain], [DienAp], [LedChip], [Quantity], [TuoiTho], [QuangThong], [HeSoCRI], [NhietDoMau], [GocMo], [DoKin], [NhietDoLamViec], [HeSoCongSuat], [VatLieu], [Content], [Warranty], [UserID], [CreateDate], [Status]) VALUES (36, NULL, N'Led bóng quả nhót 4', CAST(0 AS Decimal(18, 0)), CAST(40000 AS Decimal(18, 0)), 1, N'2016_01_05_16_59_26_54_smallSize.jpg', NULL, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, CAST(0x283B0B00 AS Date), 1)
INSERT [dbo].[tblProducts] ([ProductID], [MetaTitle], [NameProduct], [Price], [PriceNews], [ManufacturesID], [ImagesMain], [DienAp], [LedChip], [Quantity], [TuoiTho], [QuangThong], [HeSoCRI], [NhietDoMau], [GocMo], [DoKin], [NhietDoLamViec], [HeSoCongSuat], [VatLieu], [Content], [Warranty], [UserID], [CreateDate], [Status]) VALUES (37, NULL, N'Đèn led tranh 3D 300x600 - 12W ', CAST(0 AS Decimal(18, 0)), CAST(50000 AS Decimal(18, 0)), 1, N'2015_12_28_12_19_18_21_smallSize.jpg', NULL, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, CAST(0x283B0B00 AS Date), 1)
INSERT [dbo].[tblProducts] ([ProductID], [MetaTitle], [NameProduct], [Price], [PriceNews], [ManufacturesID], [ImagesMain], [DienAp], [LedChip], [Quantity], [TuoiTho], [QuangThong], [HeSoCRI], [NhietDoMau], [GocMo], [DoKin], [NhietDoLamViec], [HeSoCongSuat], [VatLieu], [Content], [Warranty], [UserID], [CreateDate], [Status]) VALUES (38, N'', N'Touve 1000', CAST(0 AS Decimal(18, 0)), CAST(10000 AS Decimal(18, 0)), 1, N'2016_01_05_17_14_00_68_smallSize.jpg', N'85-265VAC ', N'SMD 285 Taiwan', 1, NULL, N'>9000 LM  ', N'          ', N'          ', N'          ', N'          ', N'', N'          ', NULL, N'', NULL, NULL, NULL, 1)
INSERT [dbo].[tblProducts] ([ProductID], [MetaTitle], [NameProduct], [Price], [PriceNews], [ManufacturesID], [ImagesMain], [DienAp], [LedChip], [Quantity], [TuoiTho], [QuangThong], [HeSoCRI], [NhietDoMau], [GocMo], [DoKin], [NhietDoLamViec], [HeSoCongSuat], [VatLieu], [Content], [Warranty], [UserID], [CreateDate], [Status]) VALUES (45, N'', N'Touve 300123', CAST(12124 AS Decimal(18, 0)), CAST(30000 AS Decimal(18, 0)), 3, N'', N'640-80 VAC', N'SMD 285 Taiwan', 1, NULL, N'>9000 LM  ', N'>80       ', N'3000 -6500', N'          ', N'IP54      ', N'-20 den 45', N'>=0.9     ', NULL, N'', NULL, NULL, CAST(0x663B0B00 AS Date), 0)
INSERT [dbo].[tblProducts] ([ProductID], [MetaTitle], [NameProduct], [Price], [PriceNews], [ManufacturesID], [ImagesMain], [DienAp], [LedChip], [Quantity], [TuoiTho], [QuangThong], [HeSoCRI], [NhietDoMau], [GocMo], [DoKin], [NhietDoLamViec], [HeSoCongSuat], [VatLieu], [Content], [Warranty], [UserID], [CreateDate], [Status]) VALUES (46, N'1', N'2', CAST(3 AS Decimal(18, 0)), CAST(4 AS Decimal(18, 0)), 1, N'', N'5         ', N'6', 1, NULL, N'          ', N'          ', N'          ', N'          ', N'          ', N'', N'          ', NULL, N'', NULL, NULL, CAST(0x663B0B00 AS Date), 0)
INSERT [dbo].[tblProducts] ([ProductID], [MetaTitle], [NameProduct], [Price], [PriceNews], [ManufacturesID], [ImagesMain], [DienAp], [LedChip], [Quantity], [TuoiTho], [QuangThong], [HeSoCRI], [NhietDoMau], [GocMo], [DoKin], [NhietDoLamViec], [HeSoCongSuat], [VatLieu], [Content], [Warranty], [UserID], [CreateDate], [Status]) VALUES (47, N'123', N'', CAST(0 AS Decimal(18, 0)), CAST(1 AS Decimal(18, 0)), 1, N'', N'          ', N'', 1, NULL, N'          ', N'          ', N'          ', N'          ', N'          ', N'', N'          ', NULL, N'', NULL, NULL, CAST(0x663B0B00 AS Date), 0)
INSERT [dbo].[tblProducts] ([ProductID], [MetaTitle], [NameProduct], [Price], [PriceNews], [ManufacturesID], [ImagesMain], [DienAp], [LedChip], [Quantity], [TuoiTho], [QuangThong], [HeSoCRI], [NhietDoMau], [GocMo], [DoKin], [NhietDoLamViec], [HeSoCongSuat], [VatLieu], [Content], [Warranty], [UserID], [CreateDate], [Status]) VALUES (48, N'', N'', CAST(0 AS Decimal(18, 0)), CAST(1 AS Decimal(18, 0)), 1, NULL, N'          ', N'', 1, NULL, N'          ', N'          ', N'          ', N'          ', N'          ', N'', N'          ', NULL, N'', NULL, NULL, CAST(0x823B0B00 AS Date), 0)
INSERT [dbo].[tblProducts] ([ProductID], [MetaTitle], [NameProduct], [Price], [PriceNews], [ManufacturesID], [ImagesMain], [DienAp], [LedChip], [Quantity], [TuoiTho], [QuangThong], [HeSoCRI], [NhietDoMau], [GocMo], [DoKin], [NhietDoLamViec], [HeSoCongSuat], [VatLieu], [Content], [Warranty], [UserID], [CreateDate], [Status]) VALUES (49, N'', N'', CAST(0 AS Decimal(18, 0)), CAST(1 AS Decimal(18, 0)), 1, NULL, N'          ', N'', 1, NULL, N'          ', N'          ', N'          ', N'          ', N'          ', N'', N'          ', NULL, N'', NULL, NULL, CAST(0x823B0B00 AS Date), 0)
INSERT [dbo].[tblProducts] ([ProductID], [MetaTitle], [NameProduct], [Price], [PriceNews], [ManufacturesID], [ImagesMain], [DienAp], [LedChip], [Quantity], [TuoiTho], [QuangThong], [HeSoCRI], [NhietDoMau], [GocMo], [DoKin], [NhietDoLamViec], [HeSoCongSuat], [VatLieu], [Content], [Warranty], [UserID], [CreateDate], [Status]) VALUES (50, N'', N'', CAST(0 AS Decimal(18, 0)), CAST(1 AS Decimal(18, 0)), 1, NULL, N'          ', N'', 1, NULL, N'          ', N'          ', N'          ', N'          ', N'          ', N'', N'          ', NULL, N'', NULL, NULL, CAST(0x823B0B00 AS Date), 0)
INSERT [dbo].[tblProducts] ([ProductID], [MetaTitle], [NameProduct], [Price], [PriceNews], [ManufacturesID], [ImagesMain], [DienAp], [LedChip], [Quantity], [TuoiTho], [QuangThong], [HeSoCRI], [NhietDoMau], [GocMo], [DoKin], [NhietDoLamViec], [HeSoCongSuat], [VatLieu], [Content], [Warranty], [UserID], [CreateDate], [Status]) VALUES (51, N'', N'1111111111', CAST(0 AS Decimal(18, 0)), CAST(1 AS Decimal(18, 0)), 1, NULL, N'          ', N'', 1, NULL, N'          ', N'          ', N'          ', N'          ', N'          ', N'', N'          ', NULL, N'', NULL, NULL, CAST(0x823B0B00 AS Date), 0)
INSERT [dbo].[tblProducts] ([ProductID], [MetaTitle], [NameProduct], [Price], [PriceNews], [ManufacturesID], [ImagesMain], [DienAp], [LedChip], [Quantity], [TuoiTho], [QuangThong], [HeSoCRI], [NhietDoMau], [GocMo], [DoKin], [NhietDoLamViec], [HeSoCongSuat], [VatLieu], [Content], [Warranty], [UserID], [CreateDate], [Status]) VALUES (52, N'', N'111111333', CAST(0 AS Decimal(18, 0)), CAST(1 AS Decimal(18, 0)), 1, NULL, N'          ', N'', 1, NULL, N'          ', N'          ', N'          ', N'          ', N'          ', N'', N'          ', NULL, N'', NULL, NULL, CAST(0x823B0B00 AS Date), 0)
INSERT [dbo].[tblProducts] ([ProductID], [MetaTitle], [NameProduct], [Price], [PriceNews], [ManufacturesID], [ImagesMain], [DienAp], [LedChip], [Quantity], [TuoiTho], [QuangThong], [HeSoCRI], [NhietDoMau], [GocMo], [DoKin], [NhietDoLamViec], [HeSoCongSuat], [VatLieu], [Content], [Warranty], [UserID], [CreateDate], [Status]) VALUES (53, N'', N'44444', CAST(0 AS Decimal(18, 0)), NULL, 1, N'7f43feb8-94e2-4322-a039-6ef872405392.jpg', N'          ', N'', 1, NULL, N'          ', N'          ', N'          ', N'          ', N'          ', N'', N'          ', NULL, N'', NULL, NULL, CAST(0x823B0B00 AS Date), 0)
INSERT [dbo].[tblProducts] ([ProductID], [MetaTitle], [NameProduct], [Price], [PriceNews], [ManufacturesID], [ImagesMain], [DienAp], [LedChip], [Quantity], [TuoiTho], [QuangThong], [HeSoCRI], [NhietDoMau], [GocMo], [DoKin], [NhietDoLamViec], [HeSoCongSuat], [VatLieu], [Content], [Warranty], [UserID], [CreateDate], [Status]) VALUES (54, N'', N'555555', CAST(0 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)), 1, N'', N'          ', N'', 0, NULL, N'          ', N'          ', N'          ', N'          ', N'          ', N'', N'          ', NULL, N'', NULL, NULL, CAST(0x823B0B00 AS Date), 0)
SET IDENTITY_INSERT [dbo].[tblProducts] OFF
SET IDENTITY_INSERT [dbo].[tblUsers] ON 

INSERT [dbo].[tblUsers] ([UserID], [Name], [Account], [Password], [Status]) VALUES (1, N'trong', N'admin', N'21232f297a57a5a743894a0e4a801fc3', 1)
INSERT [dbo].[tblUsers] ([UserID], [Name], [Account], [Password], [Status]) VALUES (2, N'ducanh', N'ducanh', N'21232f297a57a5a743894a0e4a801fc3', 1)
SET IDENTITY_INSERT [dbo].[tblUsers] OFF
ALTER TABLE [dbo].[tblCategories] ADD  CONSTRAINT [DF_tblCategories_Status]  DEFAULT ((0)) FOR [Status]
GO
ALTER TABLE [dbo].[tblCategories] ADD  CONSTRAINT [DF_tblCategories_CreateDate]  DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [dbo].[tblContact] ADD  CONSTRAINT [DF_tblContact_DateSent]  DEFAULT (getdate()) FOR [DateSent]
GO
ALTER TABLE [dbo].[tblContact] ADD  CONSTRAINT [DF_tblContact_Status]  DEFAULT ((0)) FOR [Status]
GO
ALTER TABLE [dbo].[tblCustomer] ADD  CONSTRAINT [DF_tblCustomer_CreateDate]  DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [dbo].[tblOrders] ADD  CONSTRAINT [DF_tblOrders_DateSet]  DEFAULT (getdate()) FOR [DateSet]
GO
ALTER TABLE [dbo].[tblOrders] ADD  CONSTRAINT [DF_tblOrders_Status]  DEFAULT ((0)) FOR [Status]
GO
ALTER TABLE [dbo].[tblProducts] ADD  CONSTRAINT [DF_tblProducts_CreateDate]  DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [dbo].[tblProducts] ADD  CONSTRAINT [DF_tblProducts_Status]  DEFAULT ((0)) FOR [Status]
GO
ALTER TABLE [dbo].[tblCategoryProducts]  WITH CHECK ADD  CONSTRAINT [FK_tblCategoryProducts_tblCategories] FOREIGN KEY([CategoryID])
REFERENCES [dbo].[tblCategories] ([CategoryID])
GO
ALTER TABLE [dbo].[tblCategoryProducts] CHECK CONSTRAINT [FK_tblCategoryProducts_tblCategories]
GO
ALTER TABLE [dbo].[tblOrderDetail]  WITH CHECK ADD  CONSTRAINT [FK_tblOrderDetail_tblOrders] FOREIGN KEY([OrderID])
REFERENCES [dbo].[tblOrders] ([OrderID])
GO
ALTER TABLE [dbo].[tblOrderDetail] CHECK CONSTRAINT [FK_tblOrderDetail_tblOrders]
GO
ALTER TABLE [dbo].[tblOrders]  WITH CHECK ADD  CONSTRAINT [FK_tblOrders_tblCustomer] FOREIGN KEY([CustomerID])
REFERENCES [dbo].[tblCustomer] ([CustomerID])
GO
ALTER TABLE [dbo].[tblOrders] CHECK CONSTRAINT [FK_tblOrders_tblCustomer]
GO
