using MagicGradients.Masks;

namespace MagicGradients.Forms.Masks;

[ContentProperty(nameof(Masks))]
public class MaskCollection : GradientMask, IMaskCollection
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

    public IReadOnlyList<IGradientMask> GetMasks()
    {
        return Masks;
    }

    protected override void OnBindingContextChanged()
    {
        base.OnBindingContextChanged();
        Masks.SetInheritedBindingContext(BindingContext);
    }
}