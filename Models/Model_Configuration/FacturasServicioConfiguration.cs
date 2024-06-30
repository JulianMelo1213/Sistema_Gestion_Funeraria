using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Sistema_gestion_funeraria.Models.Model_Configuration
{
    public class FacturasServicioConfiguration : IEntityTypeConfiguration<FacturasServicio>
    {
        public void Configure(EntityTypeBuilder<FacturasServicio> entity)
        {
            entity.HasKey(e => new { e.IdServicio, e.IdDifunto }).HasName("PK__Facturac__87371E6E5CF4A5BB");

            entity.ToTable("Facturas_Servicios");

            entity.Property(e => e.IdServicio).HasColumnName("ID_Servicio");
            entity.Property(e => e.IdDifunto).HasColumnName("ID_Difunto");
            entity.Property(e => e.Costo).HasColumnType("decimal(12, 2)");

            entity.HasOne(d => d.IdServicioNavigation).WithMany(p => p.FacturasServicios)
                .HasForeignKey(d => d.IdServicio)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Facturaci__ID_Se__4D94879B");
        }
    }
}
