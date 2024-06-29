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

    public virtual DbSet<Categoria> Categorias { get; set; }

    public virtual DbSet<Difunto> Difuntos { get; set; }

    public virtual DbSet<Empleado> Empleados { get; set; }

    public virtual DbSet<FacturasServicio> FacturasServicios { get; set; }

    public virtual DbSet<JornadaLaborale> JornadaLaborales { get; set; }

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


        modelBuilder.Entity<Cargo>(entity =>
        {
            entity.HasKey(e => e.IdCargo).HasName("PK__Cargo__8D69B95FB68199D1");

            entity.Property(e => e.IdCargo).HasColumnName("ID_Cargo");
            entity.Property(e => e.Descripcion).HasMaxLength(200);
            entity.Property(e => e.Nombre).HasMaxLength(50);
        });

        modelBuilder.Entity<Categoria>(entity =>
        {
            entity.HasKey(e => e.IdCategoria).HasName("PK__Categori__02AA0785B34B9C91");

            entity.Property(e => e.IdCategoria).HasColumnName("ID_Categoria");
            entity.Property(e => e.Descripcion).HasMaxLength(200);
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.TotalCobertura)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("Total_Cobertura");
        });

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

        modelBuilder.Entity<Empleado>(entity =>
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

        modelBuilder.Entity<JornadaLaborale>(entity =>
        {
            entity.HasKey(e => e.IdJornadaLaboral).HasName("PK__Jornada___4D9539810E0370F1");

            entity.ToTable("Jornada_Laborales");

            entity.Property(e => e.IdJornadaLaboral).HasColumnName("ID_Jornada_Laboral");
            entity.Property(e => e.FechaEntrada).HasColumnName("Fecha_Entrada");
            entity.Property(e => e.FechaSalida).HasColumnName("Fecha_Salida");
        });

        modelBuilder.Entity<LibroFirma>(entity =>
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
        });

        modelBuilder.Entity<Localidad>(entity =>
        {
            entity.HasKey(e => e.IdLocalidad).HasName("PK__Localida__8ACE3DA1F196609E");

            entity.ToTable("Localidad");

            entity.Property(e => e.IdLocalidad).HasColumnName("ID_Localidad");
            entity.Property(e => e.Direccion).HasMaxLength(200);
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.Telefono).HasMaxLength(10);
        });

        modelBuilder.Entity<Sala>(entity =>
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

        modelBuilder.Entity<TipoIdentificacione>(entity =>
        {
            entity.HasKey(e => e.IdTipoIdentificacion).HasName("PK__Tipo_Ide__2D8D9EE1D17D799B");

            entity.ToTable("Tipo_Identificaciones");

            entity.Property(e => e.IdTipoIdentificacion).HasColumnName("ID_TipoIdentificacion");
            entity.Property(e => e.Nombre).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
