using LibraryManagement.Service.Command.Book.Add;
using LibraryManagement.Service.Command.Book.Delete;
using LibraryManagement.Service.Command.Book.Update;
using LibraryManagement.Service.Query.Book;
using LibraryManagement.Storage.Repository;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.Controllers
{
    public class BooksController : Controller
    {
        private readonly ILibraryRepository _libraryRepository;

        public BooksController(ILibraryRepository repository)
        {
            _libraryRepository = repository;
        }

        public IActionResult Index()
        {
            var handler = new GetAllBooksQueryHandler(_libraryRepository);
            var query = new GetAllBooksQuery();
            var books = handler.Handle(query);
            return View(books);
        }

        public IActionResult Add()
        {
            return View(new AddBookCommand());
        }

        [HttpPost]
        public IActionResult Add(AddBookCommand command)
        {
            var handler = new AddBookCommandHandler(_libraryRepository);
            var result = handler.Handle(command);

            if (result.IsFailure)
            {
                return View(command);
            }

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var book = _libraryRepository.GetBookById(id);
            if (book == null)
            {
                return NotFound();
            }

            var command = new UpdateBookCommand
            {
                BookId = book.Id,
                Title = book.Title,
                Author = book.Author,
                Genre = book.Genre,
                Year = book.Year
            };

            return View(command);
        }

        [HttpPost]
        public IActionResult Edit(UpdateBookCommand command)
        {
            var handler = new UpdateBookCommandHandler(_libraryRepository);
            var result = handler.Handle(command);

            if (result.IsFailure)
            {
                return View(command);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(DeleteBookCommand command)
        {
            var handler = new DeleteBookCommandHandler(_libraryRepository);
            var result = handler.Handle(command);

            return RedirectToAction("Index");
        }
    }
}
