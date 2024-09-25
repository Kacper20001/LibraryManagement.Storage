using LibraryManagement.Storage.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagement.Storage.Entities;

namespace LibraryManagement.Service.Command.Loan
{
    public class LoanBookCommandHandler : ICommandHandler<LoanBookCommand>
    {
        private readonly ILibraryRepository _repository;

        public LoanBookCommandHandler(ILibraryRepository repository)
        {
            _repository = repository;
        }

        public Result Handle(LoanBookCommand command)
        {
            var validationResult = new LoanBookCommandValidator().Validate(command);
            if (!validationResult.IsValid)
            {
                return Result.Fail(validationResult);
            }

            var client = _repository.GetClientById(command.ClientId);  
            var book = _repository.GetBookById(command.BookId);  
            if (client == null || book == null)
            {
                return Result.Fail("Klient lub książka nie istnieje.");
            }

            if (book.IsLoaned)
            {
                return Result.Fail("Książka jest już wypożyczona.");
            }

            
            var returnDate = DateTime.UtcNow.AddDays(30);

       
            var loan = new Storage.Entities.Loan(client.Id, client, book.Id, book, DateTime.UtcNow, returnDate);

            _repository.AddLoan(loan);

            return Result.Ok();
        }


    }
}
