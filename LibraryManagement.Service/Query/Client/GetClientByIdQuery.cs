using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagement.Service.Query.Dtos;


namespace LibraryManagement.Service.Query.Client
{
    public class GetClientByIdQuery : IQuery<ClientDto>
    {
        public int ClientId { get; set; }

        public GetClientByIdQuery(int clientId)
        {
            ClientId = clientId;
        }
    }
}
