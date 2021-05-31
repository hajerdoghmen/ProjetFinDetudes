USE [PFE]
GO

/****** Object:  Table [dbo].[ArticleCategory]    Script Date: 31/05/2021 13:52:58 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ArticleCategory](
	[ArticleCategoryId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ArticleCategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


