namespace YadaYada.ZplFlow;

public record FileStart : Fragment
{
    public override string GetZpl()
    {
        return Codes.FileStart;
    }
}