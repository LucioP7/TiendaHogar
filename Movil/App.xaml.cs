using CommunityToolkit.Mvvm.Messaging;
using Movil.Class;
using Movil.Views;

namespace Movil
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new AppShell();
            MainPage = new TiendaShell();
           
        }

        
    }
}
