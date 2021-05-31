/****** Script de la commande SelectTopNRows à partir de SSMS  ******/
SELECT TOP (1000) [DiscoutId]
      ,[ArticleId]
      ,[StartDate]
      ,[EndDate]
      ,[Percent]
  FROM [PFE].[dbo].[Discount]