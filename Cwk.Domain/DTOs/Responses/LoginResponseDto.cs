using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cwk.Domain.DTOs.Responses
{
    public class LoginResponseDto
    {
        public bool IsAuthencated { get; set; }
        public string Token { get; set; } = null!;
        public string message { get; set; } = null!;
    }
}
