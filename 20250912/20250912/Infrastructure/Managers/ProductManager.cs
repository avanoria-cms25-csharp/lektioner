using Infrastructure.Interfaces;
using Infrastructure.Models;

namespace Infrastructure.Managers;

public class ProductManager(IProductService productService, IFileService fileService) : IProductManager
{
    private readonly IProductService _productService = productService;
    private readonly IFileService _fileService = fileService;

    public IEnumerable<Product> GetAllProducts()
    {
        var productList = _productService.GetProductList();
        return productList;
    }

    public bool SaveProduct(ProductCreateRequest productCreateRequest)
    {
        var add_success = _productService.AddToProductList(productCreateRequest);
        if (add_success)
        {
            var productList = _productService.GetProductList();

            var save_result = _fileService.SaveContentToFile<IEnumerable<Product>>(productList);
            return save_result;
        }

        return false;
    }
}
