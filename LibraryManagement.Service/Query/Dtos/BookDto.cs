using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Service.Query.Dtos
{
    public class BookDto
    {
        public BookDto(int id, string title, string author, string genre, int year)
        {
            Id = id;
            Title = title;
            Author = author;
            Genre = genre;
            Year = year;
        }

        public int Id { get; }
        public string Title { get; }
        public string Author { get; }
        public string Genre { get; }
        public int Year { get; }
    }
}
