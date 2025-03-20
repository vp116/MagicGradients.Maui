using System.ComponentModel;
using MagicGradients.Xaml;

namespace MagicGradients;

[TypeConverter(typeof(OffsetTypeConverter))]
public struct Offset
{
    public static Offset Empty { get; } = new(-1, OffsetType.Proportional);
    public static Offset Zero { get; } = new(0, OffsetType.Proportional);

    public double Value { get; set; }
    public OffsetType Type { get; set; }

    public bool IsEmpty => Value < 0;

    public Offset(double value, OffsetType type)
    {
        Value = value;
        Type = type;
    }

    public static Offset Prop(double value)
    {
        return new Offset(value, OffsetType.Proportional);
    }

    public static Offset Abs(double value)
    {
        return new Offset(value, OffsetType.Absolute);
    }

    public override string ToString()
    {
        return $"{Value}:{Type}";
    }

    public static bool operator ==(Offset o1, Offset o2)
    {
        return o1.Value == o2.Value;
    }

    public static bool operator !=(Offset o1, Offset o2)
    {
        return o1.Value != o2.Value;
    }
}

public enum OffsetType
{
    Proportional,
    Absolute
}

public static class OffsetExtensions
{
    public static double GetDrawPixels(this Offset offset, int sizeInPixels, double pixelScaling)
    {
        return offset.Type == OffsetType.Proportional
            ? offset.Value * sizeInPixels
            : offset.Value * pixelScaling;
    }
}