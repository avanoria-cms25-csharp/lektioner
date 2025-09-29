using Infrastructure.Services;

namespace Presentation.ConsoleApp;

public class MainDialog(IProductService productService)
{
    private readonly IProductService _productService = productService;

    public void Show()
    {

    }
}
