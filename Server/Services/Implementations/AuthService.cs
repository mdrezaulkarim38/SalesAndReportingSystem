using Server.DTOs;
using Server.Helpers;
using Server.Models;
using Server.Repositories.Interfaces;
using Server.Services.Interfaces;

namespace Server.Services.Implementations;

public class AuthService : IAuthService
{
    private readonly IUserRepository _userRepository;
    private readonly JwtTokenHelper _jwtTokenHelper;

    public AuthService(IUserRepository userRepository, JwtTokenHelper jwtTokenHelper)
    {
        _userRepository = userRepository;
        _jwtTokenHelper = jwtTokenHelper;
    }

    public async Task<string> RegisterAsync(RegisterDto request)
    {
        var existingUser = await _userRepository.GetByUsernameAsync(request.UserName);
        if (existingUser != null)
        {
            throw new InvalidOperationException("Username already exists.");
        }

        var user = new User
        {
            Name = request.Name,
            UserName = request.UserName,
            Password = PasswordHasher.HashPassword(request.Password)
        };

        await _userRepository.AddAsync(user);
        return _jwtTokenHelper.GenerateToken(user.Id, user.UserName, user.Name!);
    }

    public async Task<string> LoginAsync(LoginDto request)
    {
        var user = await _userRepository.GetByUsernameAsync(request.UserName!);
        if (user == null || !PasswordHasher.VerifyPassword(request.Password!, user.Password))
        {
            throw new UnauthorizedAccessException("Invalid username or password.");
        }

        return _jwtTokenHelper.GenerateToken(user.Id, user.UserName, user.Name!);
    }
}