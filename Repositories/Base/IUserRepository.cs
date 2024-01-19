using Turbo.az.Models;

namespace Turbo.az.Repositories.Base;
public interface IUserRepository
{
    Task<IEnumerable<User>> GetAllUsersAsync();
    Task InsertUserAsync(User user);
}