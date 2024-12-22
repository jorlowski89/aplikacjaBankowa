-- USUWANIE BAZY
USE master;
GO
-- Ustaw baz� w tryb single-user
ALTER DATABASE BankApplication SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
GO
-- Usu� baz� danych
DROP DATABASE BankApplication;
GO


CREATE DATABASE BankApplication;
GO

USE BankApplication;
GO

CREATE TABLE Users (
    UserID UNIQUEIDENTIFIER DEFAULT NEWID() PRIMARY KEY,					-- Automatyczny UUID
    Username NVARCHAR(50) NOT NULL UNIQUE,									-- Unikalna nazwa u�ytkownika
    PasswordHash VARBINARY(256) NOT NULL,									-- Hash has�a
	IsActive BIT DEFAULT 0 NOT NULL,										-- Czy konto jest aktywne (0 = nieaktywne, 1 = aktywne)
    CreatedAt DATETIME DEFAULT GETUTCDATE() NOT NULL						-- Data i czas utworzenia rekordu
);
GO

INSERT INTO Users (Username, PasswordHash, IsActive)
VALUES (
    'admin',
    HASHBYTES('SHA2_256', 'admin'),											-- Hashowanie has�a
	1
);
GO
INSERT INTO Users (Username, PasswordHash)
VALUES (
    'user1',
    HASHBYTES('SHA2_256', 'user1')											-- Hashowanie has�a
);
GO
INSERT INTO Users (Username, PasswordHash, IsActive)
VALUES (
    'user2',
    HASHBYTES('SHA2_256', 'user2'),											-- Hashowanie has�a
	1
);
GO
INSERT INTO Users (Username, PasswordHash, IsActive)
VALUES (
    'user3',
    HASHBYTES('SHA2_256', 'user2'),											-- Hashowanie has�a
	1
);
GO

CREATE TABLE Accounts (
    AccountID UNIQUEIDENTIFIER DEFAULT NEWID() PRIMARY KEY,					-- Automatyczny UUID
    AccountName NVARCHAR(100) NOT NULL,										-- Nazwa konta
    AccountType NVARCHAR(50) NOT NULL,										-- Typ konta (np. oszcz�dno�ciowe, bie��ce)
    AccountNumber NVARCHAR(20) NOT NULL UNIQUE,								-- Unikalny numer konta
    UserID UNIQUEIDENTIFIER NOT NULL,										-- Powi�zanie z u�ytkownikiem (klucz obcy)
    AccountBalance BIGINT DEFAULT 0 NOT NULL, 								-- Saldo konta
    Currency NVARCHAR(3) NOT NULL,											-- Waluta konta (np. PLN, USD)
    FOREIGN KEY (UserID) REFERENCES Users(UserID)							-- Klucz obcy do tabeli Users
);
GO

CREATE TABLE TransferTypes (
    TransferTypeID UNIQUEIDENTIFIER DEFAULT NEWID() PRIMARY KEY,			-- Automatyczny UUID
    TransferType NVARCHAR(50) NOT NULL UNIQUE								-- Typ transferu (np. Wp�ata_got�wki, Wyp�ata_got�wki, Przelew_krajowy)
);
GO

INSERT INTO TransferTypes (TransferType)
VALUES 
    ('Wp�ata_got�wki'),
    ('Wyp�ata_got�wki'),
    ('Przelew_krajowy');
GO

CREATE TABLE Transfers (
    TransferID UNIQUEIDENTIFIER DEFAULT NEWID() PRIMARY KEY,				-- Automatyczny UUID
    Amount BIGINT NOT NULL,													-- Kwota transferu
    TransferTitle NVARCHAR(255) NOT NULL,									-- Tytu� przelewu
    SenderAccountID UNIQUEIDENTIFIER NOT NULL,								-- UUID konta nadawcy
    RecipientAccountID UNIQUEIDENTIFIER NOT NULL,							-- UUID konta odbiorcy
    SendingDate DATETIME DEFAULT GETUTCDATE() NULL,							-- Data wys�ania transferu
    PostingDate DATETIME NULL,												-- Data ksi�gowania transferu
    TransferTypeID UNIQUEIDENTIFIER NOT NULL,								-- Typ transferu (klucz obcy)
    FOREIGN KEY (SenderAccountID) REFERENCES Accounts(AccountID),			-- Klucz obcy do konta nadawcy
    FOREIGN KEY (RecipientAccountID) REFERENCES Accounts(AccountID),		-- Klucz obcy do konta odbiorcy
    FOREIGN KEY (TransferTypeID) REFERENCES TransferTypes(TransferTypeID)	-- Klucz obcy do typ�w transfer�w
);
GO


