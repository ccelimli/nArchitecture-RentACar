using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class ModelConfiguration : IEntityTypeConfiguration<Model>
{
    public void Configure(EntityTypeBuilder<Model> builder)
    {
        builder.ToTable("Models").HasKey(model => model.Id);

        builder.Property(model => model.Id).HasColumnName("Id").IsRequired();
        builder.Property(model => model.Name).HasColumnName("Name").IsRequired();
        builder.Property(model => model.BrandId).HasColumnName("BrandId").IsRequired();
        builder.Property(model => model.FuelId).HasColumnName("FuelId").IsRequired();
        builder.Property(model => model.TransmissionId).HasColumnName("TransmissionId").IsRequired();
        builder.Property(model => model.DailyPrice).HasColumnName("DailyPrice").IsRequired();
        builder.Property(model => model.ImageUrl).HasColumnName("ImageUrl").IsRequired();


        builder.Property(model => model.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(model => model.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(model => model.DeletedDate).HasColumnName("DeletedDate");

        builder.HasIndex(indexExpression: model => model.Name, name: "UK_Models_Name").IsUnique();

        builder.HasOne(model => model.Brand);
        builder.HasOne(model => model.Fuel);
        builder.HasOne(model => model.Transmission);

        builder.HasMany(model => model.Cars);

        builder.HasQueryFilter(model => !model.DeletedDate.HasValue);
    }
}
