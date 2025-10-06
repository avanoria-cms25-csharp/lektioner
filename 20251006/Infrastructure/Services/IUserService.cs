using Infrastructure.Models;

namespace Infrastructure.Services
{
    public interface IUserService
    {
        void AddUser(User user);
        void DeleteUser(User user);
        void DeleteUserById(int id);
        IEnumerable<User> GetUsers();
    }
}