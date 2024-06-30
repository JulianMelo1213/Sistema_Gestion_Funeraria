using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistema_gestion_funeraria.Models;

namespace Sistema_gestion_funeraria.Models.Model_Configuration
{
    public class DifuntoConfiguration : IEntityTypeConfiguration<Difunto>
    {
        public void Configure(EntityTypeBuilder<Difunto> entity)
        {
            entity.HasKey(e => e.IdDifunto).HasName("PK__Defuncio__E05EBEA85A1B991F");

            entity.Property(e => e.IdDifunto)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID_Difunto");
            entity.Property(e => e.CertificacionDefuncion)
                .HasColumnType("image")
                .HasColumnName("Certificacion_Defuncion");
            entity.Property(e => e.FechaFallecimiento).HasColumnName("Fecha_Fallecimiento");
            entity.Property(e => e.HorarioEntrada).HasColumnName("Horario_Entrada");
            entity.Property(e => e.HorarioSalida).HasColumnName("Horario_Salida");
            entity.Property(e => e.IdSala).HasColumnName("ID_Sala");
            entity.Property(e => e.IdTipoIdentificacion).HasColumnName("ID_TipoIdentificacion");
            entity.Property(e => e.Identificacion).HasMaxLength(11);
            entity.Property(e => e.NombreDifunto)
                .HasMaxLength(100)
                .HasColumnName("Nombre_Difunto");
            entity.Property(e => e.Representante).HasMaxLength(100);
            entity.Property(e => e.RepresentanteTelefono)
                .HasMaxLength(9)
                .HasColumnName("Representante_Telefono");

            entity.HasOne(d => d.IdDifuntoNavigation).WithOne(p => p.Difunto)
                .HasForeignKey<Difunto>(d => d.IdDifunto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Difuntos_Tipo_Identificaciones");

            entity.HasOne(d => d.IdSalaNavigation).WithMany(p => p.Difuntos)
                .HasForeignKey(d => d.IdSala)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Difuntos_Salas");
        }
    }
}
