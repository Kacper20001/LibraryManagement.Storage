using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Service.Command.Book.Delete
{
    public class DeleteBookCommand : ICommand
    {
        public int BookId { get; set; }
    }
}
