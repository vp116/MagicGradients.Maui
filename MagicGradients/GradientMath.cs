namespace MagicGradients;

public static class GradientMath
{
    public static double ToRadians(double degrees)
    {
        return Math.PI / 180 * degrees;
    }

    public static double FromDegrees(double degrees)
    {
        return (180 + degrees) % 360;
    }
}