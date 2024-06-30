﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Sistema_gestion_funeraria.Migrations
{
    [DbContext(typeof(FunerariaContext))]
    partial class FunerariaContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AtributosCategoria", b =>
                {
                    b.Property<int>("IdAtributo")
                        .HasColumnType("int")
                        .HasColumnName("ID_Atributo");

                    b.Property<int>("IdCategoria")
                        .HasColumnType("int")
                        .HasColumnName("ID_Categoria");

                    b.HasKey("IdAtributo", "IdCategoria")
                        .HasName("PK__Atributo__1EE0EA6043280821");

                    b.HasIndex("IdCategoria");

                    b.ToTable("Atributos_Categorias", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Sistema_gestion_funeraria.Models.AppUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Test.Models.Atributo", b =>
                {
                    b.Property<int>("IdAtributo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID_Atributo");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdAtributo"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("IdAtributo")
                        .HasName("PK__Atributo__5ECA4A186BBE52E3");

                    b.ToTable("Atributos");
                });

            modelBuilder.Entity("Test.Models.Cargo", b =>
                {
                    b.Property<int>("IdCargo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID_Cargo");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCargo"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IdCargo")
                        .HasName("PK__Cargo__8D69B95FB68199D1");

                    b.ToTable("Cargos");
                });

            modelBuilder.Entity("Test.Models.Categoria", b =>
                {
                    b.Property<int>("IdCategoria")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID_Categoria");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCategoria"));

                    b.Property<string>("Descripcion")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal>("TotalCobertura")
                        .HasColumnType("decimal(12, 2)")
                        .HasColumnName("Total_Cobertura");

                    b.HasKey("IdCategoria")
                        .HasName("PK__Categori__02AA0785B34B9C91");

                    b.ToTable("Categorias");
                });

            modelBuilder.Entity("Test.Models.Difunto", b =>
                {
                    b.Property<int>("IdDifunto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID_Difunto");

                    b.Property<byte[]>("CertificacionDefuncion")
                        .IsRequired()
                        .HasColumnType("image")
                        .HasColumnName("Certificacion_Defuncion");

                    b.Property<DateOnly>("FechaFallecimiento")
                        .HasColumnType("date")
                        .HasColumnName("Fecha_Fallecimiento");

                    b.Property<TimeOnly>("HorarioEntrada")
                        .HasColumnType("time")
                        .HasColumnName("Horario_Entrada");

                    b.Property<TimeOnly>("HorarioSalida")
                        .HasColumnType("time")
                        .HasColumnName("Horario_Salida");

                    b.Property<int>("IdSala")
                        .HasColumnType("int")
                        .HasColumnName("ID_Sala");

                    b.Property<int>("IdTipoIdentificacion")
                        .HasColumnType("int")
                        .HasColumnName("ID_TipoIdentificacion");

                    b.Property<string>("Identificacion")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<string>("NombreDifunto")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Nombre_Difunto");

                    b.Property<string>("Representante")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("RepresentanteTelefono")
                        .HasMaxLength(9)
                        .HasColumnType("nvarchar(9)")
                        .HasColumnName("Representante_Telefono");

                    b.HasKey("IdDifunto")
                        .HasName("PK__Defuncio__E05EBEA85A1B991F");

                    b.HasIndex("IdSala");

                    b.ToTable("Difuntos");
                });

            modelBuilder.Entity("Test.Models.Empleado", b =>
                {
                    b.Property<int>("IdEmpleado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID_Empleado");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdEmpleado"));

                    b.Property<string>("Direccion")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("IdCargo")
                        .HasColumnType("int")
                        .HasColumnName("ID_Cargo");

                    b.Property<int>("IdJornadaLaboral")
                        .HasColumnType("int")
                        .HasColumnName("ID_Jornada_Laboral");

                    b.Property<int>("IdLocalidad")
                        .HasColumnType("int")
                        .HasColumnName("ID_Localidad");

                    b.Property<int>("IdTipoIdentificacion")
                        .HasColumnType("int")
                        .HasColumnName("ID_TipoIdentificacion");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("NumDocumento")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("IdEmpleado")
                        .HasName("PK__Empleado__B7872C90AFF4E8ED");

                    b.HasIndex("IdCargo");

                    b.HasIndex("IdJornadaLaboral");

                    b.HasIndex("IdLocalidad");

                    b.HasIndex("IdTipoIdentificacion");

                    b.ToTable("Empleados");
                });

            modelBuilder.Entity("Test.Models.FacturasServicio", b =>
                {
                    b.Property<int>("IdServicio")
                        .HasColumnType("int")
                        .HasColumnName("ID_Servicio");

                    b.Property<int>("IdDifunto")
                        .HasColumnType("int")
                        .HasColumnName("ID_Difunto");

                    b.Property<decimal>("Costo")
                        .HasColumnType("decimal(12, 2)");

                    b.HasKey("IdServicio", "IdDifunto")
                        .HasName("PK__Facturac__87371E6E5CF4A5BB");

                    b.ToTable("Facturas_Servicios", (string)null);
                });

            modelBuilder.Entity("Test.Models.JornadaLaborale", b =>
                {
                    b.Property<int>("IdJornadaLaboral")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID_Jornada_Laboral");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdJornadaLaboral"));

                    b.Property<DateOnly>("FechaEntrada")
                        .HasColumnType("date")
                        .HasColumnName("Fecha_Entrada");

                    b.Property<DateOnly>("FechaSalida")
                        .HasColumnType("date")
                        .HasColumnName("Fecha_Salida");

                    b.HasKey("IdJornadaLaboral")
                        .HasName("PK__Jornada___4D9539810E0370F1");

                    b.ToTable("Jornada_Laborales", (string)null);
                });

            modelBuilder.Entity("Test.Models.LibroFirma", b =>
                {
                    b.Property<int>("IdLibroFirma")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID_Libro_Firma");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdLibroFirma"));

                    b.Property<int>("IdDifunto")
                        .HasColumnType("int")
                        .HasColumnName("ID_Difunto");

                    b.Property<string>("Mensaje")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("NombreFirma")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Nombre_Firma");

                    b.HasKey("IdLibroFirma")
                        .HasName("PK__Libro_Fi__4A04D334864E53AC");

                    b.HasIndex("IdDifunto");

                    b.ToTable("Libro_Firmas", (string)null);
                });

            modelBuilder.Entity("Test.Models.Localidad", b =>
                {
                    b.Property<int>("IdLocalidad")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID_Localidad");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdLocalidad"));

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("IdLocalidad")
                        .HasName("PK__Localida__8ACE3DA1F196609E");

                    b.ToTable("Localidad", (string)null);
                });

            modelBuilder.Entity("Test.Models.Sala", b =>
                {
                    b.Property<int>("IdSala")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID_Sala");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdSala"));

                    b.Property<int>("Capacidad")
                        .HasColumnType("int");

                    b.Property<string>("Estatus")
                        .IsRequired()
                        .HasMaxLength(1)
                        .IsUnicode(false)
                        .HasColumnType("char(1)")
                        .IsFixedLength();

                    b.Property<int>("IdCategoria")
                        .HasColumnType("int")
                        .HasColumnName("ID_Categoria");

                    b.Property<int>("IdLocalidad")
                        .HasColumnType("int")
                        .HasColumnName("ID_Localidad");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("IdSala")
                        .HasName("PK__Salas__2071DEA7B374F345");

                    b.HasIndex("IdCategoria");

                    b.HasIndex("IdLocalidad");

                    b.ToTable("Salas");
                });

            modelBuilder.Entity("Test.Models.Servicio", b =>
                {
                    b.Property<int>("IdServicio")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID_Servicio");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdServicio"));

                    b.Property<decimal>("Costo")
                        .HasColumnType("decimal(12, 2)");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IdServicio")
                        .HasName("PK__Servicio__1932F584415698B8");

                    b.ToTable("Servicios");
                });

            modelBuilder.Entity("Test.Models.ServiciosCategoria", b =>
                {
                    b.Property<int>("IdServicio")
                        .HasColumnType("int")
                        .HasColumnName("ID_Servicio");

                    b.Property<int>("IdCategoria")
                        .HasColumnType("int")
                        .HasColumnName("ID_Categoria");

                    b.Property<decimal>("Costo")
                        .HasColumnType("decimal(12, 2)");

                    b.HasKey("IdServicio", "IdCategoria")
                        .HasName("PK__Servicio__591855FC0A40FA83");

                    b.HasIndex("IdCategoria");

                    b.ToTable("Servicios_Categorias", (string)null);
                });

            modelBuilder.Entity("Test.Models.TipoIdentificacione", b =>
                {
                    b.Property<int>("IdTipoIdentificacion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID_TipoIdentificacion");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdTipoIdentificacion"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("IdTipoIdentificacion")
                        .HasName("PK__Tipo_Ide__2D8D9EE1D17D799B");

                    b.ToTable("Tipo_Identificaciones", (string)null);
                });

            modelBuilder.Entity("AtributosCategoria", b =>
                {
                    b.HasOne("Test.Models.Atributo", null)
                        .WithMany()
                        .HasForeignKey("IdAtributo")
                        .IsRequired()
                        .HasConstraintName("FK__Atributo___ID_At__2E1BDC42");

                    b.HasOne("Test.Models.Categoria", null)
                        .WithMany()
                        .HasForeignKey("IdCategoria")
                        .IsRequired()
                        .HasConstraintName("FK__Atributo___ID_Ca__2F10007B");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Sistema_gestion_funeraria.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Sistema_gestion_funeraria.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Sistema_gestion_funeraria.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Sistema_gestion_funeraria.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Test.Models.Difunto", b =>
                {
                    b.HasOne("Test.Models.TipoIdentificacione", "IdDifuntoNavigation")
                        .WithOne("Difunto")
                        .HasForeignKey("Test.Models.Difunto", "IdDifunto")
                        .IsRequired()
                        .HasConstraintName("FK_Difuntos_Tipo_Identificaciones");

                    b.HasOne("Test.Models.Sala", "IdSalaNavigation")
                        .WithMany("Difuntos")
                        .HasForeignKey("IdSala")
                        .IsRequired()
                        .HasConstraintName("FK_Difuntos_Salas");

                    b.Navigation("IdDifuntoNavigation");

                    b.Navigation("IdSalaNavigation");
                });

            modelBuilder.Entity("Test.Models.Empleado", b =>
                {
                    b.HasOne("Test.Models.Cargo", "IdCargoNavigation")
                        .WithMany("Empleados")
                        .HasForeignKey("IdCargo")
                        .IsRequired()
                        .HasConstraintName("FK_Empleados_Cargos");

                    b.HasOne("Test.Models.JornadaLaborale", "IdJornadaLaboralNavigation")
                        .WithMany("Empleados")
                        .HasForeignKey("IdJornadaLaboral")
                        .IsRequired()
                        .HasConstraintName("FK_Empleados_Jornada_Laborales");

                    b.HasOne("Test.Models.Localidad", "IdLocalidadNavigation")
                        .WithMany("Empleados")
                        .HasForeignKey("IdLocalidad")
                        .IsRequired()
                        .HasConstraintName("FK_Empleados_Localidad");

                    b.HasOne("Test.Models.TipoIdentificacione", "IdTipoIdentificacionNavigation")
                        .WithMany("Empleados")
                        .HasForeignKey("IdTipoIdentificacion")
                        .IsRequired()
                        .HasConstraintName("FK_Empleados_Tipo_Identificaciones");

                    b.Navigation("IdCargoNavigation");

                    b.Navigation("IdJornadaLaboralNavigation");

                    b.Navigation("IdLocalidadNavigation");

                    b.Navigation("IdTipoIdentificacionNavigation");
                });

            modelBuilder.Entity("Test.Models.FacturasServicio", b =>
                {
                    b.HasOne("Test.Models.Servicio", "IdServicioNavigation")
                        .WithMany("FacturasServicios")
                        .HasForeignKey("IdServicio")
                        .IsRequired()
                        .HasConstraintName("FK__Facturaci__ID_Se__4D94879B");

                    b.Navigation("IdServicioNavigation");
                });

            modelBuilder.Entity("Test.Models.LibroFirma", b =>
                {
                    b.HasOne("Test.Models.Difunto", "IdDifuntoNavigation")
                        .WithMany("LibroFirmas")
                        .HasForeignKey("IdDifunto")
                        .IsRequired()
                        .HasConstraintName("FK_Libro_Firmas_Difuntos");

                    b.Navigation("IdDifuntoNavigation");
                });

            modelBuilder.Entity("Test.Models.Sala", b =>
                {
                    b.HasOne("Test.Models.Categoria", "IdCategoriaNavigation")
                        .WithMany("Salas")
                        .HasForeignKey("IdCategoria")
                        .IsRequired()
                        .HasConstraintName("FK__Salas__ID_Catego__29572725");

                    b.HasOne("Test.Models.Localidad", "IdLocalidadNavigation")
                        .WithMany("Salas")
                        .HasForeignKey("IdLocalidad")
                        .IsRequired()
                        .HasConstraintName("FK__Salas__ID_Locali__286302EC");

                    b.Navigation("IdCategoriaNavigation");

                    b.Navigation("IdLocalidadNavigation");
                });

            modelBuilder.Entity("Test.Models.ServiciosCategoria", b =>
                {
                    b.HasOne("Test.Models.Categoria", "IdCategoriaNavigation")
                        .WithMany("ServiciosCategoria")
                        .HasForeignKey("IdCategoria")
                        .IsRequired()
                        .HasConstraintName("FK__Servicios__ID_Ca__34C8D9D1");

                    b.HasOne("Test.Models.Servicio", "IdServicioNavigation")
                        .WithMany("ServiciosCategoria")
                        .HasForeignKey("IdServicio")
                        .IsRequired()
                        .HasConstraintName("FK__Servicios__ID_Se__33D4B598");

                    b.Navigation("IdCategoriaNavigation");

                    b.Navigation("IdServicioNavigation");
                });

            modelBuilder.Entity("Test.Models.Cargo", b =>
                {
                    b.Navigation("Empleados");
                });

            modelBuilder.Entity("Test.Models.Categoria", b =>
                {
                    b.Navigation("Salas");

                    b.Navigation("ServiciosCategoria");
                });

            modelBuilder.Entity("Test.Models.Difunto", b =>
                {
                    b.Navigation("LibroFirmas");
                });

            modelBuilder.Entity("Test.Models.JornadaLaborale", b =>
                {
                    b.Navigation("Empleados");
                });

            modelBuilder.Entity("Test.Models.Localidad", b =>
                {
                    b.Navigation("Empleados");

                    b.Navigation("Salas");
                });

            modelBuilder.Entity("Test.Models.Sala", b =>
                {
                    b.Navigation("Difuntos");
                });

            modelBuilder.Entity("Test.Models.Servicio", b =>
                {
                    b.Navigation("FacturasServicios");

                    b.Navigation("ServiciosCategoria");
                });

            modelBuilder.Entity("Test.Models.TipoIdentificacione", b =>
                {
                    b.Navigation("Difunto");

                    b.Navigation("Empleados");
                });
#pragma warning restore 612, 618
        }
    }
}
