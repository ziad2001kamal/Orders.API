using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Orders.API.Data;
using Orders.Core.Dtos;
using Orders.Core.ViewModels;
using Orders.Data.Models;
using Orders.Infrastructure.Extentions;
using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Infrastructure.Services.Resturants
{
    public class ResturantService : IResturantService
    {
        private readonly OrdersDbContext _db;
        private readonly IMapper _mapper;

        public ResturantService(OrdersDbContext db, IMapper mapper)
        {

            _db = db;
            _mapper = mapper;

        }
        public async Task<List<ResturantViewModel>> Getall(string searchKey)
        {
            var resturent = await _db.Resturants.Include(x => x.Meals).Where(x => x.Name.Contains(searchKey) || string.IsNullOrEmpty(searchKey)).OrderByDescending(x => x.Meals.Count()).ToListAsync();
            return _mapper.Map<List<ResturantViewModel>>(resturent);
        }

        public async Task<int> Create(CreateResturentDto dto)
        {
            var resturant = _mapper.Map<Resturant>(dto);
            await _db.AddAsync(resturant);
            await _db.SaveChangesAsync();
            return resturant.Id;
        }

        public async Task<List<ResturantViewModel>> NearMe(string userId)
        {
            var user = await _db.Users.SingleOrDefaultAsync(x => x.Id == userId);
            var resturents = await _db.Resturants.ToListAsync();
            var distance = new Dictionary<int, double>();
            var userLocation = new Coordinates((double)user.Latitude, (double)user.Logittude);
            foreach (var resturent in resturents)
            {
                var resturentLocation = new Coordinates((double)resturent.Latitude, (double)resturent.Logittude);
                var distanceKM = userLocation.DistanceTo(resturentLocation);
                distance.Add(resturent.Id, distanceKM);
            }
            var nearIds = distance.OrderBy(x => x.Value).Take(5).Select(x => x.Key).ToList();
            var nearResturant = _db.Resturants.Where(x => nearIds.Contains(x.Id)).ToList();
            return _mapper.Map<List<ResturantViewModel>>(nearResturant);

        }

    }
}
