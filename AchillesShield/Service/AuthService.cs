using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AchillesShield.DTO.Auth;
using AchillesShield.Models;
using AchillesShield.Repositories.Interfaces;
using AchillesShield.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;

namespace AchillesShield.Services;

public class AuthService : IAuthService
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IConfiguration _configuration;

    public AuthService(
        IUserRepository userRepository,
        IUnitOfWork unitOfWork,
        IConfiguration configuration)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
        _configuration = configuration;
    }

    // =========================
    // REGISTER
    // =========================
    public async Task<LoginResponse> RegisterAsync(
        RegisterRequest request)
    {
        // Check if username already exists
        var existingUser =
            await _userRepository.GetByUsernameAsync(request.Username);

        if (existingUser != null)
        {
            throw new Exception("Username already exists.");
        }

        // Check if email already exists
        var existingEmail =
            await _userRepository.GetByEmailAsync(request.Email);

        if (existingEmail != null)
        {
            throw new Exception("Email already exists.");
        }

        // Hash password using BCrypt
        var passwordHash =
            BCrypt.Net.BCrypt.HashPassword(request.Password);

        // Create user
        var user = new User
        {
            Username = request.Username,
            Email = request.Email,
            PasswordHash = passwordHash,
            IsActive = true,
            RoleId = request.RoleId
        };

        // Add user to DbContext
        await _userRepository.AddAsync(user);

        // Save user to PostgreSQL
        await _unitOfWork.SaveChangesAsync();

        // Load user again together with Role
        var createdUser =
            await _userRepository.GetByIdWithRoleAsync(user.Id);

        if (createdUser == null)
        {
            throw new Exception("User could not be created.");
        }

        // Generate JWT
        var token = GenerateJwtToken(createdUser);

        return new LoginResponse
        {
            Token = token,
            UserId = createdUser.Id,
            Username = createdUser.Username,
            Role = createdUser.Role.Name
        };
    }


    // =========================
    // LOGIN
    // =========================
    public async Task<LoginResponse> LoginAsync(
        LoginRequest request)
    {
        // Find user by username
        var user =
            await _userRepository.GetByUsernameAsync(request.Username);

        if (user == null)
        {
            throw new UnauthorizedAccessException(
                "Invalid username or password.");
        }

        // Check if user is active
        if (!user.IsActive || user.IsDeleted)
        {
            throw new UnauthorizedAccessException(
                "User is inactive.");
        }

        // Verify password against BCrypt hash
        var passwordValid =
            BCrypt.Net.BCrypt.Verify(
                request.Password,
                user.PasswordHash);

        if (!passwordValid)
        {
            throw new UnauthorizedAccessException(
                "Invalid username or password.");
        }

        // Generate JWT
        var token = GenerateJwtToken(user);

        return new LoginResponse
        {
            Token = token,
            UserId = user.Id,
            Username = user.Username,
            Role = user.Role.Name
        };
    }


    // =========================
    // JWT TOKEN
    // =========================
    private string GenerateJwtToken(User user)
    {
        var key =
            _configuration["Jwt:Key"]
            ?? throw new InvalidOperationException(
                "JWT Key is missing.");

        var issuer =
            _configuration["Jwt:Issuer"];

        var audience =
            _configuration["Jwt:Audience"];

        var expirationMinutes =
            int.Parse(
                _configuration["Jwt:ExpirationMinutes"] ?? "60");


        var claims = new List<Claim>
        {
            new Claim(
                ClaimTypes.NameIdentifier,
                user.Id.ToString()),

            new Claim(
                ClaimTypes.Name,
                user.Username),

            new Claim(
                ClaimTypes.Role,
                user.Role?.Name ?? string.Empty)
        };


        var securityKey =
            new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(key));

        var credentials =
            new SigningCredentials(
                securityKey,
                SecurityAlgorithms.HmacSha256);


        var token = new JwtSecurityToken(
            issuer: issuer,
            audience: audience,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(
                expirationMinutes),
            signingCredentials: credentials);


        return new JwtSecurityTokenHandler()
            .WriteToken(token);
    }
}