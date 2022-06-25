CREATE TABLE [dbo].[TB_Address] (
    [Id]           INT          IDENTITY (1, 1) NOT NULL,
    [PostalCode]   VARCHAR (15)  NOT NULL,
    [Street]       VARCHAR (50) NOT NULL,
    [Number]       INT          NOT NULL,
    [Complement]   VARCHAR (50) NULL,
    [Neighborhood] VARCHAR (50) NOT NULL,
    [City]         VARCHAR (50) NOT NULL,
    [IdUf]         INT          NOT NULL,
    [IdCustomer]   INT          NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_TB_Address_TB_UFs] FOREIGN KEY ([IdUf]) REFERENCES [dbo].[TB_UFs] ([Id]),
    CONSTRAINT [FK_TB_Address_TB_Customers] FOREIGN KEY ([IdCustomer]) REFERENCES [dbo].[TB_Customers] ([Id])
);

