using System.Runtime.Serialization;

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
    public ScalableBitmappedFont(string font = "0", int fragmentWidth = 0, int fragmentHeight = 0, Orientation orientation = Orientation.Normal)
    {
        this.Font = font;
        this.FontWidth = fragmentWidth;
        this.FontHeight = fragmentHeight;
        this.Orientation = orientation;
    }
    public override string GetZpl(Document document)
    {
        return $"{Codes.ScalableBitmappedFont}{this.Font}{this.Orientation.GetEnumMemberValue()},{this.FontHeight},{this.FontWidth}";
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