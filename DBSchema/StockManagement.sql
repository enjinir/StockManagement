USE [StockManagement]
GO
/****** Object:  Table [dbo].[OperationLog]    Script Date: 09-11-15 10:44:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OperationLog](
	[LogId] [uniqueidentifier] NOT NULL DEFAULT (newsequentialid()),
	[UserId] [uniqueidentifier] NULL,
	[OperationType] [nvarchar](50) NULL,
	[OperationDate] [datetime] NULL,
	[RecordId] [uniqueidentifier] NULL,
	[OperationDetails] [nvarchar](2000) NULL,
 CONSTRAINT [PK_OperationLog] PRIMARY KEY CLUSTERED 
(
	[LogId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Product]    Script Date: 09-11-15 10:44:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[ProductId] [uniqueidentifier] NOT NULL DEFAULT (newsequentialid()),
	[Name] [nvarchar](50) NULL,
	[OwnerId] [uniqueidentifier] NULL,
PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Stock]    Script Date: 09-11-15 10:44:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Stock](
	[ProductId] [uniqueidentifier] NOT NULL,
	[Count] [int] NULL,
	[UnitPrice] [float] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[User]    Script Date: 09-11-15 10:44:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[UserId] [uniqueidentifier] NOT NULL CONSTRAINT [DF__User__UserId__1BFD2C07]  DEFAULT (newsequentialid()),
	[FullName] [nvarchar](255) NOT NULL,
	[Email] [nvarchar](255) NOT NULL,
	[Username] [nvarchar](255) NOT NULL,
	[Password] [nvarchar](2048) NOT NULL,
	[RegistrationDate] [datetime] NOT NULL,
	[IsAdmin] [bit] NOT NULL,
 CONSTRAINT [PK__User__1788CC4C874834B8] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  View [dbo].[Logs]    Script Date: 09-11-15 10:44:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[Logs]
AS
SELECT   dbo.OperationLog.OperationType, dbo.OperationLog.OperationDetails, dbo.OperationLog.OperationDate, dbo.[User].FullName, dbo.Product.Name, dbo.Stock.Count, dbo.OperationLog.LogId, dbo.OperationLog.UserId, 
                dbo.OperationLog.RecordId
FROM      dbo.OperationLog LEFT JOIN
                dbo.Product ON dbo.OperationLog.RecordId = dbo.Product.ProductId LEFT JOIN
                dbo.Stock ON dbo.Product.ProductId = dbo.Stock.ProductId LEFT JOIN
                dbo.[User] ON dbo.OperationLog.UserId = dbo.[User].UserId

GO
INSERT [dbo].[OperationLog] ([LogId], [UserId], [OperationType], [OperationDate], [RecordId], [OperationDetails]) VALUES (N'a868c3a6-2087-e511-827a-ac7ba154be9b', N'eac3a7fb-1387-e511-827a-ac7ba154be9b', N'Login', CAST(N'2015-11-09 22:30:02.110' AS DateTime), NULL, N'Keysi Goldengil logged in.')
INSERT [dbo].[OperationLog] ([LogId], [UserId], [OperationType], [OperationDate], [RecordId], [OperationDetails]) VALUES (N'18978956-2187-e511-827a-ac7ba154be9b', N'eac3a7fb-1387-e511-827a-ac7ba154be9b', N'Login', CAST(N'2015-11-09 22:34:57.010' AS DateTime), NULL, N'Keysi Goldengil logged in.')
INSERT [dbo].[OperationLog] ([LogId], [UserId], [OperationType], [OperationDate], [RecordId], [OperationDetails]) VALUES (N'd148db75-2187-e511-827a-ac7ba154be9b', N'eac3a7fb-1387-e511-827a-ac7ba154be9b', N'Login', CAST(N'2015-11-09 22:35:49.557' AS DateTime), NULL, N'Keysi Goldengil logged in.')
INSERT [dbo].[OperationLog] ([LogId], [UserId], [OperationType], [OperationDate], [RecordId], [OperationDetails]) VALUES (N'b4a190a4-2187-e511-827a-ac7ba154be9b', N'eac3a7fb-1387-e511-827a-ac7ba154be9b', N'Login', CAST(N'2015-11-09 22:37:07.917' AS DateTime), NULL, N'Keysi Goldengil logged in.')
INSERT [dbo].[Product] ([ProductId], [Name], [OwnerId]) VALUES (N'7c17b19e-2e83-e511-827a-ac7ba154be9b', N'Onluk Çivi', N'cdbb008b-5b7a-e511-8277-ac7ba154be9b')
INSERT [dbo].[Product] ([ProductId], [Name], [OwnerId]) VALUES (N'19232cca-5f85-e511-827a-ac7ba154be9b', N'Makaralı Çamaşır Askısı', N'68cc3276-5b7a-e511-8277-ac7ba154be9b')
INSERT [dbo].[Stock] ([ProductId], [Count], [UnitPrice]) VALUES (N'7c17b19e-2e83-e511-827a-ac7ba154be9b', 100000, 5)
INSERT [dbo].[Stock] ([ProductId], [Count], [UnitPrice]) VALUES (N'19232cca-5f85-e511-827a-ac7ba154be9b', 45, 5)
INSERT [dbo].[User] ([UserId], [FullName], [Email], [Username], [Password], [RegistrationDate], [IsAdmin]) VALUES (N'68cc3276-5b7a-e511-8277-ac7ba154be9b', N'Mehmet Seçkin', N'seckin92@gmail.com', N'seckin92', N'1234', CAST(N'2015-01-01 00:00:00.000' AS DateTime), 0)
INSERT [dbo].[User] ([UserId], [FullName], [Email], [Username], [Password], [RegistrationDate], [IsAdmin]) VALUES (N'cdbb008b-5b7a-e511-8277-ac7ba154be9b', N'Erdem Yücesoy', N'erdemyucesoy@gmail.com', N'erdemy', N'1234', CAST(N'2015-01-01 00:00:00.000' AS DateTime), 0)
INSERT [dbo].[User] ([UserId], [FullName], [Email], [Username], [Password], [RegistrationDate], [IsAdmin]) VALUES (N'acea5a25-d084-e511-827a-ac7ba154be9b', N'Seren Can', N'serencan18@gmail.com', N'serencan', N'1234', CAST(N'2015-11-07 00:48:42.923' AS DateTime), 0)
INSERT [dbo].[User] ([UserId], [FullName], [Email], [Username], [Password], [RegistrationDate], [IsAdmin]) VALUES (N'eac3a7fb-1387-e511-827a-ac7ba154be9b', N'Keysi Goldengil', N'keysigolden@gmail.com', N'fare', N'1234', CAST(N'2015-11-09 20:59:20.900' AS DateTime), 1)
ALTER TABLE [dbo].[OperationLog]  WITH NOCHECK ADD  CONSTRAINT [FK_OperationLog_Product] FOREIGN KEY([RecordId])
REFERENCES [dbo].[Product] ([ProductId])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[OperationLog] CHECK CONSTRAINT [FK_OperationLog_Product]
GO
ALTER TABLE [dbo].[OperationLog]  WITH CHECK ADD  CONSTRAINT [FK_OperationLog_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[OperationLog] CHECK CONSTRAINT [FK_OperationLog_User]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_User] FOREIGN KEY([OwnerId])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_User]
GO
ALTER TABLE [dbo].[Stock]  WITH CHECK ADD  CONSTRAINT [FK_Stock_Product] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([ProductId])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Stock] CHECK CONSTRAINT [FK_Stock_Product]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[50] 4[19] 2[12] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "OperationLog"
            Begin Extent = 
               Top = 106
               Left = 924
               Bottom = 247
               Right = 1111
            End
            DisplayFlags = 280
            TopColumn = 2
         End
         Begin Table = "Product"
            Begin Extent = 
               Top = 7
               Left = 267
               Bottom = 129
               Right = 441
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Stock"
            Begin Extent = 
               Top = 5
               Left = 12
               Bottom = 127
               Right = 186
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "User"
            Begin Extent = 
               Top = 157
               Left = 468
               Bottom = 298
               Right = 654
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'Logs'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'Logs'
GO
