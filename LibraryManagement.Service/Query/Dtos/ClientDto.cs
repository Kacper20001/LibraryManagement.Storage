using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Service.Query.Dtos
{
    public class ClientDto
    {
        public ClientDto(int id, string name, string surname, string email)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Email = email;
        }

        public int Id { get; }
        public string Name { get; }
        public string Surname { get; }
        public string Email { get; }
    }
}
