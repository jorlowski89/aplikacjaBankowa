/*
Kwerendy do USUWANIA BAZY!
Ustaw baz� w tryb single-user
Usu� baz� danych
*/

USE master;
GO
ALTER DATABASE BankApplication SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
GO
DROP DATABASE BankApplication;
GO
