using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Shopping.Models;
using System;

namespace HotProject.Configuration
{
    public class SeederRolesConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            string RoleId = Guid.NewGuid().ToString();

            object value = builder.HasData(
                new IdentityRole() { Id = RoleId, Name = "Admin", ConcurrencyStamp = "1", NormalizedName = "Admin" },
                new IdentityRole() { Id = Guid.NewGuid().ToString(), Name = "user", ConcurrencyStamp = "2", NormalizedName = "Human Resource" }
                );
        }
    }
}