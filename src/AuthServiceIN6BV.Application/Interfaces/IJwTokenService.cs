using System.ComponentModel.DataAnnotations;
using AuthServiceIN6BV.Domain.Entities;
namespace AuthServiceIN6BV.Application.Interfaces;

public interface IJwTokenService
{
    string GenerateToken(User user);
    
}