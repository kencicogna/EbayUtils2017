USE [BTData]
GO

/****** Object:  Table [dbo].[picklist]    Script Date: 01/07/2017 16:02:35 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[picklist](
	[location] [nvarchar](30) NULL,
	[image_url] [nvarchar](256) NULL,
	[quantity] [int] NULL,
	[Title] [nvarchar](120) NULL,
	[Variation] [nvarchar](64) NULL,
	[DI_flag] [nvarchar](1) NULL,
	[SKU] [nvarchar](50) NULL,
	[item_picked] [int] NULL
) ON [PRIMARY]

GO

