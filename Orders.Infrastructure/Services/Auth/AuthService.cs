using Microsoft.AspNetCore.Identity;
using Orders.API.Data;
using Orders.Core.Dtos;
using Orders.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Infrastructure.Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly OrdersDbContext _db;
        private readonly UserManager<User> _userManager;

        public AuthService(OrdersDbContext db, UserManager<User> userManager)
        {
            _db = db;
            _userManager = userManager;
        }
        public async Task<bool> Login(LoginDto dto)
        {
            var user = _db.Users.SingleOrDefault(x => x.UserName == dto.Username);
            if (user == null)
            {
                //throw Invalidusername or password
            }
            var result = await _userManager.CheckPasswordAsync(user, dto.Password);
            if (!result)
            {
                //throw Invalidusername or password

            }
            return result;
        }
        //string username, string password
    }
}
