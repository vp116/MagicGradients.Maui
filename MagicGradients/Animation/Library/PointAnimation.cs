﻿using MagicGradients.Animation.Tween;

namespace MagicGradients.Animation;

public class PointAnimation : PropertyAnimation<Point>
{
    public override ITweener<Point> Tweener { get; } = new PointTweener();
}

public class PointAnimationUsingKeyFrames : PropertyAnimationUsingKeyFrames<Point>
{
    public override ITweener<Point> Tweener { get; } = new PointTweener();
}

public class PointKeyFrame : KeyFrame<Point>
{
}