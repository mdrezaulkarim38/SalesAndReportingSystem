using Server.DTOs;
namespace Server.Services.Interfaces;

public interface IAuthService
{
    Task<string> RegisterAsync(RegisterDto request);
    Task<string> LoginAsync(LoginDto request);
}