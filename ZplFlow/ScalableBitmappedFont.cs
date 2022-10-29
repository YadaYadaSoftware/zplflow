using System.Runtime.Serialization;
using System.Text;

namespace YadaYada.ZplFlow;

public interface IScalableBitmappedFont
{
    string Font { get; set; }
    int? FontWidth { get; set; }
    Orientation Orientation { get; set; }
    int? FontHeight { get; set; }
}

public class ScalableBitmappedFont : Fragment, IScalableBitmappedFont
{
    public ScalableBitmappedFont(string font = "M", int fragmentWidth = 10, int fragmentHeight = 10, Orientation orientation = Orientation.Normal)
    {
        this.Font = font;
        this.FontWidth = fragmentWidth;
        this.FontHeight = fragmentHeight;
        this.Orientation = orientation;
    }
    public override string GetZpl(Document document, bool withComments = false)
    {
        var zpl = new StringBuilder();
        if (withComments)
        {
            zpl.AppendLine($"{Codes.CommentStart} --- Set Font: {nameof(Font)}='{this.Font}, {nameof(Orientation)}='{this.Orientation}', {nameof(FontHeight)}='{this.FontHeight}', {nameof(FontWidth)}='{this.FontWidth}' --- {Codes.CommentEnd}");
        }
        zpl.Append($"{Codes.ScalableBitmappedFont}{this.Font}{this.Orientation.GetEnumMemberValue()},{this.FontHeight},{this.FontWidth}");
        zpl.AppendLine();
        return zpl.ToString();
    }
    public string Font { get; set; }
    public int? FontWidth { get; set; }
    public Orientation Orientation { get; set; }
    public int? FontHeight { get; set; }
}

public enum Orientation
{
    [EnumMember(Value = "N")] Normal,
    [EnumMember(Value = "R")] Rotated90,
    [EnumMember(Value = "I")] Rotated180,
    [EnumMember(Value = "B")] Rotated270
}