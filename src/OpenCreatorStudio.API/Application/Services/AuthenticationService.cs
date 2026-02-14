using OpenCreatorStudio.Application.DTOs;
using OpenCreatorStudio.Application.Interfaces;
using OpenCreatorStudio.Domain.Entities;

namespace OpenCreatorStudio.Application.Services;

/// <summary>
/// Service d'authentification avec BCrypt.
/// </summary>
public class AuthenticationService : IAuthenticationService
{
    private readonly IUserRepository _userRepository;

    public AuthenticationService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<AuthResponse> LoginAsync(AuthRequest request)
    {
        var user = await _userRepository.GetByUsernameAsync(request.Username);
        
        if (user == null)
        {
            return new AuthResponse
            {
                Success = false,
                Message = "Nom d'utilisateur ou mot de passe incorrect"
            };
        }

        // Vérification du mot de passe avec BCrypt
        bool isPasswordValid = BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash);
        
        if (!isPasswordValid)
        {
            return new AuthResponse
            {
                Success = false,
                Message = "Nom d'utilisateur ou mot de passe incorrect"
            };
        }

        // Mise à jour de la dernière connexion
        user.LastLoginAt = DateTime.UtcNow;
        await _userRepository.UpdateAsync(user);

        return new AuthResponse
        {
            Success = true,
            Token = GenerateToken(user), // TODO: Implémenter JWT
            User = MapToUserDto(user)
        };
    }

    public async Task<UserDto> RegisterAsync(string username, string password, string? email = null)
    {
        if (await UsernameExistsAsync(username))
        {
            throw new InvalidOperationException("Ce nom d'utilisateur existe déjà");
        }

        var user = new User
        {
            Username = username,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(password),
            Email = email,
            CreatedAt = DateTime.UtcNow
        };

        var createdUser = await _userRepository.CreateAsync(user);
        return MapToUserDto(createdUser);
    }

    public async Task<bool> UsernameExistsAsync(string username)
    {
        var user = await _userRepository.GetByUsernameAsync(username);
        return user != null;
    }

    private string GenerateToken(User user)
    {
        // TODO: Implémenter génération JWT
        // Pour l'instant, retourner un token simple
        return $"token_{user.Id}_{Guid.NewGuid()}";
    }

    private UserDto MapToUserDto(User user)
    {
        return new UserDto
        {
            Id = user.Id,
            Username = user.Username,
            Email = user.Email,
            CreatedAt = user.CreatedAt
        };
    }
}

/// <summary>
/// Interface du repository utilisateur (définie dans Application pour DIP).
/// </summary>
public interface IUserRepository
{
    Task<User?> GetByUsernameAsync(string username);
    Task<User?> GetByIdAsync(int id);
    Task<User> CreateAsync(User user);
    Task<User> UpdateAsync(User user);
}
