using System.ComponentModel;
using MagicGradients.Maui;

namespace MagicGradients;

[TypeConverter(typeof(CssGradientSourceTypeConverter))]
public interface IGradientSource
{
    IEnumerable<Gradient> GetGradients();
}