using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;
using Test.Models;

namespace Sistema_gestion_funeraria.Models.Model_Configuration
{
    public class EmpleadoConfiguration : IEntityTypeConfiguration<Empleado>
    {
        public void Configure(EntityTypeBuilder<Empleado> entity)
        {
               entity.HasKey(e => e.IdEmpleado).HasName("PK__Empleado__B7872C90AFF4E8ED");

                entity.Property(e => e.IdEmpleado).HasColumnName("ID_Empleado");
                entity.Property(e => e.Direccion).HasMaxLength(200);
                entity.Property(e => e.IdCargo).HasColumnName("ID_Cargo");
                entity.Property(e => e.IdJornadaLaboral).HasColumnName("ID_Jornada_Laboral");
                entity.Property(e => e.IdLocalidad).HasColumnName("ID_Localidad");
                entity.Property(e => e.IdTipoIdentificacion).HasColumnName("ID_TipoIdentificacion");
                entity.Property(e => e.Nombre).HasMaxLength(100);
                entity.Property(e => e.NumDocumento).HasMaxLength(11);
                entity.Property(e => e.Telefono).HasMaxLength(10);

                entity.HasOne(d => d.IdCargoNavigation).WithMany(p => p.Empleados)
                    .HasForeignKey(d => d.IdCargo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Empleados_Cargos");

                entity.HasOne(d => d.IdJornadaLaboralNavigation).WithMany(p => p.Empleados)
                    .HasForeignKey(d => d.IdJornadaLaboral)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Empleados_Jornada_Laborales");

                entity.HasOne(d => d.IdLocalidadNavigation).WithMany(p => p.Empleados)
                    .HasForeignKey(d => d.IdLocalidad)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Empleados_Localidad");

                entity.HasOne(d => d.IdTipoIdentificacionNavigation).WithMany(p => p.Empleados)
                    .HasForeignKey(d => d.IdTipoIdentificacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Empleados_Tipo_Identificaciones");
            
        }
    }
}
