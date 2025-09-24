CREATE TABLE [dbo].[userRoleUpgradeTBL](
	[userRoleUpgradeId] [int] IDENTITY(1,1) NOT NULL,
	[userId] [int] NOT NULL,
	[emailAddress] [nvarchar](100) NOT NULL,
	[upgradeDate] [datetimeoffset](7) NULL,
	[deleted] [bit] NOT NULL,
	[createUserId] [int] NOT NULL,
	[createDate] [datetimeoffset](7) NOT NULL,
	[amendUserId] [int] NOT NULL,
	[amendDate] [datetimeoffset](7) NOT NULL,
	[userHistoryTypeId] [int] NOT NULL,
 CONSTRAINT [PK_userRoleUpgrade] PRIMARY KEY CLUSTERED 
(
	[userRoleUpgradeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[userRoleUpgradeTBL] ADD  DEFAULT ((12)) FOR [userHistoryTypeId]
GO

ALTER TABLE [dbo].[userRoleUpgradeTBL]  WITH CHECK ADD  CONSTRAINT [FK_userRoleUpgradeTBL_userHistoryTypeTBL] FOREIGN KEY([userHistoryTypeId])
REFERENCES [dbo].[userHistoryTypeTBL] ([UserHistoryTypeId])
GO

ALTER TABLE [dbo].[userRoleUpgradeTBL] CHECK CONSTRAINT [FK_userRoleUpgradeTBL_userHistoryTypeTBL]
GO

ALTER TABLE [dbo].[userRoleUpgradeTBL]  WITH CHECK ADD  CONSTRAINT [FK_userRoleUpgradeTbl_userTbl] FOREIGN KEY([userId])
REFERENCES [dbo].[userTBL] ([userId])
GO

ALTER TABLE [dbo].[userRoleUpgradeTBL] CHECK CONSTRAINT [FK_userRoleUpgradeTbl_userTbl]
GO

