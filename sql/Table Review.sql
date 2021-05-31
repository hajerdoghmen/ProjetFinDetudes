/****** Script de la commande SelectTopNRows à partir de SSMS  ******/
SELECT TOP (1000) [ReviewId]
      ,[ArticleId]
      ,[Score]
      ,[Comments]
      ,[ReviewDate]
  FROM [PFE].[dbo].[Review]