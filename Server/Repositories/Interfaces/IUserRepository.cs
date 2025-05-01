using Server.Models;
namespace Server.Repositories.Interfaces;

public interface IUserRepository
{
    Task<User?> GetByUsernameAsync(string username);
    Task<User> AddAsync(User user);
}