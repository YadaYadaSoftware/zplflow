namespace YadaYada.ZplFlow;

public record FileStart : Fragment
{
    public override string GetZpl(Document document)
    {
        return Codes.FileStart;
    }
}