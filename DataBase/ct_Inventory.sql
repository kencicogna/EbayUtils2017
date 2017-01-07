USE [BTData]
GO

/****** Object:  Table [dbo].[Inventory]    Script Date: 01/07/2017 16:06:56 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Inventory](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SKU] [nvarchar](30) NULL,
	[Variation] [nvarchar](64) NULL,
	[Title] [nvarchar](120) NULL,
	[short_title] [nvarchar](256) NULL,
	[cost] [nvarchar](10) NULL,
	[supplier] [varchar](100) NULL,
	[image_url] [nvarchar](256) NULL,
	[main_image_url] [nvarchar](256) NULL,
	[weight] [int] NULL,
	[packaged_weight] [real] NULL,
	[bubblewrap] [varchar](1) NULL,
	[packaging] [nvarchar](50) NULL,
	[eBayItemID] [nvarchar](50) NULL,
	[eBayItemHistoryID] [nvarchar](50) NULL,
	[ASIN] [nvarchar](30) NULL,
	[UPC] [nvarchar](64) NULL,
	[Location] [nvarchar](30) NULL,
	[active] [int] NOT NULL,
	[last_modified] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

