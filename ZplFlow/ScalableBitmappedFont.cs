using System.Runtime.Serialization;

namespace YadaYada.ZplFlow;

public class ScalableBitmappedFont : Fragment
{
    public ScalableBitmappedFont(string font = "0", int width = 10, int height = 10, Orientation orientation = Orientation.Normal)
    {
        this.Font = font;
        this.Width = width;
        this.Height = height;
        this.Orientation = orientation;
    }
    public override string GetZpl(Document document)
    {
        return $"{Codes.ScalableBitmappedFont}{this.Font}{this.Orientation.GetEnumMemberValue()},{this.Height},{this.Width}";
    }
    public string Font { get; }
    public int? Width { get; }
    public Orientation Orientation { get; }
    
}

public enum Orientation
{
    [EnumMember(Value = "N")] Normal,
    [EnumMember(Value = "R")] Rotated90,
    [EnumMember(Value = "I")] Rotated180,
    [EnumMember(Value = "B")] Rotated270
}