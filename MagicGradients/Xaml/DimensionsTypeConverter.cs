using System.ComponentModel;
using System.Globalization;

namespace MagicGradients.Xaml;

public class DimensionsTypeConverter : OffsetTypeConverter
{
    public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
    {
        if (value is string stringValue)
        {
            if (string.IsNullOrWhiteSpace(stringValue))
                return Dimensions.Zero;

            stringValue = stringValue.Trim();

            var dim = stringValue.Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (dim.Length == 1) return new Dimensions(GetOffset(dim[0], OffsetType.Absolute));

            if (dim.Length == 2)
                return new Dimensions(
                    GetOffset(dim[0], OffsetType.Absolute),
                    GetOffset(dim[1], OffsetType.Absolute));

            throw new InvalidOperationException($"Cannot convert \"{stringValue}\" into {typeof(Dimensions)}");
        }

        throw new NotSupportedException($"Cannot convert from {value.GetType()} to {typeof(Dimensions)}");
    }
}