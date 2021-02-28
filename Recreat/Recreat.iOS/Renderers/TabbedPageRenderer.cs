using CoreGraphics;
using Foundation;
using Recreat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UIKit;
using Xamarin.Forms.Platform.iOS;
using Xamarin.Forms;
using CoreAnimation;
using Android.Bluetooth;
using Recreat.Mobile.iOS.Renderers;
using Recreat.Mobile.Renderers;

[assembly: ExportRenderer(typeof(Recreat.Mobile.Renderers.BottomTabbedPage),typeof(TabbedPageRenderer))]
namespace Recreat.Mobile.iOS.Renderers
{
    public class TabbedPageRenderer : TabbedRenderer
    {
        private readonly float tabBarHeight = 0b100101100;

        public override void ViewWillLayoutSubviews()
        {
            base.ViewWillLayoutSubviews();

            TabBar.Frame = new CGRect(TabBar.Frame.X, TabBar.Frame.Y + (TabBar.Frame.Height - tabBarHeight), TabBar.Frame.Width, tabBarHeight);
        }
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            //Добовление окргугления для TabbedPage
            this.TabBar.Layer.MasksToBounds = true;
            this.TabBar.Translucent = true;
            this.TabBar.BarStyle = UIBarStyle.Black;
            this.TabBar.Layer.CornerRadius = 30;
            this.TabBar.Layer.MaskedCorners = CoreAnimation.CACornerMask.MaxXMinYCorner | CoreAnimation.CACornerMask.MinXMinYCorner;
            //Добовление центровой кнопки
            UIButton btn = new UIButton(frame: new CoreGraphics.CGRect(0, 0, 60, 60));
            this.View.Add(btn);
            btn.ClipsToBounds = true;
            btn.Layer.CornerRadius = 30;
            btn.AdjustsImageWhenHighlighted = false;
            btn.SetImage(UIImage.FromFile("PlasButton.png"), UIControlState.Normal);
            CGPoint center = this.TabBar.Center;
            btn.Center = center;

            //button click event
            btn.TouchUpInside += (sender, ex) =>
            {
                ((BottomTabbedPage)sender).SendCenterButtonClicked();
                var command = ((BottomTabbedPage)sender).Command;
                if (command == null) return;
                if (command.CanExecute(null))
                {
                    command.Execute(null);
                }
            };
            this.ShouldSelectViewController += (UITabBarController tabBarController, UIViewController viewController) =>
            {
                if (viewController == tabBarController.ViewControllers[2])
                {
                    return false;
                }
                return true;
            };
        }
         protected override void OnElementChanged(VisualElementChangedEventArgs e)
        {
            base.OnElementChanged(e);
        }
    }
}