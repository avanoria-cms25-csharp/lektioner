namespace ConsoleApp1;

public class User
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;





    public User(string firstName, string lastName, string email)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
    }

    public User(string email)
    {
        Email = email;
    }
}


public class UserService
{
    // field
    private List<User> Private_UsersList  = [];

    // Properties
    public List<User> Public_UsersList { get; set; } = [];


}