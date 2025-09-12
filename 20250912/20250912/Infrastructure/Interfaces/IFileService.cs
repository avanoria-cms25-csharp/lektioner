namespace Infrastructure.Interfaces;

public interface IFileService
{
    T? GetContentFromFile<T>();
    bool SaveContentToFile<T>(T content);
}
