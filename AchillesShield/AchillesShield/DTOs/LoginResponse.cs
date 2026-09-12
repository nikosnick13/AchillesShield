namespace AchillesShield.DTO.Auth;

public class LoginResponse
{
    public string Token { get; set; } = null!;
    public int UserId { get; set; }
    public string Username { get; set; } = null!;
    public string Role { get; set; } = null!;
}