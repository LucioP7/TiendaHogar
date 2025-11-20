using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class nuevoInicio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Descripcion = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Eliminado = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Localidades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Eliminado = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Localidades", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Marcas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Eliminado = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marcas", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Dni = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Direccion = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Telefono = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LocalidadId = table.Column<int>(type: "int", nullable: false),
                    Eliminado = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clientes_Localidades_LocalidadId",
                        column: x => x.LocalidadId,
                        principalTable: "Localidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Proveedores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Direccion = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Telefonos = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Cuit = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CondicionIva = table.Column<int>(type: "int", nullable: false),
                    LocalidadId = table.Column<int>(type: "int", nullable: true),
                    Eliminado = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proveedores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Proveedores_Localidades_LocalidadId",
                        column: x => x.LocalidadId,
                        principalTable: "Localidades",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Ventas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Fecha = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    FormaPago = table.Column<int>(type: "int", nullable: false),
                    Iva = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Eliminado = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ventas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ventas_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Compras",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FormaDePago = table.Column<int>(type: "int", nullable: false),
                    Iva = table.Column<int>(type: "int", nullable: false),
                    Total = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ProveedorId = table.Column<int>(type: "int", nullable: true),
                    Eliminado = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compras", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Compras_Proveedores_ProveedorId",
                        column: x => x.ProveedorId,
                        principalTable: "Proveedores",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Descripcion = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Precio = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Eliminado = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Oferta = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Imagen = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CategoriaId = table.Column<int>(type: "int", nullable: false),
                    MarcaId = table.Column<int>(type: "int", nullable: false),
                    ProveedorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Productos_Categorias_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categorias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Productos_Marcas_MarcaId",
                        column: x => x.MarcaId,
                        principalTable: "Marcas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Productos_Proveedores_ProveedorId",
                        column: x => x.ProveedorId,
                        principalTable: "Proveedores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "DetallesCompra",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ProductoId = table.Column<int>(type: "int", nullable: false),
                    PrecioUnitario = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    CompraId = table.Column<int>(type: "int", nullable: false),
                    Eliminado = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetallesCompra", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DetallesCompra_Compras_CompraId",
                        column: x => x.CompraId,
                        principalTable: "Compras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetallesCompra_Productos_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Productos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "DetallesVenta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    VentaId = table.Column<int>(type: "int", nullable: false),
                    ProductoId = table.Column<int>(type: "int", nullable: false),
                    PrecioUnitario = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    Eliminado = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetallesVenta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DetallesVenta_Productos_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Productos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetallesVenta_Ventas_VentaId",
                        column: x => x.VentaId,
                        principalTable: "Ventas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Categorias",
                columns: new[] { "Id", "Descripcion", "Eliminado", "Nombre" },
                values: new object[,]
                {
                    { 1, "Productos eléctricos para el hogar", false, "Electrodomésticos" },
                    { 2, "Productos de limpieza", false, "Limpieza" },
                    { 3, "Comestibles y bebidas", false, "Alimentos" },
                    { 4, "Artículos de bazar", false, "Bazar" },
                    { 5, "Juguetes y juegos", false, "Juguetería" },
                    { 6, "Ropa y accesorios", false, "Textil" },
                    { 7, "Herramientas y materiales", false, "Ferretería" },
                    { 8, "Perfumes y cosméticos", false, "Perfumería" },
                    { 9, "Útiles escolares y oficina", false, "Papelería" },
                    { 10, "Productos para mascotas", false, "Mascotas" }
                });

            migrationBuilder.InsertData(
                table: "Localidades",
                columns: new[] { "Id", "Eliminado", "Nombre" },
                values: new object[,]
                {
                    { 1, false, "Córdoba" },
                    { 2, false, "Villa María" },
                    { 3, false, "Río Cuarto" },
                    { 4, false, "San Francisco" },
                    { 5, false, "Alta Gracia" },
                    { 6, false, "Carlos Paz" },
                    { 7, false, "Jesús María" },
                    { 8, false, "Villa Dolores" },
                    { 9, false, "La Falda" },
                    { 10, false, "Cosquín" }
                });

            migrationBuilder.InsertData(
                table: "Marcas",
                columns: new[] { "Id", "Eliminado", "Nombre" },
                values: new object[,]
                {
                    { 1, false, "Philips" },
                    { 2, false, "Samsung" },
                    { 3, false, "LG" },
                    { 4, false, "Ariel" },
                    { 5, false, "Coca-Cola" },
                    { 6, false, "Tupperware" },
                    { 7, false, "Mattel" },
                    { 8, false, "Levis" },
                    { 9, false, "Tramontina" },
                    { 10, false, "Nestlé" }
                });

            migrationBuilder.InsertData(
                table: "Clientes",
                columns: new[] { "Id", "Direccion", "Dni", "Eliminado", "Email", "LocalidadId", "Nombre", "Telefono" },
                values: new object[,]
                {
                    { 1, "Calle Falsa 123", "30123456", false, "juan.perez@email.com", 1, "Juan Pérez", "3511111111" },
                    { 2, "Av. Siempreviva 742", "30234567", false, "maria.gomez@email.com", 2, "María Gómez", "3512222222" },
                    { 3, "San Martín 100", "30345678", false, "carlos.lopez@email.com", 3, "Carlos López", "3513333333" },
                    { 4, "Belgrano 200", "30456789", false, "ana.torres@email.com", 4, "Ana Torres", "3514444444" },
                    { 5, "Rivadavia 300", "30567890", false, "luis.fernandez@email.com", 5, "Luis Fernández", "3515555555" },
                    { 6, "Mitre 400", "30678901", false, "sofia.ramirez@email.com", 6, "Sofía Ramírez", "3516666666" },
                    { 7, "Sarmiento 500", "30789012", false, "diego.castro@email.com", 7, "Diego Castro", "3517777777" },
                    { 8, "Urquiza 600", "30890123", false, "lucia.martinez@email.com", 8, "Lucía Martínez", "3518888888" },
                    { 9, "Lavalle 700", "30901234", false, "javier.ruiz@email.com", 9, "Javier Ruiz", "3519999999" },
                    { 10, "Moreno 800", "31012345", false, "valeria.diaz@email.com", 10, "Valeria Díaz", "3511010101" }
                });

            migrationBuilder.InsertData(
                table: "Proveedores",
                columns: new[] { "Id", "CondicionIva", "Cuit", "Direccion", "Eliminado", "LocalidadId", "Nombre", "Telefonos" },
                values: new object[,]
                {
                    { 1, 0, "20-12345678-1", "Av. Colón 123", false, 1, "Distribuidora Sur", "3511234567" },
                    { 2, 5, "20-23456789-2", "San Martín 456", false, 2, "Mayorista Norte", "3512345678" },
                    { 3, 4, "20-34567890-3", "Belgrano 789", false, 3, "Almacén Central", "3513456789" },
                    { 4, 1, "20-45678901-4", "Rivadavia 321", false, 4, "Mercado Oeste", "3514567890" },
                    { 5, 2, "20-56789012-5", "Mitre 654", false, 5, "Distribuidora Este", "3515678901" },
                    { 6, 3, "20-67890123-6", "Sarmiento 987", false, 6, "Mayorista Sur", "3516789012" },
                    { 7, 6, "20-78901234-7", "Urquiza 159", false, 7, "Almacén Norte", "3517890123" },
                    { 8, 5, "20-89012345-8", "Lavalle 753", false, 8, "Mercado Central", "3518901234" },
                    { 9, 0, "20-90123456-9", "Moreno 357", false, 9, "Distribuidora Norte", "3519012345" },
                    { 10, 4, "20-01234567-0", "Alvear 951", false, 10, "Mayorista Central", "3510123456" }
                });

            migrationBuilder.InsertData(
                table: "Compras",
                columns: new[] { "Id", "Eliminado", "Fecha", "FormaDePago", "Iva", "ProveedorId", "Total" },
                values: new object[,]
                {
                    { 1, false, new DateTime(2025, 10, 21, 1, 38, 54, 95, DateTimeKind.Local).AddTicks(1994), 0, 21, 1, 120000 },
                    { 2, false, new DateTime(2025, 10, 22, 1, 38, 54, 95, DateTimeKind.Local).AddTicks(2017), 1, 21, 2, 180000 },
                    { 3, false, new DateTime(2025, 10, 23, 1, 38, 54, 95, DateTimeKind.Local).AddTicks(2020), 3, 21, 3, 1200 },
                    { 4, false, new DateTime(2025, 10, 24, 1, 38, 54, 95, DateTimeKind.Local).AddTicks(2022), 0, 21, 4, 800 },
                    { 5, false, new DateTime(2025, 10, 25, 1, 38, 54, 95, DateTimeKind.Local).AddTicks(2024), 2, 21, 5, 1500 },
                    { 6, false, new DateTime(2025, 10, 26, 1, 38, 54, 95, DateTimeKind.Local).AddTicks(2026), 3, 21, 6, 3500 },
                    { 7, false, new DateTime(2025, 10, 27, 1, 38, 54, 95, DateTimeKind.Local).AddTicks(2071), 0, 21, 7, 9000 },
                    { 8, false, new DateTime(2025, 10, 28, 1, 38, 54, 95, DateTimeKind.Local).AddTicks(2074), 1, 21, 8, 2500 },
                    { 9, false, new DateTime(2025, 10, 29, 1, 38, 54, 95, DateTimeKind.Local).AddTicks(2075), 2, 21, 9, 5000 },
                    { 10, false, new DateTime(2025, 10, 30, 1, 38, 54, 95, DateTimeKind.Local).AddTicks(2077), 0, 21, 10, 7000 }
                });

            migrationBuilder.InsertData(
                table: "Productos",
                columns: new[] { "Id", "CategoriaId", "Descripcion", "Eliminado", "Imagen", "MarcaId", "Nombre", "Oferta", "Precio", "ProveedorId" },
                values: new object[,]
                {
                    { 1, 1, "Smart TV Philips", false, "tv32.jpg", 1, "Televisor LED 32", true, 120000m, 1 },
                    { 2, 1, "Samsung 7kg", false, "lavadora.jpg", 2, "Lavadora Automática", false, 180000m, 2 },
                    { 3, 2, "1L", false, "ariel.jpg", 4, "Detergente Ariel", false, 1200m, 3 },
                    { 4, 3, "Bebida gaseosa", false, "cocacola.jpg", 5, "Coca-Cola 2L", true, 800m, 4 },
                    { 5, 4, "Contenedor plástico", false, "tupperware.jpg", 6, "Tupperware Grande", false, 1500m, 5 },
                    { 6, 5, "Mattel original", false, "barbie.jpg", 7, "Muñeca Barbie", true, 3500m, 6 },
                    { 7, 6, "Talle 42", false, "levis.jpg", 8, "Jeans Levis", false, 9000m, 7 },
                    { 8, 7, "Acero forjado", false, "martillo.jpg", 9, "Martillo Tramontina", false, 2500m, 8 },
                    { 9, 8, "Fragancia floral", false, "perfume.jpg", 10, "Perfume Nestlé", true, 5000m, 9 },
                    { 10, 10, "Bolsa 10kg", false, "mascotas.jpg", 10, "Alimento Mascotas", false, 7000m, 10 }
                });

            migrationBuilder.InsertData(
                table: "Ventas",
                columns: new[] { "Id", "ClienteId", "Eliminado", "Fecha", "FormaPago", "Iva", "Total" },
                values: new object[,]
                {
                    { 1, 1, false, new DateTime(2025, 10, 31, 1, 38, 54, 95, DateTimeKind.Local).AddTicks(2120), 0, 21m, 120000m },
                    { 2, 2, false, new DateTime(2025, 11, 1, 1, 38, 54, 95, DateTimeKind.Local).AddTicks(2125), 1, 21m, 180000m },
                    { 3, 3, false, new DateTime(2025, 11, 2, 1, 38, 54, 95, DateTimeKind.Local).AddTicks(2128), 3, 21m, 1200m },
                    { 4, 4, false, new DateTime(2025, 11, 3, 1, 38, 54, 95, DateTimeKind.Local).AddTicks(2130), 0, 21m, 800m },
                    { 5, 5, false, new DateTime(2025, 11, 4, 1, 38, 54, 95, DateTimeKind.Local).AddTicks(2133), 2, 21m, 1500m },
                    { 6, 6, false, new DateTime(2025, 11, 5, 1, 38, 54, 95, DateTimeKind.Local).AddTicks(2136), 3, 21m, 3500m },
                    { 7, 7, false, new DateTime(2025, 11, 6, 1, 38, 54, 95, DateTimeKind.Local).AddTicks(2138), 0, 21m, 9000m },
                    { 8, 8, false, new DateTime(2025, 11, 7, 1, 38, 54, 95, DateTimeKind.Local).AddTicks(2140), 1, 21m, 2500m },
                    { 9, 9, false, new DateTime(2025, 11, 8, 1, 38, 54, 95, DateTimeKind.Local).AddTicks(2142), 2, 21m, 5000m },
                    { 10, 10, false, new DateTime(2025, 11, 9, 1, 38, 54, 95, DateTimeKind.Local).AddTicks(2144), 0, 21m, 7000m }
                });

            migrationBuilder.InsertData(
                table: "DetallesCompra",
                columns: new[] { "Id", "Cantidad", "CompraId", "Eliminado", "PrecioUnitario", "ProductoId" },
                values: new object[,]
                {
                    { 1, 1, 1, false, 120000m, 1 },
                    { 2, 1, 2, false, 180000m, 2 },
                    { 3, 1, 3, false, 1200m, 3 },
                    { 4, 1, 4, false, 800m, 4 },
                    { 5, 1, 5, false, 1500m, 5 },
                    { 6, 1, 6, false, 3500m, 6 },
                    { 7, 1, 7, false, 9000m, 7 },
                    { 8, 1, 8, false, 2500m, 8 },
                    { 9, 1, 9, false, 5000m, 9 },
                    { 10, 1, 10, false, 7000m, 10 }
                });

            migrationBuilder.InsertData(
                table: "DetallesVenta",
                columns: new[] { "Id", "Cantidad", "Eliminado", "PrecioUnitario", "ProductoId", "VentaId" },
                values: new object[,]
                {
                    { 1, 1, false, 120000m, 1, 1 },
                    { 2, 1, false, 180000m, 2, 2 },
                    { 3, 1, false, 1200m, 3, 3 },
                    { 4, 1, false, 800m, 4, 4 },
                    { 5, 1, false, 1500m, 5, 5 },
                    { 6, 1, false, 3500m, 6, 6 },
                    { 7, 1, false, 9000m, 7, 7 },
                    { 8, 1, false, 2500m, 8, 8 },
                    { 9, 1, false, 5000m, 9, 9 },
                    { 10, 1, false, 7000m, 10, 10 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_LocalidadId",
                table: "Clientes",
                column: "LocalidadId");

            migrationBuilder.CreateIndex(
                name: "IX_Compras_ProveedorId",
                table: "Compras",
                column: "ProveedorId");

            migrationBuilder.CreateIndex(
                name: "IX_DetallesCompra_CompraId",
                table: "DetallesCompra",
                column: "CompraId");

            migrationBuilder.CreateIndex(
                name: "IX_DetallesCompra_ProductoId",
                table: "DetallesCompra",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_DetallesVenta_ProductoId",
                table: "DetallesVenta",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_DetallesVenta_VentaId",
                table: "DetallesVenta",
                column: "VentaId");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_CategoriaId",
                table: "Productos",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_MarcaId",
                table: "Productos",
                column: "MarcaId");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_ProveedorId",
                table: "Productos",
                column: "ProveedorId");

            migrationBuilder.CreateIndex(
                name: "IX_Proveedores_LocalidadId",
                table: "Proveedores",
                column: "LocalidadId");

            migrationBuilder.CreateIndex(
                name: "IX_Ventas_ClienteId",
                table: "Ventas",
                column: "ClienteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetallesCompra");

            migrationBuilder.DropTable(
                name: "DetallesVenta");

            migrationBuilder.DropTable(
                name: "Compras");

            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "Ventas");

            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropTable(
                name: "Marcas");

            migrationBuilder.DropTable(
                name: "Proveedores");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Localidades");
        }
    }
}
