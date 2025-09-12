using AutoMapper;
using Cwk.Application.Interfaces;
using Cwk.Business.Interfaces;
using Cwk.Domain.DTOs.Requests;
using Cwk.Domain.DTOs.Responses;
using Cwk.Domain.Entities;
using Cwk.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cwk.Business.Services
{
    public class AuthService(ITokenServices tokenService, IUserRepository userRepository, IMapper mapper) : IAuthService
    {
        private readonly ITokenServices _tokenService = tokenService;
        private readonly IUserRepository _userRepository = userRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<LoginResponseDto> Login(LoginRequestDto loginRequest)
        {
            var user = await _userRepository.GetUserByemailAsync(loginRequest.Email);
            var isAuthenticated = user != null && BCrypt.Net.BCrypt.Verify(loginRequest.Password, user.PasswordHash);
            if(isAuthenticated && user!.IsActive)
            {
                var token = _tokenService.GenerateToken(user);
                return new LoginResponseDto
                {
                    IsAuthencated = true,
                    Token = token,
                    Message = "Inicio de sesion exitoso!"
                };
            }
            else
            {
                return new LoginResponseDto
                {
                    IsAuthencated = false,
                    Token = string.Empty,
                    Message = "Credenciales invalidas o usuario inactivo."
                };
            }
        }

        public async Task<UserResponseDto> Register(CreateUserDto createUser)
        {
            var user = new User
            {
                Name = createUser.Name,
                Email = createUser.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(createUser.Password),
                PhoneNumber = createUser.PhoneNumber,
                Role = createUser.Role,
            };

            var createdUser = await _userRepository.CreateAsync(user);
            return _mapper.Map<UserResponseDto>(createdUser);
        }
    }
}
