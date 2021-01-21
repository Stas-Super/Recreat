using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V4.View;
using Android.Views;
using Android.Widget;
using RecreatMobile.Droid.Raders;
using RecreatMobile.Renderers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android.AppCompat;

[assembly: ExportRenderer(typeof(BottomTabbedPage), typeof(BottomTabbedPageRenderer))]
namespace RecreatMobile.Droid.Raders
{
    public class BottomTabbedPageRenderer : TabbedPageRenderer
    {
        public BottomTabbedPageRenderer(Context context) : base(context)
        {

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
            tabLayout.SetPadding(0, 50, 0, 50);
            tabLayout.Measure(0, 0);
            viewPager.SetPadding(0, -tabLayout.MeasuredHeight, 0, 0);

        }
    }
}