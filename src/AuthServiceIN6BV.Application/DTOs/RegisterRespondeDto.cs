namespace AuthServiceIN6BV.Application.DTOs;

public class RegisterRespondeDto
{
    public bool Success { get; set; } = false;
    public UserResponseDto User { get; set; } = new();

    public string Message { get; set; } = string.Empty;

    public bool EmailVerificationRequired { get; set; } = true;



}