using MagicGradients.Forms.SkiaViews.Drawing;
using MagicGradients.Masks;
using SkiaSharp.Views.Maui;
using SkiaSharp.Views.Maui.Controls;


namespace MagicGradients.Forms.SkiaViews
{
    [ContentProperty(nameof(GradientSource))]
    public class GradientView : SKCanvasView, IGradientControl, IGradientVisualElement
    {
        static GradientView()
        {
            GlobalSetup.Current.UseCssStyles<GradientView>();
        }

        public GradientDrawable Drawable { get; protected set; }

        public static readonly BindableProperty GradientSourceProperty = GradientControl.GradientSourceProperty;
        public static readonly BindableProperty GradientSizeProperty = GradientControl.GradientSizeProperty;
        public static readonly BindableProperty GradientRepeatProperty = GradientControl.GradientRepeatProperty;
        public static readonly BindableProperty MaskProperty = GradientControl.MaskProperty;

        public double ViewWidth => Width;

        public IGradientSource GradientSource
        {
            get => (IGradientSource)GetValue(GradientSourceProperty);
            set => SetValue(GradientSourceProperty, value);
        }

        public Dimensions GradientSize
        {
            get => (Dimensions)GetValue(GradientSizeProperty);
            set => SetValue(GradientSizeProperty, value);
        }

        public BackgroundRepeat GradientRepeat
        {
            get => (BackgroundRepeat)GetValue(GradientRepeatProperty);
            set => SetValue(GradientRepeatProperty, value);
        }

        public IGradientMask Mask
        {
            get => (IGradientMask)GetValue(MaskProperty);
            set => SetValue(MaskProperty, value);
        }

        public GradientView()
        {
            Drawable = new GradientDrawable(this);
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
            this.SetBindingContext(BindingContext);
        }

        protected override void OnPaintSurface(SKPaintSurfaceEventArgs e)
        {
            base.OnPaintSurface(e);

            var context = new DrawContext(e);
            context.Measure(GradientSize, Width);

            Drawable.Draw(context);
        }

        public void InvalidateCanvas()
        {
            InvalidateSurface();
        }
    }
}
