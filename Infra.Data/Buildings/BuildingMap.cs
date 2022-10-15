using Domain.Buildings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Data.Buildings
{
    public class BuildingMap : IEntityTypeConfiguration<Domain.Buildings.Building>
    {
        public void Configure(EntityTypeBuilder<Building> builder)
        {
            builder.Property(c => c.Name)
                .IsRequired();

            builder.Property(c => c.RoomAmount)
                .IsRequired();

            builder.Property(c => c.Meters)
                .IsRequired();

            builder.ToTable(nameof(Domain.Buildings.Building));
        }
    }
}