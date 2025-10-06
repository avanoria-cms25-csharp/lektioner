using Infrastructure.Models;

namespace Infrastructure.Services;

public class UserService : IUserService
{
    private List<User> _userList = [];

    public bool AddUser(User user)
    {
        var user_exists = _userList.Any(usr => usr.Email == user.Email);

        if (!user_exists)
        {
            user.Id = _userList.Count + 1;
            _userList.Add(user);
            return true;
        }

        return false;
    }

    public IEnumerable<User> GetUsers()
    {
        return _userList;
    }

    public User? GetUserById(int id)
    {
        var user = _userList.FirstOrDefault(u => u.Id == id);
        return user;
    }


    public bool UpdateUser(User user)
    {
        var existing_user = GetUserById(user.Id);

        if (existing_user is not null)
        {
            existing_user.FirstName = user.FirstName;
            existing_user.LastName = user.LastName;

            if (existing_user.Email != user.Email)
            {
                var existing_email = _userList.Any(usr => usr.Email == user.Email);
                if (existing_email)
                    return false;

                existing_user.Email = user.Email;
            }

            return true;
        }

        return false;
    }


    public bool DeleteUserById(int id)
    {
        var existing_user = GetUserById(id);

        if (existing_user is not null)
        {
            _userList.Remove(existing_user);
            return true;
        }

        return false;
            
    }

    public bool DeleteUser(User user)
    {
        _userList.Remove(user);
        return true;
    }
}
