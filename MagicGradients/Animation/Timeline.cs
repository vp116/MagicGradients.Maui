﻿using System.Diagnostics;

namespace MagicGradients.Animation;

public abstract class Timeline : BindableObject
{
    private readonly string _handle = Guid.NewGuid().ToString();
    private int _playCount;

    public uint Duration { get; set; } = 0;
    public int Delay { get; set; } = 0;
    public RepeatBehavior RepeatBehavior { get; set; } = new(RepeatBehaviorType.Count, 1);
    public bool AutoReverse { get; set; }
    public Easing Easing { get; set; } = Easing.Linear;
    public BindableObject Target { get; set; } = default;
    public VisualElement Animator { get; private set; }

    public async Task Begin(VisualElement animator)
    {
        Animator = animator;
        OnBegin();

        if (Delay > 0) await Task.Delay(Delay);

        Animate();
    }

    private void Animate()
    {
        Animator.Animate(_handle, OnAnimate(),
            length: Duration,
            easing: Easing,
            finished: (v, c) =>
            {
                _playCount++;
                Debug.WriteLine($"Timeline Finished (plays: {_playCount}, handle: {_handle})");
                OnFinished();
            },
            repeat: IsRepeat);
    }

    public void End()
    {
        Animator?.AbortAnimation(_handle);
        _playCount = 0;
    }

    public virtual void OnBegin()
    {
        if (Target == null) throw new NullReferenceException("Null Target property.");
    }

    public abstract Microsoft.Maui.Controls.Animation OnAnimate();

    public virtual void OnFinished()
    {
    }

    protected bool IsRepeat()
    {
        if (RepeatBehavior.Type == RepeatBehaviorType.Forever)
            return true;

        return _playCount < RepeatBehavior.Count - 1;
    }
}