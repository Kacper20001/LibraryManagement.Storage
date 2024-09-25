using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Storage.Entities
{
    [Table("Clients", Schema = "Library")]
    public class Client
    {
        protected Client() { }

        public Client(string name, string surname, string email)
        {
            Name = name;
            Surname = surname;
            Email = email;
        }

        [Key]
        public int Id { get; set; }

        [Required, MinLength(3), MaxLength(30)]
        public string Name { get; set; }

        [Required, MinLength(3), MaxLength(30)]
        public string Surname { get; set; }

        [MinLength(3), MaxLength(30)]
        public string Email { get; set; }

        public ICollection<Loan> Loans { get; set; }
    }
}
