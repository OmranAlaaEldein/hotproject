using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopping.Models;
using Shopping.Models.Const;
using System;

namespace HotProject.Configuration
{
    public class SeederUserConfiguration:IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.Property(p => p.LastName).IsRequired().HasMaxLength(ValidConst.MaxLenghtNames);

            string UserId = Guid.NewGuid().ToString();
            
            var user = new ApplicationUser()
                {
                    Id = UserId,
                    UserName = "Admin",
                    LastName = "Admin",
                    Email = "admin@gmail.com",
                    LockoutEnabled = false,
                    Address = "",
                    PhoneNumber = "",
                };

                PasswordHasher<ApplicationUser> passwordHasher = new PasswordHasher<ApplicationUser>();
                user.PasswordHash= passwordHasher.HashPassword(user, "Admin");

            builder.HasData(user);
        }

    }
}