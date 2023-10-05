using Orders.Core.Dtos;
using Orders.Core.ViewModels;

namespace Orders.Infrastructure.Services.Resturants
{
    public interface IResturantService
    {
        Task<List<ResturantViewModel>> Getall(string searchKey);
        Task<List<ResturantViewModel>> NearMe(string userId);
        Task<int> Create(CreateResturentDto dto);

    }
}