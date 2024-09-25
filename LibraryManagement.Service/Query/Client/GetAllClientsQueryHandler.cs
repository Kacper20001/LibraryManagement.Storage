using LibraryManagement.Storage.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagement.Service.Query.Dtos;


namespace LibraryManagement.Service.Query.Client
{
    public class GetAllClientsQueryHandler : IQueryHandler<GetAllClientsQuery, List<ClientDto>>
    {
        private readonly ILibraryRepository _repository;

        public GetAllClientsQueryHandler(ILibraryRepository repository)
        {
            _repository = repository;
        }

        public List<ClientDto> Handle(GetAllClientsQuery query)
        {
            var clients = _repository.GetClients();
            return clients.Select(c => new ClientDto(c.Id, c.Name, c.Surname, c.Email)).ToList();
        }
    }
}
