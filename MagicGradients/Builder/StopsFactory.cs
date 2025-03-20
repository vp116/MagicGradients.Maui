namespace MagicGradients.Builder;

public class StopsFactory
{
    public List<GradientStop> Stops { get; } = new();

    public void CreateStop(Color color, Offset? offset = null)
    {
        var stop = new GradientStop
        {
            Color = color,
            Offset = offset ?? Offset.Empty
        };

        Stops.Add(stop);
    }
}