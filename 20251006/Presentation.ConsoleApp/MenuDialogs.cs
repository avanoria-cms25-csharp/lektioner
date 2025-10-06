using Infrastructure.Models;
using Infrastructure.Services;

namespace Presentation.ConsoleApp;

public class MenuDialogs(IUserService userService)
{
    private readonly IUserService _userService = userService;

    public void Show()
    {

        while (true)
        {
            MainMenu();
        }
    }


    public void MainMenu()
    {
        Console.WriteLine("1. Add User");

        UserAddView();
    }

    public void UserAddView()
    {
        var user = new User();

        Console.Clear();
        Console.WriteLine("NEW USER");
        Console.Write("First Name: ");
        user.FirstName = Console.ReadLine()!;

        Console.Write("Last Name: ");
        user.FirstName = Console.ReadLine()!;

        Console.Write("Email: ");
        user.FirstName = Console.ReadLine()!;

        var result = _userService.AddUser(user);
        if (result)
        {
            Console.WriteLine("User was added successfully.");
        }
        else
        {
            Console.WriteLine("Unable to add user");
        }

        Console.ReadKey();
    }
}
