using LibraryManagement.Storage.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Service.Command.Book.Update
{
    public class UpdateBookCommandHandler : ICommandHandler<UpdateBookCommand>
    {
        private readonly ILibraryRepository _repository;

        public UpdateBookCommandHandler(ILibraryRepository repository)
        {
            _repository = repository;
        }

        public Result Handle(UpdateBookCommand command)
        {
            var book = _repository.GetBookById(command.BookId);
            if (book == null)
            {
                return Result.Fail("Book not found.");
            }

            var validationResult = new UpdateBookCommandValidator().Validate(command);
            if (!validationResult.IsValid)
            {
                return Result.Fail(validationResult);
            }

            book.Title = command.Title;
            book.Author = command.Author;
            book.Genre = command.Genre;
            book.Year = command.Year;

            _repository.UpdateBook(book);

            return Result.Ok();
        }
    }
}
