using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;
using Test.Models;

namespace Sistema_gestion_funeraria.Models.Model_Configuration
{
    public class LibroFirmaConfiguration : IEntityTypeConfiguration<LibroFirma>
    {
         public void Configure(EntityTypeBuilder<LibroFirma> entity)
         {
            
                entity.HasKey(e => e.IdLibroFirma).HasName("PK__Libro_Fi__4A04D334864E53AC");

                entity.ToTable("Libro_Firmas");

                entity.Property(e => e.IdLibroFirma).HasColumnName("ID_Libro_Firma");
                entity.Property(e => e.IdDifunto).HasColumnName("ID_Difunto");
                entity.Property(e => e.Mensaje).HasMaxLength(500);
                entity.Property(e => e.NombreFirma)
                    .HasMaxLength(100)
                    .HasColumnName("Nombre_Firma");

                entity.HasOne(d => d.IdDifuntoNavigation).WithMany(p => p.LibroFirmas)
                    .HasForeignKey(d => d.IdDifunto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Libro_Firmas_Difuntos");
            
         }
    }
}
