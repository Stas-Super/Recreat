using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace RecreatMobile.Raderers
{
    public class BottomTabbedPage : TabbedPage
    {

        public static readonly BindableProperty SizeProperty =
                BindableProperty.Create("Size", typeof(double), typeof(BottomTabbedPage), 0.0,
                defaultValueCreator: bindable => Device.GetNamedSize(NamedSize.Large, (Label)bindable));

    }
}
