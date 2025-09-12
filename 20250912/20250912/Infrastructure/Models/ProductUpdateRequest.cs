namespace Infrastructure.Models;

public class ProductUpdateRequest
{
    public string? ArticleNumber { get; set; }
    public bool IsService { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
}