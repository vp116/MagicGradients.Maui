using MagicGradients.Renderers;

namespace MagicGradients;

[ContentProperty(nameof(Stops))]
public abstract class Gradient : GradientElement, IGradientSource
{
    public static readonly BindableProperty IsRepeatingProperty = BindableProperty.Create(
        nameof(IsRepeating), typeof(bool), typeof(LinearGradient), false);

    private GradientElements<GradientStop> _stops;

    protected Gradient()
    {
        Stops = new GradientElements<GradientStop>();
    }

    public IGradientShader Shader { get; protected set; }

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

    public IEnumerable<Gradient> GetGradients()
    {
        return new[] { this };
    }

    protected override void OnBindingContextChanged()
    {
        base.OnBindingContextChanged();
        Stops.SetInheritedBindingContext(BindingContext);
    }

    public virtual void InstantiateShader(BindableObject view)
    {
    }

    public virtual void Measure(int width, int height)
    {
        foreach (var stop in Stops)
            stop.RenderOffset = !stop.Offset.IsEmpty && stop.Offset.Type == OffsetType.Absolute
                ? (float)Shader.CalculateRenderOffset(stop.Offset.Value, width, height)
                : (float)stop.Offset.Value;

        CalculateUndefinedOffsets();
    }

    private void CalculateUndefinedOffsets()
    {
        var fromIndex = 0;

        for (var i = 0; i < Stops.Count; i++)
            if (Stops[i].RenderOffset >= 0 || i == Stops.Count - 1)
            {
                CalculateUndefinedRange(fromIndex, i);
                fromIndex = i;
            }
    }

    private void CalculateUndefinedRange(int fromIndex, int toIndex)
    {
        var currentOffset = Math.Max(Stops[fromIndex].RenderOffset, 0);
        var endOffset = Math.Abs(Stops[toIndex].RenderOffset);

        var step = (endOffset - currentOffset) / (toIndex - fromIndex);

        for (var i = fromIndex; i <= toIndex; i++)
        {
            var stop = Stops[i];

            if (stop.RenderOffset < 0) stop.RenderOffset = currentOffset;
            currentOffset += step;
        }
    }
}