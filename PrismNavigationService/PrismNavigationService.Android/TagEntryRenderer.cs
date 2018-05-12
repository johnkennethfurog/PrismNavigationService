using System;


using Android.Content;
using Android.Runtime;
using Xamarin.Forms;
using DLToolkit.Forms.Controls;
using PrismNavigationService.Droid;
using Xamarin.Forms.Platform.Android;
using Android.Util;

[assembly: ExportRenderer(typeof(TagEntry), typeof(TagEntryRenderer))]
namespace PrismNavigationService.Droid
{
    class TagEntryRenderer : EntryRenderer
    {
        public static void Init()
        {
#pragma warning disable 0219
            var dummy = new TagEntryRenderer(Android.App.Application.Context);
#pragma warning restore 0219
        }
        public TagEntryRenderer(Context context) : base(context)
        {

        }

        public TagEntryRenderer(Context context, IAttributeSet attrs) : base(context)
        {
        }

        public TagEntryRenderer(Context context, IAttributeSet attrs, int defStyle) : base(context)
        {
        }
        public TagEntryRenderer(IntPtr a, JniHandleOwnership b) : base(Android.App.Application.Context)
        {
        }
    }
}