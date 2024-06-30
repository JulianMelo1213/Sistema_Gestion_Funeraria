using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sistema_gestion_funeraria.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Atributos",
                columns: table => new
                {
                    ID_Atributo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Atributo__5ECA4A186BBE52E3", x => x.ID_Atributo);
                });

            migrationBuilder.CreateTable(
                name: "Cargos",
                columns: table => new
                {
                    ID_Cargo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Cargo__8D69B95FB68199D1", x => x.ID_Cargo);
                });

            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    ID_Categoria = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Total_Cobertura = table.Column<decimal>(type: "decimal(12,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Categori__02AA0785B34B9C91", x => x.ID_Categoria);
                });

            migrationBuilder.CreateTable(
                name: "Jornada_Laborales",
                columns: table => new
                {
                    ID_Jornada_Laboral = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha_Entrada = table.Column<DateOnly>(type: "date", nullable: false),
                    Fecha_Salida = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Jornada___4D9539810E0370F1", x => x.ID_Jornada_Laboral);
                });

            migrationBuilder.CreateTable(
                name: "Localidad",
                columns: table => new
                {
                    ID_Localidad = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Localida__8ACE3DA1F196609E", x => x.ID_Localidad);
                });

            migrationBuilder.CreateTable(
                name: "Servicios",
                columns: table => new
                {
                    ID_Servicio = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Costo = table.Column<decimal>(type: "decimal(12,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Servicio__1932F584415698B8", x => x.ID_Servicio);
                });

            migrationBuilder.CreateTable(
                name: "Tipo_Identificaciones",
                columns: table => new
                {
                    ID_TipoIdentificacion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Tipo_Ide__2D8D9EE1D17D799B", x => x.ID_TipoIdentificacion);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Atributos_Categorias",
                columns: table => new
                {
                    ID_Atributo = table.Column<int>(type: "int", nullable: false),
                    ID_Categoria = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Atributo__1EE0EA6043280821", x => new { x.ID_Atributo, x.ID_Categoria });
                    table.ForeignKey(
                        name: "FK__Atributo___ID_At__2E1BDC42",
                        column: x => x.ID_Atributo,
                        principalTable: "Atributos",
                        principalColumn: "ID_Atributo");
                    table.ForeignKey(
                        name: "FK__Atributo___ID_Ca__2F10007B",
                        column: x => x.ID_Categoria,
                        principalTable: "Categorias",
                        principalColumn: "ID_Categoria");
                });

            migrationBuilder.CreateTable(
                name: "Salas",
                columns: table => new
                {
                    ID_Sala = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Capacidad = table.Column<int>(type: "int", nullable: false),
                    Estatus = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: false),
                    ID_Categoria = table.Column<int>(type: "int", nullable: false),
                    ID_Localidad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Salas__2071DEA7B374F345", x => x.ID_Sala);
                    table.ForeignKey(
                        name: "FK__Salas__ID_Catego__29572725",
                        column: x => x.ID_Categoria,
                        principalTable: "Categorias",
                        principalColumn: "ID_Categoria");
                    table.ForeignKey(
                        name: "FK__Salas__ID_Locali__286302EC",
                        column: x => x.ID_Localidad,
                        principalTable: "Localidad",
                        principalColumn: "ID_Localidad");
                });

            migrationBuilder.CreateTable(
                name: "Facturas_Servicios",
                columns: table => new
                {
                    ID_Servicio = table.Column<int>(type: "int", nullable: false),
                    ID_Difunto = table.Column<int>(type: "int", nullable: false),
                    Costo = table.Column<decimal>(type: "decimal(12,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Facturac__87371E6E5CF4A5BB", x => new { x.ID_Servicio, x.ID_Difunto });
                    table.ForeignKey(
                        name: "FK__Facturaci__ID_Se__4D94879B",
                        column: x => x.ID_Servicio,
                        principalTable: "Servicios",
                        principalColumn: "ID_Servicio");
                });

            migrationBuilder.CreateTable(
                name: "Servicios_Categorias",
                columns: table => new
                {
                    ID_Servicio = table.Column<int>(type: "int", nullable: false),
                    ID_Categoria = table.Column<int>(type: "int", nullable: false),
                    Costo = table.Column<decimal>(type: "decimal(12,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Servicio__591855FC0A40FA83", x => new { x.ID_Servicio, x.ID_Categoria });
                    table.ForeignKey(
                        name: "FK__Servicios__ID_Ca__34C8D9D1",
                        column: x => x.ID_Categoria,
                        principalTable: "Categorias",
                        principalColumn: "ID_Categoria");
                    table.ForeignKey(
                        name: "FK__Servicios__ID_Se__33D4B598",
                        column: x => x.ID_Servicio,
                        principalTable: "Servicios",
                        principalColumn: "ID_Servicio");
                });

            migrationBuilder.CreateTable(
                name: "Empleados",
                columns: table => new
                {
                    ID_Empleado = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumDocumento = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    ID_TipoIdentificacion = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    ID_Cargo = table.Column<int>(type: "int", nullable: false),
                    ID_Jornada_Laboral = table.Column<int>(type: "int", nullable: false),
                    ID_Localidad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Empleado__B7872C90AFF4E8ED", x => x.ID_Empleado);
                    table.ForeignKey(
                        name: "FK_Empleados_Cargos",
                        column: x => x.ID_Cargo,
                        principalTable: "Cargos",
                        principalColumn: "ID_Cargo");
                    table.ForeignKey(
                        name: "FK_Empleados_Jornada_Laborales",
                        column: x => x.ID_Jornada_Laboral,
                        principalTable: "Jornada_Laborales",
                        principalColumn: "ID_Jornada_Laboral");
                    table.ForeignKey(
                        name: "FK_Empleados_Localidad",
                        column: x => x.ID_Localidad,
                        principalTable: "Localidad",
                        principalColumn: "ID_Localidad");
                    table.ForeignKey(
                        name: "FK_Empleados_Tipo_Identificaciones",
                        column: x => x.ID_TipoIdentificacion,
                        principalTable: "Tipo_Identificaciones",
                        principalColumn: "ID_TipoIdentificacion");
                });

            migrationBuilder.CreateTable(
                name: "Difuntos",
                columns: table => new
                {
                    ID_Difunto = table.Column<int>(type: "int", nullable: false),
                    Nombre_Difunto = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ID_TipoIdentificacion = table.Column<int>(type: "int", nullable: false),
                    Identificacion = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Representante = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Representante_Telefono = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: true),
                    Fecha_Fallecimiento = table.Column<DateOnly>(type: "date", nullable: false),
                    Horario_Entrada = table.Column<TimeOnly>(type: "time", nullable: false),
                    Horario_Salida = table.Column<TimeOnly>(type: "time", nullable: false),
                    Certificacion_Defuncion = table.Column<byte[]>(type: "image", nullable: false),
                    ID_Sala = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Defuncio__E05EBEA85A1B991F", x => x.ID_Difunto);
                    table.ForeignKey(
                        name: "FK_Difuntos_Salas",
                        column: x => x.ID_Sala,
                        principalTable: "Salas",
                        principalColumn: "ID_Sala");
                    table.ForeignKey(
                        name: "FK_Difuntos_Tipo_Identificaciones",
                        column: x => x.ID_Difunto,
                        principalTable: "Tipo_Identificaciones",
                        principalColumn: "ID_TipoIdentificacion");
                });

            migrationBuilder.CreateTable(
                name: "Libro_Firmas",
                columns: table => new
                {
                    ID_Libro_Firma = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_Difunto = table.Column<int>(type: "int", nullable: false),
                    Nombre_Firma = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Mensaje = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Libro_Fi__4A04D334864E53AC", x => x.ID_Libro_Firma);
                    table.ForeignKey(
                        name: "FK_Libro_Firmas_Difuntos",
                        column: x => x.ID_Difunto,
                        principalTable: "Difuntos",
                        principalColumn: "ID_Difunto");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Atributos_Categorias_ID_Categoria",
                table: "Atributos_Categorias",
                column: "ID_Categoria");

            migrationBuilder.CreateIndex(
                name: "IX_Difuntos_ID_Sala",
                table: "Difuntos",
                column: "ID_Sala");

            migrationBuilder.CreateIndex(
                name: "IX_Empleados_ID_Cargo",
                table: "Empleados",
                column: "ID_Cargo");

            migrationBuilder.CreateIndex(
                name: "IX_Empleados_ID_Jornada_Laboral",
                table: "Empleados",
                column: "ID_Jornada_Laboral");

            migrationBuilder.CreateIndex(
                name: "IX_Empleados_ID_Localidad",
                table: "Empleados",
                column: "ID_Localidad");

            migrationBuilder.CreateIndex(
                name: "IX_Empleados_ID_TipoIdentificacion",
                table: "Empleados",
                column: "ID_TipoIdentificacion");

            migrationBuilder.CreateIndex(
                name: "IX_Libro_Firmas_ID_Difunto",
                table: "Libro_Firmas",
                column: "ID_Difunto");

            migrationBuilder.CreateIndex(
                name: "IX_Salas_ID_Categoria",
                table: "Salas",
                column: "ID_Categoria");

            migrationBuilder.CreateIndex(
                name: "IX_Salas_ID_Localidad",
                table: "Salas",
                column: "ID_Localidad");

            migrationBuilder.CreateIndex(
                name: "IX_Servicios_Categorias_ID_Categoria",
                table: "Servicios_Categorias",
                column: "ID_Categoria");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Atributos_Categorias");

            migrationBuilder.DropTable(
                name: "Empleados");

            migrationBuilder.DropTable(
                name: "Facturas_Servicios");

            migrationBuilder.DropTable(
                name: "Libro_Firmas");

            migrationBuilder.DropTable(
                name: "Servicios_Categorias");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Atributos");

            migrationBuilder.DropTable(
                name: "Cargos");

            migrationBuilder.DropTable(
                name: "Jornada_Laborales");

            migrationBuilder.DropTable(
                name: "Difuntos");

            migrationBuilder.DropTable(
                name: "Servicios");

            migrationBuilder.DropTable(
                name: "Salas");

            migrationBuilder.DropTable(
                name: "Tipo_Identificaciones");

            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropTable(
                name: "Localidad");
        }
    }
}
