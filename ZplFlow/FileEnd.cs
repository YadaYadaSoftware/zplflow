namespace YadaYada.ZplFlow;

public record FileEnd : Fragment
{
    public override string GetZpl()
    {
        return Codes.FileEnd;
    }
}