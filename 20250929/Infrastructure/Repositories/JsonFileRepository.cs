using Infrastructure.Models;
using System.Text.Json;

namespace Infrastructure.Repositories;


public interface IJsonFileRepository
{
    Task WriteAsync(IEnumerable<Product> products, CancellationToken cancellationToken = default);
    ValueTask<IReadOnlyList<Product>> ReadAsync(CancellationToken cancellationToken = default);
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
        var baseDirectory = AppContext.BaseDirectory;
        var dataDirectory = Path.Combine(baseDirectory, "Data");
        _filePath = Path.Combine(dataDirectory, fileName);

        EnsureInitialized(dataDirectory, _filePath);
    }

    public static void EnsureInitialized(string dataDirectory, string filePath)
    {
        if (!Directory.Exists(dataDirectory))
            Directory.CreateDirectory(dataDirectory);

        if (!File.Exists(filePath))
            File.WriteAllText(filePath, "[]");
    }

    public async Task WriteAsync(IEnumerable<Product> products, CancellationToken cancellationToken = default)
    {
        await using var stream = File.Create(_filePath);
        await JsonSerializer.SerializeAsync(stream, products, _jsonOptions, cancellationToken);
    }

    public async ValueTask<IReadOnlyList<Product>> ReadAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            await using var stream = File.OpenRead(_filePath);
            var products = await JsonSerializer.DeserializeAsync<List<Product>>(stream, _jsonOptions, cancellationToken);
            return products ?? [];
        }
        catch
        {
            return [];
        }
    }
}
