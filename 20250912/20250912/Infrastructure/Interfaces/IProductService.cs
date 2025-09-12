using Infrastructure.Models;

namespace Infrastructure.Interfaces;

public interface IProductService
{
    bool CreateProduct(ProductCreateRequest product);

    IEnumerable<Product> GetProducts();

    Product GetProductById(string id);
    Product GetProductByArticleNumber(string articleNumber);
    Product GetProductByName(string name);

    bool UpdateProduct(string id, ProductUpdateRequest product);

    bool DeleteProduct(string id);
}
