using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagement.Storage.Entities;
using LibraryManagement.Storage.Repository;

namespace LibraryManagement.Service.Command.Book.Add
{
    public class AddBookCommandHandler : ICommandHandler<AddBookCommand>
    {
        private readonly ILibraryRepository _repository;

        public AddBookCommandHandler(ILibraryRepository repository)
        {
            _repository = repository;
        }

        public Result Handle(AddBookCommand command)
        {
            var validationResult = new AddBookCommandValidator().Validate(command);
            if (!validationResult.IsValid)
            {
                return Result.Fail(validationResult);
            }

            var book = new Storage.Entities.Book(command.Title, command.Author, command.Genre, command.Year);
            _repository.AddBook(book);

            return Result.Ok();
        }
    }
}
