using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Service.Command.Loan
{
    public class LoanBookCommandValidator : AbstractValidator<LoanBookCommand>
    {
        public LoanBookCommandValidator()
        {
            RuleFor(x => x.ClientId).NotEmpty().WithMessage("ClientId jest wymagany.");
            RuleFor(x => x.BookId).NotEmpty().WithMessage("BookId jest wymagany.");
        }
    }
}
