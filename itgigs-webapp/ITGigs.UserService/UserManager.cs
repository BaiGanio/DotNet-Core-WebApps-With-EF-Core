using ITGigs.Common.Extensions;
using ITGigs.DB;
using ITGigs.UserService.Domain;
using ITGigs.UserService.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITGigs.UserService
{
    public class UserManager : IUser
    {
        private readonly AppDbContext _ctx;

        public UserManager()
        {
            this._ctx = new AppDbContext();
        }

        public async Task ConfirmEmailAsync(User user)
        {
            var updatedUser = new User(
                user.Username,
                user.Email,
                user.Password,
                user.ValidationCode,
                true,
                new CustomId(new Guid(user.Id)),
                user.ImgUrl,
                DateTime.Now
            );
            _ctx.Users.Update(updatedUser);
            await _ctx.SaveChangesAsync();
        }

        public async Task<List<User>> GetAllUsersAsync() => await _ctx.Users.ToListAsync();

        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _ctx.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<User> GetUserByIdAsync(string id)
        {
            List<User> users = await _ctx.Users.ToListAsync();
            return users.FirstOrDefault(u => u.Id == id);
        }

        public Task LoginAsync()
        {
            throw new NotImplementedException();
        }

        public async Task RegisterAsync(User user)
        {
            await _ctx.Users.AddAsync(user);
            await _ctx.SaveChangesAsync();
        }
    }
}
