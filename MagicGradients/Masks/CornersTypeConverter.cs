using System.ComponentModel;
using System.Globalization;
using MagicGradients.Xaml;

namespace MagicGradients.Masks;

public class CornersTypeConverter : OffsetTypeConverter
{
    public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
    {
        if (value is string stringValue) return ConvertFromString(stringValue);

        throw new InvalidOperationException($"Cannot convert {value} to {typeof(Corners)}");
    }

    public Corners ConvertFromString(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return Corners.Zero;

        value = value.Trim();

        var dim = value.Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

        if (dim.Length == 1) return new Corners(new Dimensions(GetOffset(dim[0], OffsetType.Absolute)));

        if (dim.Length == 2)
            return new Corners(
                new Dimensions(GetOffset(dim[0], OffsetType.Absolute)),
                new Dimensions(GetOffset(dim[0], OffsetType.Absolute)),
                new Dimensions(GetOffset(dim[1], OffsetType.Absolute)),
                new Dimensions(GetOffset(dim[1], OffsetType.Absolute)));

        if (dim.Length == 4)
            return new Corners(
                new Dimensions(GetOffset(dim[0], OffsetType.Absolute)),
                new Dimensions(GetOffset(dim[1], OffsetType.Absolute)),
                new Dimensions(GetOffset(dim[2], OffsetType.Absolute)),
                new Dimensions(GetOffset(dim[3], OffsetType.Absolute)));

        throw new InvalidOperationException($"Cannot convert \"{value}\" into {typeof(Corners)}");
    }
}