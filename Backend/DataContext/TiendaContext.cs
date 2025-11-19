using Microsoft.EntityFrameworkCore;
using Service.Models;

namespace Backend.DataContext
{
    public partial class TiendaContext : DbContext
    {
        public TiendaContext()
        {
        }

        public TiendaContext(DbContextOptions<TiendaContext> options)
            : base(options)
        {
        }

        #region DbSets
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Localidad> Localidades { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Marca> Marcas { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Proveedor> Proveedores { get; set; }
        public DbSet<Venta> Ventas { get; set; }
        public DbSet<DetalleVenta> DetallesVenta { get; set; }
        public DbSet<Compra> Compras { get; set; }
        public DbSet<DetalleCompra> DetallesCompra { get; set; }
        #endregion

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
                string? cadenaConexion = configuration.GetConnectionString("mysqlRemoto");

                optionsBuilder.UseMySql(cadenaConexion, ServerVersion.AutoDetect(cadenaConexion));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region datos semillas localidad
            // Localidades
            modelBuilder.Entity<Localidad>().HasData(
                new Localidad { Id = 1, Nombre = "Córdoba", Eliminado = false },
                new Localidad { Id = 2, Nombre = "Villa María", Eliminado = false },
                new Localidad { Id = 3, Nombre = "Río Cuarto", Eliminado = false },
                new Localidad { Id = 4, Nombre = "San Francisco", Eliminado = false },
                new Localidad { Id = 5, Nombre = "Alta Gracia", Eliminado = false },
                new Localidad { Id = 6, Nombre = "Carlos Paz", Eliminado = false },
                new Localidad { Id = 7, Nombre = "Jesús María", Eliminado = false },
                new Localidad { Id = 8, Nombre = "Villa Dolores", Eliminado = false },
                new Localidad { Id = 9, Nombre = "La Falda", Eliminado = false },
                new Localidad { Id = 10, Nombre = "Cosquín", Eliminado = false }
            );
            #endregion
            #region datos semilla proveedor
            // Proveedores
            modelBuilder.Entity<Proveedor>().HasData(
                new Proveedor { Id = 1, Nombre = "Distribuidora Sur", Direccion = "Av. Colón 123", Telefonos = "3511234567", Cuit = "20-12345678-1", CondicionIva = Service.Enums.CondicionIvaEnum.ResponsableInscripto, LocalidadId = 1, Eliminado = false },
                new Proveedor { Id = 2, Nombre = "Mayorista Norte", Direccion = "San Martín 456", Telefonos = "3512345678", Cuit = "20-23456789-2", CondicionIva = Service.Enums.CondicionIvaEnum.Monotributista, LocalidadId = 2, Eliminado = false },
                new Proveedor { Id = 3, Nombre = "Almacén Central", Direccion = "Belgrano 789", Telefonos = "3513456789", Cuit = "20-34567890-3", CondicionIva = Service.Enums.CondicionIvaEnum.ConsumidorFinal, LocalidadId = 3, Eliminado = false },
                new Proveedor { Id = 4, Nombre = "Mercado Oeste", Direccion = "Rivadavia 321", Telefonos = "3514567890", Cuit = "20-45678901-4", CondicionIva = Service.Enums.CondicionIvaEnum.ResponsableNoInscripto, LocalidadId = 4, Eliminado = false },
                new Proveedor { Id = 5, Nombre = "Distribuidora Este", Direccion = "Mitre 654", Telefonos = "3515678901", Cuit = "20-56789012-5", CondicionIva = Service.Enums.CondicionIvaEnum.Exento, LocalidadId = 5, Eliminado = false },
                new Proveedor { Id = 6, Nombre = "Mayorista Sur", Direccion = "Sarmiento 987", Telefonos = "3516789012", Cuit = "20-67890123-6", CondicionIva = Service.Enums.CondicionIvaEnum.NoResponsable, LocalidadId = 6, Eliminado = false },
                new Proveedor { Id = 7, Nombre = "Almacén Norte", Direccion = "Urquiza 159", Telefonos = "3517890123", Cuit = "20-78901234-7", CondicionIva = Service.Enums.CondicionIvaEnum.SujetoNoCategorizado, LocalidadId = 7, Eliminado = false },
                new Proveedor { Id = 8, Nombre = "Mercado Central", Direccion = "Lavalle 753", Telefonos = "3518901234", Cuit = "20-89012345-8", CondicionIva = Service.Enums.CondicionIvaEnum.Monotributista, LocalidadId = 8, Eliminado = false },
                new Proveedor { Id = 9, Nombre = "Distribuidora Norte", Direccion = "Moreno 357", Telefonos = "3519012345", Cuit = "20-90123456-9", CondicionIva = Service.Enums.CondicionIvaEnum.ResponsableInscripto, LocalidadId = 9, Eliminado = false },
                new Proveedor { Id = 10, Nombre = "Mayorista Central", Direccion = "Alvear 951", Telefonos = "3510123456", Cuit = "20-01234567-0", CondicionIva = Service.Enums.CondicionIvaEnum.ConsumidorFinal, LocalidadId = 10, Eliminado = false }
            );
            #endregion
            #region datos semilla categoria
            // Categorías
            modelBuilder.Entity<Categoria>().HasData(
                new Categoria { Id = 1, Nombre = "Electrodomésticos", Descripcion = "Productos eléctricos para el hogar", Eliminado = false },
                new Categoria { Id = 2, Nombre = "Limpieza", Descripcion = "Productos de limpieza", Eliminado = false },
                new Categoria { Id = 3, Nombre = "Alimentos", Descripcion = "Comestibles y bebidas", Eliminado = false },
                new Categoria { Id = 4, Nombre = "Bazar", Descripcion = "Artículos de bazar", Eliminado = false },
                new Categoria { Id = 5, Nombre = "Juguetería", Descripcion = "Juguetes y juegos", Eliminado = false },
                new Categoria { Id = 6, Nombre = "Textil", Descripcion = "Ropa y accesorios", Eliminado = false },
                new Categoria { Id = 7, Nombre = "Ferretería", Descripcion = "Herramientas y materiales", Eliminado = false },
                new Categoria { Id = 8, Nombre = "Perfumería", Descripcion = "Perfumes y cosméticos", Eliminado = false },
                new Categoria { Id = 9, Nombre = "Papelería", Descripcion = "Útiles escolares y oficina", Eliminado = false },
                new Categoria { Id = 10, Nombre = "Mascotas", Descripcion = "Productos para mascotas", Eliminado = false }
            );
            #endregion
            #region datos semilla marca
            // Marcas
            modelBuilder.Entity<Marca>().HasData(
                new Marca { Id = 1, Nombre = "Philips", Eliminado = false },
                new Marca { Id = 2, Nombre = "Samsung", Eliminado = false },
                new Marca { Id = 3, Nombre = "LG", Eliminado = false },
                new Marca { Id = 4, Nombre = "Ariel", Eliminado = false },
                new Marca { Id = 5, Nombre = "Coca-Cola", Eliminado = false },
                new Marca { Id = 6, Nombre = "Tupperware", Eliminado = false },
                new Marca { Id = 7, Nombre = "Mattel", Eliminado = false },
                new Marca { Id = 8, Nombre = "Levis", Eliminado = false },
                new Marca { Id = 9, Nombre = "Tramontina", Eliminado = false },
                new Marca { Id = 10, Nombre = "Nestlé", Eliminado = false }
            );
            #endregion
            #region datos semilla cliente
            // Clientes
            modelBuilder.Entity<Cliente>().HasData(
                new Cliente { Id = 1, Nombre = "Juan Pérez", Dni = "30123456", Email = "juan.perez@email.com", Direccion = "Calle Falsa 123", Telefono = "3511111111", LocalidadId = 1, Eliminado = false },
                new Cliente { Id = 2, Nombre = "María Gómez", Dni = "30234567", Email = "maria.gomez@email.com", Direccion = "Av. Siempreviva 742", Telefono = "3512222222", LocalidadId = 2, Eliminado = false },
                new Cliente { Id = 3, Nombre = "Carlos López", Dni = "30345678", Email = "carlos.lopez@email.com", Direccion = "San Martín 100", Telefono = "3513333333", LocalidadId = 3, Eliminado = false },
                new Cliente { Id = 4, Nombre = "Ana Torres", Dni = "30456789", Email = "ana.torres@email.com", Direccion = "Belgrano 200", Telefono = "3514444444", LocalidadId = 4, Eliminado = false },
                new Cliente { Id = 5, Nombre = "Luis Fernández", Dni = "30567890", Email = "luis.fernandez@email.com", Direccion = "Rivadavia 300", Telefono = "3515555555", LocalidadId = 5, Eliminado = false },
                new Cliente { Id = 6, Nombre = "Sofía Ramírez", Dni = "30678901", Email = "sofia.ramirez@email.com", Direccion = "Mitre 400", Telefono = "3516666666", LocalidadId = 6, Eliminado = false },
                new Cliente { Id = 7, Nombre = "Diego Castro", Dni = "30789012", Email = "diego.castro@email.com", Direccion = "Sarmiento 500", Telefono = "3517777777", LocalidadId = 7, Eliminado = false },
                new Cliente { Id = 8, Nombre = "Lucía Martínez", Dni = "30890123", Email = "lucia.martinez@email.com", Direccion = "Urquiza 600", Telefono = "3518888888", LocalidadId = 8, Eliminado = false },
                new Cliente { Id = 9, Nombre = "Javier Ruiz", Dni = "30901234", Email = "javier.ruiz@email.com", Direccion = "Lavalle 700", Telefono = "3519999999", LocalidadId = 9, Eliminado = false },
                new Cliente { Id = 10, Nombre = "Valeria Díaz", Dni = "31012345", Email = "valeria.diaz@email.com", Direccion = "Moreno 800", Telefono = "3511010101", LocalidadId = 10, Eliminado = false }
            );
            #endregion
            #region datos semilla producto
            // Productos
            modelBuilder.Entity<Producto>().HasData(
                new Producto { Id = 1, Nombre = "Televisor LED 32", Descripcion = "Smart TV Philips", Precio = 120000, Eliminado = false, Oferta = true, Imagen = "tv32.jpg", CategoriaId = 1, MarcaId = 1, ProveedorId = 1 },
                new Producto { Id = 2, Nombre = "Lavadora Automática", Descripcion = "Samsung 7kg", Precio = 180000, Eliminado = false, Oferta = false, Imagen = "lavadora.jpg", CategoriaId = 1, MarcaId = 2, ProveedorId = 2 },
                new Producto { Id = 3, Nombre = "Detergente Ariel", Descripcion = "1L", Precio = 1200, Eliminado = false, Oferta = false, Imagen = "ariel.jpg", CategoriaId = 2, MarcaId = 4, ProveedorId = 3 },
                new Producto { Id = 4, Nombre = "Coca-Cola 2L", Descripcion = "Bebida gaseosa", Precio = 800, Eliminado = false, Oferta = true, Imagen = "cocacola.jpg", CategoriaId = 3, MarcaId = 5, ProveedorId = 4 },
                new Producto { Id = 5, Nombre = "Tupperware Grande", Descripcion = "Contenedor plástico", Precio = 1500, Eliminado = false, Oferta = false, Imagen = "tupperware.jpg", CategoriaId = 4, MarcaId = 6, ProveedorId = 5 },
                new Producto { Id = 6, Nombre = "Muñeca Barbie", Descripcion = "Mattel original", Precio = 3500, Eliminado = false, Oferta = true, Imagen = "barbie.jpg", CategoriaId = 5, MarcaId = 7, ProveedorId = 6 },
                new Producto { Id = 7, Nombre = "Jeans Levis", Descripcion = "Talle 42", Precio = 9000, Eliminado = false, Oferta = false, Imagen = "levis.jpg", CategoriaId = 6, MarcaId = 8, ProveedorId = 7 },
                new Producto { Id = 8, Nombre = "Martillo Tramontina", Descripcion = "Acero forjado", Precio = 2500, Eliminado = false, Oferta = false, Imagen = "martillo.jpg", CategoriaId = 7, MarcaId = 9, ProveedorId = 8 },
                new Producto { Id = 9, Nombre = "Perfume Nestlé", Descripcion = "Fragancia floral", Precio = 5000, Eliminado = false, Oferta = true, Imagen = "perfume.jpg", CategoriaId = 8, MarcaId = 10, ProveedorId = 9 },
                new Producto { Id = 10, Nombre = "Alimento Mascotas", Descripcion = "Bolsa 10kg", Precio = 7000, Eliminado = false, Oferta = false, Imagen = "mascotas.jpg", CategoriaId = 10, MarcaId = 10, ProveedorId = 10 }
            );
            #endregion
            #region datos semillas compras
            // Compras
            modelBuilder.Entity<Compra>().HasData(
                new Compra { Id = 1, FormaDePago = Service.Enums.FormaDePagoEnum.Efectivo, Iva = 21, Total = 120000, Fecha = DateTime.Now.AddDays(-30), ProveedorId = 1, Eliminado = false },
                new Compra { Id = 2, FormaDePago = Service.Enums.FormaDePagoEnum.Tarjeta_Credito, Iva = 21, Total = 180000, Fecha = DateTime.Now.AddDays(-29), ProveedorId = 2, Eliminado = false },
                new Compra { Id = 3, FormaDePago = Service.Enums.FormaDePagoEnum.Transferencia, Iva = 21, Total = 1200, Fecha = DateTime.Now.AddDays(-28), ProveedorId = 3, Eliminado = false },
                new Compra { Id = 4, FormaDePago = Service.Enums.FormaDePagoEnum.Efectivo, Iva = 21, Total = 800, Fecha = DateTime.Now.AddDays(-27), ProveedorId = 4, Eliminado = false },
                new Compra { Id = 5, FormaDePago = Service.Enums.FormaDePagoEnum.Tarjeta_Debito, Iva = 21, Total = 1500, Fecha = DateTime.Now.AddDays(-26), ProveedorId = 5, Eliminado = false },
                new Compra { Id = 6, FormaDePago = Service.Enums.FormaDePagoEnum.Transferencia, Iva = 21, Total = 3500, Fecha = DateTime.Now.AddDays(-25), ProveedorId = 6, Eliminado = false },
                new Compra { Id = 7, FormaDePago = Service.Enums.FormaDePagoEnum.Efectivo, Iva = 21, Total = 9000, Fecha = DateTime.Now.AddDays(-24), ProveedorId = 7, Eliminado = false },
                new Compra { Id = 8, FormaDePago = Service.Enums.FormaDePagoEnum.Tarjeta_Credito, Iva = 21, Total = 2500, Fecha = DateTime.Now.AddDays(-23), ProveedorId = 8, Eliminado = false },
                new Compra { Id = 9, FormaDePago = Service.Enums.FormaDePagoEnum.Tarjeta_Debito, Iva = 21, Total = 5000, Fecha = DateTime.Now.AddDays(-22), ProveedorId = 9, Eliminado = false },
                new Compra { Id = 10, FormaDePago = Service.Enums.FormaDePagoEnum.Efectivo, Iva = 21, Total = 7000, Fecha = DateTime.Now.AddDays(-21), ProveedorId = 10, Eliminado = false }
            );
            #endregion
            #region datos semillas ventas
            // Ventas
            modelBuilder.Entity<Venta>().HasData(
                new Venta { Id = 1, Fecha = DateTime.Now.AddDays(-20), ClienteId = 1, FormaPago = Service.Enums.FormaDePagoEnum.Efectivo, Iva = 21, Total = 120000, Eliminado = false },
                new Venta { Id = 2, Fecha = DateTime.Now.AddDays(-19), ClienteId = 2, FormaPago = Service.Enums.FormaDePagoEnum.Tarjeta_Credito, Iva = 21, Total = 180000, Eliminado = false },
                new Venta { Id = 3, Fecha = DateTime.Now.AddDays(-18), ClienteId = 3, FormaPago = Service.Enums.FormaDePagoEnum.Transferencia, Iva = 21, Total = 1200, Eliminado = false },
                new Venta { Id = 4, Fecha = DateTime.Now.AddDays(-17), ClienteId = 4, FormaPago = Service.Enums.FormaDePagoEnum.Efectivo, Iva = 21, Total = 800, Eliminado = false },
                new Venta { Id = 5, Fecha = DateTime.Now.AddDays(-16), ClienteId = 5, FormaPago = Service.Enums.FormaDePagoEnum.Tarjeta_Debito, Iva = 21, Total = 1500, Eliminado = false },
                new Venta { Id = 6, Fecha = DateTime.Now.AddDays(-15), ClienteId = 6, FormaPago = Service.Enums.FormaDePagoEnum.Transferencia, Iva = 21, Total = 3500, Eliminado = false },
                new Venta { Id = 7, Fecha = DateTime.Now.AddDays(-14), ClienteId = 7, FormaPago = Service.Enums.FormaDePagoEnum.Efectivo, Iva = 21, Total = 9000, Eliminado = false },
                new Venta { Id = 8, Fecha = DateTime.Now.AddDays(-13), ClienteId = 8, FormaPago = Service.Enums.FormaDePagoEnum.Tarjeta_Credito, Iva = 21, Total = 2500, Eliminado = false },
                new Venta { Id = 9, Fecha = DateTime.Now.AddDays(-12), ClienteId = 9, FormaPago = Service.Enums.FormaDePagoEnum.Tarjeta_Debito, Iva = 21, Total = 5000, Eliminado = false },
                new Venta { Id = 10, Fecha = DateTime.Now.AddDays(-11), ClienteId = 10, FormaPago = Service.Enums.FormaDePagoEnum.Efectivo, Iva = 21, Total = 7000, Eliminado = false }
            );
            #endregion
            #region datos semillas detallescompras

            // DetallesCompra
            modelBuilder.Entity<DetalleCompra>().HasData(
                new DetalleCompra { Id = 1, ProductoId = 1, PrecioUnitario = 120000, Cantidad = 1, CompraId = 1, Eliminado = false },
                new DetalleCompra { Id = 2, ProductoId = 2, PrecioUnitario = 180000, Cantidad = 1, CompraId = 2, Eliminado = false },
                new DetalleCompra { Id = 3, ProductoId = 3, PrecioUnitario = 1200, Cantidad = 1, CompraId = 3, Eliminado = false },
                new DetalleCompra { Id = 4, ProductoId = 4, PrecioUnitario = 800, Cantidad = 1, CompraId = 4, Eliminado = false },
                new DetalleCompra { Id = 5, ProductoId = 5, PrecioUnitario = 1500, Cantidad = 1, CompraId = 5, Eliminado = false },
                new DetalleCompra { Id = 6, ProductoId = 6, PrecioUnitario = 3500, Cantidad = 1, CompraId = 6, Eliminado = false },
                new DetalleCompra { Id = 7, ProductoId = 7, PrecioUnitario = 9000, Cantidad = 1, CompraId = 7, Eliminado = false },
                new DetalleCompra { Id = 8, ProductoId = 8, PrecioUnitario = 2500, Cantidad = 1, CompraId = 8, Eliminado = false },
                new DetalleCompra { Id = 9, ProductoId = 9, PrecioUnitario = 5000, Cantidad = 1, CompraId = 9, Eliminado = false },
                new DetalleCompra { Id = 10, ProductoId = 10, PrecioUnitario = 7000, Cantidad = 1, CompraId = 10, Eliminado = false }
            );
            #endregion
            #region datos semillas detallesventas
            // DetallesVenta
            modelBuilder.Entity<DetalleVenta>().HasData(
                new DetalleVenta { Id = 1, VentaId = 1, ProductoId = 1, PrecioUnitario = 120000, Cantidad = 1, Eliminado = false },
                new DetalleVenta { Id = 2, VentaId = 2, ProductoId = 2, PrecioUnitario = 180000, Cantidad = 1, Eliminado = false },
                new DetalleVenta { Id = 3, VentaId = 3, ProductoId = 3, PrecioUnitario = 1200, Cantidad = 1, Eliminado = false },
                new DetalleVenta { Id = 4, VentaId = 4, ProductoId = 4, PrecioUnitario = 800, Cantidad = 1, Eliminado = false },
                new DetalleVenta { Id = 5, VentaId = 5, ProductoId = 5, PrecioUnitario = 1500, Cantidad = 1, Eliminado = false },
                new DetalleVenta { Id = 6, VentaId = 6, ProductoId = 6, PrecioUnitario = 3500, Cantidad = 1, Eliminado = false },
                new DetalleVenta { Id = 7, VentaId = 7, ProductoId = 7, PrecioUnitario = 9000, Cantidad = 1, Eliminado = false },
                new DetalleVenta { Id = 8, VentaId = 8, ProductoId = 8, PrecioUnitario = 2500, Cantidad = 1, Eliminado = false },
                new DetalleVenta { Id = 9, VentaId = 9, ProductoId = 9, PrecioUnitario = 5000, Cantidad = 1, Eliminado = false },
                new DetalleVenta { Id = 10, VentaId = 10, ProductoId = 10, PrecioUnitario = 7000, Cantidad = 1, Eliminado = false }
            );
            #endregion


            #region definición de filtros de eliminación
            // (este código no lo habilitamos todavía porque es cuando agregamos un campo Eliminado a las tablas y modificamos los
            // ApiControllers para que al mandar a eliminar solo cambien este campo y lo pongan en verdadero, esta configuración de
            // eliminación hace que el sistema ignore los registros que tengan el eliminado en verdadero, así que hace que en
            // apariencia y funcionalidad esté "eliminado", pero van a seguir estando ahí para que podamos observar las eliminaciones que hubo)
            modelBuilder.Entity<Cliente>().HasQueryFilter(m => !m.Eliminado);
            modelBuilder.Entity<Compra>().HasQueryFilter(m => !m.Eliminado);
            modelBuilder.Entity<DetalleCompra>().HasQueryFilter(m => !m.Eliminado);
            modelBuilder.Entity<DetalleVenta>().HasQueryFilter(m => !m.Eliminado);
            modelBuilder.Entity<Localidad>().HasQueryFilter(m => !m.Eliminado);
            modelBuilder.Entity<Producto>().HasQueryFilter(m => !m.Eliminado);
            modelBuilder.Entity<Proveedor>().HasQueryFilter(m => !m.Eliminado);
            modelBuilder.Entity<Venta>().HasQueryFilter(m => !m.Eliminado);
            modelBuilder.Entity<Categoria>().HasQueryFilter(m => !m.Eliminado);
            modelBuilder.Entity<Marca>().HasQueryFilter(m => !m.Eliminado);

            #endregion

        }
    }
}
