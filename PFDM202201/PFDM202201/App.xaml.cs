using Xamarin.Forms;

namespace PFDM202201
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage()); // Instanciando a navegação não hierárquica 
        }                                                  // passando como página inicial a MainPage
        

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
