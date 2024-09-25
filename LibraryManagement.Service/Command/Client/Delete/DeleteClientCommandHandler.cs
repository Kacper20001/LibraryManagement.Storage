using LibraryManagement.Storage.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Service.Command.Client.Delete
{
    public class DeleteClientCommandHandler : ICommandHandler<DeleteClientCommand>
    {
        private readonly ILibraryRepository _repository;

        public DeleteClientCommandHandler(ILibraryRepository repository)
        {
            _repository = repository;
        }

        public Result Handle(DeleteClientCommand command)
        {
            var client = _repository.GetClientById(command.ClientId);
            if (client == null)
            {
                return Result.Fail("Client not found.");
            }

            _repository.DeleteClient(command.ClientId);

            return Result.Ok();
        }
    }
}
