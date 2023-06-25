# Lista zakupów
## Opis
Lista zakupów to prosty program konsolowy napisany w języku C#, który umożliwia użytkownikowi tworzenie i zarządzanie listą zakupów. Program wykorzystuje framework SQLite do obsługi bazy danych SQL, umożliwiając automatyczny zapis i odczyt danych z bazy.

## Wymagania systemowe
 - .NET Core 6.0 lub nowszy
 - SQLite

## Instrukcje instalacji
 - Sklonuj repozytorium lub pobierz pliki programu jako archiwum ZIP.
 - Otwórz projekt w środowisku programistycznym obsługującym język C#, takim jak Visual Studio.
 - Zainstaluj System Data SQLite, jeśli jeszcze go nie masz zainstalowanego. Możesz zainstalować go za pomocą menedżera pakietów NuGet lub CLI.
 - Skonfiguruj połączenie do swojej bazy danych SQL w pliku konfiguracyjnym programu.
 - Skompiluj projekt, aby wygenerować plik wykonywalny.
 - Uruchom program konsolowy "ListaZakupow.exe".

## Instrukcje użytkowania
Po uruchomieniu programu, zostaniesz przywitany i zaproszony do wprowadzania poleceń.
Dostępne polecenia to:
 - "dodaj [przedmiot]" - dodaje [przedmiot] do listy zakupów.
 - "usuń [przedmiot]" - usuwa [przedmiot] z listy zakupów.
 - "wyświetl" - wyświetla wszystkie przedmioty na liście zakupów.
 - "wyjście" - kończy program.
Każda zmiana w liście zakupów jest automatycznie zapisywana w bazie danych.
Po zakończeniu programu i ponownym uruchomieniu, dane zostaną wczytane z bazy danych.

## Możliwości rozbudowy
Program "Lista zakupów" oferuje wiele możliwości rozbudowy, takich jak:

 - Obsługa wielu list zakupów: Program może umożliwić użytkownikowi tworzenie i zarządzanie wieloma listami zakupów, przechowując je w osobnych tabelach bazy danych.
 - Rozbudowane filtrowanie i sortowanie: Program może obsługiwać bardziej zaawansowane filtrowanie i sortowanie przedmiotów na liście, umożliwiając użytkownikowi szybkie wyszukiwanie i sortowanie według różnych kryteriów.
 - Ulepszone zarządzanie użytkownikami: Program może wprowadzić system rejestracji i logowania użytkowników, umożliwiając przechowywanie list zakupów dla różnych użytkowników.

## Dodane funkcjonalości
 - Dodawanie informacji o ilości i cenie: Program może rozszerzyć strukturę danych przedmiotu na liście zakupów, aby przechowywać informacje o ilości i cenie, co umożliwi obliczanie sumy zakupów.


## Autor
Ten program został stworzony przez Kamila Sulkowskiego.

## Licencja
Ten program jest udostępniany na licencji MIT. Szczegółowe informacje znajdują się w pliku [LICENSE].