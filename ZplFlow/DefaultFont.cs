using System.Text;

namespace YadaYada.ZplFlow;

public record DefaultFont(char? Font = null, int? WidthInDots = null, int? HeightInDots = null) : Fragment
{
    public char? Font { get; set; } = Font;
    public int? WidthInDots { get; set; } = WidthInDots;
    public int? HeightInDots { get; set; } = HeightInDots;

    public override string GetZpl(Document document, bool withComments = false)
    {
        var zpl = new StringBuilder();

        if (withComments)
        {
            zpl.AppendLine($"{Codes.CommentStart} --- {nameof(DefaultFont)} {nameof(Font)}='{Font}', {nameof(HeightInDots)}='{HeightInDots}', {nameof(WidthInDots)}='{WidthInDots}' --- {Codes.CommentEnd}");
        }

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