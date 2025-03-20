using System.Diagnostics;

namespace MagicGradients.Forms.Animation;

public abstract class PropertyAnimation<TValue> : Timeline
{
    private TValue _animateFrom;
    private TValue _animateTo;
    public BindableProperty TargetProperty { get; set; } = default;
    public TValue From { get; set; }
    public TValue To { get; set; } = default;
    public abstract ITweener<TValue> Tweener { get; }

    public override void OnBegin()
    {
        base.OnBegin();

        if (TargetProperty == null) throw new NullReferenceException("Null Target property.");

        SetDefaults((TValue)Target.GetValue(TargetProperty));
    }

    private void SetDefaults(TValue value)
    {
        From = From.Equals(default(TValue)) ? value : From;

        _animateFrom = From;
        _animateTo = To;
    }

    public override Microsoft.Maui.Controls.Animation OnAnimate()
    {
        return new Microsoft.Maui.Controls.Animation(x =>
            {
                var value = Tweener.Tween(_animateFrom, _animateTo, x);
                Target.SetValue(TargetProperty, value);
            },
            easing: Easing,
            finished: () =>
            {
                Debug.WriteLine($"Property [{TargetProperty.PropertyName}] Finished (value: {_animateTo})");
                OnFinished();
            });
    }

    public override void OnFinished()
    {
        Debug.WriteLine($"Property [{TargetProperty.PropertyName}] OnFinished()");

        if (AutoReverse)
        {
            var tmp = _animateFrom;
            _animateFrom = _animateTo;
            _animateTo = tmp;
        }
    }
}