namespace MagicGradients.Drawing;

public class LinearGradientPaintEx : LinearGradientPaint
{
    public LinearGradientPaintEx(
        PaintGradientStop[] gradientStops,
        Point startPoint,
        Point endPoint,
        bool isRepeating) : base(gradientStops, startPoint, endPoint)
    {
        IsRepeating = isRepeating;
    }

    public bool IsRepeating { get; set; }
}