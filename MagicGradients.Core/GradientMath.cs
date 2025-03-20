namespace MagicGradients;

internal static class GradientMath
{
    public static double ToRadians(double degrees)
    {
        return Math.PI / 180 * degrees;
    }

    public static double RotateBy180(double degrees)
    {
        return (180 + degrees) % 360;
    }
}