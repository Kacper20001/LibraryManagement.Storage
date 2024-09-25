using LibraryManagement.Storage.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagement.Service.Query.Dtos;


namespace LibraryManagement.Service.Query.Loan
{
    public class GetLoansByClientIdQueryHandler : IQueryHandler<GetLoansByClientIdQuery, List<LoanDto>>
    {
        private readonly ILibraryRepository _repository;

        public GetLoansByClientIdQueryHandler(ILibraryRepository repository)
        {
            _repository = repository;
        }

        public List<LoanDto> Handle(GetLoansByClientIdQuery query)
        {
            var loans = _repository.GetLoansByClientId(query.ClientId);

            return loans.Select(l =>
            {
                if (l.Book == null || l.Client == null)
                {
                    throw new Exception("Brak powiązanej książki lub klienta przy wypożyczeniu.");
                }

                return new LoanDto(
                    l.Id,
                    l.BookId,
                    l.Book.Title,
                    l.Client.Name + " " + l.Client.Surname,  
                    l.LoanDate,
                    l.ReturnDate);
            }).ToList();
        }
    }
}
