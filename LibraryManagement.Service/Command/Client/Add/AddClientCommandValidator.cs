using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Service.Command.Client.Add
{
    public class AddClientCommandValidator : AbstractValidator<AddClientCommand>
    {
        public AddClientCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().Length(3, 30);
            RuleFor(x => x.Surname).NotEmpty().Length(3, 30);
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
        }
    }
}
