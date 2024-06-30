using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;
using Sistema_gestion_funeraria.Models;

namespace Sistema_gestion_funeraria.Models.Model_Configuration
{
    public class LocalidadConfiguration : IEntityTypeConfiguration<Localidad>
    {
        public void Configure(EntityTypeBuilder<Localidad> entity)
        {
            
            entity.HasKey(e => e.IdLocalidad).HasName("PK__Localida__8ACE3DA1F196609E");

            entity.ToTable("Localidad");

            entity.Property(e => e.IdLocalidad).HasColumnName("ID_Localidad");
            entity.Property(e => e.Direccion).HasMaxLength(200);
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.Telefono).HasMaxLength(10);
            
        }
    }
}
