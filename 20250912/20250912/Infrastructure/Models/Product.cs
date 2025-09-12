namespace Infrastructure.Models;

public class Product
{
    public string Id { get; set; } = null!;
    public string? ArticleNumber { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
}
