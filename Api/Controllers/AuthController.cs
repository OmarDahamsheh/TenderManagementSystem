using Application.DTO.AuthDTOs;
using Application.Service.UserService;
using Microsoft.AspNetCore.Mvc;

namespace TendersManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
      private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register([FromBody] RegisterUserDTO registerUserDTO) { 
            await _authService.Register(registerUserDTO);
            return Ok();
        }

        [HttpPost("login")]
        public async Task<ActionResult<AuthResponseDTO>>Login([FromBody] LoginDTO loginDTO)
        {
            var authResponse = await _authService.Login(loginDTO);
            return Ok(authResponse);
        }

        [HttpPost("forgot-password")]
        public async Task<ActionResult<string>> ForgotPassword([FromBody] ForgotPasswordDTO dto)
        {
            var token = await _authService.ForgotPassword(dto);
            return Ok(token);
        }

        [HttpPost("reset-password")]
        public async Task<ActionResult> ResetPassword([FromBody] ResetPasswordDTO dto)
        {
            await _authService.ResetPassword(dto);
            return Ok();
        }
    }
}
