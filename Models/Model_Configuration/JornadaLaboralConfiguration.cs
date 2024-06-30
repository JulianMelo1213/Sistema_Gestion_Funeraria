using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;
using Sistema_gestion_funeraria.Models;

namespace Sistema_gestion_funeraria.Models.Model_Configuration
{
    public class JornadaLaboralConfiguration : IEntityTypeConfiguration<JornadaLaborale>
    {
        public void Configure(EntityTypeBuilder<JornadaLaborale> entity)
        {
           
           entity.HasKey(e => e.IdJornadaLaboral).HasName("PK__Jornada___4D9539810E0370F1");

           entity.ToTable("Jornada_Laborales");

           entity.Property(e => e.IdJornadaLaboral).HasColumnName("ID_Jornada_Laboral");
           entity.Property(e => e.FechaEntrada).HasColumnName("Fecha_Entrada");
           entity.Property(e => e.FechaSalida).HasColumnName("Fecha_Salida");
           

        }
    }
}
