using LibraryManagement.Storage.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Service.Command.Loan.Delete
{
    public class DeleteLoanCommandHandler : ICommandHandler<DeleteLoanCommand>
    {
        private readonly ILibraryRepository _repository;

        public DeleteLoanCommandHandler(ILibraryRepository repository)
        {
            _repository = repository;
        }

        public Result Handle(DeleteLoanCommand command)
        {
            var loan = _repository.GetLoanById(command.LoanId);
            if (loan == null)
            {
                return Result.Fail("Nie znaleziono wypożyczenia.");
            }

            _repository.DeleteLoan(command.LoanId);
            return Result.Ok();
        }
    }
}
