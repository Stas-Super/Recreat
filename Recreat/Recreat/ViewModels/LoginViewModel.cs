using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using static System.Net.Mime.MediaTypeNames;
using RecreatMobile;
using App3;
using Xamarin.Forms;
using RecreatMobile.Views;

namespace RecreatMobile.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        public ICommand LoginPageClick { get; set; }

        public LoginViewModel()
        {
            LoginPageClick = new Command(LoginPage);
        }

        private async void LoginPage()
        {
            await App.Current.MainPage.Navigation.PushAsync(new LoginPage());
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
