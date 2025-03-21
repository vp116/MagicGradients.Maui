﻿using System.Diagnostics;

namespace MagicGradients.Forms.Animation;

[ContentProperty(nameof(Animations))]
public class Storyboard : Timeline
{
    public static readonly BindableProperty BeginAtProperty =
        BindableProperty.CreateAttached("BeginAt", typeof(double), typeof(Storyboard), 0d);

    public static readonly BindableProperty FinishAtProperty =
        BindableProperty.CreateAttached("FinishAt", typeof(double), typeof(Storyboard), 1d);

    public List<Timeline> Animations { get; set; } = new();

    public static double GetBeginAt(BindableObject view)
    {
        return (double)view.GetValue(BeginAtProperty);
    }

    public static void SetBeginAt(BindableObject view, double value)
    {
        view.SetValue(BeginAtProperty, value);
    }

    public static double GetFinishAt(BindableObject view)
    {
        return (double)view.GetValue(FinishAtProperty);
    }

    public static void SetFinishAt(BindableObject view, double value)
    {
        view.SetValue(FinishAtProperty, value);
    }

    public override void OnBegin()
    {
        foreach (var anim in Animations)
        {
            if (anim.Target == null)
                anim.Target = Target;

            anim.OnBegin();
        }
    }

    public override Microsoft.Maui.Controls.Animation OnAnimate()
    {
        var animation = new Microsoft.Maui.Controls.Animation();

        foreach (var anim in Animations)
        {
            var beginAt = GetBeginAt(anim);
            var finishAt = GetFinishAt(anim);

            if (anim.Duration > 0)
            {
                finishAt = Math.Min(finishAt, beginAt + (double)anim.Duration / Duration);
                Debug.WriteLine($"FinishAt updated to {finishAt}");
            }

            animation.Add(beginAt, finishAt, anim.OnAnimate());
        }

        return animation;
    }
}