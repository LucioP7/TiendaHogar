using CommunityToolkit.Mvvm.Messaging;
using Movil.Class;
using Movil.ViewModels;

namespace Movil.Views;

public partial class IniciarSesionView : ContentPage
{
	public IniciarSesionView()
	{
		InitializeComponent();

    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        if (BindingContext is IniciarSesionViewModel vm)
        {
            _ = vm.ChequearSiHayUsuarioAlmacenadoAsync();
        }
    }
}