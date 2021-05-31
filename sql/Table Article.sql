USE [PFE]
GO

/****** Object:  Table [dbo].[Article]    Script Date: 31/05/2021 13:55:38 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Article](
	[ArticleId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[ArticleCategoryId] [int] NULL,
	[Price] [float] NULL,
	[DeliveryEstimated] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ArticleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Article]  WITH CHECK ADD FOREIGN KEY([ArticleCategoryId])
REFERENCES [dbo].[ArticleCategory] ([ArticleCategoryId])
GO


