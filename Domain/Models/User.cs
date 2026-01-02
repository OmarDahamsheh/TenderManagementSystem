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

        
        public string Name { get; set; } =string.Empty;

        
        public string Email { get; set; } = string.Empty;
        
        
        [RegularExpression(@"^07\d{8}$",ErrorMessage ="Phone number must be 10 digits long and starts with 07")]
        public string PhoneNumber{ get; set; }

        
        public UserRole Role { get; set; }

        public List<Tender> CreatedTenders { get; set; } =new List<Tender>();
        public ICollection<Bid>Bids { get; set; }=new List<Bid>();

        public byte[]? PasswordHash { get; set; }//This stores the hashed version of the user's password.
        public byte[]? PasswordSalt { get; set; }//This is used to add an extra layer of security to the password hashing process.


        public byte[]? PasswordResetTokenHash { get; set; }//This stores the hashed version of the password reset token.
        public DateTime? ResetTokenExpiresAt { get; set; }//This indicates when the password reset token will expire.


        public User(string Name, string Email, string PhoneNumber, UserRole Role) { 
            this.Name = Name;
            this.Email = Email;
            this.PhoneNumber = PhoneNumber;
            this.Role = Role;

        }
    }
}
