using Movil.ViewModels;

namespace Movil.Views;

public partial class ProductosEnOfertaView : ContentPage
{
	public ProductosEnOfertaView()
	{
		InitializeComponent();
	}
    protected override void OnAppearing()
    {
        base.OnAppearing();
        var viewmodel = this.BindingContext as ProductosEnOfertaViewModel;
        //if (viewmodel.NotaSeleccionada != null)
        //{
        viewmodel.ObtenerProductos();

        //}
    }
}