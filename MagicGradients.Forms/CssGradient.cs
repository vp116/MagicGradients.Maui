namespace MagicGradients.Forms;

[ContentProperty(nameof(Stylesheet))]
public class CssGradient : GradientElement, IGradientSource
{
    public static readonly BindableProperty StylesheetProperty = BindableProperty.Create(
        nameof(Stylesheet),
        typeof(string),
        typeof(CssGradient),
        propertyChanged: OnStylesheetChanged);

    private readonly CssGradientSource _gradientSource = new();

    public string Stylesheet
    {
        get => (string)GetValue(StylesheetProperty);
        set => SetValue(StylesheetProperty, value);
    }

    public IReadOnlyList<IGradient> GetGradients()
    {
        return _gradientSource.GetGradients();
    }

    private static void OnStylesheetChanged(BindableObject bindable, object oldValue, object newValue)
    {
        ((CssGradient)bindable).InternalParse((string)newValue);
    }

    private void InternalParse(string css)
    {
        _gradientSource.Parse(css);
    }
}