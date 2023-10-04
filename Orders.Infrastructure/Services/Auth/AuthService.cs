using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Orders.API.Data;
using Orders.Core.Constant;
using Orders.Core.Dtos;
using Orders.Core.Exceptions;
using Orders.Core.Options;
using Orders.Core.ViewModels;
using Orders.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Infrastructure.Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly OrdersDbContext _db;
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        private readonly JwtOptions _options;

        public AuthService(OrdersDbContext db, UserManager<User> userManager, IMapper mapper, IOptions<JwtOptions> options)
        {
            _db = db;
            _userManager = userManager;
            _mapper = mapper;
            _options = options.Value;
        }
        public async Task<LoginResponseViewModel> Login(LoginDto dto)
        {
            var user = _db.Users.SingleOrDefault(x => x.UserName == dto.Username);
            if (user == null)
            {
                throw new InvalidUsernameOrPassword();
            }
            var result = await _userManager.CheckPasswordAsync(user, dto.Password);
            if (!result)
            {
                throw new InvalidUsernameOrPassword();

            }
            var response = new LoginResponseViewModel();
            response.AccessToken = await GenerateAccessToken(user);
            response.User = _mapper.Map<UserViewModel>(user);

            return response;
        }
        private async Task<AccessTokenViewModel> GenerateAccessToken(User user)
        {
            var roles = await _userManager.GetRolesAsync(user);
            var claims = new List<Claim>()
            {
            new Claim(JwtRegisteredClaimNames.Sub,user.UserName),
            new Claim(Claims.PhoneNumber, user.PhoneNumber),
            new Claim(Claims.UserId,user.Id),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };
            if (roles.Any())
            {
                claims.Add(new Claim(ClaimTypes.Role, string.Join(",", roles)));
            }
            var Key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.SecurityKey));
            var credentials = new SigningCredentials(Key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddMonths(1);
            var accessToken = new JwtSecurityToken(_options.Issure,
                _options.Issure,
                claims,
                expires: expires,
                signingCredentials: credentials
                );
            var result = new AccessTokenViewModel()
            {
                AccessToken = new JwtSecurityTokenHandler().WriteToken(accessToken),
                ExpireAt = expires
            };
            return result;
        }
        //string username, string password
    }
}
