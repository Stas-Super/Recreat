using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace RecreatMobile.Raderers
{
    public class CustumEntry : Entry
	{
        [Obsolete]
        public static readonly BindableProperty BorderColorProperty =
			BindableProperty.Create<CustumEntry, Color>(p => p.BorderColor, Color.Black);

		public Color BorderColor
		{
			get { return (Color)GetValue(BorderColorProperty); }
			set { SetValue(BorderColorProperty, value); }
		}

        [Obsolete]
        public static readonly BindableProperty FontSizeProperty =
			BindableProperty.Create<CustumEntry, double>(p => p.FontSize, Font.Default.FontSize);

		public double FontSize
		{
			get { return (double)GetValue(FontSizeProperty); }
			set { SetValue(FontSizeProperty, value); }
		}

        [Obsolete]
        public static readonly BindableProperty PlaceholderColorProperty =
			BindableProperty.Create<CustumEntry, Color>(p => p.PlaceholderColor, Color.Default);

		public Color PlaceholderColor
		{
			get { return (Color)GetValue(PlaceholderColorProperty); }
			set { SetValue(PlaceholderColorProperty, value); }
		}
	}
}
