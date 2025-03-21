﻿using MagicGradients.Drawing;
using MagicGradients.Masks;

namespace MagicGradients.Forms;

[ContentProperty(nameof(GradientSource))]
public class GradientView : GraphicsView, IGradientControl, IGradientVisualElement
{
    public static readonly BindableProperty GradientSourceProperty = GradientControl.GradientSourceProperty;
    public static readonly BindableProperty GradientSizeProperty = GradientControl.GradientSizeProperty;
    public static readonly BindableProperty GradientRepeatProperty = GradientControl.GradientRepeatProperty;
    public static readonly BindableProperty MaskProperty = GradientControl.MaskProperty;

    static GradientView()
    {
        GlobalSetup.Current.UseCssStyles<GradientView>();
    }

    public GradientView()
    {
        Drawable = new GradientDrawable(this);
    }

    public double ViewWidth => Width;

    public IGradientSource GradientSource
    {
        get => (IGradientSource)GetValue(GradientSourceProperty);
        set => SetValue(GradientSourceProperty, value);
    }

    public Dimensions GradientSize
    {
        get => (Dimensions)GetValue(GradientSizeProperty);
        set => SetValue(GradientSizeProperty, value);
    }

    public BackgroundRepeat GradientRepeat
    {
        get => (BackgroundRepeat)GetValue(GradientRepeatProperty);
        set => SetValue(GradientRepeatProperty, value);
    }

    public IGradientMask Mask
    {
        get => (IGradientMask)GetValue(MaskProperty);
        set => SetValue(MaskProperty, value);
    }

    public void InvalidateCanvas()
    {
        OnPropertyChanged(nameof(Drawable));
    }

    protected override void OnBindingContextChanged()
    {
        base.OnBindingContextChanged();
        this.SetBindingContext(BindingContext);
    }
}