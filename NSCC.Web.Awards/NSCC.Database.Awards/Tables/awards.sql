USE [awards]
GO
/****** Object:  Table [dbo].[awards]    Script Date: 08/08/2013 16:39:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[awards](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[code] [nvarchar](100) NOT NULL,
	[displayname] [nvarchar](255) NOT NULL,
	[description] [text] NOT NULL,
	[requireincomeinfo] [bit] NOT NULL CONSTRAINT [DF_awards_requireincomeinfo]  DEFAULT ((1)),
	[eligiblecampuses] [nvarchar](max) NOT NULL,
	[eligibleprograms] [nvarchar](max) NOT NULL,
	[essayquestions] [nvarchar](255) NULL,
	[attachments] [nvarchar](255) NULL,
	[sortorder] [int] NOT NULL,
	[active] [bit] NOT NULL CONSTRAINT [DF_awards_active]  DEFAULT ((1)),
 CONSTRAINT [PK_awards] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
