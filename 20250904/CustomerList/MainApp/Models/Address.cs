﻿namespace MainApp.Models;

public class Address
{
    public string AddressLine_1 { get; set; } = null!;
    public string? AddressLine_2 { get; set; }
    public string PostalCode { get; set; } = null!;
    public string City { get; set; } = null!;

}