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
    public override string GetZpl()
    {
        var zpl = new StringBuilder();
        zpl.Append($"{Codes.FieldOrigin}{X},{Y},{(int)Justification}");
        return zpl.ToString();

    }
}