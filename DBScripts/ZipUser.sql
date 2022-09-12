USE [ALTIMETRIK]
GO

/****** Object:  Table [dbo].[ZipUser]    Script Date: 13-09-2022 00:03:24 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ZipUser](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](50) NOT NULL,
	[LastName] [varchar](50) NOT NULL,
	[Email] [varchar](100) NOT NULL,
	[Phone] [varchar](30) NOT NULL,
	[JobTitle] [varchar](50) NOT NULL,
	[MonthlySalary] [money] NOT NULL,
	[MonthlyExpense] [money] NULL,
	[ModifiedOn] [datetime] NOT NULL,
 CONSTRAINT [PK_ZipUser] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


