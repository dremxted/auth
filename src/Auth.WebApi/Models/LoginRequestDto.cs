namespace Auth.WebApi.Models;

public record LoginRequestDto
{
    public string Username { get; set; } = string.Empty;
}
