using Cwk.Domain.Entities;

namespace Cwk.Application.Interfaces
{
    public interface ITokenServices
    {
        public string GenerateToken(User user);
    }
}
