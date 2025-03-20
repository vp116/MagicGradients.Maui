using System.ComponentModel;
using MagicGradients.Converters;

namespace MagicGradients;

[Flags]
[TypeConverter(typeof(FontAttributesTypeConverter))]
public enum FontAttributes
{
    None = 0,
    Bold = 1 << 0,
    Italic = 1 << 1
}

public enum TextAlignment
{
    Start,
    Center,
    End
}