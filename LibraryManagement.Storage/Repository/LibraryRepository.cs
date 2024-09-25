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

        public List<Client> GetClients() => _context.Clients.ToList();
        public Client GetClientById(int clientId) => _context.Clients.Include(c => c.Loans).SingleOrDefault(c => c.Id == clientId);
        public void AddClient(Client client) { _context.Clients.Add(client); _context.SaveChanges(); }
        public void DeleteClient(int clientId) { var client = _context.Clients.Find(clientId); if (client != null) { _context.Clients.Remove(client); _context.SaveChanges(); } }
        public void UpdateClient(Client client) { _context.Clients.Update(client); _context.SaveChanges(); }
        public List<Book> GetBooks() => _context.Books.ToList();
        public Book GetBookById(int bookId) => _context.Books.Find(bookId);
        public void AddBook(Book book) { _context.Books.Add(book); _context.SaveChanges(); }
        public void DeleteBook(int bookId) { var book = _context.Books.Find(bookId); if (book != null) { _context.Books.Remove(book); _context.SaveChanges(); } }
        public void UpdateBook(Book book) { _context.Books.Update(book); _context.SaveChanges(); }
        public List<Loan> GetLoansByClientId(int clientId)
        {
            return _context.Loans
                           .Include(l => l.Book)   
                           .Include(l => l.Client)
                           .Where(l => l.ClientId == clientId)
                           .ToList();  }
        public Loan GetLoanById(int loanId) => _context.Loans.Find(loanId);
        public void ReturnLoan(int loanId) { var loan = _context.Loans.Find(loanId); if (loan != null) { loan.ReturnDate = DateTime.UtcNow; _context.SaveChanges(); } }
        public void DeleteLoan(int loanId)
        {
            var loan = _context.Loans.Include(l => l.Book).FirstOrDefault(l => l.Id == loanId);

            if (loan != null)
            {
                loan.Book.IsLoaned = false;

                _context.Loans.Remove(loan);
                _context.SaveChanges();
            }
        }
        public void AddLoan(Loan loan)
        {
            var book = _context.Books.Find(loan.BookId);
            var client = _context.Clients.Find(loan.ClientId);  
            if (book != null && client != null && !book.IsLoaned)
            {
                loan.Client = client;
                loan.Book = book; 
                _context.Loans.Add(loan);
                book.IsLoaned = true; 
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Książka już jest wypożyczona, klient lub książka nie istnieje.");
            }
        }
        public List<Loan> GetAllLoans()
        {
            return _context.Loans.Include(l => l.Book).Include(l => l.Client).ToList();
        }

    }
}

