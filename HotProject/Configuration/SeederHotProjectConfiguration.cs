using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using Shopping.Models;
using Shopping.Models.Const;

namespace HotProject.Configuration
{
    public class SeederHotProjectConfiguration : IEntityTypeConfiguration<HotProjectObj>
    {
        public void Configure(EntityTypeBuilder<HotProjectObj> builder)
        {
            builder.HasKey(x => x.id);
            builder.Property(x => x.Name).HasMaxLength(ValidConst.MaxLenghtNames);
                
        }
    }
}