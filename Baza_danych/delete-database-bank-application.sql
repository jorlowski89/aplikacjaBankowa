/*
Kwerendy do USUWANIA BAZY!
Ustaw bazê w tryb single-user
Usuñ bazê danych
*/

USE master;
GO
ALTER DATABASE BankApplication SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
GO
DROP DATABASE BankApplication;
GO
