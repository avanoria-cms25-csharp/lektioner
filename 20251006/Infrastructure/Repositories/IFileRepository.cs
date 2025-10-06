using Infrastructure.Models;

namespace Infrastructure.Repositories;

public interface IFileRepository
{
    bool Write(List<User> users);
    IEnumerable<User> Read();
}
