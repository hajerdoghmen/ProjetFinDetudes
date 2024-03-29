USE [PFE]
GO
/****** Object:  StoredProcedure [dbo].[PS_GetReviewByArticleId]    Script Date: 31/05/2021 13:58:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[PS_GetReviewByArticleId] 
	 @articleId INT
AS
BEGIN
	SET NOCOUNT ON;

    SELECT r.ArticleId, 
	       r.ReviewId,
		   r.Score,
		   r.Comments,
		   r.ReviewDate
	FROM Review r

	WHERE r.ArticleId = @articleId
END