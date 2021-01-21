using Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UIKit;
using Xamarin.Forms.Platform.iOS;

namespace RecreatMobile.iOS.Renderers
{
    public class TabbedPageRenderer : TabbedRenderer
    {
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            this.TabBar.Layer.MasksToBounds = true;
            this.TabBar.Translucent = true;
            //this.TabBar.BarTintColor = UIColor.White;
            this.TabBar.BarStyle = UIBarStyle.Black;
            this.TabBar.Layer.CornerRadius = 20;
            this.TabBar.Layer.MaskedCorners = CoreAnimation.CACornerMask.MaxXMinYCorner | CoreAnimation.CACornerMask.MinXMinYCorner;
        }

    }
}