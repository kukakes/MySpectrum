using System;
using System.ComponentModel;
using Android.Content;
using Android.Graphics;
using Android.Text;
using MySpectrumApp.Android.CustomRenderers;
using MySpectrumApp.CustomRenderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(GradientColorLabel), typeof(GradientLabelRenderer))]
namespace MySpectrumApp.Android.CustomRenderers
{
    class GradientLabelRenderer : LabelRenderer
    {
        public GradientLabelRenderer(Context context) : base(context)
        {
        }

        double Degree2Rad(int degree) =>
            Math.PI * degree / 180.0;

        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);

            if (Element != null)
                ApplyGradient();
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == Label.TextProperty.PropertyName ||
                e.PropertyName == Label.HeightProperty.PropertyName)
                ApplyGradient();
        }

        private void ApplyGradient()
        {
            if (string.IsNullOrEmpty(Element.Text))
                return;

            TextPaint pt = Control.Paint;
            var width = pt.MeasureText(Element.Text);
            var height = Element.Height;

            if (width > 0 && height > 0)
            {
                int theta = 17;
                double gradientAngle = Degree2Rad(theta);

                var X = width * Math.Cos(gradientAngle);
                var Y = height * Math.Sin(gradientAngle);

                Shader textShader = new LinearGradient(0, 0, (float)X, (float)Y,
                new int[]{
                        Xamarin.Forms.Color.FromRgb(226,81,106).ToAndroid(),
                        Xamarin.Forms.Color.FromRgb(226,81,106).ToAndroid(),
                        Xamarin.Forms.Color.FromRgb(0, 173, 231).ToAndroid(),
                        Xamarin.Forms.Color.FromRgb(10,209,165).ToAndroid(),
                        Xamarin.Forms.Color.FromRgb(10,209,165).ToAndroid(),
                }, new float[] { 0, 0.12f, 0.5f, 0.88f, 1 }, Shader.TileMode.Clamp);


                Control.Paint.SetShader(textShader);
            }
        }
    }
}

