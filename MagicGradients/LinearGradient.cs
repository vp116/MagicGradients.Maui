﻿using MagicGradients.Renderers;

namespace MagicGradients;

public class LinearGradient : Gradient
{
    public static readonly BindableProperty AngleProperty = BindableProperty.Create(
        nameof(Angle), typeof(double), typeof(LinearGradient), 0d);

    public static readonly BindableProperty UseLegacyShaderProperty =
        BindableProperty.CreateAttached("UseLegacyShader", typeof(bool), typeof(LinearGradient), false,
            propertyChanged: OnUseLegacyShaderChanged);

    public double Angle
    {
        get => (double)GetValue(AngleProperty);
        set => SetValue(AngleProperty, value);
    }

    public static bool GetUseLegacyShader(BindableObject view)
    {
        return (bool)view.GetValue(UseLegacyShaderProperty);
    }

    public static void SetUseLegacyShader(BindableObject view, bool value)
    {
        view.SetValue(UseLegacyShaderProperty, value);
    }

    public override void InstantiateShader(BindableObject view)
    {
        if (GetUseLegacyShader(view))
            Shader = new LinearGradientShaderLegacy(this);
        else
            Shader = new LinearGradientShader(this);
    }

    private static void OnUseLegacyShaderChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var view = (IGradientControl)bindable;

        if (view.GradientSource != null)
        {
            foreach (var gradient in view.GradientSource.GetGradients().Where(x => x is LinearGradient))
                gradient.InstantiateShader(bindable);

            ((IGradientVisualElement)view).InvalidateCanvas();
        }
    }
}