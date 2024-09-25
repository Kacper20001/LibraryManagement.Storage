using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibraryManagement.Service.Query.Dtos;
using System.Threading.Tasks;

namespace LibraryManagement.Service.Query.Book
{
    public class GetBookByIdQuery : IQuery<BookDto>
    {
        public int BookId { get; set; }

        public GetBookByIdQuery(int bookId)
        {
            BookId = bookId;
        }
    }
}
