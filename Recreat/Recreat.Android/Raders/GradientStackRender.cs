using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RecreatMobile.Raders;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using App3.Droid.Raders;
using Android.Graphics.Drawables;
using RecreatMobile.Services;

[assembly: ExportRenderer(typeof(GradientPage), typeof(GradientStackRender))]

namespace App3.Droid.Raders
{
    [Obsolete]
    public class GradientStackRender : VisualElementRenderer<StackLayout>
    {
        private Color StartColor { get; set; }
        private Color EndColor { get; set; }
        public GradientColorStackMode Mode { get;set; }
        private GradientDrawable.Orientation ToJavaOrintation(GradientColorStackMode orintatinColors)
        {
            switch (orintatinColors)
            {
                case GradientColorStackMode.BlTr:
                    return GradientDrawable.Orientation.BlTr;
                case GradientColorStackMode.BottomTop:
                    return GradientDrawable.Orientation.BottomTop;
                case GradientColorStackMode.BrTl:
                    return GradientDrawable.Orientation.BrTl;
                case GradientColorStackMode.LeftRight:
                    return GradientDrawable.Orientation.LeftRight;
                case GradientColorStackMode.RightLeft:
                    return GradientDrawable.Orientation.RightLeft;
                case GradientColorStackMode.TlBr:
                    return GradientDrawable.Orientation.TlBr;
                case GradientColorStackMode.TopBottom:
                    return GradientDrawable.Orientation.TopBottom;
                case GradientColorStackMode.TrBl:
                    return GradientDrawable.Orientation.TrBl;
                default:
                    throw new Exception("Wrong value");
            }
        }
        protected override void DispatchDraw(global::Android.Graphics.Canvas canvas)
        {
            #region for Vertical Gradient
            //var gradient = new Android.Graphics.LinearGradient(0, 0, 0, Height,
            #endregion

            #region for Horizontal Gradient
            var gradient = new Android.Graphics.LinearGradient(0, 0, Width, 0,
            #endregion

                   this.StartColor.ToAndroid(),
                   this.EndColor.ToAndroid(),
                   Android.Graphics.Shader.TileMode.Mirror);

            var paint = new Android.Graphics.Paint()
            {
                Dither = true,
            };
            paint.SetShader(gradient);
            canvas.DrawPaint(paint);
            base.DispatchDraw(canvas);
        }

        protected override void OnElementChanged(ElementChangedEventArgs<StackLayout> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null || Element == null)
            {
                return;
            }
            try
            {
                var stack = e.NewElement as GradientPage;
                this.StartColor = stack.StartColor;
                this.EndColor = stack.EndColor;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(@"ERROR:", ex.Message);
            }
        }

    }
}