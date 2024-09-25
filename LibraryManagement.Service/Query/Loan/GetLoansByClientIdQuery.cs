using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibraryManagement.Service.Query.Dtos;
using System.Threading.Tasks;

namespace LibraryManagement.Service.Query.Loan
{
    public class GetLoansByClientIdQuery : IQuery<List<LoanDto>>
    {
        public int ClientId { get; set; }

        public GetLoansByClientIdQuery(int clientId)
        {
            ClientId = clientId;
        }
    }
}
