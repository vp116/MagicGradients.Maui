using MagicGradients.Parser;

namespace MagicGradients.Builder;

public class CssGradientBuilder : StopsBuilder<CssGradientBuilder>, IChildBuilder
{
    public CssGradientBuilder(string styleSheet)
    {
        StyleSheet = styleSheet;
    }

    protected override CssGradientBuilder Instance => this;

    internal string StyleSheet { get; }

    public void AddConstructed(List<IGradient> gradients)
    {
        gradients.AddRange(new CssGradientParser().Parse(StyleSheet));
    }
}