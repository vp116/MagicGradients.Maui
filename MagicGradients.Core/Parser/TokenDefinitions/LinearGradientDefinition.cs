using MagicGradients.Builder;

namespace MagicGradients.Parser.TokenDefinitions;

public class LinearGradientDefinition : ITokenDefinition
{
    public bool IsMatch(string token)
    {
        return token == CssToken.LinearGradient ||
               token == CssToken.RepeatingLinearGradient;
    }

    public void Parse(CssReader reader, GradientBuilder builder)
    {
        var repeating = reader.Read().Trim() == CssToken.RepeatingLinearGradient;
        var direction = reader.ReadNext().Trim();
        var angle = 0d;

        var hasAngle = TryConvertDegreeToAngle(direction, out angle) ||
                       TryConvertTurnToAngle(direction, out angle) ||
                       TryConvertNamedDirectionToAngle(direction, out angle);

        builder.UseBuilder(new LinearGradientBuilder
        {
            Angle = angle,
            IsRepeating = repeating
        });

        if (!hasAngle) reader.Rollback();
    }

    internal bool TryConvertDegreeToAngle(string token, out double angle)
    {
        if (Offset.TryExtractNumber(token, "deg", out var degrees))
        {
            angle = GradientMath.RotateBy180(degrees);
            return true;
        }

        // For "0" deg is optional
        if (token.Equals("0", StringComparison.OrdinalIgnoreCase))
        {
            angle = GradientMath.RotateBy180(0);
            return true;
        }

        angle = 0;
        return false;
    }

    internal bool TryConvertTurnToAngle(string token, out double angle)
    {
        if (Offset.TryExtractNumber(token, "turn", out var turn))
        {
            angle = GradientMath.RotateBy180(360 * turn);
            return true;
        }

        angle = 0;
        return false;
    }

    internal bool TryConvertNamedDirectionToAngle(string token, out double angle)
    {
        var reader = new CssReader(token, ' ');

        if (reader.CanRead && reader.Read() == "to")
        {
            var defaultVector = Vector2.Down; // By default gradient is drawn top-down
            var directionVector = Vector2.Zero;

            reader.MoveNext();

            while (reader.CanRead)
            {
                directionVector.SetNamedDirection(reader.Read());
                reader.MoveNext();
            }

            angle = Vector2.Angle(ref defaultVector, ref directionVector);

            // We start rotation from Vector(0, -1) clockwise
            // If gradient ends in I or II quarter of coordinate system
            // we use angle to calculate actual rotation

            if (directionVector.X > 0) angle = 360 - angle;

            return true;
        }

        angle = 0;
        return false;
    }
}