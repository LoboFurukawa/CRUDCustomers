CREATE TABLE [dbo].[TB_Customers]
(
	[Id]               INT NOT NULL PRIMARY KEY, 
    [CPF]              VARCHAR(11) NOT NULL, 
    [Name]             VARCHAR(50) NOT NULL, 
    [RG]               VARCHAR(10) NULL, 
    [ShippingDate]     DATE NULL, 
    [IdDispatchAgency] INT NULL, 
    [IdUF]             INT NULL, 
    [BirthDate]        DATE NOT NULL, 
    [Gender]           VARCHAR(2) NOT NULL, 
    [IdMaritalStatus]  INT NOT NULL, 
    CONSTRAINT [FK_TB_Customers_TB_UFs] FOREIGN KEY ([IdUF]) REFERENCES [TB_UFs]([Id]),
    CONSTRAINT [FK_TB_Customers_TB_MaritalStatus] FOREIGN KEY ([IdMaritalStatus]) REFERENCES [TB_MaritalStatus]([Id]),
    CONSTRAINT [FK_TB_Customers_TB_DispatchAgency] FOREIGN KEY ([IdDispatchAgency]) REFERENCES [TB_DispatchAgency]([Id])
)
