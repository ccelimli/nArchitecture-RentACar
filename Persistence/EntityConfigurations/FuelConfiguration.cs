using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class FuelConfiguration : IEntityTypeConfiguration<Fuel>
{
    public void Configure(EntityTypeBuilder<Fuel> builder)
    {
        builder.ToTable("Fuels").HasKey(fuel => fuel.Id);

        builder.Property(fuel => fuel.Id).HasColumnName("Id").IsRequired();
        builder.Property(fuel => fuel.Name).HasColumnName("Name").IsRequired();
        builder.Property(fuel => fuel.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(fuel => fuel.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(fuel => fuel.DeletedDate).HasColumnName("DeletedDate");

        builder.HasIndex(indexExpression: fuel => fuel.Name, name: "UK_Fuels_Name").IsUnique();
        builder.HasMany(fuel => fuel.Models);

        //GlobalFilter
        builder.HasQueryFilter(fuel => !fuel.DeletedDate.HasValue);
    }
}
