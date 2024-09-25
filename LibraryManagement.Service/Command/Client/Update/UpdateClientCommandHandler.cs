using LibraryManagement.Storage.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Service.Command.Client.Update
{
    public class UpdateClientCommandHandler : ICommandHandler<UpdateClientCommand>
    {
        private readonly ILibraryRepository _repository;

        public UpdateClientCommandHandler(ILibraryRepository repository)
        {
            _repository = repository;
        }

        public Result Handle(UpdateClientCommand command)
        {
            var client = _repository.GetClientById(command.ClientId);
            if (client == null)
            {
                return Result.Fail("Client not found.");
            }

            var validationResult = new UpdateClientCommandValidator().Validate(command);
            if (!validationResult.IsValid)
            {
                return Result.Fail(validationResult);
            }

            client.Name = command.Name;
            client.Surname = command.Surname;
            client.Email = command.Email;

            _repository.UpdateClient(client);

            return Result.Ok();
        }
    }
}
