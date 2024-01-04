using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.EntityConfigurations;

public class BrandConfiguration : IEntityTypeConfiguration<Brand>
{
    public void Configure(EntityTypeBuilder<Brand> builder)
    {
        builder.ToTable("Brands").HasKey(brand=>brand.Id);

        builder.Property(brand => brand.Id).HasColumnName("Id").IsRequired();
        builder.Property(brand => brand.Name).HasColumnName("Name").IsRequired();
        builder.Property(brand => brand.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(brand => brand.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(brand => brand.DeletedDate).HasColumnName("DeletedDate");

        builder.HasIndex(indexExpression: brand => brand.Name, name: "UK_Brands_Name").IsUnique();
        builder.HasMany(brand => brand.Models);

        //GlobalFilter
        builder.HasQueryFilter(brand => !brand.DeletedDate.HasValue);
    }
}
