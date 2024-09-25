using LibraryManagement.Storage.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace LibraryManagement.Storage.Repository
{
    public class LibraryRepository : ILibraryRepository
    {
        private readonly LibraryDbContext _context;

        public LibraryRepository(LibraryDbContext context)
        {
            _context = context;
        }

        // Client Management
        public List<Client> GetClients() => _context.Clients.ToList();
        public Client GetClientById(int clientId) => _context.Clients.Include(c => c.Loans).SingleOrDefault(c => c.Id == clientId);
        public void AddClient(Client client) { _context.Clients.Add(client); _context.SaveChanges(); }
        public void DeleteClient(int clientId) { var client = _context.Clients.Find(clientId); if (client != null) { _context.Clients.Remove(client); _context.SaveChanges(); } }
        public void UpdateClient(Client client) { _context.Clients.Update(client); _context.SaveChanges(); }

        // Book Management
        public List<Book> GetBooks() => _context.Books.ToList();
        public Book GetBookById(int bookId) => _context.Books.Find(bookId);
        public void AddBook(Book book) { _context.Books.Add(book); _context.SaveChanges(); }
        public void DeleteBook(int bookId) { var book = _context.Books.Find(bookId); if (book != null) { _context.Books.Remove(book); _context.SaveChanges(); } }
        public void UpdateBook(Book book) { _context.Books.Update(book); _context.SaveChanges(); }

        // Loan Management
        public List<Loan> GetLoansByClientId(int clientId)
        {
            // Włącz Include, aby załadować powiązane obiekty książek i klientów
            return _context.Loans
                           .Include(l => l.Book)   // Załaduj książki
                           .Include(l => l.Client) // Załaduj klientów
                           .Where(l => l.ClientId == clientId)
                           .ToList();
        }
        public Loan GetLoanById(int loanId) => _context.Loans.Find(loanId);
        public void ReturnLoan(int loanId) { var loan = _context.Loans.Find(loanId); if (loan != null) { loan.ReturnDate = DateTime.UtcNow; _context.SaveChanges(); } }
        public void DeleteLoan(int loanId)
        {
            var loan = _context.Loans.Include(l => l.Book).FirstOrDefault(l => l.Id == loanId);

            if (loan != null)
            {
                // Ustaw książkę jako dostępną do wypożyczenia
                loan.Book.IsLoaned = false;

                // Usuń wypożyczenie
                _context.Loans.Remove(loan);

                // Zapisz zmiany w bazie
                _context.SaveChanges();
            }
        }
        public void AddLoan(Loan loan)
        {
            var book = _context.Books.Find(loan.BookId);
            var client = _context.Clients.Find(loan.ClientId);  // Pobieramy klienta z bazy

            if (book != null && client != null && !book.IsLoaned)
            {
                loan.Client = client;  // Przypisujemy klienta do wypożyczenia
                loan.Book = book;  // Przypisujemy książkę do wypożyczenia
                _context.Loans.Add(loan);
                book.IsLoaned = true;  // Oznaczamy książkę jako wypożyczoną
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Książka już jest wypożyczona, klient lub książka nie istnieje.");
            }
        }
        public List<Loan> GetAllLoans()
        {
            return _context.Loans.Include(l => l.Book).Include(l => l.Client).ToList(); // Pobieramy wszystkie wypożyczenia, łącznie z powiązanymi książkami i klientami
        }

    }
}

