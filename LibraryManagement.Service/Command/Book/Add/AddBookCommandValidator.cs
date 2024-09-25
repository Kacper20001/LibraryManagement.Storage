using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Service.Command.Book.Add
{
    public class AddBookCommandValidator : AbstractValidator<AddBookCommand>
    {
        public AddBookCommandValidator()
        {
            RuleFor(x => x.Title).NotEmpty().Length(3, 100);
            RuleFor(x => x.Author).NotEmpty().Length(3, 50);
            RuleFor(x => x.Year).GreaterThan(0);
        }
    }
}
