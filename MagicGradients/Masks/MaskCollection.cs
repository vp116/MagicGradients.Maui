using MagicGradients.Renderers;

namespace MagicGradients.Masks;

[ContentProperty(nameof(Masks))]
public class MaskCollection : GradientMask
{
    private GradientElements<GradientMask> _masks;

    public MaskCollection()
    {
        Masks = new GradientElements<GradientMask>();
    }

    public GradientElements<GradientMask> Masks
    {
        get => _masks;
        set
        {
            _masks?.Release();
            _masks = value;
            _masks.AttachTo(this);
        }
    }

    protected override void OnBindingContextChanged()
    {
        base.OnBindingContextChanged();
        Masks.SetInheritedBindingContext(BindingContext);
    }

    public override void Clip(RenderContext context)
    {
        foreach (var mask in Masks) mask.Clip(context);
    }

    public override string ToString()
    {
        return "Mask Collection";
    }
}