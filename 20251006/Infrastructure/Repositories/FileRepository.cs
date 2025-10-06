using Infrastructure.Models;
using System.Text.Json;
using System.Threading.Tasks;

namespace Infrastructure.Repositories;

public class FileRepository : IFileRepository
{
    private readonly string _filePath = "";
    private static readonly JsonSerializerOptions _jsonSerializerOptions = new()
    {
        WriteIndented = true,
    };

    public FileRepository(string fileName = "data.json")
    {
        var base_directory = AppContext.BaseDirectory;
        var data_directory = Path.Combine(base_directory, "Data");
        _filePath = Path.Combine(data_directory, fileName);

        EnsureInitialized(data_directory, _filePath);
    }

    public static void EnsureInitialized(string dataDirectory, string filePath)
    {
        if (!Directory.Exists(dataDirectory))
            Directory.CreateDirectory(dataDirectory);

        if (!File.Exists(filePath))
            File.WriteAllText(filePath, "[]");
    }


    public IEnumerable<User> Read()
    {
        using var stream = File.OpenRead(_filePath);
        var users = JsonSerializer.Deserialize<List<User>>(stream, _jsonSerializerOptions);
        return users ?? [];
    }

    public bool Write(List<User> users)
    {
        try
        {
            using var stream = File.Create(_filePath);
            JsonSerializer.Serialize(stream, users, _jsonSerializerOptions);
            return true;
        }
        catch
        {
            return false;
        }
    }
}