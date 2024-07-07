using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Sistema_gestion_funeraria.Models.Model_Configuration
{
    public class SalaConfiguration : IEntityTypeConfiguration<Sala>
    {
        public void Configure(EntityTypeBuilder<Sala> entity)
        {
            entity.HasKey(e => e.IdSala).HasName("PK__Salas__2071DEA7B374F345");

            entity.Property(e => e.IdSala).HasColumnName("ID_Sala");
            entity.Property(e => e.Estatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.IdCategoria).HasColumnName("ID_Categoria");
            entity.Property(e => e.IdLocalidad).HasColumnName("ID_Localidad");
            entity.Property(e => e.Nombre).HasMaxLength(100);

            entity.HasOne(d => d.IdCategoriaNavigation).WithMany(p => p.Salas)
                .HasForeignKey(d => d.IdCategoria)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Salas__ID_Catego__29572725");

            entity.HasOne(d => d.IdLocalidadNavigation).WithMany(p => p.Salas)
                .HasForeignKey(d => d.IdLocalidad)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Salas__ID_Locali__286302EC");
        }
    }
}
