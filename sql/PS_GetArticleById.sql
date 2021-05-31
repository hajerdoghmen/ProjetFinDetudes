USE [PFE]
GO
/****** Object:  StoredProcedure [dbo].[PS_GetArticleById]    Script Date: 31/05/2021 13:58:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[PS_GetArticleById] 
	 @articleId INT
AS
BEGIN
	SET NOCOUNT ON;

    SELECT a.ArticleId, 
		   a.ArticleCategoryId,
		   a.Name as 'ArticleName', 
		   a.Price, 
		   a.DeliveryEstimated
	FROM Article a --awel7aja ychufha FROM ba3d INNER JOIN ba3d WHERE ba3d SELECT ba3d ORDER BYE 
	--INNER JOIN ArticleCategory ac on ac.ArticleCategoryId = a.ArticleCategoryId -- nlasa9 ArtcileCategory fi Article
	--INNER JOIN Picture p on p.ArticleId =  a.ArticleId
	--INNER JOIN Review r on r.ArticleId = a.ArticleId
	WHERE a.ArticleId = @articleId
END






