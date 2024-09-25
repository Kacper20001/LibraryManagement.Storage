using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Service.Query.Dtos
{
    public class LoanDto
    {
        public LoanDto(int id, int bookId, string bookTitle, string clientName, DateTime loanDate, DateTime? returnDate)
        {
            Id = id;
            BookId = bookId;
            BookTitle = bookTitle;
            ClientName = clientName; // Przypisanie nazwy klienta
            LoanDate = loanDate;
            ReturnDate = returnDate;
        }

        public int Id { get; }
        public int BookId { get; }
        public string BookTitle { get; }
        public string ClientName { get; } // Nowe pole na nazwę klienta
        public DateTime LoanDate { get; }
        public DateTime? ReturnDate { get; }
    }

}
