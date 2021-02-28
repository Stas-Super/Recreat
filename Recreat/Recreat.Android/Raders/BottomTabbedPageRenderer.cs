using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V4.View;
using Android.Views;
using Android.Widget;
using Recreat.Mobile.Renderers;
using Recreat.Droid.Raders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms.Platform.Android.AppCompat;
using Recreat.Mobile.Droid.Raders;

[assembly: ExportRenderer(typeof(BottomTabbedPage), typeof(BottomTabbedPageRenderer))]
namespace Recreat.Mobile.Droid.Raders
{
    public class BottomTabbedPageRenderer : TabbedPageRenderer
    {
        private Context ctx;
        public BottomTabbedPageRenderer(Context context) : base(context)
        {
            ctx = context;
        }

        protected override void OnLayout(bool changed, int l, int t, int r, int b)
        {
            base.OnLayout(changed, l, t, r, b);
            InvertLayoutThroughScale();
        }

        private void InvertLayoutThroughScale()
        {
            ViewGroup.ScaleY = -1;

            TabLayout tabLayout = null;
            ViewPager viewPager = null;

            for (int i = 0; i < ChildCount; ++i)
            {
                Android.Views.View view = (Android.Views.View)GetChildAt(i);
                if (view is TabLayout) tabLayout = (TabLayout)view;
                else if (view is ViewPager) viewPager = (ViewPager)view;
            }

            tabLayout.ScaleY = viewPager.ScaleY = -1;
            //tabLayout.SetPadding(0, 100, 0, 100);
            tabLayout.SetMinimumHeight(270);
            tabLayout.Measure(0, 0);
            viewPager.SetPadding(0, Math.Min(-270,-tabLayout.MeasuredHeight), 0, 0);

        }

        protected override void OnElementChanged(ElementChangedEventArgs<TabbedPage> e)
        {
            base.OnElementChanged(e);
            if(e.NewElement != null)
            {
                TabLayout tabLayout = null;
                for (int i = 0; i < ChildCount; ++i)
                {
                    Android.Views.View view = (Android.Views.View)GetChildAt(i);
                    if (view is TabLayout) tabLayout = (TabLayout)view;
                }
                Android.Widget.ImageButton imgButton = new Android.Widget.ImageButton(ctx);
                imgButton.Click += (sender, args) =>
                {
                    ((BottomTabbedPage)e.NewElement).SendCenterButtonClicked();
                    var command = ((BottomTabbedPage)e.NewElement).Command;
                    if (command == null) return;
                    if (command.CanExecute(null))
                    {
                        command.Execute(null);
                    }
                };
                imgButton.SetImageResource(Resource.Drawable.TabButton);
                imgButton.SetBackgroundColor(Android.Graphics.Color.Transparent);
                var viewgroup = ((ViewGroup)tabLayout.GetChildAt(0));
                for (int i = 0; i < viewgroup.ChildCount; ++i)
                {
                    Android.Views.View view = viewgroup.GetChildAt(i);
                    if(view != null)
                    {
                        view.SetPadding(0, 50, 0, 50);
                    }
                }
                imgButton.SetPadding(0, 50, 0, 0);
                viewgroup.RemoveViewAt(2);
                var buttonscount = viewgroup.ChildCount;
                viewgroup.AddView(imgButton, 2);
            }
        }
    }
}