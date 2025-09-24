CREATE TABLE [dbo].[loginWizardRuleTBL](
	[loginWizardRuleId] [int] NOT NULL,
	[loginWizardStageId] [int] NOT NULL,
	[loginWizardRuleCategoryId] [int] NOT NULL,
	[description] [nvarchar](128) NOT NULL,
	[reasonDisplayText] [nvarchar](1024) NOT NULL,
	[activationPeriod] [int] NULL,
	[required] [bit] NOT NULL,
	[active] [bit] NOT NULL,
	[deleted] [bit] NOT NULL,
	[amendUserId] [int] NOT NULL,
	[amendDate] [datetimeoffset](7) NOT NULL,
 CONSTRAINT [PK_loginWizardRule] PRIMARY KEY CLUSTERED 
(
	[loginWizardRuleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 100) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[loginWizardRuleTBL]  WITH CHECK ADD  CONSTRAINT [FK_loginWizardRuleTBL_loginWizardStageTBL] FOREIGN KEY([loginWizardStageId])
REFERENCES [dbo].[loginWizardStageTBL] ([loginWizardStageId])
GO

ALTER TABLE [dbo].[loginWizardRuleTBL] CHECK CONSTRAINT [FK_loginWizardRuleTBL_loginWizardStageTBL]
GO