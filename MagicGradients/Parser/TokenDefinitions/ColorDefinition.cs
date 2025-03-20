using MagicGradients.Xaml;
using Microsoft.Maui.Graphics.Converters;

namespace MagicGradients.Parser.TokenDefinitions;

public class ColorDefinition
{
    protected ColorTypeConverter ColorConverter { get; } = new();
    protected OffsetTypeConverter OffsetConverter { get; } = new();

    protected List<Offset> GetOffsets(string[] tokens)
    {
        var offsets = new List<Offset>();

        foreach (var token in tokens)
            if (OffsetConverter.TryExtractOffset(token, out var offset))
                offsets.Add(offset);

        return offsets;
    }
}