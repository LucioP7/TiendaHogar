using Movil.ViewModels;

namespace Movil.Views
{
    public partial class ProductosView : ContentPage
    {
        public ProductosView()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            if (BindingContext is ProductosViewModel viewmodel)
            {
                // Solo cargar si está vacío. No forzar SelectedProduct a null.
                if (viewmodel.Productos == null || viewmodel.Productos.Count == 0)
                {
                    await viewmodel.ObtenerProductos();
                }
            }
        }
    }
}