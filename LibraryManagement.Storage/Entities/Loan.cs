using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Storage.Entities
{
    [Table("Loans", Schema = "Library")]
    public class Loan
    {
        protected Loan() { }

        public Loan(int clientId, Client client, int bookId, Book book, DateTime loanDate, DateTime? returnDate = null)
        {
            ClientId = clientId;
            Client = client;
            BookId = bookId;
            Book = book;
            LoanDate = loanDate;
            ReturnDate = returnDate;
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public int ClientId { get; set; }

        [ForeignKey("ClientId")]
        public virtual Client Client { get; set; }

        [Required]
        public int BookId { get; set; }

        [ForeignKey("BookId")]
        public virtual Book Book { get; set; }

        [Required]
        public DateTime LoanDate { get; set; }

        public DateTime? ReturnDate { get; set; }
    }

}
