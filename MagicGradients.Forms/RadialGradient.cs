﻿namespace MagicGradients.Forms;

public class RadialGradient : Gradient, IRadialGradient
{
    public static readonly BindableProperty CenterProperty = BindableProperty.Create(
        nameof(Center), typeof(Position), typeof(RadialGradient), Position.Prop(0.5, 0.5));

    public static readonly BindableProperty RadiusProperty = BindableProperty.Create(
        nameof(RadiusProperty), typeof(Dimensions), typeof(RadialGradient), Dimensions.Zero);

    public static readonly BindableProperty ShapeProperty = BindableProperty.Create(
        nameof(Shape), typeof(RadialGradientShape), typeof(RadialGradient), RadialGradientShape.Ellipse);

    public static readonly BindableProperty StretchProperty = BindableProperty.Create(
        nameof(Stretch), typeof(RadialGradientStretch), typeof(RadialGradient), RadialGradientStretch.FarthestCorner);

    public Position Center
    {
        get => (Position)GetValue(CenterProperty);
        set => SetValue(CenterProperty, value);
    }

    public Dimensions Radius
    {
        get => (Dimensions)GetValue(RadiusProperty);
        set => SetValue(RadiusProperty, value);
    }

    public RadialGradientShape Shape
    {
        get => (RadialGradientShape)GetValue(ShapeProperty);
        set => SetValue(ShapeProperty, value);
    }

    public RadialGradientStretch Stretch
    {
        get => (RadialGradientStretch)GetValue(StretchProperty);
        set => SetValue(StretchProperty, value);
    }
}