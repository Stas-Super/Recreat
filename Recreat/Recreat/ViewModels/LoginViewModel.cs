using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using static System.Net.Mime.MediaTypeNames;
using Recreat;
using Xamarin.Forms;
using Recreat.Mobile.Views;
using Recreat.Mobile.Views;
using Recreat.Mobile;

namespace Recreat.Mobile.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        public ICommand LoginPageClick { get; set; }
        public ICommand Login { get; set; }
        public LoginViewModel()
        {
            LoginPageClick = new Command(LoginPage);
            Login = new Command(LoginMethed);
        }
        private async void LoginMethed()
        {
            await App.Current.MainPage.Navigation.PushAsync(new Main());
        }
        private async void LoginPage()
        {
            await App.Current.MainPage.Navigation.PushAsync(new LoginPage());
        }

        
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
