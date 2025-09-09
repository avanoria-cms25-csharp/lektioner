namespace MainApp.Models;

public class Customer
{
    public string Id { get; set; } = null!;
    public string CustomerName { get; set; } = null!;
    public ContactInformation ContactInformation { get; set; } = null!;
    public ContactPerson? ContactPerson { get; set; }
    public Address BillingAddress { get; set; } = null!;
    public Address DeliveryAddress { get; set; } = null!;
}
