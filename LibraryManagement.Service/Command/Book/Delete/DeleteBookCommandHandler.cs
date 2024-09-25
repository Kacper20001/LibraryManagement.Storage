using LibraryManagement.Storage.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Service.Command.Book.Delete
{
    public class DeleteBookCommandHandler : ICommandHandler<DeleteBookCommand>
    {
        private readonly ILibraryRepository _repository;

        public DeleteBookCommandHandler(ILibraryRepository repository)
        {
            _repository = repository;
        }

        public Result Handle(DeleteBookCommand command)
        {
            var book = _repository.GetBookById(command.BookId);
            if (book == null)
            {
                return Result.Fail("Book not found.");
            }

            _repository.DeleteBook(command.BookId);
            return Result.Ok();
        }
    }
}
