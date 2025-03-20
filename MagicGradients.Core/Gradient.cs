namespace MagicGradients;

public class GradientStop : IGradientStop
{
    public GradientStop(Color color, Offset? offset = null)
    {
        Color = color;
        Offset = offset ?? Offset.Empty;
    }

    public Color Color { get; }
    public Offset Offset { get; }
    public float RenderOffset { get; set; }
}

public class Gradient : IGradient
{
    public List<IGradientStop> Stops { get; set; }
    public bool IsRepeating { get; set; }

    public IReadOnlyList<IGradientStop> GetStops()
    {
        return Stops;
    }
}

public class LinearGradient : Gradient, ILinearGradient
{
    public double Angle { get; set; }
}

public class RadialGradient : Gradient, IRadialGradient
{
    public Position Center { get; set; }
    public Dimensions Radius { get; set; }
    public RadialGradientShape Shape { get; set; }
    public RadialGradientStretch Stretch { get; set; }
}