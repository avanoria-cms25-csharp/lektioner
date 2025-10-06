using Infrastructure.Models;
using Infrastructure.Repositories;

namespace Infrastructure.Services;

public class UserService(IFileRepository fileRepository) : IUserService
{
    private List<User> _userList = [];
    private readonly IFileRepository _fileRepository = fileRepository;

    public bool AddUser(User user)
    {
        if (user is null || 
            string.IsNullOrEmpty(user!.FirstName) ||
            string.IsNullOrEmpty(user!.LastName) ||
            string.IsNullOrEmpty(user!.Email))
            return false;

        var user_exists = _userList.Any(usr => usr.Email == user.Email);

        if (!user_exists)
        {
            user.Id = _userList.Count + 1;
            _userList.Add(user);

            var result = _fileRepository.Write(_userList);
            return result;
        }

        return false;
    }

    public IEnumerable<User> GetUsers()
    {
        _userList = [.. _fileRepository.Read()];

        return _userList;
    }

    public User? GetUserById(int id)
    {
        _userList = [.. _fileRepository.Read()];

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

            var result = _fileRepository.Write(_userList);
            return result;
        }

        return false;
    }


    public bool DeleteUserById(int id)
    {
        var existing_user = GetUserById(id);

        if (existing_user is not null)
        {
            _userList.Remove(existing_user);

            var result = _fileRepository.Write(_userList);
            return result;
        }

        return false;
            
    }

    public bool DeleteUser(User user)
    {
        _userList.Remove(user);

        var result = _fileRepository.Write(_userList);
        return result;
    }
}
