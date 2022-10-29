namespace YadaYada.ZplFlow;

public class Origin : Fragment
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
    public override string GetZpl(Document document)
    {
        return $"{Codes.FieldOrigin}{X},{Y},{Justification}";
    }
}