using CoreAnimation;
using Foundation;
using RecreatMobile.Raderers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
[assembly: ExportRenderer(typeof(Entry), typeof(EntryRenderer))]
namespace Recreat.iOS.Renderers
{
    public class CastumEntryRenderer : EntryRenderer
    {
		protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
		{
			base.OnElementChanged(e);

			if (Control != null)
			{
				Control.BorderStyle = UITextBorderStyle.None;

				var view = (Element as CustumEntry);
				if (view != null)
				{
					DrawBorder(view);
					SetFontSize(view);
					SetPlaceholderTextColor(view);
				}
			}
		}

		protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged(sender, e);

			var view = (CustumEntry)Element;
			if (e.PropertyName.Equals(view.BorderColor))
				DrawBorder(view);
			if (e.PropertyName.Equals(view.FontSize))
				SetFontSize(view);
			if (e.PropertyName.Equals(view.PlaceholderColor))
				SetPlaceholderTextColor(view);
		}

		void DrawBorder(CustumEntry view)
		{
			var borderLayer = new CALayer();
			borderLayer.MasksToBounds = true;
			borderLayer.Frame = new CoreGraphics.CGRect(0f, Frame.Height / 2, Frame.Width, 1f);
			borderLayer.BorderColor = view.BorderColor.ToCGColor();
			borderLayer.BorderWidth = 1.0f;

			Control.Layer.AddSublayer(borderLayer);
			Control.BorderStyle = UITextBorderStyle.None;
		}

		void SetFontSize(CustumEntry view)
		{
			if (view.FontSize != Font.Default.FontSize)
				Control.Font = UIFont.SystemFontOfSize((System.nfloat)view.FontSize);
			else if (view.FontSize == Font.Default.FontSize)
				Control.Font = UIFont.SystemFontOfSize(17f);
		}

		void SetPlaceholderTextColor(CustumEntry view)
		{
			if (string.IsNullOrEmpty(view.Placeholder) == false && view.PlaceholderColor != Color.Default)
			{
				var placeholderString = new NSAttributedString(view.Placeholder,
											new UIStringAttributes { ForegroundColor = view.PlaceholderColor.ToUIColor() });
				Control.AttributedPlaceholder = placeholderString;
			}
		}
	}
}
