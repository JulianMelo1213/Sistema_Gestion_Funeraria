using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;
using Sistema_gestion_funeraria.Models;

namespace Sistema_gestion_funeraria.Models.Model_Configuration
{
    public class CargoConfiguration : IEntityTypeConfiguration<Cargo>
    {
        public void Configure(EntityTypeBuilder<Cargo> entity)
        {
                entity.HasKey(e => e.IdCargo).HasName("PK__Cargo__8D69B95FB68199D1");

                entity.Property(e => e.IdCargo).HasColumnName("ID_Cargo");
                entity.Property(e => e.Descripcion).HasMaxLength(200);
                entity.Property(e => e.Nombre).HasMaxLength(50);
            
        }
    }
}
