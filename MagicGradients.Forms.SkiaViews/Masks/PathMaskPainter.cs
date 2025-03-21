﻿using MagicGradients.Drawing;
using MagicGradients.Masks;
using SkiaSharp;
using DrawContext = MagicGradients.Forms.SkiaViews.Drawing.DrawContext;

namespace MagicGradients.Forms.SkiaViews.Masks
{
    public class PathMaskPainter : GradientMaskPainter, IMaskPainter<IPathMask, DrawContext>
    {
        public void Clip(IPathMask mask, DrawContext context)
        {
            if (!mask.IsActive || string.IsNullOrEmpty(mask.Data))
                return;

            using var path = SKPath.ParseSvgPathData(mask.Data);
            path.GetTightBounds(out var bounds);

            using var canvasLock = new CanvasLock(context.Canvas);
            LayoutBounds(mask, bounds, context, true);
            context.Canvas.ClipPath(path, mask.ClipMode.ToSkOperation());
        }
    }
}
