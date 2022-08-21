using System;
using MySpectrumApp.Android.Effects;
using MySpectrumApp.Effects;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ResolutionGroupName("MySpectrumApp")]
[assembly: ExportEffect(typeof(AndroidEntryWithNoUnderlineEffect), nameof(EntryWithNoUnderlineEffect))]
namespace MySpectrumApp.Android.Effects
{
    public class AndroidEntryWithNoUnderlineEffect : PlatformEffect
    {
        public AndroidEntryWithNoUnderlineEffect()
        {
        }

        protected override void OnAttached()
        {
            Control.Background = null;

            //Set respectable padding
            float scale = global::Android.App.Application.Context.Resources.DisplayMetrics.Density;

            Thickness padding = new Thickness(10,4);
            if (padding.VerticalThickness > 0 && padding.HorizontalThickness > 0)
                Control.SetPadding((int)(padding.Left * scale), (int)(padding.Top * scale), (int)(padding.Right * scale), (int)(padding.Bottom * scale));

        }

        protected override void OnDetached()
        {
        }
    }
}

