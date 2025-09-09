using Infrastructure.Managers;
using Infrastructure.Models;

namespace Infrastructure.Services;

public class MenuService(UserManager userManager)
{
    private readonly UserManager _userManager = userManager;

    public void Start()
    {
        while (true)
        {
            MainMenu();
        }
    }

    private void MainMenu()
    {
        Console.WriteLine("#### MENU ####");
        Console.WriteLine("1. \t Add New User");

        Console.WriteLine("");
        Console.Write("Select menu option: ");
        var option = Console.ReadLine();

        switch (option)
        {
            case "1":
                AddNewUserOption();
                break;
        }
    }

    private void AddNewUserOption()
    {
        var user = new User();

        Console.Clear();
        Console.WriteLine("#### NEW USER ####");

        Console.Write("Enter First Name: ");
        user.FirstName = Console.ReadLine()!;
        Console.Write("Enter Last Name: ");
        user.LastName = Console.ReadLine()!;
        Console.Write("Enter Email: ");
        user.Email = Console.ReadLine()!;
        Console.Write("Enter Password: ");
        user.Password = Console.ReadLine()!;

        _userManager.CreateUser(user);

        Console.ReadKey();
    }

}
