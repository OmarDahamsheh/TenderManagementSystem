using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.AuthDTOs
{
    public class ResetPasswordDTO
    {
        public string Email { get; set; }
        public string Token { get; set; }     // user received token
        public string NewPassword { get; set; }
    }
}
