using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Service.Command.Loan.Delete
{
    public class DeleteLoanCommand : ICommand
    {
        public int LoanId { get; set; }
        public int ClientId { get; set; } 

    }
}
