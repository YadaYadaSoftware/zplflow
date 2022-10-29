using System.Text;

namespace YadaYada.ZplFlow;

public record Origin : Fragment
{
    public Origin()
    {
        
    }

    public Origin(int x, int y, JustificationEnum justification)
    {
        X = x;
        Y = y;
        Justification = justification;
    }

    public enum JustificationEnum
    {
        Left,
        Right,
        Auto
    }

    public int X { get; set; }
    public int Y { get; set; }
    public JustificationEnum Justification { get; set; }
    public override string GetZpl(Document document, bool withComments = false)
    {
        var zpl = new StringBuilder();
        if (withComments)
        {
            zpl.AppendLine($"{Codes.CommentStart} --- Origin {nameof(X)}='{X}', {nameof(Y)}='{Y}', {nameof(Justification)}='{Justification}' --- {Codes.CommentEnd}");
        }
        zpl.Append($"{Codes.FieldOrigin}{X},{Y},{(int)Justification}");
        return zpl.ToString();

    }
}