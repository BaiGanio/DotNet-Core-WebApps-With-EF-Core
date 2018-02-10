using ITGigs.UserService.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ITGigs.UserService.Domain
{
    public interface IUser
    {
        Task RegisterAsync(User user);
        Task LoginAsync();
        Task<User> GetUserByIdAsync(string id);
        Task<User> GetUserByEmailAsync(string email);
        Task<List<User>> GetAllUsersAsync();
    }
}
