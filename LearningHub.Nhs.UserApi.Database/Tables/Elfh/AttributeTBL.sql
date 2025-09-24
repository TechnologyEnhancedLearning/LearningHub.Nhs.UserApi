CREATE TABLE [dbo].[attributeTBL](
	[attributeId] [int] IDENTITY(1,1) NOT NULL,
	[attributeTypeId] [int] NOT NULL,
	[attributeName] [nvarchar](50) NOT NULL,
	[attributeAccess] [tinyint] NOT NULL,
	[attributeDescription] [nvarchar](400) NULL,
	[deleted] [bit] NOT NULL,
	[amendUserId] [int] NOT NULL,
	[amendDate] [datetimeoffset](7) NOT NULL,
 CONSTRAINT [PK_attributeTBL] PRIMARY KEY CLUSTERED 
(
	[attributeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 100) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[attributeTBL] ADD  DEFAULT ((0)) FOR [attributeAccess]
GO

ALTER TABLE [dbo].[attributeTBL] ADD  DEFAULT ((0)) FOR [deleted]
GO

ALTER TABLE [dbo].[attributeTBL] ADD  DEFAULT (sysdatetimeoffset()) FOR [amendDate]
GO

ALTER TABLE [dbo].[attributeTBL]  WITH CHECK ADD  CONSTRAINT [FK_attributeTBL_attributeTypeId] FOREIGN KEY([attributeTypeId])
REFERENCES [dbo].[attributeTypeTBL] ([attributeTypeId])
GO

ALTER TABLE [dbo].[attributeTBL] CHECK CONSTRAINT [FK_attributeTBL_attributeTypeId]
GO