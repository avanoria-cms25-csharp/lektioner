using Presentation.Helpers;
using Presentation.Interfaces;
using Presentation.Models;

namespace Presentation.Services;

public class UserService : IUserService
{
    private readonly List<User> _users = new List<User>();

    public UserServiceResponse AddUserToList(User user)
    {
        if (!Validator.ValidateUser(user))
            return new UserServiceResponse { Error = "User is Null"};

        if (!Validator.ValidateEmail(user.Email))
            return new UserServiceResponse { Error = "Email is invalid" };

        if (!Validator.ValidatePassword(user.Password))
            return new UserServiceResponse { Error = "Password is invalid" };

        _users.Add(user);

        if (!UserExistsInList(user))
            return new UserServiceResponse { Error = "User was not added to the list" };

        return new UserServiceResponse { Succeeded = true };
    }

    public bool UserExistsInList(User user)
    {
        if (_users.Contains(user)) 
            return true;

        return false;
    }

}
