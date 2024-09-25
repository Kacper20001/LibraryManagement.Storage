using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Service.Command.Client.Update
{
    public class UpdateClientCommandValidator : AbstractValidator<UpdateClientCommand>
    {
        public UpdateClientCommandValidator()
        {
            RuleFor(x => x.ClientId).NotEmpty();
            RuleFor(x => x.Name).NotEmpty().Length(3, 30);
            RuleFor(x => x.Surname).NotEmpty().Length(3, 30);
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
        }
    }
}
