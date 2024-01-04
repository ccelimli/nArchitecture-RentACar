using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class CarConfiguration : IEntityTypeConfiguration<Car>
{
    public void Configure(EntityTypeBuilder<Car> builder)
    {
        builder.ToTable("Cars").HasKey(car => car.Id);

        builder.Property(car => car.Id).HasColumnName("Id").IsRequired();
        builder.Property(car => car.ModelId).HasColumnName("ModelId").IsRequired();
        builder.Property(car => car.Kilometer).HasColumnName("Kilometer").IsRequired();
        builder.Property(car => car.CarState).HasColumnName("State").IsRequired();
        builder.Property(car => car.ModelYear).HasColumnName("ModelYear").IsRequired();
        builder.Property(car => car.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(car => car.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(car => car.DeletedDate).HasColumnName("DeletedDate");

        builder.HasOne(car => car.Model);

        //GlobalFilter
        builder.HasQueryFilter(car => !car.DeletedDate.HasValue);
    }
}
