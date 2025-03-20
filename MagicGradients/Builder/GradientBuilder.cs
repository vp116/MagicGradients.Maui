namespace MagicGradients.Builder;

public class GradientBuilder : StopsBuilder<GradientBuilder>
{
    private readonly List<IChildBuilder> _children = new();
    private IChildBuilder _currentBuilder;

    protected override GradientBuilder Instance => this;
    public override StopsFactory StopsFactory => GetCurrentBuilder().StopsFactory;

    public GradientBuilder AddLinearGradient(Action<LinearGradientBuilder> setup = null)
    {
        var builder = new LinearGradientBuilder();
        setup?.Invoke(builder);

        UseBuilder(builder);
        return this;
    }

    public GradientBuilder AddRadialGradient(Action<RadialGradientBuilder> setup = null)
    {
        var builder = new RadialGradientBuilder();
        setup?.Invoke(builder);

        UseBuilder(builder);
        return this;
    }

    public GradientBuilder AddCssGradient(string styleSheet)
    {
        var builder = new CssGradientBuilder(styleSheet);

        UseBuilder(builder);
        return this;
    }

    public void UseBuilder(IChildBuilder builder)
    {
        _currentBuilder = builder;
        _children.Add(builder);
    }

    public Gradient[] Build()
    {
        return _children.Select(x => x.Construct()).ToArray();
    }

    private IChildBuilder GetCurrentBuilder()
    {
        if (_currentBuilder == null) UseBuilder(new LinearGradientBuilder());

        return _currentBuilder;
    }
}