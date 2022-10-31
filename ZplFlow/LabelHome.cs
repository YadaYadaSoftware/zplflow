namespace YadaYada.ZplFlow;

public record LabelHome : Fragment
{
    public LabelHome(int x, int y):base(y)
    {
        X = x;
        Y = y;
    }

    public int X { get; }
    public int Y { get; }

    public override string GetZpl()
    {
        return $"{Codes.LabelHome}{X},{Y}";
    }
}