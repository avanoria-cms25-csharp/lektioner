namespace Infrastructure.Models;

public class ProductCreateRequest
{
    public string? ArticleNumber { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public bool IsService { get; set; }
}
