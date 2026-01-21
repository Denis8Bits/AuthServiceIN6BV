using System.ComponentModel.DataAnnotations;
namespace AuthServiceIN6BV.Domain.Entities;

public class User
{
    [Key]
    [MaxLength(16)]
    public string Id { get; set; } = string.Empty;

    [Required(ErrorMessage = "el nombre es obligatorio")]
    [MaxLength(25, ErrorMessage = "el nombre no puede tener mas de 25 caracteres")]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "el apellido es obligatorio")]
    [MaxLength(25, ErrorMessage = "el apellido no puede tener mas de 25 caracteres")]
    public string Surname { get; set; } = string.Empty;


    [Required(ErrorMessage = "el nombre de usuario es obligatorio")]
    [MaxLength(25, ErrorMessage = "el nombre de usuario no puede tener mas de 25 caracteres")]
    public string UserName { get; set; } = string.Empty;

    [Required(ErrorMessage = "el correo es obligatorio")]
    [EmailAddress(ErrorMessage = "el correo no tiene un formato valido")]
    [MaxLength(150, ErrorMessage = "el correo no puede tener mas de 150 caracteres")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "la contrasena es obligatoria")]
    [MinLength(8, ErrorMessage = "la contrasena debe tener al menos 8 caracteres")]
    [MaxLength(255, ErrorMessage = "la contrasena no puede tener mas de 255 caracteres")]
    public string Password { get; set; } = string.Empty;

    public bool Status { get; set; } = false;

    public DateTime CreateAt { get; set; }
    public DateTime UpdateAt { get; set; }

    public UserProfile UserProfile { get; set; } = null!;
    public ICollection<UserRole> UserRoles { get; set; } = [];

    public UserEmail UserEmail { get; set; } = null!;
    public UserPasswordReset UserPasswordReset { get; set; } = null!;
}