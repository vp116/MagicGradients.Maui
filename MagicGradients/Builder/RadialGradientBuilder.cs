﻿namespace MagicGradients.Builder;

public class RadialGradientBuilder : StopsBuilder<RadialGradientBuilder>, IChildBuilder
{
    private RadialGradientFlags _flags;

    public RadialGradientBuilder()
    {
        Center = new Point(0.5, 0.5);
        RadiusX = -1d;
        RadiusY = -1d;
        Shape = RadialGradientShape.Ellipse;
        Size = RadialGradientSize.FarthestCorner;
        IsRepeating = false;
        Flags = RadialGradientFlags.PositionProportional;
    }

    protected override RadialGradientBuilder Instance => this;

    internal RadialGradientFlags Flags
    {
        get => _flags;
        set => _flags = value;
    }

    internal Point Center { get; set; }
    internal double RadiusX { get; set; }
    internal double RadiusY { get; set; }
    internal RadialGradientShape Shape { get; set; }
    internal RadialGradientSize Size { get; set; }
    internal bool IsRepeating { get; set; }

    public Gradient Construct()
    {
        var radialGradient = new RadialGradient
        {
            Center = Center,
            Shape = Shape,
            Size = Size,
            RadiusX = RadiusX,
            RadiusY = RadiusY,
            Flags = _flags,
            IsRepeating = IsRepeating,
            Stops = new GradientElements<GradientStop>(StopsFactory.Stops)
        };

        return radialGradient;
    }

    public RadialGradientBuilder Circle()
    {
        Shape = RadialGradientShape.Circle;
        return this;
    }

    public RadialGradientBuilder Ellipse()
    {
        Shape = RadialGradientShape.Ellipse;
        return this;
    }

    public RadialGradientBuilder At(Point position, Action<DimenOptions> setup = null)
    {
        var options = new DimenOptions().Proportional();
        setup?.Invoke(options);

        Center = position;
        FlagsHelper.SetValue(ref _flags, RadialGradientFlags.PositionProportional, options.IsProportional);

        return this;
    }

    public RadialGradientBuilder At(double x, double y, Action<DimenOptions> setup = null)
    {
        return At(new Point(x, y), setup);
    }

    public RadialGradientBuilder Radius(Size radius, Action<DimenOptions> setup = null)
    {
        return Radius(radius.Width, radius.Height, setup);
    }

    public RadialGradientBuilder Radius(double radiusX, double radiusY, Action<DimenOptions> setup = null)
    {
        var options = new DimenOptions();
        setup?.Invoke(options);

        RadiusX = radiusX;
        RadiusY = radiusY;
        FlagsHelper.SetValue(ref _flags, RadialGradientFlags.SizeProportional, options.IsProportional);

        return this;
    }

    public RadialGradientBuilder StretchTo(RadialGradientSize size)
    {
        Size = size;
        return this;
    }

    public RadialGradientBuilder Repeat()
    {
        IsRepeating = true;
        return this;
    }
}