using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Sistema_gestion_funeraria.Models.Model_Configuration;

namespace Sistema_gestion_funeraria.Models;

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

        modelBuilder.ApplyConfiguration(new CargoConfiguration());

        modelBuilder.ApplyConfiguration(new CategoriaConfiguration());

        modelBuilder.ApplyConfiguration(new SalaConfiguration());

        modelBuilder.ApplyConfiguration(new LibroFirmaConfiguration());

        modelBuilder.ApplyConfiguration(new EmpleadoConfiguration());

        modelBuilder.ApplyConfiguration(new LocalidadConfiguration());

        modelBuilder.ApplyConfiguration(new ServicioConfiguration());

        modelBuilder.ApplyConfiguration(new JornadaLaboralConfiguration());

        modelBuilder.ApplyConfiguration(new DifuntoConfiguration());

        modelBuilder.ApplyConfiguration(new ServiciosCategoriaConfiguration());

        modelBuilder.ApplyConfiguration(new FacturasServicioConfiguration());

        modelBuilder.ApplyConfiguration(new FacturasCategoriaConfiguration()); 

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
