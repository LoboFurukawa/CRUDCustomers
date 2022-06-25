CREATE TABLE [dbo].[TB_Address] (
    [Id]           INT          NOT NULL IDENTITY,
    [PostalCode]   VARCHAR (7)  NOT NULL,
    [Street]       VARCHAR (50) NOT NULL,
    [Number]       INT          NOT NULL,
    [Complement]   VARCHAR (50) NULL,
    [Neighborhood] VARCHAR (50) NOT NULL,
    [City]         VARCHAR (50) NOT NULL,
    [IdUf]         INT          NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_TB_Address_TB_UFs] FOREIGN KEY ([IdUf]) REFERENCES [dbo].[TB_UFs] ([Id])
);

