using LibraryManagement.Storage.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Storage.Repository
{
    public interface ILibraryRepository
    {
        // Client Management
        List<Client> GetClients();
        Client GetClientById(int clientId);
        void AddClient(Client client);
        void DeleteClient(int clientId);
        void UpdateClient(Client client); // Dodanie metody aktualizacji

        // Book Management
        List<Book> GetBooks();
        Book GetBookById(int bookId);
        void AddBook(Book book);
        void DeleteBook(int bookId);
        void UpdateBook(Book book); // Dodanie metody aktualizacji

        // Loan Management
        List<Loan> GetLoansByClientId(int clientId);
        List<Loan> GetAllLoans();

        Loan GetLoanById(int loanId);
        void AddLoan(Loan loan);
        void DeleteLoan(int loanId);
        void ReturnLoan(int loanId);
    }
}
