using Cwk.Business.Interfaces;
using Cwk.Domain.DTOs.Requests;
using Microsoft.AspNetCore.Mvc;

namespace Cwk.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IAuthService authService) : ControllerBase
    {
        private readonly IAuthService _authService = authService;

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto loginRequest)
        {
            if (loginRequest == null)
            {
                return BadRequest("Invalid login request");
            }

            var response = await _authService.Login(loginRequest);
            if (response.IsAuthencated)
            {
                return Ok(response);
            }
            else
            {
                return Unauthorized(response.Message);
            }
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] CreateUserDto createUser)
        {
            if (createUser == null)
            {
                return BadRequest("Invalid registration request");
            }
            var response = await _authService.Register(createUser);
            if (response != null)
            {
                return CreatedAtAction(nameof(Register), new { id = response.Id }, response);
            }
            else
            {
                return BadRequest("registration failed");
            }
        }
    }
}
