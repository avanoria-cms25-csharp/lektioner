using Infrastructure.Models;

namespace Infrastructure.Interfaces;

public interface IProductService
{
    bool AddToProductList(ProductCreateRequest newProduct);
    IEnumerable<Product> GetProductList();

    Product? GetProductById(string id);
    Product? GetProductByName(string name);
    Product? GetProductByArticleNumber (string articleNumber);

}
