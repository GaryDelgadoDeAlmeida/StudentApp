CREATE TABLE [dbo].[Student] (
    [Id]          INT          NOT NULL IDENTITY,
    [firstName]   VARCHAR (50) NULL,
    [lastName]    VARCHAR (50) NULL,
    [phoneNumber] VARCHAR (50) NULL,
    [address]     VARCHAR (50) NULL,
    [postalCode]  VARCHAR (5)  NULL,
    [city]        VARCHAR (50) NULL,
    [country]     VARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

