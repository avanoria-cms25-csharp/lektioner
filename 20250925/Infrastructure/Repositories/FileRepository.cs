using Infrastructure.Models;
using System.Text.Json;

namespace Infrastructure.Repositories;

public interface IFileRepository
{
    Task<IEnumerable<User>> ReadAsync(CancellationToken cancellationToken);
    Task WriteAsync(IEnumerable<User> users, CancellationToken cancellationToken);
}


public class FileRepository : IFileRepository
{
    private readonly string _filePath;
    private static readonly JsonSerializerOptions _jsonOptions = new() { WriteIndented = true };

    public FileRepository()
    {
        var baseDirectory = AppContext.BaseDirectory;
        var dataDirectory = Path.Combine(baseDirectory, "Data");
        _filePath = Path.Combine(dataDirectory, "users.json");

        if (!Directory.Exists(dataDirectory))
        {
            Directory.CreateDirectory(dataDirectory);
        }

        if(!File.Exists(_filePath))
        {
            File.WriteAllText(_filePath, "[]");
        }
    }

    public async Task<IEnumerable<User>> ReadAsync(CancellationToken cancellationToken)
    {
        if (!File.Exists(_filePath)) 
            return [];

        var json = await File.ReadAllTextAsync(_filePath, cancellationToken);
        if (string.IsNullOrWhiteSpace(json)) 
            return [];

        try
        { 
            var users = JsonSerializer.Deserialize<List<User>>(json, _jsonOptions);
            return users ?? [];
        }
        catch (JsonException)
        {
            await File.WriteAllTextAsync(_filePath, "[]", cancellationToken);
            return [];
        }
    }

    public async Task WriteAsync(IEnumerable<User> users, CancellationToken cancellationToken)
    {
        string json = JsonSerializer.Serialize(users, _jsonOptions);
        await File.WriteAllTextAsync(_filePath, json, cancellationToken);
    }
}
