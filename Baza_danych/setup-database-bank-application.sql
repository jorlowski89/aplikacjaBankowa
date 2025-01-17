/*
Kwerendy do TWORZENIA BAZY!
*/

CREATE DATABASE BankApplication;
GO

USE BankApplication;
GO

CREATE TABLE Users (
    UserID UNIQUEIDENTIFIER DEFAULT NEWID() PRIMARY KEY,					-- Automatyczny UUID
    Username NVARCHAR(50) NOT NULL UNIQUE,									-- Unikalna nazwa u¿ytkownika
    PasswordHash VARBINARY(256) NOT NULL,									-- Hash has³a
	IsActive BIT DEFAULT 0 NOT NULL,										-- Czy konto jest aktywne (0 = nieaktywne, 1 = aktywne)
    CreatedAt DATETIME DEFAULT GETUTCDATE() NOT NULL						-- Data i czas utworzenia rekordu
);
GO

CREATE TABLE LoggedInUsers (
    Username       NVARCHAR(50) NOT NULL UNIQUE,							-- Nazwa u¿ytkownika
    IsLoggedIn     BIT NOT NULL DEFAULT 0,									-- Czy zalogowany (0 = nie, 1 = tak)
    LoggedAt       DATETIME NOT NULL DEFAULT GETUTCDATE(),					-- Data/czas ostatniej zmiany stanu
    CONSTRAINT FK_LoggedInUsers_Users
        FOREIGN KEY (Username) REFERENCES Users(Username)					-- Powi¹zanie z tabel¹ Users po nazwie
);
GO

INSERT INTO Users (Username, PasswordHash, IsActive)
VALUES (
    'admin',
    HASHBYTES('SHA2_256', 'admin'),											-- Hashowanie has³a
	1
);
GO
INSERT INTO Users (Username, PasswordHash)
VALUES (
    'user1',
    HASHBYTES('SHA2_256', 'user1')											-- Hashowanie has³a
);
GO
INSERT INTO Users (Username, PasswordHash, IsActive)
VALUES (
    'user2',
    HASHBYTES('SHA2_256', 'user2'),											-- Hashowanie has³a
	1
);
GO
INSERT INTO Users (Username, PasswordHash, IsActive)
VALUES (
    'user3',
    HASHBYTES('SHA2_256', 'user2'),											-- Hashowanie has³a
	1
);
GO

CREATE TABLE Accounts (
    AccountID UNIQUEIDENTIFIER DEFAULT NEWID() PRIMARY KEY,					-- Automatyczny UUID
    AccountName NVARCHAR(100) NOT NULL,										-- Nazwa konta
    AccountType NVARCHAR(50) NOT NULL,										-- Typ konta (np. oszczêdnoœciowe, bie¿¹ce)
    AccountNumber INT NOT NULL UNIQUE,								-- Unikalny numer konta
    UserID UNIQUEIDENTIFIER NOT NULL,										-- Powi¹zanie z u¿ytkownikiem (klucz obcy)
    AccountBalance REAL DEFAULT 0 NOT NULL, 								-- Saldo konta
    Currency NVARCHAR(3) DEFAULT 'PLN' NOT NULL,											-- Waluta konta (np. PLN, USD)
    FOREIGN KEY (UserID) REFERENCES Users(UserID)							-- Klucz obcy do tabeli Users
);
GO

INSERT INTO Accounts (
AccountName,
AccountType,
AccountNumber,
UserID,
AccountBalance
)
VALUES (
    'Direct admin',
    'normal',											
	9999,
	(SELECT UserID FROM Users WHERE Username = 'admin'),  --admin
	999999
);
GO
INSERT INTO Accounts (
AccountName,
AccountType,
AccountNumber,
UserID,
AccountBalance
)
VALUES (
    'Direct user1',
    'normal',											
	1111,
	(SELECT UserID FROM Users WHERE Username = 'user1'), -- user1
	0
);
GO

INSERT INTO Accounts (
AccountName,
AccountType,
AccountNumber,
UserID,
AccountBalance
)
VALUES (
    'Direct user2',
    'normal',									
	2222,
	(SELECT UserID FROM Users WHERE Username = 'user2'), -- user2
	0
);
GO
INSERT INTO Accounts (
AccountName,
AccountType,
AccountNumber,
UserID,
AccountBalance
)
VALUES (
    'Direct user3',
    'normal',											
	'3333',
	(SELECT UserID FROM Users WHERE Username = 'user3'), -- user3
	0
);
GO

CREATE TABLE TransferTypes (
    TransferTypeID UNIQUEIDENTIFIER DEFAULT NEWID() PRIMARY KEY,			-- Automatyczny UUID
    TransferType NVARCHAR(50) NOT NULL UNIQUE								-- Typ transferu (np. Wp³ata_gotówki, Wyp³ata_gotówki, Przelew_krajowy)
);
GO

INSERT INTO TransferTypes (TransferType)
VALUES 
    ('Wp³ata_gotówki'),
    ('Wyp³ata_gotówki'),
    ('Przelew_krajowy');
GO

CREATE TABLE Transfers (
    TransferID UNIQUEIDENTIFIER DEFAULT NEWID() PRIMARY KEY,				-- Automatyczny UUID
    Amount REAL NOT NULL,													-- Kwota transferu
    TransferTitle NVARCHAR(255) NOT NULL,									-- Tytu³ przelewu
    SenderAccountID UNIQUEIDENTIFIER NULL,								-- UUID konta nadawcy
    RecipientAccountID UNIQUEIDENTIFIER NULL,							-- UUID konta odbiorcy
    SendingDate DATETIME DEFAULT GETUTCDATE() NULL,							-- Data wys³ania transferu
    PostingDate DATETIME NULL,												-- Data ksiêgowania transferu
    TransferTypeID UNIQUEIDENTIFIER NOT NULL,								-- Typ transferu (klucz obcy)
    FOREIGN KEY (SenderAccountID) REFERENCES Accounts(AccountID),			-- Klucz obcy do konta nadawcy
    FOREIGN KEY (RecipientAccountID) REFERENCES Accounts(AccountID),		-- Klucz obcy do konta odbiorcy
    FOREIGN KEY (TransferTypeID) REFERENCES TransferTypes(TransferTypeID)	-- Klucz obcy do typów transferów
);
GO


