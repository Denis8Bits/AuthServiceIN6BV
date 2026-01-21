using AuthServiceIN6BV.Application.DTOs;

namespace AuthServiceIN6BV.Domain.Dtos;

public class AuthResponseDto
{
    public bool Succes { get; set; } = true;
    public string Message { get; set; } = string.Empty;
    public string Token { get; set; } = string.Empty;
    public UserDetailsDto UserDetailsDto { get; set;} = new();
    public DateTime ExpiresAt {get; set;}
}