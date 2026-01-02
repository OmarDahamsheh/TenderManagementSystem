using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTO.AuthDTOs;

namespace Application.Service.UserService
{
    public interface IAuthService
    {
        public Task Register(RegisterUserDTO registerUserDTO);
        public Task<AuthResponseDTO> Login(LoginDTO loginDTO);
        public Task<string> ForgotPassword(ForgotPasswordDTO forgotPasswordDTO);
        public Task ResetPassword(ResetPasswordDTO resetPasswordDTO);
    }
}
