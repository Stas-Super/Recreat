using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace RecreatMobile.Renderers
{
    public class BottomTabbedPage : TabbedPage
    {

        public static readonly BindableProperty SizeProperty =
                BindableProperty.Create("Size", typeof(double), typeof(BottomTabbedPage), 0.0,
                defaultValueCreator: bindable => Device.GetNamedSize(NamedSize.Large, (Label)bindable));
       
        public event EventHandler CenterButtonClicked;
        public void SendCenterButtonClicked()
        {
            EventHandler eventHandler = this.CenterButtonClicked;
            eventHandler?.Invoke((object)this, EventArgs.Empty);
        }

        public static readonly BindableProperty CommandProperty =
        BindableProperty.Create(nameof(Command), typeof(ICommand), typeof(BottomTabbedPage), null);

        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }
    }
}
