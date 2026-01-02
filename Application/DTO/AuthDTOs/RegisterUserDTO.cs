using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.AuthDTOs
{
    // This DTO is used when registering a new user
    public class RegisterUserDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int Role { get; set; }        // maps to UserRole enum
        public string Password { get; set; }
    }
}
