using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Service.Command.Client.Delete
{
    public class DeleteClientCommand : ICommand
    {
        public int ClientId { get; set; }
    }
}
