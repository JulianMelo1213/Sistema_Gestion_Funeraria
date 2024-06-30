using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;
using Test.Models;

namespace Sistema_gestion_funeraria.Models.Model_Configuration
{
    public class TipoIdentificacionConfiguration : IEntityTypeConfiguration<TipoIdentificacione>
    {
        public void Configure(EntityTypeBuilder<TipoIdentificacione> entity)
        {
                entity.HasKey(e => e.IdTipoIdentificacion).HasName("PK__Tipo_Ide__2D8D9EE1D17D799B");

                entity.ToTable("Tipo_Identificaciones");

                entity.Property(e => e.IdTipoIdentificacion).HasColumnName("ID_TipoIdentificacion");
                entity.Property(e => e.Nombre).HasMaxLength(100);
        }
    }
}
