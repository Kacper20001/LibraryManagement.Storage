# 📚 LibraryManagement – ASP.NET Core MVC

**LibraryManagement** to aplikacja webowa do zarządzania biblioteką, stworzona w technologii ASP.NET Core MVC z wykorzystaniem wzorców projektowych oraz Entity Framework. System pozwala na pełne zarządzanie klientami, książkami i wypożyczeniami w środowisku biblioteki. Projekt powstał w ramach przedmiotu *Szkolenie Techniczne 2*.

## 🔧 Funkcje aplikacji

- Dodawanie, edytowanie i usuwanie książek
- Zarządzanie klientami (CRUD)
- Obsługa wypożyczeń i zwrotów książek
- Przypisywanie wypożyczeń do klientów
- Wyszukiwanie i filtrowanie danych
- Wyraźny podział warstw (CQRS, Repository, EF)
- Przejrzysty interfejs użytkownika oparty na ASP.NET MVC
- Testy funkcjonalne (opisane w Gherkinie)

## 🧱 Technologie

- C# / .NET 8
- ASP.NET Core MVC
- Entity Framework Core
- SQL Server
- FluentValidation
- Visual Studio
- Git

## 💻 Wymagania

- Windows 7 lub nowszy
- Visual Studio
- .NET 8.0
- SQL Server + SSMS
- Min. 2 GB RAM, 100 MB wolnego miejsca

## ▶️ Jak odpalić

1. Sklonuj repozytorium:  
   `git clone https://github.com/Kacper20001/LibraryManagement.Storage.git`
2. Otwórz projekt w Visual Studio
3. Skonfiguruj connection string w `LibraryDbContext.cs`
4. Wykonaj migracje EF Core (np. `Update-Database`)
5. Uruchom aplikację (np. IIS Express)

## 🧠 Autor

**Kacper Kulig**  
Numer albumu: w69199  
Projekt zrealizowany w ramach zajęć **Szkolenie Techniczne 2**

---
