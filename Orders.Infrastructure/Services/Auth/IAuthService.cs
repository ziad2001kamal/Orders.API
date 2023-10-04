using Orders.Core.Dtos;

namespace Orders.Infrastructure.Services.Auth
{
    public interface IAuthService
    {
        Task<bool> Login(LoginDto dto);

    }
}