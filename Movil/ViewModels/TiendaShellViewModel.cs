using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Storage;

namespace Movil.ViewModels
{
    public partial class TiendaShellViewModel : ObservableObject
    {
        public IRelayCommand LogoutCommand { get; }

        [ObservableProperty]
        private bool isUserLogout = true; // true => mostrar Login, no autologin

        public TiendaShellViewModel()
        {
            LogoutCommand = new RelayCommand(Logout);
        }

        private void Logout()
        {
            IsUserLogout = true; // señalamos que el usuario pidió sesión
            (App.Current.MainPage as TiendaShell)?.DisableAppAfterLogin();
        }

        public void OnLoginScreenRequested()
        {
            // llamado desde navegación a Login para evitar autologin
            IsUserLogout = true;
        }

        public void OnLoggedIn()
        {
            IsUserLogout = false;
        }
    }
}
