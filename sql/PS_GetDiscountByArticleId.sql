USE [PFE]
GO
/****** Object:  StoredProcedure [dbo].[PS_GetDiscountByArticleId]    Script Date: 31/05/2021 13:58:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[PS_GetDiscountByArticleId] 
	 @articleId INT
AS
BEGIN
	SET NOCOUNT ON;

    SELECT d.ArticleId,
	       d.DiscoutId,
	       d.StartDate,
		   d.EndDate,
		   d.[Percent]
	FROM Discount d

	WHERE d.ArticleId = @articleId
END
