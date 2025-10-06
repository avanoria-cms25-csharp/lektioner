using Infrastructure.Models;

namespace Infrastructure.Services;

public class UserService : IUserService
{
    private List<User> _userList = [];

    public void AddUser(User user)
    {
        user.Id = _userList.Count + 1;
        _userList.Add(user);
    }

    public IEnumerable<User> GetUsers()
    {
        return _userList;
    }

    public void DeleteUserById(int id)
    {
        var user = _userList.FirstOrDefault(usr => usr.Id == id);

        if (user is not null)
            _userList.Remove(user);
    }

    public void DeleteUser(User user)
    {
        _userList.Remove(user);
    }
}
