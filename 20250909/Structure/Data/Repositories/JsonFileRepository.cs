namespace Data.Repositories;

public class JsonFileRepository(string filePath)
{
    private readonly string _filePath = filePath;
}
