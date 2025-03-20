using Android.Content;
using Microsoft.Maui.Controls.Handlers.Compatibility;
using Microsoft.Maui.Controls.Internals;
using Microsoft.Maui.Controls.Platform;
using Microsoft.Maui.Graphics.Platform;
using System.ComponentModel;

namespace MagicGradients.Forms;

[Preserve]
public class GraphicsViewRenderer : ViewRenderer<GraphicsView, PlatformGraphicsView>
{
    public GraphicsViewRenderer(Context context) : base(context)
    {
    }

    protected override void OnElementChanged(ElementChangedEventArgs<GraphicsView> e)
    {
        base.OnElementChanged(e);

        if (e.OldElement != null)
        {
            // Unsubscribe from event handlers and cleanup any resources
            SetNativeControl(null);
        }

        if (e.NewElement != null)
        {
            SetNativeControl(new PlatformGraphicsView(Context));
            UpdateDrawable();
        }
    }

    protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        base.OnElementPropertyChanged(sender, e);

        if (e.PropertyName == nameof(GraphicsView.Drawable))
            UpdateDrawable();
    }

    private void UpdateDrawable()
    {
        Control.Drawable = Element.Drawable;
    }
}