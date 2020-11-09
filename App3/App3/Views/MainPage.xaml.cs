using App3;
using System;
using Xamarin.Forms;

namespace FacebookLogin.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            faceBook.Clicked += LoginWithFacebook_Clicked;
        }

        private async void LoginWithFacebook_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new FacebookProfilePage());
        }
    }
}
