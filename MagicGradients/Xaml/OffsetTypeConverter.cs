﻿using System.ComponentModel;
using System.Globalization;

namespace MagicGradients.Xaml;

public class OffsetTypeConverter : TypeConverter
{
    public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
    {
        if (value is string stringValue) return GetOffset(stringValue, OffsetType.Proportional);

        throw new InvalidOperationException($"Cannot convert {value} to {typeof(Offset)}");
    }

    public Offset GetOffset(string value, OffsetType defaultType)
    {
        if (string.IsNullOrWhiteSpace(value))
            return Offset.Empty;

        value = value.Trim();

        if (double.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, out var d))
            return new Offset(d, defaultType);

        if (TryExtractOffset(value, out var res)) return res;

        throw new InvalidOperationException($"Cannot convert \"{value}\" into {typeof(Offset)}");
    }

    public bool TryExtractOffset(string token, out Offset result)
    {
        if (token != null)
        {
            if (token.TryExtractNumber("%", out var percent))
            {
                var value = Math.Min(percent / 100, 1f); // No bigger than 1
                result = new Offset(value, OffsetType.Proportional);
                return true;
            }

            if (token.TryExtractNumber("px", out var pixels))
            {
                result = new Offset(pixels, OffsetType.Absolute);
                return true;
            }
        }

        result = Offset.Zero;
        return false;
    }
}