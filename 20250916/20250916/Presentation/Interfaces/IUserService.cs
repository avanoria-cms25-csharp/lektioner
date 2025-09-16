using Presentation.Models;

namespace Presentation.Interfaces;

public interface IUserService
{
    UserServiceResponse AddUserToList(User user);
    bool UserExistsInList(User user);
}
