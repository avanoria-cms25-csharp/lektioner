using Infrastructure.Models;

namespace Infrastructure.Services
{
    public interface IUserService
    {
        bool AddUser(User user);
        bool DeleteUser(User user);
        bool DeleteUserById(int id);
        User? GetUserById(int id);
        IEnumerable<User> GetUsers();
        bool UpdateUser(User user);
    }
}