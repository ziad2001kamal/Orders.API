using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Orders.API.Data;
using Orders.Core.Dtos;
using Orders.Core.ViewModels;
using Orders.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Infrastructure.Services.Users
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly OrdersDbContext _db;
        private readonly IMapper _mapper;

        public UserService(UserManager<User> userManager, OrdersDbContext db, IMapper mapper)
        {
            _userManager = userManager;
            _db = db;
            _mapper = mapper;
        }
        public async Task<List<UserViewModel>> GetAll(string serachKey)
        {
            var users = _db.Users.Where(x => x.FullName.Contains(serachKey) || string.IsNullOrWhiteSpace(serachKey)).Select(x => new UserViewModel()).ToList();
            return _mapper.Map<List<UserViewModel>>(users);

        }
        public async Task<string> Create(CreateUserDto dto)
        {
            var user = _mapper.Map<User>(dto);
            user.UserName = dto.PhoneNumber;
            await _userManager.CreateAsync(user, dto.Password);
            return user.Id;

        }
        public async Task<string> Update(UpdateUserDto dto)
        {
            var user = _db.Users.SingleOrDefault(x => x.Id == dto.Id);
            if (user == null)
            {
                //throw 
            }
            var UpdateUser = _mapper.Map(dto, user);
            _db.Users.Update(UpdateUser);
            _db.SaveChanges();
            return user.Id;
        }
        public async Task<string> Delete(string id)
        {
            var user = _db.Users.SingleOrDefault(x => x.Id == id);
            if (user == null)
            {
                //throw 
            }
            user.IsDelete = true;
            _db.Users.Update(user);
            _db.SaveChanges();
            return user.Id;
        }
        public async Task<UserViewModel> Get(string id)
        {
            var user = _db.Users.SingleOrDefault(x => x.Id == id);
            if (user == null)
            {
                //throw 
            }
            var userVm = _mapper.Map<UserViewModel>(user);
            return userVm;
        }
    }

}
