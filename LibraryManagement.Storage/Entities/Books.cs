using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Storage.Entities
{
    [Table("Books", Schema = "Library")]
    public class Book
    {
        protected Book() { }
        public Book(string title, string author, string genre, int year)
        {
            Title = title;
            Author = author;
            Genre = genre;
            Year = year;
        }

        [Key]
        public int Id { get; set; }

        [Required, MinLength(3), MaxLength(100)]
        public string Title { get; set; }

        [Required, MinLength(3), MaxLength(50)]
        public string Author { get; set; }

        [MaxLength(50)]
        public string Genre { get; set; }

        [Required]
        public int Year { get; set; }
        [Required]
        public bool IsLoaned { get; set; } 
    }
}
