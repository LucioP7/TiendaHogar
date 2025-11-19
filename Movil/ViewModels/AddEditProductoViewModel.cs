using CommunityToolkit.Mvvm.Messaging;
using Movil.Class;
using Service.Models;
using Service.Services;
using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Movil.ViewModels
{
    public class AddEditProductoViewModel : ObjectNotification
    {
        // Servicio de productos (manteniendo el campo solicitado)
        ProductoService productoService = new ProductoService();
        // Servicios genéricos para catálogos
        private readonly GenericService<Categoria> categoriaService = new();
        private readonly GenericService<Marca> marcaService = new();
        private readonly GenericService<Proveedor> proveedorService = new();

        private Producto? editProduct;
        public Producto? EditProduct
        {
            get => editProduct;
            set
            {
                editProduct = value;
                OnPropertyChanged();
                SettingData();
            }
        }

        // Propiedades básicas
        private string nombre = string.Empty;
        public string Nombre
        {
            get => nombre;
            set { nombre = value; OnPropertyChanged(); SaveProductCommand.ChangeCanExecute(); }
        }

        private string descripcion = string.Empty;
        public string Descripcion
        {
            get => descripcion;
            set { descripcion = value; OnPropertyChanged(); SaveProductCommand.ChangeCanExecute(); }
        }

        private decimal precio;
        public decimal Precio
        {
            get => precio;
            set { precio = value; OnPropertyChanged(); SaveProductCommand.ChangeCanExecute(); }
        }

        // Para binding del Entry de precio y permitir estados intermedios ("120.")
        private string precioTexto = string.Empty;
        public string PrecioTexto
        {
            get => precioTexto;
            set
            {
                if (precioTexto == value) return;
                precioTexto = value;
                // Intentar parsear con culturas comunes
                if (decimal.TryParse(value, NumberStyles.Number, CultureInfo.CurrentCulture, out var d) ||
                    decimal.TryParse(value, NumberStyles.Number, CultureInfo.InvariantCulture, out d))
                {
                    Precio = d;
                }
                OnPropertyChanged();
                SaveProductCommand.ChangeCanExecute();
            }
        }

        private bool oferta;
        public bool Oferta
        {
            get => oferta;
            set { oferta = value; OnPropertyChanged(); }
        }

        private string imagen = string.Empty;
        public string Imagen
        {
            get => imagen;
            set { imagen = value; OnPropertyChanged(); }
        }

        // Catálogos
        public ObservableCollection<Categoria> Categorias { get; private set; } = new();
        public ObservableCollection<Marca> Marcas { get; private set; } = new();
        public ObservableCollection<Proveedor> Proveedores { get; private set; } = new();

        private Categoria? selectedCategoria;
        public Categoria? SelectedCategoria
        {
            get => selectedCategoria;
            set { selectedCategoria = value; OnPropertyChanged(); SaveProductCommand.ChangeCanExecute(); }
        }

        private Marca? selectedMarca;
        public Marca? SelectedMarca
        {
            get => selectedMarca;
            set { selectedMarca = value; OnPropertyChanged(); SaveProductCommand.ChangeCanExecute(); }
        }

        private Proveedor? selectedProveedor;
        public Proveedor? SelectedProveedor
        {
            get => selectedProveedor;
            set { selectedProveedor = value; OnPropertyChanged(); SaveProductCommand.ChangeCanExecute(); }
        }

        public Command SaveProductCommand { get; }

        public AddEditProductoViewModel()
        {
            SaveProductCommand = new Command(async () => await SaveProduct(), CanSave);
            _ = LoadLookups();
        }

        private bool CanSave()
        {
            return !string.IsNullOrWhiteSpace(Nombre) &&
                   !string.IsNullOrWhiteSpace(Descripcion) &&
                   Precio > 0 &&
                   SelectedCategoria != null &&
                   SelectedMarca != null &&
                   SelectedProveedor != null;
        }

        private async Task LoadLookups()
        {
            try
            {
                var categorias = await categoriaService.GetAllAsync();
                var marcas = await marcaService.GetAllAsync();
                var proveedores = await proveedorService.GetAllAsync();

                if (categorias != null)
                    Categorias = new ObservableCollection<Categoria>(categorias);
                if (marcas != null)
                    Marcas = new ObservableCollection<Marca>(marcas);
                if (proveedores != null)
                    Proveedores = new ObservableCollection<Proveedor>(proveedores);

                OnPropertyChanged(nameof(Categorias));
                OnPropertyChanged(nameof(Marcas));
                OnPropertyChanged(nameof(Proveedores));

                // Si estamos editando, establecer selección ahora que hay datos
                if (editProduct != null)
                {
                    SelectedCategoria = Categorias.FirstOrDefault(c => c.Id == editProduct.CategoriaId);
                    SelectedMarca = Marcas.FirstOrDefault(m => m.Id == editProduct.MarcaId);
                    SelectedProveedor = Proveedores.FirstOrDefault(p => p.Id == editProduct.ProveedorId);
                }

                SaveProductCommand.ChangeCanExecute();
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", "No se pudieron cargar los catálogos:\n" + ex.Message, "OK");
            }
        }

        private void SettingData()
        {
            if (editProduct == null)
            {
                Nombre = string.Empty;
                Descripcion = string.Empty;
                Precio = 0;
                PrecioTexto = string.Empty;
                Oferta = false;
                Imagen = string.Empty;
                SelectedCategoria = null;
                SelectedMarca = null;
                SelectedProveedor = null;
            }
            else
            {
                Nombre = editProduct.Nombre;
                Descripcion = editProduct.Descripcion;
                Precio = editProduct.Precio;
                PrecioTexto = editProduct.Precio.ToString(CultureInfo.InvariantCulture);
                Oferta = editProduct.Oferta;
                Imagen = editProduct.Imagen ?? string.Empty;

                // Intentar preselección (puede que aún no estén cargadas las listas)
                SelectedCategoria = Categorias.FirstOrDefault(c => c.Id == editProduct.CategoriaId);
                SelectedMarca = Marcas.FirstOrDefault(m => m.Id == editProduct.MarcaId);
                SelectedProveedor = Proveedores.FirstOrDefault(p => p.Id == editProduct.ProveedorId);
            }
            SaveProductCommand.ChangeCanExecute();
        }

        private async Task SaveProduct()
        {
            try
            {
                if (EditProduct != null)
                {
                    editProduct.Nombre = Nombre;
                    editProduct.Descripcion = Descripcion;
                    editProduct.Precio = Precio;
                    editProduct.Oferta = Oferta;
                    editProduct.Imagen = string.IsNullOrWhiteSpace(Imagen) ? null : Imagen;
                    editProduct.CategoriaId = SelectedCategoria?.Id ?? 0;
                    editProduct.MarcaId = SelectedMarca?.Id ?? 0;
                    editProduct.ProveedorId = SelectedProveedor?.Id ?? 0;

                    await productoService.UpdateAsync(editProduct);
                }
                else
                {
                    var nuevo = new Producto
                    {
                        Nombre = Nombre,
                        Descripcion = Descripcion,
                        Precio = Precio,
                        Oferta = Oferta,
                        Imagen = string.IsNullOrWhiteSpace(Imagen) ? null : Imagen,
                        CategoriaId = SelectedCategoria?.Id ?? 0,
                        MarcaId = SelectedMarca?.Id ?? 0,
                        ProveedorId = SelectedProveedor?.Id ?? 0
                    };
                    await productoService.AddAsync(nuevo);
                }

                await Shell.Current.GoToAsync("//nuestra_app/productos/ListaProductos");
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", "No se pudo guardar el producto:\n" + ex.Message, "OK");
            }
        }
    }
}


