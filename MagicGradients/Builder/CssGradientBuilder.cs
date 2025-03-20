using MagicGradients.Parser;

namespace MagicGradients.Builder;

public class CssGradientBuilder : StopsBuilder<CssGradientBuilder>, IChildBuilder
{
    public CssGradientBuilder(string styleSheet)
    {
        StyleSheet = styleSheet;
    }

    protected override CssGradientBuilder Instance => this;

    internal string StyleSheet { get; set; }

    public Gradient Construct()
    {
        var parsed = new CssGradientParser().ParseCss(StyleSheet);
        if (parsed.Length != 1)
            throw new InvalidOperationException("StyleSheet must contain single gradient function.");
        return parsed.First();
    }
}