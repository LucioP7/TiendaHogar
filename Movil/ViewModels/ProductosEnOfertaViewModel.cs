using Movil.Class;
using Service.Models;
using Service.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace Movil.ViewModels
{
    public class ProductosEnOfertaViewModel : ObjectNotification
    {
        private readonly ProductoService productoService = new ProductoService();

        private string filterProducts = string.Empty;
        public string FilterProducts
        {
            get => filterProducts;
            set { filterProducts = value; OnPropertyChanged(); _ = FiltrarProducto(); }
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

        private bool activityStart;
        public bool ActivityStart
        {
            get => activityStart;
            set { activityStart = value; OnPropertyChanged(); }
        }

        public Command ObtenerProductosCommand { get; }
        public Command FiltrarProductosCommand { get; }

        public ProductosEnOfertaViewModel()
        {
            ObtenerProductosCommand = new Command(async () => await ObtenerProductos());
            FiltrarProductosCommand = new Command(async () => await FiltrarProducto());
            _ = ObtenerProductos();
        }

        private async Task FiltrarProducto()
        {
            if (productosListToFilter == null)
                return;

            var term = FilterProducts ?? string.Empty;

            var productosFiltrados = productosListToFilter
                .Where(p => p.Oferta &&
                            (p.Nombre ?? string.Empty).Contains(term, System.StringComparison.OrdinalIgnoreCase));

            Productos = new ObservableCollection<Producto>(productosFiltrados);
        }

        public async Task ObtenerProductos()
        {
            FilterProducts = string.Empty;
            ActivityStart = true;
            productosListToFilter = await productoService.GetAllAsync();

            var productosEnOferta = (productosListToFilter ?? new List<Producto>())
                .Where(p => p.Oferta)
                .ToList();

            Productos = new ObservableCollection<Producto>(productosEnOferta);
            ActivityStart = false;
        }
    }
}
