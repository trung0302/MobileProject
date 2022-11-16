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

[assembly: ExportRenderer(typeof(BorderlessEntry), typeof(BorderlessEntryRenderer))]
namespace Project.Droid
{
    public class BorderlessEntryRenderer : EntryRenderer
    {
        public BorderlessEntryRenderer(Context context) : base(context)
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
                gradientDrawable.SetCornerRadius(60f);
                gradientDrawable.SetStroke(5, Android.Graphics.Color.Rgb(28, 181, 224));
                gradientDrawable.SetColor(Android.Graphics.Color.Rgb(25, 26, 50));
                Control.SetBackground(gradientDrawable);

                Control.SetPadding(52, Control.PaddingTop, Control.PaddingRight,Control.PaddingBottom);
                //IntPtr IntPtrtextViewClass = JNIEnv.FindClass(typeof(TextView));
                //IntPtr mCursorDrawableResProperty = JNIEnv.GetFieldID(IntPtrtextViewClass, "mCursorDrawableRes", "I");

                //JNIEnv.SetField(Control.Handle, mCursorDrawableResProperty, Resource.Drawable.my_cursor);

                Control.SetTextCursorDrawable(Resource.Drawable.my_cursor);
            }
        }
    }
}