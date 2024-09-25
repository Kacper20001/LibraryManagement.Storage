using LibraryManagement.Storage.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Service.Command.Client.Add
{
    public class AddClientCommandHandler : ICommandHandler<AddClientCommand>
    {
        private readonly ILibraryRepository _repository;

        public AddClientCommandHandler(ILibraryRepository repository)
        {
            _repository = repository;
        }

        public Result Handle(AddClientCommand command)
        {
            var validationResult = new AddClientCommandValidator().Validate(command);
            if (!validationResult.IsValid)
            {
                return Result.Fail(validationResult);
            }

            var client = new Storage.Entities.Client(command.Name, command.Surname, command.Email);
            _repository.AddClient(client);

            return Result.Ok();
        }
    }
}
