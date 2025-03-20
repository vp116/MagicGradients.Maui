using MagicGradients.Parser;

namespace MagicGradients;

public class CssGradientSource : IGradientSource
{
    private readonly CssGradientParser _parser = new();
    private List<IGradient> _gradients;

    public CssGradientSource()
    {
        _gradients = new List<IGradient>();
    }

    public CssGradientSource(string css)
    {
        Parse(css);
    }

    public IReadOnlyList<IGradient> GetGradients()
    {
        return _gradients;
    }

    public void Parse(string css)
    {
        _gradients = _parser.Parse(css);
    }
}