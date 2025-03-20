using MagicGradients.Renderers;

namespace MagicGradients;

public class RadialGradient : Gradient
{
    public static readonly BindableProperty CenterProperty = BindableProperty.Create(
        nameof(Center), typeof(Point), typeof(RadialGradient), new Point(0.5, 0.5));

    public static readonly BindableProperty RadiusXProperty = BindableProperty.Create(
        nameof(RadiusXProperty), typeof(double), typeof(RadialGradient), -1d);

    public static readonly BindableProperty RadiusYProperty = BindableProperty.Create(
        nameof(RadiusYProperty), typeof(double), typeof(RadialGradient), -1d);

    public static readonly BindableProperty FlagsProperty = BindableProperty.Create(
        nameof(Flags), typeof(RadialGradientFlags), typeof(RadialGradient), RadialGradientFlags.PositionProportional);

    public static readonly BindableProperty ShapeProperty = BindableProperty.Create(
        nameof(Shape), typeof(RadialGradientShape), typeof(RadialGradient), RadialGradientShape.Ellipse);

    public static readonly BindableProperty SizeProperty = BindableProperty.Create(
        nameof(Size), typeof(RadialGradientSize), typeof(RadialGradient), RadialGradientSize.FarthestCorner);

    public Point Center
    {
        get => (Point)GetValue(CenterProperty);
        set => SetValue(CenterProperty, value);
    }

    public double RadiusX
    {
        get => (double)GetValue(RadiusXProperty);
        set => SetValue(RadiusXProperty, value);
    }

    public double RadiusY
    {
        get => (double)GetValue(RadiusYProperty);
        set => SetValue(RadiusYProperty, value);
    }

    public RadialGradientFlags Flags
    {
        get => (RadialGradientFlags)GetValue(FlagsProperty);
        set => SetValue(FlagsProperty, value);
    }

    public RadialGradientShape Shape
    {
        get => (RadialGradientShape)GetValue(ShapeProperty);
        set => SetValue(ShapeProperty, value);
    }

    public RadialGradientSize Size
    {
        get => (RadialGradientSize)GetValue(SizeProperty);
        set => SetValue(SizeProperty, value);
    }

    public override void InstantiateShader(BindableObject view)
    {
        Shader = new RadialGradientShader(this);
    }
}