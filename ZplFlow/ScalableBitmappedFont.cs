using System.Runtime.Serialization;
using System.Text;

namespace YadaYada.ZplFlow;

public interface IScalableBitmappedFont
{
    char Font { get; set; }
    int? FontWidth { get; set; }
    Orientation Orientation { get; set; }
    int? FontHeight { get; set; }
}

public record ScalableBitmappedFont : Fragment, IScalableBitmappedFont
{
    public ScalableBitmappedFont(char font, Orientation orientation, int? fragmentWidth = null, int? fragmentHeight = null)
    {
        Font = font;
        Orientation = orientation;
        FragmentWidth = fragmentWidth;
        FragmentHeight = fragmentHeight;
    }
    public override string GetZpl(Document document)
    {
        var zpl = new StringBuilder();
        zpl.Append($"{Codes.ScalableBitmappedFont}{this.Font}{this.Orientation.GetEnumMemberValue()},");
        if (this.FontHeight.HasValue)
        {
            zpl.Append(this.FontHeight.Value);
        }
        zpl.Append(",");
        if (this.FontWidth.HasValue)
        {
            zpl.Append(this.FontWidth.Value);
        }
        
        return zpl.ToString();
    }
    public char Font { get; set; }
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