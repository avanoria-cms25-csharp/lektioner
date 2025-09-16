using Presentation.Models;
using System.Text.RegularExpressions;

namespace Presentation.Helpers;

public class Validator
{
    public static bool ValidateUser(User user)
    {
        if (user is null)
            return false;

        return true;
    }

    public static bool ValidateEmail(string email)
    {
        if (string.IsNullOrEmpty(email))
            return false;

        string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
        return Regex.IsMatch(email, emailPattern);
    }

    public static bool ValidatePassword(string password)
    {
        if (string.IsNullOrEmpty(password))
            return false;

        string passwordPattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^A-Za-z0-9]).{8,}$";
        return Regex.IsMatch(password, passwordPattern);
    }
}
