CREATE TABLE [dbo].[loginWizardStageActivityTBL](
	[loginWizardStageActivityId] [int] IDENTITY(1,1) NOT NULL,
	[loginWizardStageId] [int] NOT NULL,
	[userId] [int] NOT NULL,
	[activityDatetime] [datetimeoffset](7) NOT NULL,
 CONSTRAINT [PK_loginWizardStageActivityTBL] PRIMARY KEY CLUSTERED 
(
	[loginWizardStageActivityId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 100) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[loginWizardStageActivityTBL]  WITH CHECK ADD  CONSTRAINT [FK_loginWizardStageActivityTBL_loginWizardStageTBL] FOREIGN KEY([loginWizardStageId])
REFERENCES [dbo].[loginWizardStageTBL] ([loginWizardStageId])
GO

ALTER TABLE [dbo].[loginWizardStageActivityTBL] CHECK CONSTRAINT [FK_loginWizardStageActivityTBL_loginWizardStageTBL]
GO

ALTER TABLE [dbo].[loginWizardStageActivityTBL]  WITH CHECK ADD  CONSTRAINT [FK_loginWizardStageActivityTBL_userTBL] FOREIGN KEY([userId])
REFERENCES [dbo].[userTBL] ([userId])
GO

ALTER TABLE [dbo].[loginWizardStageActivityTBL] CHECK CONSTRAINT [FK_loginWizardStageActivityTBL_userTBL]
GO