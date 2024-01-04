using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class TransmissionConfiguration : IEntityTypeConfiguration<Transmission>
{
    public void Configure(EntityTypeBuilder<Transmission> builder)
    {
        builder.ToTable("Transmissions").HasKey(transmission => transmission.Id);

        builder.Property(transmission => transmission.Id).HasColumnName("Id").IsRequired();
        builder.Property(transmission => transmission.Name).HasColumnName("Name").IsRequired();
        builder.Property(transmission => transmission.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(transmission => transmission.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(transmission => transmission.DeletedDate).HasColumnName("DeletedDate");

        builder.HasIndex(indexExpression: transmission => transmission.Name, name: "UK_Transmissions_Name").IsUnique();
        builder.HasMany(transmission => transmission.Models);

        //GlobalFilter
        builder.HasQueryFilter(transmission => !transmission.DeletedDate.HasValue);
    }
}
