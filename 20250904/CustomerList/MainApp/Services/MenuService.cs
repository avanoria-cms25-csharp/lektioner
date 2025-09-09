using MainApp.Models;

namespace MainApp.Services;

public class MenuService
{
    private CustomerService _customerService = new CustomerService();


    public void DisplayMainMenu()
    {
        _customerService = new CustomerService();
        while (true)
        {
            Console.Clear();
            Console.WriteLine("### MENU OPTIONS ###");
            Console.WriteLine("1. Create Customer");
            Console.WriteLine("2. View Customer List");

            Console.WriteLine();
            Console.Write("Choose a menu option: ");
            var option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    DisplayAddCustomerOption();
                    break;

                case "2":
                    DisplayListCustomersOption();
                    break;
            }
        }
    }


    private void DisplayAddCustomerOption()
    {
        Console.Clear();
        Console.WriteLine("### NEW CUSTOMER ###");

        var customer = new Customer();


        // Customer Name
        while (string.IsNullOrEmpty(customer.CustomerName))
        {
            Console.Write("Enter Customer Name: ");
            customer.CustomerName = Console.ReadLine()!;

            if (string.IsNullOrEmpty(customer.CustomerName))
            {
                Console.WriteLine("You must enter a valid customer name.");
                Console.ReadKey();
                Console.Clear();
            }
        }

        // Customer Contact Person
        customer.ContactPerson = new ContactPerson();

        while (string.IsNullOrEmpty(customer.ContactPerson.FirstName))
        {
            Console.Write("Enter First Name: ");
            customer.ContactPerson.FirstName = Console.ReadLine()!;

            if (string.IsNullOrEmpty(customer.ContactPerson.FirstName))
            {
                Console.WriteLine("You must enter a valid first name.");
                Console.ReadKey();
                Console.Clear();
            }
        }


        while (string.IsNullOrEmpty(customer.ContactPerson.LastName))
        {
            Console.Write("Enter Last Name: ");
            customer.ContactPerson.LastName = Console.ReadLine()!;

            if (string.IsNullOrEmpty(customer.ContactPerson.LastName))
            {
                Console.WriteLine("You must enter a valid last name.");
                Console.ReadKey();
                Console.Clear();
            }
        }


        _customerService.Create(customer);

        Console.WriteLine();
        Console.WriteLine("Customer was created successfully.");
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }

    private void DisplayListCustomersOption()
    {
        Console.Clear();
        Console.WriteLine("### CUSTOMER LIST ###");

        var customerList = _customerService.GetAll();

        foreach (var customer in customerList)
        {
            Console.WriteLine($"{customer.Id} - {customer.CustomerName}");
        }

        Console.WriteLine();
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }
}
