using Infrastructure.Models;
using Infrastructure.Repositories;

namespace Infrastructure.Services;

public interface IUserService
{
    void Cancel();
    Task<IEnumerable<User>> GetUsersAsync();
    Task SaveUserAsync(User user);
}

public class UserService(IFileRepository fileRepository) : IUserService
{
    private readonly IFileRepository _fileRepository = fileRepository;
    private List<User> _users = [];
    private CancellationTokenSource _cts = null!;

    public void Cancel()
    {
        _cts.Cancel();
    }


    public async Task SaveUserAsync(User user)
    {
        try
        {
            _cts = new CancellationTokenSource();

            user.Id = Guid.NewGuid().ToString();
            _users.Add(user);

            await _fileRepository.WriteAsync(_users, _cts.Token);
        }
        catch
        {
            Cancel();
        }
        finally
        {
            _cts.Dispose();
        }
    }

    public async Task<IEnumerable<User>> GetUsersAsync()
    {
        try
        {
            _cts = new CancellationTokenSource();

            var result = await _fileRepository.ReadAsync(_cts.Token);
            _users = [.. result];
        }
        catch
        {
            Cancel();
            _users = [];
        }
        finally
        {
            _cts.Dispose();
        }

        return _users;
    }
}

