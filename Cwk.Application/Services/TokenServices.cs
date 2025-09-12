using Cwk.Application.Interfaces;
using Cwk.Domain.Entities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cwk.Application.Services
{
    public class TokenServices(IConfiguration config) : ITokenServices
    {
        private readonly string secretKey = config.GetSection("Jwt").GetValue<string>("key");

        public string GenerateToken(User user)
        {
            throw new NotImplementedException();
        }
    }
}
