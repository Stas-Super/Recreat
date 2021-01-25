using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using RecreatMobile.Renderers;
namespace RecreatMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Main : BottomTabbedPage
    {
        public Main()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private void BottomTabbedPage_CenterButtonClicked(object sender, EventArgs e)
        {
            DisplayAlert("Hello world", "Hello", "ok");
        }
    }
}