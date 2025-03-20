namespace MagicGradients.Forms;

[ContentProperty(nameof(Stops))]
public abstract class Gradient : GradientElement, IGradient, IGradientSource
{
    public static readonly BindableProperty IsRepeatingProperty = BindableProperty.Create(
        nameof(IsRepeating), typeof(bool), typeof(LinearGradient), false);

    private GradientElements<GradientStop> _stops;

    protected Gradient()
    {
        Stops = new GradientElements<GradientStop>();
    }

    public GradientElements<GradientStop> Stops
    {
        get => _stops;
        set
        {
            _stops?.Release();
            _stops = value;
            _stops.AttachTo(this);
        }
    }

    public bool IsRepeating
    {
        get => (bool)GetValue(IsRepeatingProperty);
        set => SetValue(IsRepeatingProperty, value);
    }

    public IReadOnlyList<IGradientStop> GetStops()
    {
        return Stops;
    }

    public IReadOnlyList<IGradient> GetGradients()
    {
        return new[] { this };
    }

    protected override void OnBindingContextChanged()
    {
        base.OnBindingContextChanged();
        Stops.SetInheritedBindingContext(BindingContext);
    }
}