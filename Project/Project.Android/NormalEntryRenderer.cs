using Android.App;
using Android.Content;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Project.Droid;
using Project.Renderers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(NormalEntry), typeof(NormalEntryRenderer))]
namespace Project.Droid
{
    public class NormalEntryRenderer : EntryRenderer
    {
        public NormalEntryRenderer(Context context) : base(context)
        {

        }
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                Control.Background = null;
                //Control.SetBackgroundResource(Resource.Layout.rounded_shape);
                var gradientDrawable = new GradientDrawable();
                gradientDrawable.SetCornerRadius(12);
                Control.SetHeight(120);
                gradientDrawable.SetStroke(5, Android.Graphics.Color.Rgb(0, 78, 146));
                gradientDrawable.SetColor(Android.Graphics.Color.Rgb(25, 26, 50));
                Control.SetBackground(gradientDrawable);

                Control.SetPadding(52, Control.PaddingTop, Control.PaddingRight, Control.PaddingBottom);

                Control.SetTextCursorDrawable(Resource.Drawable.my_cursor);
            }
        }
    }
}