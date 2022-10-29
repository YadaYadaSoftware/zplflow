using System.Runtime.Serialization;

namespace YadaYada.ZplFlow;

public class ScalableBitmappedFont : Fragment
{
    public ScalableBitmappedFont(string font, int width, int height, Orientation orientation)
    {
        this.Font = font;
        this.Width = width;
        this.Height = height;
        this.Orientation = orientation;
    }
    public override string GetZpl()
    {
        return $"{Codes.ScalableBitmappedFont}{this.Font}{this.Orientation.ToStringFromEnumMember()},{this.Height},{this.Width}";
    }
    public string Font { get; }
    public int? Width { get; }
    public int? Height { get; }
    public Orientation Orientation { get; }
    
}

public enum Orientation
{
    [EnumMember(Value = "N")] Normal,
    [EnumMember(Value = "R")] Rotated90,
    [EnumMember(Value = "I")] Rotated180,
    [EnumMember(Value = "B")] Rotated270
}

public static class EnumHelper
{
    public static string ToStringFromEnumMember(this Enum @enum)
    {
        return @enum.GetType()
            .GetMember(@enum.ToString())
            .First()
            .GetCustomAttributes(typeof(EnumMemberAttribute), false)
            .Cast<EnumMemberAttribute>()
            .First()
            .Value;
    }
}