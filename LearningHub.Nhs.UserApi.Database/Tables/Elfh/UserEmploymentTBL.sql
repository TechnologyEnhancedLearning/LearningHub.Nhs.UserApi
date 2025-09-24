
CREATE TABLE [dbo].[userEmploymentTBL](
	[userEmploymentId] [int] IDENTITY(1,1) NOT NULL,
	[userId] [int] NOT NULL,
	[jobRoleId] [int] NULL,
	[specialtyId] [int] NULL,
	[gradeId] [int] NULL,
	[schoolId] [int] NULL,
	[locationId] [int] NOT NULL,
	[medicalCouncilId] [int] NULL,
	[medicalCouncilNo] [nvarchar](50) NULL,
	[startDate] [datetimeoffset](7) NULL,
	[endDate] [datetimeoffset](7) NULL,
	[deleted] [bit] NOT NULL,
	[archived] [bit] NOT NULL,
	[amendUserId] [int] NOT NULL,
	[amendDate] [datetimeoffset](7) NOT NULL,
 CONSTRAINT [PK_userEmploymentTBL] PRIMARY KEY CLUSTERED 
(
	[userEmploymentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 100) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[userEmploymentTBL] ADD  CONSTRAINT [DF_userEmploymentTBL_deleted]  DEFAULT ((0)) FOR [deleted]
GO

ALTER TABLE [dbo].[userEmploymentTBL] ADD  CONSTRAINT [DF_userEmploymentTBL_archived]  DEFAULT ((0)) FOR [archived]
GO

ALTER TABLE [dbo].[userEmploymentTBL]  WITH CHECK ADD  CONSTRAINT [FK_userEmploymentTBL_gradeTBL] FOREIGN KEY([gradeId])
REFERENCES [dbo].[gradeTBL] ([gradeId])
GO

ALTER TABLE [dbo].[userEmploymentTBL] CHECK CONSTRAINT [FK_userEmploymentTBL_gradeTBL]
GO

ALTER TABLE [dbo].[userEmploymentTBL]  WITH CHECK ADD  CONSTRAINT [FK_userEmploymentTBL_jobRoleTBL] FOREIGN KEY([jobRoleId])
REFERENCES [dbo].[jobRoleTBL] ([jobRoleId])
GO

ALTER TABLE [dbo].[userEmploymentTBL] CHECK CONSTRAINT [FK_userEmploymentTBL_jobRoleTBL]
GO

ALTER TABLE [dbo].[userEmploymentTBL]  WITH CHECK ADD  CONSTRAINT [FK_userEmploymentTBL_locationTBL] FOREIGN KEY([locationId])
REFERENCES [dbo].[locationTBL] ([locationId])
GO

ALTER TABLE [dbo].[userEmploymentTBL] CHECK CONSTRAINT [FK_userEmploymentTBL_locationTBL]
GO

ALTER TABLE [dbo].[userEmploymentTBL]  WITH CHECK ADD  CONSTRAINT [FK_userEmploymentTBL_medicalCouncilTBL] FOREIGN KEY([medicalCouncilId])
REFERENCES [dbo].[medicalCouncilTBL] ([medicalCouncilId])
GO

ALTER TABLE [dbo].[userEmploymentTBL] CHECK CONSTRAINT [FK_userEmploymentTBL_medicalCouncilTBL]
GO

ALTER TABLE [dbo].[userEmploymentTBL]  WITH CHECK ADD  CONSTRAINT [FK_userEmploymentTBL_schoolTBL] FOREIGN KEY([schoolId])
REFERENCES [dbo].[schoolTBL] ([schoolId])
GO

ALTER TABLE [dbo].[userEmploymentTBL] CHECK CONSTRAINT [FK_userEmploymentTBL_schoolTBL]
GO

ALTER TABLE [dbo].[userEmploymentTBL]  WITH CHECK ADD  CONSTRAINT [FK_userEmploymentTBL_specialtyTBL] FOREIGN KEY([specialtyId])
REFERENCES [dbo].[specialtyTBL] ([specialtyId])
GO

ALTER TABLE [dbo].[userEmploymentTBL] CHECK CONSTRAINT [FK_userEmploymentTBL_specialtyTBL]
GO

ALTER TABLE [dbo].[userEmploymentTBL]  WITH CHECK ADD  CONSTRAINT [FK_userEmploymentTBL_userTBL] FOREIGN KEY([userId])
REFERENCES [dbo].[userTBL] ([userId])
GO

ALTER TABLE [dbo].[userEmploymentTBL] CHECK CONSTRAINT [FK_userEmploymentTBL_userTBL]
GO

ALTER TABLE [dbo].[userEmploymentTBL]  WITH CHECK ADD  CONSTRAINT [FK_userEmploymentTBL_userTBL_AmendUser] FOREIGN KEY([amendUserId])
REFERENCES [dbo].[userTBL] ([userId])
GO

ALTER TABLE [dbo].[userEmploymentTBL] CHECK CONSTRAINT [FK_userEmploymentTBL_userTBL_AmendUser]
GO