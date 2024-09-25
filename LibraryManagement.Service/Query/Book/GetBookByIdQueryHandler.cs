using LibraryManagement.Storage.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagement.Service.Query.Dtos;


namespace LibraryManagement.Service.Query.Book
{
    public class GetBookByIdQueryHandler : IQueryHandler<GetBookByIdQuery, BookDto>
    {
        private readonly ILibraryRepository _repository;

        public GetBookByIdQueryHandler(ILibraryRepository repository)
        {
            _repository = repository;
        }

        public BookDto Handle(GetBookByIdQuery query)
        {
            var book = _repository.GetBookById(query.BookId);
            if (book == null)
            {
                return null;
            }

            return new BookDto(book.Id, book.Title, book.Author, book.Genre, book.Year);
        }
    }
}
