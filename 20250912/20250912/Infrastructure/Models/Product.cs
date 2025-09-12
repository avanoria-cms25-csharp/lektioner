namespace Infrastructure.Models;

public class Product
{
    public string Id { get; set; } = null!;
    public string? ArticleNumber { get; set; }
    public bool IsService { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
}


public class ProductCreateRequest
{
    public string? ArticleNumber { get; set; }
    public bool IsService { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
}
