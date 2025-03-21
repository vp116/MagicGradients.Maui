using MagicGradients.Parser;

namespace MagicGradients;

[ContentProperty(nameof(Stylesheet))]
public class CssGradientSource : GradientCollection
{
    public static readonly BindableProperty StylesheetProperty = BindableProperty.Create(
        nameof(Stylesheet), typeof(string), typeof(CssGradientSource), propertyChanged: OnStylesheetChanged);

    public string Stylesheet
    {
        get => (string)GetValue(StylesheetProperty);
        set => SetValue(StylesheetProperty, value);
    }

    private static void OnStylesheetChanged(BindableObject bindable, object oldValue, object newValue)
    {
        ((CssGradientSource)bindable).InternalParse((string)newValue);
    }

    private void InternalParse(string css)
    {
        var parsed = new CssGradientParser().ParseCss(css);
        Gradients = new GradientElements<Gradient>(parsed);
    }

    public static CssGradientSource Parse(string css)
    {
        return new CssGradientSource
        {
            Stylesheet = css
        };
    }
}