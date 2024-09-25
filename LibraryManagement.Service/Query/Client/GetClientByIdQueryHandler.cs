using LibraryManagement.Storage.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagement.Service.Query.Dtos;


namespace LibraryManagement.Service.Query.Client
{
    public class GetClientByIdQueryHandler : IQueryHandler<GetClientByIdQuery, ClientDto>
    {
        private readonly ILibraryRepository _repository;

        public GetClientByIdQueryHandler(ILibraryRepository repository)
        {
            _repository = repository;
        }

        public ClientDto Handle(GetClientByIdQuery query)
        {
            var client = _repository.GetClientById(query.ClientId);
            if (client == null)
            {
                return null;
            }

            return new ClientDto(client.Id, client.Name, client.Surname, client.Email);
        }
    }
}
