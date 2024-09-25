using LibraryManagement.Service.Query.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Service.Command.Loan
{
    public class LoanBookCommand : ICommand
    {
        public int ClientId { get; set; }
        public int BookId { get; set; }

        public List<ClientDto> Clients { get; set; }
        public List<BookDto> Books { get; set; } 
    }
}
