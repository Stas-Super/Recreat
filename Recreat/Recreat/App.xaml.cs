using FacebookLogin.Views;
using Recreat.Mobile.Views;
using Xamarin.Forms;

namespace Recreat.Mobile {
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            Device.SetFlags(new string[] { "Brush_Experimental" });
            MainPage = new NavigationPage(new MainPage());
            //MainPage = new NavigationPage(new MainCsPage())
            //{
            //    Title = "Facebook Login"
            //};
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
