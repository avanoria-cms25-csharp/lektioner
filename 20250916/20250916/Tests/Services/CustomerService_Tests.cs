using Moq;
using Newtonsoft.Json;
using Presentation.Interfaces;
using Presentation.Models;
using Presentation.Services;

namespace Tests.Services;

public class CustomerService_Tests
{
    [Fact]
    public void AddCustomer_ShouldAddCustomerToCustomerList()
    {
        // Arrange
        var fileServiceMock = new Mock<IFileService>();
        var fileService = fileServiceMock.Object;
        fileServiceMock.Setup(fs => fs.SaveToFile(It.IsAny<string>(), It.IsAny<string>()));

        var customerService = new CustomerService(fileService);
        var customer = new Customer { Id = "1", CustomerName = "Nackademin AB" }; 

        // Act
        var result = customerService.AddCustomer(customer);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void GetCustomers_ShouldReturnEmptyList_IfNoCustomersInList()
    {
        // Arrange
        var fileServiceMock = new Mock<IFileService>();
        var fileService = fileServiceMock.Object;

        ICustomerService customerService = new CustomerService(fileService);

        
        // Act
        var result = customerService.GetCustomers();

        
        // Assert
        Assert.Empty(result);

    }

    [Fact]
    public void GetCustomers_ShouldReturnListOfCustomers()
    {
        // Arrange
        var customer = new Customer { Id = "1", CustomerName = "Test" };
        var list = new List<Customer>
        {
            customer
        };
        string json = JsonConvert.SerializeObject(list);


        var fileServiceMock = new Mock<IFileService>();
        var fileService = fileServiceMock.Object;

        fileServiceMock.Setup(fs => fs.GetFromFile(It.IsAny<string>())).Returns(json);

        ICustomerService customerService = new CustomerService(fileService);


        // Act
        var result = customerService.GetCustomers();


        // Assert
        Assert.Single(result);
        Assert.Equal(customer.CustomerName, result.FirstOrDefault()!.CustomerName);
    }
}
