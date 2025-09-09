using Infrastructure.Models;
using Infrastructure.Services;

namespace Infrastructure.Managers;

public class UserManager(JsonFileService fileService)
{
    private readonly JsonFileService _fileService = fileService;

    public string CreateUser(User user)
    {
        if (user == null)
            return "Invalid object provided";

        if (string.IsNullOrWhiteSpace(user.FirstName))
            return "Invalid first name";

        if (string.IsNullOrWhiteSpace(user.LastName))
            return "Invalid last name";

        if (string.IsNullOrWhiteSpace(user.Email))
            return "Invalid email address";

        if (string.IsNullOrWhiteSpace(user.Password))
            return "Invalid password";


        return "";
    }
}