using LibraryManagement.Service.Query.Dtos;
using LibraryManagement.Storage.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Service.Query.Loan
{
    public class GetAllLoansQueryHandler : IQueryHandler<GetAllLoansQuery, List<LoanDto>>
    {
        private readonly ILibraryRepository _repository;

        public GetAllLoansQueryHandler(ILibraryRepository repository)
        {
            _repository = repository;
        }

        public List<LoanDto> Handle(GetAllLoansQuery query)
        {
            var loans = _repository.GetAllLoans(); 
            return loans.Select(l => new LoanDto(
                l.Id,
                l.BookId,
                l.Book.Title,
                l.Client.Name + " " + l.Client.Surname,
                l.LoanDate,
                l.ReturnDate)).ToList();
        }
    }
}
