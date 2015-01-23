USE [awards]
GO

/****** Object:  Table [dbo].[submissions]    Script Date: 2013-08-06 2:58:18 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[submissions](
	[id] [uniqueidentifier] NOT NULL,
	[datesubmitted] [datetime] NOT NULL,
	[firstname] [nvarchar](100) NOT NULL,
	[lastname] [nvarchar](100) NOT NULL,
	[studentnumber] [nvarchar](10) NOT NULL,
	[email] [nvarchar](100) NOT NULL,
	[address1] [nvarchar](100) NOT NULL,
	[address2] [nvarchar](100) NULL,
	[city] [nvarchar](100) NOT NULL,
	[province] [nvarchar](100) NOT NULL,
	[postalcode] [nvarchar](50) NOT NULL,
	[phone1] [nvarchar](50) NOT NULL,
	[phone2] [nvarchar](50) NULL,
	[campus] [nvarchar](100) NOT NULL,
	[campusname] [nvarchar](100) NOT NULL,
	[program] [nvarchar](100) NOT NULL,
	[programname] [nvarchar](100) NOT NULL,
	[incomeprestudy] [decimal](18, 0) NOT NULL,
	[incomefamily] [decimal](18, 0) NOT NULL,
	[incomespouse] [decimal](18, 0) NOT NULL,
	[incomescholarships] [decimal](18, 0) NOT NULL,
	[incomesponsorships] [decimal](18, 0) NOT NULL,
	[incomestudentloan] [decimal](18, 0) NOT NULL,
	[incomeotherloan] [decimal](18, 0) NOT NULL,
	[incomesavings] [decimal](18, 0) NOT NULL,
	[incomestudyperiod] [decimal](18, 0) NOT NULL,
	[incomeother] [decimal](18, 0) NOT NULL,
	[incometotal] [decimal](18, 0) NOT NULL,
	[expensetuition] [decimal](18, 0) NOT NULL,
	[expensehealthbenefits] [decimal](18, 0) NOT NULL,
	[expensestudentassociation] [decimal](18, 0) NOT NULL,
	[expenseupass] [decimal](18, 0) NOT NULL,
	[expensetextbooks] [decimal](18, 0) NOT NULL,
	[expenseparking] [decimal](18, 0) NOT NULL,
	[expenseportfoliosupplies] [decimal](18, 0) NOT NULL,
	[expensegeneralsupplies] [decimal](18, 0) NOT NULL,
	[expensetools] [decimal](18, 0) NOT NULL,
	[expensesafetycerts] [decimal](18, 0) NOT NULL,
	[expensesafetysupplies] [decimal](18, 0) NOT NULL,
	[expensemedical] [decimal](18, 0) NOT NULL,
	[expenseother] [decimal](18, 0) NOT NULL,
	[expenserentmortgage] [decimal](18, 0) NOT NULL,
	[expensephone] [decimal](18, 0) NOT NULL,
	[expenseinternet] [decimal](18, 0) NOT NULL,
	[expenseelectricity] [decimal](18, 0) NOT NULL,
	[expenseheat] [decimal](18, 0) NOT NULL,
	[expenseinsurance] [decimal](18, 0) NOT NULL,
	[expensegroceries] [decimal](18, 0) NOT NULL,
	[expensedebtpayments] [decimal](18, 0) NOT NULL,
	[expensefamilycare] [decimal](18, 0) NOT NULL,
	[expensetransportation] [decimal](18, 0) NOT NULL,
	[expensepersonal] [decimal](18, 0) NOT NULL,
	[expensetotal] [decimal](18, 0) NOT NULL,
	[financialneed] [decimal](18, 0) NOT NULL,
	[question1] [text] NULL,
	[question2] [text] NULL,
	[question3] [text] NULL,
	[question4] [text] NULL,
	[question5] [text] NULL,
	[question6] [text] NULL,
	[question7] [text] NULL,
	[question8] [text] NULL,
	[question9] [text] NULL,
	[question10] [text] NULL,
	[acceptedterms] [bit] NULL,
	[useragent] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_submissions] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

