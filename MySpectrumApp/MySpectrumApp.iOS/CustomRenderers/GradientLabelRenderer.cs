using System;
using CoreGraphics;
using MySpectrumApp.CustomRenderers;
using MySpectrumApp.iOS.CustomRenderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(GradientColorLabel), typeof(GradientLabelRenderer))]
namespace MySpectrumApp.iOS.CustomRenderers
{
    public class GradientLabelRenderer : LabelRenderer
    {
        double Degree2Rad(int degree) =>
           Math.PI * degree / 180.0;

        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);

            if (Element != null)
                ApplyGradient();
        }

        private void ApplyGradient()
        {
            if (Element != null && !string.IsNullOrEmpty(Element.Text)
                && Element.Width > 0 && Element.Height > 0)
            {
                CGSize size = new CGSize(Element.Width, Element.Height);
                UIGraphics.BeginImageContextWithOptions(size, false, 0);
                CGContext context = UIGraphics.GetCurrentContext();
                CGColorSpace colorspace = CGColorSpace.CreateDeviceRGB();

                int theta = 17;
                double gradientAngle = Degree2Rad(theta);

                var X = size.Width * Math.Cos(gradientAngle);
                var Y = size.Height * Math.Sin(gradientAngle);

                CGGradient gradient = new CGGradient(colorspace,
                    new CGColor[] {
                    Xamarin.Forms.Color.FromRgb(226,81,106).ToCGColor(),
                        Xamarin.Forms.Color.FromRgb(226,81,106).ToCGColor(),
                        Xamarin.Forms.Color.FromRgb(0, 173, 231).ToCGColor(),
                        Xamarin.Forms.Color.FromRgb(10,209,165).ToCGColor(),
                        Xamarin.Forms.Color.FromRgb(10,209,165).ToCGColor()},
                    new nfloat[] { 0, 0.12f, 0.5f, 0.88f, 1 });

                context.DrawLinearGradient(gradient, new CGPoint(0, 0), new CGPoint(X, Y), CGGradientDrawingOptions.DrawsAfterEndLocation);

                UIImage image = UIGraphics.GetImageFromCurrentImageContext();

                gradient = null;
                colorspace = null;
                //CGGradient.Release(gradient);
                //CGColorSpace.Release(colorspace);
                UIGraphics.EndImageContext();

                var color = new UIColor(image);
                Control.TextColor = color;
            }
        }

        public override CGRect Frame
        {
            get => base.Frame;
            set
            {
                base.Frame = value;
                if (value.Width > 0 && value.Height > 0)
                    ApplyGradient();
            }
        }
    }
}

