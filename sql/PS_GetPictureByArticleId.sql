USE [PFE]
GO
/****** Object:  StoredProcedure [dbo].[PS_GetPictureByArticleId]    Script Date: 31/05/2021 13:58:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[PS_GetPictureByArticleId] 
	 @articleId INT
AS
BEGIN
	SET NOCOUNT ON;

    SELECT p.ArticleId,
	       p.PictureId,
	       p.Picture
	FROM Picture p

	WHERE p.ArticleId = @articleId
END
