# Aplikacja Bankowa

- Widoki - Jakub
- BE - Mateusz
- Baza - Albert

## Funkcjonalności:
- Logowanie (użytkownik, hasło)
- Zakładanie nowego użytkownika
- Przelew zwykły
- Walidacja przelewów powyżej 15 tys Euro
- Historia przelewów
- Wpłata/wypłata z bankomatu

## Baza (Tabele):
- 'users': uuid, login, password, user_type(admin/user), is_active, create_date
- 'accounts': uuid, account_name, account_type, account_number, user_uuid, account_balance, currency
- 'transfers': uuid, amount, transfer_title, sender_account_uuid, recipient_account_uuid, sending_date, posting_date, transfer_type
- 'transfer_types': uuid, transfer_type (Wpłata_gotówki, wypłata_gotówki, przelewy_krajowy)

## Widoki użytkownika:
- okno logowania
- rejestracja
- strona domowa (po zalogowaniu): przywitanie, saldo, ostatnie przelewy, wykonaj przelew, otwórz historię
- historia
- przelewy
- bankomat

## Widoki admina:
- okno logowania
- strona domowa: walidacja przelewów, użytkownicy
- lista użytkowników (widok admina)
- lista przelewów do zatwierdzenia
- walidacja nowych użytkowników

## Technologie:
- C#
- SQL Server
- WinForms

## Setup Database

- Instalacja sqlexpress 2022 [download](https://www.microsoft.com/en-us/sql-server/sql-server-downloads?msockid=2099d0b1a47466a23918c5f7a55667d1)
- Zainstaluj SSMS [download](https://learn.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-ver16)
- Uruchom SSMS i połącz z serwerem SQL `.\SQLEXPRESS`
- Otwórz i uruchom kwerendy z pliku setup-database-bank-application.sql w SSMS
- aktualizacja bazy uruchom kwerendy z pliku delete-database-bank-application.sql w SSMS
- ponownie uruchom kwerendy z pliku setup-database-bank-application.sql w SSMS
