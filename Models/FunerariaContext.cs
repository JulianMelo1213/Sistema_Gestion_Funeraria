using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Sistema_gestion_funeraria.Models;
using Sistema_gestion_funeraria.Models.Model_Configuration;
namespace Test.Models;

public partial class FunerariaContext : IdentityDbContext<AppUser>
{
    public FunerariaContext()
    {
    }

    

    public FunerariaContext(DbContextOptions<FunerariaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Atributo> Atributos { get; set; }

    public virtual DbSet<Cargo> Cargos { get; set; }

    public virtual DbSet<TipoIdentificacione> Categorias { get; set; }

    public virtual DbSet<Difunto> Difuntos { get; set; }

    public virtual DbSet<Empleado> Empleados { get; set; }

    public virtual DbSet<FacturasServicio> FacturasServicios { get; set; }

    public virtual DbSet<TipoIdentificacione> JornadaLaborales { get; set; }

    public virtual DbSet<LibroFirma> LibroFirmas { get; set; }

    public virtual DbSet<Localidad> Localidads { get; set; }

    public virtual DbSet<Sala> Salas { get; set; }

    public virtual DbSet<Servicio> Servicios { get; set; }

    public virtual DbSet<ServiciosCategoria> ServiciosCategorias { get; set; }

    public virtual DbSet<TipoIdentificacione> TipoIdentificaciones { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("name=DefaultConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new AtributoConfiguration());

        modelBuilder.ApplyConfiguration(new CargoConfiguration());

        modelBuilder.ApplyConfiguration(new CategoriaConfiguration());

        modelBuilder.ApplyConfiguration(new SalaConfiguration());

        modelBuilder.ApplyConfiguration(new LibroFirmaConfiguration());

        modelBuilder.ApplyConfiguration(new EmpleadoConfiguration());

        modelBuilder.ApplyConfiguration(new LocalidadConfiguration());

        modelBuilder.ApplyConfiguration(new ServicioConfiguration());

        modelBuilder.ApplyConfiguration(new JornadaLaboralConfiguration());




        modelBuilder.Entity<Difunto>(entity =>
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
        });

       

        modelBuilder.Entity<FacturasServicio>(entity =>
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
        });

       
        

        

        modelBuilder.Entity<Servicio>(entity =>
        {
            entity.HasKey(e => e.IdServicio).HasName("PK__Servicio__1932F584415698B8");

            entity.Property(e => e.IdServicio).HasColumnName("ID_Servicio");
            entity.Property(e => e.Costo).HasColumnType("decimal(12, 2)");
            entity.Property(e => e.Descripcion).HasMaxLength(200);
            entity.Property(e => e.Nombre).HasMaxLength(50);
        });

        modelBuilder.Entity<ServiciosCategoria>(entity =>
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
        });

        

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
