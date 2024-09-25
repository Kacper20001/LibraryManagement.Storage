using LibraryManagement.Storage.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagement.Service.Query.Dtos;


namespace LibraryManagement.Service.Query.Book
{
    public class GetAllBooksQueryHandler : IQueryHandler<GetAllBooksQuery, List<BookDto>>
    {
        private readonly ILibraryRepository _repository;

        public GetAllBooksQueryHandler(ILibraryRepository repository)
        {
            _repository = repository;
        }

        public List<BookDto> Handle(GetAllBooksQuery query)
        {
            var books = _repository.GetBooks();
            return books.Select(b => new BookDto(b.Id, b.Title, b.Author, b.Genre, b.Year)).ToList();
        }
    }
}
