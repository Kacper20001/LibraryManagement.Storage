using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Service.Command.Book.Update
{
    public class UpdateBookCommandValidator : AbstractValidator<UpdateBookCommand>
    {
        public UpdateBookCommandValidator()
        {
            RuleFor(x => x.BookId).NotEmpty();
            RuleFor(x => x.Title).NotEmpty().Length(3, 100);
            RuleFor(x => x.Author).NotEmpty().Length(3, 50);
            RuleFor(x => x.Year).GreaterThan(0);
        }
    }
}
