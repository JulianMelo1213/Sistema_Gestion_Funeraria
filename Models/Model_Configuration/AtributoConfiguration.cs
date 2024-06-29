using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;
using Test.Models;

namespace Sistema_gestion_funeraria.Models.Model_Configuration
{
    public class AtributoConfiguration : IEntityTypeConfiguration<Atributo>
    {
        public void Configure(EntityTypeBuilder<Atributo> entity)
        {
                entity.HasKey(e => e.IdAtributo).HasName("PK__Atributo__5ECA4A186BBE52E3");

                entity.Property(e => e.IdAtributo).HasColumnName("ID_Atributo");
                entity.Property(e => e.Descripcion).HasMaxLength(200);
                entity.Property(e => e.Nombre).HasMaxLength(100);

                entity.HasMany(d => d.IdCategoria).WithMany(p => p.IdAtributos)
                    .UsingEntity<Dictionary<string, object>>(
                        "AtributosCategoria",
                        r => r.HasOne<TipoIdentificacione>().WithMany()
                            .HasForeignKey("IdCategoria")
                            .OnDelete(DeleteBehavior.ClientSetNull)
                            .HasConstraintName("FK__Atributo___ID_Ca__2F10007B"),
                        l => l.HasOne<Atributo>().WithMany()
                            .HasForeignKey("IdAtributo")
                            .OnDelete(DeleteBehavior.ClientSetNull)
                            .HasConstraintName("FK__Atributo___ID_At__2E1BDC42"),
                        j =>
                        {
                            j.HasKey("IdAtributo", "IdCategoria").HasName("PK__Atributo__1EE0EA6043280821");
                            j.ToTable("Atributos_Categorias");
                            j.IndexerProperty<int>("IdAtributo").HasColumnName("ID_Atributo");
                            j.IndexerProperty<int>("IdCategoria").HasColumnName("ID_Categoria");
                        }
            );
        }
    }
}
