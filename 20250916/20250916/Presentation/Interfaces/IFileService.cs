namespace Presentation.Interfaces;

public interface IFileService
{
    void SaveToFile(string path, string content);
    string GetFromFile(string path);
}
