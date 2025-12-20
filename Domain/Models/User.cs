using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(50)]
        public string Name { get; set; } =string.Empty;

        [Required, EmailAddress, MaxLength(50)]
        public string Email { get; set; } = string.Empty;
        
        [Required]
        [RegularExpression(@"^07\d{8}$",ErrorMessage ="Phone number must be 10 digits long and starts with 07")]
        public string PhoneNumber{ get; set; }

        [Required]
        public UserRole Role { get; set; }

        public List<Tender> CreatedTenders { get; set; } =new List<Tender>();
        public ICollection<Bid>Bids { get; set; }=new List<Bid>();
        private User() { }
        public User(string Name, string Email, string PhoneNumber, UserRole Role) { 
            this.Name = Name;
            this.Email = Email;
            this.PhoneNumber = PhoneNumber;
            this.Role = Role;

        }
    }
}
