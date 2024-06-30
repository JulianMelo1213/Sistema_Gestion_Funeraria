using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Sistema_gestion_funeraria.Models.Model_Configuration
{
    public class ServiciosCategoriaConfiguration : IEntityTypeConfiguration<ServiciosCategoria>
    {
        public void Configure(EntityTypeBuilder<ServiciosCategoria> entity)
        {
            entity.HasKey(e => new { e.IdServicio, e.IdCategoria }).HasName("PK__Servicio__591855FC0A40FA83");

            entity.ToTable("Servicios_Categorias");

            entity.Property(e => e.IdServicio).HasColumnName("ID_Servicio");
            entity.Property(e => e.IdCategoria).HasColumnName("ID_Categoria");
            entity.Property(e => e.Costo).HasColumnType("decimal(12, 2)");

            entity.HasOne(d => d.IdCategoriaNavigation).WithMany(p => p.ServiciosCategoria)
                .HasForeignKey(d => d.IdCategoria)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Servicios__ID_Ca__34C8D9D1");

            entity.HasOne(d => d.IdServicioNavigation).WithMany(p => p.ServiciosCategoria)
                .HasForeignKey(d => d.IdServicio)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Servicios__ID_Se__33D4B598");
        }
    }
}
