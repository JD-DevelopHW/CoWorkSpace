using Cwk.Domain.DTOs.Requests;
using Cwk.Domain.DTOs.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cwk.Business.Interfaces
{
    public interface IAuthService
    {
        Task<LoginResponseDto> Login(LoginRequestDto loginRequest);

        Task<UserResponseDto> Register(CreateUserDto createUser);
    }
}
