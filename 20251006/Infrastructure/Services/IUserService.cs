using Infrastructure.Models;

namespace Infrastructure.Services
{
    public interface IUserService
    {
        void AddUser(User user);
        IEnumerable<User> GetUsers();
    }
}