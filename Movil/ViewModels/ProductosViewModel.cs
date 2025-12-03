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
            set
            {
                selectedProduct = value;
                OnPropertyChanged();
                EditarProductoCommand.ChangeCanExecute();
                EliminarProductoCommand.ChangeCanExecute();
            }
        }

        public Command ObtenerProductosCommand { get; }
        public Command FiltrarProductosCommand { get; }
        public Command AgregarProductoCommand { get; }
        public Command EditarProductoCommand { get; }
        public Command EliminarProductoCommand { get; }

        public ProductosViewModel()
        {
            ObtenerProductosCommand = new Command(async () => await ObtenerProductos());
            FiltrarProductosCommand = new Command(async () => await FiltrarProductos());
            AgregarProductoCommand = new Command(async () => await AgregarProducto());
            EditarProductoCommand = new Command(async (_) => await EditarProducto(), _ => SelectedProduct != null);
            EliminarProductoCommand = new Command(async () => await EliminarProducto(), () => SelectedProduct != null);
            _ = ObtenerProductos();
        }

        private async Task EditarProducto()
        {
            var navigationParameter = new ShellNavigationQueryParameters
            {
                { "ProductToEdit", SelectedProduct }
            };
            await Shell.Current.GoToAsync("//nuestra_app/productos/AgregarEditarProducto", navigationParameter);
        }

        private async Task AgregarProducto()
        {
            var navigationParameter = new ShellNavigationQueryParameters
            {
                { "ProductToEdit", null }
            };
            await Shell.Current.GoToAsync("//nuestra_app/productos/AgregarEditarProducto", navigationParameter);
        }

        private async Task EliminarProducto()
        {
            if (SelectedProduct == null)
                return;

            // Confirmación de usuario
            var confirmar = await Application.Current.MainPage.DisplayAlert(
                "Eliminar producto",
                $"¿Desea eliminar \"{SelectedProduct.Nombre}\"?",
                "Eliminar",
                "Cancelar");

            if (!confirmar)
                return;

            try
            {
                // Intenta eliminar por Id si existe; si tu GenericService admite entidad, cámbialo a DeleteAsync(SelectedProduct)
                // Asumiendo una propiedad Id en Producto:
                await productoService.DeleteAsync(SelectedProduct.Id);

                // Quitar de la colección y lista base
                productosListToFilter?.Remove(SelectedProduct);
                Productos.Remove(SelectedProduct);

                // Limpiar selección
                SelectedProduct = null;

                await Application.Current.MainPage.DisplayAlert("Productos", "Producto eliminado correctamente.", "OK");
            }
            catch
            {
                await Application.Current.MainPage.DisplayAlert("Productos", "No se pudo eliminar el producto.", "OK");
            }
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
