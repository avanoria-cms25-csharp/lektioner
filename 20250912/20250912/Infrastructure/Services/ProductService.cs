using Infrastructure.Interfaces;
using Infrastructure.Models;

namespace Infrastructure.Services;

public class ProductService : IProductService
{
    public bool CreateProduct(ProductCreateRequest product)
    {
        throw new NotImplementedException();
    }

    public bool DeleteProduct(string id)
    {
        throw new NotImplementedException();
    }

    public Product GetProductByArticleNumber(string articleNumber)
    {
        throw new NotImplementedException();
    }

    public Product GetProductById(string id)
    {
        throw new NotImplementedException();
    }

    public Product GetProductByName(string name)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Product> GetProducts()
    {
        throw new NotImplementedException();
    }

    public bool UpdateProduct(string id, ProductUpdateRequest product)
    {
        throw new NotImplementedException();
    }
}
