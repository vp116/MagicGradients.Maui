using System.ComponentModel;
using System.Globalization;

namespace MagicGradients.Maui;

[TypeConverter(typeof(IGradientSource))]
public class CssGradientSourceTypeConverter : TypeConverter
{
    public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
    {
        return sourceType == typeof(string);
    }

    public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
    {
        var valueStr = value?.ToString();

        if (string.IsNullOrEmpty(valueStr))
            throw new InvalidOperationException($"Cannot convert \"{value}\" into {typeof(IGradientSource)}");

        return CssGradientSource.Parse(valueStr);
    }
}