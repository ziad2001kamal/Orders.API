using Orders.Core.Dtos;
using Orders.Core.ViewModels;

namespace Orders.Infrastructure.Services.Auth
{
    public interface IAuthService
    {
        Task<LoginResponseViewModel> Login(LoginDto dto);

    }
}