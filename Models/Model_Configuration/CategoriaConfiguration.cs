using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;
using Sistema_gestion_funeraria.Models;

namespace Sistema_gestion_funeraria.Models.Model_Configuration
{
    public class CategoriaConfiguration : IEntityTypeConfiguration<Categoria>
    {   
        public void Configure(EntityTypeBuilder<Categoria> entity)
        {
            entity.HasKey(e => e.IdCategoria).HasName("PK__Categori__02AA0785B34B9C91");

            entity.Property(e => e.IdCategoria).HasColumnName("ID_Categoria");
            entity.Property(e => e.Descripcion).HasMaxLength(200);
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.TotalCobertura)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("Total_Cobertura");
        }
    }
}
