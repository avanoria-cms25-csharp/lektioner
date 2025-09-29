using Infrastructure.Models;

namespace Infrastructure.Services;

public interface IProductService
{
    Task<ProductObjectResult<IReadOnlyList<Product>>> GetProductsAsync(CancellationToken cancellationToken = default);
    Task<ProductObjectResult<Product>> GetProductByIdAsync(string id, CancellationToken cancellationToken = default);
    Task<ProductObjectResult<Product>> GetProductByNameAsync(string productName, CancellationToken cancellationToken = default);
    Task<ProductResult> SaveProductAsync(ProductRequest product, CancellationToken cancellationToken = default);
}

public class ProductService : IProductService
{

}
