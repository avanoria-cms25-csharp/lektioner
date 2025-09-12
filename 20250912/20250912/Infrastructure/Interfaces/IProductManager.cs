using Infrastructure.Models;

namespace Infrastructure.Interfaces;

public interface IProductManager
{
    bool SaveProduct(ProductCreateRequest productCreateRequest);
    IEnumerable<Product> GetAllProducts();
}
