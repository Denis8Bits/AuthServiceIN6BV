using AuthServiceIN6BV.Domain.Entities;
using AuthServiceIN6BV.Application.Service;
using AuthServiceIN6BV.Domain.Constants;
using Microsoft.EntityFrameworkCore;
using AuthServiceIN6BV.Application.Services;

namespace AuthServiceIN6BV.Persistence.Data;

public static class DataSeeder
{
    public static async Task SeedAsync(ApplicationDbContext context)
    {
        if (!context.Roles.Any())
        {
            var role = new List<Role>
            {
                new()
                {
                    Id = UuidGenerator.GenerateRoleId(),
                    Name = RoleConstants.ADMIN_ROLE
                },
                new()
                {
                    Id = UuidGenerator.GenerateRoleId(),
                    Name = RoleConstants.USER_ROLE
                }
            };

            await context.Roles.AddRangeAsync(role);
            await context.SaveChangesAsync();
        }

        if (!await context.Users.AnyAsync())
        {
            var adminRole = await context.Roles.FirstOrDefaultAsync(r => r.Name == RoleConstants.ADMIN_ROLE);
            if (adminRole != null)
            {
                var passwordHasher = new PasswordHasServices();
                var profileId = UuidGenerator.GenerateUserId();
                var emailId = UuidGenerator.GenerateUserId();
                var userRoleId = UuidGenerator.GenerateUserId();
                var userId = UuidGenerator.GenerateUserId();

                var adminUser = new User
                {
                    Id = userRoleId,
                    Name = "Admin",
                    Surname = "User",
                    Username = "admin",
                    Email = "admin@ksport.local",
                    Password = passwordHasher.HashPassword("Admin1234!"),
                    Status = true,
                    UserProfile = new UserProfile
                    {
                        Id = profileId,
                        UserId = userId,
                        ProfilePicture = string.Empty,
                        Phone = string.Empty
                    },
                    UserEmail = new UserEmail
                    {
                        Id = emailId,
                        UserId = userId,
                        EmailVerified = true,
                        EmailVerificationToken = null,
                        EmailVerificationTokenExpiry = null,
                    },
                    UserRoles =
                    [
                        new UserRole
                        {
                            Id = userRoleId,
                            UserId = userId,
                            RoleId = adminRole.Id
                        }
                    ]

                };

                await context.Users.AddAsync(adminUser);
                await context.SaveChangesAsync();
            }
        }
    }
}