using System.Text;

namespace YadaYada.ZplFlow;

public record DefaultFont(char? Font = null, int? WidthInDots = null, int? HeightInDots = null) : Fragment(0)
{
    public char? Font { get; set; } = Font;
    public int? WidthInDots { get; set; } = WidthInDots;
    public int? HeightInDots { get; set; } = HeightInDots;

    public override string GetZpl()
    {
        var zpl = new StringBuilder();

        zpl.Append(Codes.DefaultFont);
        if (Font.HasValue)
        {
            zpl.Append(Font.Value);
        }
        zpl.Append(",");
        if (HeightInDots.HasValue)
        {
            zpl.Append(HeightInDots.Value);
        }
        zpl.Append(",");
        if (WidthInDots.HasValue)
        {
            zpl.Append(WidthInDots.Value);
        }
        return zpl.ToString();

    }
}