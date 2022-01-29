using System.Threading.Tasks;
using Entities.Dto;

namespace Contracts
{
    public interface IAuthenticationManager
    {
        Task<bool> ValidateUser(UserForAuthenticationDto userForAuth);
        Task<string> CreateToken();

    }
}
