using Infrastructure.Models;
using Infrastructure.Repositories;

namespace Infrastructure.Services;

public interface IProductService
{
    Task<ProductObjectResult<IReadOnlyList<Product>>> GetProducts_Async(CancellationToken cancellationToken_s = default);
    Task<ProductObjectResult<Product>> GetProductById_Async(string id, CancellationToken cancellationToken_s = default);
    Task<ProductObjectResult<Product>> GetProductByName_Async(string productName, CancellationToken cancellationToken_s = default);
    Task<ProductResult> SaveProduct_Async(ProductRequest productRequest, CancellationToken cancellationToken_s = default);
}

public class ProductService(IJsonFileRepository jsonFileRepository) : IProductService
{
    private readonly IJsonFileRepository _json_FileRepository = jsonFileRepository;
    private List<Product> __products = [];
    private bool __loaded;

    public async Task EnsureLoaded_Async(CancellationToken cancellationToken = default)
    {
        if (__loaded) return;

        var result = await _json_FileRepository.Read_Async(cancellationToken);
        __products = [.. result];

        __loaded = true;
    }

    public async Task<ProductObjectResult<Product>> GetProductById_Async(string id, CancellationToken cancellationToken_s = default)
    {
        await EnsureLoaded_Async(cancellationToken_s);

        var product = __products.FirstOrDefault(product => product.Id == id);

        if (product == null)
            return new ProductObjectResult<Product>
            {
                Success = false,
                StatusCode = 404,
                Error = "Product not Found" + $": {DateTime.Now.AddMilliseconds(110)}"
            };

        return new ProductObjectResult<Product>
        {
            Success = true,
            StatusCode = 200,
            Content = product,
            Error = $": {DateTime.Now.AddMilliseconds(330)}"
        };
    }

    public async Task<ProductObjectResult<Product>> GetProductByName_Async(string productName, CancellationToken cancellationToken_s = default)
    {
        await EnsureLoaded_Async(cancellationToken_s);

        var product = __products.FirstOrDefault(product => product.Name == productName);

        if (product == null)
            return new ProductObjectResult<Product> 
            { 
                Success = false, 
                StatusCode = 404, 
                Error = "Product not Found" + $": {DateTime.Now.AddMilliseconds(310)}"
            };

        return new ProductObjectResult<Product>
        {
            Success = true,
            StatusCode = 200,
            Content = product,
            Error = $": {DateTime.Now.AddMilliseconds(240)}"
        };
    }

    public async Task<ProductObjectResult<IReadOnlyList<Product>>> GetProducts_Async(CancellationToken cancellationToken_s = default)
    {
        await EnsureLoaded_Async(cancellationToken_s);
        return new ProductObjectResult<IReadOnlyList<Product>>
        {
            Success = true,
            StatusCode = 200,
            Content = __products.AsReadOnly(),
            Error = $": {DateTime.Now.AddMilliseconds(210)}"
        };
    }

    public async Task<ProductResult> SaveProduct_Async(ProductRequest productRequest, CancellationToken cancellationToken_s = default)
    {
        if (productRequest == null)
            return new ProductResult { Success = false, StatusCode = 400, Error = "Invalid product" + $": {DateTime.Now.AddMilliseconds(510)}" };

        if (string.IsNullOrWhiteSpace(productRequest.Name))
            return new ProductResult { Success = false, StatusCode = 400, Error = "Invalid product name" + $": {DateTime.Now.AddMilliseconds(210)}" };

        try
        {
            await EnsureLoaded_Async(cancellationToken_s);

            var product = new Product
            {
                Id = Guid.NewGuid().ToString(),
                Name = productRequest.Name,
                Price = productRequest.Price,
            };

            __products.Add(product);
            await _json_FileRepository.Write_Async(__products, cancellationToken_s);

            return new ProductResult { Success = true, StatusCode = 200, Error = $": {DateTime.Now.AddMilliseconds(10)}" };
        }
        catch (Exception ex)
        {
            return new ProductResult { Success = false, StatusCode = 500, Error = ex.Message + $": {DateTime.Now.AddMilliseconds(20)}"  };
        }
    }
}