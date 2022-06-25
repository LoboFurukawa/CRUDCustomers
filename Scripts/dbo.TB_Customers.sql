CREATE TABLE [dbo].[TB_Customers] (
    [Id]               INT          NOT NULL IDENTITY,
    [CPF]              VARCHAR (11) NOT NULL,
    [Name]             VARCHAR (50) NOT NULL,
    [RG]               VARCHAR (10) NULL,
    [ShippingDate]     DATE         NULL,
    [IdDispatchAgency] INT          NULL,
    [IdUF]             INT          NULL,
    [BirthDate]        DATE         NOT NULL,
    [Gender]           VARCHAR (2)  NOT NULL,
    [IdMaritalStatus]  INT          NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_TB_Customers_TB_UFs] FOREIGN KEY ([IdUF]) REFERENCES [dbo].[TB_UFs] ([Id]),
    CONSTRAINT [FK_TB_Customers_TB_MaritalStatus] FOREIGN KEY ([IdMaritalStatus]) REFERENCES [dbo].[TB_MaritalStatus] ([Id]),
    CONSTRAINT [FK_TB_Customers_TB_DispatchAgency] FOREIGN KEY ([IdDispatchAgency]) REFERENCES [dbo].[TB_DispatchAgency] ([Id])
);

