namespace MagicGradients.Builder;

public class LinearGradientBuilder : StopsBuilder<LinearGradientBuilder>, IChildBuilder
{
    public LinearGradientBuilder()
    {
        Angle = 0;
        IsRepeating = false;
    }

    protected override LinearGradientBuilder Instance => this;

    public double Angle { get; internal set; }
    public bool IsRepeating { get; internal set; }

    public void AddConstructed(List<IGradient> gradients)
    {
        gradients.Add(Factory.Construct(this));
    }

    public LinearGradientBuilder Rotate(double angle)
    {
        Angle = angle;
        return this;
    }

    public LinearGradientBuilder Repeat()
    {
        IsRepeating = true;
        return this;
    }
}