using AutoMapper;
using Orders.API.Data;
using System;
using System.Collections.Generic;
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

    }
}
