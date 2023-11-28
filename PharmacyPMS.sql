USE [PharmacyPMS]
GO
/****** Object:  Table [dbo].[Invoice]    Script Date: 28/09/2023 9:48:02 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Invoice](
	[CreatedAt] [datetime]  NULL,
	[UpdatedAt] [datetime]  NULL,
	[Active] [varchar](50)  NULL,
	[InvoiceID] [int] IDENTITY(1,1) NOT NULL,
	[InvoiceDate] [date] NOT NULL,
	[LoggedID] [int] NOT NULL,
	[TotalDiscount] [varchar](50) NOT NULL,
	[Total] [varchar](50) NOT NULL,
	[GrandTotal] [varchar](50) NOT NULL,
	[Payment] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[InvoiceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Invoice_Order]    Script Date: 28/09/2023 9:48:02 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Invoice_Order](
	[CreatedAt] [datetime]  NULL,
	[UpdatedAt] [datetime]  NULL,
	[Active] [varchar](50)  NULL,
	[InvoiceOrderID] [int] NOT NULL,
	[ProductID] [int] NOT NULL,
	[StockID] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[BatchNo] [int] NOT NULL,
	[DiscountOnProduct] [decimal](5, 2) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Manufacturer]    Script Date: 28/09/2023 9:48:02 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Manufacturer](
	[CreatedAt] [datetime]  NULL,
	[UpdatedAt] [datetime]  NULL,
	[Active] [varchar](50)  NULL,
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PersonID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Patient]    Script Date: 28/09/2023 9:48:02 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Patient](
	[CreatedAt] [datetime]  NULL,
	[UpdatedAt] [datetime]  NULL,
	[Active] [varchar](50)  NULL,
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CNIC] [varchar](13) NOT NULL,
	[PersonID] [int] NOT NULL,
	[InvoiceID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Person]    Script Date: 28/09/2023 9:48:02 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Person](
	[CreatedAt] [datetime]  NULL,
	[UpdatedAt] [datetime]  NULL,
	[Active] [varchar](50)  NULL,
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](20) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[Address] [varchar](50) NOT NULL,
	[PhoneNo] [varchar](11) NOT NULL,
	[LoggedID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 28/09/2023 9:48:02 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[CreatedAt] [datetime]  NULL,
	[UpdatedAt] [datetime]  NULL,
	[Active] [varchar](50)  NULL,
	[ProductID] [int] IDENTITY(1,1) NOT NULL,
	[Company] [varchar](20) NOT NULL,
	[Supplier] [varchar](20) NOT NULL,
	[Name] [varchar](30) NOT NULL,
	[Type] [varchar](20) NOT NULL,
	[CostPrice] [float] NOT NULL,
	[RetailPrice] [float] NOT NULL,
	[Margin] [float] NOT NULL,
	[ConversionalUnit] [varchar](50) NOT NULL,
	[Narcotic] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Returns]    Script Date: 28/09/2023 9:48:02 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Returns](
	[CreatedAt] [datetime]  NULL,
	[UpdatedAt] [datetime]  NULL,
	[Active] [varchar](50)  NULL,
	[InvoiceID] [int] NOT NULL,
	[Amount] [varchar](50) NOT NULL,
	[Quantity] [varchar](50) NOT NULL,
	[LoggedID] [int] NOT NULL,
	[Date] [datetime] NOT NULL,
	[ProductID] [int] NOT NULL,
	[StockID] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Stock]    Script Date: 28/09/2023 9:48:02 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Stock](
	[CreatedAt] [datetime]  NULL,
	[UpdatedAt] [datetime]  NULL,
	[Active] [varchar](50)  NULL,
	[StockID] [int] IDENTITY(1,1) NOT NULL,
	[SupplierID] [int] NOT NULL,
	[Date] [datetime] NOT NULL,
	[LoggedID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[StockID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StockItems]    Script Date: 28/09/2023 9:48:02 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StockItems](
	[CreatedAt] [datetime]  NULL,
	[UpdatedAt] [datetime]  NULL,
	[Active] [varchar](50)  NULL,
	[StockID] [int] NOT NULL,
	[ProductID] [int] NOT NULL,
	[BatchNO] [int] NOT NULL,
	[ExpiredDate] [datetime] NOT NULL,
	[Quantity] [int] NOT NULL,
	[conversionableunit] [nvarchar](50) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Supplier]    Script Date: 28/09/2023 9:48:02 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Supplier](
	[CreatedAt] [datetime]  NULL,
	[UpdatedAt] [datetime]  NULL,
	[Active] [varchar](50)  NULL,
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PersonID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TotalInvoices]    Script Date: 28/09/2023 9:48:02 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TotalInvoices](
	[CreatedAt] [datetime]  NULL,
	[UpdatedAt] [datetime]  NULL,
	[Active] [varchar](50)  NULL,
	[InvoiceID] [int] NOT NULL,
	[TotalPrice] [varchar](40) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 28/09/2023 9:48:02 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
    [CreatedAt] [datetime]  NULL,
	[UpdatedAt] [datetime]  NULL,
	[Active] [varchar](50)  NULL,
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Username] [varchar](50) NOT NULL,
	[Password] [varchar](50) NOT NULL,
	[Role] [varchar](10) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Invoice_Order]  WITH CHECK ADD  CONSTRAINT [FK_Invoice_Order] FOREIGN KEY([InvoiceOrderID])
REFERENCES [dbo].[Invoice] ([InvoiceID])
GO
ALTER TABLE [dbo].[Invoice_Order] CHECK CONSTRAINT [FK_Invoice_Order]
GO
ALTER TABLE [dbo].[Invoice_Order]  WITH CHECK ADD  CONSTRAINT [FK_Invoice_StockID] FOREIGN KEY([StockID])
REFERENCES [dbo].[Stock] ([StockID])
GO
ALTER TABLE [dbo].[Invoice_Order] CHECK CONSTRAINT [FK_Invoice_StockID]
GO
ALTER TABLE [dbo].[Invoice_Order]  WITH CHECK ADD  CONSTRAINT [FK_Product_Invoice_Order] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Products] ([ProductID])
GO
ALTER TABLE [dbo].[Invoice_Order] CHECK CONSTRAINT [FK_Product_Invoice_Order]
GO
ALTER TABLE [dbo].[Manufacturer]  WITH CHECK ADD  CONSTRAINT [FK_Manufacturer] FOREIGN KEY([PersonID])
REFERENCES [dbo].[Person] ([ID])
GO
ALTER TABLE [dbo].[Manufacturer] CHECK CONSTRAINT [FK_Manufacturer]
GO
ALTER TABLE [dbo].[Patient]  WITH CHECK ADD  CONSTRAINT [FK_Patient] FOREIGN KEY([PersonID])
REFERENCES [dbo].[Person] ([ID])
GO
ALTER TABLE [dbo].[Patient] CHECK CONSTRAINT [FK_Patient]
GO

ALTER TABLE [dbo].[Returns]  WITH CHECK ADD  CONSTRAINT [FK_Return_Invoice] FOREIGN KEY([InvoiceID])
REFERENCES [dbo].[Invoice] ([InvoiceID])
GO
ALTER TABLE [dbo].[Returns] CHECK CONSTRAINT [FK_Return_Invoice]
GO
ALTER TABLE [dbo].[Returns]  WITH CHECK ADD  CONSTRAINT [FK_Return_Product] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Products] ([ProductID])
GO
ALTER TABLE [dbo].[Returns] CHECK CONSTRAINT [FK_Return_Product]
GO

ALTER TABLE [dbo].[Returns]  WITH CHECK ADD  CONSTRAINT [FK_Returns_StockID] FOREIGN KEY([StockID])
REFERENCES [dbo].[Stock] ([StockID])
GO
ALTER TABLE [dbo].[Returns] CHECK CONSTRAINT [FK_Returns_StockID]
GO
ALTER TABLE [dbo].[StockItems]  WITH CHECK ADD  CONSTRAINT [FK_stockitem] FOREIGN KEY([StockID])
REFERENCES [dbo].[Stock] ([StockID])
GO
ALTER TABLE [dbo].[StockItems] CHECK CONSTRAINT [FK_stockitem]
GO
ALTER TABLE [dbo].[Supplier]  WITH CHECK ADD  CONSTRAINT [FK_Supplierr] FOREIGN KEY([PersonID])
REFERENCES [dbo].[Person] ([ID])
GO
ALTER TABLE [dbo].[Supplier] CHECK CONSTRAINT [FK_Supplierr]
GO
ALTER TABLE [dbo].[TotalInvoices]  WITH CHECK ADD  CONSTRAINT [FK_TotalInvoices] FOREIGN KEY([InvoiceID])
REFERENCES [dbo].[Invoice] ([InvoiceID])
GO
ALTER TABLE [dbo].[TotalInvoices] CHECK CONSTRAINT [FK_TotalInvoices]
GO
/****** Object:  StoredProcedure [dbo].[InsertPerson]    Script Date: 28/09/2023 9:48:02 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertPerson]
    @Name VARCHAR(20),
    @Email VARCHAR(50),
    @Address VARCHAR(50),
    @PhoneNo VARCHAR(11),
    @LoggedID INTEGER,
    @PersonID INTEGER OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO Person (Name, Email, Address, PhoneNo, LoggedID)
    VALUES (@Name, @Email, @Address, @PhoneNo, @LoggedID);

    SET @PersonID = SCOPE_IDENTITY();
END
GO
/****** Object:  StoredProcedure [dbo].[sp_insertManufacture]    Script Date: 28/09/2023 9:48:02 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_insertManufacture]
	-- Add the parameters for the stored procedure here
	@PersonID INTEGER ,
	@ID INTEGER OUTPUT

	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	  INSERT INTO Manufacturer(PersonID)
    VALUES (@PersonID);

    SET @ID = SCOPE_IDENTITY();

END
GO




/****** Object:  Table [dbo].[Patient]    Script Date: 28/09/2023 9:48:02 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PatientAudit](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PatientId] [int] NOT NULL,
	
	[CreatedAt] [datetime]  NULL,

	[UpdatedAt] [datetime]  NULL,
	[Active] [varchar](50)  NULL,

	[CNIC] [varchar](13) NOT NULL,





	[InvoiceID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO





/****** Object:  Table [dbo].[Manufacturer]    Script Date: 28/09/2023 9:48:02 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ManufacturerAudit](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ManufactureId] [int]  NOT NULL,


	[CreatedAt] [datetime]  NULL,

	[UpdatedAt] [datetime]  NULL,
	[Active] [varchar](50)  NULL,

PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO






/****** Object:  Table [dbo].[Supplier]    Script Date: 28/09/2023 9:48:02 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SupplierAudit](
    [ID] [int] IDENTITY(1,1) NOT NULL,
	[SupplierId] [int] NOT NULL,
	[CreatedAt] [datetime]  NULL,
	[UpdatedAt] [datetime]  NULL,
	[Active] [varchar](50)  NULL,

	
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Supplier]    Script Date: 28/09/2023 9:48:02 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LOGS](
	[CreatedAt] [datetime]  NULL,
    [LogId] [int] IDENTITY(1,1) NOT NULL,
	[LogTitle] [varchar](50)  NOT NULL,
	[LogClass] [varchar](50)  NOT NULL,
	[LogFunction] [varchar](50)  NOT NULL,
	
PRIMARY KEY CLUSTERED 
(
	[LogId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO



/****** Object:  Table [dbo].[Users]    Script Date: 28/09/2023 9:48:02 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UsersAudit](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,

	[CreatedAt] [datetime]  NULL,

	[UpdatedAt] [datetime]  NULL,
	[Active] [varchar](50)  NULL,
	
	[OldUsername] [varchar](50) NOT NULL,
	[OldPassword] [varchar](50) NOT NULL,
	[OldRole] [varchar](10) NOT NULL,

	
	[NewUsername] [varchar](50) NOT NULL,
	[NewPassword] [varchar](50) NOT NULL,
	[NewRole] [varchar](10) NOT NULL,


PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Person]    Script Date: 28/09/2023 9:48:02 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PersonAudit](
	[CreatedAt] [datetime]  NULL,
	[UpdatedAt] [datetime]  NULL,
	[Active] [varchar](50)  NULL,

	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PersonId] [int] NOT NULL,

	[OldName] [varchar](20) NOT NULL,
	[OldEmail] [varchar](50) NOT NULL,
	[OldAddress] [varchar](50) NOT NULL,
	[OldPhoneNo] [varchar](11) NOT NULL,

	[NewName] [varchar](20) NOT NULL,
	[NewEmail] [varchar](50) NOT NULL,
	[NewAddress] [varchar](50) NOT NULL,
	[NewPhoneNo] [varchar](11) NOT NULL,

	[LoggedID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO





ALTER TABLE [dbo].[SupplierAudit]  WITH CHECK ADD  CONSTRAINT [FK_SupplierAuditt] FOREIGN KEY([SupplierId])
REFERENCES [dbo].[Supplier] ([ID])
GO
ALTER TABLE [dbo].[SupplierAudit] CHECK CONSTRAINT [FK_SupplierAuditt]
GO





ALTER TABLE [dbo].[ManufacturerAudit]  WITH CHECK ADD  CONSTRAINT [FK_ManufacturerAuditt] FOREIGN KEY([ManufactureId])
REFERENCES [dbo].[Manufacturer] ([ID])
GO
ALTER TABLE [dbo].[ManufacturerAudit] CHECK CONSTRAINT [FK_ManufacturerAuditt]
GO


ALTER TABLE [dbo].[PatientAudit]  WITH CHECK ADD  CONSTRAINT [FK_PatientAuditt] FOREIGN KEY([PatientId])
REFERENCES [dbo].[Patient] ([ID])
GO
ALTER TABLE [dbo].[PatientAudit] CHECK CONSTRAINT [FK_PatientAuditt]
GO


ALTER TABLE [dbo].[UsersAudit]  WITH CHECK ADD  CONSTRAINT [FK_UsersAuditt] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([ID])
GO
ALTER TABLE [dbo].[UsersAudit] CHECK CONSTRAINT [FK_UsersAuditt]
GO

ALTER TABLE [dbo].[PersonAudit]  WITH CHECK ADD  CONSTRAINT [FK_PersonAuditt] FOREIGN KEY([PersonId])
REFERENCES [dbo].[Person] ([ID])
GO
ALTER TABLE [dbo].[PersonAudit] CHECK CONSTRAINT [FK_PersonAuditt]
GO