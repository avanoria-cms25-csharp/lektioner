using Infrastructure.Models;
using System.Text.Json;
using System.Threading;

namespace Infrastructure.Repositories;


public interface IJsonFileRepository
{
    Task Write_Async(IEnumerable<Product> products, CancellationToken cancellationToken_s = default);
    ValueTask<IReadOnlyList<Product>> Read_Async(CancellationToken cancellationToken_s = default);
}


public class JsonFileRepository : IJsonFileRepository
{

    private readonly string _filePath = null!;
    private static readonly JsonSerializerOptions _jsonOptions = new(JsonSerializerDefaults.Web)
    {
        WriteIndented = true,
    };


    public JsonFileRepository(string fileName = "data.json")
    {
        var base_Directory = AppContext.BaseDirectory;
        var data_Directory = Path.Combine(base_Directory, "Data");
        _filePath = Path.Combine(data_Directory, fileName);

        EnsureInitialized(data_Directory, _filePath);
    }

    public static void EnsureInitialized(string dataDirectory, string filePath)
    {
        if (!Directory.Exists(dataDirectory))
            Directory.CreateDirectory(dataDirectory);

        if (!File.Exists(filePath))
            File.WriteAllText(filePath, "[]");
    }

    public async Task Write_Async(IEnumerable<Product> products, CancellationToken cancellationToken_s = default)
    {
        await using var stream = File.Create(_filePath);
        await JsonSerializer.SerializeAsync(stream, products, _jsonOptions, cancellationToken_s);
    }

    public async ValueTask<IReadOnlyList<Product>> Read_Async(CancellationToken cancellationToken_s = default)
    {
        try
        {
            await using var stream = File.OpenRead(_filePath);
            var products = await JsonSerializer.DeserializeAsync<List<Product>>(stream, _jsonOptions, cancellationToken_s);
            return products ?? [];
        }
        catch
        {
            return [];
        }
    }
}
