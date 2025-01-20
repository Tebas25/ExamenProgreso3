using ExamenProgreso3.Views;

namespace ExamenProgreso3
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new PaginaConsulta();
        }
    }
}
