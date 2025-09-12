using Infrastructure.Interfaces;
using Infrastructure.Models;

namespace Presentation;

public class MenuService(IProductManager productManager)
{
    private readonly IProductManager _productManager = productManager;


    private void AddMenuOption()
    {
        var product = new ProductCreateRequest();

        Console.Write("Product Name: ");
        var name = Console.ReadLine();
       
        while (string.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine("You must enter a valid product name.");
            Console.Write("Product Name: ");
            name = Console.ReadLine()!;
        }

        product.Name = name;

        Console.Write("Product Description (optional): ");
        product.Description = Console.ReadLine();

        Console.Write("Product Article Number (optional): ");
        product.ArticleNumber = Console.ReadLine();

        var result = _productManager.SaveProduct(product);
        if (result)
            Console.WriteLine("Product was created successfully.");
        else
            Console.WriteLine("Something went wrong! Please try again later.");

        Console.WriteLine("Press any key to continue.");
        Console.ReadKey();
    }

    private void ViewMenuOption()
    {
        var products = _productManager.GetAllProducts();
        foreach (var product in products)
        {
            Console.WriteLine($"{product.Name}");
        }

        Console.WriteLine("Press any key to continue.");
        Console.ReadKey();
    }


    private void MainMenu()
    {
        while (true)
        {
            Console.WriteLine("####### MENU OPTIONS #######");
            Console.WriteLine("1. \t NEW PRODUCT");
            Console.WriteLine("2. \t VIEW PRODUCT LIST");
            Console.Write("Select menu option: ");
            var option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    Console.Clear();
                    AddMenuOption();
                    break;

                case "2":
                    Console.Clear();
                    ViewMenuOption();
                    break;
            }

            Console.Clear();
        }
    }

    public void Run()
    {
        _productManager.GetAllProducts();
        MainMenu();
    }
}
