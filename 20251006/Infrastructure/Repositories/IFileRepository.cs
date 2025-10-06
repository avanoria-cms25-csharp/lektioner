namespace Infrastructure.Repositories;

public interface IFileRepository
{
    bool Write(string content);
    string Read();
}
