using CommunityToolkit.Mvvm.Messaging;
using Movil.Class;
using Service.Models;
using Service.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace Movil.ViewModels
{
    public class ProductosViewModel : ObjectNotification
    {
        private GenericService<Producto> productoService = new GenericService<Producto>();
        private string filterProducts = string.Empty;

        public string FilterProducts
        {
            get => filterProducts;
            set { filterProducts = value; OnPropertyChanged(); _ = FiltrarProductos(); }
        }

        private bool _isRefreshing;
        public bool IsRefreshing
        {
            get => _isRefreshing;
            set { _isRefreshing = value; OnPropertyChanged(); }
        }

        private ObservableCollection<Producto> productos;
        public ObservableCollection<Producto> Productos
        {
            get => productos;
            set { productos = value; OnPropertyChanged(); }
        }

        private List<Producto>? productosListToFilter;
        private Producto? selectedProduct;
        public Producto? SelectedProduct
        {
            get => selectedProduct;
            set { selectedProduct = value; OnPropertyChanged(); EditarProductoCommand.ChangeCanExecute(); }
        }

        public Command ObtenerProductosCommand { get; }
        public Command FiltrarProductosCommand { get; }
        public Command AgregarProductoCommand { get; }
        public Command EditarProductoCommand { get; }

        public ProductosViewModel()
        {
            ObtenerProductosCommand = new Command(async () => await ObtenerProductos());
            FiltrarProductosCommand = new Command(async () => await FiltrarProductos());
            AgregarProductoCommand = new Command(async () => await AgregarProducto());
            EditarProductoCommand = new Command(async (_) => await EditarProducto(), _ => SelectedProduct != null);
            _ = ObtenerProductos();
        }

        private async Task EditarProducto()
        {
            var navigationParameter = new ShellNavigationQueryParameters
            {
                { "ProductToEdit", SelectedProduct }
            };
            // Ruta absoluta completa dentro del Shell
            await Shell.Current.GoToAsync("//nuestra_app/productos/AgregarEditarProducto", navigationParameter);
        }

        private async Task AgregarProducto()
        {
            var navigationParameter = new ShellNavigationQueryParameters
            {
                { "ProductToEdit", null }
            };
            // Ruta absoluta completa dentro del Shell
            await Shell.Current.GoToAsync("//nuestra_app/productos/AgregarEditarProducto", navigationParameter);
        }

        public async Task FiltrarProductos()
        {
            if (productosListToFilter == null)
                return;

            var term = FilterProducts ?? string.Empty;
            if (string.IsNullOrWhiteSpace(term))
            {
                Productos = new ObservableCollection<Producto>(productosListToFilter);
                return;
            }

            var filtrados = productosListToFilter.Where(p =>
                (p.Nombre ?? string.Empty).Contains(term, System.StringComparison.OrdinalIgnoreCase) ||
                (p.Descripcion ?? string.Empty).Contains(term, System.StringComparison.OrdinalIgnoreCase));

            Productos = new ObservableCollection<Producto>(filtrados);
        }

        public async Task ObtenerProductos()
        {
            FilterProducts = string.Empty;
            IsRefreshing = true;
            productosListToFilter = await productoService.GetAllAsync();
            Productos = new ObservableCollection<Producto>(productosListToFilter ?? new List<Producto>());
            IsRefreshing = false;
        }
    }
}
