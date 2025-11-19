using CommunityToolkit.Mvvm.Messaging;
using Movil.Class;
using Movil.ViewModels;
using Movil.Views;
using System.Diagnostics;

namespace Movil
{
    public partial class TiendaShell : Shell
    {
        public TiendaShell()
        {
            InitializeComponent();
            FlyoutItemsPrincipal.IsVisible = false; // Oculta el menú lateral
            RegisterRoutes();

            Navigating += (s, e) =>
            {
                Debug.WriteLine($"[Shell] Navigating: From='{e.Current?.Location}' To='{e.Target.Location}' Source='{e.Source}'");
                if (e.Target.Location.OriginalString.EndsWith("/Login") || e.Target.Location.OriginalString == "//Login")
                {
                    if (BindingContext is TiendaShellViewModel vm)
                        vm.OnLoginScreenRequested();
                }
            };
            Navigated += (s, e) =>
            {
                Debug.WriteLine($"[Shell] Navigated: Current='{e.Current?.Location}' Previous='{e.Previous?.Location}'");
            };
        }

        private void RegisterRoutes()
        {
            Routing.RegisterRoute("Registrarse", typeof(RegistrarseView));
        }

        public void EnableAppAfterLogin()
        {
            FlyoutBehavior = FlyoutBehavior.Flyout;
            FlyoutItemsPrincipal.IsVisible = true;

            try
            {
                _ = Shell.Current.GoToAsync("//nuestra_app/productos/ListaProductos");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[Shell] Navigation error (EnableAppAfterLogin): {ex}");
            }

            if (BindingContext is TiendaShellViewModel viewmodel)
                viewmodel.OnLoggedIn();
        }

        public void DisableAppAfterLogin()
        {
            FlyoutItemsPrincipal.IsVisible = false;
            FlyoutBehavior = FlyoutBehavior.Disabled;
            try
            {
                _ = Shell.Current.GoToAsync("//Login");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[Shell] Navigation error (DisableAppAfterLogin): {ex}");
            }
        }
    }
}
