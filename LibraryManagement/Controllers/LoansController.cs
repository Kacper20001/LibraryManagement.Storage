using LibraryManagement.Service.Command.Loan;
using LibraryManagement.Service.Command.Loan.Delete;
using LibraryManagement.Service.Query.Book;
using LibraryManagement.Service.Query.Client;
using LibraryManagement.Service.Query.Dtos;
using LibraryManagement.Service.Query.Loan;
using LibraryManagement.Storage.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace LibraryManagement.Controllers
{
    public class LoansController : Controller
    {
        private readonly ILibraryRepository _libraryRepository;

        public LoansController(ILibraryRepository repository)
        {
            _libraryRepository = repository;
        }

        public IActionResult Index()
        {
            var handler = new GetAllLoansQueryHandler(_libraryRepository);
            var query = new GetAllLoansQuery();
            var loans = handler.Handle(query);
            return View(loans);  // Wyświetlamy wszystkie wypożyczenia w widoku
        }

        public IActionResult Add()
        {
            // Pobierz klientów i książki, które nie są wypożyczone
            var clients = _libraryRepository.GetClients()
                              .Select(c => new ClientDto(c.Id, c.Name, c.Surname, c.Email))
                              .ToList();
            var books = _libraryRepository.GetBooks()
                              .Where(b => !b.IsLoaned) // Tylko książki, które są dostępne
                              .Select(b => new BookDto(b.Id, b.Title, b.Author, b.Genre, b.Year))
                              .ToList();

            var command = new LoanBookCommand
            {
                Clients = clients,
                Books = books
            };

            return View(command);
        }

        [HttpPost]
        public IActionResult Add(LoanBookCommand command)
        {
            var handler = new LoanBookCommandHandler(_libraryRepository);
            var result = handler.Handle(command);

            if (result.IsFailure)
            {
                var clients = _libraryRepository.GetClients()
                                  .Select(c => new ClientDto(c.Id, c.Name, c.Surname, c.Email))
                                  .ToList();
                var books = _libraryRepository.GetBooks()
                                  .Where(b => !b.IsLoaned)
                                  .Select(b => new BookDto(b.Id, b.Title, b.Author, b.Genre, b.Year))
                                  .ToList();

                command.Clients = clients;
                command.Books = books;
                return View(command);
            }

            return RedirectToAction("Index", new { clientId = command.ClientId });
        }
        [HttpPost]
        public IActionResult Delete(int loanId)
        {
            _libraryRepository.DeleteLoan(loanId);
            return RedirectToAction("Index");
        }



    }
}
