using Infrastructure.Interfaces;
using Infrastructure.Models;

namespace Infrastructure.Services;

public class ProductService : IProductService
{
    private List<Product> _productList = [];

    public bool AddToProductList(ProductCreateRequest newProduct)
    {
        if (newProduct == null)
            return false;

        if (!string.IsNullOrWhiteSpace(newProduct.Name))
            return false;

        Product product = new()
        {
            Id = Guid.NewGuid().ToString(),
            ArticleNumber = newProduct.ArticleNumber,
            Name = newProduct.Name,
            Description = newProduct.Description
        };

        _productList.Add(product);
        return true;
    }

    public Product? GetProductByArticleNumber(string articleNumber)
    {
        var product = _productList.FirstOrDefault(x => x.ArticleNumber == articleNumber);
        return product;
    }

    public Product? GetProductById(string id)
    {
        var product = _productList.FirstOrDefault(x => x.Id == id);
        return product;
    }

    public Product? GetProductByName(string name)
    {
        var product = _productList.FirstOrDefault(x => x.Name == name);
        return product;
    }

    public IEnumerable<Product> GetProductList()
    {
        return _productList;
    }
}
