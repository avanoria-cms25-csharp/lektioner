using Newtonsoft.Json;
using Presentation.Interfaces;
using Presentation.Models;

namespace Presentation.Services;

public class CustomerService(IFileService fileService) : ICustomerService
{
    private List<Customer> _customerList = [];
    private readonly IFileService _fileService = fileService;
    private readonly string _filePath = @"c:\data\customers.json";

    public bool AddCustomer(Customer customer)
    {
        _customerList.Add(customer);

        string json = JsonConvert.SerializeObject(_customerList);
        _fileService.SaveToFile(_filePath, json);

        return true;
    }

    public IEnumerable<Customer> GetCustomers()
    {
        var content = _fileService.GetFromFile(_filePath);
        
        try
        {
            _customerList = JsonConvert.DeserializeObject<List<Customer>>(content)!;
        }
        catch { }

        return _customerList;
    }
}
