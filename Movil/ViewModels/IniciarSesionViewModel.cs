using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Firebase.Auth;
using Firebase.Auth.Providers;
using Firebase.Auth.Repository;
using Microsoft.Maui.Dispatching;

namespace Movil.ViewModels
{
    public partial class IniciarSesionViewModel : ObservableObject
    {
        public readonly FirebaseAuthClient _clientAuth;
        private FileUserRepository _userRepository;
        private UserInfo _userInfo;
        private FirebaseCredential _firebaseCredential;

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(IniciarSesionCommand))]
        private string mail;

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(IniciarSesionCommand))]
        private string password;

        [ObservableProperty]
        private bool recordarContrasena; // renombrado para evitar caracteres no ASCII en el identificador

        public IRelayCommand IniciarSesionCommand { get; }
        public IRelayCommand RegistrarseCommand { get; }

        public IniciarSesionViewModel()
        {
            _clientAuth = new FirebaseAuthClient(new FirebaseAuthConfig()
            {
                ApiKey = "AIzaSyD0Qf5QqxJV7jdeT13p2KsgHe0UarmX1bw",
                AuthDomain = "rendir-a3948.firebaseapp.com",
                Providers = new Firebase.Auth.Providers.FirebaseAuthProvider[]
                {
                    new EmailProvider()
                }
            });
            _userRepository = new FileUserRepository("TiendaHogar");

            IniciarSesionCommand = new RelayCommand(IniciarSesion, PermitirIniciarSesion);
            RegistrarseCommand = new RelayCommand(Registrarse);
        }

        public async Task ChequearSiHayUsuarioAlmacenadoAsync()
        {
            if (_userRepository.UserExists())
            {
                // Solo autologin si el Shell no está en estado de logout
                var shell = App.Current.MainPage as TiendaShell;
                var shellVm = shell?.BindingContext as TiendaShellViewModel;
                if (shellVm?.IsUserLogout == true)
                    return; // el usuario pidió login explícito; no redirigir

                (_userInfo, _firebaseCredential) = _userRepository.ReadUser();

                // Aplazar navegación hasta que la UI esté lista
                Application.Current?.Dispatcher.Dispatch(async () =>
                {
                    try
                    {
                        await Task.Delay(50);
                        shell?.EnableAppAfterLogin();
                    }
                    catch (Exception)
                    {
                        // Ignorar para no romper el inicio; se verá en logs si se agrega telemetría
                    }
                });
            }
        }

        private async void Registrarse()
        {
            await Shell.Current.GoToAsync("Registrarse");
        }

        public bool PermitirIniciarSesion()
        {
            return !string.IsNullOrEmpty(Mail) && !string.IsNullOrEmpty(Password);
        }

        private async void IniciarSesion()
        {
            try
            {

                var userCredential = await _clientAuth.SignInWithEmailAndPasswordAsync(mail, password);
                if (userCredential.User.Info.IsEmailVerified == false)
                {
                    await Application.Current.MainPage.DisplayAlert("Inicio de sesión", "Debe verificar su correo electrónico", "Ok");
                    return;
                }

                if (recordarContrasena)
                {
                    _userRepository.SaveUser(userCredential.User);
                }
                else
                {
                    _userRepository.DeleteUser();
                }

                if (App.Current.MainPage is TiendaShell shelltienda)
                {
                    shelltienda.EnableAppAfterLogin();
                }
            }
            catch (FirebaseAuthException error)
            {
                await Application.Current.MainPage.DisplayAlert("Inicio de sesión", "Ocurrió un problema:" + error.Reason, "Ok");
            }
        }
    }
}
