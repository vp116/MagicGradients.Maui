﻿using MagicGradients.Masks;

namespace MagicGradients;

public partial class GradientView : IGradientControl
{
    private BackgroundRepeat _gradientRepeat;

    private Dimensions _gradientSize;

    private IGradientSource _gradientSource;

    private IGradientMask _mask;
    public double ViewWidth { get; private set; }

    public IGradientSource GradientSource
    {
        get => _gradientSource;
        set => SetValue(ref _gradientSource, value);
    }

    public Dimensions GradientSize
    {
        get => _gradientSize;
        set => SetValue(ref _gradientSize, value);
    }

    public BackgroundRepeat GradientRepeat
    {
        get => _gradientRepeat;
        set => SetValue(ref _gradientRepeat, value);
    }

    public IGradientMask Mask
    {
        get => _mask;
        set => SetValue(ref _mask, value);
    }

    private void SetValue<T>(ref T field, T value)
    {
        field = value;
        InvalidateNative();
    }

    partial void InvalidateNative();
}