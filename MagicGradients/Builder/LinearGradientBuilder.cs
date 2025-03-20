namespace MagicGradients.Builder;

public class LinearGradientBuilder : StopsBuilder<LinearGradientBuilder>, IChildBuilder
{
    public LinearGradientBuilder()
    {
        Angle = 0;
        IsRepeating = false;
    }

    protected override LinearGradientBuilder Instance => this;

    internal double Angle { get; set; }
    internal bool IsRepeating { get; set; }

    public Gradient Construct()
    {
        var linearGradient = new LinearGradient
        {
            Angle = Angle,
            IsRepeating = IsRepeating,
            Stops = new GradientElements<GradientStop>(StopsFactory.Stops)
        };

        return linearGradient;
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