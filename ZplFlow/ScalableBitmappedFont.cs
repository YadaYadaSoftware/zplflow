using System.Runtime.Serialization;
using System.Text;

namespace YadaYada.ZplFlow;

public interface IScalableBitmappedFont
{
    char FontCode { get; set; }
    int? FontWidth { get; set; }
    Orientation Orientation { get; set; }
    int? FontHeight { get; set; }
}

public record ScalableBitmappedFont : Fragment, IScalableBitmappedFont
{
    public ScalableBitmappedFont(char fontCode, Orientation orientation, int fontWidth , int fontHeight):base(0)
    {
        FontCode = fontCode;
        Orientation = orientation;
        FontWidth = fontWidth;
        FontHeight = fontHeight;
    }
    public override string GetZpl()
    {
        var zpl = new StringBuilder();
        zpl.Append($"{Codes.ScalableBitmappedFont}{this.FontCode}{this.Orientation.GetEnumMemberValue()},{this.FontHeight},{this.FontWidth}");
        return zpl.ToString();
    }
    public char FontCode { get; set; }
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