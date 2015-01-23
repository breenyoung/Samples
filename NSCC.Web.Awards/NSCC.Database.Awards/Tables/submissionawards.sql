USE [awards]
GO

/****** Object:  Table [dbo].[submissionawards]    Script Date: 2013-08-06 2:58:07 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[submissionawards](
	[submissionid] [uniqueidentifier] NOT NULL,
	[awardid] [nvarchar](100) NOT NULL
) ON [PRIMARY]

GO

