CREATE TABLE [dbo].[termsAndConditionsTBL](
	[termsAndConditionsId] [int] IDENTITY(1,1) NOT NULL,
	[createdDate] [datetimeoffset](7) NOT NULL,
	[description] [nvarchar](512) NOT NULL,
	[details] [ntext] NOT NULL,
	[tenantId] [int] NOT NULL,
	[active] [bit] NOT NULL,
	[reportable] [bit] NOT NULL,
	[deleted] [bit] NOT NULL,
	[amendUserID] [int] NOT NULL,
	[amendDate] [datetimeoffset](7) NOT NULL,
 CONSTRAINT [PK_termsAndConditions] PRIMARY KEY CLUSTERED 
(
	[termsAndConditionsId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 100) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[termsAndConditionsTBL] ADD  DEFAULT ((1)) FOR [reportable]
GO

ALTER TABLE [dbo].[termsAndConditionsTBL]  WITH CHECK ADD  CONSTRAINT [FK_termsAndConditionsTBL_tenantTBL] FOREIGN KEY([tenantId])
REFERENCES [dbo].[tenantTBL] ([tenantId])
GO

ALTER TABLE [dbo].[termsAndConditionsTBL] CHECK CONSTRAINT [FK_termsAndConditionsTBL_tenantTBL]
GO