using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.AuthDTOs
{
    // This DTO is used to send back user info and token after authentication. The token can be a JWT or any other type of token.
    public class AuthResponseDTO
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public int Role { get; set; }
        public string? Token { get; set; }   // later JWT
    }
}
