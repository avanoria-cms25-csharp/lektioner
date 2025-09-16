using Presentation.Models;

namespace Presentation.Interfaces;

public interface ICustomerService
{
    bool AddCustomer(Customer customer);
    IEnumerable<Customer> GetCustomers();
}
