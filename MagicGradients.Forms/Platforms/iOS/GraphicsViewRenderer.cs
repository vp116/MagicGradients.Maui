using System.ComponentModel;
using Foundation;
using Microsoft.Maui.Controls.Handlers.Compatibility;
using Microsoft.Maui.Controls.Platform;
using Microsoft.Maui.Graphics.Platform;

namespace MagicGradients.Forms;

[Preserve]
public class GraphicsViewRenderer : ViewRenderer<GraphicsView, PlatformGraphicsView>
{
    protected override void OnElementChanged(ElementChangedEventArgs<GraphicsView> e)
    {
        base.OnElementChanged(e);

        if (e.OldElement != null)
            // Unsubscribe from event handlers and cleanup any resources
            SetNativeControl(null);

        if (e.NewElement != null)
        {
            SetNativeControl(new PlatformGraphicsView());
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