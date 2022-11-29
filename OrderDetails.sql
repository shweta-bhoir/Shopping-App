USE [temp]
GO

/****** Object:  Table [dbo].[orderDetails]    Script Date: 11/29/2022 8:32:19 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[orderDetails](
	[orderDetailID] [int] IDENTITY(1,1) NOT NULL,
	[orderId] [int] NULL,
	[itemName] [varchar](50) NOT NULL,
	[Qty] [int] NOT NULL,
	[itemAmount] [int] NOT NULL,
	[discountAmount] [int] NULL,
	[finalAmount] [int] NOT NULL,
	[createdOn] [date] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[orderDetailID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[orderDetails]  WITH CHECK ADD FOREIGN KEY([orderId])
REFERENCES [dbo].[Orders] ([orderId])
GO


